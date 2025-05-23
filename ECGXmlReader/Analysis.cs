using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ECGXmlReader;

//<gread>正常范围的心电图</gread>
//<digcode>101:正常范围 </digcode>
//<miscode>1-0-0 </miscode>
public class Analysis
{
    public static string AnalysisPath = "/ns:AnnotatedECG/ns:component/ns:series/ns:analysis";  //ns:gread;

    public string Greed { get; set; } = "没有诊断结论";
    public string DigCode { get; set; } = string.Empty;
    public string MisCode { get; set; } = string.Empty;

    public Analysis(XmlNode node, XmlNamespaceManager ns)
    {
        foreach (XmlNode n in node.ChildNodes)
        {
            if (n.Name == "gread")
            {
                Greed = n.InnerText;
            }
            if (n.Name == "digcode")
            {
                DigCode = n.InnerText;
            }
            if (n.Name == "miscode")
            {
                MisCode = n.InnerText;
            }
        }
    }
}
