using KiCad_Panel_Assembly_Files_Generator.Properties;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace KiCad_Panel_Assembly_Files_Generator
{
    public partial class InputFilesForm : Form
    {
        // Public readonly variables
        public readonly bool GraphicsDebugEnabled = false;

        // Public variables
        Dictionary<string, DesignInfo> Designs = new Dictionary<string, DesignInfo>();

        // Private readonly variables
        private static readonly Rectangle IconButtonImageBounds = new Rectangle(7, 7, 16, 16);

        // Darkmode title bar
        // Source: https://stackoverflow.com/a/64927217
        [DllImport("DwmApi")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, int[] attrValue, int attrSize);

        protected override void OnHandleCreated(EventArgs e)
        {
            if (DwmSetWindowAttribute(Handle, 19, new[] { 1 }, 4) != 0)
                DwmSetWindowAttribute(Handle, 20, new[] { 1 }, 4);
        }

        public InputFilesForm()
        {
            InitializeComponent();

            designListBox.BackColor = WindowColors.NormalBGColor;
            placementsListBox.BackColor = WindowColors.NormalBGColor;
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

                if (Designs[designListBox.GetItemText(designListBox.SelectedItem)].Placements.Count > 0)
                {
                    foreach (string PlacementName in Designs[designListBox.GetItemText(designListBox.SelectedItem)].Placements.Keys)
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
            AddFileForm addFileForm = new AddFileForm("Add new Design", "Design Name", "BOM File (.csv)", false);

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
            if (designListBox.SelectedIndex >= 0)
            {
                Designs.Remove(designListBox.GetItemText(designListBox.SelectedItem));
                designListBox.Items.Remove(designListBox.SelectedItem);

                if (designListBox.SelectedIndex == 0)
                {
                    bRemoveDesign.Enabled = false;
                    bAddPlacements.Enabled = false;
                }
            }
        }

        private void bAddPlacements_Click(object sender, EventArgs e)
        {
            AddFileForm addFileForm = new AddFileForm("Add new Placement", "Placement Name", "Component Placement File (.csv)", true);

            if (addFileForm.ShowDialog() == DialogResult.OK)
            {
                if (Designs[designListBox.GetItemText(designListBox.SelectedItem)].Placements.Keys.Contains(addFileForm.fileName))
                {
                    MessageBox.Show("A placement with the name \"" + addFileForm.fileName + "\" already exists in the selected design!", "Duplicate Placement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    Designs[designListBox.GetItemText(designListBox.SelectedItem)].addPlacementInfo(new PlacementInfo(addFileForm.fileName, addFileForm.fileDir, addFileForm.placementPosition));

                    placementsListBox.Items.Add(addFileForm.fileName);
                }
            }
        }

        private void bRemovePlacement_Click(object sender, EventArgs e)
        {
            if ((placementsListBox.SelectedIndex >= 0) && (designListBox.SelectedIndex >= 0))
            {
                Designs[designListBox.GetItemText(designListBox.SelectedItem)].removePlacementInfo(placementsListBox.GetItemText(placementsListBox.SelectedItem));
                placementsListBox.Items.Remove(placementsListBox.SelectedItem);

                if (placementsListBox.SelectedIndex == 0)
                {
                    bRemovePlacement.Enabled = false;
                }
            }
        }

        private void bExport_Click(object sender, EventArgs e)
        {
            // Read all BOM files
            foreach (KeyValuePair<string, DesignInfo> DesignKvp in Designs)
            {

            }
        }
    }
}
