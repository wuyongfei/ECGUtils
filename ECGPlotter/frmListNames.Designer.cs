namespace ECGPlotter
{
    partial class frmListNames
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
            lblFileList = new Label();
            lstNames = new ListBox();
            txtFileName = new TextBox();
            btnFinish = new Button();
            btnStart = new Button();
            lstNamesFinished = new ListBox();
            lblFileFinished = new Label();
            lblCurrFile = new Label();
            btnRedo = new Button();
            label1 = new Label();
            lvLeads = new ListView();
            LEAD = new ColumnHeader();
            ORIGN = new ColumnHeader();
            SCALE = new ColumnHeader();
            LENGTH = new ColumnHeader();
            lblFile = new Label();
            lblHeader = new Label();
            btnCheckAll = new Button();
            btnSetDefault = new Button();
            btnShowECG = new Button();
            lvLabels = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            SuspendLayout();
            // 
            // lblFileList
            // 
            lblFileList.AutoSize = true;
            lblFileList.Location = new Point(12, 6);
            lblFileList.Name = "lblFileList";
            lblFileList.Size = new Size(97, 15);
            lblFileList.TabIndex = 0;
            lblFileList.Text = "文件列表-待标注";
            // 
            // lstNames
            // 
            lstNames.FormattingEnabled = true;
            lstNames.ItemHeight = 15;
            lstNames.Location = new Point(12, 24);
            lstNames.Name = "lstNames";
            lstNames.Size = new Size(263, 214);
            lstNames.TabIndex = 1;
            lstNames.SelectedIndexChanged += lstNames_SelectedIndexChanged;
            lstNames.DoubleClick += lstNames_DoubleClick;
            // 
            // txtFileName
            // 
            txtFileName.Location = new Point(297, 24);
            txtFileName.Name = "txtFileName";
            txtFileName.ReadOnly = true;
            txtFileName.Size = new Size(274, 23);
            txtFileName.TabIndex = 2;
            txtFileName.TextChanged += txtFileName_TextChanged;
            // 
            // btnFinish
            // 
            btnFinish.Location = new Point(496, 503);
            btnFinish.Name = "btnFinish";
            btnFinish.Size = new Size(75, 23);
            btnFinish.TabIndex = 3;
            btnFinish.Text = "完成标注";
            btnFinish.UseVisualStyleBackColor = true;
            btnFinish.Click += btnFinish_Click;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(297, 503);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(75, 23);
            btnStart.TabIndex = 4;
            btnStart.Text = "开始标注";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // lstNamesFinished
            // 
            lstNamesFinished.FormattingEnabled = true;
            lstNamesFinished.ItemHeight = 15;
            lstNamesFinished.Location = new Point(12, 265);
            lstNamesFinished.Name = "lstNamesFinished";
            lstNamesFinished.Size = new Size(263, 229);
            lstNamesFinished.TabIndex = 5;
            lstNamesFinished.SelectedIndexChanged += lstNamesFinished_SelectedIndexChanged;
            // 
            // lblFileFinished
            // 
            lblFileFinished.AutoSize = true;
            lblFileFinished.Location = new Point(12, 247);
            lblFileFinished.Name = "lblFileFinished";
            lblFileFinished.Size = new Size(97, 15);
            lblFileFinished.TabIndex = 6;
            lblFileFinished.Text = "文件列表-已标注";
            // 
            // lblCurrFile
            // 
            lblCurrFile.AutoSize = true;
            lblCurrFile.Location = new Point(297, 3);
            lblCurrFile.Name = "lblCurrFile";
            lblCurrFile.Size = new Size(79, 15);
            lblCurrFile.TabIndex = 7;
            lblCurrFile.Text = "当前工作文件";
            // 
            // btnRedo
            // 
            btnRedo.Location = new Point(200, 503);
            btnRedo.Name = "btnRedo";
            btnRedo.Size = new Size(75, 23);
            btnRedo.TabIndex = 8;
            btnRedo.Text = "重新标注";
            btnRedo.UseVisualStyleBackColor = true;
            btnRedo.Click += btnRedo_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 507);
            label1.Name = "label1";
            label1.Size = new Size(187, 15);
            label1.TabIndex = 9;
            label1.Text = "如需重新标注，选择文件，点击 ->";
            // 
            // lvLeads
            // 
            lvLeads.CheckBoxes = true;
            lvLeads.Columns.AddRange(new ColumnHeader[] { LEAD, ORIGN, SCALE, LENGTH });
            lvLeads.FullRowSelect = true;
            lvLeads.GridLines = true;
            lvLeads.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvLeads.Location = new Point(301, 109);
            lvLeads.MultiSelect = false;
            lvLeads.Name = "lvLeads";
            lvLeads.Size = new Size(270, 242);
            lvLeads.TabIndex = 10;
            lvLeads.UseCompatibleStateImageBehavior = false;
            lvLeads.View = View.Details;
            // 
            // LEAD
            // 
            LEAD.Text = "Lead";
            LEAD.Width = 80;
            // 
            // ORIGN
            // 
            ORIGN.Text = "Origin";
            ORIGN.TextAlign = HorizontalAlignment.Center;
            ORIGN.Width = 70;
            // 
            // SCALE
            // 
            SCALE.Text = "Scale";
            SCALE.TextAlign = HorizontalAlignment.Center;
            SCALE.Width = 80;
            // 
            // LENGTH
            // 
            LENGTH.Text = "# Data";
            LENGTH.TextAlign = HorizontalAlignment.Right;
            LENGTH.Width = 65;
            // 
            // lblFile
            // 
            lblFile.AutoSize = true;
            lblFile.Location = new Point(301, 64);
            lblFile.Name = "lblFile";
            lblFile.Size = new Size(25, 15);
            lblFile.TabIndex = 11;
            lblFile.Text = "File";
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Location = new Point(301, 86);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(45, 15);
            lblHeader.TabIndex = 12;
            lblHeader.Text = "Header";
            // 
            // btnCheckAll
            // 
            btnCheckAll.Location = new Point(304, 359);
            btnCheckAll.Name = "btnCheckAll";
            btnCheckAll.Size = new Size(42, 23);
            btnCheckAll.TabIndex = 13;
            btnCheckAll.Text = "全选";
            btnCheckAll.UseVisualStyleBackColor = true;
            btnCheckAll.Click += btnCheckAll_Click;
            // 
            // btnSetDefault
            // 
            btnSetDefault.Location = new Point(351, 359);
            btnSetDefault.Name = "btnSetDefault";
            btnSetDefault.Size = new Size(48, 23);
            btnSetDefault.TabIndex = 14;
            btnSetDefault.Text = "预设";
            btnSetDefault.UseVisualStyleBackColor = true;
            btnSetDefault.Click += btnSetDefault_Click;
            // 
            // btnShowECG
            // 
            btnShowECG.Location = new Point(481, 359);
            btnShowECG.Name = "btnShowECG";
            btnShowECG.Size = new Size(90, 23);
            btnShowECG.TabIndex = 15;
            btnShowECG.Text = "显示心电图";
            btnShowECG.UseVisualStyleBackColor = true;
            btnShowECG.Click += btnShowECG_Click;
            // 
            // lvLabels
            // 
            lvLabels.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4 });
            lvLabels.FullRowSelect = true;
            lvLabels.GridLines = true;
            lvLabels.Location = new Point(304, 388);
            lvLabels.MultiSelect = false;
            lvLabels.Name = "lvLabels";
            lvLabels.Size = new Size(267, 97);
            lvLabels.TabIndex = 16;
            lvLabels.UseCompatibleStateImageBehavior = false;
            lvLabels.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "P波";
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "导联";
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "起始";
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "终止";
            // 
            // frmListNames
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(586, 531);
            Controls.Add(lvLabels);
            Controls.Add(btnShowECG);
            Controls.Add(btnSetDefault);
            Controls.Add(btnCheckAll);
            Controls.Add(lblHeader);
            Controls.Add(lblFile);
            Controls.Add(lvLeads);
            Controls.Add(label1);
            Controls.Add(btnRedo);
            Controls.Add(lblCurrFile);
            Controls.Add(lblFileFinished);
            Controls.Add(lstNamesFinished);
            Controls.Add(btnStart);
            Controls.Add(btnFinish);
            Controls.Add(txtFileName);
            Controls.Add(lstNames);
            Controls.Add(lblFileList);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "frmListNames";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ECG标注工具";
            Load += frmListNames_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblFileList;
        private ListBox lstNames;
        private TextBox txtFileName;
        private Button btnFinish;
        private Button btnStart;
        private ListBox lstNamesFinished;
        private Label lblFileFinished;
        private Label lblCurrFile;
        private Button btnRedo;
        private Label label1;
        private ListView lvLeads;
        private ColumnHeader LEAD;
        private ColumnHeader ORIGN;
        private ColumnHeader SCALE;
        private ColumnHeader LENGTH;
        private Label lblFile;
        private Label lblHeader;
        private Button btnCheckAll;
        private Button btnSetDefault;
        private Button btnShowECG;
        private ListView lvLabels;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
    }
}