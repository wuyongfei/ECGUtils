using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ECGXmlReader;

public class Annotation
{
    public static string AnnotationPath = "/ns:AnnotatedECG/ns:component/ns:series/ns:subjectOf/ns:annotationSet/ns:component/ns:annotation";

    public static Dictionary<string, string> AnnotationNamess = new Dictionary<string, string>() {
          {"MDC_ECG_HEART_RATE", "RATE"},
          {"MDC_ECG_TIME_PD_RR", "RR"},
          {"MDC_ECG_TIME_PD_PWD", "PWD"},
          {"MDC_ECG_TIME_PD_PR", "PR"},
          {"MDC_ECG_ANGLE_QRS_FRONT", "QRSF"},
          {"MDC_ECG_TIME_PD_QRS", "QTS"},
          {"MDC_ECG_TIME_PD_QT", "QT"},
          {"MDC_ECG_TIME_PD_QTc", "QTc"},
          {"MDC_ECG_WAVE_R_S", "R_S"},
          {"MDC_ECG_WAVE_SV1", "SV1"},
          {"MDC_ECG_WAVE_RV5", "RV5"},
          {"MDC_ECG_WAVE_RV6", "RV6"}
    };

    private short _hr2 = 0;                 // bpm
    public short HR2 { get { return _hr2; } }

    private int _rr2 = 0;                   // ms
    public int RR2 { get { return _rr2; } }

    private int _pwd2 = 0;                  // ms
    public int PWD2 { get { return _pwd2; } }

    private int _pr2 = 0;                   // ms
    public int PR2 { get { return _pr2; } }

    private int _qt2 = 0;                   // ms
    public int QT2 { get { return _qt2; } }

    private int _qtc2 = 0;                  // ms
    public int QTc2 { get { return _qtc2; } }

    private int _qrs2 = 0;                  // ms
    public int QRS2 { get { return _qrs2; } }

    private float _axi2 = 0;               // deg
    public float Axi2 { get { return _axi2; } }

    private float _rs2 = 0;                 // mv
    public float RS2 { get { return _rs2; } }

    private float _sv12 = 0;                // mv
    public float SV12 { get { return _sv12; } }

    private float _rv52 = 0;                // mv
    public float RV52 { get { return _rv52; } }

    private float _rv62 = 0;                // mv
    public float RV62 { get { return _rv62; } }

    public string HR { get; private set; }
    public string RR { get; private set; }
    public string PWD { get; private set; }
    public string QT { get; private set; }
    public string QTc { get; private set; }
    public string QRS { get; private set; }
    public string PR { get; private set; }
    public string Axi { get; private set; }
    public string RS { get; private set; }
    public string SV1 { get; private set; }
    public string RV5 { get; private set; }
    public string RV6 { get; private set; }

    public string QTOverQTc { get { return $"QT/QTc：{_qt2}/{_qtc2} ms(0-480/320-480)"; } }
    public string RV5OverSV1 { get { return $"RV5/SV1：{_rv52}/{_sv12} mV (0-2.5/0-2)"; } }
    public string RV5PlusSV1 { get { return $"RV5+SV1：{_rv52 + _sv12} mV (0 - 3.5)"; } }

