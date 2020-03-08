using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DC.SpiroGraph.Core
{
    public class SpiroGraphGenerator
    {
        /// <summary>
        /// Radius, R, of Circle (equator) centered at the origin
        /// </summary>
        public double Radius1 { get; set; }

        /// <summary>
        /// Radius, r, of circle (bicyle wheel) cetered at (R + r, 0)
        /// </summary>
        public double Radius2 { get; set; }

        /// <summary>
        /// Distance of Point (reflector) from the center of Circle 2 (the circle of Radius2)
        /// </summary>
        public double Position { get; set; }

        /// <summary>
        /// Controls how precise the SpiroGraph is drawn.
        /// Controls t of f(t).
        /// Resolution = 360, t = 0, 1, 2, 3, ...,360
        /// Resolution = 180, t = 0, 2, 4, 6, ... 360
        /// 
        /// </summary>
        public double Resolution { get; set; }

        public IEnumerable<Point>  GetSpiroGraphPoints()
        {

            var t = 0d;
            var sumOfRadius = Radius1 + Radius2;

            var firstPoint = new Point { X = Xt(sumOfRadius, Radius2, Position, t), Y = Yt(sumOfRadius, Radius2, Position, t) };
            var currentPoint = new Point { X = firstPoint.X, Y = firstPoint.Y };

            // Convert to Radians
            var increment = (360 / Resolution) * Math.PI / 180;

            do
            {
                for (var i = 0; i < Resolution; i++)
                {
                    yield return currentPoint;
                    t += increment;
                    currentPoint = new Point { X = Xt(sumOfRadius, Radius2, Position, t), Y = Yt(sumOfRadius, Radius2, Position, t) };
                }
            } while (currentPoint.NotAboutEqualTo(firstPoint));
            
            yield return currentPoint;
        }

        public IEnumerable<Point> GetSpiroGraphPoints2()
        {
            var endPoints = FindAllEndPoints();
            var numberOfEndPonits = endPoints.Count();
            var numberOfPoints = Convert.ToInt32((numberOfEndPonits - 1)*Resolution + 1);
            var points = new Point[numberOfPoints];
            var resolution = Convert.ToInt32(Resolution);

            var sumOfRadius = Radius1 + Radius2;

            // Convert to Radians
            var increment = (360/Resolution)*Math.PI/180;
            points[0] = GetPoint(sumOfRadius, 0);

            Parallel.For(1, numberOfEndPonits, i =>
                                                   {
                                                       for (var j = 0; j < resolution; j++)
                                                       {
                                                           var pointIndex = (i - 1)*resolution + j + 1;
                                                           var t = pointIndex*increment;
                                                           points[pointIndex] = GetPoint(sumOfRadius, t);
                                                       }
                                                   });
            return points;
        }
        
        public IEnumerable<Point> GetSpiroGraphPoints3()
        {
            var endPoints = FindAllEndPoints();
            var numberOfEndPonits = endPoints.Count();
            var numberOfPoints = Convert.ToInt32((numberOfEndPonits - 1)*Resolution + 1);

            var sumOfRadius = Radius1 + Radius2;

            // Convert to Radians
            var increment = (360/Resolution)*Math.PI/180;

            var points2 = Enumerable.Range(0, numberOfPoints)
                .Select(i => new {Index = i, t = i*increment})
                .Select(it => new {it.Index, point = GetPoint(sumOfRadius, it.t)})
                .OrderBy(ip => ip.Index)
                .Select(ip => ip.point);

            return points2;
        }

        public IEnumerable<Point> FindAllEndPoints()
        {
            var t = 0d;
            var sumOfRadius = CalculateSumOfRadius();

            var firstPoint = GetPoint(sumOfRadius, t);
            var currentPoint = new Point { X = firstPoint.X, Y = firstPoint.Y };
            // Convert to Radians
            var increment = CalculateIncrement();

            do
            {
                yield return currentPoint;
                t += (increment*Resolution);
                currentPoint = GetPoint(sumOfRadius, t);
            } while (currentPoint.NotAboutEqualTo(firstPoint));

            yield return currentPoint;
        }

        private double CalculateIncrement()
        {
            return (360/Resolution)*Math.PI/180;
        }

        private double CalculateSumOfRadius()
        {
            return Radius1 + Radius2;
        }

        private static double Xt(double sumOfRadius, double radius2, double position , double t)
        {
            return sumOfRadius * Math.Cos(t) + position * Math.Cos(sumOfRadius * t / radius2);
        }

        private static double Yt(double sumOfRadius, double radius2, double position, double t)
        {
            return sumOfRadius * Math.Sin(t) + position * Math.Sin(sumOfRadius * t / radius2);
        }

        private Point GetPoint(double sumOfRadius, double t)
        {
            return new Point { X = Xt(sumOfRadius, Radius2, Position, t), Y = Yt(sumOfRadius, Radius2, Position, t) };
        }
    }
}
