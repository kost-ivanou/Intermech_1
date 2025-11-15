using System.Diagnostics;
using System;
using System.Threading;
using Microsoft.VisualBasic.Devices;
using System.Linq;
using System.Net.NetworkInformation;

namespace Winform_6
{
    public class ResourceMonitor : IDisposable
    {
        private readonly PerformanceCounter cpuCounter;
        private readonly PerformanceCounter ramCounter;
        private readonly PerformanceCounter netRecv;
        private readonly PerformanceCounter netSent;

        private readonly float totalRamMB;
        private Timer timer;

        public int Interval { get; private set; }

        public event Action<ResourceData> OnDataUpdated;

        public ResourceMonitor(int intervalMs = 1000)
        {
            Interval = intervalMs;

            cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            ramCounter = new PerformanceCounter("Memory", "Available MBytes");

            var cat = new PerformanceCounterCategory("Network Interface");
            string instance = cat.GetInstanceNames()[1];//1 - выбор сетевого адаптера

            netRecv = new PerformanceCounter("Network Interface", "Bytes Received/sec", instance);
            netSent = new PerformanceCounter("Network Interface", "Bytes Sent/sec", instance);

            totalRamMB = new ComputerInfo().TotalPhysicalMemory / (1024f * 1024f);

            Start();
        }

        public void Start()
        {
            timer?.Dispose();
            timer = new Timer(UpdateStats, null, 0, Interval);
        }

        public void SetInterval(int intervalMs)
        {
            Interval = intervalMs;
            Start();
        }

        private void UpdateStats(object state)
        {
            var data = new ResourceData
            {
                cpuUsage = cpuCounter.NextValue(),
                ramUsagePercent = 100 - (ramCounter.NextValue() / totalRamMB * 100),
                netRecvKB = netRecv.NextValue() / 1024f,
                netSentKB = netSent.NextValue() / 1024f
            };

            OnDataUpdated?.Invoke(data);
        }

        public void Dispose()
        {
            timer?.Dispose();
            cpuCounter?.Dispose();
            ramCounter?.Dispose();
            netRecv?.Dispose();
            netSent?.Dispose();
        }
    }
}

