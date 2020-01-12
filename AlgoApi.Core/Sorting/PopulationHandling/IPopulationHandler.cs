using System.Collections.Generic;
using AlgoApi.Models;

namespace AlgoApi.Core.Sorting.PopulationHandler
{
    public interface IPopulationHandler<T>
    {
        int[][][] GeneratePopulation(List<TagVector<T>> vectors, int popSize);

        Dictionary<int[][], int> EvaluatePopulation(int[][][] pop,
            List<TagVector<T>> vectors);

        int[][][] SelectBreeders(Dictionary<int[][], int> scoredPop, int breedersCnt);

        int[][][] CrossBreed(int[][][] breeders, int popSize);

        void MutatePop(int[][][] pop, float mutationRate);

        int[][] GetBreedersChild(int[][] parent1Pos, int[][] parent2Pos);
    }
}