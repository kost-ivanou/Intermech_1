namespace Winform_5
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
            this.treeView = new System.Windows.Forms.TreeView();
            this.btnSearchStart = new System.Windows.Forms.Button();
            this.lblDirectory = new System.Windows.Forms.Label();
            this.btnChooseDirectory = new System.Windows.Forms.Button();
            this.txtMask = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nmbThreads = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nmbThreads)).BeginInit();
            this.SuspendLayout();
            // 
            // treeView
            // 
            this.treeView.Location = new System.Drawing.Point(21, 142);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(651, 399);
            this.treeView.TabIndex = 0;
            // 
            // btnSearchStart
            // 
            this.btnSearchStart.Location = new System.Drawing.Point(21, 92);
            this.btnSearchStart.Name = "btnSearchStart";
            this.btnSearchStart.Size = new System.Drawing.Size(115, 35);
            this.btnSearchStart.TabIndex = 1;
            this.btnSearchStart.Text = "Начать поиск";
            this.btnSearchStart.UseVisualStyleBackColor = true;
            this.btnSearchStart.Click += new System.EventHandler(this.btnSearchStart_Click);
            // 
            // lblDirectory
            // 
            this.lblDirectory.AutoSize = true;
            this.lblDirectory.Location = new System.Drawing.Point(152, 12);
            this.lblDirectory.Name = "lblDirectory";
            this.lblDirectory.Size = new System.Drawing.Size(0, 13);
            this.lblDirectory.TabIndex = 3;
            // 
            // btnChooseDirectory
            // 
            this.btnChooseDirectory.Location = new System.Drawing.Point(21, 7);
            this.btnChooseDirectory.Name = "btnChooseDirectory";
            this.btnChooseDirectory.Size = new System.Drawing.Size(125, 23);
            this.btnChooseDirectory.TabIndex = 4;
            this.btnChooseDirectory.Text = "Выбрать папку";
            this.btnChooseDirectory.UseVisualStyleBackColor = true;
            this.btnChooseDirectory.Click += new System.EventHandler(this.btnChooseDirectory_Click);
            // 
            // txtMask
            // 
            this.txtMask.Location = new System.Drawing.Point(187, 37);
            this.txtMask.Name = "txtMask";
            this.txtMask.Size = new System.Drawing.Size(129, 20);
            this.txtMask.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Введите маску для поиска";
            // 
            // nmbThreads
            // 
            this.nmbThreads.Location = new System.Drawing.Point(187, 66);
            this.nmbThreads.Name = "nmbThreads";
            this.nmbThreads.Size = new System.Drawing.Size(105, 20);
            this.nmbThreads.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Выберите количество потоков";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 553);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nmbThreads);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMask);
            this.Controls.Add(this.btnChooseDirectory);
            this.Controls.Add(this.lblDirectory);
            this.Controls.Add(this.btnSearchStart);
            this.Controls.Add(this.treeView);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.nmbThreads)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.Button btnSearchStart;
        private System.Windows.Forms.Label lblDirectory;
        private System.Windows.Forms.Button btnChooseDirectory;
        private System.Windows.Forms.TextBox txtMask;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nmbThreads;
        private System.Windows.Forms.Label label2;
    }
}

