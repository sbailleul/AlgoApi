using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace AlgoApi.Test.EnumerableTests
{
    [TestFixture]
    public class ISetTests
    {
    
        [Test]
        public void HashSetIntersect()
        {
            var set = new HashSet<string>() {"A","B","C"};
            var set1 = new HashSet<string>() {"E","A"};
            var arr = new[] {"E", "A"};
            
            var res1 = set1.Intersect(set).ToHashSet();
            set1.IntersectWith(arr);
            foreach (var re in res1)
            {
                Console.WriteLine(re);   
            }
            foreach (var se in set1)
            {
                Console.WriteLine(se);   
            }
            // res = set.In
        }

        [Test]
        public void HashSetUnion()
        {
            var set = new HashSet<string>() {"A", "B", "C"};
            var set1 = new HashSet<string>() {"E", "A"};
            set.UnionWith(set1);
            foreach (var s in set)
            {
                Console.WriteLine(s);
            }
        }
        
        [Test]
        public void SymmetricExcept()
        {
            var set = new HashSet<string>() {"A", "B", "C"};
            var set1 = new HashSet<string>() {"E", "A"};
            set.SymmetricExceptWith(set1);
            
            foreach (var s in set)
            {
                Console.WriteLine(s);
            }
        }
        
        [Test]
        public void ExceptWith()
        {
            var set = new HashSet<string>() {"A", "B", "C"};
            var set1 = new HashSet<string>() {"E", "A"};
            set.ExceptWith(set1);
            
            foreach (var s in set)
            {
                Console.WriteLine(s);
            }
        }
        
        [Test]
        public void SetEquals()
        {
            var set = new HashSet<string>() {"A", "B", "C"};
            var set1 = new HashSet<string>() {"E", "A"};
            var arr = new[] {"A", "A", "B", "C"};
            Console.WriteLine(set.SetEquals(arr));
        }
    }
}