﻿using System.Collections.Generic;

namespace AlgoApi.Core.PathFinding.Interfaces
{
    public interface IPathFinder
    {
        List<int[]> FindShortestPath(int[][] matrix, int[] startVector, int[] endVector);
    }
}