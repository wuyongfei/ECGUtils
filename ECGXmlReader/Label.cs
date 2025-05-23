using ECGXmlReader;
using System.Diagnostics;
using System.Reflection.Emit;
using System.Reflection.PortableExecutable;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ECGXmlReader;

/// <summary>
/// This is the structure in sqlite
/// </summary>
public class Label
{
    /// <summary>
    /// PK, auto-incremental
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// full folder name of the xml file. Hopefully it can be unique so that
    /// every record in this db can be tracked back to its origin.
    /// </summary>
    public string Fullpath { get; set; }

    /// <summary>
    /// JSON string
    /// </summary>
    public string HeaderInfo { get; set; }
    /// <summary>
    /// For each lead:
    /// JSON string
    /// </summary>
    public string LeadsInfo { get; set; }

    /// <summary>
    /// For tracking purpose
    /// </summary>
    public string CreateUser { get; set; }
    public DateTime CreateDate { get; set; }
    public string UpdateUser { get; set; }
    public DateTime UpdateDate { get; set; }
    public int Status { get; set; }
    /// <summary>
    /// JSON string
    /// </summary>
    public string LabelList { get; set; }

    /// <summary>
    /// Data for all leads
    /// </summary>
    public byte[] Blob { get; set; }
}

/// <summary>
/// this is the structure used in code
/// </summary>
public class LabelDTO
{
    /// <summary>
    /// PK, auto-incremental
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// full folder name of the xml file. Hopefully it can be unique so that
    /// every record in this db can be tracked back to its origin.
    /// </summary>
    public string Fullpath { get; set; }

    /// <summary>
    /// JSON
    /// </summary>
    public ECGHeaderDTO? HeaderInfo { get; set; }

    /// <summary>
    /// For each lead:
    /// JSON, all leads except ECG data 
    /// </summary>
    // public List<ECGDataItemDTO> LeadsInfo { get; set; }
    public ECGDataItemDTO? LeadsInfo { get; set; }

    /// <summary>
    /// For tracking purpose
    /// </summary>
    public string CreateUser { get; set; }
    public DateTime CreateDate { get; set; }
    public string UpdateUser { get; set; }
    public DateTime UpdateDate { get; set; }
    public int Status { get; set; }
    /// <summary>
    /// JSON, all labels
    /// </summary>
    public List<LabelInfo>? LabelList { get; set; }

    /// <summary>
    /// Data for all leads
    /// </summary>
    public short[] Digits { get; set; }

    public LabelDTO()
    {
        Id = 0;
        Fullpath = string.Empty;
        CreateUser = "SYSTEM";
        UpdateUser = "SYSTEM";
        CreateDate = DateTime.Now;
        UpdateDate = DateTime.Now;
        Status = 0;
    }

    /// <summary>
    /// 使用心电图（XML）数据+标注 初始化LabelDTO
    /// 
    /// 用于将xml文件内容和标注写入sqlite数据库
    /// </summary>
    /// <param name="id">0=新记录</param>
    /// <param name="ecg">ECGMapping类</param>
    /// <param name="labelList">标注数据列表</param>
    /// <param name="user">标注人</param>
    public LabelDTO(int id, ECGMapping ecg, List<LabelInfo> labelList, string user, int status = 0)
    {
        Id = id;
        Fullpath = ecg.XmlFile;     //.XmlFilePath;
        HeaderInfo = new ECGHeaderDTO(ecg.Header);
        LeadsInfo = new ECGDataItemDTO(ecg.GetItem("MDC_ECG_LEAD_II"));         // new List<ECGDataItemDTO>();     
        CreateUser = user;
        CreateDate = DateTime.Now;
        UpdateUser = user;
        UpdateDate = DateTime.Now;
        LabelList = labelList;
        Status = status;

        List<short> d = [];

        foreach (ECGDataItem di in ecg.GetItems())
        {
            // LeadsInfo.Add(new ECGDataItemDTO(di));
            d.AddRange(di.digits);
        }

        Digits = d.ToArray();
        Debug.Assert(Digits.Length == 12 * 5000);
    }

