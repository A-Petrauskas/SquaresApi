using System.Collections.Generic;
using System.Drawing;

namespace Services.Contracts
{
    public class SquaresContract
    {
        public int squareCount { get; set; }

        public List<List<string>> squares { get; set; }
    }
}