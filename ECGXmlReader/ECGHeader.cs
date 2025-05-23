using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml;

namespace ECGXmlReader;

//<sequence classCode = "OBS" >
//   < code code="TIME_RELATIVE" codeSystem="2.16.840.1.113883.6.24" codeSystemName="MDC"/>
//   <value xsi:type="GLIST_PQ">
//      <head value = "0" unit="s"/>
//      <increment value = "2" unit="s"/>
//   </value>
//</sequence>
public class ECGHeader
{
    private string xsiType = "GLIST_PQ";
    //private string[] attributes = ["classCode", "code", "codeSystem", "codeSystemName",
    //                        "value","unit"];
    //private string[] nodenames = ["sequence", "code", "value", "head", "increment"];

    private string classCode = string.Empty;
    private string code = string.Empty;
    private string codeSystem = string.Empty;
    private string codeSystemName = string.Empty;
    private string head_value = string.Empty;
    private string head_unit = string.Empty;
    private string increment_value = string.Empty;
    private string increment_unit = string.Empty;

    public string ClassCode
    {
        get { return classCode; }
        set { classCode = value; }
    }

    public string XsiType
    {
        get { return xsiType; }
        set { xsiType = value; }
    }

    public string Code
    {
        get { return code; }
        set { code = value; }
    }

    public string CodeSystem
    {
        get { return codeSystem; }
        set { codeSystem = value; }
    }

    public string CodeSystemName
    {
        get { return codeSystemName; }
        set { codeSystem = value; }
    }

    public string HeadValue
    {
        get { return head_value; }
        set { head_value = value; }
    }

    public string HeadUnit
    {
        get { return head_unit; }
        set { head_unit = value; }
    }

    public string IncrementValue
    {
        get { return increment_value; }
        set { increment_value = value; }
    }

    public string IncrementUnit
    {
        get { return increment_unit; }
        set { increment_unit = value; }
    }

    public string Head { get { return $"{head_value}/{head_unit}"; } }
    //public string HeadUnit { get { return head_unit; } }

    public string Increment { get { return $"{increment_value}/{increment_unit}"; } }
    //public string IncrementUnit { get { return increment_unit; } }

    public string Header_Head_Increment { get { return $"{head_value}/{head_unit}|{increment_value}/{increment_unit}"; } }

    public string Log()
    {
        return $"{xsiType} {Head} {Increment}";
    }

    public ECGHeader(XmlNode node, XmlNamespaceManager ns)
    {
        classCode = (node.Attributes.Count == 0) ? string.Empty : node.Attributes.GetNamedItem("classCode").Value;

        XmlNode n = node.SelectSingleNode("ns:code", ns);
        if (n != null)
        {
            //XmlAttribute? attribute = (XmlAttribute?)n.Attributes.GetNamedItem("code1");
            //if (attribute != null) { 
            //    string code1 = attribute.Value.ToString();
            //}

            code = (n as XmlElement).HasAttribute("code") ?
                n.Attributes.GetNamedItem("code").Value.ToString() : string.Empty;

            codeSystem = (n as XmlElement).HasAttribute("codeSystem") ?
                n.Attributes.GetNamedItem("codeSystem").Value : string.Empty;

            codeSystemName = (n as XmlElement).HasAttribute("codeSystemName") ?
                n.Attributes.GetNamedItem("codeSystemName").Value : string.Empty;
        }

        n = node.SelectSingleNode("ns:value", ns);
        if (n != null && n.HasChildNodes)
        {
            xsiType = n.Attributes.GetNamedItem("xsi:type").Value.ToString();
            //if(xsiType != null && xsiType != XSI_TYPE)
            //{
            //    throw new Exception($"Invalid xsi:type {xsiType} expecting {XSI_TYPE}");
            //}

            XmlNode vn = n.SelectSingleNode("ns:head", ns);
            if (n != null && n.HasChildNodes)
            {
                head_value = (vn as XmlElement).HasAttribute("value") ?
                    vn.Attributes.GetNamedItem("value").Value.ToString() : string.Empty;

                head_unit = (vn as XmlElement).HasAttribute("unit") ?
                    vn.Attributes.GetNamedItem("unit").Value.ToString() : string.Empty;
            }

            vn = n.SelectSingleNode("ns:increment", ns);
            if (n != null && n.HasChildNodes)
            {
                increment_value = (vn as XmlElement).HasAttribute("value") ?
                    vn.Attributes.GetNamedItem("value").Value.ToString() : string.Empty;

                increment_unit = (vn as XmlElement).HasAttribute("unit") ?
                    vn.Attributes.GetNamedItem("unit").Value.ToString() : string.Empty;
            }
        }
    }

