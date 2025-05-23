using ECGXmlReader;
using System.Diagnostics;

namespace ECGPWaveLabelling;

public partial class frmMain : Form
{
    private ECGConfig mySettings;
    public ECGConfig AppConfig
    {
        set { mySettings = value; }
    }

    private ECGMapping _ecgm;

    private List<LabelInfo> _allWaves = [];
    private Dictionary<int, string> _leadTypes = new Dictionary<int, string>();
    private string _CurrFile = string.Empty;

    public frmMain()
    {
        InitializeComponent();
    }

    private void lstFiles_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (lstFiles.SelectedIndex == -1) return;

        string xmlfile = lstFiles.Text;

        if (!File.Exists(xmlfile))
        {
            MessageBox.Show($"文件 {xmlfile} 不存在");
            txtFile.Text = string.Empty;
        }
        else
        {
            txtFile.Text = xmlfile;
        }
    }

    private void btnBrowse_Click(object sender, EventArgs e)
    {
        OpenFileDialog dialog = new OpenFileDialog
        {
            Filter = "xml files (*.xml)|*.xml",
            InitialDirectory = mySettings.RootFolder,
            Title = "请选择文件",
            Multiselect = false
        };

        if (dialog.ShowDialog() == DialogResult.OK)
        {
            txtFile.Text = dialog.FileName;
        }
    }

    private ECGMapping LoadXml(string xmlFile, int lead)
    {
        try
        {
            this.Cursor = Cursors.WaitCursor;

            ECGMapping ecg = XMLParser.ReadXml(xmlFile);

            if (ecg != null)
            {
                ECGDataItem item = ecg.GetItem(ECGDataItem.LeadIndexNames[lead + 1]);     // II 导联
                if (item == null)
                {
                    throw new Exception($"文件 {xmlFile} 的数据有错误。");
                }

                List<LabelInfo> ls = item.GetLabels();
                if (ls != null)
                {
                    int leadIndex = lead + 1;
                    if (!_leadTypes.ContainsKey(leadIndex))
                    {
                        string leadName = ECGDataItem.LeadIndexNames[leadIndex];
                        _leadTypes.Add(leadIndex, ECGDataItem.LeadShortNames[leadName.ToUpper()]);
                    }

                    LoadPWaves(ls);
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
            MessageBox.Show(ex.Message, this.Text);
        }
        finally
        {
            this.Cursor = Cursors.Default;
        }

        return null;
    }

    private void LoadPWaves(List<LabelInfo> labels)
    {
        try
        {
            lvLabels.Items.Clear();
            lblPWaveCnt.Text = string.Empty;

            lvLabels.Font = new Font(lvLabels.Font, FontStyle.Bold);

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
            lblPWaveCnt.Text = $"P 波数量：{lvLabels.Items.Count}";

            _allWaves.AddRange(labels);

            _allWaves = (from LabelInfo li in _allWaves
                         orderby li.StartX
                         select li).ToList<LabelInfo>();

            LoadAllPWaves();
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }
    }

    private void frmMain_Load(object sender, EventArgs e)
    {
        foreach (string xmlFile in Program.Load(mySettings.RootFolder))
        {
            lstFiles.Items.Add(xmlFile);
        }

        if (lstFiles.Items.Count > 0) { lstFiles.SelectedIndex = 0; }
        comboLeads.SelectedIndex = 1;       // II is the default
    }

    private void btnPWave_Click(object sender, EventArgs e)
    {
        if(txtFile.Text != _CurrFile)
        {
            lvLabels.Items.Clear();
            lstAllPWaves.Items.Clear();
            _allWaves.Clear();
            _CurrFile = txtFile.Text;
        }

        _ecgm = LoadXml(txtFile.Text, comboLeads.SelectedIndex);
    }

    private void btnShowGraph_Click(object sender, EventArgs e)
    {
        if (_ecgm == null) return;

        string leadName = ECGDataItem.LeadIndexNames[comboLeads.SelectedIndex + 1];
        ECGDataItem item = _ecgm.GetItem(leadName);
        Bandpass.Show(item.digits, ECGDataItem.LeadShortNames[leadName.ToUpper()]);
        // MultiPass.Show(item.digits, ECGDataItem.LeadShortNames[leadName.ToUpper()]);
    }

    private void btnShowLeads_Click(object sender, EventArgs e)
    {
        if (_ecgm == null) return;

        foreach (KeyValuePair<int, string> kv in _leadTypes)
        {
            string leadName = ECGDataItem.LeadIndexNames[kv.Key];
            ECGDataItem item = _ecgm.GetItem(leadName);
            Bandpass.Show(item.digits, kv.Value);
        }
    }

    private void btnRemoveLead_Click(object sender, EventArgs e)
    {
        if (comboPLeads.SelectedIndex == -1) return;

        int leadIndex = (comboPLeads.SelectedItem as ComboboxItem).Value;
        _leadTypes.Remove(leadIndex);

        string ls = comboPLeads.Text.ToString();

        _allWaves = (from LabelInfo li in _allWaves
                     where li.Lead != ls
                     select li).ToList<LabelInfo>();

        LoadAllPWaves();
    }

    private void LoadAllPWaves()
    {
        lstAllPWaves.Items.Clear();

        lstAllPWaves.Font = new Font(lstAllPWaves.Font, FontStyle.Bold);

        foreach (LabelInfo li in _allWaves)
        {
            ListViewItem row = new ListViewItem(li.LabelType);
            row.Font = new Font(row.Font, FontStyle.Regular);

            row.SubItems.Add(li.Lead);
            row.SubItems.Add(li.StartX.ToString());
            row.SubItems.Add(li.EndX.ToString());

            lstAllPWaves.Items.Add(row);
        }

        lstAllPWaves.Columns[lstAllPWaves.Columns.Count - 1].Width = -2;

        comboPLeads.Text = string.Empty;
        comboPLeads.Items.Clear();
        foreach (KeyValuePair<int, string> kv in _leadTypes)
        {
            ComboboxItem item = new ComboboxItem();
            item.Text = kv.Value;
            item.Value = kv.Key;
            comboPLeads.Items.Add(item);
        }
    }
}

public class ComboboxItem
{
    public string Text { get; set; }
    public int Value { get; set; }

    public override string ToString()
    {
        return Text;
    }
}
