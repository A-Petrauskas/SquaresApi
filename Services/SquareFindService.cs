using System.Collections.Generic;
using System.Drawing;

namespace Services
{
    public class SquareFindService
    {
        // This method will get all possible squares (points can be reused)
        public List<Point[]> GetAllSquares(Point[] input)
        {
            var allSquares = new List<Point[]>();

            HashSet<Point> set = new HashSet<Point>();
            foreach (var point in input)
                set.Add(point);

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input.Length; j++)
                {
                    if (i == j)
                        continue;

                    Point[] DiagVertex = GetRestPoints(input[i], input[j]);
                    if (set.Contains(DiagVertex[0]) && set.Contains(DiagVertex[1]))
                    {
                        var square = new Point[]
                        {
                            input[i], input[j],
                            DiagVertex[0], DiagVertex[1]
                        };

                        allSquares.Add(square);
                    }
                }
            }

            return allSquares;
        }

        private Point[] GetRestPoints(Point a, Point c)
        {
            Point[] res = new Point[2];

            int midX = (a.X + c.X) / 2;
            int midY = (a.Y + c.Y) / 2;

            int Ax = a.X - midX;
            int Ay = a.Y - midY;
            int bX = midX - Ay;
            int bY = midY + Ax;
            Point b = new Point(bX, bY);

            int cX = (c.X - midX);
            int cY = (c.Y - midY);
            int dX = midX - cY;
            int dY = midY + cX;
            Point d = new Point(dX, dY);

            res[0] = b;
            res[1] = d;
            return res;
        }
    }
}