using ECGXmlReader;
using GraficDisplay;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;

namespace ECGPlotter;

public partial class frmListNames : Form
{
    public List<string> XmlFileList { get; set; }
    public List<string> FinishedList { get; set; }
    public string RootFolder { get; set; }

    public string[] DefaultWorkLeads { get; set; }

    private ECGMapping ecgm;
    private LabelHandler handler;
    private ECGSettings mySettings;

    public frmListNames()
    {
        InitializeComponent();

        mySettings = Program.Configuration.GetSection("ECGSettings").Get<ECGSettings>();
    }


    private ECGMapping LoadXml(string xmlFile)
    {
        try
        {
            this.Cursor = Cursors.WaitCursor;

            ECGMapping ecg = XMLParser.ReadXml(xmlFile);

            if (ecg != null)
            {
                //if (ecg.Header != null)
                //{
                //    Debug.WriteLine("    HEADER: " + ecg.Header.Log());
                //}

                //foreach (ECGDataItem item in ecg.GetItems())
                //{
                //    Debug.WriteLine("    DATA: " + item.Log());
                //}
                ECGDataItem item = ecg.GetItem("MDC_ECG_LEAD_II");     // II 导联
                if (item == null)
                {
                    throw new Exception($"文件 {xmlFile} 的数据有错误。");
                }

                string labelfile = Path.Combine(ecg.XmlFilePath, mySettings.LabelFileName);
                if (!File.Exists(labelfile))
                {
                    List<LabelInfo> ls = item.GetLabels();
                    if (ls != null)
                    {
                        bool b = LabelHandler.SaveLabels(ls, labelfile);
                    }
                }
            }
            else
            {
                throw new Exception($"读取文件 {xmlFile} 出错。");
            }

            this.Cursor = Cursors.Default;

            return ecg;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message,this.Text);
        }
        finally
        {
            this.Cursor = Cursors.Default;
        }

