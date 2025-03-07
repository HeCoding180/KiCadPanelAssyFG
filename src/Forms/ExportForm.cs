﻿using KiCadPanelAssyFG.src;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KiCadPanelAssyFG
{
    public partial class ExportForm : Form
    {
        //   ---   Public Properties   ---
        #region PUBLIC_PROPERTIES
        /// <summary>
        /// Number of unique designs. Used to generate the reference suffix
        /// </summary>
        public int uniqueDesigns { private set; get; }

        /// <summary>
        /// Getter property that returns a list of all footprint directories entered by the user.
        /// </summary>
        public string[] KiCadFootprintDirs
        {
            get
            {
                return fpDirsTextbox.Text.Split(Environment.NewLine);
            }
        }

        /// <summary>
        /// True once the footprints have been loaded once.
        /// </summary>
        public bool FootprintsLoaded { private set; get; }
        #endregion

        //   ---   Private Properties   ---
        #region PRIVATE_PROPERTIES
        /// <summary>
        /// Combined BOM file containing all design's BOMs with the newly generated reference designators.
        /// </summary>
        private BOMFile PanelBOM;
        /// <summary>
        /// Dictionary containing the data of all placements. Keys are the placements' reference designators.
        /// </summary>
        private Dictionary<string, PlacementDataLine> PanelPlacements;

        /// <summary>
        /// Size of all unscaled component's outlines. Used to calculate the appropriate scaling factor for the outline segments.
        /// </summary>
        private SizeF PreviewSize;

        private Color _TopOutlineColor;
        private Color _BottomOutlineColor;

        /// <summary>
        /// Property containing the color used to display parts placed on the top side of the PCB.
        /// Automatically updates the top outline color textbox's colors and text.
        /// </summary>
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
        /// <summary>
        /// Property containing the color used to display parts placed on the bottom side of the PCB.
        /// Automatically updates the bottom outline color textbox's colors and text.
        /// </summary>
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

        /// <summary>
        /// Getter property that returns the RGB value from the <c><b>TopOutlineColor</b></c> property and modifies the opacity according to the opacity slider's value.
        /// This color is used for the brushes used to fill the preview outlines.
        /// </summary>
        private Color TopOutlineFillColor
        {
            get
            {
                return Color.FromArgb((int)Math.Round(255.0 * (double)bgOpacityTrackbar.Value / 100), TopOutlineColor);
            }
        }
        /// <summary>
        /// Getter property that returns the RGB value from the <c><b>BottomOutlineColor</b></c> property and modifies the opacity according to the opacity slider's value.
        /// This color is used for the brushes used to fill the preview outlines.
        /// </summary>
        private Color BottomOutlineFillColor
        {
            get
            {
                return Color.FromArgb((int)Math.Round(255.0 * (double)bgOpacityTrackbar.Value / 100), BottomOutlineColor);
            }
        }
        #endregion

        //   ---   Constructor   ---
        public ExportForm(FileOverviewForm sender)
        {
            InitializeComponent();

            this.FormClosing += sender.ExportForm_Closing;

            PanelBOM = new BOMFile();
            PanelPlacements = new Dictionary<string, PlacementDataLine>();

            uniqueDesigns = 0;

            PreviewSize = new Size(0, 0);

            FootprintsLoaded = false;

            // Load settings from settings file
            Properties.Settings.Default.Reload();
            fpDirsTextbox.Text = Properties.Settings.Default.FootprintDirs;
            separateFilesCheckbox.Checked = Properties.Settings.Default.UseSeparatePlacementFiles;
            TopOutlineColor = Properties.Settings.Default.TopOutlineColor;
            BottomOutlineColor = Properties.Settings.Default.BottomOutlineColor;
            bgOpacityTrackbar.Value = Properties.Settings.Default.BackgroundOpacity;
        }

        //   ---   Public Methods   ---
        #region PUBLIC_METHODS
        /// <summary>
        /// Method used to add a design to the list of all designs. This function automatically generates the suffixes for the reference designators.
        /// </summary>
        /// <param name="design">Design that is to be added to the output BOM and placement file.</param>
        public void AddDesign(DesignInfo design)
        {
            // Create list of all placements contained in this design
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
                // Variable used to track if any BOM item was found in the placements list
                bool MatchFound_FullBOM = false;

                // Iterate through all BOM Data lines
                foreach (string PartNo in design.BOMFileData.BOMData.Keys)
                {
                    BOMDataLine refBomDataLine = design.BOMFileData.BOMData[PartNo];

                    // Create new BOM dataline without any references and copy the remaining properties
                    BOMDataLine outputBomDataLine = new BOMDataLine(refBomDataLine.Value, refBomDataLine.Footprint, refBomDataLine.LCSC_PN);

                    bool MatchFound_DataLine = false;

                    // Iterate through all references of the current bom data line
                    foreach (string currentDesignator in refBomDataLine.References)
                    {
                        PlacementDataLine refPlacementDataLine;
                        bool MatchFound_Local = false;

                        // Add reference with suffix to the current output BOM line
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
                            // No matching designator was found in the placements list
                        }
                    }

                    if (MatchFound_DataLine)
                    {
                        // If any match has been found in the dataline, add it to the output BOM
                        tempBOM.BOMData.Add(outputBomDataLine.LCSC_PN, outputBomDataLine);
                    }
                    else
                    {
                        // No matching designator from the BOM line was found in the placements list
                    }
                }

                if (MatchFound_FullBOM)
                {
                    // A full BOM has been completed. Merge it with the existing BOM to simplify it
                    PanelBOM.MergeFile(tempBOM);

                    // Increment number of unique designs to recieve new suffix for the next iteration
                    uniqueDesigns++;
                }
                else
                {
                    // Remaining items are not populated
                    break;
                }
            }
        }

        /// <summary>
        /// Add a list of designs to the current output BOM and placement file.
        /// </summary>
        /// <param name="designs">List of designs that are to be added.</param>
        public void addDesigns(List<DesignInfo> designs)
        {
            // Iterate through all designs
            foreach (DesignInfo design in designs)
            {
                this.AddDesign(design);
            }
        }

        /// <summary>
        /// Update the datagridviews from the export BOM and placements.
        /// </summary>
        public void UpdateTables()
        {
            // Update BOM table
            // Clear existing data from the BOM table
            BOMTable.Rows.Clear();

            // Iterate through the BOM and add all data lines
            foreach (string bomKey in PanelBOM.BOMData.Keys)
            {
                // Generate reference designators string
                string referencesString = "";
                for (int i = 0; i < PanelBOM.BOMData[bomKey].References.Count; i++)
                {
                    if (i > 0) referencesString += ", ";
                    referencesString += PanelBOM.BOMData[bomKey].References[i];
                }

                // Add row data
                BOMTable.Rows.Add(
                    PanelBOM.BOMData[bomKey].Value,
                    referencesString,
                    PanelBOM.BOMData[bomKey].Footprint,
                    PanelBOM.BOMData[bomKey].LCSC_PN);
            }

            // Update placements table
            // Clear existing data from the placements table
            PlacementsTable.Rows.Clear();

            // Iterate through all placements and add all data lines
            foreach (PlacementDataLine placementDataLine in PanelPlacements.Values)
            {
                string sideStr = ((placementDataLine.Side == PlacementSide.Top) ? "Top" : ((placementDataLine.Side == PlacementSide.Bottom) ? "Bottom" : "Undefined"));

                // Add row data
                PlacementsTable.Rows.Add(
                    placementDataLine.Reference,
                    placementDataLine.Value,
                    placementDataLine.Footprint,
                    placementDataLine.Position.X.ToString(),
                    placementDataLine.Position.Y.ToString(),
                    placementDataLine.Rotation.ToString(),
                    sideStr);
            }
        }

        /// <summary>
        /// Public method used to load all footprints and update the preview
        /// </summary>
        public void LoadFootprints()
        {
            // Check if any footprint directories have been added by the user
            if (KiCadFootprintDirs.Length == 0)
                return;

            bool AllFootprintsFound = true;

            // Iterate through all BOM data lines
            foreach (BOMDataLine bomDataLine in PanelBOM.BOMData.Values)
            {
                string fullFootprintDir = "";
                bool dirFound = false;

                // Iterate through all footprint directories to search for matching footprints
                foreach (string footprintDirectory in KiCadFootprintDirs)
                {
                    // Generate footprint path from directory and footprint name
                    fullFootprintDir = (footprintDirectory.Trim().Replace("/", "\\") + "\\" + KiCadFootprintUtil.GetRelativePathFromFootprintName(bomDataLine.Footprint)).Replace("\\\\", "\\");

                    // Check if footprint exists
                    if (File.Exists(fullFootprintDir))
                    {
                        dirFound = true;
                        break;
                    }
                }

                if (dirFound)
                {
                    // matching footprint file found
                    KiCadFootprintData partFootprintData = KiCadFootprintParser.ParseKiCadFootprint(fullFootprintDir);

                    // Iterate through all reference designators from this BOM line and uppdate matching placements
                    foreach (string reference in bomDataLine.References)
                    {
                        if (PanelPlacements.ContainsKey(reference))
                            PanelPlacements[reference].FootprintData = new KiCadFootprintData(partFootprintData);
                    }
                }
                else
                {
                    // Some footprints are missing
                    AllFootprintsFound = false;
                    continue;
                }
            }

            if (!AllFootprintsFound)
            {
                // Not all footprints were found, ask user if he still wants to continue
                if (MessageBox.Show("Not all footprints were found press \"OK\" to continue, press \"cancel\" to abort.", "Footprints missing", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
                {
                    // User chose to abort
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

                // Flip position Y values
                PointF graphicalFootprintPos = new PointF
                {
                    X = refDataLine.Position.X,
                    Y = -refDataLine.Position.Y
                };

                // Apply footprint rotation and position transformation to outline segments
                refFootprintData.OutlineSegments = Util.RotPosTransformLines(refFootprintData.OutlineSegments, graphicalFootprintPos, refDataLine.Rotation);

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

            // All footprints were loaded, refresh placements preview
            FootprintsLoaded = true;
            PlacementPreviewPanel.Refresh();
        }
        #endregion

        //   ---   Private Methods   ---
        #region PRIVATE_METHODS
        /// <summary>
        /// Method used to get the current design suffix based on the number of unique designs existing.
        /// </summary>
        /// <returns>String unique to the design number.</returns>
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
        #endregion

        //   ---   Event Callback Methods   ---
        #region EVENT_CALLBACK_METHODS
        #region FORM_EVENTS
        private void ExportForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Save all user variables to the settings file before the form is closed
            Properties.Settings.Default.FootprintDirs = fpDirsTextbox.Text;
            Properties.Settings.Default.UseSeparatePlacementFiles = separateFilesCheckbox.Checked;
            Properties.Settings.Default.TopOutlineColor = TopOutlineColor;
            Properties.Settings.Default.BottomOutlineColor = BottomOutlineColor;
            Properties.Settings.Default.BackgroundOpacity = bgOpacityTrackbar.Value;
            Properties.Settings.Default.Save();
        }
        #endregion

        #region PAINT_EVENTS
        private void PlacementPreviewPanel_Paint(object sender, PaintEventArgs e)
        {
            Panel senderPanel = (Panel)sender;

            // Fill Background
            e.Graphics.Clear(Color.Black);

            // Check if any footprints are loaded
            if (FootprintsLoaded)
            {
                // Calculate scaling and movement to resize and center the preview appropriately
                float boundsWidth = (float)senderPanel.Size.Width - 20.0f;
                float boundsHeight = (float)senderPanel.Size.Height - 20.0f;

                // Check if opacity to ignore shape fills
                bool fillPolygons = bgOpacityTrackbar.Value > 0;

                // Base transform vector for centering the outlines with a margin of 10px
                PointF transformVec = new PointF(10.0f, 10.0f);

                float previewScalingFactor = 1.0f;

                // Check if width or height is the limiting factor for the scaling
                if ((boundsWidth / boundsHeight) > (PreviewSize.Width / PreviewSize.Height))
                {
                    // Height is the limiting factor, calculate the scaling factor
                    previewScalingFactor = boundsHeight / PreviewSize.Height;

                    // Calculate the X offset needed to center the preview
                    transformVec.X += (boundsWidth - previewScalingFactor * PreviewSize.Width) / 2;
                }
                else
                {
                    // Width is the limiting factor, calculate the scaling factor
                    previewScalingFactor = boundsWidth / PreviewSize.Width;

                    // Calculate the Y offset needed to center the preview
                    transformVec.Y += (boundsHeight - previewScalingFactor * PreviewSize.Height) / 2;
                }

                // Create pen and brush variable for drawing the part outlines
                using (Pen TopOutlinePen = new Pen(TopOutlineColor),
                    BottomOutlinePen = new Pen(BottomOutlineColor))
                using (Brush TopFillBrush = new SolidBrush(TopOutlineFillColor),
                    BottomFillBrush = new SolidBrush(BottomOutlineFillColor))
                {
                    // Interate through all placements
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
                                List<PointF> scaledPoints = Util.ScalePosTransformPoints(refFootprintData.OutlinePolyPoints, transformVec, previewScalingFactor);

                                // Fill polygon if the opacity is above 0
                                if (fillPolygons) e.Graphics.FillPolygon(FillBrush, scaledPoints.ToArray());

                                // Draw polygon outline
                                e.Graphics.DrawPolygon(OutlinePen, scaledPoints.ToArray());
                            }
                            else
                            {
                                // Outline is not a closed polygonal chain or contains stub or isolated segments
                                List<LineF> scaledLines = Util.ScalePosTransformLines(refFootprintData.OutlineSegments, transformVec, previewScalingFactor);

                                // Draw all outline segments as individual segments
                                foreach (LineF refLine in scaledLines)
                                {
                                    // Draw individual line
                                    e.Graphics.DrawLine(OutlinePen, refLine.StartPoint, refLine.EndPoint);
                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region USER_INTERACTION_EVENTS
        private void topOutlineColorTextbox_DoubleClick(object sender, EventArgs e)
        {
            // Open color dialog to allow the user to select a new color
            using (ColorDialog colorDialog = new ColorDialog())
            {
                colorDialog.Color = TopOutlineColor;

                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    // Color selection successful, update top outline color
                    TopOutlineColor = colorDialog.Color;

                    // Update preview panel
                    PlacementPreviewPanel.Refresh();
                }
            }
        }

        private void bottomOutlineColorTextbox_DoubleClick(object sender, EventArgs e)
        {
            // Open color dialog to allow the user to select a new color
            using (ColorDialog colorDialog = new ColorDialog())
            {
                colorDialog.Color = TopOutlineColor;

                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    // Color selection successful, update bottom outline color
                    BottomOutlineColor = colorDialog.Color;

                    // Update preview panel
                    PlacementPreviewPanel.Refresh();
                }
            }
        }

        private void VisibilityCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            // Update placements preview
            PlacementPreviewPanel.Refresh();
        }

        private void bgOppacityTrackbar_Scroll(object sender, EventArgs e)
        {
            // Refresh placements preview
            PlacementPreviewPanel.Refresh();
        }

        private void bReloadFootprints_Click(object sender, EventArgs e)
        {
            LoadFootprints();
        }

        private void bExport_Click(object sender, EventArgs e)
        {
            string projectName = ProjectNameTextbox.Text.Replace(" ", "_");

            string selectedOutputPath = "";

            // Check if project name is missing
            if (projectName == "")
            {
                MessageBox.Show("Please enter a project name.", "Project Name Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check project name validity
            if (!Regex.IsMatch(projectName, "^(?!^(PRN|AUX|CLOCK\\$|NUL|CON|COM[1-9]|LPT[1-9])$)[^<>:\\\"\\/\\|?*\\x00-\\x1F]+$"))
            {
                MessageBox.Show("The current project name contains invalid characters or is otherwise invalid. Please select a different name.", "Invalid Project Name Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Open folder browser dialog for the file output directory
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Select Output Folder to Save Files in";
                dialog.UseDescriptionForTitle = true;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    selectedOutputPath = dialog.SelectedPath;
                }
                else
                {
                    return;
                }
            }

            // Check if output directory is valid
            if (!Directory.Exists(selectedOutputPath))
            {
                MessageBox.Show("The selected output directory does not exist, please try again.", "Invalid Output Directory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AssyFilesGenerator filesGenerator = new AssyFilesGenerator(';');

            // Generate BOM file
            filesGenerator.ExportToFile(projectName + "_BOM.csv", selectedOutputPath, PanelBOM);

            // Generate placement file from the placements dictionary to use for the export function
            PlacementFile tempPanelPlacementFile = new PlacementFile();
            foreach (string placementKey in PanelPlacements.Keys)
            {
                tempPanelPlacementFile.PlacementData.Add(PanelPlacements[placementKey]);
            }

            // Check if the user wants separate files for top and bottom layer
            if (separateFilesCheckbox.Checked)
            {
                // Generate top placement file
                filesGenerator.ExportToFile(projectName + "_top_pos.csv", selectedOutputPath, tempPanelPlacementFile, PlacementSide.Top);
                // Generate bottom placement file
                filesGenerator.ExportToFile(projectName + "_bottom_pos.csv", selectedOutputPath, tempPanelPlacementFile, PlacementSide.Bottom);
            }
            else
            {
                // Generate combined top and bottom placement file
                filesGenerator.ExportToFile(projectName + "_pos.csv", selectedOutputPath, tempPanelPlacementFile);
            }
        }
        #endregion
        #endregion
    }
}
