namespace GraphLib
{
    partial class PlotterDisplayEx
    {
       
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;



        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlotterDisplayEx));
            imgList1 = new System.Windows.Forms.ImageList(components);
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            panel1 = new System.Windows.Forms.Panel();
            cmdPrint = new System.Windows.Forms.Button();
            cmdStop = new System.Windows.Forms.Button();
            cmdPlay = new System.Windows.Forms.Button();
            lb_Position = new System.Windows.Forms.Label();
            lb_playback = new System.Windows.Forms.Label();
            hScrollBar1 = new System.Windows.Forms.HScrollBar();
            hScrollBar2 = new System.Windows.Forms.HScrollBar();
            gPane = new PlotterGraphPaneEx();
            contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
            selectGraphsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panel1.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // imgList1
            // 
            imgList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            imgList1.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("imgList1.ImageStream");
            imgList1.TransparentColor = System.Drawing.Color.Transparent;
            imgList1.Images.SetKeyName(0, "media-playback-start.png");
            imgList1.Images.SetKeyName(1, "media-playback-stop.png");
            imgList1.Images.SetKeyName(2, "media-playback-pause.png");
            imgList1.Images.SetKeyName(3, "printer.png");
            // 
            // splitContainer1
            // 
            splitContainer1.BackColor = System.Drawing.SystemColors.Control;
            splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            splitContainer1.IsSplitterFixed = true;
            splitContainer1.Location = new System.Drawing.Point(0, 0);
            splitContainer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            splitContainer1.Panel1.Controls.Add(panel1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = System.Drawing.Color.Transparent;
            splitContainer1.Panel2.Controls.Add(gPane);
            splitContainer1.Size = new System.Drawing.Size(698, 391);
            splitContainer1.SplitterDistance = 39;
            splitContainer1.SplitterWidth = 5;
            splitContainer1.TabIndex = 2;
            splitContainer1.TabStop = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(cmdPrint);
            panel1.Controls.Add(cmdStop);
            panel1.Controls.Add(cmdPlay);
            panel1.Controls.Add(lb_Position);
            panel1.Controls.Add(lb_playback);
            panel1.Controls.Add(hScrollBar1);
            panel1.Controls.Add(hScrollBar2);
            panel1.Location = new System.Drawing.Point(4, 4);
            panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(691, 32);
            panel1.TabIndex = 7;
            // 
            // cmdPrint
            // 
            cmdPrint.Location = new System.Drawing.Point(594, 6);
            cmdPrint.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            cmdPrint.Name = "cmdPrint";
            cmdPrint.Size = new System.Drawing.Size(78, 22);
            cmdPrint.TabIndex = 9;
            cmdPrint.Text = "Print";
            cmdPrint.UseVisualStyleBackColor = true;
            cmdPrint.Click += cmdPrint_Click;
            // 
            // cmdStop
            // 
            cmdStop.Location = new System.Drawing.Point(510, 6);
            cmdStop.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            cmdStop.Name = "cmdStop";
            cmdStop.Size = new System.Drawing.Size(44, 22);
            cmdStop.TabIndex = 8;
            cmdStop.Text = "Stop";
            cmdStop.UseVisualStyleBackColor = true;
            cmdStop.Click += cmdStop_Click;
            // 
            // cmdPlay
            // 
            cmdPlay.Location = new System.Drawing.Point(456, 6);
            cmdPlay.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            cmdPlay.Name = "cmdPlay";
            cmdPlay.Size = new System.Drawing.Size(50, 22);
            cmdPlay.TabIndex = 7;
            cmdPlay.Text = "Play";
            cmdPlay.UseVisualStyleBackColor = true;
            cmdPlay.Click += cmdPlay_Click;
            // 
            // lb_Position
            // 
            lb_Position.AutoSize = true;
            lb_Position.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            lb_Position.Location = new System.Drawing.Point(7, 9);
            lb_Position.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lb_Position.Name = "lb_Position";
            lb_Position.Size = new System.Drawing.Size(50, 15);
            lb_Position.TabIndex = 3;
            lb_Position.Text = "Position";
            // 
            // lb_playback
            // 
            lb_playback.AutoSize = true;
            lb_playback.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            lb_playback.Location = new System.Drawing.Point(210, 9);
            lb_playback.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lb_playback.Name = "lb_playback";
            lb_playback.Size = new System.Drawing.Size(89, 15);
            lb_playback.TabIndex = 2;
            lb_playback.Text = "Playback Speed";
            // 
            // hScrollBar1
            // 
            hScrollBar1.Location = new System.Drawing.Point(66, 11);
            hScrollBar1.Maximum = 10000;
            hScrollBar1.Name = "hScrollBar1";
            hScrollBar1.Size = new System.Drawing.Size(138, 10);
            hScrollBar1.TabIndex = 4;
            hScrollBar1.Scroll += OnScrollbarScroll;
            // 
            // hScrollBar2
            // 
            hScrollBar2.Location = new System.Drawing.Point(313, 11);
            hScrollBar2.Maximum = 10000;
            hScrollBar2.Name = "hScrollBar2";
            hScrollBar2.Size = new System.Drawing.Size(130, 10);
            hScrollBar2.TabIndex = 6;
            hScrollBar2.Value = 1;
            hScrollBar2.Scroll += OnScrollBarSpeedScroll;
            // 
            // gPane
            // 
            gPane.Dock = System.Windows.Forms.DockStyle.Fill;
            gPane.Location = new System.Drawing.Point(0, 0);
            gPane.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            gPane.Name = "gPane";
            gPane.Size = new System.Drawing.Size(698, 347);
            gPane.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { selectGraphsToolStripMenuItem, toolStripSeparator1 });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new System.Drawing.Size(117, 32);
            // 
            // selectGraphsToolStripMenuItem
            // 
            selectGraphsToolStripMenuItem.Name = "selectGraphsToolStripMenuItem";
            selectGraphsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            selectGraphsToolStripMenuItem.Text = "Options";
            selectGraphsToolStripMenuItem.Click += selectGraphsToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(113, 6);
            // 
            // PlotterDisplayEx
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.Transparent;
            ContextMenuStrip = contextMenuStrip1;
            Controls.Add(splitContainer1);
            Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            Name = "PlotterDisplayEx";
            Size = new System.Drawing.Size(698, 391);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        //// TODO ToolBar is no longer supported. Use ToolStrip instead. For more details see https://docs.microsoft.com/en-us/dotnet/core/compatibility/winforms#removed-controls
        //        private System.Windows.Forms.ToolBar tb1;
        //// TODO ToolBarButton is no longer supported. Use ToolStripButton instead. For more details see https://docs.microsoft.com/en-us/dotnet/core/compatibility/winforms#removed-controls
        //private System.Windows.Forms.ToolBarButton tbbSeparator3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        //// TODO ToolBarButton is no longer supported. Use ToolStripButton instead. For more details see https://docs.microsoft.com/en-us/dotnet/core/compatibility/winforms#removed-controls
        //private System.Windows.Forms.ToolBarButton tbbSave;
        //// TODO ToolBarButton is no longer supported. Use ToolStripButton instead. For more details see https://docs.microsoft.com/en-us/dotnet/core/compatibility/winforms#removed-controls
        //private System.Windows.Forms.ToolBarButton tbbOpen;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private PlotterGraphPaneEx gPane;
        private System.Windows.Forms.HScrollBar hScrollBar2;
        private System.Windows.Forms.Label lb_Position;
        private System.Windows.Forms.Label lb_playback;
        public System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem selectGraphsToolStripMenuItem;
        private System.Windows.Forms.ImageList imgList1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        // TODO ToolBarButton is no longer supported. Use ToolStripButton instead. For more details see https://docs.microsoft.com/en-us/dotnet/core/compatibility/winforms#removed-controls
        //private System.Windows.Forms.ToolBarButton tbbPrint;
        // TODO ToolBarButton is no longer supported. Use ToolStripButton instead. For more details see https://docs.microsoft.com/en-us/dotnet/core/compatibility/winforms#removed-controls
        //private System.Windows.Forms.ToolBarButton toolBarButton2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cmdPrint;
        private System.Windows.Forms.Button cmdStop;
        private System.Windows.Forms.Button cmdPlay;
    }
}
