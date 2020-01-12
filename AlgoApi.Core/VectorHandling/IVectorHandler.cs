using System.Collections.Generic;
using AlgoApi.Models;

namespace AlgoApi.Core.VectorHandling
{
    public interface IVectorHandler<T>
    {
        List<TagVector<T>> InitVectors(T[][] matrix);
        void SwapVectorPos(TagVector<T> vector1, TagVector<T> vector2);
        void DisplayVectors(List<TagVector<T>> tagVectors);
        void DisplayVectors(List<TagVector<T>> tagVectors, int h, int w);
        T[][] ConvertVectorsToMatrix(List<TagVector<T>> tagVectors);
        T[][] ConvertVectorsToMatrix(List<TagVector<T>> tagVectors, int h, int w);

        void ShuffleVectorsPositions(List<TagVector<T>> tagVectors);
        void SetPositionsToVectors(int[][] positions, List<TagVector<T>> vectors);
    }
}