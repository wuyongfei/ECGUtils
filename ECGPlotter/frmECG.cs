using System.ComponentModel;
using ECGPlotter;
using ECGXmlReader;
using GraphLib;
using Microsoft.Extensions.Configuration;

namespace GraficDisplay;

public partial class frmECG : Form
{
    public ECGMapping ECG { get; set; }
    public string[] SelectedLeads { get; set; }

    private int NumGraphs = 12;
    private String CurExample = "STACKED";      // "TILED_VERTICAL_AUTO";
    private String CurColorSchema = "GRAY";
    private PrecisionTimer.Timer mTimer = null;
    private DateTime lastTimerTick = DateTime.Now;

    private ECGSettings mySettings;

    public frmECG()
    {
        InitializeComponent();

        display.Smoothing = System.Drawing.Drawing2D.SmoothingMode.None;
        display.SetLabelPlay("播放");
        display.SetLabelStop("停止");
        display.SetLabelPrint("打印");
        display.SetLabelPosition("位置");
        display.SetLabelPlayback("播放速度");

        //CalcDataGraphs();

        //display.Refresh();

        //UpdateGraphCountMenu();

        //UpdateColorSchemaMenu();

        //mTimer = new PrecisionTimer.Timer();
        //mTimer.Period = 40;                         // 20 fps
        //mTimer.Tick += new EventHandler(OnTimerTick);
        //lastTimerTick = DateTime.Now;
        //mTimer.Start();
    }

    protected override void OnClosed(EventArgs e)
    {
        mTimer.Stop();
        mTimer.Dispose();
        base.OnClosed(e);
    }

    private void OnTimerTick(object sender, EventArgs e)
    {
        if (CurExample == "ANIMATED_AUTO")
        {
            try
            {
                TimeSpan dt = DateTime.Now - lastTimerTick;

                for (int j = 0; j < NumGraphs; j++)
                {

                    // CalcSinusFunction_3(display.DataSources[j], j, (float)dt.TotalMilliseconds);

                }

                this.Invoke(new MethodInvoker(RefreshGraph));
            }
            catch (ObjectDisposedException ex)
            {
                // we get this on closing of form
            }
            catch (Exception ex)
            {
                Console.Write("exception invoking refreshgraph(): " + ex.Message);
            }


        }
    }

    private void RefreshGraph()
    {
        display.Refresh();
    }

    //protected void CalcSinusFunction_0(DataSource src, int idx)
    //{
    //    for (int i = 0; i < src.Length; i++)
    //    {
    //        src.Samples[i].x = i;
    //        src.Samples[i].y = (float)(((float)200 * Math.Sin((idx + 1) * (i + 1.0) * 48 / src.Length)));
    //    }
    //}

    //protected void CalcSinusFunction_1(DataSource src, int idx)
    //{
    //    for (int i = 0; i < src.Length; i++)
    //    {
    //        src.Samples[i].x = i;

    //        src.Samples[i].y = (float)(((float)20 *
    //                                    Math.Sin(20 * (idx + 1) * (i + 1) * Math.PI / src.Length)) *
    //                                    Math.Sin(40 * (idx + 1) * (i + 1) * Math.PI / src.Length)) +
    //                                    (float)(((float)200 *
    //                                    Math.Sin(200 * (idx + 1) * (i + 1) * Math.PI / src.Length)));
    //    }
    //    src.OnRenderYAxisLabel = RenderYLabel;
    //}

    protected void StackedDataSource(DataSource src, ECGDataItem di)
    {
        for (int i = 0; i < di.digits.Length; i++)
        {
            src.Samples[i].x = i+1;

            src.Samples[i].y = (float)di.digits[i];
        }
        src.OnRenderYAxisLabel = RenderYLabel;
    }

    //protected void CalcSinusFunction_2(DataSource src, int idx)
    //{
    //    for (int i = 0; i < src.Length; i++)
    //    {
    //        src.Samples[i].x = i;

    //        src.Samples[i].y = (float)(((float)20 *
    //                                    Math.Sin(40 * (idx + 1) * (i + 1) * Math.PI / src.Length)) *
    //                                    Math.Sin(160 * (idx + 1) * (i + 1) * Math.PI / src.Length)) +
    //                                    (float)(((float)200 *
    //                                    Math.Sin(4 * (idx + 1) * (i + 1) * Math.PI / src.Length)));
    //    }
    //    src.OnRenderYAxisLabel = RenderYLabel;
    //}

