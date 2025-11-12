using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winform_4
{
    public class DownloadItemControl : UserControl
    {
        private Label lblFileName;
        private ProgressBar progressBar;
        private ErrorProvider errorProvider1;
        private Button btnPauseResume;
        private Label lblDownloadSpeed;
        private Label lblStatus;
        private Button btnCancel;
        private System.ComponentModel.IContainer components;

        private readonly DownloadTask _task;
        private readonly Stopwatch _speedWatch = new Stopwatch();
        private long _lastBytes = 0;

        public DownloadItemControl(DownloadTask task)
        {
            InitializeComponent();
            _task = task;

            lblFileName.Text = task.FileName;
            lblStatus.Text = "Ожидание...";
            lblDownloadSpeed.Text = "0 KB/s";
            btnPauseResume.Text = "Пауза";
            btnCancel.Text = "Отмена";

            _task.ProgressChanged += Task_ProgressChanged;
            _task.StatusChanged += Task_StatusChanged;
        }

        private void Task_ProgressChanged(DownloadTask task, double progress)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => Task_ProgressChanged(task, progress)));
                return;
            }

            progressBar.Value = (int)(progress * 100);
            UpdateSpeed(task);
        }

        private void Task_StatusChanged(DownloadTask task, DownloadTaskStatus status, string msg)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => Task_StatusChanged(task, status, msg)));
                return;
            }

            lblStatus.Text = msg;

            if (status == DownloadTaskStatus.Loading) btnPauseResume.Text = "Пауза";
            else if (status == DownloadTaskStatus.Paused) btnPauseResume.Text = "Продолжить";
            else if (status == DownloadTaskStatus.Success)
            {
                btnCancel.Enabled = false;
                btnPauseResume.Enabled = false;
            }
        }

        private void UpdateSpeed(DownloadTask task)
        {
            if (!_speedWatch.IsRunning)
            {
                _speedWatch.Start();
                _lastBytes = task._uploadedBytes;
                return;
            }

            if (_speedWatch.ElapsedMilliseconds >= 1000)
            {
                long bytesUploaded = task._uploadedBytes;
                long delta = bytesUploaded - _lastBytes;
                double kbPerSec = delta / 1024.0;

                lblDownloadSpeed.Text = $"{kbPerSec} KB/s";

                _lastBytes = bytesUploaded;
                _speedWatch.Restart();
            }
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblFileName = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblDownloadSpeed = new System.Windows.Forms.Label();
            this.btnPauseResume = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(13, 10);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(35, 13);
            this.lblFileName.TabIndex = 0;
            this.lblFileName.Text = "label1";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(16, 26);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(116, 13);
            this.progressBar.TabIndex = 1;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lblDownloadSpeed
            // 
            this.lblDownloadSpeed.AutoSize = true;
            this.lblDownloadSpeed.Location = new System.Drawing.Point(138, 26);
            this.lblDownloadSpeed.Name = "lblDownloadSpeed";
            this.lblDownloadSpeed.Size = new System.Drawing.Size(35, 13);
            this.lblDownloadSpeed.TabIndex = 2;
            this.lblDownloadSpeed.Text = "label2";
            // 
            // btnPauseResume
            // 
            this.btnPauseResume.Location = new System.Drawing.Point(17, 45);
            this.btnPauseResume.Name = "btnPauseResume";
            this.btnPauseResume.Size = new System.Drawing.Size(84, 21);
            this.btnPauseResume.TabIndex = 3;
            this.btnPauseResume.Text = "button1";
            this.btnPauseResume.UseVisualStyleBackColor = true;
            this.btnPauseResume.Click += new System.EventHandler(this.btnPauseResume_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(197, 26);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(35, 13);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "label3";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(107, 45);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 21);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "button1";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // DownloadItemControl
            // 
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnPauseResume);
            this.Controls.Add(this.lblDownloadSpeed);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lblFileName);
            this.Name = "DownloadItemControl";
            this.Size = new System.Drawing.Size(496, 90);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btnPauseResume_Click(object sender, EventArgs e)
        {
            if (_task.Status == DownloadTaskStatus.Loading)
            {
                _task.Pause();
                lblStatus.Text = "Пауза";
                btnPauseResume.Text = "Продолжить";
            }
            else if (_task.Status == DownloadTaskStatus.Paused)
            {
                _task.Resume();
                lblStatus.Text = "Возобновление...";
                btnPauseResume.Text = "Пауза";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _task.Cancel();
            lblStatus.Text = "Отменено";
            btnPauseResume.Enabled = false;
            btnCancel.Enabled = false;
        }
    }
}
