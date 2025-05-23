using ECGXmlReader;
using OxyPlot.Series;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECGPWaveLabelling;

public static  class BaselineMethod
{
    public static void Show(short[] signal)
    {
        // Example ECG data (replace with actual data)
        double[] ecgData = signal.Select(x => (double)x).ToArray();    
        ecgData = Baseline(ecgData, 500);     

        // Debug.WriteLine($"{ecgData.Max()},{ecgData.Min()}");

        // Sampling frequency and total samples
        int samplingFrequency = 500; // 500 Hz

        // Lightly filter the data (only high-pass to remove baseline wander)
        double[] filteredData = HighPassFilter(ecgData, samplingFrequency, 0.5);

        // Detect P-waves on the lightly filtered data
        List<int> pWaveIndices = DetectPWave(filteredData, samplingFrequency);

        // Plot the ECG data and highlight P-waves
        PlotECGData(ecgData, filteredData, pWaveIndices);
    }

    // zero-phase filter
    private static double[] HighPassFilter(double[] data, double samplingFrequency, double cutoffFrequency)
    {
        double rc = 1.0 / (2 * Math.PI * cutoffFrequency);
        double dt = 1.0 / samplingFrequency;
        double alpha = rc / (rc + dt);

        double[] filteredData = new double[data.Length];
        filteredData[0] = data[0]; // Initialize the first value

        for (int i = 1; i < data.Length; i++)
        {
            filteredData[i] = alpha * (filteredData[i - 1] + data[i] - data[i - 1]);
        }

        return filteredData;
    }

    private static double[] Baseline(double[] rawData, int samplingFrequency)
    {
        //int windowSize = 50; // Adjust this value as needed
        int windowSize = (int)(0.2 * samplingFrequency); // 200 ms window

        double[] baseline = new double[rawData.Length];
        for (int i = windowSize; i < rawData.Length; i++)
        {
            baseline[i] = rawData.Skip(i - windowSize).Take(windowSize).Average();
        }

        return rawData.Zip(baseline, (ecg, baseVal) => ecg - baseVal).ToArray();
    }

    private static List<int> DetectPWave(double[] filteredData, int samplingFrequency)
    {
        List<int> pWaveIndices = [];
        double threshold = 0.2; // Lower threshold for P-wave detection
        int windowSize = (int)(0.2 * samplingFrequency); // 200 ms window

        for (int i = windowSize; i < filteredData.Length - windowSize; i++)
        {
            if (filteredData[i] > threshold)
            {
                // Check if this is the maximum in the window
                bool isMax = true;
                for (int j = i - windowSize; j <= i + windowSize; j++)
                {
                    if (filteredData[j] > filteredData[i])
                    {
                        isMax = false;
                        break;
                    }
                }

                if (isMax)
                {
                    pWaveIndices.Add(i);
                }
            }
        }

        return pWaveIndices;
    }

    static List<int> DetectPWave2(double[] filteredData, int samplingFrequency)
    {
        List<int> pWaveIndices = [];
        double threshold = 0.2; // Threshold for P-wave detection (absolute value)
        int windowSize = (int)(0.2 * samplingFrequency); // 200 ms window

        for (int i = windowSize; i < filteredData.Length - windowSize; i++)
        {
            if (Math.Abs(filteredData[i]) > threshold)
            {
                // Check if this is the maximum or minimum in the window
                bool isPeak = true;
                for (int j = i - windowSize; j <= i + windowSize; j++)
                {
                    if (Math.Abs(filteredData[j]) > Math.Abs(filteredData[i]))
                    {
                        isPeak = false;
                        break;
                    }
                }

                if (isPeak)
                {
                    pWaveIndices.Add(i);
                }
            }
        }

        return pWaveIndices;
    }       

    private static void PlotECGData(double[] rawData, double[] filteredData, List<int> pWaveIndices)
    {
        // Create a new plot model
        var plotModel = new PlotModel { Title = "ECG Data with P-wave Detection" };

        // Create a line series for the raw ECG data
        var rawSeries = new LineSeries
        {
            Title = "Raw ECG",
            Color = OxyColors.Blue
        };
        for (int i = 0; i < rawData.Length; i++)
        {
            rawSeries.Points.Add(new DataPoint(i / 500.0, rawData[i])); // Time in seconds
        }
        plotModel.Series.Add(rawSeries);

        // Create a line series for the filtered ECG data
        var filteredSeries = new LineSeries
        {
            Title = "Filtered ECG",
            Color = OxyColors.Green
        };
        for (int i = 0; i < filteredData.Length; i++)
        {
            filteredSeries.Points.Add(new DataPoint(i / 500.0, filteredData[i])); // Time in seconds
        }
        plotModel.Series.Add(filteredSeries);

        // Add markers for P-waves
        foreach (int index in pWaveIndices)
        {
            var pWaveMarker = new ScatterSeries
            {
                MarkerType = MarkerType.Circle,
                MarkerSize = 5,
                MarkerFill = OxyColors.Red
            };
            pWaveMarker.Points.Add(new ScatterPoint(index / 500.0, filteredData[index]));
            plotModel.Series.Add(pWaveMarker);
        }

        // Create a plot view and display it
        var plotView = new OxyPlot.WindowsForms.PlotView { Model = plotModel };
        var form = new System.Windows.Forms.Form
        {
            Text = "ECG Plot",
            Width = 1200,
            Height = 400
        };
        form.Controls.Add(plotView);
        plotView.Dock = System.Windows.Forms.DockStyle.Fill;
        System.Windows.Forms.Application.Run(form);
    }
}
