using System.Collections.Generic;
using System.Numerics;

namespace AlgoApi.Models
{
    public class TagVector<T>
    {
        public List<int> Pos { get; set; }
        public T Tag { get; set; }

        public TagVector(List<int> pos, T tag)
        {
            Pos = pos;
            Tag = tag;
        }
    }
}