using System.Collections.Generic;
using System.Drawing;

namespace Services
{
    public class SquareFindService
    {
        public int SquareCount(Point[] input)
        {
            int count = 0;

            HashSet<Point> set = new HashSet<Point>();
            foreach (var point in input)
                set.Add(point);

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input.Length; j++)
                {
                    if (i == j)
                        continue;

                    Point[] DiagVertex = GetRestPints(input[i], input[j]);
                    if (set.Contains(DiagVertex[0]) && set.Contains(DiagVertex[1]))
                    {
                        count++;
                    }
                }
            }
            return count;

        }

        private Point[] GetRestPints(Point a, Point c)
        {
            Point[] res = new Point[2];

            int midX = (a.X + c.Y) / 2;
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