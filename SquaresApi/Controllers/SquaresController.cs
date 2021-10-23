using Microsoft.AspNetCore.Mvc;
using Repositories;
using Repositories.Entities;
using Services;
using Services.Contracts;
using System.Collections.Generic;

namespace SquaresApi.Controllers
{
    [Route("[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class SquaresController : ControllerBase
    {
        private readonly SquaresRepository _squaresRepository;
        public SquaresController(SquaresRepository squaresRepository)
        {
            _squaresRepository = squaresRepository;
        }


        [HttpGet]
        public ActionResult<List<Squares>> Get()
        {
            var stringTemp = @"[(-1;1), (1;1), (1;-1), (-1;-1)]";

            var points = new PointPrettyStringService().ConvertStringToPoint(stringTemp);

            var rez = new SquareFindService().GetAllSquares(points);

            var response = new SquaresContract()
            {
                squareCount = rez.Count,

                squares = new PointPrettyStringService().ConvertPointToString(rez),

                squareUniqueness = false
            };

            return _squaresRepository.Get();
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}