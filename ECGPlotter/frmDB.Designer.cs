namespace ECGPlotter
{
    partial class frmDB
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
            columnHeader4 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader1 = new ColumnHeader();
            lvLabels = new ListView();
            columnHeader3 = new ColumnHeader();
            btnShowECG = new Button();
            btnSetDefault = new Button();
            btnCheckAll = new Button();
            lblHeader = new Label();
            lblFile = new Label();
            LENGTH = new ColumnHeader();
            SCALE = new ColumnHeader();
            ORIGN = new ColumnHeader();
            lvLeads = new ListView();
            LEAD = new ColumnHeader();
            label1 = new Label();
            btnRedo = new Button();
            lblCurrFile = new Label();
            lblFileFinished = new Label();
            btnStart = new Button();
            btnFinish = new Button();
            txtFileName = new TextBox();
            lblFileList = new Label();
            lstNames = new ListView();
            FullPath = new ColumnHeader();
            lstFinishedNames = new ListView();
            FullPathFinished = new ColumnHeader();
            SuspendLayout();
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "终止";
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "导联";
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "P波";
            // 
            // lvLabels
            // 
            lvLabels.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4 });
            lvLabels.FullRowSelect = true;
            lvLabels.GridLines = true;
            lvLabels.Location = new Point(304, 391);
            lvLabels.MultiSelect = false;
            lvLabels.Name = "lvLabels";
            lvLabels.Size = new Size(267, 106);
            lvLabels.TabIndex = 33;
            lvLabels.UseCompatibleStateImageBehavior = false;
            lvLabels.View = View.Details;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "起始";
            // 
            // btnShowECG
            // 
            btnShowECG.Location = new Point(481, 362);
            btnShowECG.Name = "btnShowECG";
            btnShowECG.Size = new Size(90, 23);
            btnShowECG.TabIndex = 32;
            btnShowECG.Text = "显示心电图";
            btnShowECG.UseVisualStyleBackColor = true;
            btnShowECG.Click += btnShowECG_Click;
            // 
            // btnSetDefault
            // 
            btnSetDefault.Location = new Point(351, 362);
            btnSetDefault.Name = "btnSetDefault";
            btnSetDefault.Size = new Size(48, 23);
            btnSetDefault.TabIndex = 31;
            btnSetDefault.Text = "预设";
            btnSetDefault.UseVisualStyleBackColor = true;
            btnSetDefault.Click += btnSetDefault_Click;
            // 
            // btnCheckAll
            // 
            btnCheckAll.Location = new Point(304, 362);
            btnCheckAll.Name = "btnCheckAll";
            btnCheckAll.Size = new Size(42, 23);
            btnCheckAll.TabIndex = 30;
            btnCheckAll.Text = "全选";
            btnCheckAll.UseVisualStyleBackColor = true;
            btnCheckAll.Click += btnCheckAll_Click;
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Location = new Point(301, 89);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(45, 15);
            lblHeader.TabIndex = 29;
            lblHeader.Text = "Header";
            // 
            // lblFile
            // 
            lblFile.AutoSize = true;
            lblFile.Location = new Point(301, 67);
            lblFile.Name = "lblFile";
            lblFile.Size = new Size(25, 15);
            lblFile.TabIndex = 28;
            lblFile.Text = "File";
            // 
            // LENGTH
            // 
            LENGTH.Text = "# Data";
            LENGTH.TextAlign = HorizontalAlignment.Right;
            LENGTH.Width = 65;
            // 
            // SCALE
            // 
            SCALE.Text = "Scale";
            SCALE.TextAlign = HorizontalAlignment.Center;
            SCALE.Width = 80;
            // 
            // ORIGN
            // 
            ORIGN.Text = "Origin";
            ORIGN.TextAlign = HorizontalAlignment.Center;
            ORIGN.Width = 70;
            // 
            // lvLeads
            // 
            lvLeads.CheckBoxes = true;
            lvLeads.Columns.AddRange(new ColumnHeader[] { LEAD, ORIGN, SCALE, LENGTH });
            lvLeads.FullRowSelect = true;
            lvLeads.GridLines = true;
            lvLeads.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvLeads.Location = new Point(301, 112);
            lvLeads.MultiSelect = false;
            lvLeads.Name = "lvLeads";
            lvLeads.Size = new Size(270, 242);
            lvLeads.TabIndex = 27;
            lvLeads.UseCompatibleStateImageBehavior = false;
            lvLeads.View = View.Details;
            lvLeads.SelectedIndexChanged += lvLeads_SelectedIndexChanged;
            // 
            // LEAD
            // 
            LEAD.Text = "Lead";
            LEAD.Width = 80;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 510);
            label1.Name = "label1";
            label1.Size = new Size(187, 15);
            label1.TabIndex = 26;
            label1.Text = "如需重新标注，选择文件，点击 ->";
            // 
            // btnRedo
            // 
            btnRedo.Location = new Point(200, 506);
            btnRedo.Name = "btnRedo";
            btnRedo.Size = new Size(75, 23);
            btnRedo.TabIndex = 25;
            btnRedo.Text = "重新标注";
            btnRedo.UseVisualStyleBackColor = true;
            btnRedo.Click += btnRedo_Click;
            // 
            // lblCurrFile
            // 
            lblCurrFile.AutoSize = true;
            lblCurrFile.Location = new Point(297, 6);
            lblCurrFile.Name = "lblCurrFile";
            lblCurrFile.Size = new Size(79, 15);
            lblCurrFile.TabIndex = 24;
            lblCurrFile.Text = "当前工作文件";
            // 
            // lblFileFinished
            // 
            lblFileFinished.AutoSize = true;
            lblFileFinished.Location = new Point(12, 259);
            lblFileFinished.Name = "lblFileFinished";
            lblFileFinished.Size = new Size(97, 15);
            lblFileFinished.TabIndex = 23;
            lblFileFinished.Text = "文件列表-已标注";
            // 
            // btnStart
            // 
            btnStart.Location = new Point(297, 506);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(75, 23);
            btnStart.TabIndex = 21;
            btnStart.Text = "开始标注";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnFinish
            // 
            btnFinish.Location = new Point(496, 506);
            btnFinish.Name = "btnFinish";
            btnFinish.Size = new Size(75, 23);
            btnFinish.TabIndex = 20;
            btnFinish.Text = "完成标注";
            btnFinish.UseVisualStyleBackColor = true;
            btnFinish.Click += btnFinish_Click;
            // 
            // txtFileName
            // 
            txtFileName.Location = new Point(297, 27);
            txtFileName.Name = "txtFileName";
            txtFileName.ReadOnly = true;
            txtFileName.Size = new Size(274, 23);
            txtFileName.TabIndex = 19;
            txtFileName.TextChanged += txtFileName_TextChanged;
            // 
            // lblFileList
            // 
            lblFileList.AutoSize = true;
            lblFileList.Location = new Point(12, 9);
            lblFileList.Name = "lblFileList";
            lblFileList.Size = new Size(97, 15);
            lblFileList.TabIndex = 17;
            lblFileList.Text = "文件列表-待标注";
            // 
            // lstNames
            // 
            lstNames.Columns.AddRange(new ColumnHeader[] { FullPath });
            lstNames.FullRowSelect = true;
            lstNames.HeaderStyle = ColumnHeaderStyle.None;
            lstNames.LabelWrap = false;
            lstNames.Location = new Point(12, 27);
            lstNames.MultiSelect = false;
            lstNames.Name = "lstNames";
            lstNames.Size = new Size(263, 220);
            lstNames.TabIndex = 34;
            lstNames.UseCompatibleStateImageBehavior = false;
            lstNames.View = View.Details;
            lstNames.ItemSelectionChanged += lstNames_ItemSelectionChanged;
            // 
            // FullPath
            // 
            FullPath.Text = "FullPath";
            // 
            // lstFinishedNames
            // 
            lstFinishedNames.Columns.AddRange(new ColumnHeader[] { FullPathFinished });
            lstFinishedNames.FullRowSelect = true;
            lstFinishedNames.HeaderStyle = ColumnHeaderStyle.None;
            lstFinishedNames.LabelWrap = false;
            lstFinishedNames.Location = new Point(12, 277);
            lstFinishedNames.MultiSelect = false;
            lstFinishedNames.Name = "lstFinishedNames";
            lstFinishedNames.Size = new Size(263, 220);
            lstFinishedNames.TabIndex = 35;
            lstFinishedNames.UseCompatibleStateImageBehavior = false;
            lstFinishedNames.View = View.Details;
            lstFinishedNames.ItemSelectionChanged += lstFinishedNames_ItemSelectionChanged;
            // 
            // FullPathFinished
            // 
            FullPathFinished.Text = "FullPathFinished";
            // 
            // frmDB
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(586, 542);
            Controls.Add(lstFinishedNames);
            Controls.Add(lstNames);
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
            Controls.Add(btnStart);
            Controls.Add(btnFinish);
            Controls.Add(txtFileName);
            Controls.Add(lblFileList);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmDB";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "标准工具";
            Load += frmDB_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader1;
        private ListView lvLabels;
        private ColumnHeader columnHeader3;
        private Button btnShowECG;
        private Button btnSetDefault;
        private Button btnCheckAll;
        private Label lblHeader;
        private Label lblFile;
        private ColumnHeader LENGTH;
        private ColumnHeader SCALE;
        private ColumnHeader ORIGN;
        private ListView lvLeads;
        private ColumnHeader LEAD;
        private Label label1;
        private Button btnRedo;
        private Label lblCurrFile;
        private Label lblFileFinished;
        private Button btnStart;
        private Button btnFinish;
        private TextBox txtFileName;
        private Label lblFileList;
        private ListView lstNames;
        private ListView lstFinishedNames;
        private ColumnHeader FullPath;
        private ColumnHeader FullPathFinished;
    }
}