    //protected void CalcSinusFunction_3(DataSource ds, int idx, float time)
    //{
    //    cPoint[] src = ds.Samples;
    //    for (int i = 0; i < src.Length; i++)
    //    {
    //        src[i].x = i;
    //        src[i].y = 200 + (float)((200 * Math.Sin((idx + 1) * (time + i * 100) / 8000.0))) +
    //                        +(float)((40 * Math.Sin((idx + 1) * (time + i * 200) / 2000.0)));
    //        /**
    //                    (float)( 4* Math.Sin( ((time + (i+8) * 100) / 900.0)))+
    //                    (float)(28 * Math.Sin(((time + (i + 8) * 100) / 290.0))); */
    //    }

    //}

    protected void StackedDataSource(DataSource ds, ECGDataItem di, int offset)
    {
        cPoint[] src = ds.Samples;

        for (int i = 0; i < src.Length; i++)
        {
            src[i].x = i + 1;

            src[i].y = (float)di.digits[i];
        }
        //src.OnRenderYAxisLabel = RenderYLabel;
    }

    private void ApplyColorSchema()
    {
        switch (CurColorSchema)
        {
            case "DARK_GREEN":
                {
                    Color[] cols = { Color.FromArgb(0,255,0),
                                     Color.FromArgb(0,255,0),
                                     Color.FromArgb(0,255,0),
                                     Color.FromArgb(0,255,0),
                                     Color.FromArgb(0,255,0) ,
                                     Color.FromArgb(0,255,0),
                                     Color.FromArgb(0,255,0) };

                    for (int j = 0; j < NumGraphs; j++)
                    {
                        display.DataSources[j].GraphColor = cols[j % 7];
                    }

                    display.BackgroundColorTop = Color.FromArgb(0, 64, 0);
                    display.BackgroundColorBot = Color.FromArgb(0, 64, 0);
                    display.SolidGridColor = Color.FromArgb(0, 128, 0);
                    display.DashedGridColor = Color.FromArgb(0, 128, 0);
                }
                break;
            case "WHITE":
                {
                    Color[] cols = { Color.DarkRed,
                                     Color.DarkSlateGray,
                                     Color.DarkCyan,
                                     Color.DarkGreen,
                                     Color.DarkBlue ,
                                     Color.DarkMagenta,
                                     Color.DeepPink };

                    for (int j = 0; j < NumGraphs; j++)
                    {
                        display.DataSources[j].GraphColor = cols[j % 7];
                    }

                    display.BackgroundColorTop = Color.White;
                    display.BackgroundColorBot = Color.White;
                    display.SolidGridColor = Color.LightGray;
                    display.DashedGridColor = Color.LightGray;
                }
                break;

            case "BLUE":
                {
                    Color[] cols = { Color.Red,
                                     Color.Orange,
                                     Color.Yellow,
                                     Color.LightGreen,
                                     Color.Blue ,
                                     Color.DarkSalmon,
                                     Color.LightPink };

                    for (int j = 0; j < NumGraphs; j++)
                    {
                        display.DataSources[j].GraphColor = cols[j % 7];
                    }

                    display.BackgroundColorTop = Color.Navy;
                    display.BackgroundColorBot = Color.FromArgb(0, 0, 64);
                    display.SolidGridColor = Color.Blue;
                    display.DashedGridColor = Color.Blue;
                }
                break;

            case "GRAY":
                {
                    Color[] cols = { Color.DarkRed,
                                     Color.DarkSlateGray,
                                     Color.DarkCyan,
                                     Color.DarkGreen,
                                     Color.DarkBlue ,
                                     Color.DarkMagenta,
                                     Color.DeepPink };

                    for (int j = 0; j < NumGraphs; j++)
                    {
                        display.DataSources[j].GraphColor = cols[j % 7];
                    }

                    display.BackgroundColorTop = Color.White;
                    display.BackgroundColorBot = Color.LightGray;
                    display.SolidGridColor = Color.LightGray;
                    display.DashedGridColor = Color.LightGray;
                }
                break;

            case "RED":
                {
                    Color[] cols = { Color.DarkCyan,
                                     Color.Yellow,
                                     Color.DarkCyan,
                                     Color.DarkGreen,
                                     Color.DarkBlue ,
                                     Color.DarkMagenta,
                                     Color.DeepPink };

                    for (int j = 0; j < NumGraphs; j++)
                    {
                        display.DataSources[j].GraphColor = cols[j % 7];
                    }

                    display.BackgroundColorTop = Color.DarkRed;
                    display.BackgroundColorBot = Color.Black;
                    display.SolidGridColor = Color.Red;
                    display.DashedGridColor = Color.Red;
                }
                break;

            case "LIGHT_BLUE":
                {
                    Color[] cols = { Color.DarkRed,
                                     Color.DarkSlateGray,
                                     Color.DarkCyan,
                                     Color.DarkGreen,
                                     Color.DarkBlue ,
                                     Color.DarkMagenta,
                                     Color.DeepPink };

                    for (int j = 0; j < NumGraphs; j++)
                    {
                        display.DataSources[j].GraphColor = cols[j % 7];
                    }

                    display.BackgroundColorTop = Color.White;
                    display.BackgroundColorBot = Color.FromArgb(183, 183, 255);
                    display.SolidGridColor = Color.Blue;
                    display.DashedGridColor = Color.Blue;
                }
                break;

            case "BLACK":
                {
                    Color[] cols = { Color.FromArgb(255,0,0),
                                     Color.FromArgb(0,255,0),
                                     Color.FromArgb(255,255,0),
                                     Color.FromArgb(64,64,255),
                                     Color.FromArgb(0,255,255) ,
                                     Color.FromArgb(255,0,255),
                                     Color.FromArgb(255,128,0) };

                    for (int j = 0; j < NumGraphs; j++)
                    {
                        display.DataSources[j].GraphColor = cols[j % 7];
                    }

                    display.BackgroundColorTop = Color.Black;
                    display.BackgroundColorBot = Color.Black;
                    display.SolidGridColor = Color.DarkGray;
                    display.DashedGridColor = Color.DarkGray;
                }
                break;
        }

    }

