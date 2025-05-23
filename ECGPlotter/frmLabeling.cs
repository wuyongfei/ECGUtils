using ECGXmlReader;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using ZedGraph;

namespace ECGPlotter;

public partial class frmLabeling : Form
{
    public ECGDataItem DataItem { get; set; }
    public LabelHandler Handler { get; set; }

    private LabelInfo newLabel;
    public LabelInfo NewLabel { get { return newLabel; } }

    public int OriginalStartX { get; set; }

    private bool isCancelled = false;
    public bool IsCancelled { get { return isCancelled; } }

    private int startValue = 0;
    public int StartValue
    {
        get { return startValue; }
        set { startValue = value; }
    }

    private int endValue = 0;
    public int EndValue
    {
        get { return endValue; }
        set { endValue = value; }
    }

    private string labelType = "P0";
    public string LabelType { get { return labelType; } }

    private Color selectedColor = Color.Red;

    private ECGSettings mySettings;
    private Dictionary<string, Color> LabelColors;
    public frmLabeling()
    {
        InitializeComponent();

        //zedGraph.MouseMove += ZedGraph_MouseMove;
        //zedGraph.MouseLeave += ZedGraph_MouseLeave;

        mySettings = Program.Configuration.GetSection("ECGSettings").Get<ECGSettings>();
        LabelColors = mySettings.LabelColors();

        // Set custom combobox styles
        cbLabelTypes.DropDownStyle = ComboBoxStyle.DropDown;
        cbLabelTypes.FlatStyle = FlatStyle.System;

        // Attach relevant event handler methods
        cbLabelTypes.DropDown += new EventHandler(cbLabelTypes_DropDown);
        cbLabelTypes.DropDownClosed += new EventHandler(cbLabelTypes_DropDownClosed);

    }

    void cbLabelTypes_DropDown(object sender, EventArgs e)
    {
        // Optionally, revert the color back to the default
        // when the combobox is dropped-down
        //
        // (Note that we're using the ACTUAL default color here,
        //  rather than hard-coding black)
        cbLabelTypes.ForeColor = SystemColors.WindowText;
    }

    void cbLabelTypes_DropDownClosed(object sender, EventArgs e)
    {
        // Change the color of the selected text in the combobox
        // to your custom color
        string key = $"P{cbLabelTypes.SelectedIndex}";
        if (LabelColors.ContainsKey(key))
        {
            cbLabelTypes.ForeColor = LabelColors[key];
        }
    }

    private void ZedGraph_MouseLeave(object sender, EventArgs e)
    {
        using (Graphics graphics = zedGraph.CreateGraphics())
        {//在zedGraph上创建画布
            zedGraph.Refresh();

            using (Pen pen = new Pen(Color.Red, 2))
            {//创建画笔并设置样式
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                //画竖直线
                graphics.DrawLine(pen, 0, 0, 0, 0);

            }
        }
    }

    //鼠标移动
    private void ZedGraph_MouseMove(object sender, MouseEventArgs e)
    {

        // ShowPonitByDraw(e);
    }


    private void cbLabelTypes_DrawItem(object sender, DrawItemEventArgs e)
    {
        e.DrawBackground();

        // Color color;

        //Text of your ComboBox element
        string text = ((System.Windows.Forms.ComboBox)sender).Items[e.Index].ToString();

        Brush brush;

        string key = $"P{e.Index}";
        if (LabelColors.ContainsKey(key))
        {
            Color color = LabelColors[key];
            brush = new SolidBrush(color);   // Brushes.Green;
        }
        else
        {
            // color = Color.Red;
            brush = Brushes.Red;
        }

        //e.Graphics.FillRectangle(new SolidBrush(color), e.Bounds);
        //e.Graphics.DrawString(text, e.Font, new SolidBrush(((ComboBox)sender).ForeColor), new Point(e.Bounds.X, e.Bounds.Y));
        //e.DrawFocusRectangle();
        e.Graphics.DrawString(text, ((Control)sender).Font, brush, e.Bounds.X, e.Bounds.Y);
    }

    private void frmLabeling_Load(object sender, EventArgs e)
    {
        isCancelled = true;

        var mySettings = Program.Configuration.GetSection("ECGSettings").Get<ECGSettings>();
        Dictionary<string, string> di = mySettings.LabelTypes();
        Debug.WriteLine(di.ContainsKey("P0"));

        foreach (KeyValuePair<string, string> kv in di)
        {
            cbLabelTypes.Items.Add(kv.Key + kv.Value);
        }

        cbLabelTypes.SelectedIndex = 0;

        txtStart.Text = startValue.ToString();
        txtEnd.Text = endValue.ToString();

        InitPlot();

        AddGraph();

    }

