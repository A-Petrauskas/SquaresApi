using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;

namespace Services
{
    public class PointConvertService
    {
        public Point[] ConvertStringToPoint(string squareString)
        {
            var allPoints = new List<Point>();

            var regex = new Regex(@"[\[\]\(\)\ ]");

            var pointsNoBrackets = regex.Replace(squareString, "").Split(",");

            foreach (var pointString in pointsNoBrackets)
            {
                var point = new Point()
                {
                    X = Int32.Parse(pointString.Split(";")[0]),
                    Y = Int32.Parse(pointString.Split(";")[1])
                };

                allPoints.Add(point);
            }

            return allPoints.ToArray();
        }
    }
}