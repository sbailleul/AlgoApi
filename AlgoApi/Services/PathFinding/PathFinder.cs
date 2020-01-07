using System;
using System.Collections.Generic;
using System.Linq;
using AlgoApi.Models;

namespace AlgoApi.Services
{
    public abstract class PathFinder
    {
        protected List<Node> DoneNodes { get; set; }
        protected List<Node> Nodes { get; set; }

        protected abstract void InitNodes(List<List<int>> matrix);

        
        protected  Node GetMinimalCostNode()
        {
            var min = Nodes.First();
            
            foreach (var node in Nodes.Where(node => (node.Cost + node.Heuristic) < min.Cost + min.Heuristic))
            {
                min = node;
            }
            Nodes.Remove(min);
            DoneNodes.Add(min);
            
            return min;
        }
        
        protected List<List<int>> GetShortestPath( List<int> start, List<int> end)
        {
            if (start == null) throw new ArgumentNullException(nameof(start));
            if (end == null) throw new ArgumentNullException(nameof(end));
            
            var shortestPath = new List<List<int>>();
            var node = DoneNodes.FirstOrDefault(nodeEl => nodeEl.Position.SequenceEqual(end));
            
            while (node != null && !node.Position.SequenceEqual(start))
            {
                shortestPath.Add(node.Position);
                node = node.Parent;
            }

            if (node == null) return null;
            
            shortestPath.Add(node.Position);
            return shortestPath;
        }

        protected void SetStartNode(IEnumerable<int> start)
        {
            var startNode = Nodes.FirstOrDefault(node => node.Position.SequenceEqual(start));
            if (startNode != null)
            {
                startNode.Cost = 0;
            }
        }
    }
}