using System;
using System.Collections.Generic;
using System.Linq;
using AlgoApi.Core.MatrixHandling;
using NUnit.Framework;

namespace AlgoApi.Test
{
    [TestFixture]
    public class MatrixHandlerTests
    {
        [Test]
        public void GetRandomMatrixOfEquitableRepeatedValues()
        {
            var matrixHandler = new MatrixHandler();
            var list = Enumerable.Range(0, 3).ToArray();
            var matrix1 = matrixHandler.GetRandomMatrixOfEquitableRepeatedValues(5, list);
            var matrix2 = matrixHandler.GetRandomMatrixOfEquitableRepeatedValues(5, list);
            Assert.That(matrix1, Is.Not.EquivalentTo(matrix2));
        }

        [Test]
        public void GetRandomMatrixOfEquitableRepeatedValuesWithBadSize()
        {
            var matrixHandler = new MatrixHandler();
            var list = Enumerable.Range(0, 3).ToArray();

            Assert.Throws<ArgumentOutOfRangeException>(() =>
                matrixHandler.GetRandomMatrixOfEquitableRepeatedValues(-1, list));
        }

        [Test]
        public void GetMatrixMask()
        {
                var matrixHandler = new MatrixHandler();
                var matrix = matrixHandler.GetMatrixMask(2);
                var expectedMatrix = new []
                {
                    new[]{-2, 0},
                    new[]{2, 0},
                    new[]{0, -2},
                    new[]{0, 2}
                }; 
            
                Assert.True(Enumerable.Range(0,4).All(i => matrix[i].SequenceEqual(expectedMatrix[i])));
        }

        
    }
}