using System;
using AlgoApi.Core.Sorting.ErrorTesting;
using AlgoApi.Core.VectorHandling;

namespace AlgoApi.Core.Sorting
{
    public abstract class Sorter<T>
    {
        protected Sorter()
        {
            VectorHandler = new VectorHandler<T>();
            RandGenerator = new Random();
            ErrorTester = new YPositionError();
        }

        protected Random RandGenerator { get; set; }

        protected IVectorHandler<T> VectorHandler { get; set; }
        protected IErrorTester ErrorTester { get; set; }
    }
}