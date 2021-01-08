using CommBetweenComponents.Model;
using System;

namespace CommBetweenComponents
{
    public class JobChangedEventArgs:EventArgs
    {
        public Job Job { get; set; }
    }
}