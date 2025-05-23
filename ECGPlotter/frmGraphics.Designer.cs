namespace ECGPlotter
{
    partial class frmGraphics
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
            splitContainer1 = new SplitContainer();
            btnClose = new Button();
            btnEditLabel = new Button();
            btnRemoveLabel = new Button();
            txtLead = new TextBox();
            txtAuthor = new TextBox();
            lblAuthor = new Label();
            txtDateTime = new TextBox();
            lblDateTime = new Label();
            txtEnd = new TextBox();
            txtStart = new TextBox();
            lblXValues = new Label();
            txtLabelType = new TextBox();
            lblLabelType = new Label();
            label1 = new Label();
            lvLabels = new ListView();
            columnHeader1 = new ColumnHeader();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // zedGraph
            // 
            zedGraph.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            zedGraph.Location = new Point(5, 5);
            zedGraph.Margin = new Padding(5);
            zedGraph.Name = "zedGraph";
            zedGraph.ScrollGrace = 0D;
            zedGraph.ScrollMaxX = 0D;
            zedGraph.ScrollMaxY = 0D;
            zedGraph.ScrollMaxY2 = 0D;
            zedGraph.ScrollMinX = 0D;
            zedGraph.ScrollMinY = 0D;
            zedGraph.ScrollMinY2 = 0D;
            zedGraph.Size = new Size(1021, 612);
            zedGraph.TabIndex = 2;
            zedGraph.UseExtendedPrintDialog = true;
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer1.Location = new Point(6, 5);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(btnClose);
            splitContainer1.Panel1.Controls.Add(btnEditLabel);
            splitContainer1.Panel1.Controls.Add(btnRemoveLabel);
            splitContainer1.Panel1.Controls.Add(txtLead);
            splitContainer1.Panel1.Controls.Add(txtAuthor);
            splitContainer1.Panel1.Controls.Add(lblAuthor);
            splitContainer1.Panel1.Controls.Add(txtDateTime);
            splitContainer1.Panel1.Controls.Add(lblDateTime);
            splitContainer1.Panel1.Controls.Add(txtEnd);
            splitContainer1.Panel1.Controls.Add(txtStart);
            splitContainer1.Panel1.Controls.Add(lblXValues);
            splitContainer1.Panel1.Controls.Add(txtLabelType);
            splitContainer1.Panel1.Controls.Add(lblLabelType);
            splitContainer1.Panel1.Controls.Add(label1);
            splitContainer1.Panel1.Controls.Add(lvLabels);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(zedGraph);
            splitContainer1.Size = new Size(1181, 622);
            splitContainer1.SplitterDistance = 146;
            splitContainer1.TabIndex = 3;
            // 
            // btnClose
            // 
            btnClose.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.Location = new Point(28, 592);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 14;
            btnClose.Text = "关闭";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnEditLabel
            // 
            btnEditLabel.Location = new Point(89, 549);
            btnEditLabel.Name = "btnEditLabel";
            btnEditLabel.Size = new Size(52, 23);
            btnEditLabel.TabIndex = 13;
            btnEditLabel.Text = "编辑";
            btnEditLabel.UseVisualStyleBackColor = true;
            btnEditLabel.Click += btnEditLabel_Click;
            // 
            // btnRemoveLabel
            // 
            btnRemoveLabel.Location = new Point(6, 548);
            btnRemoveLabel.Name = "btnRemoveLabel";
            btnRemoveLabel.Size = new Size(60, 23);
            btnRemoveLabel.TabIndex = 12;
            btnRemoveLabel.Text = "删除";
            btnRemoveLabel.UseVisualStyleBackColor = true;
            btnRemoveLabel.Click += btnRemoveLabel_Click;
            // 
            // txtLead
            // 
            txtLead.Location = new Point(89, 363);
            txtLead.Name = "txtLead";
            txtLead.ReadOnly = true;
            txtLead.Size = new Size(52, 23);
            txtLead.TabIndex = 11;
            txtLead.Text = "I";
            txtLead.TextAlign = HorizontalAlignment.Center;
            // 
            // txtAuthor
            // 
            txtAuthor.Location = new Point(6, 515);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.ReadOnly = true;
            txtAuthor.Size = new Size(135, 23);
            txtAuthor.TabIndex = 10;
            // 
            // lblAuthor
            // 
            lblAuthor.AutoSize = true;
            lblAuthor.Location = new Point(8, 496);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(44, 15);
            lblAuthor.TabIndex = 9;
            lblAuthor.Text = "标注人";
            // 
            // txtDateTime
            // 
            txtDateTime.Location = new Point(6, 465);
            txtDateTime.Name = "txtDateTime";
            txtDateTime.ReadOnly = true;
            txtDateTime.Size = new Size(135, 23);
            txtDateTime.TabIndex = 8;
            // 
            // lblDateTime
            // 
            lblDateTime.AutoSize = true;
            lblDateTime.Location = new Point(8, 446);
            lblDateTime.Name = "lblDateTime";
            lblDateTime.Size = new Size(58, 15);
            lblDateTime.TabIndex = 7;
            lblDateTime.Text = "标注时间";
            // 
            // txtEnd
            // 
            txtEnd.Location = new Point(89, 412);
            txtEnd.Name = "txtEnd";
            txtEnd.ReadOnly = true;
            txtEnd.Size = new Size(52, 23);
            txtEnd.TabIndex = 6;
            txtEnd.TextAlign = HorizontalAlignment.Center;
            // 
            // txtStart
            // 
            txtStart.Location = new Point(6, 412);
            txtStart.Name = "txtStart";
            txtStart.ReadOnly = true;
            txtStart.Size = new Size(54, 23);
            txtStart.TabIndex = 5;
            txtStart.TextAlign = HorizontalAlignment.Center;
            // 
            // lblXValues
            // 
            lblXValues.AutoSize = true;
            lblXValues.Location = new Point(8, 394);
            lblXValues.Name = "lblXValues";
            lblXValues.Size = new Size(52, 15);
            lblXValues.TabIndex = 4;
            lblXValues.Text = "X轴范围";
            // 
            // txtLabelType
            // 
            txtLabelType.Location = new Point(6, 364);
            txtLabelType.Name = "txtLabelType";
            txtLabelType.ReadOnly = true;
            txtLabelType.Size = new Size(54, 23);
            txtLabelType.TabIndex = 3;
            txtLabelType.Text = "P0";
            txtLabelType.TextAlign = HorizontalAlignment.Center;
            // 
            // lblLabelType
            // 
            lblLabelType.AutoSize = true;
            lblLabelType.Location = new Point(8, 345);
            lblLabelType.Name = "lblLabelType";
            lblLabelType.Size = new Size(89, 15);
            lblLabelType.TabIndex = 2;
            lblLabelType.Text = "标注类别/导联";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 12);
            label1.Name = "label1";
            label1.Size = new Size(32, 15);
            label1.TabIndex = 1;
            label1.Text = "标注";
            // 
            // lvLabels
            // 
            lvLabels.Columns.AddRange(new ColumnHeader[] { columnHeader1 });
            lvLabels.HeaderStyle = ColumnHeaderStyle.None;
            lvLabels.LabelWrap = false;
            lvLabels.Location = new Point(6, 34);
            lvLabels.MultiSelect = false;
            lvLabels.Name = "lvLabels";
            lvLabels.Size = new Size(135, 261);
            lvLabels.TabIndex = 0;
            lvLabels.UseCompatibleStateImageBehavior = false;
            lvLabels.View = View.Tile;
            lvLabels.SelectedIndexChanged += lvLabels_SelectedIndexChanged;
            // 
            // frmGraphics
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1190, 632);
            Controls.Add(splitContainer1);
            DoubleBuffered = true;
            Name = "frmGraphics";
            Text = "frmGraphics";
            WindowState = FormWindowState.Maximized;
            Load += frmGraphics_Load;
            Paint += frmGraphics_Paint;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraph;
        private SplitContainer splitContainer1;
        private ListView lvLabels;
        private ColumnHeader columnHeader1;
        private Label label1;
        private TextBox txtDateTime;
        private Label lblDateTime;
        private TextBox txtEnd;
        private TextBox txtStart;
        private Label lblXValues;
        private TextBox txtLabelType;
        private Label lblLabelType;
        private TextBox txtAuthor;
        private Label lblAuthor;
        private TextBox txtLead;
        private Button btnEditLabel;
        private Button btnRemoveLabel;
        private Button btnClose;
    }
}