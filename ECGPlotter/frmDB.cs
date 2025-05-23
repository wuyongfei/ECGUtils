using ECGXmlReader;
using GraficDisplay;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ECGPlotter;

public partial class frmDB : Form
{
    public List<LabelShortForm> WorkList { get; set; }
    public List<LabelShortForm> FinishedList { get; set; }

    private ECGMapping? _ecgm;
    private ECGSettings _mySettings;
    private int _workId = 0;
    // private List<LabelInfo>? _labels;
    // private bool _isLoaded = false;
    private LabelHandler _handler;

    public frmDB()
    {
        InitializeComponent();

        _mySettings = Program.Configuration.GetSection("ECGSettings").Get<ECGSettings>();
    }

    private void btnRedo_Click(object sender, EventArgs e)
    {
        if (lstFinishedNames.SelectedItems.Count == 0) { return; }

        int finishedId = int.Parse(lstFinishedNames.SelectedItems[0].Tag.ToString());

        int idx = lstFinishedNames.SelectedIndices[0];
        lstFinishedNames.Items.RemoveAt(idx);

        Redo(finishedId);
    }

    private void btnStart_Click(object sender, EventArgs e)
    {
        LoadGraphic();
    }

    private void btnFinish_Click(object sender, EventArgs e)
    {
        if (_workId == 0) return;

        LabelShortForm? lsf = WorkList.Where(x => x.Id == _workId).FirstOrDefault();
        if (lsf == null) return;        // should be error

        // add it to FinishedList and also lstNames
        lsf.Status = (int)DBAccess.LabelState.FINISHED;

        FinishedList.Add(lsf);

        ListViewItem li = new ListViewItem(lsf.Fullpath);
        li.Tag = lsf.Id.ToString();
        lstFinishedNames.Items.Add(li);

        // remove from WorkList
        WorkList.RemoveAll(x => x.Id == _workId);
        // remove from list
        lstNames.Items.RemoveAt(lstNames.SelectedIndices[0]);

        // update database with labels
        string labelsJson = "NA";
        if (_handler.IsLoaded)
        {
            labelsJson = ECGMappingDTO.SerializeLabels(_handler.LeadLabels);
        }

        bool b = DBAccess.Update(_mySettings.DBName, _workId, _mySettings.UserName, labelsJson, (int)DBAccess.LabelState.FINISHED);
        if (!b)
        {
            MessageBox.Show($"无法更新数据库{_mySettings.DBName}：将记录 {_workId} 状态设置为 {nameof(DBAccess.LabelState.FINISHED)}");
        }
    }

    private void btnCheckAll_Click(object sender, EventArgs e)
    {
        foreach (ListViewItem lvi in lvLeads.Items)
        {
            lvi.Checked = true;
        }
    }

