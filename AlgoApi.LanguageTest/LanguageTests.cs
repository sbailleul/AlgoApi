using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace AlgoApi.Test
{
    [TestFixture]
    public class LanguageTests
    {
        
        IEnumerable<string> _strings;
        
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