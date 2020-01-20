using System.Collections.Generic;
using AlgoApi.Models.Graph;

namespace AlgoApi.Core.PathFinding
{
    public class PathFinderService<T>where T: PathFinder
    {
        private readonly PathFinder _pathFinder;
        
        public PathFinderService(T pathFinder)
        {
            _pathFinder = pathFinder;
        }

        public List<int[]> GetShortestPath(ShortestPathRequest shortestPathRequest)
        {
            return _pathFinder.FindShortestPath(shortestPathRequest.Matrix.ToArray(),shortestPathRequest.StartVector, shortestPathRequest.EndVector);
        }
    }
}