using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiCad_Panel_Assembly_Files_Generator
{
    // Custom Exceptions
    public class ArgumentDataException : Exception
    {
        public ArgumentDataException() { }

        public ArgumentDataException(string message) : base(message) { }

        public ArgumentDataException(string message, Exception inner) : base(message, inner) { }
    }
    
    // Custom Enums
    public enum PlacementPosition
    {
        Undef,
        Top,
        Bottom
    }
}
