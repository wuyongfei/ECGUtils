using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;
using MathNet.Numerics.IntegralTransforms;
using MathNet.Numerics;
using System.Diagnostics;
using ECGXmlReader;
using System.Xml.Linq;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace ECGPWaveLabelling;

internal static class Program
{
    public static IConfiguration Configuration;

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        //ApplicationConfiguration.Initialize();
        //Application.Run(new Form1());
        var builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

        Configuration = builder.Build();
        Application.SetHighDpiMode(HighDpiMode.SystemAware);
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        var mySettings = Program.Configuration.GetSection("ECGConfig").Get<ECGConfig>();
        // check settings

        if (mySettings != null)
        {
            frmMain frm = new frmMain();
            frm.AppConfig = mySettings;
            Application.Run(frm);       
        }
        else
        {
            MessageBox.Show("无效设置。请联系运维。");
            Application.Exit();
        }
    }

    public static List<string> Load(string path)
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