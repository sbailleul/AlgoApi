using System.Collections.Generic;

namespace AlgoApi.Core.MatrixHandling
{
    public interface IMatrixHandler
    {
        T[][] GetRandomMatrixOfEquitableRepeatedValues<T>(int repetition, T[] values);
        void DisplayMatrix<T>(T[][] matrix);

        int[][] GetMatrixMask(int maskVal);
    }
}