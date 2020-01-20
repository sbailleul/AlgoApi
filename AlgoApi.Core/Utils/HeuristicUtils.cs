using System;

namespace AlgoApi.Core.HeuristicHandling
{
    public static class HeuristicUtils
    {
        public static double MetropolisCriterion(int oldError, int currentError, double temperature)
        {
            var val = Math.Exp((oldError - currentError) / temperature);
            return val;
        }
    }
}