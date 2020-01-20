using System;
using System.Collections.Generic;
using System.Linq;
using AlgoApi.Core.EnumerableHandling;
using NUnit.Framework;

namespace AlgoApi.Test.Core.EnumerableHandling
{
    [TestFixture]
    public class ListByIndexTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetDistinctRandomElement()
        {
            var list = Enumerable.Range(0, 100).ToList();

            Assert.AreNotEqual(1, ListByIndex.GetDistinctRandomElement(list, 1));
        }

        [Test]
        public void GetDistinctRandomElementWithBadListSize()
        {
            var list = new List<int>();
            Assert.Throws<ArgumentException>(() => ListByIndex.GetDistinctRandomElement(list, 1));
        }

        [Test]
        public void GetDistinctRandomIndex()
        {
            var list = Enumerable.Range(0, 100).ToList();

            Assert.AreNotEqual(0, ListByIndex.GetDistinctRandomIndex(list, 0));
        }

        [Test]
        public void GetDistinctRandomIndexWithBadIndex()
        {
            var list = new List<string>();
            Assert.Throws<ArgumentException>(() => ListByIndex.GetDistinctRandomIndex(list, 1));
        }

        [Test]
        public void SwapListElementWithBadIndex()
        {
            var list = new List<string>();
            Assert.Throws<ArgumentOutOfRangeException>(() => ListByIndex.SwapElement(list, 1, 2));
        }
    }
}