    // stored in sqlite:
    //{
    // "ClassCode":"OBS","XsiType":"GLIST_PQ","Code":"TIME_RELATIVE",
    // "CodeSystem":"2.16.840.1.113883.6.24","CodeSystemName":"MDC",
    // "HeadValue":"0","HeadUnit":"s",
    // "IncrementValue":"2","IncrementUnit":"s"
    //}
    public ECGHeader(ECGHeaderDTO dto)
    {
        classCode = dto.ClassCode;
        xsiType = dto.XsiType;
        code = dto.Code;
        codeSystem = dto.CodeSystem;
        codeSystemName = dto.CodeSystemName;
        head_value =   dto.HeadValue;
        head_unit = dto.HeadUnit;
        increment_value = dto.IncrementValue;
        increment_unit = dto.IncrementUnit;
    }
}

public class ECGHeaderDTO
{
    public string ClassCode { get; set; }
    public string XsiType { get; set; }
    public string Code { get; set; }
    public string CodeSystem { get; set; }
    public string CodeSystemName { get; set; }
    public string HeadValue { get; set; }
    public string HeadUnit { get; set; }
    public string IncrementValue { get; set; }
    public string IncrementUnit { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public ECGHeaderDTO() { }

    public ECGHeaderDTO(string classCode, string xsiType, string code, string codeSystem, string codeSystemName, string headValue, string headUnit, string incrementValue, string incrementUnit)
    {
        ClassCode = classCode;
        XsiType = xsiType;
        Code = code;
        CodeSystem = codeSystem;
        CodeSystemName = codeSystemName;
        HeadValue = headValue;
        HeadUnit = headUnit;
        IncrementValue = incrementValue;
        IncrementUnit = incrementUnit;
    }

    public ECGHeaderDTO(ECGHeader h)
    {
        ClassCode = h.ClassCode;
        XsiType = h.XsiType;
        Code = h.Code;
        CodeSystem = h.CodeSystem;
        CodeSystemName = h.CodeSystemName;
        HeadValue = h.HeadValue;
        HeadUnit = h.HeadUnit;
        IncrementValue = h.IncrementValue;
        IncrementUnit = h.IncrementUnit;
    }

    public string Serialize()
    {
        JsonSerializerOptions options = new()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
        };

        string json = JsonSerializer.Serialize<ECGHeaderDTO>(this, options);

        Debug.WriteLine(json);

        return json;
    }

    public static ECGHeaderDTO DeserializeFromFile(string filename)
    {
        string jsonString = File.ReadAllText(filename);
        ECGHeaderDTO dto = JsonSerializer.Deserialize<ECGHeaderDTO>(jsonString)!;

        Debug.WriteLine($"Code: {dto.Code}");
        Debug.WriteLine($"CodeSystem: {dto.CodeSystem}");
        Debug.WriteLine($"Scale: {dto.HeadValue}/{dto.HeadUnit}");

        return dto;
    }

    public static ECGHeaderDTO DeserializeFromText(string jsonText)
    {
        ECGHeaderDTO dto = JsonSerializer.Deserialize<ECGHeaderDTO>(jsonText)!;

        Debug.WriteLine($"Code: {dto.Code}");
        Debug.WriteLine($"CodeSystem: {dto.CodeSystem}");
        Debug.WriteLine($"Scale: {dto.HeadValue} / {dto.HeadUnit}");

        return dto;
    }
}