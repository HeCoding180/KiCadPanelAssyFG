using KiCad_Panel_Assembly_Files_Generator.Properties;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace KiCad_Panel_Assembly_Files_Generator
{
    public partial class InputFilesForm : Form
    {
        readonly bool GraphicsDebugEnabled = false;

        // Darkmode title bar
        // Source: https://stackoverflow.com/a/64927217
        [DllImport("DwmApi")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, int[] attrValue, int attrSize);

        private static readonly Rectangle IconButtonImageBounds = new Rectangle(7, 7, 16, 16);

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

            if (senderListBox.Items.Count > 1)
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

        }

        private void bAddDesign_Click(object sender, EventArgs e)
        {

        }

        private void bRemoveDesign_Click(object sender, EventArgs e)
        {

        }

        private void bAddPlacements_Click(object sender, EventArgs e)
        {

        }

        private void bRemovePlacement_Click(object sender, EventArgs e)
        {

        }
    }
}
