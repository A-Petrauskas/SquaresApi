﻿using Microsoft.AspNetCore.Mvc;
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

        [HttpPost("points/{square-uniq}")]
        public SquaresEntity Post([FromBody] string points, int squareUniqueness)
        {
            var newSquares = _squaresService.CreateSquares(points, squareUniqueness);

            return newSquares;
        }

        [HttpPut("{id}/points/{points}")]
        public void Put(string id, string points)
        {
        }

        [HttpDelete("{id}/points/{points}")]
        public void Delete(string id, string points)
        {
        }
    }
}