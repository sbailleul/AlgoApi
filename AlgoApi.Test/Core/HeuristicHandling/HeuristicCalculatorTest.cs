using System;
using System.Collections.Generic;
using AlgoApi.Core.HeuristicHandling;
using NUnit.Framework;
using NUnit.Framework.Internal.Execution;

namespace AlgoApi.Test
{
    [TestFixture]
    public class HeuristicCalculatorTest
    {
        [Test]
        public void MetropolisCriterium()
        {
            var heuristicCalculator = new HeuristicCalculator();
            var lastError = 10;
            var currentError = 20;
            var temperature = 0.5d;
            var res = heuristicCalculator.MetropolisCriterion(lastError, currentError, temperature);
            
            Assert.AreEqual(Math.Exp((lastError - currentError) / temperature), res);
        }
        
        [Test]
        public void CalculateManhattanDistance()
        {
            var heuristicCalculator = new HeuristicCalculator();
            var sourcePosition = new []{0,1};
            var destinationPosition = new []{10,1};
            var expectedRes = Math.Abs(sourcePosition[0] - destinationPosition[0]) + Math.Abs(sourcePosition[1] - destinationPosition[1]);
            Assert.AreEqual(expectedRes, heuristicCalculator.CalculateManhattanDistance(sourcePosition, destinationPosition));
            
        }
    }
}