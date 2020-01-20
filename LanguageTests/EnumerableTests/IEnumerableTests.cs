using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace AlgoApi.LanguageTest.EnumerableTests
{
    [TestFixture]
    public class IEnumerableTests
    {
        [Test]
        public void EnumeratorTest()
        {
            var test = new AllDaysOfWeek();
            foreach (var s in test) Console.WriteLine(s);
        }
    }

    public class AllDaysOfWeek : IEnumerable<string>
    {
        public IEnumerator<string> GetEnumerator()
        {
            yield return "Monday";
            yield return "Tuesday";
            yield return "Wednesday";
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}