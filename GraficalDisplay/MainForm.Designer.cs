namespace GraficDisplay
{
    using GraphLib;

    partial class MainForm
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
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            layoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            filterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            noneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            antiAliasedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            highQualityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            highSpeedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            examplesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            normalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            normalAutoscaledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            stackedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            verticallyAlignedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            verticallyAlignedAutoscaledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            tiledVerticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            tiledVerticalAutoscaledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            tiledHorizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            tiledHorizontalAutoscaledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            animatedGraphDemoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            colorSchemesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            blueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            whiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            grayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            lightBlueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            blackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            redToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            greenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            numGraphsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            display = new PlotterDisplayEx();
            toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { layoutToolStripMenuItem });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new System.Windows.Forms.Padding(10, 4, 0, 4);
            menuStrip1.Size = new System.Drawing.Size(1033, 37);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // layoutToolStripMenuItem
            // 
            layoutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { filterToolStripMenuItem, examplesToolStripMenuItem, colorSchemesToolStripMenuItem, numGraphsToolStripMenuItem, toolStripMenuItem1, exitToolStripMenuItem });
            layoutToolStripMenuItem.Name = "layoutToolStripMenuItem";
            layoutToolStripMenuItem.Size = new System.Drawing.Size(92, 29);
            layoutToolStripMenuItem.Text = "Settings";
            // 
            // filterToolStripMenuItem
            // 
            filterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { noneToolStripMenuItem, antiAliasedToolStripMenuItem, highQualityToolStripMenuItem, highSpeedToolStripMenuItem });
            filterToolStripMenuItem.Name = "filterToolStripMenuItem";
            filterToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            filterToolStripMenuItem.Text = "Filter";
            // 
            // noneToolStripMenuItem
            // 
            noneToolStripMenuItem.Name = "noneToolStripMenuItem";
            noneToolStripMenuItem.Size = new System.Drawing.Size(213, 34);
            noneToolStripMenuItem.Text = "None";
            noneToolStripMenuItem.Click += noneToolStripMenuItem_Click;
            // 
            // antiAliasedToolStripMenuItem
            // 
            antiAliasedToolStripMenuItem.Name = "antiAliasedToolStripMenuItem";
            antiAliasedToolStripMenuItem.Size = new System.Drawing.Size(213, 34);
            antiAliasedToolStripMenuItem.Text = "AntiAliased";
            antiAliasedToolStripMenuItem.Click += antiAliasedToolStripMenuItem_Click;
            // 
            // highQualityToolStripMenuItem
            // 
            highQualityToolStripMenuItem.Name = "highQualityToolStripMenuItem";
            highQualityToolStripMenuItem.Size = new System.Drawing.Size(213, 34);
            highQualityToolStripMenuItem.Text = "High Quality";
            highQualityToolStripMenuItem.Click += highQualityToolStripMenuItem_Click;
            // 
            // highSpeedToolStripMenuItem
            // 
            highSpeedToolStripMenuItem.Name = "highSpeedToolStripMenuItem";
            highSpeedToolStripMenuItem.Size = new System.Drawing.Size(213, 34);
            highSpeedToolStripMenuItem.Text = "High Speed";
            highSpeedToolStripMenuItem.Click += highSpeedToolStripMenuItem_Click;
            // 
            // examplesToolStripMenuItem
            // 
            examplesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { normalToolStripMenuItem, normalAutoscaledToolStripMenuItem, stackedToolStripMenuItem, verticallyAlignedToolStripMenuItem, verticallyAlignedAutoscaledToolStripMenuItem, tiledVerticalToolStripMenuItem, tiledVerticalAutoscaledToolStripMenuItem, tiledHorizontalToolStripMenuItem, tiledHorizontalAutoscaledToolStripMenuItem, animatedGraphDemoToolStripMenuItem });
            examplesToolStripMenuItem.Name = "examplesToolStripMenuItem";
            examplesToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            examplesToolStripMenuItem.Text = "Examples";
            // 
            // normalToolStripMenuItem
            // 
            normalToolStripMenuItem.Name = "normalToolStripMenuItem";
            normalToolStripMenuItem.Size = new System.Drawing.Size(342, 34);
            normalToolStripMenuItem.Text = "Normal";
            normalToolStripMenuItem.Click += normalToolStripMenuItem_Click;
            // 
            // normalAutoscaledToolStripMenuItem
            // 
            normalAutoscaledToolStripMenuItem.Name = "normalAutoscaledToolStripMenuItem";
            normalAutoscaledToolStripMenuItem.Size = new System.Drawing.Size(342, 34);
            normalAutoscaledToolStripMenuItem.Text = "Normal Autoscaled";
            normalAutoscaledToolStripMenuItem.Click += normalAutoscaledToolStripMenuItem_Click;
            // 
            // stackedToolStripMenuItem
            // 
            stackedToolStripMenuItem.Name = "stackedToolStripMenuItem";
            stackedToolStripMenuItem.Size = new System.Drawing.Size(342, 34);
            stackedToolStripMenuItem.Text = "Stacked";
            stackedToolStripMenuItem.Click += stackedToolStripMenuItem_Click_1;
            // 
            // verticallyAlignedToolStripMenuItem
            // 
            verticallyAlignedToolStripMenuItem.Name = "verticallyAlignedToolStripMenuItem";
            verticallyAlignedToolStripMenuItem.Size = new System.Drawing.Size(342, 34);
            verticallyAlignedToolStripMenuItem.Text = "Vertically Aligned";
            verticallyAlignedToolStripMenuItem.Click += verticallyAlignedToolStripMenuItem_Click;
            // 
            // verticallyAlignedAutoscaledToolStripMenuItem
            // 
            verticallyAlignedAutoscaledToolStripMenuItem.Name = "verticallyAlignedAutoscaledToolStripMenuItem";
            verticallyAlignedAutoscaledToolStripMenuItem.Size = new System.Drawing.Size(342, 34);
            verticallyAlignedAutoscaledToolStripMenuItem.Text = "Vertically Aligned Autoscaled";
            verticallyAlignedAutoscaledToolStripMenuItem.Click += verticallyAlignedAutoscaledToolStripMenuItem_Click;
            // 
            // tiledVerticalToolStripMenuItem
            // 
            tiledVerticalToolStripMenuItem.Name = "tiledVerticalToolStripMenuItem";
            tiledVerticalToolStripMenuItem.Size = new System.Drawing.Size(342, 34);
            tiledVerticalToolStripMenuItem.Text = "Tiled Vertical";
            tiledVerticalToolStripMenuItem.Click += tiledVerticalToolStripMenuItem_Click;
            // 
            // tiledVerticalAutoscaledToolStripMenuItem
            // 
            tiledVerticalAutoscaledToolStripMenuItem.Name = "tiledVerticalAutoscaledToolStripMenuItem";
            tiledVerticalAutoscaledToolStripMenuItem.Size = new System.Drawing.Size(342, 34);
            tiledVerticalAutoscaledToolStripMenuItem.Text = "Tiled Vertical Autoscaled";
            tiledVerticalAutoscaledToolStripMenuItem.Click += tiledVerticalAutoscaledToolStripMenuItem_Click;
            // 
            // tiledHorizontalToolStripMenuItem
            // 
            tiledHorizontalToolStripMenuItem.Name = "tiledHorizontalToolStripMenuItem";
            tiledHorizontalToolStripMenuItem.Size = new System.Drawing.Size(342, 34);
            tiledHorizontalToolStripMenuItem.Text = "Tiled Horizontal";
            tiledHorizontalToolStripMenuItem.Click += tiledHorizontalToolStripMenuItem_Click;
            // 
            // tiledHorizontalAutoscaledToolStripMenuItem
            // 
            tiledHorizontalAutoscaledToolStripMenuItem.Name = "tiledHorizontalAutoscaledToolStripMenuItem";
            tiledHorizontalAutoscaledToolStripMenuItem.Size = new System.Drawing.Size(342, 34);
            tiledHorizontalAutoscaledToolStripMenuItem.Text = "Tiled Horizontal Autoscaled";
            tiledHorizontalAutoscaledToolStripMenuItem.Click += tiledHorizontalAutoscaledToolStripMenuItem_Click;
            // 
            // animatedGraphDemoToolStripMenuItem
            // 
            animatedGraphDemoToolStripMenuItem.Name = "animatedGraphDemoToolStripMenuItem";
            animatedGraphDemoToolStripMenuItem.Size = new System.Drawing.Size(342, 34);
            animatedGraphDemoToolStripMenuItem.Text = "Animated Graph Demo";
            animatedGraphDemoToolStripMenuItem.Click += animatedGraphDemoToolStripMenuItem_Click;
            // 
            // colorSchemesToolStripMenuItem
            // 
            colorSchemesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { blueToolStripMenuItem, whiteToolStripMenuItem, grayToolStripMenuItem, lightBlueToolStripMenuItem, blackToolStripMenuItem, redToolStripMenuItem, greenToolStripMenuItem });
            colorSchemesToolStripMenuItem.Name = "colorSchemesToolStripMenuItem";
            colorSchemesToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            colorSchemesToolStripMenuItem.Text = "Color Schemes";
            // 
            // blueToolStripMenuItem
            // 
            blueToolStripMenuItem.Name = "blueToolStripMenuItem";
            blueToolStripMenuItem.Size = new System.Drawing.Size(191, 34);
            blueToolStripMenuItem.Text = "Blue";
            blueToolStripMenuItem.Click += blueToolStripMenuItem_Click;
            // 
            // whiteToolStripMenuItem
            // 
            whiteToolStripMenuItem.Name = "whiteToolStripMenuItem";
            whiteToolStripMenuItem.Size = new System.Drawing.Size(191, 34);
            whiteToolStripMenuItem.Text = "White";
            whiteToolStripMenuItem.Click += whiteToolStripMenuItem_Click;
            // 
            // grayToolStripMenuItem
            // 
            grayToolStripMenuItem.Name = "grayToolStripMenuItem";
            grayToolStripMenuItem.Size = new System.Drawing.Size(191, 34);
            grayToolStripMenuItem.Text = "Gray";
            grayToolStripMenuItem.Click += grayToolStripMenuItem_Click;
            // 
            // lightBlueToolStripMenuItem
            // 
            lightBlueToolStripMenuItem.Name = "lightBlueToolStripMenuItem";
            lightBlueToolStripMenuItem.Size = new System.Drawing.Size(191, 34);
            lightBlueToolStripMenuItem.Text = "Light Blue";
            lightBlueToolStripMenuItem.Click += lightBlueToolStripMenuItem_Click;
            // 
            // blackToolStripMenuItem
            // 
            blackToolStripMenuItem.Name = "blackToolStripMenuItem";
            blackToolStripMenuItem.Size = new System.Drawing.Size(191, 34);
            blackToolStripMenuItem.Text = "Black";
            blackToolStripMenuItem.Click += blackToolStripMenuItem_Click;
            // 
            // redToolStripMenuItem
            // 
            redToolStripMenuItem.Name = "redToolStripMenuItem";
            redToolStripMenuItem.Size = new System.Drawing.Size(191, 34);
            redToolStripMenuItem.Text = "Red";
            redToolStripMenuItem.Click += redToolStripMenuItem_Click;
            // 
            // greenToolStripMenuItem
            // 
            greenToolStripMenuItem.Name = "greenToolStripMenuItem";
            greenToolStripMenuItem.Size = new System.Drawing.Size(191, 34);
            greenToolStripMenuItem.Text = "Green";
            greenToolStripMenuItem.Click += greenToolStripMenuItem_Click;
            // 
            // numGraphsToolStripMenuItem
            // 
            numGraphsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripMenuItem2, toolStripMenuItem3, toolStripMenuItem4, toolStripMenuItem5, toolStripMenuItem6, toolStripMenuItem7 });
            numGraphsToolStripMenuItem.Name = "numGraphsToolStripMenuItem";
            numGraphsToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            numGraphsToolStripMenuItem.Text = "Num Graphs";
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new System.Drawing.Size(124, 34);
            toolStripMenuItem2.Text = "1";
            toolStripMenuItem2.Click += toolStripMenuItem2_Click;
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new System.Drawing.Size(124, 34);
            toolStripMenuItem3.Text = "2";
            toolStripMenuItem3.Click += toolStripMenuItem3_Click;
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new System.Drawing.Size(124, 34);
            toolStripMenuItem4.Text = "3";
            toolStripMenuItem4.Click += toolStripMenuItem4_Click;
            // 
            // toolStripMenuItem5
            // 
            toolStripMenuItem5.Name = "toolStripMenuItem5";
            toolStripMenuItem5.Size = new System.Drawing.Size(124, 34);
            toolStripMenuItem5.Text = "4";
            toolStripMenuItem5.Click += toolStripMenuItem5_Click;
            // 
            // toolStripMenuItem6
            // 
            toolStripMenuItem6.Name = "toolStripMenuItem6";
            toolStripMenuItem6.Size = new System.Drawing.Size(124, 34);
            toolStripMenuItem6.Text = "5";
            toolStripMenuItem6.Click += toolStripMenuItem6_Click;
            // 
            // toolStripMenuItem7
            // 
            toolStripMenuItem7.Name = "toolStripMenuItem7";
            toolStripMenuItem7.Size = new System.Drawing.Size(124, 34);
            toolStripMenuItem7.Text = "6";
            toolStripMenuItem7.Click += toolStripMenuItem7_Click;
            // 
            // display
            // 
            display.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            display.BackColor = System.Drawing.Color.White;
            display.BackgroundColorBot = System.Drawing.Color.FromArgb(0, 0, 64);
            display.BackgroundColorTop = System.Drawing.Color.Navy;
            display.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            display.DashedGridColor = System.Drawing.Color.Blue;
            display.DoubleBuffering = true;
            display.Location = new System.Drawing.Point(0, 37);
            display.Margin = new System.Windows.Forms.Padding(8, 12, 8, 12);
            display.Name = "display";
            display.PlaySpeed = 0.5F;
            display.Size = new System.Drawing.Size(1033, 917);
            display.SolidGridColor = System.Drawing.Color.Blue;
            display.TabIndex = 1;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new System.Drawing.Size(267, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1033, 954);
            Controls.Add(display);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            Name = "MainForm";
            Text = "GraphLib Demo";
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
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

