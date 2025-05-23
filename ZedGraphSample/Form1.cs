using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

namespace ZedGraphSample
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load( object sender, EventArgs e )
		{
			CreateGraph( zg1 );
			SetSize();
		}

		private void CreateGraph( ZedGraphControl zgc )
		{
			GraphPane myPane = zgc.GraphPane;

			// Set the titles and axis labels
			myPane.Title.Text = "My Test Graph";
			myPane.XAxis.Title.Text = "X Value";
			myPane.YAxis.Title.Text = "My Y Axis";

			// Make up some data points from the Sine function
			PointPairList list = new PointPairList();
			for ( double x = 0; x < 36; x++ )
			{
				double y = Math.Sin( x * Math.PI / 15.0 );

				list.Add( x, y );
			}

			// Generate a blue curve with circle symbols, and "My Curve 2" in the legend
			LineItem myCurve = myPane.AddCurve( "My Curve", list, Color.Blue,
									SymbolType.Circle );
			// Fill the area under the curve with a white-red gradient at 45 degrees
			myCurve.Line.Fill = new Fill( Color.White, Color.Red, 45F );
			// Make the symbols opaque by filling them with white
			myCurve.Symbol.Fill = new Fill( Color.White );

			// Fill the axis background with a color gradient
			myPane.Chart.Fill = new Fill( Color.White, Color.LightGoldenrodYellow, 45F );

			// Fill the pane background with a color gradient
			myPane.Fill = new Fill( Color.White, Color.FromArgb( 220, 220, 255 ), 45F );

			// Calculate the Axis Scale Ranges
			zgc.AxisChange();
		}

		private void Form1_Resize( object sender, EventArgs e )
		{
			SetSize();
		}

		private void SetSize()
		{
			zg1.Location = new Point( 10, 10 );
			// Leave a small margin around the outside of the control
			zg1.Size = new Size( this.ClientRectangle.Width - 20, this.ClientRectangle.Height - 20 );
		}
	}
}