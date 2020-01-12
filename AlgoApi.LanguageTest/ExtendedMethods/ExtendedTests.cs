using System;
using NUnit.Framework;

namespace AlgoApi.Test
{
    internal static class ConsoleExtend
    {
        public static void WriteLines(this object o,   int lineCnt)
        {
            for (int i = 0; i < lineCnt; i++)
            {
                Console.WriteLine();
            }
        }
    }

    
    public class Target
    {
        protected string _name;

        public string Id { get; set; } = "lower_case";
    }
    
    public class InternalTarget: Target
    {
        
    }
    
    internal static class MyTarget
    {
        public static string GetStandardID(this Target target)
        {
            return target.Id.ToUpper();
        }
        
    }
    
    
    [TestFixture]
    public class ExtendedTests
    {
        [Test]
        public void MyTarget_GetStandardID()
        {
            var t = new Target();
            Console.WriteLine(t.Id);
            Console.WriteLine(t.GetStandardID());
        }
        
        [Test]
        public void ConsoleExtend_WriteLines()
        {
            const int i = 5;
            Console.WriteLine("WRITE "+ i + " LINES :");
            i.WriteLines(i);
            Console.WriteLine(i + " LINES !!!");
        }

        
    }
} 