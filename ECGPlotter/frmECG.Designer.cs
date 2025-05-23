namespace GraficDisplay
{
    using GraphLib;

    partial class frmECG
    {
        PlotterDisplayEx display = null;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            menuStrip1 = new MenuStrip();
            layoutToolStripMenuItem = new ToolStripMenuItem();
            filterToolStripMenuItem = new ToolStripMenuItem();
            noneToolStripMenuItem = new ToolStripMenuItem();
            antiAliasedToolStripMenuItem = new ToolStripMenuItem();
            highQualityToolStripMenuItem = new ToolStripMenuItem();
            highSpeedToolStripMenuItem = new ToolStripMenuItem();
            examplesToolStripMenuItem = new ToolStripMenuItem();
            normalToolStripMenuItem = new ToolStripMenuItem();
            normalAutoscaledToolStripMenuItem = new ToolStripMenuItem();
            stackedToolStripMenuItem = new ToolStripMenuItem();
            verticallyAlignedToolStripMenuItem = new ToolStripMenuItem();
            verticallyAlignedAutoscaledToolStripMenuItem = new ToolStripMenuItem();
            tiledVerticalToolStripMenuItem = new ToolStripMenuItem();
            tiledVerticalAutoscaledToolStripMenuItem = new ToolStripMenuItem();
            tiledHorizontalToolStripMenuItem = new ToolStripMenuItem();
            tiledHorizontalAutoscaledToolStripMenuItem = new ToolStripMenuItem();
            animatedGraphDemoToolStripMenuItem = new ToolStripMenuItem();
            colorSchemesToolStripMenuItem = new ToolStripMenuItem();
            blueToolStripMenuItem = new ToolStripMenuItem();
            whiteToolStripMenuItem = new ToolStripMenuItem();
            grayToolStripMenuItem = new ToolStripMenuItem();
            lightBlueToolStripMenuItem = new ToolStripMenuItem();
            blackToolStripMenuItem = new ToolStripMenuItem();
            redToolStripMenuItem = new ToolStripMenuItem();
            greenToolStripMenuItem = new ToolStripMenuItem();
            numGraphsToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripMenuItem();
            toolStripMenuItem4 = new ToolStripMenuItem();
            toolStripMenuItem5 = new ToolStripMenuItem();
            toolStripMenuItem6 = new ToolStripMenuItem();
            toolStripMenuItem7 = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            exitToolStripMenuItem = new ToolStripMenuItem();
            display = new PlotterDisplayEx();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { layoutToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 2, 0, 2);
            menuStrip1.Size = new Size(723, 24);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // layoutToolStripMenuItem
            // 
            layoutToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { filterToolStripMenuItem, examplesToolStripMenuItem, colorSchemesToolStripMenuItem, numGraphsToolStripMenuItem, toolStripMenuItem1, exitToolStripMenuItem });
            layoutToolStripMenuItem.Name = "layoutToolStripMenuItem";
            layoutToolStripMenuItem.Size = new Size(44, 20);
            layoutToolStripMenuItem.Text = "设置";
            // 
            // filterToolStripMenuItem
            // 
            filterToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { noneToolStripMenuItem, antiAliasedToolStripMenuItem, highQualityToolStripMenuItem, highSpeedToolStripMenuItem });
            filterToolStripMenuItem.Name = "filterToolStripMenuItem";
            filterToolStripMenuItem.Size = new Size(180, 22);
            filterToolStripMenuItem.Text = "过滤器";
            // 
            // noneToolStripMenuItem
            // 
            noneToolStripMenuItem.Name = "noneToolStripMenuItem";
            noneToolStripMenuItem.Size = new Size(141, 22);
            noneToolStripMenuItem.Text = "None";
            noneToolStripMenuItem.Click += noneToolStripMenuItem_Click;
            // 
            // antiAliasedToolStripMenuItem
            // 
            antiAliasedToolStripMenuItem.Name = "antiAliasedToolStripMenuItem";
            antiAliasedToolStripMenuItem.Size = new Size(141, 22);
            antiAliasedToolStripMenuItem.Text = "AntiAliased";
            antiAliasedToolStripMenuItem.Click += antiAliasedToolStripMenuItem_Click;
            // 
            // highQualityToolStripMenuItem
            // 
            highQualityToolStripMenuItem.Name = "highQualityToolStripMenuItem";
            highQualityToolStripMenuItem.Size = new Size(141, 22);
            highQualityToolStripMenuItem.Text = "High Quality";
            highQualityToolStripMenuItem.Click += highQualityToolStripMenuItem_Click;
            // 
            // highSpeedToolStripMenuItem
            // 
            highSpeedToolStripMenuItem.Name = "highSpeedToolStripMenuItem";
            highSpeedToolStripMenuItem.Size = new Size(141, 22);
            highSpeedToolStripMenuItem.Text = "High Speed";
            highSpeedToolStripMenuItem.Click += highSpeedToolStripMenuItem_Click;
            // 
            // examplesToolStripMenuItem
            // 
            examplesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { normalToolStripMenuItem, normalAutoscaledToolStripMenuItem, stackedToolStripMenuItem, verticallyAlignedToolStripMenuItem, verticallyAlignedAutoscaledToolStripMenuItem, tiledVerticalToolStripMenuItem, tiledVerticalAutoscaledToolStripMenuItem, tiledHorizontalToolStripMenuItem, tiledHorizontalAutoscaledToolStripMenuItem, animatedGraphDemoToolStripMenuItem });
            examplesToolStripMenuItem.Name = "examplesToolStripMenuItem";
            examplesToolStripMenuItem.Size = new Size(180, 22);
            examplesToolStripMenuItem.Text = "显示模式";
            // 
            // normalToolStripMenuItem
            // 
            normalToolStripMenuItem.Name = "normalToolStripMenuItem";
            normalToolStripMenuItem.Size = new Size(227, 22);
            normalToolStripMenuItem.Text = "Normal";
            normalToolStripMenuItem.Click += normalToolStripMenuItem_Click;
            // 
            // normalAutoscaledToolStripMenuItem
            // 
            normalAutoscaledToolStripMenuItem.Name = "normalAutoscaledToolStripMenuItem";
            normalAutoscaledToolStripMenuItem.Size = new Size(227, 22);
            normalAutoscaledToolStripMenuItem.Text = "Normal Autoscaled";
            normalAutoscaledToolStripMenuItem.Click += normalAutoscaledToolStripMenuItem_Click;
            // 
            // stackedToolStripMenuItem
            // 
            stackedToolStripMenuItem.Name = "stackedToolStripMenuItem";
            stackedToolStripMenuItem.Size = new Size(227, 22);
            stackedToolStripMenuItem.Text = "Stacked";
            stackedToolStripMenuItem.Click += stackedToolStripMenuItem_Click_1;
            // 
            // verticallyAlignedToolStripMenuItem
            // 
            verticallyAlignedToolStripMenuItem.Name = "verticallyAlignedToolStripMenuItem";
            verticallyAlignedToolStripMenuItem.Size = new Size(227, 22);
            verticallyAlignedToolStripMenuItem.Text = "Vertically Aligned";
            verticallyAlignedToolStripMenuItem.Click += verticallyAlignedToolStripMenuItem_Click;
            // 
            // verticallyAlignedAutoscaledToolStripMenuItem
            // 
            verticallyAlignedAutoscaledToolStripMenuItem.Name = "verticallyAlignedAutoscaledToolStripMenuItem";
            verticallyAlignedAutoscaledToolStripMenuItem.Size = new Size(227, 22);
            verticallyAlignedAutoscaledToolStripMenuItem.Text = "Vertically Aligned Autoscaled";
            verticallyAlignedAutoscaledToolStripMenuItem.Click += verticallyAlignedAutoscaledToolStripMenuItem_Click;
            // 
            // tiledVerticalToolStripMenuItem
            // 
            tiledVerticalToolStripMenuItem.Name = "tiledVerticalToolStripMenuItem";
            tiledVerticalToolStripMenuItem.Size = new Size(227, 22);
            tiledVerticalToolStripMenuItem.Text = "Tiled Vertical";
            tiledVerticalToolStripMenuItem.Click += tiledVerticalToolStripMenuItem_Click;
            // 
            // tiledVerticalAutoscaledToolStripMenuItem
            // 
            tiledVerticalAutoscaledToolStripMenuItem.Name = "tiledVerticalAutoscaledToolStripMenuItem";
            tiledVerticalAutoscaledToolStripMenuItem.Size = new Size(227, 22);
            tiledVerticalAutoscaledToolStripMenuItem.Text = "Tiled Vertical Autoscaled";
            tiledVerticalAutoscaledToolStripMenuItem.Click += tiledVerticalAutoscaledToolStripMenuItem_Click;
            // 
            // tiledHorizontalToolStripMenuItem
            // 
            tiledHorizontalToolStripMenuItem.Name = "tiledHorizontalToolStripMenuItem";
            tiledHorizontalToolStripMenuItem.Size = new Size(227, 22);
            tiledHorizontalToolStripMenuItem.Text = "Tiled Horizontal";
            tiledHorizontalToolStripMenuItem.Click += tiledHorizontalToolStripMenuItem_Click;
            // 
            // tiledHorizontalAutoscaledToolStripMenuItem
            // 
            tiledHorizontalAutoscaledToolStripMenuItem.Name = "tiledHorizontalAutoscaledToolStripMenuItem";
            tiledHorizontalAutoscaledToolStripMenuItem.Size = new Size(227, 22);
            tiledHorizontalAutoscaledToolStripMenuItem.Text = "Tiled Horizontal Autoscaled";
            tiledHorizontalAutoscaledToolStripMenuItem.Click += tiledHorizontalAutoscaledToolStripMenuItem_Click;
            // 
            // animatedGraphDemoToolStripMenuItem
            // 
            animatedGraphDemoToolStripMenuItem.Enabled = false;
            animatedGraphDemoToolStripMenuItem.Name = "animatedGraphDemoToolStripMenuItem";
            animatedGraphDemoToolStripMenuItem.Size = new Size(227, 22);
            animatedGraphDemoToolStripMenuItem.Text = "Animated Graph Demo";
            animatedGraphDemoToolStripMenuItem.Click += animatedGraphDemoToolStripMenuItem_Click;
            // 
            // colorSchemesToolStripMenuItem
            // 
            colorSchemesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { blueToolStripMenuItem, whiteToolStripMenuItem, grayToolStripMenuItem, lightBlueToolStripMenuItem, blackToolStripMenuItem, redToolStripMenuItem, greenToolStripMenuItem });
            colorSchemesToolStripMenuItem.Name = "colorSchemesToolStripMenuItem";
            colorSchemesToolStripMenuItem.Size = new Size(180, 22);
            colorSchemesToolStripMenuItem.Text = "颜色模式";
            // 
            // blueToolStripMenuItem
            // 
            blueToolStripMenuItem.Name = "blueToolStripMenuItem";
            blueToolStripMenuItem.Size = new Size(127, 22);
            blueToolStripMenuItem.Text = "Blue";
            blueToolStripMenuItem.Click += blueToolStripMenuItem_Click;
            // 
            // whiteToolStripMenuItem
            // 
            whiteToolStripMenuItem.Name = "whiteToolStripMenuItem";
            whiteToolStripMenuItem.Size = new Size(127, 22);
            whiteToolStripMenuItem.Text = "White";
            whiteToolStripMenuItem.Click += whiteToolStripMenuItem_Click;
            // 
            // grayToolStripMenuItem
            // 
            grayToolStripMenuItem.Name = "grayToolStripMenuItem";
            grayToolStripMenuItem.Size = new Size(127, 22);
            grayToolStripMenuItem.Text = "Gray";
            grayToolStripMenuItem.Click += grayToolStripMenuItem_Click;
            // 
            // lightBlueToolStripMenuItem
            // 
            lightBlueToolStripMenuItem.Name = "lightBlueToolStripMenuItem";
            lightBlueToolStripMenuItem.Size = new Size(127, 22);
            lightBlueToolStripMenuItem.Text = "Light Blue";
            lightBlueToolStripMenuItem.Click += lightBlueToolStripMenuItem_Click;
            // 
            // blackToolStripMenuItem
            // 
            blackToolStripMenuItem.Name = "blackToolStripMenuItem";
            blackToolStripMenuItem.Size = new Size(127, 22);
            blackToolStripMenuItem.Text = "Black";
            blackToolStripMenuItem.Click += blackToolStripMenuItem_Click;
            // 
            // redToolStripMenuItem
            // 
            redToolStripMenuItem.Name = "redToolStripMenuItem";
            redToolStripMenuItem.Size = new Size(127, 22);
            redToolStripMenuItem.Text = "Red";
            redToolStripMenuItem.Click += redToolStripMenuItem_Click;
            // 
            // greenToolStripMenuItem
            // 
            greenToolStripMenuItem.Name = "greenToolStripMenuItem";
            greenToolStripMenuItem.Size = new Size(127, 22);
            greenToolStripMenuItem.Text = "Green";
            greenToolStripMenuItem.Click += greenToolStripMenuItem_Click;
            // 
            // numGraphsToolStripMenuItem
            // 
            numGraphsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem2, toolStripMenuItem3, toolStripMenuItem4, toolStripMenuItem5, toolStripMenuItem6, toolStripMenuItem7 });
            numGraphsToolStripMenuItem.Name = "numGraphsToolStripMenuItem";
            numGraphsToolStripMenuItem.Size = new Size(180, 22);
            numGraphsToolStripMenuItem.Text = "图形数量";
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(80, 22);
            toolStripMenuItem2.Text = "1";
            toolStripMenuItem2.Click += toolStripMenuItem2_Click;
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(80, 22);
            toolStripMenuItem3.Text = "2";
            toolStripMenuItem3.Click += toolStripMenuItem3_Click;
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new Size(80, 22);
            toolStripMenuItem4.Text = "3";
            toolStripMenuItem4.Click += toolStripMenuItem4_Click;
            // 
            // toolStripMenuItem5
            // 
            toolStripMenuItem5.Name = "toolStripMenuItem5";
            toolStripMenuItem5.Size = new Size(80, 22);
            toolStripMenuItem5.Text = "4";
            toolStripMenuItem5.Click += toolStripMenuItem5_Click;
            // 
            // toolStripMenuItem6
            // 
            toolStripMenuItem6.Name = "toolStripMenuItem6";
            toolStripMenuItem6.Size = new Size(80, 22);
            toolStripMenuItem6.Text = "5";
            toolStripMenuItem6.Click += toolStripMenuItem6_Click;
            // 
            // toolStripMenuItem7
            // 
            toolStripMenuItem7.Name = "toolStripMenuItem7";
            toolStripMenuItem7.Size = new Size(80, 22);
            toolStripMenuItem7.Text = "6";
            toolStripMenuItem7.Click += toolStripMenuItem7_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(177, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(180, 22);
            exitToolStripMenuItem.Text = "退出";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // display
            // 
            display.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            display.BackColor = Color.White;
            display.BackgroundColorBot = Color.FromArgb(0, 0, 64);
            display.BackgroundColorTop = Color.Navy;
            display.BackgroundImageLayout = ImageLayout.Stretch;
            display.DashedGridColor = Color.Blue;
            display.DoubleBuffering = true;
            display.Location = new Point(0, 22);
            display.Margin = new Padding(6, 7, 6, 7);
            display.Name = "display";
            display.PlaySpeed = 0.5F;
            display.Size = new Size(723, 550);
            display.SolidGridColor = Color.Blue;
            display.TabIndex = 1;
            // 
            // frmECG
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(723, 572);
            Controls.Add(display);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4);
            Name = "frmECG";
            Text = "心电图";
            WindowState = FormWindowState.Maximized;
            Load += frmECG_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem layoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem antiAliasedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem highQualityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem highSpeedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem examplesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem normalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stackedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verticallyAlignedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tiledVerticalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tiledHorizontalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem normalAutoscaledToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tiledVerticalAutoscaledToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tiledHorizontalAutoscaledToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verticallyAlignedAutoscaledToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorSchemesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem whiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem numGraphsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem grayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lightBlueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem animatedGraphDemoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem greenToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

