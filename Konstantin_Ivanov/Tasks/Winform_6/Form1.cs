using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winform_6
{
    public partial class Form1: Form
    {
        private ResourceMonitor monitor;

        public Form1()
        {
            InitializeComponent();
            InitMonitor();
        }

        private void InitMonitor()
        {
            monitor = new ResourceMonitor(1000);
            monitor.OnDataUpdated += Monitor_OnDataUpdated;

            btnInterval.Text = $"Интервал: {monitor.Interval} мс";
        }

        private void Monitor_OnDataUpdated(ResourceData data)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => Monitor_OnDataUpdated(data)));
                return;
            }

            progressCpu.Value = (int)Math.Min(data.cpuUsage, 100);
            lblCpu.Text = $"{data.cpuUsage:F1}%";

            progressRam.Value = (int)Math.Min(data.ramUsagePercent, 100);
            lblRam.Text = $"{data.ramUsagePercent:F1}%";

            progressNet.Value = (int)Math.Min(data.netTotalKB, progressNet.Maximum);
            lblNet.Text = $"{data.netTotalKB:F1} KB/s";
        }

        private void btnInterval_Click(object sender, EventArgs e)
        {
            using (var dlg = new InputIntervalForm(monitor.Interval))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    monitor.SetInterval(dlg.Interval);
                    btnInterval.Text = $"Интервал: {dlg.Interval} мс";
                }
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            monitor.Dispose();
        }
    }
}
