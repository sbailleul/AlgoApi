using System.Collections.Generic;
using AlgoApi.Models.Graph;

namespace AlgoApi.Core.CostCalculating
{
    public interface ICostCalculator
    {
        void UpdateNodesCost(List<Node> nodes, int[][] matrix, Node min, int[]? destinationPosition = null);
    }
}