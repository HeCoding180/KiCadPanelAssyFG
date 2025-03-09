using KiCadPanelAssyFG.Properties;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace KiCadPanelAssyFG
{
    public partial class FileOverviewForm : Form
    {
        // Public readonly variables
        public static readonly bool GraphicsDebugEnabled = false;

        // Public variables
        Dictionary<string, DesignInfo> Designs = new Dictionary<string, DesignInfo>();

        // Private readonly variables
        private static readonly Rectangle IconButtonImageBounds = new Rectangle(7, 7, 16, 16);

        // Private variables
        private ExportForm? ExportWin;
        private bool ExportWinActive;

        public FileOverviewForm()
        {
            InitializeComponent();

            designListBox.BackColor = WindowColors.NormalBGColor;
            placementsListBox.BackColor = WindowColors.NormalBGColor;
        }

        public void ExportForm_Closing(object? sender, FormClosingEventArgs e)
        {
            ExportWinActive = false;
        }

        private void ListBox_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = 30;
        }

        private void ListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            ListBox senderListBox = (ListBox)sender;

            if (senderListBox.Items.Count > 0)
            {
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                {
                    using (Brush BGBrush = new SolidBrush(WindowColors.SelectedColor))
                    {
                        e.Graphics.FillRectangle(BGBrush, e.Bounds);
                    }
                }
                else
                {
                    using (Brush BGBrush = new SolidBrush(senderListBox.BackColor))
                    {
                        e.Graphics.FillRectangle(BGBrush, e.Bounds);
                    }
                }

                float textSpacing = e.Bounds.Height / 2 - senderListBox.Font.GetHeight() / 2;

                float TextXPos = e.Bounds.X + textSpacing;
                float TextYPos = e.Bounds.Y + textSpacing;

                if (GraphicsDebugEnabled)
                {
                    // Draw Item Bounds
                    e.Graphics.DrawRectangle(new Pen(Brushes.Purple), e.Bounds.X, e.Bounds.Y, e.Bounds.Width - 1, e.Bounds.Height - 1);

                    // Draw Item Center Line
                    e.Graphics.DrawLine(new Pen(Brushes.Blue), e.Bounds.X, e.Bounds.Y + e.Bounds.Height / 2, e.Bounds.X + e.Bounds.Width, e.Bounds.Y + e.Bounds.Height / 2);

                    // Draw Text boundary
                    e.Graphics.DrawRectangle(new Pen(Brushes.Red), TextXPos, TextYPos, TextRenderer.MeasureText(senderListBox.Items[e.Index].ToString(), senderListBox.Font).Width - 1, senderListBox.Font.GetHeight());
                }

                using (Brush FontBrush = new SolidBrush(WindowColors.ForeColor))
                {
                    e.Graphics.DrawString(senderListBox.Items[e.Index].ToString(), senderListBox.Font, FontBrush, TextXPos, TextYPos);
                }

                e.DrawFocusRectangle();
            }
        }

        private void AddButton_Paint(object sender, PaintEventArgs e)
        {
            Button SenderButton = (Button)sender;

            if (SenderButton.Enabled)
            {
                e.Graphics.DrawImage(Resources.AddIcon, IconButtonImageBounds);
            }
            else
            {
                e.Graphics.DrawImage(Resources.AddIcon_Disabled, IconButtonImageBounds);
            }
        }

        private void RemoveButton_Paint(object sender, PaintEventArgs e)
        {
            Button SenderButton = (Button)sender;

            if (SenderButton.Enabled)
            {
                e.Graphics.DrawImage(Resources.RemoveIcon, IconButtonImageBounds);
            }
            else
            {
                e.Graphics.DrawImage(Resources.RemoveIcon_Disabled, IconButtonImageBounds);
            }
        }

        private void designListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (designListBox.SelectedIndex >= 0)
            {
                placementsListBox.SelectedIndex = -1;
                placementsListBox.Items.Clear();

                string? selectedDesignKey = designListBox.GetItemText(designListBox.SelectedItem);

                if ((selectedDesignKey != null) && (Designs[selectedDesignKey].Placements.Count > 0))
                {
                    foreach (string PlacementName in Designs[selectedDesignKey].Placements.Keys)
                    {
                        placementsListBox.Items.Add(PlacementName);
                    }
                }

                bRemoveDesign.Enabled = true;
                bAddPlacements.Enabled = true;
            }
            else
            {
                placementsListBox.Items.Clear();

                bRemoveDesign.Enabled = false;
                bAddPlacements.Enabled = false;
            }
        }

        private void placementsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (placementsListBox.SelectedIndex >= 0)
            {
                bRemovePlacement.Enabled = true;
            }
            else
            {
                bRemovePlacement.Enabled = false;
            }
        }

        private void bAddDesign_Click(object sender, EventArgs e)
        {
            AddFileForm addFileForm = new AddFileForm("Add new Design", "Design Name", "BOM File (.csv)");

            if (addFileForm.ShowDialog() == DialogResult.OK)
            {
                if (Designs.Keys.Contains(addFileForm.fileName))
                {
                    MessageBox.Show("A design with the name \"" + addFileForm.fileName + "\" already exists!", "Duplicate Design", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    Designs.Add(addFileForm.fileName, new DesignInfo(addFileForm.fileName, addFileForm.fileDir));

                    designListBox.Items.Add(addFileForm.fileName);
                }
            }
        }

        private void bRemoveDesign_Click(object sender, EventArgs e)
        {
            if ((designListBox.SelectedIndex >= 0) && (designListBox.SelectedItem != null))
            {
                string? selectedDesign = designListBox.GetItemText(designListBox.SelectedItem);

                if (selectedDesign != null)
                {
                    Designs.Remove(selectedDesign);
                    designListBox.Items.Remove(designListBox.SelectedItem);

                    if (designListBox.SelectedIndex == 0)
                    {
                        bRemoveDesign.Enabled = false;
                        bAddPlacements.Enabled = false;
                    }
                }
            }
        }

        private void bAddPlacements_Click(object sender, EventArgs e)
        {
            string? selectedDesignKey = designListBox.GetItemText(designListBox.SelectedItem);

            if (selectedDesignKey != null)
            {
                AddFileForm addFileForm = new AddFileForm("Add new Placement", "Placement Name", "Component Placement File (.csv)");

                if (addFileForm.ShowDialog() == DialogResult.OK)
                {
                    if (Designs[selectedDesignKey].Placements.Keys.Contains(addFileForm.fileName))
                    {
                        MessageBox.Show("A placement with the name \"" + addFileForm.fileName + "\" already exists in the selected design!", "Duplicate Placement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        Designs[selectedDesignKey].addPlacementInfo(new PlacementInfo(addFileForm.fileName, addFileForm.fileDir));

                        placementsListBox.Items.Add(addFileForm.fileName);
                    }
                }
            }
        }

        private void bRemovePlacement_Click(object sender, EventArgs e)
        {
            string? selectedDesignKey = designListBox.GetItemText(designListBox.SelectedItem);
            object? selectedPlacementItem = placementsListBox.SelectedItem;
            string? selectedPlacementKey = placementsListBox.GetItemText(selectedPlacementItem);

            if ((selectedDesignKey != null) && (selectedPlacementItem != null) && (selectedPlacementKey != null) && (placementsListBox.SelectedIndex >= 0) && (designListBox.SelectedIndex >= 0))
            {
                Designs[selectedDesignKey].removePlacementInfo(selectedPlacementKey);
                placementsListBox.Items.Remove(selectedPlacementItem);

                if (placementsListBox.SelectedIndex == 0)
                {
                    bRemovePlacement.Enabled = false;
                }
            }
        }

        private void bExport_Click(object sender, EventArgs e)
        {
            DoubleProgressbarWindow progressbarWindow = new DoubleProgressbarWindow("Loading Designs", "Loading Design: ", "Parsing: ");
            progressbarWindow.Show();

            progressbarWindow.PrimaryMaxProgress = Designs.Count;

            string lastDesignKey = "";
            string lastPlacementKey = "";

            try
            {
                // Read and parse all BOM and placement files
                foreach (string designKey in Designs.Keys)
                {
                    lastDesignKey = designKey;
                    progressbarWindow.SecondaryMaxProgress = 1 + Designs[designKey].Placements.Count;

                    progressbarWindow.PrimaryText = "Loading Design: " + designKey;
                    progressbarWindow.SecondaryText = "Parsing BOM File: " + designKey;

                    Designs[designKey].parseBomFromFile();
                    progressbarWindow.SecondaryProgress += 1;

                    foreach (string placementKey in Designs[designKey].Placements.Keys)
                    {
                        lastPlacementKey = placementKey;

                        progressbarWindow.SecondaryText = "Parsing Placement File: " + placementKey;
                        Designs[designKey].Placements[placementKey].parsePlacementFromFile();
                        progressbarWindow.SecondaryProgress += 1;
                    }
                    lastPlacementKey = "";

                    progressbarWindow.PrimaryProgress += 1;
                    progressbarWindow.SecondaryProgress = 0;
                }
            }
            catch (ArgumentDataException argEx)
            {
                string errorMessage;
                if (lastPlacementKey != "")
                    errorMessage = "The import failed in Design \"" + lastDesignKey + "\" in  \"" + lastPlacementKey + "\" with the following error message: " + Environment.NewLine + argEx.Message;
                else
                    errorMessage = "The import failed in Design \"" + lastDesignKey + "\" with the following error message: " + Environment.NewLine + argEx.Message;
                MessageBox.Show(errorMessage, "Import Aborted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            progressbarWindow.Close();

            if ((ExportWin == null) || !ExportWinActive)
            {
                ExportWin = new ExportForm(this);

                foreach (string designKey in Designs.Keys)
                {
                    ExportWin.AddDesign(Designs[designKey]);
                }

                ExportWin.Show();

                ExportWin.UpdateTables();

                ExportWin.LoadFootprints();

                ExportWinActive = true;
            }
        }
    }
}
