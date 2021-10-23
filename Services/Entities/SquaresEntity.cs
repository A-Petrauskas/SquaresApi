using System.Collections.Generic;

namespace Services.Entities
{
    public class SquaresEntity
    {
        public string Id { get; set; }

        public int squareCount { get; set; }

        public bool squareUniqueness { get; set; }

        public List<List<string>> squares { get; set; }
    }
}