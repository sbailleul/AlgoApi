using System;
using System.Threading;
using NUnit.Framework;

namespace AlgoApi.LanguageTest.EventProgrammation
{
    public delegate int BizRuleDelegate(int x, int y);

    [TestFixture]
    public class EventsTests
    {
        [Test]
        public void TestActions()
        {
            var processor = new ProcessData();
            processor.ProcessAction(2, 2, (x, y) => Console.WriteLine(x + y));
            processor.ProcessAction(2, 3, (x, y) => Console.WriteLine(x * y));
        }

        [Test]
        public void TestEventRaising()
        {
            var processor = new ProcessData();
            processor.ProcessDelegate(1, 2, (x, y) => x + y);
            processor.ProcessDelegate(1, 2, (x, y) => x * y);
            var worker = new Worker();

            worker.WorkPerformed +=
                (sender, e) =>
                    Console.WriteLine("H : " + e.Hours + " WT : " +
                                      e.WorkType); // OR new EventHandler<WorkPerformedEventArgs>(Worker_WorkPerformed) OR delegate(object sender, WorkPerformedEventArgs e) {...} OR (object sender, WorkPerformedEventArgs e) => {};
            worker.WorkCompleted += (sender, e) => Console.WriteLine("Work is done");
            worker.DoWork(4, "Generate reports");
        }

        [Test]
        public void TestFunctions()
        {
            var processor = new ProcessData();
            processor.ProcessFunction(2, 2, (x, y) => x + y);
            processor.ProcessFunction(2, 3, (x, y) => x + y);
        }

        // private static void Worker_WorkPerformed(object sender, WorkPerformedEventArgs e)
        // {
        //     Console.WriteLine("H : " + e.Hours + " WT : " + e.WorkType);
        // }
        //
        // private static void Worker_WorkCompleted(object sender, EventArgs e)
        // {
        //     Console.WriteLine("Work is done");
        // }
    }

    public class ProcessData
    {
        public void ProcessDelegate(int x, int y, BizRuleDelegate del)
        {
            var res = del(x, y);
            Console.WriteLine(res);
        }

        public void ProcessAction(int x, int y, Action<int, int> act)
        {
            act(x, y);
            Console.WriteLine("ACTION DONE");
        }

        public void ProcessFunction(int x, int y, Func<int, int, int> func)
        {
            Console.WriteLine(func(x, y));
            Console.WriteLine("FUNCTION DONE");
        }
    }

    public class WorkPerformedEventArgs : EventArgs
    {
        public WorkPerformedEventArgs(int hours, string workType)
        {
            Hours = hours;
            WorkType = workType;
        }

        public int Hours { get; set; }
        public string WorkType { get; set; }
    }

    public class Worker
    {
        public event EventHandler<WorkPerformedEventArgs> WorkPerformed;
        public event EventHandler WorkCompleted;

        public void DoWork(int hours, string workType)
        {
            for (var i = 0; i < hours; i++)
            {
                Thread.Sleep(1000);
                OnWorkPerformed(this, new WorkPerformedEventArgs(i + 1, workType));
            }

            OnWorkCompleted();
        }

        protected virtual void OnWorkPerformed(object sender, WorkPerformedEventArgs e)
        {
            WorkPerformed?.Invoke(sender, e);
        }

        protected virtual void OnWorkCompleted()
        {
            WorkCompleted?.Invoke(this, EventArgs.Empty);
        }
    }
}


// public delegate int WorkPerformedHandler(object sender, WorkPerformedEventArgs e);
// var del1 = new WorkPerformedHandler(Manager_WorkPerformed1);
// var del2 = new WorkPerformedHandler(Manager_WorkPerformed2);
// var del3 = new WorkPerformedHandler(Manager_WorkPerformed3);
//
// del1 += del2 + del3;

// Console.WriteLine(del1(10, "4EGERRG"));
// ;
// DoWork(del1);


// static int Manager_WorkPerformed1(int hours, string workType)
// {
//     Console.WriteLine("W1 Hours : " + hours + " | Work type : " + workType);
//     return hours + 1;
// }
//
//
// static int Manager_WorkPerformed2(int hours, string workType)
// {
//     Console.WriteLine("W2 Hours : " + hours + " | Work type : " + workType);
//     return hours + 2;
// }
//
// static int Manager_WorkPerformed3(int hours, string workType)
// {
//     Console.WriteLine("W3 Hours : " + hours + " | Work type : " + workType);
//     return hours + 3;
// }
//
// static void DoWork(WorkPerformedHandler del)
// {
//     del(5, "Salut");
// }