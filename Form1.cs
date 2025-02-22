using System.Runtime.InteropServices;

namespace KiCad_Panel_Assembly_Files_Generator
{
    public partial class InputFilesForm : Form
    {
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
        }
    }
}
