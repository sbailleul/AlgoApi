using System;
using AlgoApi.Core.EnumerableHandling;
using AlgoApi.Core.Sorting.ErrorTesting;
using AlgoApi.Core.Sorting.PopulationHandling;
using AlgoApi.Core.VectorHandling;
using NUnit.Framework;

namespace AlgoApi.LanguageTest.DesignPatterns
{
    [TestFixture]
    public class DependencyInjection
    {
        [Test]
        public void InjectorTests()
        {
            
            var inj = new Injector();
            inj.Bind<DateTime>(DateTime.Now);
            // inj.Bind<IVectorHandler<string>, VectorUtils<string>>();
            // inj.Bind<IEnumerableStrategyByIndex,ArrayByIndex>();
            inj.Bind<IErrorTester, YPositionError>();
            PositionPopulationHandler<string> popHandler= inj.Resolve<PositionPopulationHandler<string>>();
            popHandler.ToString();
            var date1 = inj.Resolve<DateTime>();
            var date2 = inj.Resolve<DateTime>();
            Assert.AreEqual(date1, date2);
            
        }
    }
}