using System;
using System.Collections.Generic;
using System.Linq;
using AlgoApi.LanguageTest.ExtendedMethods;
using NUnit.Framework;

namespace AlgoApi.LanguageTest
{
    [TestFixture]
    public class LanguageTests
    {
        private IEnumerable<string> _strings;

        [Test]
        public void ArrayTest()
        {
            var target = new Target();
            var arr = new[] {1, 2};
            var list = new StringList();


            list.Count();

            Array.Reverse(arr);
            var t = arr.Reverse();
        }
    }
}