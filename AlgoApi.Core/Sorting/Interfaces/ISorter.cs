using System.Collections.Generic;

namespace AlgoApi.Core.Sorting.Interfaces
{
    public interface ISorter<T>
    {
        T[][] SortMatrix(T[][] matrix);
    }
}