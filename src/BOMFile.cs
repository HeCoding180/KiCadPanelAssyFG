using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiCadPanelAssyFG
{
    public class BOMFile
    {
        public Dictionary<string, BOMDataLine> BOMData { set; get; }

        public BOMFile()
        {
            BOMData = new Dictionary<string, BOMDataLine>();
        }

        public BOMFile(BOMFile bomFile)
        {
            BOMData = new Dictionary<string, BOMDataLine>();

            foreach (string bomKey in bomFile.BOMData.Keys)
            {
                BOMData.Add(bomKey, new BOMDataLine(bomFile.BOMData[bomKey]));
            }
        }

        public void MergeFile(BOMFile BOM)
        {
            foreach (string bomDataKey in BOM.BOMData.Keys)
            {
                if (BOMData.ContainsKey(bomDataKey))
                {
                    BOMData[bomDataKey].References.AddRange(BOM.BOMData[bomDataKey].References);
                }
                else
                {
                    BOMData.Add(BOM.BOMData[bomDataKey].LCSC_PN, new BOMDataLine(BOM.BOMData[bomDataKey]));
                }
            }
        }

        public static BOMFile Parse(string fileDir)
        {
            return Parse(File.ReadLines(fileDir));
        }

        public static BOMFile Parse(string[] rawBomData)
        {
            return Parse(rawBomData.AsEnumerable());
        }

        public static BOMFile Parse(IEnumerable<string> rawBomData)
        {
            string[] headers = rawBomData.First().Split(";");

            if (headers.Length < 4)
            {
                throw new ArgumentDataException("BOM file does not contain required headers");
            }

            int ValueIndex = -1;
            int ReferencesIndex = -1;
            int FootprintIndex = -1;
            int PartNumberIndex = -1;

            for (int i = 0; i < headers.Length; i++)
            {
                if (headers[i].Contains("Value", StringComparison.OrdinalIgnoreCase))
                {
                    if (ValueIndex == -1)
                        ValueIndex = i;
                    else
                        throw new ArgumentDataException("BOM file contains multiple copies of the same header");
                }
                else if (headers[i].Contains("Reference", StringComparison.OrdinalIgnoreCase))
                {
                    if (ReferencesIndex == -1)
                        ReferencesIndex = i;
                    else
                        throw new ArgumentDataException("BOM file contains multiple copies of the same header");
                }
                else if (headers[i].Contains("Footprint", StringComparison.OrdinalIgnoreCase))
                {
                    if (FootprintIndex == -1)
                        FootprintIndex = i;
                    else
                        throw new ArgumentDataException("BOM file contains multiple copies of the same header");
                }
                else if (headers[i].Contains("LCSC Part Number", StringComparison.OrdinalIgnoreCase))
                {
                    if (PartNumberIndex == -1)
                        PartNumberIndex = i;
                    else
                        throw new ArgumentDataException("BOM file contains multiple copies of the same header");
                }
                else
                {
                    // Other headers are ignored
                }
            }

            if ((ValueIndex == -1) ||
                (ReferencesIndex == -1) ||
                (FootprintIndex == -1) ||
                (PartNumberIndex == -1))
            {
                throw new ArgumentDataException("BOM file does not contain required headers");
            }

            BOMFile outputBOM = new BOMFile();

            foreach (string rawBomLine in rawBomData.Skip(1))
            {
                string[] splitBomLine = rawBomLine.Split(";");

                string[] references = splitBomLine[ReferencesIndex].Split(",");

                for (int i = 0; i < references.Length; i++)
                {
                    references[i] = references[i].Trim();
                }

                outputBOM.BOMData.Add(splitBomLine[PartNumberIndex], new BOMDataLine(splitBomLine[ValueIndex], references, splitBomLine[FootprintIndex], splitBomLine[PartNumberIndex]));
            }

            return outputBOM;
        }
    }

    public class BOMDataLine
    {
        public string Value { set; get; }
        public List<string> References { set; get; }
        public string Footprint { set; get; }
        public string LCSC_PN { set; get; }

        public BOMDataLine(string[] references, string lcscPN)
        {
            Value = "";
            Footprint = "";
            LCSC_PN = lcscPN;

            References = new List<string>();
            References.AddRange(references);
        }

        public BOMDataLine(string value, string footprint, string lcscPN)
        {
            Value = value;
            Footprint = footprint;
            LCSC_PN = lcscPN;

            References = new List<string>();
        }

        public BOMDataLine(string value, string[] references, string footprint, string lcscPN)
        {
            Value = value;
            Footprint = footprint;
            LCSC_PN = lcscPN;

            References = new List<string>(references);
        }

        public BOMDataLine(BOMDataLine bomDataLine)
        {
            Value = bomDataLine.Value;
            Footprint = bomDataLine.Footprint;
            LCSC_PN = bomDataLine.LCSC_PN;

            References = new List<string>(bomDataLine.References);
        }
    }
}
