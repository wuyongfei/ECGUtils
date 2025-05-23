using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace ZedGraphSample
{
    public partial class FormRH850 : Form
    {
        private GraphPane _outputPane;

        public FormRH850()
        {
            InitializeComponent();
        }

        PointPairList list = new PointPairList();

        private void InitializeGraphs()
        {
            _outputPane = zedGraphControl1.GraphPane;
            _outputPane.Title.Text = " ";
            _outputPane.Legend.IsVisible = false;
            _outputPane.YAxis.Title.Text = "Value";
            _outputPane.XAxis.Title.Text = "PWM Cycle";

            _outputPane.YAxis.Scale.Min = 0;
            _outputPane.YAxis.Scale.MajorStep = 10;
            _outputPane.YAxis.Scale.MinorStep = 5;

            _outputPane.XAxis.Scale.Format = "#";
            _outputPane.XAxis.Scale.Mag = 0;
            _outputPane.XAxis.Scale.Min = 0;
            _outputPane.XAxis.Scale.Max = 100;

            Random random = new Random();



            for (int i = 0; i < 500; i++)
            {
                list.Add(i, random.NextDouble() * 100);

            }

            _outputPane.AddCurve("Frequencies", list, Color.Blue, SymbolType.None);
            zedGraphControl1.AxisChange();
            //zedGraphControl1.Invalidate();
        }

        private void FormRH850_Load(object sender, EventArgs e)
        {
            InitializeGraphs();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random random = new Random();

            list.Clear();

            for (int i = 0; i < 100; i++)
            {
                list.Add(i, random.NextDouble() * 100);

            }

            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
        }
    }
}
