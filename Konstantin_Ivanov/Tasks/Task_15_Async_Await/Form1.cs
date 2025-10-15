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
            textBox.Text = "Подключение к базе данных...\n";

            await Task.Delay(4000);

            textBox.Text = "Подключен к базе данных\n";

            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox.AppendText("...Данные получены\n");
        }

        private async void disconnectButton_Click(object sender, EventArgs e)
        {
            textBox.Text = "Отключение от базы данных...\n";

            timer1.Stop();

            await Task.Delay(3000);

            textBox.Text = "Отключен\n";
        }
    }
}
