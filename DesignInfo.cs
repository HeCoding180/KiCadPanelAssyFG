using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiCad_Panel_Assembly_Files_Generator
{
    internal class PlacementInfo
    {
        public string Name;
        public string CompPlacementFileDir;
        public PlacementPosition Position;

        public PlacementInfo(string name, string compPlacementFileDir, PlacementPosition position)
        {
            Name = name;
            CompPlacementFileDir = compPlacementFileDir;
            Position = position;
        }
    }

    internal class DesignInfo
    {
        public string Name;
        public string BOMFileDir;
        public Dictionary<string, PlacementInfo> Placements = new Dictionary<string, PlacementInfo>();

        public DesignInfo(string name, string bomFileDir)
        {
            Name = name;
            BOMFileDir = bomFileDir;
        }

        public DesignInfo(string name, string bomFileDir, PlacementInfo[] placementInfos)
        {
            Name = name;
            BOMFileDir = bomFileDir;

            foreach (PlacementInfo placementInfo in placementInfos)
            {
                Placements.Add(placementInfo.Name, placementInfo);
            }
        }

        public void addPlacementInfo (PlacementInfo placementInfo)
        {
            Placements.Add(placementInfo.Name, placementInfo);
        }

        public void removePlacementInfo (string name)
        {
            Placements.Remove(name);
        }
    }
}