    protected void CalcDataGraphs()
    {

        this.SuspendLayout();

        display.DataSources.Clear();
        display.SetDisplayRangeX(0, mySettings.DisplayRangeX);      // 400

        int distance = mySettings.Distance;
        display.SetGridDistanceX(mySettings.GridDistance);

        int offset = 50;

        for (int j = 0; j < NumGraphs; j++)
        {
            display.DataSources.Add(new DataSource());
            display.DataSources[j].Name = SelectedLeads[j];     // "Graph " + (j + 1);
            display.DataSources[j].OnRenderXAxisLabel += RenderXLabel;

            string leadType = $"MDC_ECG_LEAD_{SelectedLeads[j].Trim()}";
            ECGDataItem di = ECG.GetItem(leadType);

            int y_min = (int)di.digits.Min();
            int y_max = (int)di.digits.Max();
            int length = di.digits.Length;

            switch (CurExample)
            {
                case "NORMAL":
                    this.Text = "Normal Graph";
                    display.DataSources[j].Length = length;       // 5800;
                    display.PanelLayout = PlotterGraphPaneEx.LayoutMode.NORMAL;
                    display.DataSources[j].AutoScaleY = false;
                    display.DataSources[j].SetDisplayRangeY(y_min, y_max);
                    display.DataSources[j].SetGridDistanceY(distance);
                    display.DataSources[j].OnRenderYAxisLabel = RenderYLabel;
                    //CalcSinusFunction_0(display.DataSources[j], j);
                    StackedDataSource(display.DataSources[j], di);
                    break;

                case "NORMAL_AUTO":
                    this.Text = "Normal Graph Autoscaled";
                    display.DataSources[j].Length = length;       // 5800;
                    display.PanelLayout = PlotterGraphPaneEx.LayoutMode.NORMAL;
                    display.DataSources[j].AutoScaleY = true;
                    display.DataSources[j].SetDisplayRangeY(y_min, y_max);
                    display.DataSources[j].SetGridDistanceY(distance);
                    display.DataSources[j].OnRenderYAxisLabel = RenderYLabel;
                    //CalcSinusFunction_0(display.DataSources[j], j);
                    StackedDataSource(display.DataSources[j], di);
                    break;

                case "STACKED":
                    this.Text = "Stacked Graph";
                    display.PanelLayout = PlotterGraphPaneEx.LayoutMode.STACKED;
                    display.DataSources[j].Length = length;       // 5800;
                    display.DataSources[j].AutoScaleY = false;
                    display.DataSources[j].SetDisplayRangeY(y_min, y_max);
                    display.DataSources[j].SetGridDistanceY(distance);
                    // CalcSinusFunction_1(display.DataSources[j], j);
                    StackedDataSource(display.DataSources[j], di);
                    break;

                case "VERTICAL_ALIGNED":
                    this.Text = "Vertical aligned Graph";
                    display.PanelLayout = PlotterGraphPaneEx.LayoutMode.VERTICAL_ARRANGED;
                    display.DataSources[j].Length = length;       // 5800;
                    display.DataSources[j].AutoScaleY = false;
                    display.DataSources[j].SetDisplayRangeY(y_min, y_max);
                    display.DataSources[j].SetGridDistanceY(distance);
                    //CalcSinusFunction_2(display.DataSources[j], j);
                    StackedDataSource(display.DataSources[j], di);
                    break;

                case "VERTICAL_ALIGNED_AUTO":
                    this.Text = "Vertical aligned Graph autoscaled";
                    display.PanelLayout = PlotterGraphPaneEx.LayoutMode.VERTICAL_ARRANGED;
                    display.DataSources[j].Length = length;       // 5800;
                    display.DataSources[j].AutoScaleY = true;
                    display.DataSources[j].SetDisplayRangeY(y_min, y_max);
                    display.DataSources[j].SetGridDistanceY(distance);
                    StackedDataSource(display.DataSources[j], di);
                    break;

                case "TILED_VERTICAL":
                    this.Text = "Tiled Graphs (vertical prefered)";
                    display.PanelLayout = PlotterGraphPaneEx.LayoutMode.TILES_VER;
                    display.DataSources[j].Length = length;       // 5800;
                    display.DataSources[j].AutoScaleY = false;
                    display.DataSources[j].SetDisplayRangeY(y_min, y_max);
                    display.DataSources[j].SetGridDistanceY(distance);
                    StackedDataSource(display.DataSources[j], di);
                    break;

                case "TILED_VERTICAL_AUTO":
                    this.Text = "Tiled Graphs (vertical prefered) autoscaled";
                    display.PanelLayout = PlotterGraphPaneEx.LayoutMode.TILES_VER;
                    display.DataSources[j].Length = length;       // 5800;
                    display.DataSources[j].AutoScaleY = true;
                    display.DataSources[j].SetDisplayRangeY(y_min, y_max);
                    display.DataSources[j].SetGridDistanceY(distance);
                    StackedDataSource(display.DataSources[j], di);
                    break;

                case "TILED_HORIZONTAL":
                    this.Text = "Tiled Graphs (horizontal prefered)";
                    display.PanelLayout = PlotterGraphPaneEx.LayoutMode.TILES_HOR;
                    display.DataSources[j].Length = length;       // 5800;
                    display.DataSources[j].AutoScaleY = false;
                    display.DataSources[j].SetDisplayRangeY(y_min, y_max);
                    display.DataSources[j].SetGridDistanceY(distance);
                    StackedDataSource(display.DataSources[j], di);
                    break;

                case "TILED_HORIZONTAL_AUTO":
                    this.Text = "Tiled Graphs (horizontal prefered) autoscaled";
                    display.PanelLayout = PlotterGraphPaneEx.LayoutMode.TILES_HOR;
                    display.DataSources[j].Length = length;       // 5800;
                    display.DataSources[j].AutoScaleY = true;
                    display.DataSources[j].SetDisplayRangeY(y_min, y_max);
                    display.DataSources[j].SetGridDistanceY(distance);
                    StackedDataSource(display.DataSources[j], di);
                    break;

                case "ANIMATED_AUTO":

                    this.Text = "Animated graphs fixed x range";
                    display.PanelLayout = PlotterGraphPaneEx.LayoutMode.TILES_HOR;
                    display.DataSources[j].Length = (int)(length / 5);     // (int)(length / 2);
                    display.DataSources[j].AutoScaleY = false;
                    display.DataSources[j].AutoScaleX = true;
                    display.DataSources[j].SetDisplayRangeY(y_min, y_max);
                    display.DataSources[j].SetGridDistanceY(distance);
                    display.DataSources[j].XAutoScaleOffset = offset;
                    //    CalcSinusFunction_3(display.DataSources[j], j, 0);
                    StackedDataSource(display.DataSources[j], di, offset);
                    display.DataSources[j].OnRenderYAxisLabel = RenderYLabel;
                    break;
            }
        }

        ApplyColorSchema();

        this.ResumeLayout();
        display.Refresh();

    }

