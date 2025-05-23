using ECGXmlReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECG;

public class DBLoader
{
    private ECGConfig _cfg;
    public DBLoader(ECGConfig cfg)
    {
        _cfg = cfg;
    }

    public void AddXmlToDB()
    {
        DirectoryInfo di = new DirectoryInfo(_cfg.RootFolder);
        DirectoryInfo[] ecgfolders = di.GetDirectories();

        foreach (DirectoryInfo dri in ecgfolders)
        {
            string[] xmlfiles = Directory.GetFiles(dri.FullName, "*.xml");
            if (xmlfiles != null)
            {
                Console.WriteLine($"{DateTime.Now:HH:ss} [AddXmlToDB]: {xmlfiles[0]}");

                int id = DBAccess.CheckUnique(_cfg.ECGXmlToDBName, xmlfiles[0]);
                if (id != -1)
                {
                    // When duplicate, just skip to the next
                    Console.WriteLine($"{DateTime.Now:HH:ss} [AddXmlToDB]: DUPLICATED {id} - {dri.FullName}");
                    continue;
                }

                ECGMapping ecg = XMLParser.ReadXml(xmlfiles[0]);

                if (ecg != null)
                {
                    LabelDTO dto = new LabelDTO(0, ecg);
                    long newID = DBAccess.Insert(_cfg.ECGXmlToDBName, dto.Convert());
                    if (newID == -1)
                    {
                        Console.WriteLine($"{DateTime.Now:HH:ss} [AddXmlToDB]: 无法加入记录 {xmlfiles[0]}");
                    }
                    else
                    {
                        Console.WriteLine($"{DateTime.Now:HH:ss} [AddXmlToDB]: 成功添加记录{newID} - {xmlfiles[0]}");
                    }
                }
                else
                {
                    Console.WriteLine($"{DateTime.Now:HH:ss} [AddXmlToDB]: 读取文件：{xmlfiles[0]} 出错！");
                }
            }
        }
    }

    public void AddLeadsToDB()
    {
        DirectoryInfo di = new DirectoryInfo(_cfg.RootFolder);
        DirectoryInfo[] ecgfolders = di.GetDirectories();

        foreach (DirectoryInfo dri in ecgfolders)
        {
            List<LabelInfo> labels = ECGHelper.LoadLabels(dri.FullName, _cfg.LabelFileName);
            if (labels == null) continue;

            string[] xmlfiles = Directory.GetFiles(dri.FullName, "*.xml");
            if (xmlfiles != null)
            {
                Console.WriteLine($"{DateTime.Now:HH:ss} [AddLeadsToDB]: {xmlfiles[0]}");

                ECGMapping ecg = XMLParser.ReadXml(xmlfiles[0]);

                if (ecg != null)
                {
                    int id = DBAccess.CheckUnique(_cfg.DBName, dri.FullName);
                    if (id != -1)
                    {
                        LabelDTO dto = new LabelDTO(id, ecg, labels, labels[0].Author);
                        bool b = DBAccess.Update(_cfg.DBName, dto.Convert());
                        if (!b)
                        {
                            Console.WriteLine($"{DateTime.Now:HH:ss} [AddLeadsToDB]: 无法更新记录 {id} - {xmlfiles[0]}！");
                        }
                        else
                        {
                            Console.WriteLine($"{DateTime.Now:HH:ss} [AddLeadsToDB]: 成功更新记录 {id} - {xmlfiles[0]}！");
                        }
                    }
                    else
                    {
                        LabelDTO dto = new LabelDTO(0, ecg, labels, labels[0].Author);
                        long newID = DBAccess.Insert(_cfg.DBName, dto.Convert());
                        if (newID == -1)
                        {
                            Console.WriteLine($"{DateTime.Now:HH:ss} [AddLeadsToDB]: 无法加入记录 {xmlfiles[0]}！");
                        }
                        else
                        {
                            Console.WriteLine($"{DateTime.Now:HH:ss} [AddLeadsToDB]: 成功添加记录{newID} - {xmlfiles[0]}！");
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"{DateTime.Now:HH:ss} [AddLeadsToDB]: 读取文件：{xmlfiles[0]} 出错！");
                }

            }
        }
    }

    public bool CreateDB(string dbFile)
    {
        bool b = false;
        try
        {
            b = DBAccess.CreateDatabase(dbFile);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{DateTime.Now:HH:ss} [CreateDB]: 无法创建数据库{dbFile}。错误如下：");
            Console.WriteLine($"{DateTime.Now:HH:ss} [CreateDB]: {ex.Message}");
            Console.WriteLine($"{DateTime.Now:HH:ss} [CreateDB]: {ex.StackTrace?.ToString()}");
        }

        return b;
    }
}
