namespace AlgoApi.Core.HeuristicHandling
{
    public sealed class ManhattanGridDistance: HeuristicGridDistance
    {
        public override double GetHeuristic(int[] sourcePosition, int[] destinationPosition,
            double perpendicularDirectionCost)
        {
            CalculateXY(sourcePosition, destinationPosition, out var dX, out var dY);
            return perpendicularDirectionCost * (dX + dY);
        }
    }
}