using System.Collections.Generic;
using System.Linq;
using AlgoApi.Core.CostCalculating;
using AlgoApi.Core.NodeHandling;
using AlgoApi.Models.Graph;

namespace AlgoApi.Core.PathFinding
{
    public class AStar : PathFinder
    {
        // protected override NodeHandler NodeHandler { get; set; } = new GridNodeHandler();
        // private CostCalculator CostCalculator { get; } = new CostCalculator(new GridCostCalculator());

        public AStar(GridNodeHandler nodeHandler, GridCostCalculator costCalculator) : base(nodeHandler, costCalculator)
        {
        }

        public override List<int[]> FindShortestPath(int[][] matrix, int[] startVector, int[] endVector)
        {
            Node min;
            NodeHandler.InitNodes(out var doneNodes, out var nodes, matrix);
            NodeHandler.SetStartNode(nodes, startVector);
            do
            {
                min = NodeHandler.GetMinimalCostNode(nodes, doneNodes);

                if (min.Position.SequenceEqual(endVector)) break;
                CostCalculator.UpdateNodesCost(nodes, matrix, min, endVector);
            } while (nodes.Count > 0 && !min.Position.SequenceEqual(endVector));


            return NodeHandler.GetShortestPath(doneNodes, startVector, endVector);
        }
    }
}