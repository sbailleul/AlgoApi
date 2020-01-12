using System.Collections.Generic;
using AlgoApi.Models.Graph;

namespace AlgoApi.Core.NodeHandling
{
    public interface IGridCostCalculator
    {
        void UpdateNodesCost(List<Node> nodes, int[][] matrix, Node min, int[] destinationPosition);
    }
}