    public Annotation(XmlNodeList annotations, XmlNamespaceManager ns)
    {
        List<AnnotationClass> annos = new List<AnnotationClass>();

        for (int i = 0; i < annotations.Count; i++)
        {
            XmlNode annotation = annotations[i];
            Debug.WriteLine(annotation.InnerText);

            AnnotationClass annoc = new AnnotationClass(annotation, ns);
            Debug.WriteLine($"    Annotation: {annoc.Log()}");
            annos.Add(annoc);
        }

        string anno = "MDC_ECG_HEART_RATE";
        var item = annos.Where(di => di.Code == anno).First();
        if (item != null)
        {
            HR = $"房率：{item.Value} {item.Unit}(60 - 100)";
            _hr2 = (item.Value == null) ? (short)0 : short.Parse(item.Value);
        }

        anno = "MDC_ECG_TIME_PD_RR";
        item = annos.Where(di => di.Code == anno).First();
        if (item != null)
        {
            RR = $"{item.Value} {item.Unit}(60 - 100)";
            _rr2 = (item.Value == null) ? 0 : int.Parse(item.Value);
        }

        anno = "MDC_ECG_TIME_PD_PWD";
        item = annos.Where(di => di.Code == anno).First();
        if (item != null)
        {
            PWD = $"P波时限：{item.Value} {item.Unit}(0 - 120)";
            _pwd2 = (item.Value == null) ? 0 : int.Parse(item.Value);
        }

        anno = "MDC_ECG_TIME_PD_PR";
        item = annos.Where(di => di.Code == anno).First();
        if (item != null)
        {
            PR = $"P-R间期：{item.Value} {item.Unit}(120 - 200)";
            _pr2 = (item.Value == null) ? 0 : int.Parse(item.Value);
        }

        anno = "MDC_ECG_ANGLE_QRS_FRONT";
        item = annos.Where(di => di.Code == anno).First();
        if (item != null)
        {
            Axi = $"QRS电轴：{item.Value} {item.Unit}(-30 - 90)";
            _axi2 = (item.Value == null) ? 0 : float.Parse(item.Value);
        }

        anno = "MDC_ECG_TIME_PD_QRS";
        item = annos.Where(di => di.Code == anno).First();
        if (item != null)
        {
            QRS = $"QRS波时限：{item.Value} {item.Unit}(0 - 120)";
            _qrs2 = (item.Value == null) ? 0 : int.Parse(item.Value);
        }

        anno = "MDC_ECG_TIME_PD_QT";
        item = annos.Where(di => di.Code == anno).First();
        if (item != null)
        {
            QT = $"{item.Value} {item.Unit}";
            _qt2 = (item.Value == null) ? 0 : int.Parse(item.Value);
        }

        anno = "MDC_ECG_TIME_PD_QTc";
        item = annos.Where(di => di.Code == anno).First();
        if (item != null)
        {
            QTc = $"{item.Value} {item.Unit}";
            _qtc2 = (item.Value == null) ? 0 : int.Parse(item.Value);
        }

        anno = "MDC_ECG_WAVE_R_S";
        item = annos.Where(di => di.Code == anno).First();
        if (item != null)
        {
            RS = $"{item.Value} {item.Unit}";
            _rs2 = (item.Value == null) ? 0 : float.Parse(item.Value);
        }

        anno = "MDC_ECG_WAVE_SV1";
        item = annos.Where(di => di.Code == anno).First();
        if (item != null)
        {
            SV1 = $"{item.Value} {item.Unit}";
            _sv12 = (item.Value == null) ? 0 : float.Parse(item.Value);
        }

        anno = "MDC_ECG_WAVE_RV5";
        item = annos.Where(di => di.Code == anno).First();
        if (item != null)
        {
            RV5 = $"{item.Value} {item.Unit}";
            _rv52 = (item.Value == null) ? 0 : float.Parse(item.Value);
        }

        anno = "MDC_ECG_WAVE_RV6";
        item = annos.Where(di => di.Code == anno).First();
        if (item != null)
        {
            RV6 = $"{item.Value} {item.Unit}";
            _rv62 = (item.Value == null) ? 0 : float.Parse(item.Value);
        }
    }

    internal class AnnotationClass
    {
        private string _code;
        private string _codeSystem;
        private string _codeSystemName;
        private string _type;
        private string _value;
        private string _unit;

        public string Code
        {
            get
            {
                return this._code;
            }
            set
            {
                this._code = value;
            }
        }

        public string CodeSystem
        {
            get
            {
                return this._codeSystem;
            }
            set
            {
                this._codeSystem = value;
            }
        }

        public string CodeSystemName
        {
            get
            {
                return this._codeSystemName;
            }
            set
            {
                this._codeSystemName = value;
            }
        }

        public string Type
        {
            get
            {
                return this._type;
            }
            set
            {
                this._type = value;
            }
        }

        public string Value
        {
            get
            {
                return this._value;
            }
            set
            {
                this._value = value;
            }
        }

        public string Unit
        {
            get
            {
                return this._unit;
            }
            set
            {
                this._unit = value;
            }
        }

        //<annotation>
        //    <code code = "MDC_ECG_TIME_PD_RR" codeSystem="2.16.840.1.113883.6.24" codeSystemName="MDC"/>
        //    <value xsi:type="PQ" value="612" unit="ms"/>
        //</annotation>
        public AnnotationClass(XmlNode node, XmlNamespaceManager ns)
        {
            XmlNode n = node.SelectSingleNode("ns:code", ns);
            if (n != null)
            {
                _code = (n as XmlElement).HasAttribute("code") ?
                    n.Attributes.GetNamedItem("code").Value.ToString() : string.Empty;

                _codeSystem = (n as XmlElement).HasAttribute("codeSystem") ?
                    n.Attributes.GetNamedItem("codeSystem").Value : string.Empty;

                _codeSystemName = (n as XmlElement).HasAttribute("codeSystemName") ?
                    n.Attributes.GetNamedItem("codeSystemName").Value : string.Empty;
            }

            n = node.SelectSingleNode("ns:value", ns);
            if (n != null)
            {
                _type = n.Attributes.GetNamedItem("xsi:type").Value.ToString();

                _value = (n as XmlElement).HasAttribute("value") ?
                    n.Attributes.GetNamedItem("value").Value.ToString() : string.Empty;

                _unit = (n as XmlElement).HasAttribute("unit") ?
                    n.Attributes.GetNamedItem("unit").Value.ToString() : string.Empty;
            }
        }

        public string Log()
        {
            return $"{_code}|{_codeSystem}|{_codeSystemName}+{_type} {_value}*{_unit}";
        }
    }
}