    private void txtStart_KeyPress(object sender, KeyPressEventArgs e)
    {
        e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
    }

    private void txtStart_TextChanged(object sender, EventArgs e)
    {
        if (IsNumericAndGreaterThan(txtStart.Text, 0))
        {
            // Change background color or provide feedback if needed
            txtStart.BackColor = System.Drawing.Color.LightGreen;
            startValue = int.Parse(txtStart.Text);
        }
        else
        {
            txtStart.BackColor = System.Drawing.Color.LightSalmon;
            txtStart.Focus();
        }
    }

    private void txtEnd_TextChanged(object sender, EventArgs e)
    {
        if (IsNumericAndLessThan(txtEnd.Text, 5000))
        {
            // Change background color or provide feedback if needed
            txtEnd.BackColor = System.Drawing.Color.LightGreen;
            endValue = int.Parse(txtEnd.Text);
        }
        else
        {
            txtEnd.BackColor = System.Drawing.Color.LightSalmon;
            txtEnd.Focus();
        }
    }

    private bool IsNumericAndLessThan(string input, int threshold)
    {
        // Try parsing the input as a double
        if (int.TryParse(input, out int number))
        {
            // Check if the number is less than the threshold
            return ((number < threshold) && (number > startValue + 10));
        }
        return false;
    }

    private bool IsNumericAndGreaterThan(string input, int threshold)
    {
        // Try parsing the input as a double
        if (int.TryParse(input, out int number))
        {
            // Check if the number is less than the threshold
            return ((number > threshold) && (number < endValue - 10));
        }
        return false;
    }

    private void txtEnd_KeyPress(object sender, KeyPressEventArgs e)
    {
        e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
    }

    private void btnStart_Click(object sender, EventArgs e)
    {
        if (startValue + 10 > endValue) return;
        startValue += 1;
        txtStart.Text = startValue.ToString();
    }

    private void btnEnd_Click(object sender, EventArgs e)
    {
        if (endValue - 10 < startValue) return;
        endValue -= 1;
        txtEnd.Text = endValue.ToString();
    }

    private void frmLabeling_FormClosing(object sender, FormClosingEventArgs e)
    {
        startValue = int.Parse(txtStart.Text);
        endValue = int.Parse(txtEnd.Text);
        labelType = $"P{cbLabelTypes.SelectedIndex}";

        //if (e.CloseReason == CloseReason.UserClosing)
        //{
        //    DialogResult result = MessageBox.Show("Do you really want to exit?", "Dialog Title", MessageBoxButtons.YesNo);
        //    if (result == DialogResult.Yes)
        //    {
        //        //Environment.Exit(0);
        //        e.Cancel = false;
        //    }
        //    else
        //    {
        //        e.Cancel = true;
        //    }
        //}
        //else
        //{
        //    e.Cancel = true;
        //}

    }

    private void btnClose_Click(object sender, EventArgs e)
    {
        isCancelled = false;

        try
        {
            labelType = $"P{cbLabelTypes.SelectedIndex}";

            if (OriginalStartX != 0)
            {
                Handler.Remove(OriginalStartX);
            }

            newLabel = Handler.Add(labelType, startValue, DataItem.digits[startValue], 
                endValue, DataItem.digits[endValue]);

            this.Close();
        }
        catch(Exception ex)
        {
            MessageBox.Show(ex.Message, this.Text);
        }
        
    }

