using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace LanguageTests
{
    [TestFixture]
    public class GenericTests
    {
        [Test]
        public void ValueTypeTests()
        {
            int t = 2;
            int i = 3;

            Console.WriteLine(t.Equals(i));
            
        }

        // private bool TestMethod<T, U>(IEnumerable<T> testList, T index) where U : class
        // {
        //     
        // }
    }
}