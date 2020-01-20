using System;
using AlgoApi.Core.HeuristicHandling;
using NUnit.Framework;

namespace AlgoApi.Test.Core.HeuristicHandling
{
    [TestFixture]
    public class HeuristicGridDistanceTests
    {
        [Test]
        public void ChebyshevDistanceTests()
        { 
            var heuristic = new ChebyshevDistance();
            var srcPos = new[] {0, 1};
            var dstPos = new[] {0, 10};
            var cost  = heuristic.GetHeuristic(srcPos, dstPos, 1.0d);
            Assert.AreEqual(9.0d, cost);
        }
        
        [Test]
        public void OctileDistanceTests()
        { 
            var heuristic = new OctileDistance();
            var srcPos = new[] {0, 1};
            var dstPos = new[] {0, 10};
            var cost  = heuristic.GetHeuristic(srcPos, dstPos, 1.0d);
            Assert.AreEqual(9.0d, cost);
        }
        
        [Test]
        public void ManhattanGridDistanceTests()
        {
            var heuristicCalculator = new ManhattanGridDistance();
            var sourcePosition = new[] {0, 1};
            var destinationPosition = new[] {10, 1};
            var expectedRes = Math.Abs(sourcePosition[0] - destinationPosition[0]) +
                              Math.Abs(sourcePosition[1] - destinationPosition[1]);
            Assert.AreEqual(expectedRes,
                heuristicCalculator.GetHeuristic(sourcePosition, destinationPosition,1));
        }

    }
}