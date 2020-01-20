using System.Collections.Generic;
using System.Linq;
using AlgoApi.Core.VectorHandling;
using AlgoApi.Models;
using NUnit.Framework;

namespace AlgoApi.Test.Core.VectorHandling
{
    [TestFixture]
    public class VectorUtilsTests
    {
        [Test]
        public void ConvertVectorsToSizedMatrix()
        {
            var vectors = new List<TagVector<string>>
            {
                new TagVector<string>(new[] {0, 0}, "A"),
                new TagVector<string>(new[] {0, 1}, "A"),
                new TagVector<string>(new[] {1, 0}, "B"),
                new TagVector<string>(new[] {1, 1}, "B")
            };
            var matrix = VectorUtils<string>.ConvertVectorsToMatrix(vectors,2,2);
        
            Assert.IsTrue(matrix.SelectMany(v => v).ToList().SequenceEqual(vectors.Select(t => t.Tag).ToList()));
        }
        
        [Test]
        public void ConvertVectorsToAutoSizedMatrix()
        {
            var vectors = new List<TagVector<string>>
            {
                new TagVector<string>(new[] {0, 0}, "A"),
                new TagVector<string>(new[] {0, 1}, "A"),
                new TagVector<string>(new[] {1, 0}, "B"),
                new TagVector<string>(new[] {1, 1}, "B")
            };
            var matrix = VectorUtils<string>.ConvertVectorsToMatrix(vectors);

            Assert.IsTrue(matrix.SelectMany(v => v).ToList().SequenceEqual(vectors.Select(t => t.Tag).ToList()));
        }

        [Test]
        public void InitVectors()
        {
            var matrix = new[] {new[] {"A", "B"}, new[] {"C", "D"}};
            var matrixSize = matrix.SelectMany(l => l).Count();
            var vectors = VectorUtils<string>.InitVectors(matrix);
            var vectorCnt = 0;
            Assert.AreEqual(matrixSize, vectors.Count);

            foreach (var val in matrix.SelectMany(row => row))
            {
                Assert.AreEqual(vectors[vectorCnt].Tag, val);
                vectorCnt++;
            }
        }

        [Test]
        public void InitVectorsWithEmptyMatrix()
        {
            var matrix = new[] {new string[0]};

            Assert.IsEmpty(VectorUtils<string>.InitVectors(matrix));
        }

        [Test]
        public void SetPositionsToVectors()
        {
            const int size = 2;
            var positions = new[] {new[] {0, 1}, new[] {0, 0}};
            var vectors = Enumerable.Range(0, 2).Select(v => new TagVector<string>(new int[0], "A")).ToList();

            VectorUtils<string>.SetPositionsToVectors(positions, vectors);

            vectors.ForEach(
                v => Assert.IsTrue(
                    v.Pos.SequenceEqual(positions[vectors.IndexOf(v)])
                ));
        }

        [Test]
        public void ShuffleVectorsPositions()
        {
            var shuffledVectors = new List<TagVector<string>>
            {
                new TagVector<string>(new[] {0, 0}, "A"),
                new TagVector<string>(new[] {0, 1}, "A"),
                new TagVector<string>(new[] {1, 0}, "B"),
                new TagVector<string>(new[] {1, 1}, "B")
            };
            var vectorsPos = shuffledVectors.Select(v => v.Pos.ToList()).ToList().SelectMany(p => p).ToList();
            VectorUtils<string>.ShuffleVectorsPositions(shuffledVectors);
            var shuffledVectorsPos = shuffledVectors.SelectMany(v => v.Pos).ToList();
            Assert.That(vectorsPos, Is.EquivalentTo(shuffledVectorsPos));
            Assert.IsFalse(vectorsPos.SequenceEqual(shuffledVectorsPos));
        }

        [Test]
        public void SwapVectorPos()
        {
            var vector1Pos = new[] {1, 0};
            var vector2Pos = new[] {0, 1};
            var vector1 = new TagVector<string>(vector1Pos.ToArray(), "vector1");
            var vector2 = new TagVector<string>(vector2Pos.ToArray(), "vector2");

            VectorUtils<string>.SwapVectorPos(vector1, vector2);

            vector1.Pos.SequenceEqual(vector2.Pos);
            Assert.IsFalse(vector1.Pos.SequenceEqual(vector2.Pos));
            Assert.IsTrue(vector1Pos.SequenceEqual(vector2.Pos));
            Assert.IsTrue(vector2Pos.SequenceEqual(vector1.Pos));
        }
    }
}