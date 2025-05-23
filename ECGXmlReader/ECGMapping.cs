using System.Diagnostics;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ECGXmlReader;

public class ECGMapping
{
    ECGHeader header;
    public ECGHeader Header
    {
        get { return header; }
        set { header = value; }
    }

    List<ECGDataItem> dataItems = new List<ECGDataItem>();

    List<Annotation> annos = new List<Annotation>();

    public List<ECGDataItem> GetItems() { return this.dataItems; }

    public ECGDataItem GetItem(string LeadType)
    {
        var item = dataItems.Where(di => di.Code == LeadType).First();

        return item;
    }

    public short[] GetItem(string LeadType, double scale)
    {
        var item = dataItems.Where(di => di.Code == LeadType).First();

        short[] digits = new short[5000];
        
        short max = (short)(item.digits.Max() * scale);
        short min = (short)(item.digits.Min() * scale);

        for (int i = 0; i < item.digits.Length; i++)
        {
            short ru = item.digits[i];
            if (ru < min)
            {
                ru = min;
            }
            if (ru > max)
            {
                ru = max;
            }

            digits[i] = ru;
        }

        return digits;
    }

    public Analysis Analysis;
    public Patient Patient;
    public Annotation Annotation;

    private string xmlFile = string.Empty;
    public string XmlFile { get { return xmlFile; } }

    private string xmlPath = string.Empty;
    public string XmlFilePath { get { return xmlPath; } }

    //DATA: MDC_ECG_LEAD_I MDC SLIST_PQ 0 uV 4.88 uV 4000
    //DATA: MDC_ECG_LEAD_II MDC SLIST_PQ 0 uV 4.88 uV 4000
    //DATA: MDC_ECG_LEAD_III MDC SLIST_PQ 0 uV 4.88 uV 4000
    //DATA: MDC_ECG_LEAD_aVR MDC SLIST_PQ 0 uV 4.88 uV 4000
    //DATA: MDC_ECG_LEAD_aVL MDC SLIST_PQ 0 uV 4.88 uV 4000
    //DATA: MDC_ECG_LEAD_aVF MDC SLIST_PQ 0 uV 4.88 uV 4000
    //DATA: MDC_ECG_LEAD_V1 MDC SLIST_PQ 0 uV 4.88 uV 4000
    //DATA: MDC_ECG_LEAD_V2 MDC SLIST_PQ 0 uV 4.88 uV 4000
    //DATA: MDC_ECG_LEAD_V3 MDC SLIST_PQ 0 uV 4.88 uV 4000
    //DATA: MDC_ECG_LEAD_V4 MDC SLIST_PQ 0 uV 4.88 uV 4000
    //DATA: MDC_ECG_LEAD_V5 MDC SLIST_PQ 0 uV 4.88 uV 4000
    //DATA: MDC_ECG_LEAD_V6 MDC SLIST_PQ 0 uV 4.88 uV 4000
    public Dictionary<string, int> LeadColumns = new Dictionary<string, int>() {
         {"MDC_ECG_LEAD_I", 1 },
         {"MDC_ECG_LEAD_II", 2 },
         {"MDC_ECG_LEAD_III", 3 },
         {"MDC_ECG_LEAD_AVR", 4 },
         {"MDC_ECG_LEAD_AVL", 5 },
         {"MDC_ECG_LEAD_AVF", 6 },
         {"MDC_ECG_LEAD_V1", 7 },
         {"MDC_ECG_LEAD_V2", 8 },
         {"MDC_ECG_LEAD_V3", 9 },
         {"MDC_ECG_LEAD_V4", 10 },
         {"MDC_ECG_LEAD_V5", 11 },
         {"MDC_ECG_LEAD_V6", 12 }
    };

    public void AddItem(ECGDataItem item)
    {
        dataItems.Add(item);
    }

