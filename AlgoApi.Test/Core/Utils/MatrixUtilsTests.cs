using System;
using System.Linq;
using AlgoApi.Core.MatrixHandling;
using NUnit.Framework;

namespace AlgoApi.Test.Utils
{
    [TestFixture]
    public class MatrixUtilsTests
    {
        
        [Test]
        public void GetRandomMatrixOfEquitableRepeatedValues()
        {
            var list = Enumerable.Range(0, 3).ToArray();
            var matrix1 = MatrixUtils.GetRandomMatrixOfEquitableRepeatedValues(5, list);
            var matrix2 = MatrixUtils.GetRandomMatrixOfEquitableRepeatedValues(5, list);
            Assert.That(matrix1, Is.Not.EquivalentTo(matrix2));
        }

        [Test]
        public void GetRandomMatrixOfEquitableRepeatedValuesWithBadSize()
        {
            var list = Enumerable.Range(0, 3).ToArray();

            Assert.Throws<ArgumentOutOfRangeException>(() =>
                MatrixUtils.GetRandomMatrixOfEquitableRepeatedValues(-1, list));
        }
    }
}