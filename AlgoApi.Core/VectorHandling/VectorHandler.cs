using System;
using System.Collections.Generic;
using System.Linq;
using AlgoApi.Core.MatrixHandling;
using AlgoApi.Models;

namespace AlgoApi.Core.VectorHandling
{
    public class VectorHandler<T> : IVectorHandler<T>
    {
        public VectorHandler()
        {
            MatrixHandler = new MatrixHandler();
        }

        private IMatrixHandler MatrixHandler { get; }

        public List<TagVector<T>> InitVectors(T[][] matrix)
        {
            var tagVectors = new List<TagVector<T>>();

            for (var i = 0; i < matrix.Length; i++)
            for (var j = 0; j < matrix[i].Length; j++)
                tagVectors.Add(new TagVector<T>(new [] {i, j}, matrix[i][j]));

            return tagVectors;
        }

        public void SwapVectorPos(TagVector<T> vector1, TagVector<T> vector2)
        {
            var tmpPos = vector1.Pos;
            vector1.Pos = vector2.Pos;
            vector2.Pos = tmpPos;
        }


        public void DisplayVectors(List<TagVector<T>> tagVectors)
        {
            Console.WriteLine();
            var matrix = ConvertVectorsToMatrix(tagVectors);
            MatrixHandler.DisplayMatrix(matrix);
        }

        public void DisplayVectors(List<TagVector<T>> tagVectors, int h, int w)
        {
            Console.WriteLine();
            var matrix = ConvertVectorsToMatrix(tagVectors, h, w);
            MatrixHandler.DisplayMatrix(matrix);
        }


        public T[][] ConvertVectorsToMatrix(List<TagVector<T>> tagVectors)
        {
            var rowCnt = tagVectors.Max(vector => vector.Pos[0]) + 1;
            var colCnt = tagVectors.Max(vector => vector.Pos[1]) + 1;
            var matrix = Enumerable.Range(1, rowCnt)
                .Select(i => Enumerable.Range(1, colCnt).Select(j => default(T)).ToArray()).ToArray();

            foreach (var vector in tagVectors) matrix[vector.Pos[0]][vector.Pos[1]] = vector.Tag;

            return matrix;
        }

        public T[][] ConvertVectorsToMatrix(List<TagVector<T>> tagVectors, int h, int w)
        {
            var matrix = Enumerable.Range(1, h)
                .Select(i => Enumerable.Range(1, w).Select(j => default(T)).ToArray()).ToArray();

            foreach (var vector in tagVectors)
                if (vector.Pos != null)
                    matrix[vector.Pos[0]][vector.Pos[1]] = vector.Tag;

            return matrix;
        }

        public void ShuffleVectorsPositions(List<TagVector<T>> tagVectors)
        {
            var random = new Random();
            for (var i = 0; i < tagVectors.Count; i++)
            {
                var j = i;
                do
                {
                    j = random.Next() % tagVectors.Count;
                } while (i == j);

                SwapVectorPos(tagVectors[i], tagVectors[j]);
            }
        }

        public void SetPositionsToVectors(int[][] positions, List<TagVector<T>> vectors)
        {
            vectors.ForEach(v => v.Pos = positions[vectors.IndexOf(v)]);
        }
    }
}