        return null;
    }

    private void LoadGraphic()
    {
        string lead = lvLeads.SelectedItems[0].Text;

        frmGraphics form = new frmGraphics();
        form.ECG = ecgm;
        form.SelectedLead = lead;

        handler.Lead = lead;
        form.Handler = handler;

        form.ShowDialog();
        form.Close();
        form = null;

        // reload labels
        LoadLabels();
    }

    private void frmListNames_Load(object sender, EventArgs e)
    {
        foreach (string xmlFile in XmlFileList)
        {
            lstNames.Items.Add(xmlFile);
        }

        if (lstNames.Items.Count > 0) { lstNames.SelectedIndex = 0; }

        foreach (string xmlFile in FinishedList)
        {
            lstNamesFinished.Items.Add(xmlFile);
        }

    }

    private void lstNames_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (lstNames.SelectedIndex == -1) return;

        string xmlfile = lstNames.Text;

        if (!File.Exists(xmlfile))
        {
            MessageBox.Show($"File {xmlfile} does not exists");
            txtFileName.Text = string.Empty;
            //btnStart.Enabled = false;
        }
        else
        {
            txtFileName.Text = xmlfile;
            lblFile.Text = xmlfile;

            LoadData(xmlfile);
            //btnStart.Enabled = true;
        }

    }

    private void LoadListView()
    {
        lvLeads.Items.Clear();

        lvLeads.Font = new Font(lvLeads.Font, FontStyle.Bold);

        foreach (ECGDataItem di in ecgm.GetItems())
        {
            string itemKey = di.Code.Replace("MDC_ECG_LEAD_", "");

            bool isDefault = DefaultWorkLeads.Contains(itemKey);

            ListViewItem row = new ListViewItem(itemKey);
            row.Font = new Font(row.Font, FontStyle.Regular);
            row.Checked = isDefault;

            if (itemKey == DefaultWorkLeads[0])
            {
                row.Selected = true;
            }

            row.SubItems.Add(di.Origin);
            row.SubItems.Add(di.Scale);
            row.SubItems.Add(di.digits.Length.ToString());

            lvLeads.Items.Add(row);
        }

        lvLeads.Columns[lvLeads.Columns.Count - 1].Width = -2;

        lblHeader.Text = ecgm.Header.Log();
    }

    private void lstNames_DoubleClick(object sender, EventArgs e)
    {
        //string xmlfile = lstNames.Text;

        //if (!File.Exists(xmlfile))
        //{
        //    MessageBox.Show($"File {xmlfile} does not exists");
        //    txtFileName.Text = string.Empty;
        //}
        //else
        //{
        //    txtFileName.Text = xmlfile;
        //    LoadGraphic(xmlfile);
        //}
    }

    private void btnStart_Click(object sender, EventArgs e)
    {
        //string xmlfile = txtFileName.Text;
        LoadGraphic();
    }

    private void btnFinish_Click(object sender, EventArgs e)
    {
        lstNamesFinished.Items.Add(txtFileName.Text);

        Append(txtFileName.Text);

        lstNames.Items.Remove(txtFileName.Text);

        txtFileName.Text = null;
    }

    private void Append(string item)
    {
        string finishedFile = Path.Combine(RootFolder, "finished.txt");
        if (File.Exists(finishedFile))
        {
            using (StreamWriter sw = File.AppendText(finishedFile))
            {
                sw.WriteLine(item);
            }
        }
        else
        {
            using (StreamWriter sw = File.CreateText(finishedFile))
            {
                sw.WriteLine(item);
            }
        }
    }

    private void btnRedo_Click(object sender, EventArgs e)
    {
        if (lstNamesFinished.SelectedItems.Count == 0) { return; }

        for (int x = lstNamesFinished.SelectedIndices.Count - 1; x >= 0; x--)
        {
            int idx = lstNamesFinished.SelectedIndices[x];
            lstNames.Items.Add(lstNamesFinished.Items[idx]);
            lstNamesFinished.Items.RemoveAt(idx);
        }

        // lstNamesFinished.ClearSelected();   

        Redo();
    }

    private void Redo()
    {
        string finishedFile = Path.Combine(RootFolder, "finished.txt");
        if (File.Exists(finishedFile))
        {
            File.Delete(finishedFile);
        }

        using (StreamWriter sw = File.CreateText(finishedFile))
        {
            for (int i = 0; i < lstNamesFinished.Items.Count; i++)
            {
                sw.WriteLine(lstNamesFinished.Items[i].ToString());
            }
        }
    }

    private void txtFileName_TextChanged(object sender, EventArgs e)
    {
        btnStart.Enabled = (txtFileName.Text.Length > 0);
    }

    private void lstNamesFinished_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (lstNamesFinished.SelectedIndex == -1) return;

        txtFileName.Text = string.Empty;        // 禁止完成标注的再次标注

        string xmlfile = lstNamesFinished.Text;

        if (!File.Exists(xmlfile))
        {
            MessageBox.Show($"文件 {xmlfile} 不存在。");
            //txtFileName.Text = string.Empty;
            //btnStart.Enabled = false;
        }
        else
        {
            lblFile.Text = xmlfile;

            LoadData(xmlfile);

            //btnStart.Enabled = true;
        }
    }

    private void LoadData(string xmlFile)
    {
        //ecgm = LoadXml(xmlFile);
        //if (ecgm != null)
        //{
        //    LoadListView();
        //}

        try
        {
            lvLabels.Items.Clear();

            ecgm = LoadXml(xmlFile);
            if (ecgm == null)
            {
                txtFileName.Text = string.Empty;
                return;
            }

            handler = new LabelHandler(ecgm.XmlFilePath, mySettings.LabelFileName);
            handler.Author = mySettings.UserName;

            Debug.WriteLine(handler.IsLoaded);

            if (handler.IsLoaded)
            {
                List<LabelInfo> labels = handler.LeadLabels;

                
                lvLabels.Font = new Font(lvLeads.Font, FontStyle.Bold);

                foreach (LabelInfo li in labels)
                {
                    ListViewItem row = new ListViewItem(li.LabelType);
                    row.Font = new Font(row.Font, FontStyle.Regular);

                    row.SubItems.Add(li.Lead);
                    row.SubItems.Add(li.StartX.ToString());
                    row.SubItems.Add(li.EndX.ToString());

                    lvLabels.Items.Add(row);
                }

                lvLabels.Columns[lvLabels.Columns.Count - 1].Width = -2;
            }


            LoadListView();
        }
        catch(Exception e)
        {
            MessageBox.Show(e.Message);
        }
    }

    private void LoadLabels()
    {

        try
        {
            lvLabels.Items.Clear();

            handler = new LabelHandler(ecgm.XmlFilePath, mySettings.LabelFileName);
            handler.Author = mySettings.UserName;

            Debug.WriteLine(handler.IsLoaded);

            if (handler.IsLoaded)
            {
                List<LabelInfo> labels = handler.LeadLabels;


                lvLabels.Font = new Font(lvLeads.Font, FontStyle.Bold);

                foreach (LabelInfo li in labels)
                {
                    ListViewItem row = new ListViewItem(li.LabelType);
                    row.Font = new Font(row.Font, FontStyle.Regular);

                    row.SubItems.Add(li.Lead);
                    row.SubItems.Add(li.StartX.ToString());
                    row.SubItems.Add(li.EndX.ToString());

                    lvLabels.Items.Add(row);
                }

                lvLabels.Columns[lvLabels.Columns.Count - 1].Width = -2;
            }
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }
    }

    private void btnCheckAll_Click(object sender, EventArgs e)
    {
        foreach(ListViewItem lvi in lvLeads.Items)
        {
            lvi.Checked = true;
        }
    }

    private void btnSetDefault_Click(object sender, EventArgs e)
    {
        foreach (ListViewItem lvi in lvLeads.Items)
        {
            string ik = lvi.Text.Trim();
            if (DefaultWorkLeads.Contains(ik))
            {
                lvi.Checked = true;
            }
            else
            {
                lvi.Checked = false;
            }
        }
    }

    private void btnShowECG_Click(object sender, EventArgs e)
    {
        string[] leads = new string[lvLeads.CheckedItems.Count];
        int i = 0;

        foreach (ListViewItem lvi in lvLeads.CheckedItems)
        {
            leads[i] = lvi.Text.Trim();
            i++;
        }

        frmECG frm = new frmECG();
        frm.ECG = ecgm;
        frm.SelectedLeads = leads;
        frm.ShowDialog();
        frm = null;
    }
}
