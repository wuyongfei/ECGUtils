using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ECGPlotter;

public class ECGSettings
{
    public string UserName { get; set; }
    public string RootFolder { get; set; }
    public string DBName { get; set; }
    public bool UseDB { get; set; }
    public string LabelFileName { get; set; }
    public Color BackColor { get; set; }
    public Size Size { get; set; }
    public string[] DefaultWorkLeads { get; set; } 
    public int DisplayRangeX { get; set; }          // = 2000;
    public int GridDistance { get; set; }           // = 50;
    public int Distance { get; set; }               // = 50;
    public string CurExample { get; set; }          // "STACKED",
    public string CurColorSchema { get; set; }      // "GRAY",
    public string[][] LabelNames { get; set; }
    public string[][] CurveColors { get; set; }
    public string[][] Annotations { get; set; }

    public Dictionary<string, string> LabelTypes()
    {
        Dictionary<string, string> di = new Dictionary<string, string>();

        for (int i = 0; i < LabelNames.Length; i++)
        {
            di.Add(LabelNames[i][0], LabelNames[i][1]);
        }

        return di;
    }

    public Dictionary<string, Color> LabelColors()
    {
        Dictionary<string, Color> di = new Dictionary<string, Color>();

        for (int i = 0; i < LabelNames.Length; i++)
        {
            di.Add(CurveColors[i][0], System.Drawing.Color.FromName(CurveColors[i][1]));
        }

        return di;
    }

    public Dictionary<string, string> AnnotationNames()
    {
        Dictionary<string, string> di = new Dictionary<string, string>();

        for (int i = 0; i < Annotations.Length; i++)
        {
            di.Add(Annotations[i][0], Annotations[i][1]);
        }

        return di;
    }

}

//public static class LabelSettings
//{
//    public static Dictionary<string, Color> LabelColors = new Dictionary<string, Color>()
//    {
//        {"P0", Color.Red },
//        {"P1", Color.Black },
//        {"P2", Color.Green },
//        {"P3", Color.Blue }
//    };

//    //public static Dictionary<string, string> LabelNames = new Dictionary<string, string>()
//    //{
//    //    {"P0", "正常P波" },
//    //    {"P1", "太高" },
//    //    {"P2", "太低" },
//    //    {"P3", "双波" }
//    //};

//    // "I", "II", "III", "aVR", "aVL", "aVF", "V1", "V2", "V3", "V4", "V5", "V6"
//    //public static string[] DefaultWorkLeads = ["II", "aVR", "V1"];

//    //public static int DisplayRangeX = 2000;
//    //public static int Distance = 50;
//}