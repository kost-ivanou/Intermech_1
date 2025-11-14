namespace Winform_7
{
    partial class FormNoteEditor
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
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(12, 22);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(154, 20);
            this.txtTitle.TabIndex = 0;
            this.txtTitle.TextChanged += new System.EventHandler(this.txtTitle_TextChanged);
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(12, 66);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(432, 237);
            this.txtContent.TabIndex = 1;
            this.txtContent.TextChanged += new System.EventHandler(this.txtContent_TextChanged);
            // 
            // FormNoteEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 327);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.txtTitle);
            this.Name = "FormNoteEditor";
            this.Text = "FormNoteEditor";
            this.Load += new System.EventHandler(this.FormNoteEditor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtContent;
    }
}