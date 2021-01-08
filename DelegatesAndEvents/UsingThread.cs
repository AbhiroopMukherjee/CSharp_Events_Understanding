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
    public partial class UsingThread : Form
    {
        delegate void StartProcessHandler();

        public UsingThread()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            var t = new Thread(new ThreadStart(StartProcess));
            t.Start();
        }

        private void StartProcess()
        {
            progressBar1.Maximum = 100;
            
            {
                if (label1.InvokeRequired)
                {
                    var sph = new StartProcessHandler(StartProcess);
                    this.Invoke(sph);
                }
                else
                {
                    for (int i = 0; i <= 100; i++)
                    {


                        Thread.Sleep(100);
                        progressBar1.Value = i;
                        label1.Text = i.ToString();
                        label1.Refresh();
                    }
                }
            }
        }
    }
}
