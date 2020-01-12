using System.Collections.Generic;

namespace AlgoApi.Core.ListHandling
{
    public interface IEnumerableStrategyByElement
    {
        T GetDistinctRandomElement<T>(IEnumerable<T> enumerable, T element1);
        int GetDistinctRandomIndex<T>(IEnumerable<T> enumerable, T element1);
        void SwapElement<T>(IEnumerable<T> enumerable, T element1, T element2);
    }
}