    //      <code code = "MDC_ECG_HEART_RATE" codeSystem="2.16.840.1.113883.6.24" codeSystemName="MDC"/>
    //      <value xsi:type="PQ" value="98" unit="bpm"/>
    //      <code code = "MDC_ECG_TIME_PD_RR" codeSystem="2.16.840.1.113883.6.24" codeSystemName="MDC"/>
    //      <value xsi:type="PQ" value="612" unit="ms"/>
    //      <code code = "MDC_ECG_TIME_PD_PWD" codeSystem="2.16.840.1.113883.6.24" codeSystemName="MDC"/>
    //      <value xsi:type="PQ" value="124" unit="ms"/>
    //      <code code = "MDC_ECG_TIME_PD_PR" codeSystem="2.16.840.1.113883.6.24" codeSystemName="MDC"/>
    //      <value xsi:type="PQ" value="171" unit="ms"/>
    //      <code code = "MDC_ECG_ANGLE_QRS_FRONT" codeSystem="2.16.840.1.113883.6.24" codeSystemName="MDC"/>
    //      <value xsi:type="PQ" value="45" unit="deg"/>
    //      <code code = "MDC_ECG_TIME_PD_QRS" codeSystem="2.16.840.1.113883.6.24" codeSystemName="MDC"/>
    //      <value xsi:type="PQ" value="103" unit="ms"/>
    //      <code code = "MDC_ECG_TIME_PD_QT" codeSystem="2.16.840.1.113883.6.24" codeSystemName="MDC"/>
    //      <value xsi:type="PQ" value="336" unit="ms"/>
    //      <code code = "MDC_ECG_TIME_PD_QTc" codeSystem="2.16.840.1.113883.6.24" codeSystemName="MDC"/>
    //      <value xsi:type="PQ" value="429" unit="ms"/>
    //      <code code = "MDC_ECG_WAVE_R_S" codeSystem="2.16.840.1.113883.6.24" codeSystemName="MDC"/>
    //      <value xsi:type="PQ" value="1.81" unit="mv"/>
    //      <code code = "MDC_ECG_WAVE_SV1" codeSystem="2.16.840.1.113883.6.24" codeSystemName="MDC"/>
    //      <value xsi:type="PQ" value="0.49" unit="mv"/>
    //      <code code = "MDC_ECG_WAVE_RV5" codeSystem="2.16.840.1.113883.6.24" codeSystemName="MDC"/>
    //      <value xsi:type="PQ" value="1.32" unit="mv"/>
    //      <code code = "MDC_ECG_WAVE_RV6" codeSystem="2.16.840.1.113883.6.24" codeSystemName="MDC"/>
    //      <value xsi:type="PQ" value="1.34" unit="mv"/>

    public void AddAnnotation(Annotation item)
    {
        annos.Add(item);
    }

    /// <summary>
    /// 从XML文件加载ECG数据
    /// </summary>
    /// <param name="xmlFile"></param>
    public ECGMapping(string xmlFile)
    {
        this.xmlFile = xmlFile;
        FileInfo fi = new FileInfo(xmlFile);
        if (fi.Exists)
        {
            xmlPath = fi.DirectoryName;
        }
    }

    /// <summary>
    /// 从数据库记录加载ECG数据
    /// </summary>
    /// <param name="label"></param>
    public ECGMapping(LabelDTO label)
    {
        header = new(label.HeaderInfo);

        xmlFile = label.Fullpath;
        if (File.Exists(xmlFile))
        {
            FileInfo fi = new FileInfo(xmlFile);
            //xmlFile = Path.Combine(xmlPath, "1.xml");
            xmlPath = fi.DirectoryName;
        }
        else
        {
            // this means the file can not be tracked back
            // most likely the file has been moved to another folder.
            xmlPath = string.Empty;
        }

        // ECGDataItemDTO dto = label.LeadsInfo;

        for (int idx = 0; idx < 12; idx++)
        {
            ECGDataItem di = new(label.LeadsInfo, idx, label.Digits);
            dataItems.Add(di);
        }
    }

    public void Export2CSV(float TS_Start, float TS_Step, float Scale, int MaxOutput = 6000)
    {
        foreach (ECGDataItem item in dataItems)
        {
            string csvFile = Path.Combine(xmlPath, item.Code.Trim() + ".csv");

            bool b = item.Export2CSV(csvFile, TS_Start, TS_Step, Scale, MaxOutput);
            if (b)
            {
                Debug.WriteLine($"{csvFile} created");
            }
        }

    }

    public void Export2CSVHalf(int TS_Start = 1, int TS_Step = 1, float Scale = 1F, int MaxOutput = 6000)
    {
        foreach (ECGDataItem item in dataItems)
        {
            string csvFile = Path.Combine(xmlPath, item.Code.Trim() + "_Half.csv");

            bool b = item.Export2CSVHalf(csvFile, TS_Start, TS_Step, Scale, MaxOutput);
            if (b)
            {
                Debug.WriteLine($"{csvFile} created");
            }
        }
    }

    public void ExportLeads()
    {
        string csvFile = Path.Combine(xmlPath, "allleads.csv");

        short[,] rs = new short[13, 5000];
        for (short i = 0; i < rs.GetLength(1); i++)
        {
            rs[0, i] = (short)(i + 1);
        }

        foreach (ECGDataItem item in dataItems)
        {
            int column = LeadColumns[item.Code.Trim().ToUpper()];
            for (int i = 0; i < item.digits.Length; i++)
            {
                rs[column, i] = item.digits[i];
            }
        }

        StringBuilder sb = new StringBuilder();
        sb.Append("TS,I,If,II,IIf,III,IIIf,aVR,aVRf,aVL,aVLf,aVF,aVFf,");
        sb.Append("V1,V1f,V2,V2f,V3,V3f,V4,V4f,V5,V5f,V6,V6f\n");

        for (int r = 0; r < rs.GetLength(1); r++)
        {

            string s = $"{rs[0, r]},{rs[1, r]},1,{rs[2, r]},1,{rs[3, r]},1,{rs[4, r]},1,{rs[5, r]},1,{rs[6, r]},1,{rs[7, r]},1,{rs[8, r]},1,{rs[9, r]},1,{rs[10, r]},1,{rs[11, r]},1,{rs[12, r]},1\n";

            sb.Append(s);
        }

        File.WriteAllText(csvFile, sb.ToString());

        sb.Clear();
    }
}

