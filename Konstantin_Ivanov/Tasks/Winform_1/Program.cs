using System;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Forms;

namespace Winform_1
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();
            ConfigureServices(services);

            var serviceProvider = services.BuildServiceProvider();
            Application.Run(serviceProvider.GetRequiredService<Form1>());
        }

        static void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton<ITextSaveService, TextSaveService>();
            services.AddTransient<Form1>();
        }
    }
}
