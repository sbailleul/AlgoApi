using System;
using NUnit.Framework;

namespace AlgoApi.LanguageTest.DesignPatterns
{
    [TestFixture]
    public class SingletonTests
    {
        [Test]
        public void TestSingleton()
        {
            Singleton.SayHi();
            Console.WriteLine("Init instances");
            Singleton s1 = Singleton.Instance;
            Singleton s2 = Singleton.Instance;
        }
    }    

    public class Singleton
    {
        private static Lazy<Singleton> LazyInstance { get; } = new Lazy<Singleton>(()=> new Singleton(), true);
        public static Singleton Instance => LazyInstance.Value;

        private static class SingletonHandler
        {
            
            
        }
        
        // private static readonly Singleton _instance = new Singleton();

        // public static Singleton Instance => _instance;

        // static Singleton(){} //Intantiate singleton with private constructor if not instantiate yet when class is used
        private Singleton()
        {
            Console.WriteLine("New singleton by constructor");
        }

        public static void SayHi()
        {
            Console.WriteLine("Hi");
        }
        
        
    }
}