using EstudiantesApp.Applications.Interfaces;
using EstudiantesApp.Applications.Services;
using EstudiantesApp.Domain.EstudiantesDBEntities;
using EstudiantesApp.Domain.Interfaces;
using EstudiantesApp.Estructure.Repositories;
using EstudiantesApp.Presentation.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EstudiantesApp.Presentation
{
    static class Program
    {
        public static IConfiguration Configuration;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            var configurationBuilder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            Configuration = configurationBuilder
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables().Build(); ;

            var builder = new HostBuilder().ConfigureServices((hostContext, services) =>
            {
                services.AddDbContext<PepitoSchoolContext>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("Default"));
                });
            });



            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();

            services.AddDbContext<PepitoSchoolContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Default"));
            });
            services.AddScoped<IEstudianteDBContext, PepitoSchoolContext>();
            services.AddScoped<IEstudianteRepository, EFEstudianteRepository>();
            services.AddScoped<IEstudianteService, EstudianteService>();
            services.AddScoped<EstudianteForm>();

            using (var serviceScope = services.BuildServiceProvider())
            {
                var main = serviceScope.GetRequiredService<EstudianteForm>();
                Application.Run(main);
            }
        }
    }
}
