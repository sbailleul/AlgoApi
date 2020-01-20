using System;

namespace AlgoApi.Core.HeuristicHandling
{
    public abstract class DiagonalDistance: HeuristicGridDistance
    {
        protected double GetDiagonalDirectionCost(double perpendicularDirectionCost, int dX, int dY,
            double diagonalDirectionCost)
        {
            return perpendicularDirectionCost * (dX + dY) +
                   (diagonalDirectionCost - 2 * perpendicularDirectionCost) * Math.Min(dX, dY);
        }
    }
}