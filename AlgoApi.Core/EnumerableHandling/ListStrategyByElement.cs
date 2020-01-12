using System;
using System.Collections.Generic;

namespace AlgoApi.Core.ListHandling
{
    public class ListStrategyByElement :EnumerableHandler, IEnumerableStrategyByElement
    {
        
        public T GetDistinctRandomElement<T>(IEnumerable<T> enumerable, T element1)
        {
            var element2 = element1;
            var random = new Random();
            var list = (List<T>) enumerable;
            try
            {
                CheckListToGetRandom(list, element1);
            }
            catch (ArgumentException e)
            {
                throw e;
            }

            while (element2.Equals(element1)) element2 = list[random.Next() % list.Count];

            return element2;
        }

        public int GetDistinctRandomIndex<T>(IEnumerable<T> enumerable, T element1)
        {
            var random = new Random();
            var list = (List<T>) enumerable;
            var idx1 = list.IndexOf(element1);
            var idx2 = idx1;

            try
            {
                CheckListToGetRandom(list, element1);
            }
            catch (ArgumentException e)
            {
                throw e;
            }

            while (idx2 == idx1) idx2 = random.Next() % list.Count;

            return idx2;
        }

        public void SwapElement<T>(IEnumerable<T> enumerable, T element1, T element2)
        {
            var list = (List<T>) enumerable;
            var idx1 = list.IndexOf(element1);
            var idx2 = list.IndexOf(element2);

            var tmpVal = list[idx1];
            list[idx1] = list[idx2];
            list[idx2] = tmpVal;
        }
        
        private void CheckListToGetRandom<T>(List<T> list, T element)
        {
            if (list.Count <= 1) throw new ArgumentException("List size has to be bigger than 1");

            if (!list.Contains(element)) throw new ArgumentException("Element to compare has to be in list");
        }
    }
}