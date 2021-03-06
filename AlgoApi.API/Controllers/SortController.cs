﻿using System.Collections.Generic;
using System.Linq;
using AlgoApi.Core.PathFinding;
using AlgoApi.Core.Sorting;
using AlgoApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace AlgoApi.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SortController : ControllerBase
    {
        [Route("[action]")]
        [HttpPost]
        public ActionResult<List<string[]>> NaiveSearch([FromServices] SorterService<NaiveSearch<string>,string> naiveSearch,
            SortRequest<string> sortRequest)
        {
            return naiveSearch.SortMatrix(sortRequest.Matrix.ToArray()).ToList();
        }

        [Route("[action]")]
        [HttpPost]
        public ActionResult<List<string[]>> SimulatedAnnealing(
            [FromServices] SorterService<SimulatedAnnealing<string>,string> simulatedAnnealing, SortRequest<string> sortRequest)
        {
            return simulatedAnnealing.SortMatrix(sortRequest.Matrix.ToArray()).ToList();
        }

        [Route("[action]")]
        [HttpPost]
        public ActionResult<List<string[]>> GeneticAlgorithm(
            [FromServices] SorterService<GeneticAlgorithm<string>,string> geneticAlgorithm, SortRequest<string> sortRequest)
        {
            return geneticAlgorithm.SortMatrix(sortRequest.Matrix.ToArray()).ToList();
        }
    }
}