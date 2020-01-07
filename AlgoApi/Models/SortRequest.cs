using System.Collections.Generic;

namespace AlgoApi.Models
{
    public class SortRequest<T>
    {
        public List<List<T>> Matrix { get; set; } 
    }
}