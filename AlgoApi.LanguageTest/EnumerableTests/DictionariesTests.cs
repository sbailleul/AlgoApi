using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using NUnit.Framework;

namespace AlgoApi.Test.EnumerableTests
{
    [TestFixture]
    public class DictionariesTests
    {
        [Test]
        public void KeyedCollectionTests()
        {
            var dic = new MyDic()
            {
                new Ingredient("Egg", 12.4),
                new Ingredient("Cabbage", 3.0)
            };

            Console.WriteLine(dic[0]);
            Console.WriteLine(dic["Cabbage"]);
        }

        [Test]
        public void SortedList()
        {
            var dic = new SortedList<string,Ingredient>()
            {
                {"E", new Ingredient("Egg", 12.4)},
                { "C", new Ingredient("Cabbage", 3.0)}
            };
            foreach (var el in dic)
            {
                Console.WriteLine(el);
            }
        }
        
        [Test]
        public void SortedDictionary()
        {
            var dic = new SortedDictionary<string,Ingredient>()
            {
                {"E", new Ingredient("Egg", 12.4)},
                { "C", new Ingredient("Cabbage", 3.0)}
            };
            foreach (var el in dic)
            {
                Console.WriteLine(el);
            }
        }
        
        
        [Test]
        public void Dictionary()
        {
            var dic = new Dictionary<string, Ingredient>(
                new DynamicEqualityComparer<string>((a,b) => string.Equals(a, b, StringComparison.OrdinalIgnoreCase), a => a.ToUpper().GetHashCode() )  )
            {
                {"E", new Ingredient("Egg", 12.4)},
                { "C", new Ingredient("Cabbage", 3.0)}
            };
            var el = dic["e"];
            Console.WriteLine(el);
        }
    }
    
    

    public class MyDic : KeyedCollection<string, Ingredient>
    {
        protected override string GetKeyForItem(Ingredient item)
        {
            return item.Name;
        }
    }

    public class Ingredient
    {
        public string Name { get; set; }
        public double Energy { get; set; }

        public Ingredient(string name, double energy)
        {
            Name = name;
            Energy = energy;
        }

        public override string ToString()
        {
            return "Name : " + Name + " Energy : " + Energy;
        }
    }

    public class DynamicEqualityComparer<T> : IEqualityComparer<T>
    {
        private Func<T,T, bool> EqualsFunc { get; set; } 
        private Func<T, int> HashFunc { get; set; }

        public DynamicEqualityComparer(Func<T, T, bool> equalsFunc, Func<T, int> hashFunc = null)
        {
            EqualsFunc = equalsFunc;
            HashFunc = hashFunc;
        }

        public bool Equals(T x, T y)
        {
            return EqualsFunc(x, y);
        }

        public int GetHashCode(T obj)
        {
            return HashFunc != null ? HashFunc(obj) : obj.GetHashCode();
        }
    }
}