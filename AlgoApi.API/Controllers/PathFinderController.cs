using System.Collections.Generic;
using System.Linq;
using AlgoApi.Core.PathFinding.Interfaces;
using AlgoApi.Models.Graph;
using Microsoft.AspNetCore.Mvc;

namespace AlgoApi.API.Controllers
{
    // GET
    [Route("[controller]")]
    [ApiController]
    public class PathFinderController : ControllerBase
    {
        [Route("[action]")]
        [HttpPost]
        public ActionResult<List<int[]>> Dijkstra([FromServices] IDijkstra dijkstra, GraphRequest graphRequest)
        {
            return CalculateShortestPath(graphRequest, dijkstra);
        }

        [Route("[action]")]
        [HttpPost]
        public ActionResult<List<int[]>> AStar([FromServices] IAStar aStar, GraphRequest graphRequest)
        {
            return CalculateShortestPath(graphRequest, aStar);
        }

        private ActionResult<List<int[]>> CalculateShortestPath(GraphRequest graphRequest, IPathFinder pathFinder)
        {
            var shortestPath =
                pathFinder.FindShortestPath(graphRequest.Matrix.ToArray(), graphRequest.StartVector, graphRequest.EndVector);
            if (shortestPath == null) return NoContent();
            return shortestPath.ToList();
        }
    }
}