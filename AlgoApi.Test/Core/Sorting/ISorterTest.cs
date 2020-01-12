using System.Collections.Generic;
using System.Linq;
using AlgoApi.Core.Sorting;
using AlgoApi.Core.Sorting.Interfaces;
using NUnit.Framework;

namespace AlgoApi.Test.Services.Sorting
{
    [TestFixture]
    public class ISorterTest
    {
        [Test]
        public void SortMatrix()
        {
            var sorters = new List<ISorter<char>>
                {new NaiveSearch<char>(), new SimulatedAnnealing<char>(), new GeneticAlgorithm<char>()};
            Assert.Multiple(() =>
            {
                foreach (var sorter in sorters)
                {
                    var matrix = Enumerable.Range(1, 3).Select(r => new [] {'A', 'B', 'C'}).ToArray();
                    matrix = sorter.SortMatrix(matrix);

                    Assert.AreEqual(3, matrix.Select(l => l[0]).Distinct().Count());
                    foreach (var chars in matrix)
                    {
                        Assert.IsFalse(chars.Distinct().Skip(1).Any());
                    }
                }
            });
        }
    }
}