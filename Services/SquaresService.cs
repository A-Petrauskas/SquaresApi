using Repositories;
using Repositories.Models;
using Services.Entities;
using System.Collections.Generic;

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

        public SquaresEntity CreateSquares(string squares, int squareUniq)
        {
            var points = _pointStringService.ConvertStringToPoint(squares);
            var squaresFound = _squareFindService.GetAllSquares(points);
            var squareUniqueBool = false;

            if (squareUniq == 1)
                squareUniqueBool = true;

            var newSquares = new Squares()
            {
                squareCount = squaresFound.Count,
                squareUniqueness = squareUniqueBool,
                squares = _pointStringService.ConvertPointToString(squaresFound)
            };

            _squaresRepository.Create(newSquares);

            var squaresEntity = _modelEntityConverter.ConvertModelToEntity(newSquares);

            return squaresEntity;
        }
    }
}