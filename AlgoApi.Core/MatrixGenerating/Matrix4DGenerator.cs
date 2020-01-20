using System;

namespace AlgoApi.Core.MatrixGenerating
{
    public class Matrix4DGenerator: IMatrixGenerator
    {
        public int[][] GetMatrix(int maskVal)
        {
            maskVal = Math.Abs(maskVal);
            return new []
            {
                new[] {maskVal * -1, 0},
                new[] {maskVal, 0},
                new[] {0, maskVal * -1},
                new[] {0, maskVal}
            };
        }
    }
}