    private String RenderXLabel(DataSource s, int idx)
    {
        if (s.AutoScaleX)
        {
            //if (idx % 2 == 0)
            {
                int Value = (int)(s.Samples[idx].x);
                return "" + Value;
            }
            return "";
        }
        else
        {
            int Value = (int)(s.Samples[idx].x / 200);
            String Label = "" + Value + "\"";
            return Label;
        }
    }

    private String RenderYLabel(DataSource s, float value)
    {
        return String.Format("{0:0.0}", value);
    }

    protected override void OnClosing(CancelEventArgs e)
    {
        display.Dispose();

        base.OnClosing(e);
    }

    private void stackedToolStripMenuItem_Click(object sender, EventArgs e)
    {
        display.PanelLayout = PlotterGraphPaneEx.LayoutMode.NORMAL;
    }

    private void verticalALignedToolStripMenuItem_Click(object sender, EventArgs e)
    {
        display.PanelLayout = PlotterGraphPaneEx.LayoutMode.VERTICAL_ARRANGED;
    }

    private void tiledVerticallyToolStripMenuItem_Click(object sender, EventArgs e)
    {
        display.PanelLayout = PlotterGraphPaneEx.LayoutMode.TILES_VER;
    }

    private void tiledHorizontalyToolStripMenuItem_Click(object sender, EventArgs e)
    {
        display.PanelLayout = PlotterGraphPaneEx.LayoutMode.TILES_HOR;
    }

