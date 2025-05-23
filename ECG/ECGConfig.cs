using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECG;

public class ECGConfig
{
    public string RootFolder { get; set; }
    public string LabelFileName { get; set; }
    public string DBName { get; set; }
    public string ECGXmlToDBName { get; set; }
}
