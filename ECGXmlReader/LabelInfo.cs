using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ECGXmlReader;

public class LabelInfo
{
    public string LabelType { get; set; }
    public string Lead { get; set; }
    public int StartX { get; set; }
    public short StartY { get; set; }
    public int EndX { get; set; }
    public short EndY { get; set; }
    public string Author { get; set; }
    public DateTime CreateDate { get; set; }

    public string DataLine()
    {
        return $"{LabelType},{Lead},{StartX},{StartY},{EndX},{EndY},{Author},{CreateDate.ToString()}";
    }

    public LabelInfo() { }

    public LabelInfo(string[] elements)
    {
        LabelType = elements[0].Trim();
        Lead = elements[1].Trim();
        int x = int.Parse(elements[2].Trim());
        if (x < 1)
        {
            throw new Exception($"起点值（{elements[2]}）无效。取值范围[1, 4999]");
        }
        else
        {
            StartX = x;
        }

        StartY = short.Parse(elements[3].Trim());

        x = int.Parse(elements[4].Trim());
        if (x > 4999)
        {
            throw new Exception($"终点值（{elements[4]}）无效。取值范围[1, 4999]");
        }
        else
        {
            EndX = x;
        }

        if(StartX > EndX)
        {
            throw new Exception($"起点值（{elements[2]}）必须小于终点值（{elements[4]}）");
        }

        EndY = short.Parse(elements[5].Trim());
        Author = elements[6].Trim();
        CreateDate = DateTime.Parse(elements[7].Trim());
    }

    public LabelInfo(string labelType, string lead,
        int startX, short startY,
        int endX, short endY, string author)
    {
        if (startX >= endX)
        {
            throw new Exception($"起点值（{startX}）必须小于终点值（{endX}）");
        }

        if(startX<0)
        {
            throw new Exception($"起点值（{startX}）无效。取值范围[1, 4999]");
        }

        if(endX>4999)
        {
            throw new Exception($"终点值（{endX}）无效。取值范围[1, 4999]");
        }

        LabelType = labelType;
        Lead = lead;
        StartX = startX;
        StartY = startY;
        EndX = endX;
        EndY = endY;
        Author = author;
        CreateDate = DateTime.Now;
    }

    public bool IsOverlapping(LabelInfo li)
    {
        // both are less than current START_X
        if (li.StartX < StartX && li.EndX < StartX) return false;

        // both are greater than current END_X. Note, li.Endx check can be ignored
        if (li.StartX > EndX && li.EndX > EndX) return false;

        return true;
    }

    public string Serialize()
    {
        JsonSerializerOptions options = new()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
        };

        string json = JsonSerializer.Serialize<LabelInfo>(this, options);

        Debug.WriteLine(json);

        return json;
    }

    public LabelInfo DeserializeFromFile(string filename)
    {
        string jsonString = File.ReadAllText(filename);
        LabelInfo dto = JsonSerializer.Deserialize<LabelInfo>(jsonString)!;

        Debug.WriteLine($"Type: {dto.LabelType}");
        Debug.WriteLine($"Lead: {dto.Lead}");
        Debug.WriteLine($"Range: {dto.StartX}/{dto.EndX}");

        return dto;
    }

    public static LabelInfo DeserializeFromText(string jsonText)
    {
        LabelInfo dto = JsonSerializer.Deserialize<LabelInfo>(jsonText)!;

        Debug.WriteLine($"Type: {dto.LabelType}");
        Debug.WriteLine($"Lead: {dto.Lead}");
        Debug.WriteLine($"Range: {dto.StartX}/{dto.EndX}");

        return dto;
    }
}

public class LabelHandler
{
    private const string Title = "LabelType,Lead,StartX,StartY,EndX,EndY,Author,CreateDate";

    private List<LabelInfo> labels = new List<LabelInfo>();
    public List<LabelInfo> LeadLabels { get { return labels; } }

    private string _error = string.Empty;
    private string _csv = string.Empty;
    private bool _isLoaded = false;
    private bool _useDB = false;
    public string ErrorText { get { return _error; } }
    public bool IsLoaded { get { return _isLoaded; } }

    // public string LabelType { get; set; }
    public string Lead { get; set; }
    public string Author { get; set; } 

    public LabelHandler(List<LabelInfo> ls)
    {
        _useDB = true;

        if (ls == null)
        {
            _isLoaded = false;
            labels = new List<LabelInfo>();
        }
        else
        {
            _isLoaded = true;
            labels = new List<LabelInfo>(ls);
        }
    }

    public LabelHandler(string labelFolder, string labelFile)
    {
        _isLoaded = false;
        _useDB = false;

        if (!Directory.Exists(labelFolder))
        {
            throw new FileNotFoundException($"目录[{labelFolder}]不存在。");
        }
        else
        {
            _csv = Path.Combine(labelFolder, labelFile);

            if (!File.Exists(_csv)) return;     // not yet labelled

            bool b = Load();
            if (!b)
            {
                throw new Exception($"读文件[{_csv}]出错：{_error}");
            }

            _isLoaded = true;
        }
    }

    private bool Load()
    {
        try
        {         
            using (TextFieldParser csvParser = new TextFieldParser(_csv))
            {
                //csvParser.CommentTokens = new string[] { "#" };
                csvParser.SetDelimiters(new string[] { "," });
                csvParser.HasFieldsEnclosedInQuotes = false;

                // Skip the row with the column names
                csvParser.ReadLine();

                int row = 0;

                while (!csvParser.EndOfData)
                {
                    // Read current line fields, pointer moves to the next line.
                    string[] fields = csvParser.ReadFields();

                    Debug.WriteLine(string.Join(",", fields));

                    LabelInfo label = new LabelInfo(fields);

                    labels.Add(label);

                    row += 1;
                }
            }

            return true;
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
            _error = e.Message;
        }

        return false;
    }

