using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_16_Domain
{
    public partial class Form1: Form
    {
        private readonly string logPath = @"C:\DiskMonitor\log.txt";
        private readonly string serviceName = "DiskMonitorService";

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonInstall_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("sc.exe", $"create {serviceName} binPath= \"D:\\Intermex\\Konstantin_Ivanov\\Tasks\\DiskMonitorService\\bin\\Debug");
                MessageBox.Show("Служба установлена!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonUninstall_Click(object sender, EventArgs e)
        {
            Process.Start("sc.exe", $"delete {serviceName}");
            MessageBox.Show("Служба удалена!");
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceController sc = new ServiceController("DiskMonitorService");
                if (sc.Status == ServiceControllerStatus.Stopped)
                {
                    sc.Start();
                    sc.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(10));
                    MessageBox.Show("Служба успешно запущена!");
                }
                else
                {
                    MessageBox.Show("Служба уже запущена.");
                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("Служба не найдена: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            var service = new ServiceController(serviceName);
            try
            {
                service.Stop();
                MessageBox.Show("Служба остановлена!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally {
                service.Dispose();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (File.Exists(logPath))
            {
                textBox1.Text = File.ReadAllText(logPath);
            }
        }
    }
}
