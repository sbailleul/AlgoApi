using System;
using System.Linq;

namespace AlgoApi.Core.MatrixHandling
{
    public static class MatrixUtils
    {
        public static T[][] GetRandomMatrixOfEquitableRepeatedValues<T>(int repetition, T[] values)
        {
            var rand = new Random();
            try
            {
                var randomArr = Enumerable.Range(0, values.Length).Select(i => Enumerable.Repeat(values[i], repetition))
                    .SelectMany(k => k).OrderBy(j => rand.Next()).ToArray();
                var matrix = Enumerable.Range(1, values.Length)
                    .Select(i => Enumerable.Range(1, repetition).Select(j => default(T)).ToArray())
                    .ToArray();
                var randomEl = randomArr.GetEnumerator();

                foreach (var row in matrix)
                    for (var i = 0; i < row.Length; i++)
                    {
                        randomEl.MoveNext();
                        row[i] = (T) randomEl.Current;
                    }

                return matrix;
            }
            catch (ArgumentOutOfRangeException e)
            {
                throw e;
            }
        }

        public static void DisplayMatrix<T>(T[][] matrix)
        {
            for (var i = 0; i < matrix.Length; i++)
            {
                for (var j = 0; j < matrix[i].Length; j++) Console.Write(matrix[i][j] + " ");
                Console.WriteLine();
            }
        }
    }
}