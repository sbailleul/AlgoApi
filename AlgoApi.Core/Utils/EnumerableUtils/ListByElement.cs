using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AlgoApi.Core.EnumerableHandling
{
    public static class ListByElement 
    {
        public static T GetDistinctRandomElement<T>(List<T> list, T element)
        {
            var element2 = element;
            var random = new Random();
            
            if (typeof(T).IsValueType)
            {
                // while (element2 == element) element2 = list[random.Next() % list.Count];
            }
            else
            {
                while (element2.Equals(element)) element2 = list[random.Next() % list.Count];
            }


            return element2;
        }

        public static int GetDistinctRandomIndex<T>(List<T> list, T element)
        {
            var random = new Random();
            var idx1 = list.IndexOf(element);
            var idx2 = idx1;
            

            while (idx2 == idx1) idx2 = random.Next() % list.Count;

            return idx2;
        }

        public static void SwapElement<T>(List<T> list, T element1, T element2)
        {
            var idx1 = list.IndexOf(element1);
            var idx2 = list.IndexOf(element2);

            var tmpVal = list[idx1];
            list[idx1] = list[idx2];
            list[idx2] = tmpVal;
        }
        
    }
}