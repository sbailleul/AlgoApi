using System;
using System.Collections.Generic;

namespace AlgoApi.Core.ListHandling
{
    public class ArrayStrategyByIndex:EnumerableHandler, IEnumerableStrategyByIndex
    {
        public int GetDistinctRandomIndex<T>(IEnumerable<T> enumerable, int idx1)
        {
            var random = new Random();
            var idx2 = idx1;
            var array = (T[]) enumerable;

            try
            {
                CheckToGetRandom(array, idx1);
            }
            catch (ArgumentException e)
            {
                throw e;
            }

            while (idx2 == idx1) idx2 = random.Next() % array.Length;

            return idx2;
        }

        public int GetDistinctRandomElement<T>(IEnumerable<T> enumerable, int idx1)
        {
            var random = new Random();
            var idx2 = idx1;
            var array = (T[]) enumerable;

            try
            {
                CheckToGetRandom(array, idx1);
            }
            catch (ArgumentException e)
            {
                throw e;
            }

            while (idx2 == idx1) idx2 = random.Next() % array.Length;

            return idx2;
        }

        public void SwapElement<T>(IEnumerable<T> enumerable, int idx1, int idx2)
        {
            var array = (T[]) enumerable;

            try
            {
                var tmpVal = array[idx1];
                array[idx1] = array[idx2];
                array[idx2] = tmpVal;
            }
            catch (ArgumentOutOfRangeException e)
            {
                throw e;
            }
        }


        private void CheckToGetRandom<T>(T[] array, int idx)
        {
            if (array.Length <= 1) throw new ArgumentException("Array size has to be bigger than 1");

            if (idx < 0 || idx >= array.Length) throw new IndexOutOfRangeException("Index to compare isn't in array");
        }
    }
}