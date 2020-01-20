using System;

namespace AlgoApi.Core.MatrixGenerating
{
    public interface IMatrixGenerator
    {
        int[][] GetMatrix(int maskVal);
    }
}