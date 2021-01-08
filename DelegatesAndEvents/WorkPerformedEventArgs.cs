using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatesAndEvents1
{
    public class WorkPerformedEventArgs : EventArgs
    {
        public WorkPerformedEventArgs(int hours,WorkType wt)
        {
            Hours = hours;
            WorkType = wt;
        }
        public int Hours { get; set; }
        public WorkType WorkType { get; set; }
    }
}
