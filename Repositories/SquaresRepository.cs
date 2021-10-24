using MongoDB.Driver;
using Repositories.Models;
using System.Collections.Generic;

namespace Repositories
{
    public class SquaresRepository
    {
         private readonly IMongoCollection<Squares> _squares;

        public SquaresRepository(ISquaresDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _squares = database.GetCollection<Squares>(settings.SquaresCollectionName);
        }

        public List<Squares> Get() =>
            _squares.Find(squares => true).ToList();

        public Squares Get(string id) =>
            _squares.Find<Squares>(squares => squares.Id == id).FirstOrDefault();

        public Squares Create(Squares squares)
        {
            _squares.InsertOne(squares);
            return squares;
        }

        public void Update(string id, Squares squaresIn) =>
            _squares.ReplaceOne(squares => squares.Id == id, squaresIn);

        public void Remove(string id) =>
            _squares.DeleteOne(squares => squares.Id == id);
    }
}
