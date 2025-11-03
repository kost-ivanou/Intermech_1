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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.добавитьФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьФайлToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.остановитьВсеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.возобновитьВсеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pnlDownloads = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьФайлToolStripMenuItem1,
            this.остановитьВсеToolStripMenuItem,
            this.возобновитьВсеToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
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
            // добавитьФайлToolStripMenuItem1
            // 
            this.добавитьФайлToolStripMenuItem1.Name = "добавитьФайлToolStripMenuItem1";
            this.добавитьФайлToolStripMenuItem1.Size = new System.Drawing.Size(103, 20);
            this.добавитьФайлToolStripMenuItem1.Text = "Добавить файл";
            // 
            // остановитьВсеToolStripMenuItem
            // 
            this.остановитьВсеToolStripMenuItem.Name = "остановитьВсеToolStripMenuItem";
            this.остановитьВсеToolStripMenuItem.Size = new System.Drawing.Size(104, 20);
            this.остановитьВсеToolStripMenuItem.Text = "Остановить все";
            // 
            // возобновитьВсеToolStripMenuItem
            // 
            this.возобновитьВсеToolStripMenuItem.Name = "возобновитьВсеToolStripMenuItem";
            this.возобновитьВсеToolStripMenuItem.Size = new System.Drawing.Size(111, 20);
            this.возобновитьВсеToolStripMenuItem.Text = "Возобновить все";
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
        private System.Windows.Forms.ToolStripMenuItem добавитьФайлToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem остановитьВсеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem возобновитьВсеToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem добавитьФайлToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.FlowLayoutPanel pnlDownloads;
    }
}

