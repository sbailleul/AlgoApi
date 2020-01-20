using System.Collections.Generic;

namespace AlgoApi.Models.Graph
{
    public class ShortestPathRequest
    {
        public List<int[]> Matrix { get; set; }
        public int[] StartVector { get; set; }
        public int[] EndVector { get; set; }
    }
}