using ECGXmlReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECG;

public static class ECGTest
{
    public static void TestLabel()
    {
        string labelfolder = @"D:\apps\ECG\ECGs\10";
        string labelfile = "labels.csv";
        string author = "Gavin";
        string lead = "aVR";

        LabelHandler handler = new LabelHandler(labelfolder, labelfile);
        handler.Author = author;
        handler.Lead = lead;

        // LabelInfo li = new LabelInfo("P0", lead, 10, 5, 20, -5, author);
        try
        {
            handler.Add("P0", 10, 5, 20, -5);
            handler.Add("P1", 50, 5, 70, -5);
            handler.Add("P2", 100, 5, 120, -5);
            handler.Add("P3", 150, 5, 170, -5);
            handler.Add("P0", 200, 5, 220, -5);
            handler.Add("P1", 250, 5, 270, -5);

            handler.Add("P2", 300, 5, 320, -5);
            handler.Add("P3", 171, 5, 190, -5);

            handler.Save();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public static void ReadXml(ECGConfig mySettings)
    {
        DirectoryInfo di = new DirectoryInfo(mySettings.RootFolder);
        DirectoryInfo[] ecgfolders = di.GetDirectories();

        foreach (DirectoryInfo dri in ecgfolders)
        {
            // Console.WriteLine(dri.FullName);

            string[] xmlfiles = Directory.GetFiles(dri.FullName, "*.xml");
            if (xmlfiles != null)
            {
                Console.WriteLine($"{DateTime.Now:HH:ss} Filename: {xmlfiles[0]}");

                ECGMapping ecg = XMLParser.ReadXml(xmlfiles[0]);

                if (ecg != null)
                {
                    if (ecg.Header != null)
                    {
                        Console.WriteLine($"{DateTime.Now:HH:ss}     HEADER: {ecg.Header.Log()}");
                    }

                    foreach (ECGDataItem item in ecg.GetItems())
                    {
                        Console.WriteLine($"{DateTime.Now:HH:ss}     DATA: {item.Log()}");
                    }

                    // TS_START = 0.0F, TS_STEP = 500F/6000F, SCALE = 10F
                    // TS_START = 1F, TS_STEP = 1F, SCALE = 10F
                    // ecg.Export2CSV(1F, 1F, 2.5F, 1001);

                    ecg.ExportLeads();
                    // ecg.Export2CSVHalf();
                    // ECGMappingDTO dto = new(ecg);
                    //string fullPath = ecg.XmlFilePath;

                    //string headerFile = Path.Combine(fullPath, "header.json");
                    ////File.WriteAllText(headerFile, dto.SerializeHeader());
                    //ECGHeaderDTO.DeserializeFromFile(headerFile);

                    //string leadsFile = Path.Combine(fullPath, "leads.json");
                    ////File.WriteAllText(leadsFile, dto.SerializeLeads());
                    //ECGMappingDTO.DeserializeLeadsFromFile(leadsFile);

                    //string allFile = Path.Combine(fullPath, "all.json");
                    ////File.WriteAllText(allFile, dto.Serialize());
                    //ECGMappingDTO.DeserializeFromFile(allFile);
                }
                else
                {
                    Console.WriteLine($"{DateTime.Now:HH:ss} Error reading xml file {xmlfiles[0]}");
                }

            }
        }
    }

    public static void TestTuple(ECGConfig mySettings)
    {
        DirectoryInfo di = new DirectoryInfo(mySettings.RootFolder);
        DirectoryInfo[] ecgfolders = di.GetDirectories();

        foreach (DirectoryInfo dri in ecgfolders)
        {
            // Console.WriteLine(dri.FullName);

            string[] xmlfiles = Directory.GetFiles(dri.FullName, "*.xml");
            string[] csvfiles = Directory.GetFiles(dri.FullName, mySettings.LabelFileName);

            if (xmlfiles != null)
            {
                Console.WriteLine($"{DateTime.Now:HH:ss} Filename: {xmlfiles[0]}");

                // ECGMapping ecg = XMLParser.ReadXml(xmlfiles[0]);
                ECGMapping ecg = XMLParser.ParseECG(xmlfiles[0]);

                if (ecg != null)
                {
                    if (ecg.Header != null)
                    {
                        Console.WriteLine($"{DateTime.Now:HH:ss}     HEADER: {ecg.Header.Log()}");
                    }

                    foreach (ECGDataItem item in ecg.GetItems())
                    {
                        Console.WriteLine($"{DateTime.Now:HH:ss}     DATA: {item.Log()}");
                    }

                    // TS_START = 0.0F, TS_STEP = 500F/6000F, SCALE = 10F
                    // TS_START = 1F, TS_STEP = 1F, SCALE = 10F
                    // ecg.Export2CSV(1F, 1F, 2.5F, 1001);

                    // ecg.ExportLeads();
                    // ecg.Export2CSVHalf();
                }
                else
                {
                    Console.WriteLine($"{DateTime.Now:HH:ss} Error reading xml file {xmlfiles[0]}");
                }

            }
        }
    }

}