public class ECGMappingDTO
{
    public ECGHeaderDTO Header { get; set; }
    public List<ECGDataItemDTO> Leads { get; set; }

    public ECGMappingDTO(ECGHeaderDTO header, List<ECGDataItemDTO> leads)
    {
        Header = header;
        Leads = leads;
    }

    public ECGMappingDTO(ECGMapping m)
    {
        Header = new ECGHeaderDTO(m.Header);

        List<ECGDataItemDTO> leads = new List<ECGDataItemDTO>();
        foreach(ECGDataItem di in m.GetItems())
        {
            ECGDataItemDTO lead = new ECGDataItemDTO(di);
            leads.Add(lead);
        }

        Leads = leads;
    }

    public string Serialize()
    {
        JsonSerializerOptions options = new()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
        };

        string json = JsonSerializer.Serialize<ECGMappingDTO>(this, options);

        Debug.WriteLine(json);

        return json;
    }

    public string SerializeHeader()
    {
        JsonSerializerOptions options = new()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
        };

        string json = JsonSerializer.Serialize<ECGHeaderDTO>(Header, options);

        Debug.WriteLine(json);

        return json;
    }

    public string SerializeLeads()
    {
        JsonSerializerOptions options = new()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
        };

        string json = JsonSerializer.Serialize<List<ECGDataItemDTO>>(Leads, options);

        Debug.WriteLine(json);

        return json;
    }

    #region 静态方法，用于序列化/反序列化

    /// <summary>
    /// 序列化HEADER
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public static string SerializeHeader(ECGHeaderDTO dto)
    {
        JsonSerializerOptions options = new()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
        };

        string json = JsonSerializer.Serialize<ECGHeaderDTO>(dto, options);

        Debug.WriteLine(json);

        return json;
    }

    /// <summary>
    /// 序列化单个LEAD。所有导联除DIGITS以外的数据是一样的，保存一个即可。
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public static string SerializeLead(ECGDataItemDTO dto)
    {
        JsonSerializerOptions options = new()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
        };

        string json = JsonSerializer.Serialize<ECGDataItemDTO>(dto, options);

        Debug.WriteLine(json);

        return json;
    }

    /// <summary>
    /// 序列化全部LEAD
    /// </summary>
    /// <param name="dtos"></param>
    /// <returns></returns>
    public static string SerializeLeads(List<ECGDataItemDTO> dtos)
    {
        JsonSerializerOptions options = new()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
        };

        string json = JsonSerializer.Serialize<List<ECGDataItemDTO>>(dtos, options);

        Debug.WriteLine(json);

        return json;
    }


    /// <summary>
    /// 序列化标注数据
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public static string SerializeLabels(List<LabelInfo> dto)
    {
        JsonSerializerOptions options = new()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
        };

        string json = JsonSerializer.Serialize<List<LabelInfo>>(dto, options);

        Debug.WriteLine(json);

        return json;
    }

    public static List<ECGDataItemDTO> DeserializeLeadsFromFile(string filename)
    {
        string jsonString = File.ReadAllText(filename);
        List<ECGDataItemDTO> dto = JsonSerializer.Deserialize<List<ECGDataItemDTO>>(jsonString)!;

        Debug.WriteLine($"Count: {dto.Count}");

        return dto;
    }

    public static List<ECGDataItemDTO> DeserializeLeadsFromText(string jsonText)
    {
        List<ECGDataItemDTO> dto = JsonSerializer.Deserialize<List<ECGDataItemDTO>>(jsonText)!;

        Debug.WriteLine($"Count: {dto.Count}");

        return dto;
    }

    public static ECGMappingDTO DeserializeFromFile(string filename)
    {
        string jsonString = File.ReadAllText(filename);
        ECGMappingDTO dto = JsonSerializer.Deserialize<ECGMappingDTO>(jsonString)!;

        Debug.WriteLine($"Code: {dto.Header.Code}");
        Debug.WriteLine($"Count: {dto.Leads.Count}");
        Debug.WriteLine($"CodeSystem: {dto.Header.CodeSystem}");
        Debug.WriteLine($"Scale: {dto.Header.HeadValue}/{dto.Header.HeadUnit}");

        return dto;
    }

    public static ECGMappingDTO DeserializeFromText(string jsonText)
    {
        ECGMappingDTO dto = JsonSerializer.Deserialize<ECGMappingDTO>(jsonText)!;

        Debug.WriteLine($"Code: {dto.Header.Code}");
        Debug.WriteLine($"Count: {dto.Leads.Count}");
        Debug.WriteLine($"CodeSystem: {dto.Header.CodeSystem}");
        Debug.WriteLine($"Scale: {dto.Header.HeadValue} / {dto.Header.HeadUnit}");

        return dto;
    }

    #endregion
}