using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiCad_Panel_Assembly_Files_Generator
{
    internal class BOMFile
    {
        public Dictionary<string, BOMDataLine> BOMData { set; get; }

        public BOMFile()
        {
            BOMData = new Dictionary<string, BOMDataLine>();
        }

        public static BOMFile TryParse(string fileDir)
        {
            return TryParse(File.ReadLines(fileDir));
        }

        public static BOMFile TryParse(string[] rawBomData)
        {
            return TryParse(rawBomData.AsEnumerable());
        }

        public static BOMFile TryParse(IEnumerable<string> rawBomData)
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

    internal class BOMDataLine
    {
        string Value { set; get; }
        string[] Designators { set; get; }
        string Footprint { set; get; }
        string LCSC_PN { set; get; }

        public BOMDataLine(string[] designators, string lCSC_PN)
        {
            LCSC_PN = lCSC_PN;

            Designators = new string[designators.Length];
            Array.Copy(designators, Designators, designators.Length);

            Value = "";
            Footprint = "";
        }

        public BOMDataLine(string value, string[] designators, string footprint, string lCSC_PN)
        {
            Value = value;
            Footprint = footprint;
            LCSC_PN = lCSC_PN;

            Designators = new string[designators.Length];
            Array.Copy(designators, Designators, designators.Length);
        }
    }
}
