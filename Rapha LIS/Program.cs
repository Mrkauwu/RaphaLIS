using Microsoft.Extensions.Configuration;
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
                .SetBasePath(AppContext.BaseDirectory) // Use BaseDirectory instead
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

            string? sqlConnectionString = config.GetConnectionString("DefaultConnection");

            IUserControlView patientView = new Rapha_LIS.Views.Rapha_LIS();
            IPatientActionView addPatientView = new PatientActionView();
            //IPatientAnalyticsView analyticsView = (IPatientAnalyticsView)patientView;
            //IAnalyticsRepository analyticsRepository = new PatientRepository(sqlConnectionString);
            IUserControlRepository repository = new PatientRepository(sqlConnectionString ?? "");
            new PatientPresenter(patientView, repository, addPatientView/*, analyticsRepository, analyticsView*/);
            Application.Run((Form)patientView);
        }
    }
}
