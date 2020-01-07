using System;
using System.Collections.Generic;
using System.Linq;
using AlgoApi.Models;

namespace TodoApi.Services.Reordering
{
    public abstract class Sorter<T>
    {
        protected List<TagVector<T>> TagVectors { get; set; }

        protected void InitVectors(List<List<T>> matrix)
        {
            TagVectors = new List<TagVector<T>>();
            
            for (int i = 0; i < matrix.Count; i++)
            {
                for (int j = 0; j < matrix[i].Count; j++)
                {
                    TagVectors.Add(new TagVector<T>(new List<int>{i,j}, matrix[i][j]));        
                }
            }
        }
        
        protected void SwapVectorPos( TagVector<T> vector1,  TagVector<T> vector2)
        {
            var tmpPos = vector1.Pos;
            vector1.Pos = vector2.Pos;
            vector2.Pos = tmpPos;
        }

        
        protected double GetError()
        {
            var error = 0.0;
            foreach (var tagVector1 in TagVectors)
            {
                foreach (var tagVector2 in TagVectors)
                {
                    if (tagVector1.Tag.Equals(tagVector2.Tag) && tagVector1.Pos[0] != tagVector2.Pos[1]) error++;
                }
            }
            return error;
        }

        
        protected bool AreNeighbours(List<int> pos1, List<int> pos2)
        {
            if (pos1 == null) throw new ArgumentNullException(nameof(pos1));
            if (pos2 == null) throw new ArgumentNullException(nameof(pos2));
            
            if(pos1[0] == pos2[0]  && (pos1[1]-1 == pos2[1] || pos1[1]+1 == pos2[1] ))
            {
                return true;
            }
            return pos1[1] == pos2[1]  && (pos1[0] - 1 == pos2[0] || pos1[0] + 1 == pos2[0]);
        }

        protected void DisplayVectors(List<List<T>> matrix)
        {
            for (int i = 0; i < matrix.Count; i++)
            {
                for (int j = 0; j < matrix[i].Count; j++)
                {
                    var vector = TagVectors.FirstOrDefault(vectorEl => vectorEl.Pos.SequenceEqual(new List<int>() {i, j}));
                    Console.Write(vector.Tag + " ");
                }
                Console.WriteLine();
            }
        }
    }
}