    private void noneToolStripMenuItem_Click(object sender, EventArgs e)
    {
        display.Smoothing = System.Drawing.Drawing2D.SmoothingMode.None;
    }

    private void antiAliasedToolStripMenuItem_Click(object sender, EventArgs e)
    {
        display.Smoothing = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
    }

    private void highSpeedToolStripMenuItem_Click(object sender, EventArgs e)
    {
        display.Smoothing = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
    }

    private void highQualityToolStripMenuItem_Click(object sender, EventArgs e)
    {
        display.Smoothing = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
    }

    private void normalToolStripMenuItem_Click(object sender, EventArgs e)
    {
        CurExample = "NORMAL";
        CalcDataGraphs();
    }

    private void normalAutoscaledToolStripMenuItem_Click(object sender, EventArgs e)
    {
        CurExample = "NORMAL_AUTO";
        CalcDataGraphs();
    }

    private void stackedToolStripMenuItem_Click_1(object sender, EventArgs e)
    {
        CurExample = "STACKED";
        CalcDataGraphs();
    }

    private void verticallyAlignedToolStripMenuItem_Click(object sender, EventArgs e)
    {
        CurExample = "VERTICAL_ALIGNED";
        CalcDataGraphs();
    }
    private void verticallyAlignedAutoscaledToolStripMenuItem_Click(object sender, EventArgs e)
    {
        CurExample = "VERTICAL_ALIGNED_AUTO";
        CalcDataGraphs();
    }

    private void tiledVerticalToolStripMenuItem_Click(object sender, EventArgs e)
    {
        CurExample = "TILED_VERTICAL";
        CalcDataGraphs();
    }
    private void tiledVerticalAutoscaledToolStripMenuItem_Click(object sender, EventArgs e)
    {
        CurExample = "TILED_VERTICAL_AUTO";
        CalcDataGraphs();
    }

    private void tiledHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
    {
        CurExample = "TILED_HORIZONTAL";
        CalcDataGraphs();
    }

    private void tiledHorizontalAutoscaledToolStripMenuItem_Click(object sender, EventArgs e)
    {
        CurExample = "TILED_HORIZONTAL_AUTO";
        CalcDataGraphs();
    }

    private void animatedGraphDemoToolStripMenuItem_Click(object sender, EventArgs e)
    {
        CurExample = "ANIMATED_AUTO";
        CalcDataGraphs();
    }


    private void blueToolStripMenuItem_Click(object sender, EventArgs e)
    {
        CurColorSchema = "BLUE";
        CalcDataGraphs();
        UpdateColorSchemaMenu();
    }

    private void whiteToolStripMenuItem_Click(object sender, EventArgs e)
    {
        CurColorSchema = "WHITE";
        CalcDataGraphs();
        UpdateColorSchemaMenu();
    }

    private void grayToolStripMenuItem_Click(object sender, EventArgs e)
    {
        CurColorSchema = "GRAY";
        CalcDataGraphs();
        UpdateColorSchemaMenu();
    }

    private void lightBlueToolStripMenuItem_Click(object sender, EventArgs e)
    {
        CurColorSchema = "LIGHT_BLUE";
        CalcDataGraphs();
        UpdateColorSchemaMenu();

    }

    private void blackToolStripMenuItem_Click(object sender, EventArgs e)
    {
        CurColorSchema = "BLACK";
        CalcDataGraphs();
        UpdateColorSchemaMenu();
    }

