// See https://aka.ms/new-console-template for more information

using ECG;
using ECGXmlReader;
using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection.PortableExecutable;
using System.Runtime;
using System.Xml;
using System.Xml.Serialization;

bool loadingXml = false;
foreach (var arg in args)
{
    if(arg.ToUpper() == "XML")
    {
        loadingXml = true;
    }
}

try
{
    IConfigurationBuilder builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

    IConfiguration configuration = builder.Build();

    var mySettings = configuration.GetSection("ECGConfig").Get<ECGConfig>();
    // Console.WriteLine(mySettings.RootFolder);
    // Console.WriteLine(mySettings.LabelFileName);

    // ECGTest.ReadXml(mySettings);

    // run some other tests
    //(ECGMapping? ecgm, List<LabelInfo>? labels) = DBAccess.GetRecord(mySettings.ECGXmlToDBName, 10);
    //if (ecgm == null)
    //{
    //    Console.WriteLine("Error");
    //}
    //if (labels == null)
    //{
    //    Console.WriteLine("Error");
    //}

    //List<LabelShortForm> lsf = DBAccess.GetLabels(mySettings.ECGXmlToDBName, (int)DBAccess.LabelState.INIT);
    //Console.WriteLine(lsf.Count);

    //// int[] ints = [(int)DBAccess.LabelState.INIT, (int)DBAccess.LabelState.FINISHED];

    //lsf = DBAccess.GetLabels(mySettings.ECGXmlToDBName, [(int)DBAccess.LabelState.INIT, (int)DBAccess.LabelState.FINISHED]);
    //Console.WriteLine(lsf.Count);

    // Environment.Exit(0);

    //ECGTest.TestTuple(mySettings);
    //ECGTest.TestLabel();


    Console.WriteLine($"{DateTime.Now:HH:ss} START");

    DBLoader loader = new DBLoader(mySettings);

    if (loadingXml)
    {
        // check if database file exists. If not, create it
        if (!File.Exists(mySettings.ECGXmlToDBName))
        {
            if (!loader.CreateDB(mySettings.ECGXmlToDBName))
            {
                Console.WriteLine($"无法创建数据库 {mySettings.ECGXmlToDBName}。请联系运维人员。");
                Environment.Exit(1);
            }
        }
        loader.AddXmlToDB();
    }
    else
    {
        // check if database file exists. If not, create it
        if (!File.Exists(mySettings.DBName))
        {
            if (!loader.CreateDB(mySettings.DBName))
            {
                Console.WriteLine($"无法创建数据库 {mySettings.DBName}。请联系运维人员。");
                Environment.Exit(2);
            }
        }

        loader.AddLeadsToDB();
    }
}
catch(Exception ex)
{
    Console.WriteLine($"{DateTime.Now:HH:ss)} {ex.Message}");
    Console.WriteLine($"{DateTime.Now:HH:ss)} {ex.StackTrace}");
}

Console.WriteLine($"{DateTime.Now:HH:ss} END");
Console.WriteLine();

Console.ReadKey();

return 0;
