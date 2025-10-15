using System;

namespace Task_15_Async_Await
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void connectButton_Click(object sender, EventArgs e)
        {
            textBox.Text = "����������� � ���� ������...\n";

            await Task.Delay(4000);

            textBox.Text = "��������� � ���� ������\n";

            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox.AppendText("...������ ��������\n");
        }

        private async void disconnectButton_Click(object sender, EventArgs e)
        {
            textBox.Text = "���������� �� ���� ������...\n";

            timer1.Stop();

            await Task.Delay(3000);

            textBox.Text = "��������\n";
        }
    }
}
