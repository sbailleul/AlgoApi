using System.Collections.Generic;
using AlgoApi.Core.Sorting.Interfaces;
using AlgoApi.Core.Sorting.NeighbourTesting;
using AlgoApi.Models;

namespace AlgoApi.Core.Sorting
{
    public class NaiveSearch<T> : Sorter<T>, INaiveSearch<T>
    {
        public NaiveSearch()
        {
            NeighbourTester = new CrossNeighbourTester();
        }

        private INeighbourTestter NeighbourTester { get; }

        public T[][] SortMatrix(T[][] matrix)
        {
            var tagVectors = VectorHandler.InitVectors(matrix);
            var switchCnt = 7000;
            var error = 0;
            do
            {
                error = ErrorTester.GetError(tagVectors);
                TagVector<T> tagVector1;
                TagVector<T> tagVector2;

                do
                {
                    tagVector1 = tagVectors[RandGenerator.Next() % tagVectors.Count];
                    tagVector2 = tagVectors[RandGenerator.Next() % tagVectors.Count];
                } while (!NeighbourTester.AreNeighbours(tagVector1.Pos, tagVector2.Pos));

                VectorHandler.SwapVectorPos(tagVector1, tagVector2);
                var newError = ErrorTester.GetError(tagVectors);
                if (newError > error)
                    VectorHandler.SwapVectorPos(tagVector1, tagVector2);
                else
                    error = newError;

                switchCnt--;
            } while (error > 0 && switchCnt >= 0);

            return VectorHandler.ConvertVectorsToMatrix(tagVectors);
        }
    }
}