using System.Collections.Generic;
using AlgoApi.Core.CostCalculating;
using AlgoApi.Core.NodeHandling;

namespace AlgoApi.Core.PathFinding
{
    public  abstract class PathFinder
    {
        protected  NodeHandler NodeHandler { get; set; }
        protected  ICostCalculator CostCalculator { get; }

        protected PathFinder(NodeHandler nodeHandler, ICostCalculator costCalculator)
        {
            NodeHandler = nodeHandler;
            CostCalculator = costCalculator;
        }

        public abstract List<int[]> FindShortestPath(int[][] matrix, int[] startVector, int[] endVector);

    }
}