namespace Winform_6
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.progressCpu = new System.Windows.Forms.ProgressBar();
            this.progressRam = new System.Windows.Forms.ProgressBar();
            this.progressNet = new System.Windows.Forms.ProgressBar();
            this.btnInterval = new System.Windows.Forms.Button();
            this.lblCpu = new System.Windows.Forms.Label();
            this.lblRam = new System.Windows.Forms.Label();
            this.lblNet = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Загрузка процессора";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(335, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Используемая оперативная память";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(195, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Сетевая активность";
            // 
            // progressCpu
            // 
            this.progressCpu.Location = new System.Drawing.Point(235, 27);
            this.progressCpu.Name = "progressCpu";
            this.progressCpu.Size = new System.Drawing.Size(164, 24);
            this.progressCpu.TabIndex = 3;
            // 
            // progressRam
            // 
            this.progressRam.Location = new System.Drawing.Point(342, 62);
            this.progressRam.Name = "progressRam";
            this.progressRam.Size = new System.Drawing.Size(164, 24);
            this.progressRam.TabIndex = 4;
            // 
            // progressNet
            // 
            this.progressNet.Location = new System.Drawing.Point(235, 95);
            this.progressNet.Maximum = 50000;
            this.progressNet.Name = "progressNet";
            this.progressNet.Size = new System.Drawing.Size(164, 24);
            this.progressNet.TabIndex = 5;
            // 
            // btnInterval
            // 
            this.btnInterval.Location = new System.Drawing.Point(620, 12);
            this.btnInterval.Name = "btnInterval";
            this.btnInterval.Size = new System.Drawing.Size(177, 57);
            this.btnInterval.TabIndex = 6;
            this.btnInterval.UseVisualStyleBackColor = true;
            this.btnInterval.Click += new System.EventHandler(this.btnInterval_Click);
            // 
            // lblCpu
            // 
            this.lblCpu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCpu.Location = new System.Drawing.Point(405, 28);
            this.lblCpu.Name = "lblCpu";
            this.lblCpu.Size = new System.Drawing.Size(209, 23);
            this.lblCpu.TabIndex = 7;
            // 
            // lblRam
            // 
            this.lblRam.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblRam.Location = new System.Drawing.Point(512, 62);
            this.lblRam.Name = "lblRam";
            this.lblRam.Size = new System.Drawing.Size(102, 24);
            this.lblRam.TabIndex = 8;
            // 
            // lblNet
            // 
            this.lblNet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblNet.Location = new System.Drawing.Point(405, 96);
            this.lblNet.Name = "lblNet";
            this.lblNet.Size = new System.Drawing.Size(197, 22);
            this.lblNet.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblNet);
            this.Controls.Add(this.lblRam);
            this.Controls.Add(this.lblCpu);
            this.Controls.Add(this.btnInterval);
            this.Controls.Add(this.progressNet);
            this.Controls.Add(this.progressRam);
            this.Controls.Add(this.progressCpu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Данные о системе";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar progressCpu;
        private System.Windows.Forms.ProgressBar progressRam;
        private System.Windows.Forms.ProgressBar progressNet;
        private System.Windows.Forms.Button btnInterval;
        private System.Windows.Forms.Label lblCpu;
        private System.Windows.Forms.Label lblRam;
        private System.Windows.Forms.Label lblNet;
    }
}

