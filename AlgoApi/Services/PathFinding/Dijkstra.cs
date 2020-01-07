using System;
using System.Collections.Generic;
using System.Linq;
using AlgoApi.Models;

namespace AlgoApi.Services
{
    public class Dijkstra : PathFinder,  IDijkstra
    {
        public List<List<int>> FindShortestPath(List<List<int>> matrix, List<int> startVector, List<int> endVector)
        {
            var end = endVector[0];
            Node min;
            InitNodes(matrix);
            SetStartNode(startVector);
            do
            {
                min = GetMinimalCostNode();

                if (min.Position[0] == end)
                {
                    break;
                }
                UpdateNodes(matrix, min);
            } while (Nodes.Count>0 && min.Position[0] != end );
            
            return GetShortestPath( startVector, endVector);
            
        }



        private void UpdateNodes(List<List<int>> matrix, Node min)
        {
            if (matrix == null) throw new ArgumentNullException(nameof(matrix));
            if (min == null) throw new ArgumentNullException(nameof(min));
            
            for (var i = 0; i < matrix[min.Position[0]].Count; i++)
            {
                if (matrix[min.Position[0]][i] == 0 || (min.Parent != null && min.Parent.Position[0] == i)) continue;
                var tmpCost = min.Cost + matrix[min.Position[0]][i];
                var updatedNode = Nodes.FirstOrDefault(node => node.Position.SequenceEqual(new List<int>{i}));
                if ( updatedNode == null || updatedNode.Cost < tmpCost) continue;
                updatedNode.Cost = tmpCost;
                updatedNode.Parent = min;
            }
        }
        
        protected override void InitNodes(List<List<int>> matrix) {
            DoneNodes = new List<Node>();
            Nodes =  new List<Node>();
            for (var i = 0; i < matrix.Count; i++)
            {
                Nodes.Add(new Node(new List<int>{i}, null, double.MaxValue, 0));
            }
            
        }
    }
}