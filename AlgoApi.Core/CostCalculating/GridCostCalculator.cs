using System;
using System.Collections.Generic;
using System.Linq;
using AlgoApi.Core.HeuristicHandling;
using AlgoApi.Core.MatrixHandling;
using AlgoApi.Models.Graph;

namespace AlgoApi.Core.NodeHandling
{
    public class GridCostCalculator:IGridCostCalculator
    {
        private IHeuristicCalculator HeuristicCalculator { get; set; } = new HeuristicCalculator();
        private int[][] PositionMask { get; set; } = new MatrixHandler().GetMatrixMask(1);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="matrix"></param>
        /// <param name="min"></param>
        /// <param name="destinationPosition"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void UpdateNodesCost(List<Node> nodes, int[][] matrix, Node min, int[] destinationPosition)
        {
            if (matrix == null) throw new ArgumentNullException(nameof(matrix));
                if (min == null) throw new ArgumentNullException(nameof(min));
            
                foreach (var mask in PositionMask)
                {
                    //Select neighbour node of min node 
                    var updatedNode = nodes.FirstOrDefault(node =>
                        node.Position.SequenceEqual(mask.Zip(min.Position, (a, b) => a + b)));
                
                    if (updatedNode == null) continue;
                    var tmpCost = min.Cost + matrix[updatedNode.Position[0]][updatedNode.Position[1]];
                    updatedNode.Heuristic =
                        HeuristicCalculator.CalculateManhattanDistance(updatedNode.Position, destinationPosition);
                    if (updatedNode.Cost < tmpCost) continue;
                    updatedNode.Cost = tmpCost;
                    updatedNode.Parent = min;
                }

        }
    }
}