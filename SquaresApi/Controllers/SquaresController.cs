using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Contracts;

namespace SquaresApi.Controllers
{
    [Route("[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class SquaresController : ControllerBase
    {
        [HttpGet]
        public ActionResult<SquaresContract> Get()
        {
            var stringTemp = @"[(-1;1), (1;1), (1;-1), (-1;-1)]";

            var points = new PointConvertService().ConvertStringToPoint(stringTemp);

            var rez = new SquareFindService().GetAllSquares(points);

            var response = new SquaresContract()
            {
                squareCount = rez.Count,

                squares = rez
            };

            return response;
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