using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace AlgoApi.Core.EnumerableHandling
{
    public static class ListByIndex 
    {
        public static int GetDistinctRandomIndex<T>(List<T> collection, int idx1)
        {
            var random = new Random();
            var idx2 = idx1;

            try
            {
                CheckToGetRandom(collection, idx1);
            }
            catch (ArgumentException e)
            {
                throw e;
            }

            while (idx2 == idx1) idx2 = random.Next() % collection.Count;

            return idx2;
        }

        public static int GetDistinctRandomElement<T>(List<T> collection, int idx1)
        {
            var random = new Random();
            var idx2 = idx1;

            try
            {
                CheckToGetRandom(collection, idx1);
            }
            catch (ArgumentException e)
            {
                throw e;
            }

            while (idx2 == idx1) idx2 = random.Next() % collection.Count;

            return idx2;
        }

        public static void SwapElement<T>(List<T> collection, int idx1, int idx2)
        {

            try
            {
                var tmpVal = collection[idx1];
                collection[idx1] = collection[idx2];
                collection[idx2] = tmpVal;
            }
            catch (ArgumentOutOfRangeException e)
            {
                throw e;
            }
        }

        private static void CheckToGetRandom<T>(List<T> collection, int idx)
        {
            if (collection.Count <= 1) throw new ArgumentException("Collection size has to be bigger than 1");

            if (idx < 0 || idx >= collection.Count) throw new IndexOutOfRangeException("Index to compare isn't in collection");
        }
    }
}