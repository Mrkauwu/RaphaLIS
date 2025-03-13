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
                .SetBasePath(AppContext.BaseDirectory) 
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

            string? sqlConnectionString = config.GetConnectionString("DefaultConnection");

            /*IPatientControlView patientView = new Rapha_LIS.Views.Rapha_LIS();
            IPatientActionView addPatientView = new PatientActionView();    
            IPatientControlRepository repository = new PatientRepository(sqlConnectionString ?? "");

            IUserControlView userControlView = new Rapha_LIS.Views.Rapha_LIS();
            IUserActionVIew userActionVIew = new UserActionView();
            IUserControlRepository userControlRepository = new UserRepository(sqlConnectionString ?? "");

           new PatientPresenter(patientView, repository, addPatientView);
           new UserPresenter(userControlView, userControlRepository, userActionVIew);
            Application.Run((Form)userControlView, patientView);*/

            // Create Main Form
            var mainForm = new Rapha_LIS.Views.Rapha_LIS(); // This should be your main form

            // Initialize Patient Presenter
            IPatientControlView patientView = mainForm;
            IPatientActionView addPatientView = new PatientActionView();
            IPatientControlRepository patientRepository = new PatientRepository(sqlConnectionString ?? "");
            //Analytics
            IPatientAnalyticsView patientAnalyticsView = mainForm;
            IAnalyticsActionView analyticsActionView = new AnalyticsActionView();
            IAnalyticsRepository analyticsRepository = new PatientRepository(sqlConnectionString ?? "");
            //Result
            IPatientResult patientResult = mainForm;
            IResultActionView resultActionView = new ResultActionView();
            IPatientResultRepository patientResultRepository = new PatientRepository(sqlConnectionString ?? "");

            
            new PatientPresenter(patientView, patientRepository, addPatientView, patientAnalyticsView, analyticsRepository,
                                  analyticsActionView, patientResult, patientResultRepository, resultActionView);

            // Initialize User Presenter
            IUserControlView userControlView = mainForm;
            IUserActionVIew userActionView = new UserActionView();
            IUserControlRepository userControlRepository = new UserRepository(sqlConnectionString ?? "");
            new UserPresenter(userControlView, userControlRepository, userActionView);

            // Run the application with the main form
            Application.Run(mainForm);

        }
    }
}
