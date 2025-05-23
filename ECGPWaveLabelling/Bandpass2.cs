using ECGXmlReader;
using OxyPlot.Series;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ECGPWaveLabelling;

public static class Bandpass2
{
    public static void Show(string xmlFile, int leadIndex)
    {
        ECGDataItem di = LoadECG(xmlFile, leadIndex);
        if (di != null)
        {
            di.PreLabelling();
            PlotECG(di);
        }
    }

    private static void PlotECG(ECGDataItem di)
    {
        var plotModel = new PlotModel { Title = "ECG Signal with R Peaks and P Waves (fs = 500 Hz)" };
        var ecgSeries = new LineSeries { Title = "Filtered ECG", Color = OxyColors.Red };
        var rPeakSeries = new ScatterSeries { Title = "R Peaks", MarkerType = MarkerType.Circle, MarkerSize = 5, MarkerFill = OxyColors.Red };
        var pPeakSeries = new ScatterSeries { Title = "R Peaks", MarkerType = MarkerType.Circle, MarkerSize = 3, MarkerFill = OxyColors.Blue };

        double[] ecgSignal = di.digits.Select(x => (double)x).ToArray();

        // 添加ECG信号
        for (int i = 0; i < di.Timeline.Length; i++)
        {
            ecgSeries.Points.Add(new DataPoint(di.Timeline[i], ecgSignal[i]));
        }

        // 添加R峰
        foreach (int rPeak in di.QRSPeaks)
        {
            rPeakSeries.Points.Add(new ScatterPoint(di.Timeline[rPeak], ecgSignal[rPeak]));
        }

        // 添加P波区域
        foreach (var range in di.Waves)
        {
            var pWaveSeries = new LineSeries { Title = "P Wave", Color = OxyColors.Black };
            for (int i = range.Start; i < range.End; i++)
            {
                pWaveSeries.Points.Add(new DataPoint(di.Timeline[i], ecgSignal[i]));
            }
            plotModel.Series.Add(pWaveSeries);
            pPeakSeries.Points.Add(new ScatterPoint(di.Timeline[range.Peak], ecgSignal[range.Peak]));
        }

        plotModel.Series.Add(ecgSeries);
        plotModel.Series.Add(rPeakSeries);
        plotModel.Series.Add(pPeakSeries);

        var plotView = new OxyPlot.WindowsForms.PlotView { Model = plotModel };
        var form = new System.Windows.Forms.Form();
        form.Controls.Add(plotView);
        plotView.Dock = System.Windows.Forms.DockStyle.Fill;
        form.ShowDialog();
    }

    private static ECGDataItem LoadECG(string xmlFile, int leadIndex)
    {
        ECGMapping ecg = XMLParser.ReadXml(xmlFile);

        if (ecg != null)
        {
            if (ecg.Header != null)
            {
                Debug.WriteLine($"{DateTime.Now:HH:ss}     HEADER: {ecg.Header.Log()}");
            }

            ECGDataItem item = ecg.GetItem(ECGDataItem.LeadIndexNames[leadIndex + 1]);

            List<LabelInfo> labels = item.GetLabels();
            foreach (LabelInfo l in labels)
            {
                Debug.WriteLine($"({l.StartX}, {l.EndX})");
            }

            return item;        // item.digits.Select(x => (double)x).ToArray();
        }

        return null;
    }
}
