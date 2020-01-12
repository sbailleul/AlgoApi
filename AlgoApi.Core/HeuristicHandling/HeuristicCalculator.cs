using System;
using System.Collections.Generic;

namespace AlgoApi.Core.HeuristicHandling
{
    public class HeuristicCalculator : IHeuristicCalculator
    {
        public double MetropolisCriterion(int lastError, int currentError, double temperature)
        {
            var val = Math.Exp((lastError - currentError) / temperature);
            return val;
        }

        public int CalculateManhattanDistance(int[] sourcePosition, int[] destinationPosition)
        {
            return Math.Abs(sourcePosition[0] - destinationPosition[0]) +
                   Math.Abs(sourcePosition[1] - destinationPosition[1]);
        }
    }
}