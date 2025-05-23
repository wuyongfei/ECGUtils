using MathNet.Numerics;
using OxyPlot.Series;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.IntegralTransforms;
using MathNet.Numerics.RootFinding; //;
using MathNet.Filtering;
using MathNet.Filtering.FIR;


namespace ECGPWaveLabelling;

public static class Wavelet
{
    public static void Show(double[] ecgSignal, string leadName)
    {
        // 1. 生成模拟ECG信号
        double fs = 500; // 采样频率 (Hz)
        double[] t = Generate.LinearRange(0, 10, 1 / fs); // 时间轴 (10秒)
        //double[] ecgSignal = t.Select(x => Math.Sin(2 * Math.PI * 1.0 * x) + 0.5 * Math.Sin(2 * Math.PI * 5.0 * x)).ToArray(); // 模拟ECG信号

        // 2. 预处理：滤波（去除高频噪声和基线漂移）
        double[] filteredEcg = BandpassFilter(ecgSignal, 0.5, 40, fs);

        // 3. 使用小波变换检测P波
        List<int> pWavePositions = DetectPWaveUsingWavelet(filteredEcg, fs);

        // 4. 可视化结果
        PlotECG(t, filteredEcg, pWavePositions);

        //// 5. 输出P波的位置
        //Console.WriteLine("P波的位置（索引）：");
        //foreach (int position in pWavePositions)
        //{
        //    Console.WriteLine(position);
        //}

        //Console.WriteLine("P波对应的时间点（秒）：");
        //foreach (int position in pWavePositions)
        //{
        //    Console.WriteLine(t[position].ToString("F2"));
        //}
    }

    // 带通滤波器
    static double[] BandpassFilter(double[] data, double lowcut, double highcut, double fs, int order = 4)
    {
        // var bandpass = new OnlineBandpassFilter(lowcut, highcut, fs, order);
        var bandpass = OnlineFirFilter.CreateBandpass(ImpulseResponse.Finite, fs, lowcut, highcut);
        return bandpass.ProcessSamples(data);
    }

    // 使用小波变换检测P波
    static List<int> DetectPWaveUsingWavelet(double[] data, double fs)
    {
        // 选择小波基函数（例如Daubechies小波）
        var wavelet = new DaubechiesWavelet(4); // Daubechies 4小波

        // 进行小波变换
        int levels = 5; // 小波分解的层数
        var waveletCoefficients = WaveletTransform.DWT(data, wavelet, levels);

        // 提取与P波相关的频带（通常在第3-4层）
        int pWaveLevel = 3;
        double[] pWaveBand = waveletCoefficients[pWaveLevel];

        // 检测P波的位置
        double threshold = 0.3 * pWaveBand.Max(); // 设置阈值
        List<int> pWavePositions = FindPeaks(pWaveBand, threshold);

        // 将小波域的位置映射回时域
        pWavePositions = pWavePositions.Select(p => p * (int)Math.Pow(2, pWaveLevel)).ToList();

        return pWavePositions;
    }

    // 检测峰值
    static List<int> FindPeaks(double[] data, double height, int? distance = null)
    {
        List<int> peaks = new List<int>();
        for (int i = 1; i < data.Length - 1; i++)
        {
            if (data[i] > height && data[i] > data[i - 1] && data[i] > data[i + 1])
            {
                if (distance.HasValue && peaks.Any() && i - peaks.Last() < distance)
                {
                    if (data[i] > data[peaks.Last()])
                    {
                        peaks.RemoveAt(peaks.Count - 1);
                        peaks.Add(i);
                    }
                }
                else
                {
                    peaks.Add(i);
                }
            }
        }
        return peaks;
    }

    // 可视化ECG信号
    static void PlotECG(double[] t, double[] ecgSignal, List<int> pWavePositions)
    {
        var plotModel = new PlotModel { Title = "ECG Signal with P Waves (fs = 500 Hz)" };
        var ecgSeries = new LineSeries { Title = "Filtered ECG" };
        var pWaveSeries = new ScatterSeries { Title = "P Waves", MarkerType = MarkerType.Circle, MarkerSize = 5, MarkerFill = OxyColors.Green };

        // 添加ECG信号
        for (int i = 0; i < t.Length; i++)
        {
            ecgSeries.Points.Add(new DataPoint(t[i], ecgSignal[i]));
        }

        // 添加P波
        foreach (int pWave in pWavePositions)
        {
            pWaveSeries.Points.Add(new ScatterPoint(t[pWave], ecgSignal[pWave]));
        }

        plotModel.Series.Add(ecgSeries);
        plotModel.Series.Add(pWaveSeries);

        var plotView = new OxyPlot.WindowsForms.PlotView { Model = plotModel };
        var form = new System.Windows.Forms.Form();
        form.Controls.Add(plotView);
        plotView.Dock = System.Windows.Forms.DockStyle.Fill;
        form.ShowDialog();
    }
}
