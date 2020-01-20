using System;

namespace AlgoApi.Core.HeuristicHandling
{
    public sealed class OctileDistance: DiagonalDistance
    {
        public override double GetHeuristic(int[] sourcePosition, int[] destinationPosition,
            double perpendicularDirectionCost)
        {
            var diagonalDirectionCost = Math.Sqrt(2);
            CalculateXY(sourcePosition, destinationPosition, out var dX, out var dY);
            return GetDiagonalDirectionCost(perpendicularDirectionCost, dX, dY, diagonalDirectionCost);
        }
        
    }
}