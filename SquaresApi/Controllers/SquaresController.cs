using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Services;

namespace SquaresApi.Controllers
{
    [Route("[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class SquaresController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var stringTemp = @"[(-1;1), (1;1), (1;-1), (-1;-1)]";

            var points = new PointConvertService().ConvertStringToPoint(stringTemp);

            var rez = new SquareFindService().GetAllSquares(points);

            return new string[] { rez.Count.ToString() };
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