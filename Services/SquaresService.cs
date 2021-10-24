using Repositories;
using Repositories.Models;
using Services.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class SquaresService
    {
        private readonly SquaresRepository _squaresRepository;
        private readonly ModelEntityConverter _modelEntityConverter;
        private readonly PointStringService _pointStringService;
        private readonly SquareFindService _squareFindService;

        public SquaresService(SquaresRepository squaresRepository, ModelEntityConverter modelEntityConverter,
            PointStringService pointStringService, SquareFindService squareFindService)
        {
            _squaresRepository = squaresRepository;
            _modelEntityConverter = modelEntityConverter;
            _pointStringService = pointStringService;
            _squareFindService = squareFindService;
        }

        public List<SquaresEntity> GetAllSquares()
        {
            var allSquaresModel = _squaresRepository.Get();

            var allSquaresEntities = _modelEntityConverter.ConvertModelToEntity(allSquaresModel);

            return allSquaresEntities;
        }

        public SquaresEntity GetSquaresById(string id)
        {
            var squaresModel = _squaresRepository.Get(id);

            var squaresEntity = _modelEntityConverter.ConvertModelToEntity(squaresModel);

            return squaresEntity;
        }

        public List<SquaresEntity> GetSquaresByPoints(string points)
        {
            var pointsList = _pointStringService.ConvertStringToListPoints(points);

            var squaresModels = _squaresRepository.GetByPoints(pointsList);

            var squaresEntities = new List<SquaresEntity>();

            foreach (var squaresModel in squaresModels)
            {
                squaresEntities.Add(_modelEntityConverter.ConvertModelToEntity(squaresModel));
            }

            return squaresEntities;
        }

        public SquaresEntity CreateSquares(string squaresInPoints, int squareUniq)
        {
            var squareUniqueBool = false;

            if (squareUniq == 1)
                squareUniqueBool = true;

            var points = _pointStringService.ConvertStringToPoint(squaresInPoints);

            if (points.Length < 4) //doesnt even try to find squares when there is less than 4 points
            {
                var newSquaresModelEmpty = new Squares()
                {
                    squareCount = 0,
                    squareUniqueness = squareUniqueBool,
                    points = _pointStringService.ConvertStringToListPoints(squaresInPoints),
                    squares = new List<List<string>>()
                };

                _squaresRepository.Create(newSquaresModelEmpty);

                var squaresEntityEmpty = _modelEntityConverter.ConvertModelToEntity(newSquaresModelEmpty);

                return squaresEntityEmpty;
            }


            var squaresFound = _squareFindService.GetAllSquares(points);

            var newSquares = new Squares()
            {
                squareCount = squaresFound.Count,
                squareUniqueness = squareUniqueBool,
                points = _pointStringService.ConvertStringToListPoints(squaresInPoints),
                squares = _pointStringService.ConvertPointToString(squaresFound)
            };

            _squaresRepository.Create(newSquares);

            var squaresEntity = _modelEntityConverter.ConvertModelToEntity(newSquares);

            return squaresEntity;
        }

        public SquaresEntity UpdateSquares(string id, string newPoints)
        {
            var squaresModel = _squaresRepository.Get(id);
            var squaresEntity = _modelEntityConverter.ConvertModelToEntity(squaresModel);

            return null;
        }

        public SquaresEntity DeletePoints (string id, string points)
        {
            var squaresModel = _squaresRepository.Get(id);
            var squaresEntity = _modelEntityConverter.ConvertModelToEntity(squaresModel);
            var pointsString = _pointStringService.ConvertStringToListPoints(points);
            var newPointsString = squaresEntity.points.Except(pointsString).ToList();

            if (newPointsString.Count < 4) //doesnt even try to find squares when there is less than 4 points
            {
                var newSquaresModelEmpty = new Squares()
                {
                    Id = squaresEntity.Id,
                    squareCount = 0,
                    squareUniqueness = squaresEntity.squareUniqueness,
                    points = newPointsString,
                    squares = new List<List<string>>()
                };

                _squaresRepository.Update(id, newSquaresModelEmpty);

                return _modelEntityConverter.ConvertModelToEntity(newSquaresModelEmpty);
            }

            var newPoints = _pointStringService.ConvertStringToPoint(string.Join(",", newPointsString));
            var newSquares = _squareFindService.GetAllSquares(newPoints);
            //Check uniqueness

            var newSquaresModel = new Squares()
            {
                Id = squaresEntity.Id,
                squareCount = newSquares.Count,
                squareUniqueness = squaresEntity.squareUniqueness,
                points = newPointsString,
                squares = _pointStringService.ConvertPointToString(newSquares)
            };

            _squaresRepository.Update(id, newSquaresModel);

            return _modelEntityConverter.ConvertModelToEntity(newSquaresModel);
        }

        public void DeleteById(string id)
        {
            _squaresRepository.Remove(id);
        }
    }
}