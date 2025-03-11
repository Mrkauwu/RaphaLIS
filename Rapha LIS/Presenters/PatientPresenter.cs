using Rapha_LIS.Models;
using Rapha_LIS.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Rapha_LIS.Presenters
{
    public class PatientPresenter
    {
        //User Control
        private readonly IUserControlView patientView;
        private readonly IUserControlRepository patientRepository;
        private readonly IPatientActionView patientActionView;
        private readonly BindingSource PatientControlBindingSource;
        private IEnumerable<PatientModel>? patientList;

        //Analytics
        /*private readonly IPatientAnalyticsView analyticsView;
        private readonly IAnalyticsRepository analyticsRepository;
        private readonly BindingSource AnalyticsBindingSource;
        private List<PatientModel> analyticsList = new List<PatientModel>();*/


        public PatientPresenter(IUserControlView patientView, IUserControlRepository patientRepository, IPatientActionView patientActionView
                                /*IAnalyticsRepository analyticsRepository, IPatientAnalyticsView analyticsView*/)
        {
            //PatientControlView
            this.patientView = patientView ?? throw new ArgumentNullException(nameof(patientView));
            this.patientRepository = patientRepository ?? throw new ArgumentNullException(nameof(patientRepository));

            //PatientActionView
            this.patientActionView = patientActionView ?? throw new ArgumentNullException(nameof(patientActionView));

            //PatientAnalyticsView
            /*this.analyticsRepository = analyticsRepository ?? throw new ArgumentNullException(nameof(analyticsRepository));
            this.analyticsView = analyticsView ?? throw new ArgumentNullException(nameof(analyticsView));*/

            //PatientControlView
            this.patientView.SearchRequestedByName += PatientView_SearchRequestedByName;
            this.patientView.AddRequested += PatientView_AddRequested;
            this.patientView.ActionRequested += PatientView_ActionRequested;
            this.PatientControlBindingSource = new BindingSource();  // ✅ Initialize first
            this.patientView.BindPatientControlList(PatientControlBindingSource);  // ✅ Now it's not null


            //PatientActionView
            this.patientActionView.SaveRequested += AddPatientView_SaveRequested;
            this.patientActionView.DeleteRequested += PatientActionView_DeleteRequested;

            //IAnalyticsView
            /*this.analyticsView.SearchRequestedById += AnalyticsView_SearchRequestedById;
            this.analyticsView.BindPatientAnalyticsList(AnalyticsBindingSource);
            this.AnalyticsBindingSource = new BindingSource();*/
            
            LoadAllPatientList();
            this.patientView.Show();
        }

        

        private void LoadAllPatientList()
        {
            patientList = patientRepository.GetAll();
            PatientControlBindingSource.DataSource = patientList;
        }

        private void CleanviewFields()
        {
            patientActionView.FirstName = "";
            patientActionView.LastName = "";
            patientActionView.MiddleInitial = "";
            patientActionView.Age = "";
            patientActionView.Address = "";
            patientActionView.CivilStatus = "";
            patientActionView.Religion = "";
            patientActionView.Contact = "";
            patientActionView.Test = "";
        }

        //PatientActionView

        private void PatientActionView_DeleteRequested(object? sender, EventArgs e)
        {
            var patient = (PatientModel)PatientControlBindingSource.Current;
            patientRepository.DeletePatient(patient.Id);
            patientActionView.IsSuccessful = true;
            patientActionView.Message = "Patient Deleted Successfuly";
            LoadAllPatientList();
        }

        private void AddPatientView_SaveRequested(object? sender, EventArgs e)
        {
            var patientModel = new PatientModel
            {
                Id = patientActionView.Id,
                FirstName = patientActionView.FirstName,
                LastName = patientActionView.LastName,
                MiddleInitial = patientActionView.MiddleInitial,
                Age = int.TryParse(patientActionView.Age, out int age) ? age : 0,
                Sex = patientActionView.Sex,
                Birthdate = patientActionView.Birthdate < new DateTime(1753, 1, 1)
                ? DateTime.Now
                : patientActionView.Birthdate,
                Address = patientActionView.Address,
                CivilStatus = patientActionView.CivilStatus,
                Religion = patientActionView.Religion,
                Contact = patientActionView.Contact,
                Test = patientActionView.Test,
                DateCreated = DateTime.Now
            };

            try
            {
                new Common.ModelDataValidation().Validate(patientModel);

                if (patientActionView.IsEdit) // Use IsEdit to check if it's an edit operation
                {
                    MessageBox.Show($"Patient ID: {patientModel.Id}");

                    patientRepository.EditPatient(patientModel);
                    patientActionView.Message = "Patient updated successfully.";
                }
                else // Add new patient
                {
                    MessageBox.Show("Adding patient..."); // Debugging step
                    patientRepository.AddPatient(patientModel);
                    patientActionView.Message = "Patient added successfully.";
                }

                patientActionView.IsSuccessful = true;
                LoadAllPatientList(); // Refresh the list
                CleanviewFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message); // Debugging step
                patientActionView.IsSuccessful = false;
                patientActionView.Message = ex.Message;
            }
        }

        //User Control View
        private void PatientView_ActionRequested(object? sender, EventArgs e)
        {
            var patientModel = (PatientModel)PatientControlBindingSource.Current;

            patientActionView.Id = patientModel.Id;
            patientActionView.FirstName = patientModel.FirstName;
            patientActionView.LastName = patientModel.LastName;
            patientActionView.MiddleInitial = patientModel.MiddleInitial;
            patientActionView.Age = patientModel.Age.ToString();
            patientActionView.Sex = patientModel.Sex;
            patientActionView.Birthdate = patientModel.Birthdate;
            patientActionView.Address = patientModel.Address;
            patientActionView.CivilStatus = patientModel.CivilStatus;
            patientActionView.Religion = patientModel.Religion;
            patientActionView.Contact = patientModel.Contact;
            patientActionView.Test = patientModel.Test;

            patientActionView.IsEdit = true;

            patientActionView.SaveRequested -= AddPatientView_SaveRequested;
            patientActionView.SaveRequested += AddPatientView_SaveRequested;

            ((Form)patientActionView).ShowDialog();
            CleanviewFields();

        }

        private void PatientView_AddRequested(object? sender, EventArgs e)
        {
            patientActionView.IsEdit = false;
            ((Form)patientActionView).ShowDialog();
        }
        

        private void PatientView_SearchRequestedByName(object? sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(this.patientView.SearchQueryByName);
            if (emptyValue == false)
                patientList = patientRepository.GetByName(this.patientView.SearchQueryByName);
            else patientList = patientRepository.GetAll();
            PatientControlBindingSource.DataSource = patientList;
        }


        //Patient Analytics View
        /*private void AnalyticsView_SearchRequestedById(object? sender, EventArgs e)
        {
            //analyticsList = analyticsRepository.GetById(this.analyticsView.SearchQueryById); 

            //string query = analyticsView.SearchQueryById;

            // Get patients from repository
            IEnumerable<PatientModel> result = analyticsRepository.GetById(analyticsView.SearchQueryById);
            
            analyticsList.AddRange(result);

            AnalyticsBindingSource.DataSource = null;
            AnalyticsBindingSource.DataSource = analyticsList;
        }*/

        


    }
}
