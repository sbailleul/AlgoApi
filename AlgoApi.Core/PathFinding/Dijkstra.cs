using System.Collections.Generic;
using AlgoApi.Core.CostCalculating;
using AlgoApi.Core.NodeHandling;
using AlgoApi.Models.Graph;

namespace AlgoApi.Core.PathFinding
{
    public class Dijkstra : PathFinder
    {
        public Dijkstra(GraphNodeHandler nodeHandler, GraphCostCalculator costCalculator) : base(nodeHandler, costCalculator)
        {
        }

        public override List<int[]> FindShortestPath(int[][] matrix, int[] startVector, int[] endVector)
        {
            var end = endVector[0];
            Node min;
            NodeHandler.InitNodes(out var doneNodes, out var nodes, matrix);
            NodeHandler.SetStartNode(nodes, startVector);
            do
            {
                min = NodeHandler.GetMinimalCostNode(nodes, doneNodes);

                if (min.Position[0] == end) break;
                CostCalculator.UpdateNodesCost(nodes, matrix, min);
            } while (nodes.Count > 0 && min.Position[0] != end);

            return NodeHandler.GetShortestPath(doneNodes, startVector, endVector);
        }
    }
}