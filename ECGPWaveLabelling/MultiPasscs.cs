using MathNet.Filtering;
using MathNet.Filtering.FIR;
using OxyPlot.Series;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Policy;
using MathNet.Numerics;

namespace ECGPWaveLabelling;

public static class MultiPass
{
    //signal + noise
    static double _fs = 500; //sampling rate
    //static double _fw = 5; //signal frequency
    //static double _fn = 50; //noise frequency
    //static double _n = 5; //number of periods to show
    //static double _A = 10; //signal amplitude
    //static double _N = 1; //noise amplitude
    //static int _size = (int)(_n * _fs / _fw); //sample size

    public static void Show(short[] signal, string leadName)
    {
        // Example ECG data (replace with actual data)
        double[] ecgData = signal.Select(x => (double)x).ToArray();

        // Debug.WriteLine($"{ecgData.Max()},{ecgData.Min()}");

        // Sampling frequency and total samples
        // int samplingFrequency = 500; // 500 Hz

        // Lightly filter the data (only high-pass to remove baseline wander)
        double[] hightPass = HighPass(ecgData);
        double[] lowPass = LowPass(ecgData);
        double[] bandPass = BandPass(ecgData);
        double[] narrowPass = NarrowBandPass(ecgData);

        // 3. 检测QRS复合波（R峰）
        List<int> rPeaks = FindRPeaks(hightPass, _fs);

        // 4. 检测P波并标记起止位置
        List<(int Start, int End, int Peak)> pWaveRanges = new List<(int, int, int)>();
        foreach (int rPeak in rPeaks)
        {
            int pWaveStart = rPeak - (int)(0.2 * _fs); // P波开始位置（200毫秒前）
            if (pWaveStart < 0) continue;   // QRS 波太靠前
            int pWaveEnd = rPeak - (int)(0.08 * _fs);  // P波结束位置（120毫秒前）

            // 确保起止位置在数组范围内
            pWaveStart = Math.Max(pWaveStart, 0);
            pWaveEnd = Math.Min(pWaveEnd, hightPass.Length - 1);

            // 在P波段内寻找峰值
            double[] pWaveSegment = hightPass.Skip(pWaveStart).Take(pWaveEnd - pWaveStart).ToArray();
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
                        peak = (ecgData[pWaveStart + pPeaks[0]] > ecgData[pWaveStart + pPeaks[1]]) ? (pWaveStart + pPeaks[0]) : (pWaveStart + pPeaks[1]);
                        break;
                    default:
                        peak = GetPWavePeakIndex(ecgData, pWaveStart, pPeaks.ToArray());
                        break;
                }

                Debug.WriteLine($"{pPeaks.Count}");
                // 记录P波的起止位置和峰值位置
                Debug.WriteLine($"({pWaveStart}, {pWaveEnd}, {peak})");
                pWaveRanges.Add((pWaveStart, pWaveEnd, peak));
            }
        }

        // Plot the ECG data and highlight P-waves
        double[] t = Generate.LinearRange(0.0F, 1.0F / _fs, 10.0F); // 时间轴 (10秒)

        PlotECG(t, ecgData, hightPass, lowPass, bandPass, narrowPass, rPeaks, pWaveRanges, leadName);
    }

    private static void PlotECG(double[] t, double[] ecgSignal,
        double[] highPass, double[] lowPass, double[] bandPass, double[] narrowPass,
        List<int> rPeaks, List<(int Start, int End, int Peak)> pWaveRanges, string leadName)
    {
        var plotModel = new PlotModel { Title = $"{leadName} ECG Signal with R Peaks and P Waves (fs = 500 Hz)" };
        var ecgSeries = new LineSeries { Title = "Original", Color = OxyColors.Red };
        var ecgHigh = new LineSeries { Title = "Highpass", Color = OxyColors.Green };
        var ecgLow = new LineSeries { Title = "Lowpass", Color = OxyColors.Blue };
        var ecgBand = new LineSeries { Title = "Bandpass", Color = OxyColors.DarkGray };
        var ecgNarrow = new LineSeries { Title = "Narrow Band", Color = OxyColors.Red };
        var rPeakSeries = new ScatterSeries { Title = "R Peaks", MarkerType = MarkerType.Circle, MarkerSize = 5, MarkerFill = OxyColors.Red };
        var pPeakSeries = new ScatterSeries { Title = "P Peaks", MarkerType = MarkerType.Circle, MarkerSize = 3, MarkerFill = OxyColors.Blue };

        // 添加ECG信号
        for (int i = 0; i < ecgSignal.Length; i++)
        {
            ecgSeries.Points.Add(new DataPoint(t[i], ecgSignal[i]));
        }

        for (int i = 0; i < ecgSignal.Length; i++)
        {
            ecgHigh.Points.Add(new DataPoint(t[i], highPass[i]));
        }

        for (int i = 0; i < ecgSignal.Length; i++)
        {
            ecgLow.Points.Add(new DataPoint(t[i], lowPass[i]));
        }

        for (int i = 0; i < ecgSignal.Length; i++)
        {
            ecgBand.Points.Add(new DataPoint(t[i], bandPass[i]));
        }

        for (int i = 0; i < ecgSignal.Length; i++)
        {
            ecgNarrow.Points.Add(new DataPoint(t[i], narrowPass[i]));
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
        form.Size = new Size(1200, 800);
        form.Show();
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

    // 使用模拟数据
    // var t = Enumerable.Range(1, size).Select(p => p * 1 / fs).ToArray();
    // var y = t.Select(p => (A * Math.Sin(2 * pi * fw * p)) + (N * Math.Sin(2 * pi * fn * p))).ToArray(); //Original

    private static double[] NarrowBandPass(double[] y, double low_cutoff = 0.5, double high_cutoff = 40)
    {
        //narrow bandpass filter
        //double fc1 = 3; //low cutoff frequency
        //double fc2 = 7; //high cutoff frequency
        var bandpassnarrow = OnlineFirFilter.CreateBandpass(ImpulseResponse.Finite, _fs, low_cutoff, high_cutoff);

        return bandpassnarrow.ProcessSamples(y); //Bandpass Narrow
    }

    private static double[] LowPass(double[] y, double cutoff_freq = 40)
    {
        //lowpass filter
        // double fc = 10; //cutoff frequency
        var lowpass = OnlineFirFilter.CreateLowpass(ImpulseResponse.Finite, _fs, cutoff_freq);
       
        return lowpass.ProcessSamples(y); //Lowpass
    }

    private static double[] HighPass(double[] y, double cutoff_freq = 0.5)
    {
        //highpass filter
        // double fc = 10; //cutoff frequency
        var highpass = OnlineFirFilter.CreateHighpass(ImpulseResponse.Finite, _fs, cutoff_freq);

        return highpass.ProcessSamples(y); //Highpass
    }

    private static double[] BandPass(double[] y, double low_cutoff = 0.5, double high_cutoff= 40)
    {
        //bandpass filter
        //double fc1 = 0; //low cutoff frequency
        //double fc2 = 10; //high cutoff frequency
        var bandpass = OnlineFirFilter.CreateBandpass(ImpulseResponse.Finite, _fs, low_cutoff, high_cutoff);

        return bandpass.ProcessSamples(y); //Bandpass
    }

}
