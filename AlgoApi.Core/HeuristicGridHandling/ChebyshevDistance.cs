using System;

namespace AlgoApi.Core.HeuristicHandling
{
    public sealed class ChebyshevDistance: DiagonalDistance
    {
        public override double GetHeuristic(int[] sourcePosition, int[] destinationPosition,
            double perpendicularDirectionCost)
        {
            CalculateXY(sourcePosition, destinationPosition, out var dX, out var dY);
            return GetDiagonalDirectionCost(perpendicularDirectionCost, dX, dY, perpendicularDirectionCost);
        }


    }
}