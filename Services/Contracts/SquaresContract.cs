using System.Collections.Generic;

namespace Services.Contracts
{
    public class SquaresContract
    {
        public int squareCount { get; set; }

        public bool squareUniqueness { get; set; }

        public List<List<string>> squares { get; set; }
    }
}