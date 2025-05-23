using ECGXmlReader;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using System.Runtime;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ECGPlotter;

// Known Color
// https://learn.microsoft.com/en-us/dotnet/api/system.drawing.knowncolor?view=net-9.0

internal static class Program
{
    public static IConfiguration Configuration;
    public static string PTitle = "心电图标注工具";
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        // ApplicationConfiguration.Initialize();
        var builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

        Configuration = builder.Build();
        Application.SetHighDpiMode(HighDpiMode.SystemAware);
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        var mySettings = Program.Configuration.GetSection("ECGSettings").Get<ECGSettings>();
        // check settings
        //Dictionary<string,string> di = mySettings.LabelTypes();
        //Debug.WriteLine(di.ContainsKey("P0"));

        if (mySettings != null)
        {
            if(mySettings.UseDB)
            {
                if (!File.Exists(mySettings.DBName))
                {
                    MessageBox.Show($"数据库【{mySettings.DBName}】不存在。请检查配置文件，修改之后再运行！", PTitle);
                    Application.Exit();
                }

                int[] status = [(int)DBAccess.LabelState.INIT, (int)DBAccess.LabelState.REDO, (int)DBAccess.LabelState.FINISHED];
                List<LabelShortForm> lsf = DBAccess.GetLabels(mySettings.DBName, status);
                if (lsf == null)
                {
                    MessageBox.Show($"无法从数据库【{mySettings.DBName}】加载数据。请联系运维人员！", PTitle);
                    Application.Exit();
                }

                if (lsf.Count == 0)
                {
                    MessageBox.Show($"数据库【{mySettings.DBName}】没有数据。请联系运维人员！", PTitle);
                    Application.Exit();
                }

                int s = (int)DBAccess.LabelState.FINISHED;
                //List<LabelShortForm> fl = (List<LabelShortForm>)(from f in lsf
                //                          where f.Status == s
                //                          select f);

                List<LabelShortForm> fl = lsf.Where(x => x.Status == s).ToList();

                if (fl == null)
                {
                    //MessageBox.Show($"数据库【{mySettings.DBName}】没有数据。请联系运维人员！");
                    //Application.Exit();
                    fl = new List<LabelShortForm>();
                }
                else
                {
                    Debug.WriteLine(fl.Count);
                }

                int[] ws = [(int)DBAccess.LabelState.INIT, (int)DBAccess.LabelState.REDO];

                //List<LabelShortForm> wl = (List<LabelShortForm>)(from w in lsf
                //                            where ws.Contains( w.Status)
                //                            select w);

                List<LabelShortForm> wl = lsf.Where(x => x.Status != s).ToList();
                if (wl == null)
                {
                    wl = new List<LabelShortForm>();
                }
                else
                {
                    Debug.WriteLine(wl.Count);
                    if (wl.Count == 0)
                    {
                        DialogResult dr = MessageBox.Show($"数据库【{mySettings.DBName}】所有记录都已标注。选择否（NO）退出，联系运维人员，选择是（YES）继续",
                                         PTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dr == DialogResult.No) Application.Exit();
                    }
                }


                frmDB frm = new frmDB();
                frm.WorkList = wl;
                frm.FinishedList = fl;

                Application.Run(frm);       // new frmListNames()
            }
            else
            {
                if (!Directory.Exists(mySettings.RootFolder))
                {
                    MessageBox.Show($"目录【{mySettings.RootFolder}】不存在。请检查配置文件，修改之后再运行！", PTitle);
                    Application.Exit();
                }

                frmListNames frm = new frmListNames();
                frm.RootFolder = mySettings.RootFolder;
                frm.DefaultWorkLeads = mySettings.DefaultWorkLeads;
                frm.FinishedList = LoadFinished(frm.RootFolder);

                List<string> list = Load(frm.RootFolder);
                frm.XmlFileList = list.Except(frm.FinishedList).ToList();

                Application.Run(frm);       // new frmListNames()
            }
        }
        else
        {
            MessageBox.Show("无效设置。请联系运维。", PTitle);
            Application.Exit();
        }


    }

    static List<string> LoadFinished(string path)
    {
        List<string> finished = new List<string>();

        string finishedFile = Path.Combine(path, "finished.txt");
        if (!File.Exists(finishedFile))
        {
            return finished;
        }

        string[] files = File.ReadAllLines(finishedFile);

        foreach (string file in files)
        {
            if (File.Exists(file))
            {
                finished.Add(file);
            }
        }

        return finished;
    }

    static List<string> Load(string path)
    {
        DirectoryInfo di = new DirectoryInfo(path);
        DirectoryInfo[] ecgfolders = di.GetDirectories();

        List<string> list = new List<string>();               

        foreach (DirectoryInfo dri in ecgfolders)
        {
            // Console.WriteLine(dri.FullName);

            string[] xmlfiles = Directory.GetFiles(dri.FullName, "*.xml");
            if (xmlfiles != null && (xmlfiles.Length > 0))
            {
                Debug.WriteLine($"START {DateTime.Now.ToString()}");
                Debug.WriteLine($"Filename: {xmlfiles[0]}");

                list.Add(xmlfiles[0]);
            }
            else
            {
                Debug.WriteLine($"No xml file in {dri.FullName}");
            }

        }

        return list;
    }
}