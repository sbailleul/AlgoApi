using System;
using System.Collections.Generic;
using AlgoApi.Core.HeuristicHandling;
using AlgoApi.Core.Sorting.Interfaces;
using AlgoApi.Core.Sorting.NeighbourTesting;
using AlgoApi.Core.TemperatureUpdating;
using AlgoApi.Models;

namespace AlgoApi.Core.Sorting
{
    public class SimulatedAnnealing<T> : Sorter<T>, ISimulatedAnnealing<T>
    {
        public SimulatedAnnealing()
        {
            TemperatureUpdater = new GeomerticUpdater();
            NeighbourTester = new CrossNeighbourTester();
            HeuristicCalculator = new HeuristicCalculator();
        }

        private INeighbourTestter NeighbourTester { get; }

        private ITemperatureUpdater TemperatureUpdater { get; }

        private HeuristicCalculator HeuristicCalculator { get; }

        public T[][] SortMatrix(T[][] matrix)
        {
            var tagVectors = VectorHandler.InitVectors(matrix);
            var temperature = 7f;
            var error = 0;
            var stagnation = 0;
            do
            {
                TagVector<T> tagVector1, tagVector2;
                var previousError = error;
                error = ErrorTester.GetError(tagVectors);
                do
                {
                    tagVector1 = tagVectors[RandGenerator.Next() % tagVectors.Count];
                    tagVector2 = tagVectors[RandGenerator.Next() % tagVectors.Count];
                } while (!NeighbourTester.AreNeighbours(tagVector1.Pos, tagVector2.Pos));

                VectorHandler.SwapVectorPos(tagVector1, tagVector2);
                var newError = ErrorTester.GetError(tagVectors);

                if (RandGenerator.NextDouble() <= HeuristicCalculator.MetropolisCriterion(error, newError, temperature))
                    error = newError;
                else
                    VectorHandler.SwapVectorPos(tagVector1, tagVector2);

                stagnation = error == previousError ? stagnation + 1 : 0;

                if (stagnation > 600) temperature = 7f;

                temperature = TemperatureUpdater.UpdateTemperature(temperature, 0.999f);
                temperature = MathF.Max(temperature, 0.0f);
                // VectorHandler.DisplayVectors(TagVectors);
            } while (error > 0);

            return VectorHandler.ConvertVectorsToMatrix(tagVectors);
        }
    }
}