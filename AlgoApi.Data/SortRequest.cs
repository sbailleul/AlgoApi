using System.Collections.Generic;

namespace AlgoApi.Models
{
    public class SortRequest<T>
    {
        public List<T[]> Matrix { get; set; }
    }
}