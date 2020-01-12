using System.Collections.Generic;
using AlgoApi.Core.Sorting.ErrorTesting;
using AlgoApi.Models;
using NUnit.Framework;

namespace AlgoApi.Test
{
    [TestFixture]
    public class YPositionErrorTests
    {
        [Test]
        public void GetError()
        {
            const int expectedError = 4;
            var errorTester = new YPositionError();
            var vectors = new List<TagVector<string>>
            {
                new TagVector<string>(new [] {0, 0}, "A"),
                new TagVector<string>(new [] {0, 1}, "B"),
                new TagVector<string>(new [] {1, 0}, "A"),
                new TagVector<string>(new [] {1, 1}, "B")
            };

            Assert.AreEqual(expectedError, errorTester.GetError(vectors));
        }
    }
}