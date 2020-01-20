using System;
using AlgoApi.Core.HeuristicHandling;
using AlgoApi.Core.Sorting.NeighbourTesting;
using AlgoApi.Core.TemperatureUpdating;
using AlgoApi.Core.VectorHandling;
using AlgoApi.Models;

namespace AlgoApi.Core.Sorting
{
    public class SimulatedAnnealing<T> : Sorter<T>
    {
        private INeighbourTester NeighbourTester { get; }

        private ITemperatureUpdater TemperatureUpdater { get; }

        public SimulatedAnnealing()
        {
            TemperatureUpdater = new GeomerticUpdater();
            NeighbourTester = new CrossNeighbourTester();
        }

        public override T[][] SortMatrix(T[][] matrix)
        {
            var tagVectors = VectorUtils<T>.InitVectors(matrix);
            var temperature = 7f;
            var error = 0;
            var stagnation = 0;
            var rand = new Random();

            do
            {
                TagVector<T> tagVector1, tagVector2;
                var previousError = error;
                error = ErrorTester.GetError(tagVectors);
                do
                {
                    tagVector1 = tagVectors[rand.Next() % tagVectors.Count];
                    tagVector2 = tagVectors[rand.Next() % tagVectors.Count];
                } while (!NeighbourTester.AreNeighbours(tagVector1.Pos, tagVector2.Pos));

                VectorUtils<T>.SwapVectorPos(tagVector1, tagVector2);
                var newError = ErrorTester.GetError(tagVectors);

                if (rand.NextDouble() <= HeuristicUtils.MetropolisCriterion(error, newError, temperature))
                    error = newError;
                else
                    VectorUtils<T>.SwapVectorPos(tagVector1, tagVector2);

                stagnation = error == previousError ? stagnation + 1 : 0;

                if (stagnation > 600) temperature = 7f;

                temperature = TemperatureUpdater.UpdateTemperature(temperature, 0.999f);
                temperature = MathF.Max(temperature, 0.0f);
            } while (error > 0);

            return VectorUtils<T>.ConvertVectorsToMatrix(tagVectors);
        }
    }
}