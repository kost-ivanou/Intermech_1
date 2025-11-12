using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winform_4
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
            string _connectionString = ConfigurationManager.ConnectionStrings["MySqlConn"].ConnectionString;

            services.AddScoped<Form1>();
            services.AddSingleton<IDbService, DbService>(sp => new DbService(_connectionString));
           
            var serviceProvider = services.BuildServiceProvider();
            var mainForm = serviceProvider.GetService<Form1>();

            DbMigrator.ApplyMigrations(serviceProvider.GetRequiredService<IDbService>());

            Application.Run(mainForm);
        }
    }
}
