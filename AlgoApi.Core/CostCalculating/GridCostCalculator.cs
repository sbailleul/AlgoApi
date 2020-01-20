using System;
using System.Collections.Generic;
using System.Linq;
using AlgoApi.Core.HeuristicHandling;
using AlgoApi.Core.MatrixGenerating;
using AlgoApi.Core.MatrixHandling;
using AlgoApi.Models.Graph;
using Microsoft.VisualBasic.CompilerServices;

namespace AlgoApi.Core.CostCalculating
{
    public class GridCostCalculator: ICostCalculator
    {
        private HeuristicGridDistance _gridDistance { get; }
        private int[][] _positionMask { get; }
        
        public GridCostCalculator(Matrix4DGenerator matrixGenerator, ManhattanGridDistance gridDistance)
        {
            _gridDistance = gridDistance;
            _positionMask = matrixGenerator.GetMatrix(1);
        }
        public GridCostCalculator(Matrix8DGenerator matrixGenerator, DiagonalDistance gridDistance)
        {
            _gridDistance = gridDistance;
            _positionMask = matrixGenerator.GetMatrix(1);
        }

        /// <summary>
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

            foreach (var mask in _positionMask)
            {
                //Select neighbour node of min node 
                var updatedNode = nodes.FirstOrDefault(node =>
                    node.Position.SequenceEqual(mask.Zip(min.Position, (a, b) => a + b)));

                if (updatedNode == null) continue;
                var tmpCost = min.Cost + matrix[updatedNode.Position[0]][updatedNode.Position[1]];
                updatedNode.Heuristic =
                    _gridDistance.GetHeuristic(updatedNode.Position, destinationPosition,1);
                if (updatedNode.Cost < tmpCost) continue;
                updatedNode.Cost = tmpCost;
                updatedNode.Parent = min;
            }
        }
    }
    
}