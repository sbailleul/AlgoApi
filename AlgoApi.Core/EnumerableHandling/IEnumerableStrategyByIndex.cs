using System.Collections.Generic;

namespace AlgoApi.Core.ListHandling
{
    public interface IEnumerableStrategyByIndex
    {
        int GetDistinctRandomIndex<T>(IEnumerable<T> enumerable, int idx1);
        int GetDistinctRandomElement<T>(IEnumerable<T> enumerable, int idx1);
        void SwapElement<T>(IEnumerable<T> enumerable, int idx1, int idx2);
    }
}