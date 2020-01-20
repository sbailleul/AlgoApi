using System;

namespace AlgoApi.Core.MatrixGenerating
{
    public class Matrix8DGenerator : IMatrixGenerator
    {
        public int[][] GetMatrix(int maskVal)
        {
            maskVal = Math.Abs(maskVal);
            return new []
            {
                new[] {maskVal * -1, maskVal*-1},
                new[] {maskVal * -1, maskVal},
                new[] {maskVal, maskVal*-1},
                new[] {maskVal, maskVal},
                new[] {maskVal * -1, 0},
                new[] {maskVal, 0},
                new[] {0, maskVal * -1},
                new[] {0, maskVal}
            };
        }
    }
}