using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThreadsAndDelgeate
{
    public partial class BackgroundWorkerDemo : Form
    {
        public BackgroundWorkerDemo()
        {
            InitializeComponent();
        }

        private long Calculate(BackgroundWorker instance, DoWorkEventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                if (instance.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    Thread.Sleep(100);
                    instance.ReportProgress(i);
                }

            }

            return 0L;
        }

        private void Start_Click(object sender, EventArgs e)
        {
            Start.Enabled = false;
            Cancel.Enabled = true;
            OutputLabel.Text = "";

            MyBackgroundWorker.RunWorkerAsync();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            MyBackgroundWorker.CancelAsync();
            Cancel.Enabled = false;
        }

        private void MyBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = Calculate(sender as BackgroundWorker, e);
        }

        private void MyBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void MyBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Start.Enabled = true;
            progressBar1.Value = 0;

            if (!e.Cancelled)
            {
                OutputLabel.Text = "Background Work Completed!";
            }
            else
            {
                OutputLabel.Text = "Cancelled";
            }
        }

        
    }
}
