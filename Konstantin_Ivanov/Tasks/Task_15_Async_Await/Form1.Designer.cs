namespace Task_15_Async_Await
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            textBox = new TextBox();
            disconnectButton = new Button();
            connectButton = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // textBox
            // 
            textBox.Location = new Point(242, 110);
            textBox.Multiline = true;
            textBox.Name = "textBox";
            textBox.Size = new Size(314, 62);
            textBox.TabIndex = 0;
            // 
            // disconnectButton
            // 
            disconnectButton.AutoSize = true;
            disconnectButton.Location = new Point(472, 297);
            disconnectButton.Name = "disconnectButton";
            disconnectButton.Size = new Size(179, 35);
            disconnectButton.TabIndex = 1;
            disconnectButton.Text = "Отключиться от БД";
            disconnectButton.UseVisualStyleBackColor = true;
            disconnectButton.Click += disconnectButton_Click;
            // 
            // connectButton
            // 
            connectButton.AutoSize = true;
            connectButton.Location = new Point(130, 297);
            connectButton.Name = "connectButton";
            connectButton.Size = new Size(183, 35);
            connectButton.TabIndex = 2;
            connectButton.Text = "Подключиться к БД";
            connectButton.UseVisualStyleBackColor = true;
            connectButton.Click += connectButton_Click;
            // 
            // timer1
            // 
            timer1.Interval = 2000;
            timer1.Tick += timer1_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(connectButton);
            Controls.Add(disconnectButton);
            Controls.Add(textBox);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox;
        private Button disconnectButton;
        private Button connectButton;
        private System.Windows.Forms.Timer timer1;
    }
}
