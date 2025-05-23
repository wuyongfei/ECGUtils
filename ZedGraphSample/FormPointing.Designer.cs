namespace ZedGraphSample
{
    partial class FormPointing
    {
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
            zedGraph = new ZedGraph.ZedGraphControl();
            SuspendLayout();
            // 
            // zedGraph
            // 
            zedGraph.Location = new System.Drawing.Point(162, 54);
            zedGraph.Margin = new System.Windows.Forms.Padding(5);
            zedGraph.Name = "zedGraph";
            zedGraph.ScrollGrace = 0D;
            zedGraph.ScrollMaxX = 0D;
            zedGraph.ScrollMaxY = 0D;
            zedGraph.ScrollMaxY2 = 0D;
            zedGraph.ScrollMinX = 0D;
            zedGraph.ScrollMinY = 0D;
            zedGraph.ScrollMinY2 = 0D;
            zedGraph.Size = new System.Drawing.Size(1112, 940);
            zedGraph.TabIndex = 1;
            zedGraph.UseExtendedPrintDialog = true;
            // 
            // FormPointing
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1437, 1049);
            Controls.Add(zedGraph);
            Name = "FormPointing";
            Text = "FormPointing";
            Load += FormPointing_Load;
            ResumeLayout(false);
        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraph;
    }
}