using System.Collections.Generic;

namespace AlgoApi.Models
{
    public class TagVector<T>
    {
        public TagVector(int[] pos, T tag)
        {
            Pos = pos;
            Tag = tag;
        }

        public TagVector()
        {
        }

        public int[] Pos { get; set; }
        public T Tag { get; set; }
    }
}