using System.Collections.Generic;
using AlgoApi.Models.Graph;

namespace AlgoApi.Core.NodeHandling
{
    public interface INodeHandler
    {
        Node GetMinimalCostNode(List<Node> nodes, List<Node> doneNodes);
        List<int[]> GetShortestPath(List<Node> doneNodes, int[] start, int[] end);
        void SetStartNode(List<Node> nodes, IEnumerable<int> start);

        void InitNodes(out List<Node> doneNodes, out List<Node> nodes, int[][] matrix);
    }
}