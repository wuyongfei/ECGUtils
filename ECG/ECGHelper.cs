using ECGXmlReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECG;

public static class ECGHelper
{   

    public static List<LabelInfo>? LoadLabels(string fullPath, string labelFileName)
    {
        try
        {
            string labelFile = Path.Combine(fullPath, labelFileName);
            // if not labelled, ignore
            if (!File.Exists(labelFile))
            {
                throw new Exception($"标注文件 {labelFile} 不存在。");
            }
            ;

            LabelHandler? handler = new LabelHandler(fullPath, labelFileName);
            handler.Author = "SYSTEM";

            if (handler.IsLoaded)
            {
                List<LabelInfo> labels = handler.LeadLabels;
                handler = null;
                return labels;
            }
            else
            {
                handler = null;
                throw new Exception($"无法读取标注文件 {labelFile} 。");
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine($"{DateTime.Now:HH:ss} [LoadLabels] {ex.Message}");
            // Console.WriteLine($"[LoadLabels]{ex.StackTrace?.ToString()}");
        }

        return null;
    }
}
