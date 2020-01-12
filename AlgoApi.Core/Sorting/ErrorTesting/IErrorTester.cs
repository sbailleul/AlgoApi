using System.Collections.Generic;
using AlgoApi.Models;

namespace AlgoApi.Core.Sorting.ErrorTesting
{
    public interface IErrorTester
    {
        int GetError<T>(List<TagVector<T>> tagVectors);
    }
}