    private void btnSetDefault_Click(object sender, EventArgs e)
    {
        foreach (ListViewItem lvi in lvLeads.Items)
        {
            string ik = lvi.Text.Trim();
            if (_mySettings.DefaultWorkLeads.Contains(ik))
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
        frm.ECG = _ecgm;
        frm.SelectedLeads = leads;
        frm.ShowDialog();
        frm = null;
    }

    private void lstNames_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
    {

        if (e.IsSelected)
        {
            lstFinishedNames.SelectedItems.Clear();
            // if (lstNames.SelectedItems.Count == 0) return;

            txtFileName.Text = lstNames.SelectedItems[0].Text;
            lblFile.Text = lstNames.SelectedItems[0].Text;

            _workId = int.Parse(lstNames.SelectedItems[0].Tag.ToString());

            LoadData();
        }
    }

    private void lstFinishedNames_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
    {
        if (e.IsSelected)
        {
            lstNames.SelectedItems.Clear();

            // if (lstFinishedNames.SelectedItems.Count == 0) return;

            txtFileName.Text = string.Empty;        // 禁止完成标注的再次标注
            lblFile.Text = lstFinishedNames.SelectedItems[0].Text;

            _workId = int.Parse(lstFinishedNames.SelectedItems[0].Tag.ToString());

            LoadData();
        }
    }

    //private void lstNames_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    txtFileName.Text = string.Empty;

    //    if (lstNames.SelectedItems.Count == 0) return;

    //    txtFileName.Text = lstNames.SelectedItems[0].Text;
    //    lblFile.Text = lstNames.SelectedItems[0].Text;

    //    _workId = int.Parse(lstNames.SelectedItems[0].Tag.ToString());

    //    LoadData();
    //}

    //private void lstFinishedNames_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (lstFinishedNames.SelectedItems.Count == 0) return;

    //    txtFileName.Text = string.Empty;        // 禁止完成标注的再次标注
    //    lblFile.Text = lstFinishedNames.SelectedItems[0].Text;

    //    _workId = int.Parse(lstFinishedNames.SelectedItems[0].Tag.ToString());

    //    LoadData();
    //}

    private void lvLeads_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void txtFileName_TextChanged(object sender, EventArgs e)
    {
        btnStart.Enabled = (txtFileName.Text.Length > 0);
    }

    private void frmDB_Load(object sender, EventArgs e)
    {
        foreach (LabelShortForm lsf in WorkList)
        {
            ListViewItem item = new ListViewItem(lsf.Fullpath);
            item.Tag = lsf.Id.ToString();
            lstNames.Items.Add(item);
        }

        lstNames.Columns[0].Width = -2;

        if (lstNames.Items.Count > 0) { lstNames.Items[0].Selected = true; }

        foreach (LabelShortForm lsf in FinishedList)
        {
            ListViewItem item = new ListViewItem(lsf.Fullpath);
            item.Tag = lsf.Id.ToString();
            lstFinishedNames.Items.Add(item);
        }

        lstFinishedNames.Columns[0].Width = -2;
    }

    private ECGMapping LoadXml(string xmlFile)
    {
        try
        {
            this.Cursor = Cursors.WaitCursor;

            ECGMapping ecg = XMLParser.ReadXml(xmlFile);

            if (ecg != null)
            {
                if (ecg.Header != null)
                {
                    Debug.WriteLine("    HEADER: " + ecg.Header.Log());
                }

                foreach (ECGDataItem item in ecg.GetItems())
                {
                    Debug.WriteLine("    DATA: " + item.Log());
                }
            }
            else
            {
                Console.WriteLine($"读取文件 {xmlFile} 出错。");
            }

            this.Cursor = Cursors.Default;

            return ecg;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
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
        form.ECG = _ecgm;
        form.SelectedLead = lead;

        _handler.Lead = lead;
        form.Handler = _handler;

        form.ShowDialog();
        form.Close();
        form = null;

        // reload labels
        LoadLabels();
    }

    /// <summary>
    /// load brief info for all leads
    /// </summary>
    private void LoadLeadsInfo()
    {
        lvLeads.Items.Clear();

        lvLeads.Font = new Font(lvLeads.Font, FontStyle.Bold);

        foreach (ECGDataItem di in _ecgm.GetItems())
        {
            string itemKey = di.Code.Replace("MDC_ECG_LEAD_", "");

            bool isDefault = _mySettings.DefaultWorkLeads.Contains(itemKey);

            ListViewItem row = new ListViewItem(itemKey);
            row.Font = new Font(row.Font, FontStyle.Regular);
            row.Checked = isDefault;

            if (itemKey == _mySettings.DefaultWorkLeads[0])
            {
                row.Selected = true;
            }

            row.SubItems.Add(di.Origin);
            row.SubItems.Add(di.Scale);
            row.SubItems.Add(di.digits.Length.ToString());

            lvLeads.Items.Add(row);
        }

        lvLeads.Columns[lvLeads.Columns.Count - 1].Width = -2;

        lblHeader.Text = _ecgm.Header.Log();
    }

    private void Redo(int id)
    {
        LabelShortForm? lsf = FinishedList.Where(x => x.Id == id).FirstOrDefault();
        if (lsf == null) return;        // should be error

        // add it to WorkList and also lstNames
        lsf.Status = (int)DBAccess.LabelState.REDO;

        WorkList.Add(lsf);
        ListViewItem li = new ListViewItem(lsf.Fullpath);
        li.Tag = lsf.Id.ToString();
        lstNames.Items.Add(li);

        // remove from FinishedList
        FinishedList.RemoveAll(x => x.Id == id);

        // update database
        bool b = DBAccess.UpdateStatus(_mySettings.DBName, id, _mySettings.UserName, (int)DBAccess.LabelState.REDO);
        if (!b)
        {
            MessageBox.Show($"无法更新数据库{_mySettings.DBName}：将记录 {id} 状态设置为 {nameof(DBAccess.LabelState.REDO)}");
        }
    }

    private void LoadData()
    {
        try
        {
            lvLabels.Items.Clear();

            // Debug.WriteLine(_handler.IsLoaded);

            List<LabelInfo> ls;
            (_ecgm, ls) = DBAccess.GetRecord(_mySettings.DBName, _workId);
            if (_ecgm == null)
            {
                txtFileName.Text = string.Empty;
                return;
            }

            _handler = new LabelHandler(ls);
            _handler.Author = _mySettings.UserName;

            if (_handler.IsLoaded)
            {
                List<LabelInfo> labels = _handler.LeadLabels;

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


            LoadLeadsInfo();
        }
        catch (Exception e)
        {
            _workId = 0;
            MessageBox.Show(e.Message);
        }
    }

    /// <summary>
    /// return from Labelling
    /// </summary>
    private void LoadLabels()
    {
        try
        {
            lvLabels.Items.Clear();

            if (_handler.IsLoaded)
            {
                List<LabelInfo> labels = _handler.LeadLabels;

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


}
