using Microsoft.FSharp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ECGXmlReader;

// 病人资料
//< id root = "2.16.840.1.113883.3.400" extension = "ZY050002450607" />
//< subjectDemographicPerson classCode = "PSN" >
//  < name > 孙浩奇 </ name >
//  < administrativeGenderCode code = "M" codeSystem = "2.16.840.1.113883.5.1" />
//  < birthTime value = "1992-11-13" />
//</ subjectDemographicPerson >
// 检查开始时间
//<effectiveTime>
//  <center value = "2024-04-15T11:02:12" />
//</ effectiveTime >
public class Patient
{
    /// <summary>
    /// 病人资料
    /// </summary>
    public static string PatientPath = "/ns:AnnotatedECG/ns:componentOf/ns:timepointEvent/ns:componentOf/ns:subjectAssignment/ns:subject/ns:trialSubject";

    /// <summary>
    /// 检查开始时间
    /// </summary>
    public static string EffectivePath = "/ns:AnnotatedECG/ns:componentOf/ns:timepointEvent/ns:effectiveTime/ns:center";

    public string Root { get; set; }
    public string Extension { get; set; }
    public string ClassCode { get; set; }
    public string Name { get; set; }
    public string Gender { get; set; }
    public string CodeSystem { get; set; }
    public DateOnly BirthDate { get; set; }
    public DateTime EffectiveTime { get; set; }

    public Patient(XmlNode? node, XmlNode? effectiveNode, XmlNamespaceManager ns)
    {
        if (node == null)
        {
            Root = "2.16.840.1.113883.3.400";
            Extension = "ZY050002450607";
            ClassCode = "PSN";
            Gender = "M";
            Name = "";
            CodeSystem = "2.16.840.1.113883.5.1";
            BirthDate = DateOnly.MinValue;
            EffectiveTime = DateTime.MinValue;

            return;
        }

        XmlNode n = node.SelectSingleNode("ns:id", ns);
        if (n != null)
        {
            Root = (n as XmlElement).HasAttribute("root") ?
                n.Attributes.GetNamedItem("root").Value.ToString() : "2.16.840.1.113883.3.400";

            Extension = (n as XmlElement).HasAttribute("extension") ?
                n.Attributes.GetNamedItem("extension").Value : "ZY050002450607";
        }
        else
        {
            Root = "2.16.840.1.113883.3.400";
            Extension = "ZY050002450607";
        }

        n = node.SelectSingleNode("ns:subjectDemographicPerson", ns);
        if (n != null)
        {
            ClassCode = (n as XmlElement).HasAttribute("classCode") ?
                n.Attributes.GetNamedItem("classCode").Value.ToString() : "PSN";

            Name = string.Empty;

            foreach(XmlNode inode in n.ChildNodes)
            {
                if (inode.Name == "name") Name = inode.InnerText.Trim();

                if (inode.Name == "administrativeGenderCode")
                {
                    Gender = (inode as XmlElement).HasAttribute("code") ?
                        inode.Attributes.GetNamedItem("code").Value.ToString() : "M";

                    CodeSystem = (inode as XmlElement).HasAttribute("codeSystem") ?
                        inode.Attributes.GetNamedItem("codeSystem").Value.ToString() : "2.16.840.1.113883.5.1";
                }

                if (inode.Name == "birthTime")
                {
                    string _value = (inode as XmlElement).HasAttribute("value") ?
                        inode.Attributes.GetNamedItem("value").Value.ToString() : string.Empty;

                    if (_value == string.Empty)
                    {
                        BirthDate = DateOnly.MinValue;
                    }
                    else
                    {
                        BirthDate = DateOnly.Parse(_value);
                    }
                }
            }

        }
        else
        {
            ClassCode = "PSN";
            Gender = "M";
            CodeSystem = "2.16.840.1.113883.5.1";
            BirthDate = DateOnly.MinValue;            
        }

        if (effectiveNode == null)
        {
            EffectiveTime = DateTime.MinValue;
        }
        else
        {
            string _value = (effectiveNode as XmlElement).HasAttribute("value") ?
                        effectiveNode.Attributes.GetNamedItem("value").Value.ToString() : string.Empty;

            if (_value == string.Empty)
            {
                EffectiveTime = DateTime.MinValue;
            }
            else
            {
                EffectiveTime = DateTime.Parse(_value);
            }
        }
    }
}
