using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoApi.Core.EnumerableHandling
{
    public abstract class EnumerableHandler<T>
    {
        protected virtual IEnumerable<T> ShuffleElements(IEnumerable<T> enumerable)
        {
            var random = new Random();
            return enumerable.OrderBy(i => random.Next());
        }
        
        
    }
}