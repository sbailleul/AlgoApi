using System;
using System.Collections.Generic;
using System.Linq;
using AlgoApi.Models;
using Microsoft.EntityFrameworkCore.Internal;

namespace AlgoApi.Services
{
    public class AStar: PathFinder, IAStar
    {
        private List<List<int>> PositionMask { get; set;}

        public AStar()
        {
            InitPositionMask();
        }

        public List<List<int>> FindShortestPath(List<List<int>> matrix, List<int> startVector, List<int> endVector)
        {
            Node min;
            InitNodes(matrix);
            SetStartNode(startVector);
            do
            {
                min = GetMinimalCostNode();

                if (min.Position.SequenceEqual(endVector))
                {
                    break;
                }
                UpdateNodes(matrix, min, endVector);
            } while (Nodes.Count>0 && !min.Position.SequenceEqual(endVector) );


            return GetShortestPath(startVector, endVector);
        }
        
        private void UpdateNodes(List<List<int>> matrix, Node min, List<int> destinationPosition)
        {
            if (matrix == null) throw new ArgumentNullException(nameof(matrix));
            if (min == null) throw new ArgumentNullException(nameof(min));

            foreach (var mask in PositionMask)
            {
                var updatedNode = Nodes.FirstOrDefault(node => node.Position.SequenceEqual(mask.Zip(min.Position, (a, b) => a + b)));
                if (updatedNode == null) continue;
                var tmpCost = min.Cost + matrix[updatedNode.Position[0]][updatedNode.Position[1]];
                updatedNode.Heuristic = CalculateManhattanDistance(updatedNode.Position, destinationPosition);
                if (updatedNode.Cost < tmpCost) continue;
                updatedNode.Cost = tmpCost;
                updatedNode.Parent = min;
            }
        }
        
        protected override void InitNodes(List<List<int>> matrix) {
            DoneNodes = new List<Node>();
            Nodes =  new List<Node>();
            for (var i = 0; i < matrix.Count; i++)
            {
                for (var j = 0; j < matrix[i].Count; j++)
                {
                    if (matrix[i][j] == 0) continue;
                    Nodes.Add(new Node(new List<int>{i,j}, null, double.MaxValue, 0));
                }
            }
        }
        

        private void InitPositionMask()
        {
            PositionMask = new List<List<int>>()
            {
                new List<int>(){-1,0},
                new List<int>(){1,0},
                new List<int>(){0,-1},
                new List<int>(){0,1},
            };
        }

        private int CalculateManhattanDistance(List<int> sourcePosition, List<int> destinationPosition)
        {
            return Math.Abs(sourcePosition[0] - destinationPosition[0]) + Math.Abs(sourcePosition[1] - destinationPosition[1]); 
        }

    }
}