using System.Collections.Generic;
using AlgoApi.Models.Graph;

namespace AlgoApi.Core.NodeHandling
{
    public class GraphNodeHandler : NodeHandler
    {
        public override void InitNodes(out List<Node> doneNodes, out List<Node> nodes, int[][] matrix)
        {
            doneNodes = new List<Node>();
            nodes = new List<Node>();
            for (var i = 0; i < matrix.Length; i++) nodes.Add(new Node(new[] {i}, null, double.MaxValue, 0));
        }
    }
}