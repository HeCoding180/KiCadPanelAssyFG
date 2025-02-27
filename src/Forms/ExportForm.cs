using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KiCadPanelAssyFG
{
    public partial class ExportForm : Form
    {
        public int uniqueDesigns { private set; get; }

        public string[] KiCadFootprintDirs
        {
            get
            {
                return fpDirsTextbox.Text.Split(Environment.NewLine);
            }
        }

        public bool FootprintsLoaded { private set; get; }

        private BOMFile PanelBOM;
        private Dictionary<string, PlacementDataLine> PanelPlacements;

        private SizeF PreviewSize;

        private Color _TopOutlineColor;
        private Color _BottomOutlineColor;

        private Color TopOutlineColor
        {
            set
            {
                _TopOutlineColor = value;
                topOutlineColorTextbox.BackColor = value;
                topOutlineColorTextbox.ForeColor = (Math.Max(Math.Max(value.R, value.G), value.B) > 128) ? Color.Black : Color.White;
                topOutlineColorTextbox.Text = ColorTranslator.ToHtml(value);
            }
            get
            {
                return _TopOutlineColor;
            }
        }
        private Color BottomOutlineColor
        {
            set
            {
                _BottomOutlineColor = value;
                bottomOutlineColorTextbox.BackColor = value;
                bottomOutlineColorTextbox.ForeColor = (Math.Max(Math.Max(value.R, value.G), value.B) > 128) ? Color.Black : Color.White;
                bottomOutlineColorTextbox.Text = ColorTranslator.ToHtml(value);
            }
            get
            {
                return _BottomOutlineColor;
            }
        }

        private Color TopOutlineFillColor
        {
            get
            {
                return Color.FromArgb(128, TopOutlineColor);
            }
        }
        private Color BottomOutlineFillColor
        {
            get
            {
                return Color.FromArgb(128, BottomOutlineColor);
            }
        }

        public ExportForm(FileOverviewForm sender)
        {
            InitializeComponent();

            this.FormClosing += sender.ExportForm_Closing;

            PanelBOM = new BOMFile();
            PanelPlacements = new Dictionary<string, PlacementDataLine>();

            uniqueDesigns = 0;

            PreviewSize = new Size(0, 0);

            FootprintsLoaded = false;

            // Load Settings
            Properties.Settings.Default.Reload();
            fpDirsTextbox.Text = Properties.Settings.Default.FootprintDirs;
            separateFilesCheckbox.Checked = Properties.Settings.Default.UseSeparatePlacementFiles;
            TopOutlineColor = Properties.Settings.Default.TopOutlineColor;
            BottomOutlineColor = Properties.Settings.Default.BottomOutlineColor;
        }

        public void AddDesign(DesignInfo design)
        {
            // Create list of all placements related to this design
            List<PlacementDataLine> placementDataLines = new List<PlacementDataLine>();
            foreach (string placementKey in design.Placements.Keys)
            {
                placementDataLines.AddRange(design.Placements[placementKey].PlacementFileData.PlacementData);
            }

            // Iterate through placements untill all placements are handled
            while (placementDataLines.Count > 0)
            {
                // Temporary BOM used to build BOM for merge
                BOMFile tempBOM = new BOMFile();
                /// <summary>
                /// Variable used to track if <b>any</b> BOM item was found in the placements list
                /// </summary>
                bool MatchFound_FullBOM = false;

                // Iterate through all BOM Data lines
                foreach (string PartNo in design.BOMFileData.BOMData.Keys)
                {
                    BOMDataLine refBomDataLine = design.BOMFileData.BOMData[PartNo];
                    BOMDataLine outputBomDataLine = new BOMDataLine(refBomDataLine.Value, refBomDataLine.Footprint, refBomDataLine.LCSC_PN);

                    bool MatchFound_DataLine = false;

                    foreach (string currentDesignator in refBomDataLine.References)
                    {
                        PlacementDataLine refPlacementDataLine;
                        bool MatchFound_Local = false;

                        outputBomDataLine.References.Add(currentDesignator + GetCurrentDesignSuffix());

                        for (int i = 0; i < placementDataLines.Count; i++)
                        {
                            // Look for first match of this designator in the list of all related placements
                            if (placementDataLines[i].Reference == currentDesignator)
                            {
                                // Store matching placement data line
                                refPlacementDataLine = new PlacementDataLine(placementDataLines[i]);
                                // Remove the handled placement data line
                                placementDataLines.RemoveAt(i);
                                // Add reference suffix and add to panel placement data
                                refPlacementDataLine.Reference += GetCurrentDesignSuffix();
                                PanelPlacements.Add(refPlacementDataLine.Reference, refPlacementDataLine);
                                // Set match flags
                                MatchFound_Local = true;
                                MatchFound_DataLine = true;
                                MatchFound_FullBOM = true;
                                break;
                            }
                        }

                        if (!MatchFound_Local)
                        {
                            // No matching designator was found in the placements list.
                        }
                    }

                    if (MatchFound_DataLine)
                    {
                        tempBOM.BOMData.Add(outputBomDataLine.LCSC_PN, outputBomDataLine);
                    }
                    else
                    {
                        // No matching designator from the BOM line was found in the placements list.
                    }
                }

                if (MatchFound_FullBOM)
                {
                    PanelBOM.MergeFile(tempBOM);

                    uniqueDesigns++;
                }
                else
                {
                    // Remaining items are not populated
                    break;
                }
            }
        }

        public void addDesigns(List<DesignInfo> designs)
        {
            foreach (DesignInfo design in designs)
            {
                this.AddDesign(design);
            }
        }

        public void UpdateTables()
        {
            BOMTable.Rows.Clear();
            foreach (string bomKey in PanelBOM.BOMData.Keys)
            {
                string designatorsString = "";

                for (int i = 0; i < PanelBOM.BOMData[bomKey].References.Count; i++)
                {
                    if (i > 0) designatorsString += ", ";
                    designatorsString += PanelBOM.BOMData[bomKey].References[i];
                }

                BOMTable.Rows.Add(
                    PanelBOM.BOMData[bomKey].Value,
                    designatorsString,
                    PanelBOM.BOMData[bomKey].Footprint,
                    PanelBOM.BOMData[bomKey].LCSC_PN);
            }

            PlacementsTable.Rows.Clear();
            foreach (PlacementDataLine placementDataLine in PanelPlacements.Values)
            {
                PlacementsTable.Rows.Add(
                    placementDataLine.Reference,
                    placementDataLine.Value,
                    placementDataLine.Footprint,
                    placementDataLine.Position.X.ToString(),
                    placementDataLine.Position.Y.ToString(),
                    placementDataLine.Rotation.ToString());
            }
        }

        private string GetCurrentDesignSuffix()
        {
            string suffix = "";
            int n = uniqueDesigns;
            while (n >= 0)
            {
                suffix += (char)('A' + (n % 26));
                n = (n / 26) - 1;
            }
            return suffix;
        }

        private void topOutlineColorTextbox_DoubleClick(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog
            {
                Color = TopOutlineColor
            };

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                TopOutlineColor = colorDialog.Color;
            }
        }

        private void bottomOutlineColorTextbox_DoubleClick(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog
            {
                Color = BottomOutlineColor
            };

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                BottomOutlineColor = colorDialog.Color;
            }
        }

        private void ExportForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.FootprintDirs = fpDirsTextbox.Text;
            Properties.Settings.Default.UseSeparatePlacementFiles = separateFilesCheckbox.Checked;
            Properties.Settings.Default.TopOutlineColor = TopOutlineColor;
            Properties.Settings.Default.BottomOutlineColor = BottomOutlineColor;
            Properties.Settings.Default.Save();
        }

        private void bReloadFootprints_Click(object sender, EventArgs e)
        {
            bool AllFootprintsFound = true;

            foreach (BOMDataLine bomDataLine in PanelBOM.BOMData.Values)
            {
                string fullFootprintDir = "";
                bool dirFound = false;

                foreach (string footprintDirectory in KiCadFootprintDirs)
                {
                    fullFootprintDir = (footprintDirectory.Trim().Replace("/", "\\") + "\\" + KiCadFootprintUtil.GetRelativePathFromFootprintName(bomDataLine.Footprint)).Replace("\\\\", "\\");

                    if (File.Exists(fullFootprintDir))
                    {
                        dirFound = true;
                        break;
                    }
                }

                if (dirFound)
                {
                    KiCadFootprintData partFootprintData = KiCadFootprintParser.ParseKiCadFootprint(fullFootprintDir);

                    foreach (string reference in bomDataLine.References)
                    {
                        if (PanelPlacements.ContainsKey(reference))
                            PanelPlacements[reference].FootprintData = new KiCadFootprintData(partFootprintData);
                    }
                }
                else
                {
                    AllFootprintsFound = false;
                    continue;
                }
            }

            if (!AllFootprintsFound)
            {
                if (MessageBox.Show("Not all footprints were found press \"OK\" to continue, press \"cancel\" to abort.", "Footprints missing", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
                {
                    return;
                }
            }

            float minX = float.MaxValue;
            float minY = float.MaxValue;
            float maxX = float.MinValue;
            float maxY = float.MinValue;

            // Apply rotation and position transformations
            foreach (string placementKey in PanelPlacements.Keys)
            {
                PlacementDataLine refDataLine = PanelPlacements[placementKey];
                KiCadFootprintData refFootprintData = refDataLine.FootprintData;

                // Apply footprint rotation and position transformation to outline segments
                refFootprintData.OutlineSegments = Util.RotPosTransformLines(refFootprintData.OutlineSegments, refDataLine.Position, refDataLine.Rotation);

                // Try build closed polygonal line, get bounds
                if (refFootprintData.TryBuildClosedPolygonalLine())
                {
                    // Outline is a closed polygonal chain
                    foreach (PointF refPoint in refFootprintData.OutlinePolyPoints)
                    {
                        // (Re)calculate min point
                        minX = float.Min(refPoint.X, minX);
                        minY = float.Min(refPoint.Y, minY);

                        // (Re)calculate max point
                        maxX = float.Max(refPoint.X, maxX);
                        maxY = float.Max(refPoint.Y, maxY);
                    }
                }
                else
                {
                    // Outline is not a closed polygonal chain or contains stub or isolated segments
                    foreach (LineF refLine in refFootprintData.OutlineSegments)
                    {
                        // (Re)calculate min point
                        minX = float.Min(refLine.StartPoint.X, float.Min(refLine.EndPoint.X, minX));
                        minY = float.Min(refLine.StartPoint.Y, float.Min(refLine.EndPoint.Y, minY));

                        // (Re)calculate max point
                        maxX = float.Max(refLine.StartPoint.X, float.Max(refLine.EndPoint.X, maxX));
                        maxY = float.Max(refLine.StartPoint.Y, float.Max(refLine.EndPoint.Y, maxY));
                    }
                }
            }

            // Calculate unscaled size of the preview
            PreviewSize = new SizeF(maxX - minX, maxY - minY);
            PointF zeroTransformVector = new PointF(-minX, -minY);

            // Apply position transform 
            foreach (string placementKey in PanelPlacements.Keys)
            {
                PlacementDataLine refDataLine = PanelPlacements[placementKey];
                KiCadFootprintData refFootprintData = refDataLine.FootprintData;

                if (refFootprintData.outlineIsClosedPolygonalChain)
                {
                    // Outline is a closed polygonal chain
                    refFootprintData.OutlineSegments = Util.PosTransformLines(refFootprintData.OutlineSegments, zeroTransformVector);
                    refFootprintData.OutlinePolyPoints = Util.PosTransformPoints(refFootprintData.OutlinePolyPoints, zeroTransformVector);
                }
                else
                {
                    // Outline is not a closed polygonal chain or contains stub or isolated segments
                    refFootprintData.OutlineSegments = Util.PosTransformLines(refFootprintData.OutlineSegments, zeroTransformVector);
                }
            }

            FootprintsLoaded = true;
            PlacementPreviewPanel.Refresh();
        }

        private void PlacementPreviewPanel_Paint(object sender, PaintEventArgs e)
        {
            // Fill Background
            e.Graphics.Clear(Color.Black);

            if (FootprintsLoaded)
            {
                using (Pen TopOutlinePen = new Pen(TopOutlineColor),
                    BottomOutlinePen = new Pen(BottomOutlineColor))
                using (Brush TopFillBrush = new SolidBrush(TopOutlineFillColor),
                    BottomFillBrush = new SolidBrush(BottomOutlineFillColor))
                {
                    foreach (string placementKey in PanelPlacements.Keys)
                    {
                        PlacementDataLine refDataLine = PanelPlacements[placementKey];
                        KiCadFootprintData refFootprintData = refDataLine.FootprintData;

                        // Check if placement side is valid and visible
                        if (((refDataLine.Side == PlacementSide.Top) && topVisibleCheckbox.Checked) || ((refDataLine.Side == PlacementSide.Bottom) && bottomVisibleCheckbox.Checked))
                        {
                            // Select appropriate brushes
                            Pen OutlinePen = (refDataLine.Side == PlacementSide.Top) ? TopOutlinePen : BottomOutlinePen;
                            Brush FillBrush = (refDataLine.Side == PlacementSide.Top) ? TopFillBrush : BottomFillBrush;

                            if (refFootprintData.outlineIsClosedPolygonalChain)
                            {
                                // Outline is a closed polygonal chain
                                e.Graphics.FillPolygon(FillBrush, refFootprintData.OutlinePolyPoints.ToArray());
                                e.Graphics.DrawPolygon(OutlinePen, refFootprintData.OutlinePolyPoints.ToArray());
                            }
                            else
                            {
                                // Outline is not a closed polygonal chain or contains stub or isolated segments
                                foreach (LineF refLine in refFootprintData.OutlineSegments)
                                {
                                    e.Graphics.DrawLine(OutlinePen, refLine.StartPoint, refLine.EndPoint);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void VisibilityCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            PlacementPreviewPanel.Refresh();
        }
    }
}
