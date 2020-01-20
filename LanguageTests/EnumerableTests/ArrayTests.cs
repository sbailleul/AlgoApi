using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace AlgoApi.LanguageTest.EnumerableTests
{
    [TestFixture]
    public class ArrayTests
    {
        private int[] TestArray;
        private List<int> TestList;

        [SetUp]
        public void GenerateArray()
        {
            var rand = new Random();
            var enumerable = Enumerable.Range(0, 1000000000).Select(i => rand.Next());
            TestArray = enumerable.ToArray();
            TestList = enumerable.ToList();
        }
        [Test]
        public void ToArrayTest()
        {
            // var arr = TestList.ToArray();
        }
        
        [Test]
        public void ArrayCastTest()
        {
            // var arr = (int[])TestArray;
            
        }
        
        // [Test]
        // public void ArrayLengthTests(int[] array)
        // {
        //
        // }
    }
}