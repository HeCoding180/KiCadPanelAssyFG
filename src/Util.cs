using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace KiCadPanelAssyFG
{
    // Custom Enums
    public enum PlacementSide
    {
        Undef,
        Top,
        Bottom
    }

    public struct LineF
    {
        public PointF StartPoint;
        public PointF EndPoint;

        public LineF(PointF startPoint, PointF endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
        }
    }

    // Custom Exceptions
    public class ArgumentDataException : Exception
    {
        public ArgumentDataException() { }

        public ArgumentDataException(string message) : base(message) { }

        public ArgumentDataException(string message, Exception inner) : base(message, inner) { }
    }

    public class InvalidKiCadFootprintException : Exception
    {
        public InvalidKiCadFootprintException() { }

        public InvalidKiCadFootprintException(string message) : base(message) { }

        public InvalidKiCadFootprintException(string message, Exception inner) : base(message, inner) { }
    }

    public class IncompleteDataException : Exception
    {
        public IncompleteDataException() { }

        public IncompleteDataException(string message) : base(message) { }

        public IncompleteDataException(string message, Exception inner) : base(message, inner) { }
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
    public partial class DoubleProgressbarWindow : Form
    {
        protected override void OnHandleCreated(EventArgs e)
        {
            if (Util.DwmSetWindowAttribute(Handle, 19, new[] { 1 }, 4) != 0)
                Util.DwmSetWindowAttribute(Handle, 20, new[] { 1 }, 4);
        }
    }
    public partial class ExportForm : Form
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

        public static PointF AddPoints(PointF p1, PointF p2) => new PointF(p1.X + p2.X, p1.Y + p2.Y);

        // Rotation transformation single
        public static PointF RotTransformPoint(PointF point, float alpha)
        {
            return new PointF
            {
                X = point.X * degCos(alpha) - point.Y * degSin(alpha),
                Y = point.Y * degCos(alpha) + point.X * degSin(alpha)
            };
        }
        public static LineF RotTransformLine(LineF line, float alpha)
        {
            return new LineF
            {
                StartPoint = RotTransformPoint(line.StartPoint, alpha),
                EndPoint = RotTransformPoint(line.EndPoint, alpha)
            };
        }

        // Rotation transformation array
        public static List<PointF> RotTransformPoints(List<PointF> points, float alpha)
        {
            List<PointF> outputPoints = new List<PointF>();

            foreach (PointF p in points)
            {
                outputPoints.Add(RotTransformPoint(p, alpha));
            }

            return outputPoints;
        }
        public static List<LineF> RotTransformLines(List<LineF> lines, float alpha)
        {
            List<LineF> outputLines = new List<LineF>();

            foreach (LineF line in lines)
            {
                outputLines.Add(RotTransformLine(line, alpha));
            }

            return outputLines;
        }

        // Position transformation array
        public static List<PointF> PosTransformPoints(List<PointF> points, PointF transformVec)
        {
            List<PointF> outputPoints = new List<PointF>();

            foreach (PointF p in points)
            {
                outputPoints.Add(AddPoints(p, transformVec));
            }

            return outputPoints;
        }
        public static List<LineF> PosTransformLines(List<LineF> lines, PointF transformVec)
        {
            List<LineF> outputLines = new List<LineF>();

            foreach (LineF line in lines)
            {
                outputLines.Add(new LineF(AddPoints(line.StartPoint, transformVec), AddPoints(line.EndPoint, transformVec)));
            }

            return outputLines;
        }

        // Position & rotation transformation single
        public static PointF RotPosTransformPoint(PointF point, PointF transformVec, float alpha)
        {
            return new PointF
            {
                X = transformVec.X + point.X * degCos(alpha) - point.Y * degSin(alpha),
                Y = transformVec.Y + point.Y * degCos(alpha) + point.X * degSin(alpha)
            };
        }
        public static LineF RotPosTransformLine(LineF line, PointF transformVec, float alpha)
        {
            return new LineF
            {
                StartPoint = RotPosTransformPoint(line.StartPoint, transformVec, alpha),
                EndPoint = RotPosTransformPoint(line.EndPoint, transformVec, alpha)
            };
        }

        // Position & rotation transformation array
        public static List<PointF> RotPosTransformPoints(List<PointF> points, PointF transformVec, float alpha)
        {
            List<PointF> outputPoints = new List<PointF>();

            foreach (PointF p in points)
            {
                outputPoints.Add(RotPosTransformPoint(p, transformVec, alpha));
            }

            return outputPoints;
        }
        public static List<LineF> RotPosTransformLines(List<LineF> lines, PointF transformVec, float alpha)
        {
            List<LineF> outputLines = new List<LineF>();

            foreach (LineF line in lines)
            {
                outputLines.Add(RotPosTransformLine(line, transformVec, alpha));
            }

            return outputLines;
        }

        // Scale & position transformation single
        public static PointF ScalePosTransformPoint(PointF point, PointF transformVec, float scaleFactor)
        {
            return new PointF
            {
                X = transformVec.X + point.X * scaleFactor,
                Y = transformVec.Y + point.Y * scaleFactor
            };
        }
        public static LineF ScalePosTransformLine(LineF line, PointF transformVec, float scaleFactor)
        {
            return new LineF
            {
                StartPoint = ScalePosTransformPoint(line.StartPoint, transformVec, scaleFactor),
                EndPoint = ScalePosTransformPoint(line.EndPoint, transformVec, scaleFactor)
            };
        }

        // Scale & position transformation array
        public static List<PointF> ScalePosTransformPoints(List<PointF> points, PointF transformVec, float scaleFactor)
        {
            List<PointF> outputPoints = new List<PointF>();

            foreach (PointF p in points)
            {
                outputPoints.Add(ScalePosTransformPoint(p, transformVec, scaleFactor));
            }

            return outputPoints;
        }
        public static List<LineF> ScalePosTransformLines(List<LineF> lines, PointF transformVec, float scaleFactor)
        {
            List<LineF> outputLines = new List<LineF>();

            foreach (LineF line in lines)
            {
                outputLines.Add(ScalePosTransformLine(line, transformVec, scaleFactor));
            }

            return outputLines;
        }

        public static float degSin(float x)
        {
            return (float)Math.Sin(x * Math.PI / 180.0f);
        }
        public static float degCos(float x)
        {
            return (float)Math.Cos(x * Math.PI / 180.0f);
        }
    }
}
