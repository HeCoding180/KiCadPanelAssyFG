using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace KiCadPanelAssyFG
{
    // Custom Exceptions
    public class ArgumentDataException : Exception
    {
        public ArgumentDataException() { }

        public ArgumentDataException(string message) : base(message) { }

        public ArgumentDataException(string message, Exception inner) : base(message, inner) { }
    }
    
    // Custom Enums
    public enum PlacementSide
    {
        Undef,
        Top,
        Bottom
    }

    // Dark mode title bar override methods
    public partial class FileOverviewForm : Form
    {
        protected override void OnHandleCreated(EventArgs e)
        {
            if (Util.DwmSetWindowAttribute(Handle, 19, new[] { 1 }, 4) != 0)
                Util.DwmSetWindowAttribute(Handle, 20, new[] { 1 }, 4);
        }
    }
    public partial class AddFileForm : Form
    {
        protected override void OnHandleCreated(EventArgs e)
        {
            if (Util.DwmSetWindowAttribute(Handle, 19, new[] { 1 }, 4) != 0)
                Util.DwmSetWindowAttribute(Handle, 20, new[] { 1 }, 4);
        }
    }

    public class Util
    {
        // Darkmode title bar dll method import
        // Source: https://stackoverflow.com/a/64927217
        /// <summary>
        /// Sets the value of Desktop Window Manager (DWM) non-client rendering attributes for a window. For programming guidance, and code examples, see Controlling non-client region rendering.
        /// </summary>
        /// <param name="hwnd">The handle to the window for which the attribute value is to be set.</param>
        /// <param name="attr">A flag describing which value to set, specified as a value of the DWMWINDOWATTRIBUTE enumeration. This parameter specifies which attribute to set, and the pvAttribute parameter points to an object containing the attribute value.</param>
        /// <param name="attrValue">A pointer to an object containing the attribute value to set. The type of the value set depends on the value of the dwAttribute parameter. The DWMWINDOWATTRIBUTE enumeration topic indicates, in the row for each flag, what type of value you should pass a pointer to in the pvAttribute parameter.</param>
        /// <param name="attrSize">The size, in bytes, of the attribute value being set via the pvAttribute parameter. The type of the value set, and therefore its size in bytes, depends on the value of the dwAttribute parameter.</param>
        /// <returns>
        /// If the function succeeds, it returns <b><c>S_OK</c></b>. Otherwise, it returns an <b><c>HRESULT</c></b> error code.
        /// If Desktop Composition has been disabled (Windows 7 and earlier), then this function returns <b><c>DWM_E_COMPOSITIONDISABLED</c></b>.
        /// </returns>
        [DllImport("DwmApi")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, int[] attrValue, int attrSize);
    }
}
