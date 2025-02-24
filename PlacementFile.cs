using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace KiCad_Panel_Assembly_Files_Generator
{
    internal class PlacementFile
    {
        public string CompPlacementFileDir;
        public PlacementPosition Side;
        public Dictionary<string, PlacementDataLine> PlacementData = new Dictionary<string, PlacementDataLine>();

        public PlacementFile(string compPlacementFileDir, PlacementPosition side)
        {
            CompPlacementFileDir = compPlacementFileDir;
            Side = side;
        }
    }

    internal class PlacementDataLine
    {
        string Reference { set; get; }
        string Value { set; get; }
        string Package { set; get; }
        PointF Position { set; get; }
        float Rotation { set; get; }
        public PlacementPosition Side { set; get; }

        public PlacementDataLine()
        {
            Reference = "";
            Value = "";
            Package = "";
            Position = new PointF(0, 0);
            Rotation = 0;
            Side = PlacementPosition.Undef;
        }

        public PlacementDataLine(string reference, string value, string package, PointF pos, float rot, PlacementPosition side)
        {
            Reference = reference;
            Value = value;
            Package = package;
            Position = pos;
            Rotation = rot;
            Side = side;
        }

        public PlacementDataLine(string reference, string value, string package, float posX, float posY, float rot, PlacementPosition side)
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
