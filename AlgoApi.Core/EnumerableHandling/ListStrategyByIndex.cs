using System;
using System.Collections.Generic;

namespace AlgoApi.Core.ListHandling
{
    public class ListStrategyByIndex :EnumerableHandler, IEnumerableStrategyByIndex
    {
        
        public int GetDistinctRandomIndex<T>(IEnumerable<T> enumerable, int idx1)
        {
            var random = new Random();
            var idx2 = idx1;
            var list = (List<T>) enumerable;
            try
            {
                CheckToGetRandom(list, idx1);
            }
            catch (ArgumentException e)
            {
                throw e;
            }

            while (idx2 == idx1) idx2 = random.Next() % list.Count;

            return idx2;
        }

        public int GetDistinctRandomElement<T>(IEnumerable<T> enumerable, int idx1)
        {
            var random = new Random();
            var idx2 = idx1;
            var list = (List<T>) enumerable;

            try
            {
                CheckToGetRandom(list, idx1);
            }
            catch (ArgumentException e)
            {
                throw e;
            }

            while (idx2 == idx1) idx2 = random.Next() % list.Count;

            return idx2;
        }

        public void SwapElement<T>(IEnumerable<T> enumerable, int idx1, int idx2)
        {
            var list = (List<T>) enumerable;

            try
            {
                var tmpVal = list[idx1];
                list[idx1] = list[idx2];
                list[idx2] = tmpVal;
            }
            catch (ArgumentOutOfRangeException e)
            {
                throw e;
            }
        }
        
        private void CheckToGetRandom<T>(List<T> list, int idx)
        {
            if (list.Count <= 1) throw new ArgumentException("List size has to be bigger than 1");

            if (idx < 0 || idx >= list.Count) throw new IndexOutOfRangeException("Index to compare isn't in list");
        }

    }
}