using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using AlgoApi.Models;

namespace TodoApi.Services.Reordering
{
    public class NaiveSearch<T>:Sorter<T>, INaiveSearch<T>
    {
        
        public List<List<T>> SortMatrix(List<List<T>> matrix)
        {
            InitVectors(matrix);
            var error = 0.0d;
            var switchCnt = 7000;
            var random = new Random();
            TagVector<T> tagVector1;
            TagVector<T> tagVector2;

            do
            {
                error = GetError();
                do
                {
                    tagVector1 = TagVectors[random.Next() % TagVectors.Count];
                    tagVector2 = TagVectors[random.Next() % TagVectors.Count];
                } while (!AreNeighbours(tagVector1.Pos, tagVector2.Pos));
                
                SwapVectorPos(tagVector1, tagVector2);
                var newError = GetError();
                if (newError > error)
                {
                    SwapVectorPos(tagVector1, tagVector2);
                }
                else
                {
                    error = newError;
                }

                switchCnt--;
                DisplayVectors(matrix);
            } while (error > 0 && switchCnt >= 0);

            throw new NotImplementedException();
        }

    }
}