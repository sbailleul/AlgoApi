using System.Collections.Generic;

namespace TodoApi.Services.Reordering
{
    public interface ISorter<T>
    {
        List<List<T>> SortMatrix(List<List<T>> matrix);

    }
}