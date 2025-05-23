using MathNet.Numerics;
using MathNet.Numerics.IntegralTransforms;
using OxyPlot.Series;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECGPWaveLabelling;

public static class Bandpass
{
    public static void Show(short[] signal, string leadName)
    {
        // 1. 生成模拟ECG信号
        int fs = 500; // 采样频率 (Hz)

        //                               START, STEP,      STOP
        double[] t = Generate.LinearRange(0.0F, 1.0F / fs, 10.0F); // 时间轴 (10秒)

        double[] ecgSignal = signal.Select(x => (double)x).ToArray();

        // 2. 预处理：滤波（去除高频噪声和基线漂移）
        double[] filteredEcg = BandpassFilter(ecgSignal, 0.5, 40, fs);  // 0.5

        // 3. 检测QRS复合波（R峰）
        List<int> rPeaks = FindRPeaks(filteredEcg, fs);

        // 4. 检测P波并标记起止位置
        List<(int Start, int End, int Peak)> pWaveRanges = new List<(int, int, int)>();
        foreach (int rPeak in rPeaks)
        {
            int pWaveStart = rPeak - (int)(0.2 * fs); // P波开始位置（200毫秒前）
            if (pWaveStart < 0) continue;   // QRS 波太靠前
            int pWaveEnd = rPeak - (int)(0.08 * fs);  // P波结束位置（120毫秒前）

            // 确保起止位置在数组范围内
            pWaveStart = Math.Max(pWaveStart, 0);
            pWaveEnd = Math.Min(pWaveEnd, filteredEcg.Length - 1);

            // 在P波段内寻找峰值
            double[] pWaveSegment = filteredEcg.Skip(pWaveStart).Take(pWaveEnd - pWaveStart).ToArray();
            List<int> pPeaks = FindPeaks(pWaveSegment, 0.3 * pWaveSegment.Max());

            if (pPeaks.Count > 0)
            {
                int peak = pWaveStart + pPeaks[0];

                switch (pPeaks.Count)
                {
                    case 1:
                        peak = pWaveStart + pPeaks[0];
                        break;
                    case 2:
                        peak = (ecgSignal[pWaveStart + pPeaks[0]] > ecgSignal[pWaveStart + pPeaks[1]]) ? (pWaveStart + pPeaks[0]) : (pWaveStart + pPeaks[1]);
                        break;
                    default:
                        peak = GetPWavePeakIndex(ecgSignal, pWaveStart, pPeaks.ToArray());
                        break;
                }

                Debug.WriteLine($"{pPeaks.Count}");
                // 记录P波的起止位置和峰值位置
                Debug.WriteLine($"({pWaveStart}, {pWaveEnd}, {peak})");
                pWaveRanges.Add((pWaveStart, pWaveEnd, peak));
            }
        }

        // 5. 输出P波的起止位置
        Debug.WriteLine("P波的起止位置（索引）：");
        foreach (var range in pWaveRanges)
        {
            Debug.WriteLine($"({range.Start}, {range.End})");
        }

        Debug.WriteLine("P波的起止时间点（秒）：");
        foreach (var range in pWaveRanges)
        {
            Debug.WriteLine($"({t[range.Start]:F2}, {t[range.End]:F2})");
        }

        // 6. 可视化结果
        PlotECG(t, filteredEcg, rPeaks, pWaveRanges, leadName);

    }

    // 带通滤波器
    private static double[] BandpassFilter(double[] data, double lowCutoff, double highCutoff, int samplingRate)
    {
        // Convert data to Complex numbers for FFT
        var complexSignal = new System.Numerics.Complex[data.Length];
        for (int i = 0; i < data.Length; i++)
        {
            complexSignal[i] = new System.Numerics.Complex(data[i], 0);
        }

        // Apply Fast Fourier Transform (FFT)
        Fourier.Forward(complexSignal, FourierOptions.Matlab);

        // Frequency Resolution
        double freqResolution = (double)samplingRate / data.Length;

        // Bandpass filter in frequency domain
        for (int i = 0; i < complexSignal.Length; i++)
        {
            double frequency = i * freqResolution;

            // Zero out frequencies outside the desired range
            if (frequency < lowCutoff || frequency > highCutoff)
            {
                complexSignal[i] = System.Numerics.Complex.Zero;
            }
        }

        // Inverse FFT to get filtered signal
        Fourier.Inverse(complexSignal, FourierOptions.Matlab);

        // Extract real part of the signal
        double[] filteredData = new double[data.Length];
        for (int i = 0; i < complexSignal.Length; i++)
        {
            filteredData[i] = complexSignal[i].Real;
        }

        return filteredData;
    }

    // 检测R峰
    private static List<int> FindRPeaks(double[] data, double fs)
    {
        double height = data.Max() * 0.5;
        int distance = (int)(fs * 0.6);
        return FindPeaks(data, height, distance);
    }

    // 检测峰值
    private static List<int> FindPeaks(double[] data, double height, int? distance = null)
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

    private static int GetPWavePeakIndex(double[] ecgData, int start, int[] pPeaks)
    {
        double[] peakValues = new double[pPeaks.Length];
        for (int idx = 0; idx < pPeaks.Length; idx++)
        {
            peakValues[idx] = ecgData[start + pPeaks[idx]];
        }

        int maxIndex = peakValues.ToList().LastIndexOf(peakValues.Max());
        return start + pPeaks[maxIndex];
    }

    // 可视化ECG信号
    private static void PlotECG(double[] t, double[] ecgSignal, List<int> rPeaks, List<(int Start, int End, int Peak)> pWaveRanges, string leadName)
    {
        var plotModel = new PlotModel { Title = $"{leadName} ECG Signal with R Peaks and P Waves (fs = 500 Hz)" };
        var ecgSeries = new LineSeries { Title = "Filtered ECG", Color = OxyColors.Red };
        var rPeakSeries = new ScatterSeries { Title = "R Peaks", MarkerType = MarkerType.Circle, MarkerSize = 5, MarkerFill = OxyColors.Red };
        var pPeakSeries = new ScatterSeries { Title = "R Peaks", MarkerType = MarkerType.Circle, MarkerSize = 3, MarkerFill = OxyColors.Blue };

        // 添加ECG信号
        for (int i = 0; i < t.Length; i++)
        {
            ecgSeries.Points.Add(new DataPoint(t[i], ecgSignal[i]));
        }

        // 添加R峰
        foreach (int rPeak in rPeaks)
        {
            rPeakSeries.Points.Add(new ScatterPoint(t[rPeak], ecgSignal[rPeak]));
        }

        // 添加P波区域
        foreach (var range in pWaveRanges)
        {
            var pWaveSeries = new LineSeries { Title = "P Wave", Color = OxyColors.Black };
            for (int i = range.Start; i < range.End; i++)
            {
                pWaveSeries.Points.Add(new DataPoint(t[i], ecgSignal[i]));
            }
            plotModel.Series.Add(pWaveSeries);
            pPeakSeries.Points.Add(new ScatterPoint(t[range.Peak], ecgSignal[range.Peak]));
        }

        plotModel.Series.Add(ecgSeries);
        plotModel.Series.Add(rPeakSeries);
        plotModel.Series.Add(pPeakSeries);

        var plotView = new OxyPlot.WindowsForms.PlotView { Model = plotModel };
        var form = new System.Windows.Forms.Form();
        form.Controls.Add(plotView);
        plotView.Dock = System.Windows.Forms.DockStyle.Fill;
        form.Size = new Size(1000, 400);
        form.Show();
    }
}
