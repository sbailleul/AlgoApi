using System.Collections.Generic;
using AlgoApi.Models;

namespace AlgoApi.Core.Sorting.ErrorTesting
{
    public class YPositionError : IErrorTester
    {
        public int GetError<T>(List<TagVector<T>> tagVectors)
        {
            var error = 0;
            foreach (var tagVector1 in tagVectors)
            foreach (var tagVector2 in tagVectors)
                if (tagVector1.Tag.Equals(tagVector2.Tag) && tagVector1.Pos[0] != tagVector2.Pos[0])
                    error++;
            return error;
        }
    }
}