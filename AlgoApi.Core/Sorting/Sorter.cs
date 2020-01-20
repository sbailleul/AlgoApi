using System;
using AlgoApi.Core.Sorting.ErrorTesting;
using AlgoApi.Core.VectorHandling;

namespace AlgoApi.Core.Sorting
{
    public abstract class Sorter<T>
    {
        protected Sorter()
        {
            ErrorTester = new YPositionError();
        }

        public abstract T[][] SortMatrix(T[][] matrix);
        protected IErrorTester ErrorTester { get; set; }
    }
}