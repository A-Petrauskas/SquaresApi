using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Repositories.Models
{
    public class Squares
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement]
        public int squareCount { get; set; }

        [BsonElement]
        public bool squareUniqueness { get; set; }

        [BsonElement]
        public List<string> points { get; set; }

        [BsonElement]
        public List<List<string>> squares { get; set; }

        //Potentially more properties that should not be returned to user
    }
}