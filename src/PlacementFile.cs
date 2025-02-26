using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace KiCadPanelAssyFG
{
    public class PlacementFile
    {
        public List<PlacementDataLine> PlacementData { set; get; }

        public PlacementFile()
        {
            PlacementData = new List<PlacementDataLine>(0);
        }

        public PlacementFile(PlacementFile placementFile)
        {
            PlacementData = new List<PlacementDataLine>(0);

            foreach (PlacementDataLine dataLine in placementFile.PlacementData)
            {
                PlacementData.Add(new PlacementDataLine(dataLine));
            }
        }

        public static PlacementFile Parse(string fileDir)
        {
            return Parse(File.ReadLines(fileDir));
        }

        public static PlacementFile Parse(string[] rawPlacementData)
        {
            return Parse(rawPlacementData.AsEnumerable());
        }

        public static PlacementFile Parse(IEnumerable<string> rawPlacementData)
        {
            char septChar = '\0';

            string headerRow = rawPlacementData.First();

            if (headerRow.Contains(';'))
            {
                septChar = ';';
            }
            else if (headerRow.Contains(','))
            {
                septChar = ',';
            }
            else
            {
                throw new ArgumentDataException("No valid separator character was found!");
            }

            string[] headers = headerRow.Split(septChar);

            if (headers.Length < 7)
            {
                throw new ArgumentDataException("Placement file does not contain required headers");
            }

            int ReferencesIndex = -1;
            int ValueIndex = -1;
            int FootprintIndex = -1;
            int PosXIndex = -1;
            int PosYIndex = -1;
            int RotationIndex = -1;
            int SideIndex = -1;

            for (int i = 0; i < headers.Length; i++)
            {
                if (headers[i].Contains("Ref", StringComparison.OrdinalIgnoreCase))
                {
                    if (ReferencesIndex == -1)
                        ReferencesIndex = i;
                    else
                        throw new ArgumentDataException("Placement file contains multiple copies of the same header");
                }
                else if (headers[i].Contains("Val", StringComparison.OrdinalIgnoreCase))
                {
                    if (ValueIndex == -1)
                        ValueIndex = i;
                    else
                        throw new ArgumentDataException("Placement file contains multiple copies of the same header");
                }
                else if (headers[i].Contains("Package", StringComparison.OrdinalIgnoreCase))
                {
                    if (FootprintIndex == -1)
                        FootprintIndex = i;
                    else
                        throw new ArgumentDataException("Placement file contains multiple copies of the same header");
                }
                else if (headers[i].Contains("PosX", StringComparison.OrdinalIgnoreCase))
                {
                    if (PosXIndex == -1)
                        PosXIndex = i;
                    else
                        throw new ArgumentDataException("Placement file contains multiple copies of the same header");
                }
                else if (headers[i].Contains("PosY", StringComparison.OrdinalIgnoreCase))
                {
                    if (PosYIndex == -1)
                        PosYIndex = i;
                    else
                        throw new ArgumentDataException("Placement file contains multiple copies of the same header");
                }
                else if (headers[i].Contains("Rot", StringComparison.OrdinalIgnoreCase))
                {
                    if (RotationIndex == -1)
                        RotationIndex = i;
                    else
                        throw new ArgumentDataException("Placement file contains multiple copies of the same header");
                }
                else if (headers[i].Contains("Side", StringComparison.OrdinalIgnoreCase))
                {
                    if (SideIndex == -1)
                        SideIndex = i;
                    else
                        throw new ArgumentDataException("Placement file contains multiple copies of the same header");
                }
                else
                {
                    // Other headers are ignored
                }
            }

            if ((ReferencesIndex == -1) ||
                (ValueIndex == -1) ||
                (FootprintIndex == -1) ||
                (PosXIndex == -1) ||
                (PosYIndex == -1) ||
                (RotationIndex == -1) ||
                (SideIndex == -1))
            {
                throw new ArgumentDataException("Placement file does not contain required headers");
            }

            PlacementFile outputPlacements = new PlacementFile();

            foreach (string rawPlacementLine in rawPlacementData.Skip(1))
            {
                string[] splitPlacementLine = rawPlacementLine.Replace("\"", "").Split(septChar);

                PointF placementPos = new PointF
                {
                    X = float.Parse(splitPlacementLine[PosXIndex]),
                    Y = float.Parse(splitPlacementLine[PosYIndex])
                };

                float placementRot = float.Parse(splitPlacementLine[RotationIndex]);

                PlacementSide placementSide = (splitPlacementLine[SideIndex].Contains("top", StringComparison.OrdinalIgnoreCase) ? (PlacementSide.Top) : (splitPlacementLine[SideIndex].Contains("bottom", StringComparison.OrdinalIgnoreCase) ? (PlacementSide.Bottom) : (PlacementSide.Undef)));

                outputPlacements.PlacementData.Add(new PlacementDataLine(splitPlacementLine[ReferencesIndex], splitPlacementLine[ValueIndex], splitPlacementLine[FootprintIndex], placementPos, placementRot, placementSide));
            }

            return outputPlacements;
        }
    }

    public class PlacementDataLine
    {
        public string Reference { set; get; }
        public string Value { set; get; }
        public string Footprint { set; get; }
        public PointF Position { set; get; }
        public float Rotation { set; get; }
        public PlacementSide Side { set; get; }

        public KiCadFootprintData FootprintData { set; get; }

        public PlacementDataLine()
        {
            Reference = "";
            Value = "";
            Footprint = "";
            Position = new PointF(0, 0);
            Rotation = 0;
            Side = PlacementSide.Undef;
        }

        public PlacementDataLine(string reference, string value, string footprint, PointF pos, float rot, PlacementSide side)
        {
            Reference = reference;
            Value = value;
            Footprint = footprint;
            Position = pos;
            Rotation = rot;
            Side = side;
        }

        public PlacementDataLine(string reference, string value, string footprint, float posX, float posY, float rot, PlacementSide side)
        {
            Reference = reference;
            Value = value;
            Footprint = footprint;
            Position = new PointF(posX, posY);
            Rotation = rot;
            Side = side;
        }

        public PlacementDataLine(PlacementDataLine dataLine)
        {
            Reference = dataLine.Reference;
            Value = dataLine.Value;
            Footprint = dataLine.Footprint;
            Position = new PointF(dataLine.Position.X, dataLine.Position.Y);
            Rotation = dataLine.Rotation;
            Side = dataLine.Side;
        }
    }
}
