using System;
using System.Diagnostics;

namespace DC.SpiroGraph.Core
{
    [DebuggerDisplay("X = {X}, Y = {Y}")]
    public class Point 
    {
        public double X { get; set; }
        public double Y { get; set; }

        
        public bool NotAboutEqualTo(Point point)
        {
            return !DoubleExtension.AboutEqual(X, point.X) && !DoubleExtension.AboutEqual(Y, point.Y);
        }
    }
}