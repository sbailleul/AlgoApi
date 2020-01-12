using System.Collections.Generic;

namespace AlgoApi.Core.Sorting.NeighbourTesting
{
    public interface INeighbourTestter
    {
        bool AreNeighbours(int[] el1, int[] el2);
    }
}