using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace DiskMonitorService
{
    [RunInstaller(true)]
    public class WindowsServiceInstaller : Installer
    {
        private ServiceProcessInstaller processInstaller;
        private ServiceInstaller serviceInstaller;

        public WindowsServiceInstaller()
        {
            processInstaller = new ServiceProcessInstaller
            {
                Account = ServiceAccount.LocalSystem
            };

            serviceInstaller = new ServiceInstaller
            {
                ServiceName = "DiskMonitorService",
                DisplayName = "Мониторинг дисков",
                Description = "Отслеживает удаление файлов и записывает путь в лог",
                StartType = ServiceStartMode.Manual
            };

            Installers.Add(processInstaller);
            Installers.Add(serviceInstaller);
        }
    }
}

