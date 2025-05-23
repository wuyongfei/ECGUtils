namespace ECGPlotter
{
    partial class frmLabeling
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
            splitContainer1 = new SplitContainer();
            btnRedraw = new Button();
            btnCancel = new Button();
            btnClose = new Button();
            cbLabelTypes = new ComboBox();
            lblLabelType = new Label();
            btnEnd = new Button();
            btnStart = new Button();
            txtEnd = new TextBox();
            txtStart = new TextBox();
            lblEnd = new Label();
            lblStart = new Label();
            zedGraph = new ZedGraph.ZedGraphControl();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(btnRedraw);
            splitContainer1.Panel1.Controls.Add(btnCancel);
            splitContainer1.Panel1.Controls.Add(btnClose);
            splitContainer1.Panel1.Controls.Add(cbLabelTypes);
            splitContainer1.Panel1.Controls.Add(lblLabelType);
            splitContainer1.Panel1.Controls.Add(btnEnd);
            splitContainer1.Panel1.Controls.Add(btnStart);
            splitContainer1.Panel1.Controls.Add(txtEnd);
            splitContainer1.Panel1.Controls.Add(txtStart);
            splitContainer1.Panel1.Controls.Add(lblEnd);
            splitContainer1.Panel1.Controls.Add(lblStart);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(zedGraph);
            splitContainer1.Size = new Size(1028, 535);
            splitContainer1.SplitterDistance = 205;
            splitContainer1.TabIndex = 0;
            // 
            // btnRedraw
            // 
            btnRedraw.Location = new Point(117, 152);
            btnRedraw.Name = "btnRedraw";
            btnRedraw.Size = new Size(75, 23);
            btnRedraw.TabIndex = 10;
            btnRedraw.Text = "刷新";
            btnRedraw.UseVisualStyleBackColor = true;
            btnRedraw.Click += btnRedraw_Click;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnCancel.Location = new Point(16, 487);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(71, 36);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "取消";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnClose
            // 
            btnClose.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnClose.Location = new Point(127, 487);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(65, 36);
            btnClose.TabIndex = 8;
            btnClose.Text = "保存";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // cbLabelTypes
            // 
            cbLabelTypes.DrawMode = DrawMode.OwnerDrawFixed;
            cbLabelTypes.FlatStyle = FlatStyle.System;
            cbLabelTypes.FormattingEnabled = true;
            cbLabelTypes.Location = new Point(16, 110);
            cbLabelTypes.Name = "cbLabelTypes";
            cbLabelTypes.Size = new Size(176, 24);
            cbLabelTypes.TabIndex = 7;
            cbLabelTypes.DrawItem += cbLabelTypes_DrawItem;
            cbLabelTypes.SelectedIndexChanged += cbLabelTypes_SelectedIndexChanged;
            // 
            // lblLabelType
            // 
            lblLabelType.AutoSize = true;
            lblLabelType.Location = new Point(16, 83);
            lblLabelType.Name = "lblLabelType";
            lblLabelType.Size = new Size(58, 15);
            lblLabelType.TabIndex = 6;
            lblLabelType.Text = "标注类别";
            // 
            // btnEnd
            // 
            btnEnd.Location = new Point(142, 47);
            btnEnd.Name = "btnEnd";
            btnEnd.Size = new Size(50, 23);
            btnEnd.TabIndex = 5;
            btnEnd.Text = "<-";
            btnEnd.UseVisualStyleBackColor = true;
            btnEnd.Click += btnEnd_Click;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(140, 13);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(52, 23);
            btnStart.TabIndex = 4;
            btnStart.Text = "->";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // txtEnd
            // 
            txtEnd.Location = new Point(60, 47);
            txtEnd.Name = "txtEnd";
            txtEnd.Size = new Size(65, 23);
            txtEnd.TabIndex = 3;
            txtEnd.TextChanged += txtEnd_TextChanged;
            txtEnd.KeyPress += txtEnd_KeyPress;
            // 
            // txtStart
            // 
            txtStart.Location = new Point(60, 13);
            txtStart.Name = "txtStart";
            txtStart.Size = new Size(65, 23);
            txtStart.TabIndex = 2;
            txtStart.TextChanged += txtStart_TextChanged;
            txtStart.KeyPress += txtStart_KeyPress;
            // 
            // lblEnd
            // 
            lblEnd.AutoSize = true;
            lblEnd.Location = new Point(16, 48);
            lblEnd.Name = "lblEnd";
            lblEnd.Size = new Size(31, 15);
            lblEnd.TabIndex = 1;
            lblEnd.Text = "止点";
            // 
            // lblStart
            // 
            lblStart.AutoSize = true;
            lblStart.Location = new Point(16, 14);
            lblStart.Name = "lblStart";
            lblStart.Size = new Size(31, 15);
            lblStart.TabIndex = 0;
            lblStart.Text = "起点";
            // 
            // zedGraph
            // 
            zedGraph.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            zedGraph.Location = new Point(-10, 3);
            zedGraph.Margin = new Padding(4, 3, 4, 3);
            zedGraph.Name = "zedGraph";
            zedGraph.ScrollGrace = 0D;
            zedGraph.ScrollMaxX = 0D;
            zedGraph.ScrollMaxY = 0D;
            zedGraph.ScrollMaxY2 = 0D;
            zedGraph.ScrollMinX = 0D;
            zedGraph.ScrollMinY = 0D;
            zedGraph.ScrollMinY2 = 0D;
            zedGraph.Size = new Size(825, 529);
            zedGraph.TabIndex = 0;
            zedGraph.UseExtendedPrintDialog = true;
            // 
            // frmLabeling
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1028, 535);
            Controls.Add(splitContainer1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmLabeling";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "标注";
            FormClosing += frmLabeling_FormClosing;
            Load += frmLabeling_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private ZedGraph.ZedGraphControl zedGraph;
        private ComboBox cbLabelTypes;
        private Label lblLabelType;
        private Label lblEnd;
        private Label lblStart;
        private Button btnClose;
        private Button btnCancel;
        private Button btnRedraw;
        private Button btnEnd;
        private Button btnStart;
        private TextBox txtEnd;
        private TextBox txtStart;
    }
}