    private void redToolStripMenuItem_Click(object sender, EventArgs e)
    {
        CurColorSchema = "RED";
        CalcDataGraphs();
        UpdateColorSchemaMenu();
    }

    private void greenToolStripMenuItem_Click(object sender, EventArgs e)
    {
        CurColorSchema = "DARK_GREEN";
        CalcDataGraphs();
        UpdateColorSchemaMenu();

    }

    private void UpdateColorSchemaMenu()
    {
        blueToolStripMenuItem.Checked = false;
        whiteToolStripMenuItem.Checked = false;
        grayToolStripMenuItem.Checked = false;
        lightBlueToolStripMenuItem.Checked = false;
        blackToolStripMenuItem.Checked = false;
        redToolStripMenuItem.Checked = false;

        if (CurColorSchema == "WHITE") whiteToolStripMenuItem.Checked = true;
        if (CurColorSchema == "BLUE") blueToolStripMenuItem.Checked = true;
        if (CurColorSchema == "GRAY") grayToolStripMenuItem.Checked = true;
        if (CurColorSchema == "LIGHT_BLUE") lightBlueToolStripMenuItem.Checked = true;
        if (CurColorSchema == "BLACK") blackToolStripMenuItem.Checked = true;
        if (CurColorSchema == "RED") redToolStripMenuItem.Checked = true;
        if (CurColorSchema == "DARK_GREEN") greenToolStripMenuItem.Checked = true;
    }

    private void UpdateGraphCountMenu()
    {
        toolStripMenuItem2.Checked = false;
        toolStripMenuItem3.Checked = false;
        toolStripMenuItem4.Checked = false;
        toolStripMenuItem5.Checked = false;
        toolStripMenuItem6.Checked = false;
        toolStripMenuItem7.Checked = false;

        switch (NumGraphs)
        {
            case 1: toolStripMenuItem2.Checked = true; break;
            case 2: toolStripMenuItem3.Checked = true; break;
            case 3: toolStripMenuItem4.Checked = true; break;
            case 4: toolStripMenuItem5.Checked = true; break;
            case 5: toolStripMenuItem6.Checked = true; break;
            case 6: toolStripMenuItem7.Checked = true; break;

        }
    }
    private void toolStripMenuItem2_Click(object sender, EventArgs e)
    {
        NumGraphs = 1;
        CalcDataGraphs();
        UpdateGraphCountMenu();
    }

    private void toolStripMenuItem3_Click(object sender, EventArgs e)
    {
        NumGraphs = 2;
        CalcDataGraphs();
        UpdateGraphCountMenu();
    }

    private void toolStripMenuItem4_Click(object sender, EventArgs e)
    {
        NumGraphs = 3;
        CalcDataGraphs();
        UpdateGraphCountMenu();
    }

    private void toolStripMenuItem5_Click(object sender, EventArgs e)
    {
        NumGraphs = 4;
        CalcDataGraphs();
        UpdateGraphCountMenu();
    }

    private void toolStripMenuItem6_Click(object sender, EventArgs e)
    {
        NumGraphs = 5;
        CalcDataGraphs();
        UpdateGraphCountMenu();
    }

    private void toolStripMenuItem7_Click(object sender, EventArgs e)
    {
        NumGraphs = 6;
        CalcDataGraphs();
        UpdateGraphCountMenu();
    }

    private void startToolStripMenuItem_Click(object sender, EventArgs e)
    {

    }

    private void stopToolStripMenuItem_Click(object sender, EventArgs e)
    {

    }

    private void printToolStripMenuItem_Click(object sender, EventArgs e)
    {

    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void frmECG_Load(object sender, EventArgs e)
    {
        mySettings = Program.Configuration.GetSection("ECGSettings").Get<ECGSettings>();
        // check settings
        //Dictionary<string, string> di = mySettings.LabelTypes();
        //Debug.WriteLine(di.ContainsKey("P0"));

        NumGraphs = SelectedLeads.Length;
        CurExample = mySettings.CurExample;
        CurColorSchema = mySettings.CurColorSchema;

        CalcDataGraphs();

        display.Refresh();

        UpdateGraphCountMenu();

        UpdateColorSchemaMenu();

        mTimer = new PrecisionTimer.Timer();
        mTimer.Period = 40;                         // 20 fps
        mTimer.Tick += new EventHandler(OnTimerTick);
        lastTimerTick = DateTime.Now;
        mTimer.Start();
    }
}