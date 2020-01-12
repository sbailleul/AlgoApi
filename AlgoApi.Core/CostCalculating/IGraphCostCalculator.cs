using System.Collections.Generic;
using AlgoApi.Models.Graph;

namespace AlgoApi.Core.NodeHandling
{
    public interface IGraphCostCalculator
    {
        void UpdateNodesCost(List<Node> nodes, int[][] matrix, Node min);
    }
}