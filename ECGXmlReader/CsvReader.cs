using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;

namespace ECGXmlReader;

public class CsvReader
{
    private string _csv;
    private short[,] leads = new short[13, 5000];
    private string _error=string.Empty;

    public CsvReader(string csvFile)
    {
        _csv = csvFile;
        if (!File.Exists(_csv))
        {
            throw new FileNotFoundException($"{csvFile} does not exist");
        }
        else
        {
            bool b = Load();

            if (!b)
            {
                throw new Exception($"Error reading {_error} due to {_error}");
            }
        }
    }

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

    public short[] GetTS()
    {
        short[] result = new short[5000];

        int col = 0;

        for (int i = 0; i < result.Length; i++)
        {
            result[i] = leads[col, i];
        }

        return result;
    }

    public short[] GetLead(string LeadName)
    {
        short[] result = new short[5000];

        if (LeadColumns.ContainsKey(LeadName.ToUpper()))
        {
            int col = LeadColumns[LeadName.ToUpper()];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = leads[col, i];
            }
        }

        return result;
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

                    Debug.WriteLine(string.Join(",",fields));

                    if (fields != null && fields.Length == 13)
                    {
                        leads[0, row] = short.Parse(fields[0]);
                        leads[1, row] = short.Parse(fields[1]);
                        leads[2, row] = short.Parse(fields[2]);
                        leads[3, row] = short.Parse(fields[3]);
                        leads[4, row] = short.Parse(fields[4]);
                        leads[5, row] = short.Parse(fields[5]);
                        leads[6, row] = short.Parse(fields[6]);
                        leads[7, row] = short.Parse(fields[7]);
                        leads[8, row] = short.Parse(fields[8]);
                        leads[9, row] = short.Parse(fields[9]);
                        leads[10, row] = short.Parse(fields[10]);
                        leads[11, row] = short.Parse(fields[11]);
                        leads[12, row] = short.Parse(fields[12]);
                    }
                    row += 1;
                }
            }

            return true;
        }
        catch (Exception e) { 
            Debug.WriteLine(e.Message);
            _error=e.Message;
        }

        return false;
    }
}
