using System;
using System.Linq;
using AlgoApi.Core.HeuristicHandling;
using NUnit.Framework;

namespace LanguageTests.Types
{
    [TestFixture]
    public class TypeTests
    {
        [Test]
        public void DecimalTests()
        {
            Decimal t = 2;
            Decimal v = 3;
            Console.WriteLine(v+t); 
        }

        // [Test]
        // public void CheckTypes()
        // {
        //     var types = new[]
        //     {
        //         typeof(HeuristicGridDistance), typeof(ChebyshevDistance), typeof(ManhattanGridDistance),
        //         typeof(OctileDistance)
        //     };
        //
        //     foreach (var type in types)
        //     {
        //         var res = type == typeof(HeuristicGridDistance);
        //         Console.WriteLine(res);
        //     }
        //     Assert.IsTrue(types.All(t => t == typeof(HeuristicGridDistance)));
        // }
    }
}