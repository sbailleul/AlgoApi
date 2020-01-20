using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoApi.Core.EnumerableHandling
{
    public static class ArrayByIndex
    {
        public static int GetDistinctRandomIndex<T>(T[] array, int idx1)
        {
            var random = new Random();
            var idx2 = idx1;

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

        public static int GetDistinctRandomElement<T>(T[] array, int idx1)
        {
            var random = new Random();
            var idx2 = idx1;
            
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

        public static void SwapElement<T>(T[] array, int idx1, int idx2)
        {

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


        private static void CheckToGetRandom<T>(T[] array, int idx)
        {
            if (array.Length <= 1) throw new ArgumentException("Array size has to be bigger than 1");

            if (idx < 0 || idx >= array.Length) throw new IndexOutOfRangeException("Index to compare isn't in array");
        }
    }
}