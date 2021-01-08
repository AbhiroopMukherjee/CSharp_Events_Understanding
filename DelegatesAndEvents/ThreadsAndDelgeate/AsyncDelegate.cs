using System;
using System.Threading;
using System.Windows.Forms;

namespace ThreadsAndDelgeate
{
    public partial class AsyncDelegate : Form
    {
        delegate void UpdateProgressDelegate(int val);

        delegate void ShowProgressDelegate(int val);
        public AsyncDelegate()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //StartProgress(100);
            var del = new UpdateProgressDelegate(StartProgress);
            del.BeginInvoke(100, null, null);
            MessageBox.Show("Done");
        }

        private void StartProgress(int v)
        {
            progressBar1.Maximum = v;

            for (int i = 0; i <= v; i++)
            {
                Thread.Sleep(10);
                ShowProgress(i);
            }
        }

        private void ShowProgress(int val)
        {
            if (label1.InvokeRequired)
            {
                var del = new ShowProgressDelegate(ShowProgress);
                this.BeginInvoke(del, val);
            }
            else
            {
                label1.Text = val.ToString();
                label1.Refresh();
                progressBar1.Value = val;
            }

            
        }
    }
}
