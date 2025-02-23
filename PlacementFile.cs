﻿using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace KiCadPanelAssyFG
{
    internal class PlacementFile
    {
        public Dictionary<string, PlacementDataLine> PlacementData { set; get; }

        public PlacementFile()
        {
            PlacementData = new Dictionary<string, PlacementDataLine>();
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
            string[] headers = rawPlacementData.First().Split(";");

            if (headers.Length < 7)
            {
                throw new ArgumentDataException("BOM file does not contain required headers");
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
                        throw new ArgumentDataException("BOM file contains multiple copies of the same header");
                }
                else if (headers[i].Contains("Val", StringComparison.OrdinalIgnoreCase))
                {
                    if (ValueIndex == -1)
                        ValueIndex = i;
                    else
                        throw new ArgumentDataException("BOM file contains multiple copies of the same header");
                }
                else if (headers[i].Contains("Package", StringComparison.OrdinalIgnoreCase))
                {
                    if (FootprintIndex == -1)
                        FootprintIndex = i;
                    else
                        throw new ArgumentDataException("BOM file contains multiple copies of the same header");
                }
                else if (headers[i].Contains("PosX", StringComparison.OrdinalIgnoreCase))
                {
                    if (PosXIndex == -1)
                        PosXIndex = i;
                    else
                        throw new ArgumentDataException("BOM file contains multiple copies of the same header");
                }
                else if (headers[i].Contains("PosY", StringComparison.OrdinalIgnoreCase))
                {
                    if (PosYIndex == -1)
                        PosYIndex = i;
                    else
                        throw new ArgumentDataException("BOM file contains multiple copies of the same header");
                }
                else if (headers[i].Contains("Rot", StringComparison.OrdinalIgnoreCase))
                {
                    if (RotationIndex == -1)
                        RotationIndex = i;
                    else
                        throw new ArgumentDataException("BOM file contains multiple copies of the same header");
                }
                else if (headers[i].Contains("Side", StringComparison.OrdinalIgnoreCase))
                {
                    if (SideIndex == -1)
                        SideIndex = i;
                    else
                        throw new ArgumentDataException("BOM file contains multiple copies of the same header");
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
                throw new ArgumentDataException("BOM file does not contain required headers");
            }

            PlacementFile outputPlacements = new PlacementFile();

            foreach (string rawPlacementLine in rawPlacementData.Skip(1))
            {
                string[] splitPlacementLine = rawPlacementLine.Split(";");

                PointF placementPos = new PointF
                {
                    X = float.Parse(splitPlacementLine[PosXIndex]),
                    Y = float.Parse(splitPlacementLine[PosYIndex])
                };

                float placementRot = float.Parse(splitPlacementLine[RotationIndex]);

                PlacementSide placementSide = (splitPlacementLine[SideIndex].Contains("top", StringComparison.OrdinalIgnoreCase) ? (PlacementSide.Top) : (splitPlacementLine[SideIndex].Contains("bottom", StringComparison.OrdinalIgnoreCase) ? (PlacementSide.Bottom) : (PlacementSide.Undef)));

                outputPlacements.PlacementData.Add(splitPlacementLine[ReferencesIndex], new PlacementDataLine(splitPlacementLine[ReferencesIndex], splitPlacementLine[ValueIndex], splitPlacementLine[FootprintIndex], placementPos, placementRot, placementSide));
            }

            return outputPlacements;
        }
    }

    internal class PlacementDataLine
    {
        string Reference { set; get; }
        string Value { set; get; }
        string Package { set; get; }
        PointF Position { set; get; }
        float Rotation { set; get; }
        public PlacementSide Side { set; get; }

        public PlacementDataLine()
        {
            Reference = "";
            Value = "";
            Package = "";
            Position = new PointF(0, 0);
            Rotation = 0;
            Side = PlacementSide.Undef;
        }

        public PlacementDataLine(string reference, string value, string package, PointF pos, float rot, PlacementSide side)
        {
            Reference = reference;
            Value = value;
            Package = package;
            Position = pos;
            Rotation = rot;
            Side = side;
        }

        public PlacementDataLine(string reference, string value, string package, float posX, float posY, float rot, PlacementSide side)
        {
            Reference = reference;
            Value = value;
            Package = package;
            Position = new PointF(posX, posY);
            Rotation = rot;
            Side = side;
        }
    }
}
