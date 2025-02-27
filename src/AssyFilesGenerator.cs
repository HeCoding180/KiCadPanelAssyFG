using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace KiCadPanelAssyFG.src
{
    public class AssyFilesGenerator
    {
        public char CSVSeparator { set; get; }

        public AssyFilesGenerator()
        {
            CSVSeparator = ';';
        }

        public AssyFilesGenerator(char separator)
        {
            CSVSeparator = separator;
        }

        public void ExportToFile(string Name, string Directory, BOMFile data)
        {
            string combinedFilePath = Path.Combine(Directory, Name);

            // Check if file already exists and if so ask the user whether to replace it or not
            if (File.Exists(combinedFilePath))
            {
                if (MessageBox.Show("The file \"" + Name + "\" already exists. Do you want to replace it?", "File Exists", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No) return;
            }

            using (StreamWriter writer = new StreamWriter(combinedFilePath))
            {
                // Write csv header to file
                writer.WriteLine("Comment" + CSVSeparator + "Designator" + CSVSeparator + "Footprint" + CSVSeparator + "LCSC part number");

                foreach (string bomDataKey in data.BOMData.Keys)
                {
                    BOMDataLine dataLine = data.BOMData[bomDataKey];

                    string References = "";
                    for (int i = 0; i < dataLine.References.Count; i++)
                    {
                        if (i > 0) References += ",";
                        References += dataLine.References[i];
                    }

                    writer.WriteLine(dataLine.Value + CSVSeparator
                        + References + CSVSeparator
                        + dataLine.Footprint + CSVSeparator
                        + dataLine.LCSC_PN);
                }
            }
        }
        public void ExportToFile(string Name, string Directory, PlacementFile data)
        {
            string combinedFilePath = Path.Combine(Directory, Name);

            // Check if all placements contain a valid side
            foreach (PlacementDataLine dataLine in data.PlacementData)
            {
                if (dataLine.Side == PlacementSide.Undef) throw new IncompleteDataException("Placement data contains part with undefined placement side");
            }

            // Check if file already exists and if so ask the user whether to replace it or not
            if (File.Exists(combinedFilePath))
            {
                if (MessageBox.Show("The file \"" + Name + "\" already exists. Do you want to replace it?", "File Exists", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No) return;
            }

            using (StreamWriter writer = new StreamWriter(combinedFilePath))
            {
                // Write csv header to file
                writer.WriteLine("Designator" + CSVSeparator + "Val" + CSVSeparator + "Package" + CSVSeparator + "Mid X" + CSVSeparator + "Mid Y" + CSVSeparator + "Rotation" + CSVSeparator + "Layer");

                foreach (PlacementDataLine dataLine in data.PlacementData)
                {
                    writer.WriteLine(dataLine.Reference + CSVSeparator
                        + dataLine.Value + CSVSeparator
                        + dataLine.Footprint + CSVSeparator
                        + dataLine.Position.X.ToString() + CSVSeparator
                        + dataLine.Position.Y.ToString() + CSVSeparator
                        + dataLine.Rotation + CSVSeparator
                        + ((dataLine.Side == PlacementSide.Top) ? "top" : "bottom"));
                }
            }
        }
        public void ExportToFile(string Name, string Directory, PlacementFile data, PlacementSide sideFilter)
        {
            string combinedFilePath = Path.Combine(Directory, Name);

            // Check if all placements contain a valid side
            foreach (PlacementDataLine dataLine in data.PlacementData)
            {
                if (dataLine.Side == PlacementSide.Undef) throw new IncompleteDataException("Placement data contains part with undefined placement side");
            }

            // Check if file already exists and if so ask the user whether to replace it or not
            if (File.Exists(combinedFilePath))
            {
                if (MessageBox.Show("The file \"" + Name + "\" already exists. Do you want to replace it?", "File Exists", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No) return;
            }

            using (StreamWriter writer = new StreamWriter(combinedFilePath))
            {
                // Write csv header to filee
                writer.WriteLine("Designator" + CSVSeparator + "Val" + CSVSeparator + "Package" + CSVSeparator + "Mid X" + CSVSeparator + "Mid Y" + CSVSeparator + "Rotation" + CSVSeparator + "Layer");

                foreach (PlacementDataLine dataLine in data.PlacementData)
                {
                    // Ignore placements that do not match the side filter
                    if (dataLine.Side != sideFilter) continue;

                    writer.WriteLine(dataLine.Reference + CSVSeparator
                        + dataLine.Value + CSVSeparator
                        + dataLine.Footprint + CSVSeparator
                        + dataLine.Position.X.ToString() + CSVSeparator
                        + dataLine.Position.Y.ToString() + CSVSeparator
                        + dataLine.Rotation + CSVSeparator
                        + ((dataLine.Side == PlacementSide.Top) ? "top" : "bottom"));
                }
            }
        }

        public string GetCSVString(BOMFile data)
        {
            string OutputString = "Comment" + CSVSeparator + "Designator" + CSVSeparator + "Footprint" + CSVSeparator + "LCSC part number";

            foreach (string bomDataKey in data.BOMData.Keys)
            {
                BOMDataLine dataLine = data.BOMData[bomDataKey];

                string References = "";
                for (int i = 0; i < dataLine.References.Count; i++)
                {
                    if (i > 0) References += ",";
                    References += dataLine.References[i];
                }

                OutputString += Environment.NewLine
                    + dataLine.Value + CSVSeparator
                    + References + CSVSeparator
                    + dataLine.Footprint+ CSVSeparator
                    + dataLine.LCSC_PN;
            }

            return OutputString;
        }
        public string GetCSVString(PlacementFile data)
        {
            string OutputString = "Designator" + CSVSeparator + "Val" + CSVSeparator + "Package" + CSVSeparator + "Mid X" + CSVSeparator + "Mid Y" + CSVSeparator + "Rotation" + CSVSeparator + "Layer";

            foreach (PlacementDataLine dataLine in data.PlacementData)
            {
                if (dataLine.Side == PlacementSide.Undef) throw new IncompleteDataException("Placement data contains part with undefined placement side");

                OutputString += Environment.NewLine
                    + dataLine.Reference + CSVSeparator
                    + dataLine.Value + CSVSeparator
                    + dataLine.Footprint + CSVSeparator
                    + dataLine.Position.X.ToString() + CSVSeparator
                    + dataLine.Position.Y.ToString() + CSVSeparator
                    + dataLine.Rotation + CSVSeparator
                    + ((dataLine.Side == PlacementSide.Top) ? "top" : "bottom");
            }

            return OutputString;
        }
        public string GetCSVString(PlacementFile data, PlacementSide sideFilter)
        {
            string OutputString = "Designator" + CSVSeparator + "Val" + CSVSeparator + "Package" + CSVSeparator + "Mid X" + CSVSeparator + "Mid Y" + CSVSeparator + "Rotation" + CSVSeparator + "Layer";

            foreach (PlacementDataLine dataLine in data.PlacementData)
            {
                // Check if placement side has been set
                if (dataLine.Side == PlacementSide.Undef) throw new IncompleteDataException("Placement data contains part with undefined placement side");
                // Ignore placements that do not match the side filter
                if (dataLine.Side != sideFilter) continue;

                OutputString += Environment.NewLine
                    + dataLine.Reference + CSVSeparator
                    + dataLine.Value + CSVSeparator
                    + dataLine.Footprint + CSVSeparator
                    + dataLine.Position.X.ToString() + CSVSeparator
                    + dataLine.Position.Y.ToString() + CSVSeparator
                    + dataLine.Rotation + CSVSeparator
                    + ((dataLine.Side == PlacementSide.Top) ? "top" : "bottom");
            }

            return OutputString;
        }
    }
}
