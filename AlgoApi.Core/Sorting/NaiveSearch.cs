using System;
using AlgoApi.Core.Sorting.NeighbourTesting;
using AlgoApi.Core.VectorHandling;
using AlgoApi.Models;

namespace AlgoApi.Core.Sorting
{
    public class NaiveSearch<T> : Sorter<T>
    {
        public NaiveSearch()
        {
            NeighbourTester = new CrossNeighbourTester();
        }

        private INeighbourTester NeighbourTester { get; }

        public override T[][] SortMatrix(T[][] matrix)
        {
            var tagVectors = VectorUtils<T>.InitVectors(matrix);
            var switchCnt = 7000;
            var error = 0;
            var rand = new Random();
            do
            {
                error = ErrorTester.GetError(tagVectors);
                TagVector<T> tagVector1;
                TagVector<T> tagVector2;

                do
                {
                    tagVector1 = tagVectors[rand.Next() % tagVectors.Count];
                    tagVector2 = tagVectors[rand.Next() % tagVectors.Count];
                } while (!NeighbourTester.AreNeighbours(tagVector1.Pos, tagVector2.Pos));

                VectorUtils<T>.SwapVectorPos(tagVector1, tagVector2);
                var newError = ErrorTester.GetError(tagVectors);
                if (newError > error)
                    VectorUtils<T>.SwapVectorPos(tagVector1, tagVector2);
                else
                    error = newError;

                switchCnt--;
            } while (error > 0 && switchCnt >= 0);

            return VectorUtils<T>.ConvertVectorsToMatrix(tagVectors);
        }
    }
}