    /// <summary>
    /// 使用心电图（XML）数据初始化LabelDTO。不包含标注数据
    /// 
    /// 这里主要用于直接将xml文件内容写入sqlite数据库
    /// </summary>
    /// <param name="id">0=新记录</param>
    /// <param name="ecg">ECGMapping类</param>
    public LabelDTO(int id, ECGMapping ecg, int status = 0)
    {
        Id = id;
        Fullpath = ecg.XmlFile;     //ecg.XmlFilePath;
        HeaderInfo = new ECGHeaderDTO(ecg.Header);
        LeadsInfo = new ECGDataItemDTO(ecg.GetItem("MDC_ECG_LEAD_II"));         // new List<ECGDataItemDTO>();     
        CreateUser = "SYSTEM";
        CreateDate = DateTime.Now;
        UpdateUser = "SYSTEM";
        UpdateDate = DateTime.Now;
        LabelList = null;
        Status = status;

        List<short> d = [];

        foreach (ECGDataItem di in ecg.GetItems())
        {
            // LeadsInfo.Add(new ECGDataItemDTO(di));
            if (di.Code == "MDC_ECG_LEAD_II")
            {
                LabelList = di.GetLabels();
            }
            d.AddRange(di.digits);
        }

        Digits = d.ToArray();
        Debug.Assert(Digits.Length == 12 * 5000);
    }

    public LabelDTO(int id, string fullpath, ECGHeaderDTO headerInfo, ECGDataItemDTO leadsInfo, string createUser, DateTime createDate, string updateUser, DateTime updateDate, List<LabelInfo> labelList, short[] digits, int status=0)
    {
        Id = id;
        Fullpath = fullpath;
        HeaderInfo = headerInfo;
        LeadsInfo = leadsInfo;
        CreateUser = createUser;
        CreateDate = createDate;
        UpdateUser = updateUser;
        UpdateDate = updateDate;
        LabelList = labelList;
        Digits = digits;
        Status = status;
    }

    /// <summary>
    /// 将数据库记录（Model-Label）转换为内部类（Class）
    /// </summary>
    /// <param name="label">数据库模型（model）</param>
    public LabelDTO(Label label)
    {
        Id = label.Id;
        Fullpath = label.Fullpath;

        HeaderInfo = ECGHeaderDTO.DeserializeFromText(label.HeaderInfo);

        LeadsInfo = ECGDataItemDTO.DeserializeFromText(label.LeadsInfo);       // ECGMappingDTO.DeserializeLeadsFromText(label.LeadsInfo);
        CreateUser = label.CreateUser;
        CreateDate = label.CreateDate;
        UpdateUser = label.UpdateUser;
        UpdateDate = label.UpdateDate;
        Status = label.Status;

        LabelList = (label.LabelList == "[]") ? null : LabelHandler.DeserializeFromText(label.LabelList);

        Digits = new short[label.Blob.Length / sizeof(short)];
        Buffer.BlockCopy(label.Blob, 0, Digits, 0, label.Blob.Length);

        Debug.WriteLine(Digits.Length);
    }

    /// <summary>
    /// 将LabelDTO转换为数据库Model-Label
    /// </summary>
    /// <returns></returns>
    public Label Convert()
    {
        Label label = new()
        {
            Id = Id,
            Fullpath = Fullpath,
            HeaderInfo = ECGMappingDTO.SerializeHeader(HeaderInfo),
            LeadsInfo = ECGMappingDTO.SerializeLead(LeadsInfo),        // SerializeLeads(LeadsInfo)
            CreateUser = CreateUser,
            CreateDate = CreateDate,
            UpdateUser = UpdateUser,
            UpdateDate = UpdateDate,
            Status = Status,
            LabelList = (LabelList is null) ? "NA" : ECGMappingDTO.SerializeLabels(LabelList),

            Blob = new byte[Digits.Length * sizeof(short)]
        };
        Buffer.BlockCopy(Digits, 0, label.Blob, 0, label.Blob.Length);

        return label;
    }
}


public class LabelShortForm
{
    /// <summary>
    /// PK, auto-incremental
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// full folder name of the xml file. Hopefully it can be unique so that
    /// every record in this db can be tracked back to its origin.
    /// </summary>
    public string Fullpath { get; set; }
    public int Status { get; set; }

    public LabelShortForm() { }

    public LabelShortForm(int id, string fullpath, int status)
    {
        Id = id;
        Fullpath = fullpath;
        Status = status;
    }
}