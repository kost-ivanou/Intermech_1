namespace Winform_7
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.lbNotes = new System.Windows.Forms.ListBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(32, 24);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(126, 34);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Добавить заметку";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lbNotes
            // 
            this.lbNotes.FormattingEnabled = true;
            this.lbNotes.Location = new System.Drawing.Point(32, 64);
            this.lbNotes.Name = "lbNotes";
            this.lbNotes.Size = new System.Drawing.Size(552, 303);
            this.lbNotes.TabIndex = 1;
            this.lbNotes.DoubleClick += new System.EventHandler(this.lbNotes_DoubleClick);
            this.lbNotes.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbNotes_MouseDown);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(248, 37);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(178, 20);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(248, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Поиск по ключевым словам";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lbNotes);
            this.Controls.Add(this.btnAdd);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListBox lbNotes;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
    }
}

