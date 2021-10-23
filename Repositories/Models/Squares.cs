using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Repositories.Entities
{
    public class Squares
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement]
        public List<List<string>> points { get; set; }

        [BsonElement]
        public int squareCount { get; set; }

        [BsonElement]
        public bool squareUniqueness { get; set; }
    }
}