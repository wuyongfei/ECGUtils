using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ECGXmlReader;

public static class XMLParser
{
    public static XmlNodeList ParseXml(string xmlfile)
    {
        XmlDocument xd = new XmlDocument();
        xd.Load(xmlfile);

        XmlNamespaceManager nsmgr = new XmlNamespaceManager(xd.NameTable);
        nsmgr.AddNamespace("ns", xd.DocumentElement.NamespaceURI);

        string[] xpaths = [ "/ns:AnnotatedECG/ns:component/ns:series/ns:component/ns:sequenceSet/ns:component/ns:sequence",
                      "/ns:AnnotatedECG/ns:component/ns:series/ns:derivation/ns:derivedSeries/ns:component/ns:sequenceSet/ns:component/ns:sequence"];

        foreach (string xpath in xpaths)
        {
            XmlNodeList nodelist = xd.SelectNodes(xpath, nsmgr);
            if (nodelist.Count != 0) return nodelist;
        }

        return null;
    }

    public static ECGMapping? ReadXml(string xmlfile)
    {
        try
        {
            XmlDocument xd = new XmlDocument();
            xd.Load(xmlfile);

            XmlNamespaceManager nsmgr = new XmlNamespaceManager(xd.NameTable);
            nsmgr.AddNamespace("ns", xd.DocumentElement.NamespaceURI);

            string[] xpaths = [ "/ns:AnnotatedECG/ns:component/ns:series/ns:component/ns:sequenceSet/ns:component/ns:sequence",
                      "/ns:AnnotatedECG/ns:component/ns:series/ns:derivation/ns:derivedSeries/ns:component/ns:sequenceSet/ns:component/ns:sequence"];

            string Sequencepath = xpaths[0];
            XmlNodeList? sequences = xd.SelectNodes(Sequencepath, nsmgr);

            if (sequences is null)
            {
                return null;
            }

            if (sequences.Count == 0)
            {
                return null;
            }

            ECGMapping ecg = new ECGMapping(xmlfile);

            for (int i = 0; i < sequences.Count; i++)
            {
                XmlNode? sequence = sequences[i];
                // Debug.WriteLine(sequence.InnerText);

                if (i == 0)
                {
                    ECGHeader header = new ECGHeader(sequence, nsmgr);
                    ecg.Header = header;

                    Debug.WriteLine($"    HEADER: {header.Log()}");
                }
                else
                {
                    ECGDataItem dt = new ECGDataItem(sequence, nsmgr);
                    ecg.AddItem(dt);

                    Debug.WriteLine($"    DATA:[{dt.MinValue} : {dt.MaxValue}] - {dt.Log()}");
                }
            }


            XmlNodeList? Annotations = xd.SelectNodes(Annotation.AnnotationPath, nsmgr);
            if (Annotations is null)
            {
                return null;
            }

            if (Annotations.Count == 0)
            {
                return null;
            }

            Annotation anno = new(Annotations, nsmgr);
            if (anno == null)
            {
                // muse be error here
            }
            else
            {
                ecg.Annotation = anno;
            }

            // 病人资料
            XmlNode? patientNode = xd.SelectSingleNode(Patient.PatientPath, nsmgr);

            // 检查开始时间
            XmlNode? effectiveNode = xd.SelectSingleNode(Patient.EffectivePath, nsmgr);

            Patient p = new(patientNode, effectiveNode, nsmgr);
            ecg.Patient = p;
                        
            XmlNode? analysisNode = xd.SelectSingleNode(Analysis.AnalysisPath, nsmgr);

            if (analysisNode != null)
            {
                Analysis ana = new (analysisNode, nsmgr);

                ecg.Analysis = ana;
            }

            return ecg;

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.ToString());
            Debug.WriteLine(ex.StackTrace.ToString());
        }

        return null;
    }

    //public static AnnotatedECG DeserializeObject(string filename)
    //{
    //    Console.WriteLine($"Reading with Stream for {filename}");

    //    // Create an instance of the XmlSerializer.
    //    XmlSerializer serializer = new XmlSerializer(typeof(AnnotatedECG));

    //    // Declare an object variable of the type to be deserialized.
    //    AnnotatedECG i;

    //    using (Stream reader = new FileStream(filename, FileMode.Open))
    //    {
    //        // Call the Deserialize method to restore the object's state.
    //        i = (AnnotatedECG)serializer.Deserialize(reader);
    //    }

    //    if (i == null)
    //    {
    //        Console.WriteLine($"Can not parse {filename}");
    //        return null;
    //    }

    //    return i;
    //}

    public static ECGMapping ParseECG(string xmlfile)
    {
        try
        {
            XmlDocument xd = new XmlDocument();
            xd.Load(xmlfile);

            XmlNamespaceManager nsmgr = new XmlNamespaceManager(xd.NameTable);
            nsmgr.AddNamespace("ns", xd.DocumentElement.NamespaceURI);

            string[] xpaths = [ "/ns:AnnotatedECG/ns:component/ns:series/ns:component/ns:sequenceSet/ns:component/ns:sequence",
                      "/ns:AnnotatedECG/ns:component/ns:series/ns:derivation/ns:derivedSeries/ns:component/ns:sequenceSet/ns:component/ns:sequence"];

            string xpath = xpaths[0];

            XmlNodeList sequences = xd.SelectNodes(xpath, nsmgr);
            if (sequences is null)
            {
                return null;
            }

            if (sequences.Count != 0)
            {
                ECGMapping ecg = new ECGMapping(xmlfile);

                for (int i = 0; i < sequences.Count; i++)
                {
                    XmlNode sequence = sequences[i];
                    // Debug.WriteLine(sequence.InnerText);

                    if (i == 0)
                    {
                        ECGHeader header = new ECGHeader(sequence, nsmgr);
                        ecg.Header = header;

                        Debug.WriteLine($"    HEADER: {header.Log()}");
                    }
                    else
                    {
                        ECGDataItem dt = new ECGDataItem(sequence, nsmgr);
                        ecg.AddItem(dt);

                        Debug.WriteLine($"    DATA:[{dt.MinValue} : {dt.MaxValue}] -  {dt.Log()}");
                    }
                }

                return ecg;
            }
        }
        catch (Exception ex) {
            Debug.WriteLine(ex.ToString());
            Debug.WriteLine(ex.StackTrace.ToString());
        }

        return null;
    }
}