using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace DelegatesAndEvents1
{
    //public delegate int WorkPerformedHandler(int hours, WorkType workType);
    public delegate int BizzRulesDelegate(int x, int y);
    class Program
    {
        
        static void Main(string[] args)
        {
            //~~~~~Without using Events
            //WorkPerformedHandler del1 = new WorkPerformedHandler(WorkPerformed1);
            //WorkPerformedHandler del2 = new WorkPerformedHandler(WorkPerformed2);
            //WorkPerformedHandler del3 = new WorkPerformedHandler(WorkPerformed3);
            //del1(5, WorkType.Golf);
            //del2(10, WorkType.GoToMeetings);
            //del1 += del2 + del3;
            //DoWork(del1);

            //~~~~~Using Events
            //Worker abhmu = new Worker();
            //abhmu.WorkPerformed += new WorkPerformedHandler(WorkPerformed1);
            //abhmu.WorkPerformed += new WorkPerformedHandler(WorkPerformed2);
            //abhmu.WorkPerformed += new WorkPerformedHandler(WorkPerformed3);


            Worker abhmu = new Worker();
            //abhmu.WorkPerformed += new EventHandler<WorkPerformedEventArgs>(WorkPerformedE1);
            //abhmu.WorkPerformed += new EventHandler<WorkPerformedEventArgs>(WorkPerformedE2);

            //~~~~~ Delegate inference
            //abhmu.WorkPerformed += WorkPerformedE1;

            //~~~~~~~ Anonymous Methods
            //abhmu.WorkPerformed += delegate (object sender, WorkPerformedEventArgs e)
            //{
            //    Console.WriteLine("Hello-->"+e.Hours + "  " + e.WorkType);
            //};
            //abhmu.WorkPerformed += WorkPerformedE2;
            //abhmu.WorkCompleted += new EventHandler(WorkCompleted);


            //~~~~~~~ Using Lambdas
            abhmu.WorkPerformed += (s,e) => Console.WriteLine("WPE1 called " + e.Hours.ToString() + "  " + e.WorkType.ToString());
            abhmu.WorkPerformed += (s, e) =>
            {
                Console.WriteLine("WPE2 called " + e.Hours.ToString() + "  " + e.WorkType.ToString());
            };
            abhmu.WorkCompleted += WorkCompleted;
            abhmu.DoWork(3, WorkType.GoToMeetings);


            // ~~~~~ Using Lambdas with custom delegates
            BizzRulesDelegate addDel = (x, y) => x + y;
            BizzRulesDelegate multiplyDel = (x, y) => x * y;
            var data = new ProcessData();
            data.Process(2, 3, multiplyDel);
            data.Process(2, 3, addDel);


            //~~~~~~ Using Action<T>
            Action<int, int> addAction = (x, y) => Console.WriteLine("Action result:- "+ (x + y));
            Action<int, int> multiplyAction = (x, y) => Console.WriteLine("Action result:- " + (x * y));
            data.ProcessAction(2, 3, addAction);
            data.ProcessAction(2, 3, multiplyAction);


            //~~~~~~ Using Func<T,TResult>
            Func<int, int,int> addFuncDel = (x, y) => x + y;
            Func<int, int,int> multiplyFuncDel = (x, y) => x * y;
            data.ProcessFunc(2, 3, addFuncDel);
            data.ProcessFunc(2, 3, multiplyFuncDel);


            //~~~~~~ Using Linq which uses Func & Action behind the scenes - Showcases good use of Lambda's
            var custs = new List<Customer>
            {
                new Customer{City = "Phoenix", FirstName = "John", LastName = "Doe", ID=1},
                new Customer{City = "Phoenix", FirstName = "Jane", LastName = "Doe", ID=500},
                new Customer{City = "Seatle", FirstName = "Suki", LastName = "Pizzoro", ID=3},
                new Customer{City = "NY", FirstName = "Michelle", LastName = "Smith", ID=4}
            };

            var phxCusts = custs.Where(c => c.City == "Phoenix" && c.ID < 500)
                .OrderBy(c => c.FirstName);

            foreach (var cust in phxCusts)
            {
                Console.WriteLine(cust.FirstName);
            }
        }

        //~~~~~~~~~ With EventHandler<T>
        private static void WorkPerformedE1(object sender, WorkPerformedEventArgs e)
        {
            Console.WriteLine("WPE1 called " + e.Hours.ToString() + "  " + e.WorkType.ToString());
        }

        private static void WorkPerformedE2(object sender, WorkPerformedEventArgs e)
        {
            Console.WriteLine("WPE2 called " + e.Hours.ToString() + "  " + e.WorkType.ToString());
        }

        private static void WorkCompleted(object sender, EventArgs e)
        {
            Console.WriteLine("Work Completed " + e.ToString()); ;
        }


        //~~~~~~~~ With Custom Delegates
        //static void DoWork(WorkPerformedHandler del)
        //{
        //    int final = del(5, WorkType.Golf);
        //    Console.WriteLine(final); //Only returns from the last event handler in invocation list
        //}
        //static int WorkPerformed1(int hours, WorkType wt)
        //{
        //    Console.WriteLine("WP1 called "+ hours.ToString() + "  " + wt.ToString());
        //    return hours + 1;
        //}

        //static int WorkPerformed2(int hours, WorkType wt)
        //{
        //    Console.WriteLine("WP2 called " + hours.ToString() + "  " + wt.ToString());
        //    return hours + 2;
        //}

        //static int WorkPerformed3(int hours, WorkType wt)
        //{
        //    Console.WriteLine("WP3 called " + hours.ToString() + "  " + wt.ToString());
        //    return hours + 3;
        //}

    }

    public enum WorkType
    {
        GoToMeetings,
        Golf,
        GenerateReports
    }

}
