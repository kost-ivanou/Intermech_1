namespace Winform_3.Dialogs
{
    partial class EventCreateDialog
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
            this.txtEventTitle = new System.Windows.Forms.TextBox();
            this.labelEventName = new System.Windows.Forms.Label();
            this.cmbEventPriority = new System.Windows.Forms.ComboBox();
            this.labelEventPriority = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtEventTitle
            // 
            this.txtEventTitle.Location = new System.Drawing.Point(75, 45);
            this.txtEventTitle.Multiline = true;
            this.txtEventTitle.Name = "txtEventTitle";
            this.txtEventTitle.Size = new System.Drawing.Size(131, 37);
            this.txtEventTitle.TabIndex = 0;
            // 
            // labelEventName
            // 
            this.labelEventName.AutoSize = true;
            this.labelEventName.Location = new System.Drawing.Point(72, 29);
            this.labelEventName.Name = "labelEventName";
            this.labelEventName.Size = new System.Drawing.Size(146, 13);
            this.labelEventName.TabIndex = 1;
            this.labelEventName.Text = "Введите название события";
            // 
            // cmbEventPriority
            // 
            this.cmbEventPriority.FormattingEnabled = true;
            this.cmbEventPriority.Items.AddRange(new object[] {
            "Низкий",
            "Средний",
            "Высокий"});
            this.cmbEventPriority.Location = new System.Drawing.Point(75, 146);
            this.cmbEventPriority.Name = "cmbEventPriority";
            this.cmbEventPriority.Size = new System.Drawing.Size(121, 21);
            this.cmbEventPriority.TabIndex = 2;
            // 
            // labelEventPriority
            // 
            this.labelEventPriority.AutoSize = true;
            this.labelEventPriority.Location = new System.Drawing.Point(72, 130);
            this.labelEventPriority.Name = "labelEventPriority";
            this.labelEventPriority.Size = new System.Drawing.Size(158, 13);
            this.labelEventPriority.TabIndex = 3;
            this.labelEventPriority.Text = "Выберите приоритет события";
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(104, 218);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(92, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "Продолжить";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(311, 218);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(92, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // EventCreateDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 275);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.labelEventPriority);
            this.Controls.Add(this.cmbEventPriority);
            this.Controls.Add(this.labelEventName);
            this.Controls.Add(this.txtEventTitle);
            this.Name = "EventCreateDialog";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtEventTitle;
        private System.Windows.Forms.Label labelEventName;
        private System.Windows.Forms.ComboBox cmbEventPriority;
        private System.Windows.Forms.Label labelEventPriority;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}