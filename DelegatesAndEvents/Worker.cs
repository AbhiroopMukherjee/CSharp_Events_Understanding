using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatesAndEvents1
{
    //public delegate int WorkPerformedHandler(int hours, WorkType workType);
    //public delegate int WorkPerformedHandler(object sender, WorkPerformedEventArgs e);
    public class Worker
    {
        //public event WorkPerformedHandler WorkPerformed;
        public event EventHandler<WorkPerformedEventArgs> WorkPerformed;
        public event EventHandler WorkCompleted;

        public void DoWork(int hours, WorkType workType)
        {
            for(int i = 0; i < hours; i++)
            {
                OnWorkPerformed(i + 1, workType);
            }
            OnWorkCompleted();

        }

        protected virtual void OnWorkPerformed(int hours, WorkType workType)
        {
            // 1st way to invoke
            //if (WorkPerformed != null)
            //{
            //    WorkPerformed(hours, workType);
            //}

            // 2nd way to invoke
            //WorkPerformed?.Invoke(hours, workType);

            //3rd way to invoke
            var del = WorkPerformed as EventHandler<WorkPerformedEventArgs>;
            if (del != null)
            {
                del(this, new WorkPerformedEventArgs(hours,workType));
            }
        }

        protected virtual void OnWorkCompleted()
        {

            //3rd way to invoke
            var del = WorkCompleted as EventHandler;
            if (del != null)
            {
                del(this, EventArgs.Empty);
            }
        }

    }
}
