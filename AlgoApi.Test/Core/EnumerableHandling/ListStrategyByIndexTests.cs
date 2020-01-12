using System;
using System.Collections.Generic;
using System.Linq;
using AlgoApi.Core.ListHandling;
using NUnit.Framework;

namespace AlgoApi.Test
{
    [TestFixture]
    public class ListStrategyByIndexTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetDistinctRandomElement()
        {
            var listHandler = new ListStrategyByIndex();
            var list = Enumerable.Range(0, 100).ToList();

            Assert.AreNotEqual(1, listHandler.GetDistinctRandomElement(list, 1));
        }

        [Test]
        public void GetDistinctRandomElementWithBadListSize()
        {
            var listHandler = new ListStrategyByIndex();
            var list = new List<int>();
            Assert.Throws<ArgumentException>(() => listHandler.GetDistinctRandomElement(list, 1));
        }

        [Test]
        public void GetDistinctRandomIndex()
        {
            var listHandler = new ListStrategyByIndex();
            var list = Enumerable.Range(0, 100).ToList();

            Assert.AreNotEqual(0, listHandler.GetDistinctRandomIndex(list, 0));
        }

        [Test]
        public void GetDistinctRandomIndexWithBadIndex()
        {
            var listHandler = new ListStrategyByIndex();
            var list = new List<string>();
            Assert.Throws<ArgumentException>(() => listHandler.GetDistinctRandomIndex(list, 1));
        }

        [Test]
        public void SwapListElementWithBadIndex()
        {
            var listHandler = new ListStrategyByIndex();
            var list = new List<string>();
            Assert.Throws<ArgumentOutOfRangeException>(() => listHandler.SwapElement(list, 1, 2));
        }
    }
}