    public bool IsOverlapping(int startX, int endX, int ignore = 0)
    {
        LabelInfo label = new LabelInfo("P0", Lead, startX, 0, endX, 0, Author);

        foreach (LabelInfo li in labels)
        {
            if (li.StartX == ignore) continue;

            if (li.IsOverlapping(label))
            {
                return true;
                //throw new Exception($"标注出现交叉：{li.LabelType}({li.StartX}, {li.EndX})<>{label.LabelType}({label.StartX}, {label.EndX})");
            }
        }

        return false;
    }

    private LabelInfo Add(LabelInfo label)
    {
        // check if overlapped
        foreach (LabelInfo li in labels)
        {
            if (li.IsOverlapping(label))
            {
                throw new Exception($"标注出现交叉：{li.LabelType}({li.StartX}, {li.EndX})<>{label.LabelType}({label.StartX}, {label.EndX})");
            }
        }

        labels.Add(label);

        // sort the list
        labels = labels.OrderBy(label => label.StartX).ToList();

        _isLoaded = (labels.Count > 0);

        return label;
    }

    public LabelInfo GetLabelInfo(int startX)
    {
        LabelInfo lbl = labels.Where(l => l.StartX == startX).FirstOrDefault();
        if (lbl != null)
        {
            return lbl;
        }

        return null;
    }

    public LabelInfo Add(string labelType, int startX, short startY, int endX, short endY)
    {
        LabelInfo label = new LabelInfo(labelType, Lead, startX, startY,
            endX, endY, Author);    
        
        return Add(label);
    }

    // startx/endx should be unique in the LIST.
    public bool Remove(LabelInfo label)
    {
        //LabelInfo lbl = labels.Where(l => l.StartX == label.StartX).FirstOrDefault();
        //if (lbl != null)
        //{
        //    labels.Remove(lbl);
        //    return lbl;
        //}

        //return null;
        try
        {
            Debug.WriteLine($"BEFORE REMOVE {labels.Count}");
            labels = labels.Where(x => x.StartX != label.StartX).ToList();
            Debug.WriteLine($"AFTER REMOVE {labels.Count}");

            if (labels.Count == 0)
            {
                if (File.Exists(_csv))
                {
                    File.Delete(_csv);
                }
            }

            _isLoaded = (labels.Count > 0);

            return true;
        }
        catch(Exception e)
        {
            Debug.WriteLine(e.Message);
            _error = e.Message;
        }

        return false;
    }

    public bool Remove(int startX)
    {
        try
        {
            Debug.WriteLine($"BEFORE REMOVE {labels.Count}");
            labels.RemoveAll(x => x.StartX == startX);
            Debug.WriteLine($"AFTER REMOVE {labels.Count}");

            //if (labels.Count == 0)
            //{
            //    if (File.Exists(_csv))
            //    {
            //        File.Delete(_csv);
            //    }
            //}

            _isLoaded = (labels.Count > 0);

            return true;
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
            _error = e.Message;
        }

        return false;
    }

    public bool RemoveAll()
    {
        try
        {
            Debug.WriteLine($"BEFORE REMOVE {labels.Count}");
            labels.Clear();
            Debug.WriteLine($"AFTER REMOVE {labels.Count}");

            //// remove csv
            //if (File.Exists(_csv))
            //{
            //    File.Delete(_csv);
            //}

            _isLoaded = false;
            return true;
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
            _error = e.Message;
        }

        return false;
    }

    public bool Save()
    {
        if (_useDB) return true;

        try
        {
            // remove the existing file first
            if (File.Exists(_csv))
            {
                File.Delete(_csv);
            }

            if (labels.Count == 0) return true;

            using (StreamWriter sw = File.CreateText(_csv))
            {
                sw.WriteLine(Title);

                foreach (LabelInfo label in labels)
                {
                    sw.WriteLine(label.DataLine());
                }
            }

            return true;
        }
        catch(Exception e)
        {
            Debug.WriteLine(e.Message);
            _error = e.Message;
        }

        return false;
    }

    public static bool SaveLabels(List<LabelInfo> ls, string csv)
    {
        try
        {
            // remove the existing file first
            if (File.Exists(csv))
            {
                File.Delete(csv);
            }

            if (ls.Count == 0) return true;

            using (StreamWriter sw = File.CreateText(csv))
            {
                sw.WriteLine(Title);

                foreach (LabelInfo label in ls)
                {
                    sw.WriteLine(label.DataLine());
                }
            }

            return true;
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
            throw;
        }

        return false;
    }

    public string Serialize()
    {
        JsonSerializerOptions options = new()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
        };

        string json = JsonSerializer.Serialize<List<LabelInfo>>(labels, options);

        Debug.WriteLine(json);

        return json;
    }

    public static List<LabelInfo> DeserializeFromFile(string filename)
    {
        string jsonString = File.ReadAllText(filename);
        List<LabelInfo> dto = JsonSerializer.Deserialize<List<LabelInfo>>(jsonString)!;

        Debug.WriteLine($"Count: {dto.Count}");

        return dto;
    }

    public static List<LabelInfo> DeserializeFromText(string jsonText)
    {
        List<LabelInfo> dto = JsonSerializer.Deserialize<List<LabelInfo>>(jsonText)!;

        Debug.WriteLine($"Count: {dto.Count}");

        return dto;
    }
}