using Repositories.Models;
using Services.Entities;
using System.Collections.Generic;

namespace Services
{
    public class ModelEntityConverter
    {
        //Need to transition to some object auto mapper
        public List<SquaresEntity> ConvertModelToEntity(List<Squares> squares)
        {
            var allSquaresEntities = new List<SquaresEntity>();

            foreach (var square in squares)
            {
                var squareEntity = new SquaresEntity()
                {
                    squareCount = square.squareCount,
                    squares = square.squares,
                    squareUniqueness = square.squareUniqueness,
                    Id = square.Id,
                    points = square.points
                };

                allSquaresEntities.Add(squareEntity);
            }

            return allSquaresEntities;
        }

        public SquaresEntity ConvertModelToEntity(Squares squares)
        {
            var squareEntity = new SquaresEntity()
            {
                squareCount = squares.squareCount,
                squares = squares.squares,
                squareUniqueness = squares.squareUniqueness,
                Id = squares.Id,
                points = squares.points
            };

            return squareEntity;
        }
    }
}
