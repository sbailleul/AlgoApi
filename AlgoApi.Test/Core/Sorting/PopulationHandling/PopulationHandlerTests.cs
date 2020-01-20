using System;
using System.Collections.Generic;
using System.Linq;
using AlgoApi.Core.Sorting.PopulationHandling;
using AlgoApi.Models;
using NUnit.Framework;

namespace AlgoApi.Test.Core.Sorting.PopulationHandling
{
    [TestFixture]
    public class PopulationHandlerTests
    {
        [Test]
        public void CrossBreed()
        {
            var populationHandler = new PositionPopulationHandler<string>();
            var pop = new[]
            {
                new[] {new[] {0, 2}, new[] {2, 2}},
                new[] {new[] {1, 2}, new[] {1, 1}}
            };
            var child = populationHandler.CrossBreed(pop, 1)[0];
            var expectedChildren = new[]
            {
                new[] {new[] {0, 2}, new[] {1, 1}},
                new[] {new[] {1, 2}, new[] {2, 2}}
            };

            Assert.True(expectedChildren.Any(expectedChild =>
                expectedChild[0].SequenceEqual(child[0]) && expectedChild[1].SequenceEqual(child[1])));
        }

        [Test]
        public void EvaluatePopulation()
        {
            var populationHandler = new PositionPopulationHandler<int>();
            var vectors = Enumerable.Range(1, 4).Select(i => new TagVector<int>(new int[2], i % 2)).ToList(); // 1 0 1 0
            var pop = Enumerable.Range(0, 2)
                .Select(i => Enumerable.Range(0, 4).Select(l => new[] {l / 2, l % 2}).ToArray()).ToArray();
            var tmp = pop[0][0];
            pop[0][0] = pop[0][3];
            pop[0][3] = tmp;

            var scoredPop = populationHandler.EvaluatePopulation(pop, vectors);
            Assert.That(scoredPop.Keys.First(), Is.EquivalentTo(pop[0]));
            Assert.AreEqual(0, scoredPop.Values.First());
        }

        [Test]
        public void GeneratePopulation()
        {
            var populationHandler = new PositionPopulationHandler<int>();
            const int popSize = 4;
            var expectedVectorsPos = Enumerable.Range(0, popSize).Select(p => new[] {p, p % 2}).ToArray();
            var vectors = Enumerable.Range(0, 4).Select(v => new TagVector<int>(expectedVectorsPos[v], v % 2))
                .ToList();
            var pop = populationHandler.GeneratePopulation(vectors, popSize);
            var expectedVectorPosSeq = expectedVectorsPos.SelectMany(e => e).ToArray();
            var diffCnt = 0;

            Assert.AreEqual(popSize, pop.Length);

            foreach (var entity in pop)
            {
                var entitySeq = entity.SelectMany(e => e).ToArray();
                Assert.That(entitySeq, Is.EquivalentTo(expectedVectorPosSeq));
                if (!entitySeq.SequenceEqual(expectedVectorPosSeq)) diffCnt++;
            }

            Assert.True(diffCnt > popSize / 2);
        }

        [Test]
        public void GetBreedersChild()
        {
            var populationHandler = new PositionPopulationHandler<string>();
            var parent1 = new[] {new[] {0, 2}, new[] {2, 2}};
            var parent2 = new[] {new[] {1, 2}, new[] {1, 1}};
            populationHandler.GetBreedersChild(parent1, parent2);
            var expectedChild = new[] {new[] {0, 2}, new[] {1, 1}};

            Assert.That(expectedChild[0], Is.EquivalentTo(parent1[0]));
            Assert.That(expectedChild[1], Is.EquivalentTo(parent2[1]));
        }

        [Test]
        public void MutatePop()
        {
            var mutationRates = new[] {1.0f, 0.0f};
            var asserts = new List<Action<bool>> {Assert.IsFalse, Assert.IsTrue};
            var populationHandler = new PositionPopulationHandler<string>();

            for (var i = 0; i < asserts.Count; i++)
            {
                var pops = Enumerable.Range(0, 2).Select(c =>
                        Enumerable.Range(0, 4)
                            .Select(e => Enumerable.Range(0, 4).Select(p => new[] {p / 2, p % 2}).ToArray()).ToArray())
                    .ToList();

                populationHandler.MutatePop(pops[0], mutationRates[i]);
                asserts[i](Enumerable.Range(0, pops[1].Length).All(j =>
                    Enumerable.Range(0, pops[1][j].Length).All(k => pops[0][j][k].SequenceEqual(pops[1][j][k])))
                );
            }
        }

        [Test]
        public void SelectBreeders()
        {
            var populationHandler = new PositionPopulationHandler<string>();
            const int breedersCnt = 2;
            var scoredPop = new Dictionary<int[][], int>
            {
                {new int [0][], 1},
                {new int [0][], 2},
                {new int [0][], 3}
            };
            var breeders = populationHandler.SelectBreeders(scoredPop, breedersCnt);
            var expectedBreeders = scoredPop.OrderBy(kv => kv.Value).Select(kv => kv.Key).Take(breedersCnt).ToArray();
            Assert.AreEqual(breedersCnt, breeders.Length);
            for (var i = 0; i < breedersCnt; i++) Assert.AreSame(breeders[i], expectedBreeders[i]);
        }
    }
}