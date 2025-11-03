using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winform_4
{
    class DownloadItemControl : UserControl
    {
        private Label lblFileName;
        private ProgressBar progressBar;
        private ErrorProvider errorProvider1;
        private Button btnPauseResume;
        private Label lblDownloadSpeed;
        private Label lblStatus;
        private Button btnCancel;
        private System.ComponentModel.IContainer components;

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
            this.btnPauseResume.Size = new System.Drawing.Size(75, 21);
            this.btnPauseResume.TabIndex = 3;
            this.btnPauseResume.Text = "button1";
            this.btnPauseResume.UseVisualStyleBackColor = true;
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
            this.btnCancel.Location = new System.Drawing.Point(98, 45);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 21);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "button1";
            this.btnCancel.UseVisualStyleBackColor = true;
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
            this.Size = new System.Drawing.Size(271, 76);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
