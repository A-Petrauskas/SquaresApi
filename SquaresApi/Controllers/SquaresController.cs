using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Entities;
using System.Collections.Generic;

namespace SquaresApi.Controllers
{
    [Route("squares")]
    [Produces("application/json")]
    [ApiController]
    public class SquaresController : ControllerBase
    {
        private readonly SquaresService _squaresService;
        public SquaresController(SquaresService squaresService)
        {
            _squaresService = squaresService;
        }


        [HttpGet]
        public ActionResult<List<SquaresEntity>> Get()
        {
            var allSquares = _squaresService.GetAllSquares();

            return allSquares;
        }

        [HttpGet("{id}")]
        public SquaresEntity Get(string id)
        {
            var squaresById = _squaresService.GetSquaresById(id);

            return squaresById;
        }

        [HttpGet("points/{points}")]
        public List<SquaresEntity> GetByPoints(string points)
        {
            var squaresByPoints = _squaresService.GetSquaresByPoints(points);

            return squaresByPoints;
        }

        [HttpPost("points/{square-uniq}")]
        public SquaresEntity Post([FromBody] string points, int squareUniqueness)
        {
            var newSquares = _squaresService.CreateSquares(points, squareUniqueness);

            return newSquares;
        }

        [HttpPut("{id}/points/{points}")]
        public SquaresEntity Put(string id, string points)
        {
            var newSquares = _squaresService.UpdateSquares(id, points);

            return newSquares;
        }

        [HttpDelete("{id}/points/{points}")]
        public SquaresEntity Delete(string id, string points)
        {
            var newSquares = _squaresService.DeletePoint(id, points);

            return newSquares;
        }
    }
}