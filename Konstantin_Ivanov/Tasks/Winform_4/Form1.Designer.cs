namespace Winform_4
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.addFileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resumeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.добавитьФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pnlDownloads = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFileToolStripMenuItem1,
            this.pauseAllToolStripMenuItem,
            this.resumeAllToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // addFileToolStripMenuItem1
            // 
            this.addFileToolStripMenuItem1.Name = "addFileToolStripMenuItem1";
            this.addFileToolStripMenuItem1.Size = new System.Drawing.Size(103, 20);
            this.addFileToolStripMenuItem1.Text = "Добавить файл";
            this.addFileToolStripMenuItem1.Click += new System.EventHandler(this.addFileToolStripMenuItem1_Click);
            // 
            // pauseAllToolStripMenuItem
            // 
            this.pauseAllToolStripMenuItem.Name = "pauseAllToolStripMenuItem";
            this.pauseAllToolStripMenuItem.Size = new System.Drawing.Size(104, 20);
            this.pauseAllToolStripMenuItem.Text = "Остановить все";
            this.pauseAllToolStripMenuItem.Click += new System.EventHandler(this.pauseAllToolStripMenuItem_Click);
            // 
            // resumeAllToolStripMenuItem
            // 
            this.resumeAllToolStripMenuItem.Name = "resumeAllToolStripMenuItem";
            this.resumeAllToolStripMenuItem.Size = new System.Drawing.Size(111, 20);
            this.resumeAllToolStripMenuItem.Text = "Возобновить все";
            this.resumeAllToolStripMenuItem.Click += new System.EventHandler(this.resumeAllToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьФайлToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(159, 26);
            // 
            // добавитьФайлToolStripMenuItem
            // 
            this.добавитьФайлToolStripMenuItem.Name = "добавитьФайлToolStripMenuItem";
            this.добавитьФайлToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.добавитьФайлToolStripMenuItem.Text = "Добавить файл";
            // 
            // pnlDownloads
            // 
            this.pnlDownloads.Location = new System.Drawing.Point(12, 37);
            this.pnlDownloads.Name = "pnlDownloads";
            this.pnlDownloads.Size = new System.Drawing.Size(776, 401);
            this.pnlDownloads.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlDownloads);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addFileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pauseAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resumeAllToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem добавитьФайлToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.FlowLayoutPanel pnlDownloads;
    }
}

