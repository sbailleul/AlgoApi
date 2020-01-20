using System;
using NUnit.Framework;

namespace AlgoApi.LanguageTest.Inheritence
{
    public class BClass

    {
        public virtual string Name { get; set; }

        public virtual void GetInfo()

        {
            Console.WriteLine("Learn C# B");
        }
    }

    // Derived Class

    public class DClass : BClass

    {
        private string name;

        public override string Name

        {
            get => name;

            set

            {
                if (!string.IsNullOrEmpty(value))
                    name = value;

                else
                    name = "No Value";
            }
        }

        public override void GetInfo()

        {
            Console.WriteLine("Welcome to D");
        }
    }

    public class CClass : BClass

    {
        private string name;

        public override string Name

        {
            get => name;

            set

            {
                if (!string.IsNullOrEmpty(value))
                    name = value;

                else
                    name = "No Value";
            }
        }

        public new void GetInfo()

        {
            Console.WriteLine("Welcome to C");
        }
    }


    [TestFixture]
    public class VirtualTests
    {
        [Test]
        public void TestOverride()
        {
            BClass d = new DClass();
            BClass c = new CClass();
            var rB = new BClass();
            var rD = new DClass();
            var rC = new CClass();

            Console.WriteLine("BASE TYPE : ");
            d.GetInfo();
            c.GetInfo();
            Console.WriteLine("DERIVED TYPE:");
            rB.GetInfo();
            rD.GetInfo();
            rC.GetInfo();
        }
    }
}