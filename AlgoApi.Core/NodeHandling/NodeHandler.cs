using System;
using System.Collections.Generic;
using System.Linq;
using AlgoApi.Models.Graph;

namespace AlgoApi.Core.NodeHandling
{
    public abstract class NodeHandler
    {
        public Node GetMinimalCostNode(List<Node> nodes, List<Node> doneNodes)
        {
            var min = nodes.First();

            foreach (var node in nodes.Where(node => node.Cost + node.Heuristic < min.Cost + min.Heuristic)) min = node;
            nodes.Remove(min);
            doneNodes.Add(min);

            return min;
        }

        public List<int[]> GetShortestPath(List<Node> doneNodes, int[] start, int[] end)
        {
            if (start == null) throw new ArgumentNullException(nameof(start));
            if (end == null) throw new ArgumentNullException(nameof(end));

            var shortestPath = new List<int[]>();
            var node = doneNodes.FirstOrDefault(nodeEl => nodeEl.Position.SequenceEqual(end));

            while (node != null && !node.Position.SequenceEqual(start))
            {
                shortestPath.Add(node.Position);
                node = node.Parent;
            }

            if (node == null) return null;

            shortestPath.Add(node.Position);
            return shortestPath;
        }

        public void SetStartNode(List<Node> nodes, IEnumerable<int> start)
        {
            var startNode = nodes.FirstOrDefault(node => node.Position.SequenceEqual(start));
            if (startNode != null) startNode.Cost = 0;
        }

    }
}