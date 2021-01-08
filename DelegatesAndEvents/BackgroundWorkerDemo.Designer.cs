namespace ThreadsAndDelgeate
{
    partial class BackgroundWorkerDemo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Start = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.OutputLabel = new System.Windows.Forms.Label();
            this.MyBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(90, 126);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(158, 64);
            this.Start.TabIndex = 0;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(506, 126);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(150, 63);
            this.Cancel.TabIndex = 1;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(90, 259);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(566, 45);
            this.progressBar1.TabIndex = 2;
            // 
            // OutputLabel
            // 
            this.OutputLabel.AutoSize = true;
            this.OutputLabel.Location = new System.Drawing.Point(459, 334);
            this.OutputLabel.Name = "OutputLabel";
            this.OutputLabel.Size = new System.Drawing.Size(97, 20);
            this.OutputLabel.TabIndex = 3;
            this.OutputLabel.Text = "OutputLabel";
            // 
            // MyBackgroundWorker
            // 
            this.MyBackgroundWorker.WorkerReportsProgress = true;
            this.MyBackgroundWorker.WorkerSupportsCancellation = true;
            this.MyBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.MyBackgroundWorker_DoWork);
            this.MyBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.MyBackgroundWorker_ProgressChanged);
            this.MyBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.MyBackgroundWorker_RunWorkerCompleted);
            // 
            // BackgroundWorkerDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.OutputLabel);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Start);
            this.Name = "BackgroundWorkerDemo";
            this.Text = "BackgroundWorkerDemo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label OutputLabel;
        private System.ComponentModel.BackgroundWorker MyBackgroundWorker;
    }
}