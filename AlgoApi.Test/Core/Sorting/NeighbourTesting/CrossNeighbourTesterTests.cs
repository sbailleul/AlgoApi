using AlgoApi.Core.Sorting.NeighbourTesting;
using NUnit.Framework;

namespace AlgoApi.Test.Core.Sorting.NeighbourTesting
{
    [TestFixture]
    public class CrossNeighbourTesterTests
    {
        [Test]
        public void AreNeighbours()
        {
            var neighbourTester = new CrossNeighbourTester();
            var pos1 = new[] {0, 0};
            var pos2 = new[] {1, 1};

            Assert.IsFalse(neighbourTester.AreNeighbours(pos1, pos2));
            pos1 = new[] {1, 0};
            Assert.IsTrue(neighbourTester.AreNeighbours(pos1, pos2));
        }
    }
}