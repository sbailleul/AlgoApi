using System;
using System.Collections.Generic;
using System.Linq;
using AlgoApi.Core.MatrixHandling;
using AlgoApi.Models;

namespace AlgoApi.Core.VectorHandling
{
    public static class VectorUtils<T>
    {

        /// <summary>
        /// Loop in matrix to set vectors list, vector tag property = matrix[i][j] & vector position = {i,j}
        /// </summary>
        /// <param name="matrix">Generic type matrix</param>
        /// <returns></returns>
        public static List<TagVector<T>> InitVectors(T[][] matrix)
        {
            var tagVectors = new List<TagVector<T>>();

            for (var i = 0; i < matrix.Length; i++)
            for (var j = 0; j < matrix[i].Length; j++)
                tagVectors.Add(new TagVector<T>(new[] {i, j}, matrix[i][j]));

            return tagVectors;
        }

        public static void SwapVectorPos(TagVector<T> vector1, TagVector<T> vector2)
        {
            var tmpPos = vector1.Pos;
            vector1.Pos = vector2.Pos;
            vector2.Pos = tmpPos;
        }


        public static void DisplayVectors(List<TagVector<T>> tagVectors)
        {
            Console.WriteLine();
            var matrix = ConvertVectorsToMatrix(tagVectors);
            MatrixUtils.DisplayMatrix(matrix);
        }

        public static void DisplayVectors(List<TagVector<T>> tagVectors, int h, int w)
        {
            Console.WriteLine();
            var matrix = ConvertVectorsToMatrix(tagVectors, h, w);
            MatrixUtils.DisplayMatrix(matrix);
        }


        /// <summary>
        /// Convert vector in matrix sized by max x and max y position of vectors
        /// </summary>
        /// <param name="tagVectors">Vector list</param>
        /// <returns></returns>
        public static T[][] ConvertVectorsToMatrix(List<TagVector<T>> tagVectors)
        {
            var rowCnt = tagVectors.Max(vector => vector.Pos[0]) + 1;
            var colCnt = tagVectors.Max(vector => vector.Pos[1]) + 1;
            var matrix = Enumerable.Range(1, rowCnt)
                .Select(i => Enumerable.Range(1, colCnt).Select(j => default(T)).ToArray()).ToArray();

            foreach (var vector in tagVectors) matrix[vector.Pos[0]][vector.Pos[1]] = vector.Tag;

            return matrix;
        }

        /// <summary>
        /// Convert list of vectors in sized matrix 
        /// </summary>
        /// <param name="tagVectors">Vector list</param>
        /// <param name="w">Matrix height</param>
        /// <param name="h">Matrix width</param>
        /// <returns></returns>
        public static T[][] ConvertVectorsToMatrix(List<TagVector<T>> tagVectors, int w, int h)
        {
            var matrix = Enumerable.Range(1, w)
                .Select(i => Enumerable.Range(1, h).Select(j => default(T)).ToArray()).ToArray();

            foreach (var vector in tagVectors)
                if (vector.Pos != null)
                    matrix[vector.Pos[0]][vector.Pos[1]] = vector.Tag;

            return matrix;
        }

        /// <summary>
        /// Shuffle vector position in list
        /// </summary>
        /// <param name="tagVectors"></param>
        public static void ShuffleVectorsPositions(List<TagVector<T>> tagVectors)
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
        
        /// <summary>
        /// For each vector in vectors copy corresponding positions in position by vector index in its list.
        /// </summary>
        /// <param name="positions"></param>
        /// <param name="vectors"></param>
        public  static void SetPositionsToVectors(int[][] positions, List<TagVector<T>> vectors)
        {
            vectors.ForEach(v => v.Pos = positions[vectors.IndexOf(v)]);
        }
    }
}