using System;
using System.Collections.Generic;
using System.Text;
using CommBetweenComponents.Model;

namespace CommBetweenComponents
{
    public sealed class Mediator
    {
        private static readonly Mediator _Instance = new Mediator();

        private Mediator()
        {
        }

        public static Mediator GetInstance()
        {
            return _Instance;
        }

        public event EventHandler<JobChangedEventArgs> JobChanged;

        public void OnJobChanged(object sender, Job job)
        {
            var jobChangeDelegate = JobChanged as EventHandler<JobChangedEventArgs>;
            if (jobChangeDelegate != null)
            {
                jobChangeDelegate(sender,new JobChangedEventArgs{Job=job});
            }
        }

    }
}
