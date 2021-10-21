using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
            return new string[] {  };
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