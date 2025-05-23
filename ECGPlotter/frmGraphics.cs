using ECGXmlReader;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.AxHost;

namespace ECGPlotter;

public partial class frmGraphics : Form
{
    //private FastBitmap _fastBitmap;
    //private int _offset = 0;
    private int selectedStartX = 0;
    private int selectedStartY = 0;
    private int selectedEndX = 0;
    private int selectedEndY = 0;

    private Dictionary<string, Color> LabelColors;

    //private uint _renderTimeInMilliseconds;
    public ECGMapping ECG { get; set; }
    public string SelectedLead { get; set; }
    public LabelHandler Handler { get; set; }
    public frmGraphics()
    {
        InitializeComponent();

        ECGSettings mySettings = Program.Configuration.GetSection("ECGSettings").Get<ECGSettings>();
        LabelColors = mySettings.LabelColors();

        //  zedGraph.PointValueEvent += ZedGraph_PointValueEvent;
        zedGraph.MouseMove += ZedGraph_MouseMove;
        zedGraph.MouseLeave += ZedGraph_MouseLeave;
        zedGraph.MouseDownEvent += ZedGraph_MouseDownEvent;
        zedGraph.ZoomEvent += ZedGraph_ZoomEvent;
    }

    double last_x_max, last_x_min, last_y_max, last_y_min;

    private bool ZedGraph_MouseDownEvent(ZedGraphControl sender, MouseEventArgs e)
    {
        // Save the zoom values
        last_x_max = sender.GraphPane.XAxis.Scale.Max;
        last_x_min = sender.GraphPane.XAxis.Scale.Min;
        last_y_max = sender.GraphPane.YAxis.Scale.Max;
        last_y_min = sender.GraphPane.YAxis.Scale.Min;
        return false;
    }

    private void ZedGraph_ZoomEvent(ZedGraphControl sender, ZoomState oldState, ZoomState newState)
    {
        if (newState.Type == ZoomState.StateType.Zoom)
        {
            double new_x_max = sender.GraphPane.XAxis.Scale.Max;
            double new_x_min = sender.GraphPane.XAxis.Scale.Min;
            double new_y_max = sender.GraphPane.YAxis.Scale.Max;
            double new_y_min = sender.GraphPane.YAxis.Scale.Min;

            SelectPointsInArea(new_x_max, new_x_min, new_y_max, new_y_min);

            sender.GraphPane.XAxis.Scale.Max = last_x_max;
            sender.GraphPane.XAxis.Scale.Min = last_x_min;
            sender.GraphPane.YAxis.Scale.Max = last_y_max;
            sender.GraphPane.YAxis.Scale.Min = last_y_min;
        }
    }

    private void SelectPointsInArea(double x_max, double x_min, double y_max, double y_min)
    {
        int startValue = (int)x_min;
        int endvalue = (int)x_max;
        Debug.WriteLine($"X=[{startValue}:{endvalue}], Y=[{y_min}:{y_max}]");

        if (Handler.IsOverlapping(startValue, endvalue))
        {
            DialogResult dr = MessageBox.Show($"选定的范围[{startValue}:{endvalue}]将出现交叉。继续标注吗？",
                this.Text, MessageBoxButtons.YesNo);
            if (dr == DialogResult.No) return;
        }

        frmLabeling frm = new frmLabeling();
        frm.StartValue = startValue;
        frm.EndValue = endvalue;
        frm.OriginalStartX = 0;
        frm.Handler = Handler;

        frm.Text = $"导联 {SelectedLead}：[{startValue}, {(int)y_min}] : [{endvalue}, {(int)y_max}]";
        frm.DataItem = ECG.GetItem($"MDC_ECG_LEAD_{SelectedLead}");

        frm.ShowDialog();

        if (!frm.IsCancelled)
        {
            int newstartValue = frm.NewLabel.StartX;
            int newendValue = frm.NewLabel.EndX;
            string labelType = frm.NewLabel.LabelType;

            // save label
            Handler.Save();

            DrawLabels(newstartValue);

            LoadLabels(newstartValue);
        }

        frm = null;

    }

    //鼠标离开时，将游标隐藏
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

    private void frmGraphics_Paint(object sender, PaintEventArgs e)
    {
        //Pen drawingPen = new Pen(Color.Red, 15);
        //e.Graphics.DrawArc(drawingPen, 50, 20, 100, 200, 40, 210);
        //drawingPen.Dispose();
    }

    private void frmGraphics_Load(object sender, EventArgs e)
    {
        this.Text = $"导联 {SelectedLead} - {ECG.Header.Log()}";

        bool b = LoadLabels(0);
        if (b)
        {
            InitPlot();

            AddGraph();

            DrawLabels();
        }
    }


