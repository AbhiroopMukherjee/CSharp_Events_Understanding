using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatesAndEvents1
{
    public class ProcessData
    {
        public void Process(int a, int b, BizzRulesDelegate del)
        {
            Console.WriteLine("result:-"+ del?.Invoke(a, b)); 
        }

        public void ProcessAction(int a,int b,Action<int,int> action)
        {
            action?.Invoke(a, b);
        }

        internal void ProcessFunc(int a, int b, Func<int, int, int> del)
        {
            Console.WriteLine("Func result:-" + del?.Invoke(a, b));
        }
    }
}
