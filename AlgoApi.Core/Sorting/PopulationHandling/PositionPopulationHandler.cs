using System;
using System.Collections.Generic;
using System.Linq;
using AlgoApi.Core.EnumerableHandling;
using AlgoApi.Core.Sorting.ErrorTesting;
using AlgoApi.Core.VectorHandling;
using AlgoApi.Models;

namespace AlgoApi.Core.Sorting.PopulationHandling
{
    public class PositionPopulationHandler<T> 
    {
        private IErrorTester ErrorTester { get; } = new YPositionError();

        public int[][][] GeneratePopulation(List<TagVector<T>> vectors, int popSize)
        {
            var pop = Enumerable.Repeat(0, popSize).Select(a => new int[vectors.Count][]).ToArray();

            for (var i = 0; i < popSize; i++)
            {
                VectorUtils<T>.ShuffleVectorsPositions(vectors);
                pop[i] = vectors.Select(v => v.Pos).ToArray();
            }

            return pop;
        }

        public Dictionary<int[][], int> EvaluatePopulation(int[][][] pop, List<TagVector<T>> vectors)
        {
            var scoredPop = new Dictionary<int[][], int>();

            foreach (var entity in pop)
            {
                VectorUtils<T>.SetPositionsToVectors(entity, vectors);
                scoredPop[entity] = ErrorTester.GetError(vectors);
            }

            return scoredPop;
        }

        public int[][][] SelectBreeders(Dictionary<int[][], int> scoredPop, int breedersCnt)
        {
            var breeders = scoredPop.OrderBy(kv => kv.Value).Select(kv => kv.Key).Take(breedersCnt).ToArray();
            return breeders;
        }

        public int[][][] CrossBreed(int[][][] breeders, int popSize)
        {
            var pop = new int[popSize][][];
            var random = new Random();
            for (var i = 0; i < popSize; i++)
            {
                var idx1 = random.Next() % breeders.Length;
                var idx2 = ArrayByIndex.GetDistinctRandomIndex(breeders, idx1);
                pop[i] = GetBreedersChild(breeders[idx1], breeders[idx2]);
            }

            return pop;
        }

        public void MutatePop(int[][][] pop, float mutationRate)
        {
            var random = new Random();

            foreach (var entity in pop)
            {
                if (random.NextDouble() > mutationRate) continue;
                var idx1 = random.Next() % entity.Length;
                var idx2 = ArrayByIndex.GetDistinctRandomIndex(entity, idx1);
                ArrayByIndex.SwapElement(entity, idx1, idx2);
            }
        }

        public int[][] GetBreedersChild(int[][] parent1Pos, int[][] parent2Pos)
        {
            var child = new int[parent1Pos.Length][];
            var lookAtP1 = true;
            var parentCnt = 0;

            for (var i = 0; i < child.Length; i++)
            {
                if (lookAtP1)
                {
                    if (child.FirstOrDefault(c => c != null && c.SequenceEqual(parent1Pos[parentCnt])) == null)
                    {
                        child[i] = parent1Pos[parentCnt];
                        lookAtP1 = !lookAtP1;
                    }
                    else if (child.FirstOrDefault(c => c != null && c.SequenceEqual(parent2Pos[parentCnt])) == null)
                    {
                        child[i] = parent2Pos[parentCnt];
                    }
                    else
                    {
                        i--;
                    }
                }
                else
                {
                    if (child.FirstOrDefault(c => c != null && c.SequenceEqual(parent2Pos[parentCnt])) == null)
                    {
                        child[i] = parent2Pos[parentCnt];
                        lookAtP1 = !lookAtP1;
                    }
                    else if (child.FirstOrDefault(c => c != null && c.SequenceEqual(parent1Pos[parentCnt])) == null)
                    {
                        child[i] = parent1Pos[parentCnt];
                    }
                    else
                    {
                        i--;
                    }
                }

                parentCnt++;
                parentCnt = parentCnt >= child.Length ? 0 : parentCnt;
            }

            return child;
        }
    }
}