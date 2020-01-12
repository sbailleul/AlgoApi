﻿using System;
using System.Collections.Generic;
using System.Linq;
using AlgoApi.Core.HeuristicHandling;
using AlgoApi.Core.MatrixHandling;
using AlgoApi.Models.Graph;

namespace AlgoApi.Core.NodeHandling
{
    public class GridNodeHandler: NodeHandler, INodeHandler
    {

        public void InitNodes(out List<Node> doneNodes, out List<Node> nodes, int[][] matrix)
        {
            doneNodes = new List<Node>();
            nodes = new List<Node>();
            for (var i = 0; i < matrix.Length; i++)
            for (var j = 0; j < matrix[i].Length; j++)
            {
                if (matrix[i][j] == 0) continue;
                nodes.Add(new Node(new [] {i, j}, null, double.MaxValue, 0));
            }
        }
        
    }
}