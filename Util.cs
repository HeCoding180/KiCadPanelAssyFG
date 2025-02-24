using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
