using System.Collections.Generic;

namespace AlgoApi.Models
{
    public class GraphRequest
    {
        public List<List<int>> Matrix { get; set; }
        public List<int> StartVector { get; set; }
        public List<int> EndVector { get; set; }
    }
}