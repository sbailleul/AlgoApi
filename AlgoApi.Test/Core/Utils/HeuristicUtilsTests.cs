using System;
using AlgoApi.Core.HeuristicHandling;
using NUnit.Framework;

namespace AlgoApi.Test.Utils
{
    [TestFixture]
    public class HeuristicUtilsTests
    {
        [Test]
        public void MetropolisCriterion()
        {
            var lastError = 10;
            var currentError = 20;
            var temperature = 0.5d;
            var res = HeuristicUtils.MetropolisCriterion(lastError, currentError, temperature);

            Assert.AreEqual(Math.Exp((lastError - currentError) / temperature), res);
        }
    }
}