    #region Methods
    private void InitPlot()
    {
        // return;

        //去掉外边框
        this.zedGraph.GraphPane.Border.IsVisible = false;

        // Scroll bars
        // this.zedGraph.IsShowHScrollBar = true;
        //this.zedGraph.IsShowVScrollBar = true;
        //this.zedGraph.IsShowCursorValues = true;
        this.zedGraph.IsShowPointValues = true;
        //this.zedGraph.IsZoomOnMouseCenter = false;

        // disable zooming
        this.zedGraph.IsEnableZoom = false;
        this.zedGraph.IsEnableWheelZoom = false;

        // Or try this
        //this.zedGraph.ZoomButtons = MouseButtons.None;
        //this.zedGraph.ZoomButtons2 = MouseButtons.None;
        //this.zedGraph.ZoomStepFraction = 0;

        //设置黑色
        //this.zedGraph.GraphPane.Fill = new ZedGraph.Fill(Color.Black);

        //设置曲线区域的矩形框的颜色  
        //this.zedGraph.GraphPane.Chart.Fill = new ZedGraph.Fill(Color.Black);

        //设置绘制曲线区域的矩形框的边框颜色 
        this.zedGraph.GraphPane.Chart.Border.Color = Color.FromArgb(150, 150, 150);

        //设置图例
        //this.zedGraph.GraphPane.Legend.Fill = new Fill(Color.Black);
        //this.zedGraph.GraphPane.Legend.FontSpec.FontColor = Color.White;

        // hide titles and legends
        this.zedGraph.GraphPane.Title.IsVisible = false;
        this.zedGraph.GraphPane.Legend.IsVisible = false;


        //灰色
        Color axisColor = Color.FromArgb(150, 150, 150);
        float dashLength = 0.1f;

        #region X轴
        //设置网格线 主网格线
        this.zedGraph.GraphPane.XAxis.MajorGrid.IsVisible = true;
        this.zedGraph.GraphPane.XAxis.MajorGrid.Color = axisColor;
        this.zedGraph.GraphPane.XAxis.MajorGrid.DashOn = dashLength;
        this.zedGraph.GraphPane.XAxis.MajorGrid.DashOff = dashLength;
        this.zedGraph.GraphPane.XAxis.MajorGrid.PenWidth = 0.1f;
        //子网格线 不可见
        this.zedGraph.GraphPane.XAxis.MinorGrid.IsVisible = false;

        //刻度
        //设置主刻度的长度
        // this.zedGraph.GraphPane.XAxis.MajorTic.Size = 10f;
        //主刻度颜色 
        this.zedGraph.GraphPane.XAxis.MajorTic.Color = axisColor;

        //隐藏X轴正上方的刻度
        this.zedGraph.GraphPane.XAxis.MajorTic.IsOpposite = false;
        this.zedGraph.GraphPane.XAxis.MinorTic.IsOpposite = false;

        //朝外
        this.zedGraph.GraphPane.XAxis.MajorTic.IsInside = false;
        this.zedGraph.GraphPane.XAxis.MinorTic.IsInside = false;


        //设置X轴刻度文本颜色
        this.zedGraph.GraphPane.XAxis.Scale.FontSpec.FontColor = axisColor;
        //设置X轴颜色
        this.zedGraph.GraphPane.XAxis.Color = axisColor;
        //设置X轴标题颜色
        this.zedGraph.GraphPane.XAxis.Title.IsVisible = false;
        //this.zedGraph.GraphPane.XAxis.Title.FontSpec.FontColor = axisColor;
        // this.zedGraph.GraphPane.XAxis.Title.Text = "时间(ms)";

        #endregion

        #region Y轴
        //设置网格线 主网格线
        this.zedGraph.GraphPane.YAxis.MajorGrid.IsVisible = true;
        this.zedGraph.GraphPane.YAxis.MajorGrid.Color = axisColor;
        //this.zedGraph.GraphPane.YAxis.MajorGrid.DashOn = dashLength;
        //this.zedGraph.GraphPane.YAxis.MajorGrid.DashOff = dashLength;
        //this.zedGraph.GraphPane.YAxis.MajorGrid.PenWidth = 0.1f;
        //设置子网格线不可见
        this.zedGraph.GraphPane.YAxis.MinorGrid.IsVisible = false;


        Color ycolor = Color.Green;     //.Yellow;

        //刻度
        //设置主刻度的长度
        // this.zedGraph.GraphPane.YAxis.MajorTic.Size = 10f;
        //主刻度颜色 
        this.zedGraph.GraphPane.YAxis.MajorTic.Color = ycolor;
        //设置对面的Y轴刻度不可见
        this.zedGraph.GraphPane.YAxis.MajorTic.IsOpposite = false;

        //朝内
        this.zedGraph.GraphPane.YAxis.MajorTic.IsOutside = false;
        this.zedGraph.GraphPane.YAxis.MinorTic.IsOutside = false;


        //设置Y轴颜色
        this.zedGraph.GraphPane.YAxis.Color = ycolor;
        //设置刻度文本颜色
        this.zedGraph.GraphPane.YAxis.Scale.FontSpec.FontColor = ycolor;

        //设置Y轴标题颜色
        this.zedGraph.GraphPane.YAxis.Title.IsVisible = false;
        // this.zedGraph.GraphPane.YAxis.Title.FontSpec.FontColor = ycolor;
        // this.zedGraph.GraphPane.YAxis.Title.Text = "速度";
        // this.zedGraph.GraphPane.YAxis.Title.Gap = 0.05f;
        this.zedGraph.GraphPane.YAxis.Title.FontSpec.StringAlignment = StringAlignment.Near;
        this.zedGraph.GraphPane.YAxis.Title.FontSpec.Angle = 90;


        #endregion

        #region Y2Axis轴 - 没有Y2
        ////显示Y2Axis
        //zedGraph.GraphPane.Y2Axis.IsVisible = true;

        ////设置主刻度
        //// zedGraph.GraphPane.Y2Axis.MajorTic.Size = 10f;
        //zedGraph.GraphPane.Y2Axis.MajorTic.IsOutside = false;
        //zedGraph.GraphPane.Y2Axis.MajorTic.Color = Color.Blue;

        ////设置颜色 蓝色
        ////zedGraph.GraphPane.Y2Axis.Scale.FontSpec.FontColor = Color.Blue;
        ////zedGraph.GraphPane.Y2Axis.Title.FontSpec.FontColor = Color.Blue;

        ////设置对面的刻度不可见
        //zedGraph.GraphPane.Y2Axis.MajorTic.IsOpposite = false;
        //zedGraph.GraphPane.Y2Axis.MinorTic.IsOpposite = false;


        ////隐藏网格线
        //zedGraph.GraphPane.Y2Axis.MajorGrid.IsVisible = false;

        //zedGraph.GraphPane.Y2Axis.Scale.Align = AlignP.Inside;   //align the Y2 axis labels so they are flush to the axis
        ////zedGraph.GraphPane.Y2Axis.Scale.Min = 1.5;
        ////zedGraph.GraphPane.Y2Axis.Scale.Max = 3;
        //zedGraph.GraphPane.Y2Axis.Scale.MaxAuto = true;
        #endregion
    }


