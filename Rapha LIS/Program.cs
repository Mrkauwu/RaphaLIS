using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rapha_LIS.Data;
using Rapha_LIS.Models;
using Rapha_LIS.Presenters;
using Rapha_LIS.Repositories;
using Rapha_LIS.Views;

namespace Rapha_LIS
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            ApplicationConfiguration.Initialize();
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

            var builder = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {

                    // Register Database Context
                    services.AddDbContext<AppDbContext>(options =>
                        options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

                    // Register Repositories
                    services.AddTransient<IPatientControlRepository, PatientRepository>();
                    services.AddTransient<IAnalyticsRepository, PatientRepository>();
                    services.AddTransient<IPatientResultRepository, PatientRepository>();
                    services.AddTransient<IUserControlRepository, UserRepository>();

                    // Register Views
                    services.AddTransient<IUserActionVIew, UserActionView>();
                    services.AddTransient<IPatientActionView, PatientActionView>();
                    services.AddTransient<IAnalyticsActionView, AnalyticsActionView>();
                    services.AddTransient<IResultActionView, ResultActionView>();
                    // Register a single instance of the main form for all related interfaces
                    services.AddSingleton<Rapha_LIS.Views.Rapha_LIS>();
                    services.AddSingleton<IPatientControlView>(provider => provider.GetRequiredService<Rapha_LIS.Views.Rapha_LIS>());
                    services.AddSingleton<IUserControlView>(provider => provider.GetRequiredService<Rapha_LIS.Views.Rapha_LIS>());
                    services.AddSingleton<IPatientAnalyticsView>(provider => provider.GetRequiredService<Rapha_LIS.Views.Rapha_LIS>());
                    services.AddSingleton<IPatientResult>(provider => provider.GetRequiredService<Rapha_LIS.Views.Rapha_LIS>());


                    // Register Presenters
                    services.AddTransient<PatientPresenter>();
                    services.AddTransient<UserPresenter>();
                })
                .Build();

            using (var scope = builder.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                // Resolve dependencies from the service provider
                var mainForm = services.GetRequiredService<IPatientControlView>();
                var patientRepo = services.GetRequiredService<IPatientControlRepository>();
                var addPatientView = services.GetRequiredService<IPatientActionView>();
                var patientAnalyticsView = (IPatientAnalyticsView)mainForm;
                var analyticsRepo = services.GetRequiredService<IAnalyticsRepository>();
                var analyticsActionView = services.GetRequiredService<IAnalyticsActionView>();
                var patientResult = (IPatientResult)mainForm;
                var patientResultRepo = services.GetRequiredService<IPatientResultRepository>();
                var resultActionView = services.GetRequiredService<IResultActionView>();

                // Initialize Patient Presenter
                new PatientPresenter(mainForm, patientRepo, addPatientView, patientAnalyticsView, analyticsRepo,
                                     analyticsActionView, patientResult, patientResultRepo, resultActionView);

                // Initialize User Presenter
                var userControlView = services.GetRequiredService<IUserControlView>();
                var userControlRepo = services.GetRequiredService<IUserControlRepository>();
                var userActionView = services.GetRequiredService<IUserActionVIew>();

                new UserPresenter(userControlView, userControlRepo, userActionView);

                // Run the application with the main form
                Application.Run((Form)mainForm);


            }
        }
    }
}
