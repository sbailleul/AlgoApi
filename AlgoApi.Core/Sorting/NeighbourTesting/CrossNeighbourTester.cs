using System.Collections.Generic;

namespace AlgoApi.Core.Sorting.NeighbourTesting
{
    public class CrossNeighbourTester : INeighbourTestter
    {
        public bool AreNeighbours(int[] el1, int[] el2)
        {
            if (el1[0] == el2[0] &&
                (el1[1] - 1 == el2[1] || el1[1] + 1 == el2[1])) return true;
            return el1[1] == el2[1] &&
                   (el1[0] - 1 == el2[0] || el1[0] + 1 == el2[0]);
        }
    }
}