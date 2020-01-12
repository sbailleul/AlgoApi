using System;
using System.Collections.Generic;
using System.Linq;
using AlgoApi.Models.Graph;

namespace AlgoApi.Core.NodeHandling
{
    public class GraphCostCalculator: IGraphCostCalculator
    {
        /// <summary>
        /// Fetch weighted matrix to update cost of nodes connected to min node where there cost is bigger than new cost 
        /// </summary>
        /// <param name="nodes">List of nodes to update</param>
        /// <param name="matrix">Weighted matrix</param>
        /// <param name="min">Node of nodes which has lower cost</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void UpdateNodesCost(List<Node> nodes, int[][] matrix, Node min)
        {
            if (matrix == null) throw new ArgumentNullException(nameof(matrix));
            if (min == null) throw new ArgumentNullException(nameof(min));

            for (var i = 0; i < matrix[min.Position[0]].Length; i++)
            {
                if (matrix[min.Position[0]][i] == 0 || min.Parent != null && min.Parent.Position[0] == i) continue;
                var tmpCost = min.Cost + matrix[min.Position[0]][i];
                var updatedNode = nodes.FirstOrDefault(node => node.Position.SequenceEqual(new [] {i}));
                if (updatedNode == null || updatedNode.Cost < tmpCost) continue;
                updatedNode.Cost = tmpCost;
                updatedNode.Parent = min;
            }
        }
    }
}