    /// <summary>
    /// 添加曲线
    /// </summary>
    private void AddGraph()
    {
        PointPairList vlist = new PointPairList();
        // PointPairList dlist = new PointPairList();

        for (int i = startValue; i <= endValue; i++)
        {
            double time = (double)i;        // di.digits[i];
            // double acceleration = 2.0;
            double velocity = (double)DataItem.digits[i];     // acceleration * time;
            // double distance = 10F;               //acceleration * time * time / 2.0;
            // double energy = 10.0 * velocity * velocity / 2.0;

            vlist.Add(time, velocity);
            // dlist.Add(time, distance);
        }

        //添加速度曲线
        LineItem myCurve = zedGraph.GraphPane.AddCurve(null, vlist, selectedColor, SymbolType.Default);
        myCurve.Symbol.Fill = new Fill(Color.White);   // fill the symbols with white

        ////添加加速度曲线
        //myCurve = zedGraph.GraphPane.AddCurve(null, dlist, Color.Blue, SymbolType.None); // Circle
        //myCurve.Symbol.Fill = new Fill(Color.White);   //fill the symbols with white
        //myCurve.IsY2Axis = true;

        zedGraph.AxisChange();
    }

    private void ClearGraph()
    {
        zedGraph.GraphPane.CurveList.Clear();
        zedGraph.GraphPane.GraphObjList.Clear();
        //zedGraph.GraphPane.Title.Text = "";
        //zedGraph.GraphPane.XAxis.Title = "";
        //zedGraph.GraphPane.YAxis.Title = "";
        //zedGraph.GraphPane.Y2Axis.Title = "";
        //zedGraph.GraphPane.XAxis.Type = AxisType.Linear;
        zedGraph.GraphPane.XAxis.Scale.TextLabels = null;
        zedGraph.RestoreScale(zedGraph.GraphPane);
        zedGraph.AxisChange();
        zedGraph.Invalidate();
    }
    #endregion

    private void btnCancel_Click(object sender, EventArgs e)
    {
        isCancelled = true;
        this.Close();
    }

    private void btnRedraw_Click(object sender, EventArgs e)
    {
        startValue = int.Parse(txtStart.Text);
        endValue = int.Parse(txtEnd.Text);

        ClearGraph();
        AddGraph();
    }

    private void cbLabelTypes_SelectedIndexChanged(object sender, EventArgs e)
    {
        string key = $"P{cbLabelTypes.SelectedIndex}";
        if (LabelColors.ContainsKey(key))
        {
            selectedColor = LabelColors[key];
        }
    }


}
