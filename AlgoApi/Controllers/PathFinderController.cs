using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using AlgoApi.Models;
using AlgoApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace TodoApi.Controllers
{
    // GET
    [Route("[controller]")]
    [ApiController]
    public class PathFinderController : ControllerBase
    {
        [Route("[action]")]
        [HttpPost]
        public ActionResult<List<List<int>>> Dijkstra([FromServices] IDijkstra dijkstra,GraphRequest graphRequest)
        {
            return CalculateShortestPath(graphRequest, dijkstra);
        }
        
        [Route("[action]")]
        [HttpPost]
        public ActionResult<List<List<int>>> AStar([FromServices] IAStar aStar, GraphRequest graphRequest)
        {
            return CalculateShortestPath(graphRequest, aStar);
        }

        private ActionResult<List<List<int>>> CalculateShortestPath(GraphRequest graphRequest, IPathFinder pathFinder)
        {
            var shortestPath = pathFinder.FindShortestPath(graphRequest.Matrix, graphRequest.StartVector, graphRequest.EndVector);
            if (shortestPath == null) return NoContent();
            return shortestPath;
        }
        
    }
}