using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiCadPanelAssyFG
{
    internal class PlacementInfo
    {
        public string Name;
        public string CompPlacementFileDir;
        public PlacementSide Side;

        public PlacementInfo(string name, string compPlacementFileDir, PlacementSide side)
        {
            Name = name;
            CompPlacementFileDir = compPlacementFileDir;
            Side = side;
        }
    }

    internal class DesignInfo
    {
        public string Name;
        public string BOMFileDir;
        public Dictionary<string, PlacementInfo> Placements = new Dictionary<string, PlacementInfo>();

        BOMFile BOMFileData;

        public DesignInfo(string name, string bomFileDir)
        {
            Name = name;
            BOMFileDir = bomFileDir;

            BOMFileData = new BOMFile();
        }

        public DesignInfo(string name, string bomFileDir, PlacementInfo[] placementInfos)
        {
            Name = name;
            BOMFileDir = bomFileDir;

            foreach (PlacementInfo placementInfo in placementInfos)
            {
                Placements.Add(placementInfo.Name, placementInfo);
            }

            BOMFileData = new BOMFile();
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
