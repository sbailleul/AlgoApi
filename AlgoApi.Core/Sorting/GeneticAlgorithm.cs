using System.Linq;
using AlgoApi.Core.Sorting.PopulationHandling;
using AlgoApi.Core.VectorHandling;

namespace AlgoApi.Core.Sorting
{
    public class GeneticAlgorithm<T> : Sorter<T>
    {
        private PositionPopulationHandler<T> PositionPopulationHandler { get; } = new PositionPopulationHandler<T>();
        
        public override T[][] SortMatrix(T[][] matrix)
        {
            const int popSize = 200;
            const float breederRation = 0.2f;
            const float mutationRate = 0.1f;
            const int breedersCnt = (int) (popSize * breederRation);
            var testVectors = VectorUtils<T>.InitVectors(matrix);
            var pop = PositionPopulationHandler.GeneratePopulation(testVectors, popSize);

            while (true)
            {
                var scoredPop = PositionPopulationHandler.EvaluatePopulation(pop, testVectors);
                var breeders = PositionPopulationHandler.SelectBreeders(scoredPop, breedersCnt);
                var bestEntity = breeders.First();
                VectorUtils<T>.SetPositionsToVectors(bestEntity, testVectors);

                if (ErrorTester.GetError(testVectors) == 0) break;

                var newPop = PositionPopulationHandler.CrossBreed(breeders, popSize);

                PositionPopulationHandler.MutatePop(newPop, mutationRate);

                pop = newPop;
            }

            return VectorUtils<T>.ConvertVectorsToMatrix(testVectors);
        }
    }
}