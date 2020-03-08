using System;

namespace DC.SpiroGraph.Core
{
    public static class DoubleExtension
    {
        public static bool AboutEqual(double x, double y)
        {
            double epsilon = Math.Max(Math.Abs(x), Math.Abs(y)) * 1E-15;
            
            var variance = x > y ? x - y : y - x;
            return Math.Abs(variance) <= epsilon;
        }
    }
}