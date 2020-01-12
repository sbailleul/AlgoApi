using System;
using System.Linq;
using NUnit.Framework;

namespace AlgoApi.Test.EnumerableTests
{
    [TestFixture]
    public class ArrayTests
    {
        [Test]
        public void ArrayLengthTests()
        {
            var arr = new[,] {{1, 2},{3, 4}};
            var jaggerArr = Enumerable.Range(0, 2).Select(a => new int[] {0, 0}).ToArray();
            
            Console.WriteLine(arr.GetLength(0));
            Console.WriteLine(jaggerArr.GetLength(0));
            
        }
    }
}