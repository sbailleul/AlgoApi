using System;
using System.Linq;
using AlgoApi.Core.MatrixGenerating;
using AlgoApi.Core.MatrixHandling;
using NUnit.Framework;

namespace AlgoApi.Test.Core.MatrixHandling
{
    [TestFixture]
    public class MatrixHandlerTests
    {
        [Test]
        public void Get4DMatrixMask()
        {
            var matrixHandler = new Matrix4DGenerator();
            var matrix = matrixHandler.GetMatrix(2);
            var expectedMatrix = new[]
            {
                new[] {-2, 0},
                new[] {2, 0},
                new[] {0, -2},
                new[] {0, 2}
            };

            Assert.True(Enumerable.Range(0, 4).All(i => matrix[i].SequenceEqual(expectedMatrix[i])));
        }
        
        [Test]
        public void Get8DMatrixMask()
        {
            var matrixHandler = new Matrix8DGenerator();
            var matrix = matrixHandler.GetMatrix(2);
            var expectedMatrix = new[]
            {
                new[] {2 * -1, 2*-1},
                new[] {2 * -1, 2},
                new[] {2, 2*-1},
                new[] {2, 2},
                new[] {2 * -1, 0},
                new[] {2, 0},
                new[] {0, 2 * -1},
                new[] {0, 2}
            };

            Assert.True(Enumerable.Range(0, 8).All(i => matrix[i].SequenceEqual(expectedMatrix[i])));
        }

    }
}