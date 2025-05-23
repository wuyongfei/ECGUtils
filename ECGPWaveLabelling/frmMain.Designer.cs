namespace ECGPWaveLabelling
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lstFiles = new ListBox();
            label1 = new Label();
            txtFile = new TextBox();
            btnBrowse = new Button();
            openFileDialog1 = new OpenFileDialog();
            lvLabels = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            comboLeads = new ComboBox();
            label2 = new Label();
            btnPWave = new Button();
            btnShowGraph = new Button();
            lblPWaveCnt = new Label();
            lstAllPWaves = new ListView();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            columnHeader7 = new ColumnHeader();
            columnHeader8 = new ColumnHeader();
            label3 = new Label();
            btnShowLeads = new Button();
            label4 = new Label();
            comboPLeads = new ComboBox();
            btnRemoveLead = new Button();
            SuspendLayout();
            // 
            // lstFiles
            // 
            lstFiles.FormattingEnabled = true;
            lstFiles.ItemHeight = 25;
            lstFiles.Location = new Point(12, 12);
            lstFiles.Name = "lstFiles";
            lstFiles.Size = new Size(354, 679);
            lstFiles.TabIndex = 0;
            lstFiles.SelectedIndexChanged += lstFiles_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(386, 9);
            label1.Name = "label1";
            label1.Size = new Size(271, 25);
            label1.TabIndex = 1;
            label1.Text = "从左侧点击文件名或者按[...]按钮";
            // 
            // txtFile
            // 
            txtFile.Location = new Point(387, 46);
            txtFile.Name = "txtFile";
            txtFile.Size = new Size(298, 31);
            txtFile.TabIndex = 2;
            // 
            // btnBrowse
            // 
            btnBrowse.Location = new Point(691, 46);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(36, 34);
            btnBrowse.TabIndex = 3;
            btnBrowse.Text = "...";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // lvLabels
            // 
            lvLabels.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4 });
            lvLabels.FullRowSelect = true;
            lvLabels.GridLines = true;
            lvLabels.Location = new Point(390, 201);
            lvLabels.MultiSelect = false;
            lvLabels.Name = "lvLabels";
            lvLabels.Size = new Size(337, 420);
            lvLabels.TabIndex = 17;
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
            // comboLeads
            // 
            comboLeads.FormattingEnabled = true;
            comboLeads.Items.AddRange(new object[] { "I - MDC_ECG_LEAD_I", "II - MDC_ECG_LEAD_II", "III - MDC_ECG_LEAD_III", "aVR - MDC_ECG_LEAD_aVR", "aVL - MDC_ECG_LEAD_AVL", "aVF - MDC_ECG_LEAD_AVF", "V1 - MDC_ECG_LEAD_V1", "V2 - MDC_ECG_LEAD_V2", "V3 - MDC_ECG_LEAD_V3", "V4 - MDC_ECG_LEAD_V4", "V5 - MDC_ECG_LEAD_V5", "V6 - MDC_ECG_LEAD_V6" });
            comboLeads.Location = new Point(496, 97);
            comboLeads.Name = "comboLeads";
            comboLeads.Size = new Size(231, 33);
            comboLeads.TabIndex = 18;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(393, 103);
            label2.Name = "label2";
            label2.Size = new Size(97, 25);
            label2.TabIndex = 19;
            label2.Text = "选择导联：";
            // 
            // btnPWave
            // 
            btnPWave.Location = new Point(615, 146);
            btnPWave.Name = "btnPWave";
            btnPWave.Size = new Size(112, 34);
            btnPWave.TabIndex = 20;
            btnPWave.Text = "计算 P 波";
            btnPWave.UseVisualStyleBackColor = true;
            btnPWave.Click += btnPWave_Click;
            // 
            // btnShowGraph
            // 
            btnShowGraph.Location = new Point(654, 641);
            btnShowGraph.Name = "btnShowGraph";
            btnShowGraph.Size = new Size(73, 34);
            btnShowGraph.TabIndex = 21;
            btnShowGraph.Text = "图示";
            btnShowGraph.UseVisualStyleBackColor = true;
            btnShowGraph.Click += btnShowGraph_Click;
            // 
            // lblPWaveCnt
            // 
            lblPWaveCnt.AutoSize = true;
            lblPWaveCnt.Location = new Point(395, 650);
            lblPWaveCnt.Name = "lblPWaveCnt";
            lblPWaveCnt.Size = new Size(90, 25);
            lblPWaveCnt.TabIndex = 22;
            lblPWaveCnt.Text = "P 波数量：";
            // 
            // lstAllPWaves
            // 
            lstAllPWaves.Columns.AddRange(new ColumnHeader[] { columnHeader5, columnHeader6, columnHeader7, columnHeader8 });
            lstAllPWaves.FullRowSelect = true;
            lstAllPWaves.GridLines = true;
            lstAllPWaves.Location = new Point(778, 46);
            lstAllPWaves.MultiSelect = false;
            lstAllPWaves.Name = "lstAllPWaves";
            lstAllPWaves.Size = new Size(337, 575);
            lstAllPWaves.TabIndex = 23;
            lstAllPWaves.UseCompatibleStateImageBehavior = false;
            lstAllPWaves.View = View.Details;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "P波";
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "导联";
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "起始";
            // 
            // columnHeader8
            // 
            columnHeader8.Text = "终止";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(778, 9);
            label3.Name = "label3";
            label3.Size = new Size(86, 25);
            label3.TabIndex = 24;
            label3.Text = "所有 P 波";
            // 
            // btnShowLeads
            // 
            btnShowLeads.Location = new Point(1038, 644);
            btnShowLeads.Name = "btnShowLeads";
            btnShowLeads.Size = new Size(77, 34);
            btnShowLeads.TabIndex = 25;
            btnShowLeads.Text = "图示";
            btnShowLeads.UseVisualStyleBackColor = true;
            btnShowLeads.Click += btnShowLeads_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(779, 646);
            label4.Name = "label4";
            label4.Size = new Size(59, 25);
            label4.TabIndex = 26;
            label4.Text = "导联：";
            // 
            // comboPLeads
            // 
            comboPLeads.FormattingEnabled = true;
            comboPLeads.Location = new Point(837, 644);
            comboPLeads.Name = "comboPLeads";
            comboPLeads.Size = new Size(80, 33);
            comboPLeads.TabIndex = 27;
            // 
            // btnRemoveLead
            // 
            btnRemoveLead.Location = new Point(918, 644);
            btnRemoveLead.Name = "btnRemoveLead";
            btnRemoveLead.Size = new Size(65, 34);
            btnRemoveLead.TabIndex = 28;
            btnRemoveLead.Text = "移除";
            btnRemoveLead.UseVisualStyleBackColor = true;
            btnRemoveLead.Click += btnRemoveLead_Click;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1135, 698);
            Controls.Add(btnRemoveLead);
            Controls.Add(comboPLeads);
            Controls.Add(label4);
            Controls.Add(btnShowLeads);
            Controls.Add(label3);
            Controls.Add(lstAllPWaves);
            Controls.Add(lblPWaveCnt);
            Controls.Add(btnShowGraph);
            Controls.Add(btnPWave);
            Controls.Add(label2);
            Controls.Add(comboLeads);
            Controls.Add(lvLabels);
            Controls.Add(btnBrowse);
            Controls.Add(txtFile);
            Controls.Add(label1);
            Controls.Add(lstFiles);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmMain";
            Text = "选取文件";
            Load += frmMain_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstFiles;
        private Label label1;
        private TextBox txtFile;
        private Button btnBrowse;
        private OpenFileDialog openFileDialog1;
        private ListView lvLabels;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ComboBox comboLeads;
        private Label label2;
        private Button btnPWave;
        private Button btnShowGraph;
        private Label lblPWaveCnt;
        private ListView lstAllPWaves;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader8;
        private Label label3;
        private Button btnShowLeads;
        private Label label4;
        private ComboBox comboPLeads;
        private Button btnRemoveLead;
    }
}
