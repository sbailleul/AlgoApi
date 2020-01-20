using System.Collections.Generic;
using System.Linq;
using AlgoApi.Core.PathFinding;
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
        public ActionResult<List<int[]>> Dijkstra([FromServices] PathFinderService<Dijkstra> pathFinderService, ShortestPathRequest shortestPathRequest)
        {
            return CalculateShortestPath(shortestPathRequest, pathFinderService);
        }

        [Route("[action]")]
        [HttpPost]
        public ActionResult<List<int[]>> AStar([FromServices] PathFinderService<AStar> pathFinderService, ShortestPathRequest shortestPathRequest)
        {
            return CalculateShortestPath(shortestPathRequest, pathFinderService);
        }

        private ActionResult<List<int[]>> CalculateShortestPath<T>(ShortestPathRequest shortestPathRequest, PathFinderService<T> pathFinderService) where T : PathFinder
        {
            var shortestPath = pathFinderService.GetShortestPath(shortestPathRequest);
            if (shortestPath == null) return NoContent();
            return shortestPath.ToList();
        }
    }
}