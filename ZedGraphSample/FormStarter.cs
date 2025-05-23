using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZedGraphSample
{
    public partial class FormStarter : Form
    {
        public FormStarter()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            _ = frm.ShowDialog();
            frm.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormRH850 frm = new FormRH850();
            _ = frm.ShowDialog();
            frm.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormPointing frm = new FormPointing();
            _ = frm.ShowDialog();
            frm.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormCurve frm = new FormCurve();
            _ = frm.ShowDialog();
            frm.Close();
        }
    }
}
