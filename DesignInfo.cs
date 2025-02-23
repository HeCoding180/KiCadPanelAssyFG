﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiCadPanelAssyFG
{
    internal class PlacementInfo
    {
        public string Name;
        public string PlacementFileDir;
        public PlacementSide Side;

        public PlacementFile PlacementFileData;

        public PlacementInfo(string name, string placementFileDir, PlacementSide side)
        {
            Name = name;
            PlacementFileDir = placementFileDir;
            Side = side;

            PlacementFileData = new PlacementFile();
        }

        public void parsePlacementFromFile()
        {
            this.PlacementFileData = PlacementFile.Parse(PlacementFileDir);
        }
    }

    internal class DesignInfo
    {
        public string Name;
        public string BOMFileDir;
        public Dictionary<string, PlacementInfo> Placements = new Dictionary<string, PlacementInfo>();

        public BOMFile BOMFileData;

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

        public void parseBomFromFile()
        {
            this.BOMFileData = BOMFile.Parse(BOMFileDir);
        }
    }
}