    #region Methods
    //自定义绘制游标
    private void ShowPonitByDraw(MouseEventArgs e)
    {
        if (zedGraph.GraphPane.Chart.Rect.Contains(e.Location) == false)
        {
            return;
        }

        using (Graphics graphics = zedGraph.CreateGraphics())
        {
            //在zedGraph上创建画布
            zedGraph.Refresh();

            using (Pen pen = new Pen(Color.Red, 2))
            {
                //创建画笔并设置样式
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;

                //画竖直线
                graphics.DrawLine(pen, e.X, zedGraph.GraphPane.Chart.Rect.Top, e.X, zedGraph.GraphPane.Chart.Rect.Bottom);

                if (zedGraph.GraphPane.CurveList.Count <= 0)
                {

                    return;
                }

                //找最近的一个点
                zedGraph.GraphPane.FindNearestPoint(e.Location, out CurveItem nearCurve, out int nearIndex);

                if (nearCurve == null || nearIndex < 0)
                {
                    return;
                }

                string tempMax = "";
                List<string> infoList = new List<string>();

                foreach (CurveItem curve in zedGraph.GraphPane.CurveList)
                {
                    //曲线名称 + 坐标点
                    string tmp = curve.Points[nearIndex].Y.ToString();
                    //填充到8个长度
                    tmp = tmp.PadLeft(8);
                    tmp = tmp.Insert(0, curve.Label.Text + ": ");

                    infoList.Add(tmp);
                    if (tmp.Length > tempMax.Length)
                    {//记录最大的长度字符串
                        tempMax = tmp;
                    }
                }


                //文本绘制的一些字体和画刷配置
                System.Drawing.Font font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Regular, GraphicsUnit.World);

                //得到一个字体绘制的大小
                SizeF tempSizeF = graphics.MeasureString(tempMax, font, (int)font.Size);

                //根据字符长度计算矩形的宽度 10是颜色矩形框的宽度
                float rectWidth = tempSizeF.Width * tempMax.Length;
                //高度
                float rectHeight = (infoList.Count + 1) * 18 + 5;
                //背景颜色框的左上角点的坐标，偏移2个像素
                Point point = new Point(e.X + 2, e.Y + 2);

                #region 计算左上角坐标 让背景矩形框在曲线的矩形框范围之内
                if (point.X + rectWidth > zedGraph.GraphPane.Chart.Rect.Right)
                {
                    point.X = (int)(point.X - rectWidth - 2);
                }

                if (point.Y + rectHeight > zedGraph.GraphPane.Chart.Rect.Bottom)
                {
                    point.Y = (int)(point.Y - rectHeight - 2);
                }
                #endregion

                pen.Color = Color.White;

                //绘制背景矩形框
                Rectangle rectBg = new Rectangle(point, new Size((int)rectWidth, (int)rectHeight));
                graphics.DrawRectangle(pen, rectBg);
                graphics.FillRectangle(new SolidBrush(Color.FromArgb(70, 70, 70)), rectBg);

                //颜色框的大小
                Size colorSize = new Size(10, 10);

                //绘制文本的颜色
                SolidBrush textBrush = new SolidBrush(Color.Red);

                //绘制文本内容 时间
                int time = 0;
                //"时间(ms):"
                string timeStr = "时间： " + nearCurve[nearIndex].X.ToString();

                graphics.DrawString(timeStr, font, textBrush,
                              new Point(point.X + 20, point.Y + 5 + time * 16));

                for (int m = 0; m < infoList.Count; m++)
                {
                    time++;
                    //绘制每条曲线的颜色小矩形框 
                    Rectangle rect1 = new Rectangle(new Point(point.X + 5, point.Y + 5 + time * 16), colorSize);
                    graphics.DrawRectangle(new Pen(zedGraph.GraphPane.CurveList[m].Color), rect1);
                    graphics.FillRectangle(new SolidBrush(zedGraph.GraphPane.CurveList[m].Color), rect1);

                    //绘制文本内容
                    graphics.DrawString(infoList[m], font, textBrush,
                                  new Point(point.X + 20, point.Y + 5 + time * 16));
                }

            }
        }
    }

    //初始化图表样式
    private void InitPlot()
    {
        // return;

        //去掉外边框
        this.zedGraph.GraphPane.Border.IsVisible = false;

        // Scroll bars
        this.zedGraph.IsShowHScrollBar = true;
        this.zedGraph.IsShowVScrollBar = true;
        //this.zedGraph.IsShowCursorValues = true;
        this.zedGraph.IsShowPointValues = true;
        this.zedGraph.IsZoomOnMouseCenter = true;

        //禁止纵向ZOOM
        this.zedGraph.IsEnableVZoom = false;
        this.zedGraph.IsEnableVPan = false;
        //设置黑色
        //this.zedGraph.GraphPane.Fill = new ZedGraph.Fill(Color.Black);

        //设置曲线区域的矩形框的颜色  
        //this.zedGraph.GraphPane.Chart.Fill = new ZedGraph.Fill(Color.Black);

        //设置绘制曲线区域的矩形框的边框颜色 
        //this.zedGraph.GraphPane.Chart.Border.Color = Color.FromArgb(150, 150, 150);


        //设置缩放和显示点
        //zedGraph.IsEnableZoom = false;
        //zedGraph.IsShowPointValues = false;

        //设置图例
        //this.zedGraph.GraphPane.Legend.Fill = new Fill(Color.Black);
        //this.zedGraph.GraphPane.Legend.FontSpec.FontColor = Color.White;

        // hide titles and legends
        this.zedGraph.GraphPane.Title.IsVisible = false;
        this.zedGraph.GraphPane.Legend.IsVisible = false;


        //灰色
        Color axisColor = Color.Red;        // Color.FromArgb(150, 150, 150);
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

        #region Y2Axis轴
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

        ECGDataItem di = ECG.GetItem($"MDC_ECG_LEAD_{SelectedLead}");
        if (di == null)
        {
            MessageBox.Show($"没有找到导联【MDC_ECG_LEAD_{SelectedLead}】数据");
            return;
        }

        for (int i = 0; i < di.digits.Length; i++)
        {
            double time = (double)i;        // di.digits[i];
            // double acceleration = 2.0;
            double velocity = (double)di.digits[i];     // acceleration * time;
            // double distance = 10F;               //acceleration * time * time / 2.0;
            // double energy = 10.0 * velocity * velocity / 2.0;


            vlist.Add(time, velocity);
            // dlist.Add(time, distance);
        }

        //添加速度曲线
        LineItem myCurve = zedGraph.GraphPane.AddCurve(null, vlist, Color.Red, SymbolType.Default);
        myCurve.Symbol.Fill = new Fill(Color.White);   // fill the symbols with white

        ////添加加速度曲线
        //myCurve = zedGraph.GraphPane.AddCurve(null, dlist, Color.Blue, SymbolType.None); // Circle
        //myCurve.Symbol.Fill = new Fill(Color.White);   //fill the symbols with white
        //myCurve.IsY2Axis = true;

        zedGraph.AxisChange();
    }

    /// <summary>
    /// if parameter is 0, draw all labels. otherwise draw only one
    /// </summary>
    /// <param name="start_px"></param>
    private void DrawLabels(int start_px = 0)
    {
        if (!Handler.IsLoaded) return;

        ECGDataItem di = ECG.GetItem($"MDC_ECG_LEAD_{SelectedLead}");

        GraphPane pane = zedGraph.GraphPane;

        foreach (LabelInfo li in Handler.LeadLabels)
        {
            if (start_px == 0)
            {
                LabelBox(pane, li, di);
            }
            else
            {
                if (li.StartX == start_px)
                {
                    LabelBox(pane, li, di);
                }
            }
        }

        zedGraph.Refresh();
    }

    private void LabelBox(GraphPane pane, LabelInfo li, ECGDataItem di)
    {
        short[] digits = di.digits.Skip(li.StartX - 1).Take(li.EndX - li.StartX).ToArray();
        short min = digits.Min();
        short max = digits.Max();

        double height = (double)Math.Abs(max - min);
        double width = (double)(li.EndX - li.StartX);

        int scale_max = (int)pane.YAxis.Scale.Max;
        int scale_min = (int)pane.YAxis.Scale.Min;

        double point_x = (double)li.StartX;

        double point_y = 0;
        if (max <= 0)
        {
            point_y = (double)max;
        }
        else
        {
            point_y = (double)max;      // (double)(scale_max - max); 
        }

        Color boxColor = LabelColors.ContainsKey(li.LabelType) ? LabelColors[li.LabelType] : Color.LightGreen;
        Color txtColor = LabelColors.ContainsKey(li.LabelType) ? LabelColors[li.LabelType] : Color.Blue;

        BoxObj box = new BoxObj(point_x, point_y, width, height, Color.Empty, boxColor);
        box.Tag = $"BOX{li.StartX}";
        box.Location.CoordinateFrame = CoordType.AxisXYScale;
        box.Location.AlignH = AlignH.Left;
        box.Location.AlignV = AlignV.Top;

        // place the box behind the axis items, so the grid is drawn on top of it
        box.ZOrder = ZOrder.E_BehindCurves;
        pane.GraphObjList.Add(box);
        
        // Add Region text inside the box 
        TextObj txt = new TextObj(li.LabelType, point_x, point_y);
        txt.Tag = $"TEXT{li.StartX}";
        txt.Location.CoordinateFrame = CoordType.AxisXYScale;
        txt.Location.AlignH = AlignH.Right;
        txt.Location.AlignV = AlignV.Center;
        txt.FontSpec.IsItalic = true;
        txt.FontSpec.FontColor = txtColor;
        txt.FontSpec.Fill.IsVisible = false;
        txt.FontSpec.Border.IsVisible = false;

        pane.GraphObjList.Add(txt);
    }

    private bool LoadLabels(int startX)
    {
        if (Handler == null)
        {
            MessageBox.Show("出现错误。请重新开始");
            return false;
        }

        if (Handler.IsLoaded)
        {
            lvLabels.Items.Clear();

            int idx = 0;
            int i = 0;
            foreach (LabelInfo li in Handler.LeadLabels)
            {
                ListViewItem lvi = new ListViewItem($"{li.LabelType} - {li.Lead} [{li.StartX}:{li.EndX}]")
                {
                    Tag = $"{li.StartX}"
                };

                lvLabels.Items.Add(lvi);

                if (li.StartX == startX) idx = i;
                i++;
            }

            // select the new one or otherwise the first one
            lvLabels.Items[idx].Selected = true;
        }

        return true;
    }

    private void RemoveObjects(string startx)
    {
        // remove text
        string tag = $"TEXT{startx}";
        int objIndex = zedGraph.GraphPane.GraphObjList.IndexOfTag(tag);
        if (objIndex != -1)
        {
            zedGraph.GraphPane.GraphObjList.RemoveAt(objIndex);
        }

        // remove box
        tag = $"BOX{startx}";
        objIndex = zedGraph.GraphPane.GraphObjList.IndexOfTag(tag);
        if (objIndex != -1)
        {
            zedGraph.GraphPane.GraphObjList.RemoveAt(objIndex);
        }

        zedGraph.Invalidate();
    }

    #endregion

    private void lvLabels_SelectedIndexChanged(object sender, EventArgs e)
    {
        selectedStartX = 0;
        selectedStartY = 0;
        selectedEndX = 0;
        selectedEndY = 0;

        if (lvLabels.SelectedItems.Count == 0) return;

        int startX = int.Parse(lvLabels.SelectedItems[0].Tag.ToString());

        LabelInfo li = Handler.GetLabelInfo(startX);
        if (li == null)
        {
            // Error
        }
        else
        {
            txtAuthor.Text = li.Author;
            txtDateTime.Text = li.CreateDate.ToString();
            txtEnd.Text = li.EndX.ToString();
            txtLabelType.Text = li.LabelType;
            txtLead.Text = li.Lead;
            txtStart.Text = li.StartX.ToString();

            selectedStartX = li.StartX;
            selectedStartY = li.StartY;
            selectedEndX = li.EndX;
            selectedEndY = li.EndY;
        }
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void btnRemoveLabel_Click(object sender, EventArgs e)
    {
        if (txtStart.Text == string.Empty) return;

        //zedGraph.GraphPane.GraphObjList.Clear();

        RemoveObjects(txtStart.Text);

        // remove the slected item from LABELS and reload listview
        Handler.Remove(int.Parse(txtStart.Text));
        Handler.Save();

        LoadLabels(0);

    }


    private void btnEditLabel_Click(object sender, EventArgs e)
    {
        frmLabeling frm = new frmLabeling();

        frm.StartValue = selectedStartX;
        frm.EndValue = selectedEndX;
        frm.OriginalStartX = selectedStartX;
        frm.Handler = Handler;

        frm.Text = $"导联 {SelectedLead}：[{selectedStartX}, {selectedStartY}] : [{selectedEndX}, {selectedEndY}]";
        frm.DataItem = ECG.GetItem($"MDC_ECG_LEAD_{SelectedLead}");

        frm.ShowDialog();

        if (!frm.IsCancelled)
        {
            int newstartValue = frm.NewLabel.StartX;
            int newendValue = frm.NewLabel.EndX;
            string labelType = frm.NewLabel.LabelType;

            // save label
            Handler.Save();

            RemoveObjects(selectedStartX.ToString());
            DrawLabels(newstartValue);

            LoadLabels(newstartValue);
        }

        frm = null;
    }
}
