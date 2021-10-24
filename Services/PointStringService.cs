using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;

namespace Services
{
    public class PointStringService
    {
        public Point[] ConvertStringToPoint(string squareString)
        {
            var allPoints = new List<Point>();

            var regex = new Regex(@"[[\]\()]");

            var pointsNoBrackets = regex.Replace(squareString, "").Split(",");

            foreach (var pointString in pointsNoBrackets)
            {
                var point = new Point()
                {
                    X = Int32.Parse(pointString.Replace(" ", "").Split(";")[0]),
                    Y = Int32.Parse(pointString.Replace(" ", "").Split(";")[1])
                };

                allPoints.Add(point);
            }

            return allPoints.ToArray();
        }

        public List<List<string>> ConvertPointToString(List<Point[]> squares)
        {
            var allSquares = new List<List<string>>();

            foreach (var points in squares)
            {
                var square = new List<string>();

                foreach (var point in points)
                {
                    var pointString = $"({point.X};{point.Y})";
                    square.Add(pointString);
                }

                allSquares.Add(square);
            }

            return allSquares;
        }

        public List<string> ConvertStringToListPoints(string points)
        {
            var regex = new Regex(@"[[\]]");

            var allPoints = regex.Replace(points.Replace(" ", ""), "").Split(",");

            return allPoints.ToList();
        }
    }
}