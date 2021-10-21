using System.Collections.Generic;
using System.Drawing;

namespace Services.Contracts
{
    public class SquaresContract
    {
        public int squareCount { get; set; }

        public List<Point[]> squares { get; set; }
    }
}