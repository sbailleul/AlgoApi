using System.Collections.Generic;

namespace AlgoApi.Core.HeuristicHandling
{
    public interface IHeuristicCalculator
    {
        double MetropolisCriterion(int lastError, int currentError, double temperature);

        int CalculateManhattanDistance(int[] sourcePosition, int[] destinationPosition);
    }
}