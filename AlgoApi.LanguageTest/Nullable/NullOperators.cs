using System;
using NUnit.Framework;

namespace AlgoApi.Test.Nullable
{
    [TestFixture]
    public class NullOperators
    {
        [Test]
        public void Coalescing()
        {
            int? i = null;
            Console.WriteLine( i?? 0);
        }
    }
}