using System;

namespace AlgoApi.Core.HeuristicHandling
{
    public abstract class HeuristicGridDistance
    {

        protected void CalculateXY(int[] sourcePosition, int[] destinationPosition,out int dX,out int dY)
        {
            dX = Math.Abs(sourcePosition[0] - destinationPosition[0]);
            dY = Math.Abs(sourcePosition[1] - destinationPosition[1]);
        }
        public abstract double GetHeuristic(int[] sourcePosition, int[] destinationPosition,
            double perpendicularDirectionCost);
    }
}