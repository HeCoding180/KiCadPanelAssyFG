﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiCadPanelAssyFG
{
    public class PlacementInfo
    {
        public string Name;
        public string PlacementFileDir;

        public PlacementFile PlacementFileData;

        public PlacementInfo(string name, string placementFileDir)
        {
            Name = name;
            PlacementFileDir = placementFileDir;

            PlacementFileData = new PlacementFile();
        }

        public void parsePlacementFromFile()
        {
            PlacementFileData = PlacementFile.Parse(PlacementFileDir);
            return;
        }
    }

    public class DesignInfo
    {
        public string Name;
        public string BOMFileDir;
        public Dictionary<string, PlacementInfo> Placements;

        public BOMFile BOMFileData;

        public DesignInfo(string name, string bomFileDir)
        {
            Name = name;
            BOMFileDir = bomFileDir;

            Placements = new Dictionary<string, PlacementInfo>();

            BOMFileData = new BOMFile();
        }

        public DesignInfo(string name, string bomFileDir, PlacementInfo[] placementInfos)
        {
            Name = name;
            BOMFileDir = bomFileDir;

            Placements = new Dictionary<string, PlacementInfo>();
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
            BOMFileData = BOMFile.Parse(BOMFileDir);
        }
    }
}
