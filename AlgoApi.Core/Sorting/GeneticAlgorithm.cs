using System;
using System.Collections.Generic;
using System.Linq;
using AlgoApi.Core.ListHandling;
using AlgoApi.Core.ReferenceHandling;
using AlgoApi.Core.Sorting.Interfaces;
using AlgoApi.Core.Sorting.PopulationHandler;
using AlgoApi.Models;

namespace AlgoApi.Core.Sorting
{
    public class GeneticAlgorithm<T> : Sorter<T>, IGeneticAlgorithm<T>
    {

        private IPopulationHandler<T> PopulationHandler { get; set; } = new PopulationHandler<T>();
    

        public T[][] SortMatrix(T[][] matrix)
        {
            const int popSize = 200;
            const float breederRation = 0.2f;
            const float mutationRate = 0.1f;
            const int breedersCnt = (int) (popSize * breederRation);
            var testVectors = VectorHandler.InitVectors(matrix);
            var pop = PopulationHandler.GeneratePopulation(testVectors, popSize);

            while (true)
            {
                var scoredPop = PopulationHandler.EvaluatePopulation(pop, testVectors);
                var breeders = PopulationHandler.SelectBreeders(scoredPop, breedersCnt);
                var bestEntity = breeders.First();
                VectorHandler.SetPositionsToVectors(bestEntity, testVectors);

                if (ErrorTester.GetError(testVectors) == 0) break;

                var newPop = PopulationHandler.CrossBreed(breeders, popSize);

                PopulationHandler.MutatePop(newPop, mutationRate);

                pop = newPop;
            }

            return VectorHandler.ConvertVectorsToMatrix(testVectors);
        }

    }
}