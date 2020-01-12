using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoApi.Core.ListHandling
{
    public abstract class  EnumerableHandler
    {
        public virtual IEnumerable<T>  ShuffleElements<T>(IEnumerable<T> array)
        {
            var random = new Random();
            return array.OrderBy(i => random.Next());
        }
    }
}