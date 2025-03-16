using Rapha_LIS.Models;
using Rapha_LIS.Repositories;
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
        //Analytics
        private readonly IPatientAnalyticsView patientAnalyticsView;
        private readonly IAnalyticsRepository analyticsRepository;
        private readonly IAnalyticsActionView analyticsActionView;
        private BindingSource analyticsBindingSource;
        private List<PatientModel> patientHRI;


        //Patient Control
        private readonly IPatientControlView patientView;
        private readonly IPatientControlRepository patientRepository;
        private readonly IPatientActionView patientActionView;
        private readonly BindingSource PatientControlBindingSource;
        private IEnumerable<PatientModel>? patientList;

        private readonly IPatientResult patientResult;
        private readonly IPatientResultRepository patientResultRepository;
        private readonly IResultActionView resultActionView;
        private readonly BindingSource ResultBindingSource;
        private IEnumerable<PatientModel>? resultList;

        public PatientPresenter(IPatientControlView patientView, IPatientControlRepository patientRepository, IPatientActionView patientActionView,
                                IPatientAnalyticsView patientAnalyticsView, IAnalyticsRepository analyticsRepository, IAnalyticsActionView analyticsActionView,
                                IPatientResult patientResult, IPatientResultRepository patientResultRepository, IResultActionView resultActionView)
        {
            //PatientControlView
            this.patientView = patientView ?? throw new ArgumentNullException(nameof(patientView));
            this.patientRepository = patientRepository ?? throw new ArgumentNullException(nameof(patientRepository));

            //PatientActionView
            this.patientActionView = patientActionView ?? throw new ArgumentNullException(nameof(patientActionView));

            //PatientControlView
            this.patientView.SearchRequestedByName += PatientView_SearchRequestedByName;
            this.patientView.AddRequested += PatientView_AddRequested;
            this.patientView.ActionRequested += PatientView_ActionRequested;
            this.PatientControlBindingSource = new BindingSource();  // ✅ Initialize first
            this.patientView.BindPatientControlList(PatientControlBindingSource);  // ✅ Now it's not null

            //PatientActionView
            this.patientActionView.SaveRequested += AddPatientView_SaveRequested;
            this.patientActionView.DeleteRequested += PatientActionView_DeleteRequested;

            //Analytics
            this.patientAnalyticsView = patientAnalyticsView ?? throw new ArgumentNullException(nameof(patientAnalyticsView));
            this.analyticsRepository = analyticsRepository ?? throw new ArgumentNullException(nameof(analyticsRepository));
            this.analyticsActionView = analyticsActionView ?? throw new ArgumentNullException(nameof(analyticsActionView));
            this.analyticsBindingSource = new BindingSource();
            
            patientHRI = analyticsRepository.GetPatientHRI();
            analyticsBindingSource.DataSource = patientHRI;
            patientAnalyticsView.BindPatientAnalyticsList(analyticsBindingSource);

            this.patientAnalyticsView.SearchRequestedByHIR += PatientAnalyticsView_SearchRequestedByHIR;
            this.patientAnalyticsView.AnalyticsActionRequested += PatientAnalyticsView_AnalyticsActionRequested;
            this.analyticsActionView.AnalyticsSubmitRequested += AnalyticsActionView_AnalyticsSubmitRequested;
            this.analyticsActionView.AnalyticsSaveRequested += AnalyticsActionView_AnalyticsSaveRequested;

            //Result
            this.patientResult = patientResult ?? throw new ArgumentNullException(nameof(patientResult));
            this.patientResultRepository = patientResultRepository ?? throw new ArgumentNullException(nameof(patientResultRepository));
            this.resultActionView = resultActionView ?? throw new ArgumentNullException(nameof(resultActionView));

            this.patientResult.ResultSearchRequested += PatientResult_ResultSearchRequested;
            this.patientResult.ResultActionRequested += PatientResult_ResultActionRequested;
            
            this.ResultBindingSource = new BindingSource();  // ✅ Initialize first
            this.patientResult.BindPatientResult(ResultBindingSource);

            LoadAllPatientList();
            this.patientView.Show();
        }

        private void PatientResult_ResultActionRequested(object? sender, EventArgs e)
        {
            var patientModel = (PatientModel)ResultBindingSource.Current;

            resultActionView.Id = patientModel.Id;
            resultActionView.FirstName = patientModel.FirstName;
            resultActionView.LastName = patientModel.LastName;
            resultActionView.MiddleInitial = patientModel.MiddleInitial;
            resultActionView.Age = patientModel.Age.ToString();
            resultActionView.Sex = patientModel.Sex;
            resultActionView.Birthdate = patientModel.Birthdate;
            resultActionView.Address = patientModel.Address;
            resultActionView.CivilStatus = patientModel.CivilStatus;
            resultActionView.Religion = patientModel.Religion;
            resultActionView.Contact = patientModel.Contact;
            resultActionView.Test = patientModel.Test;
            resultActionView.Result = patientModel.Result;

            resultActionView.IsEdit = true;

            ((Form)resultActionView).ShowDialog();
            CleanviewFields();
        }

        private void LoadAllPatientList()
        {
            patientActionView.DeleteButtonVisible = patientActionView.IsEdit;
            patientList = patientRepository.GetAll();
            PatientControlBindingSource.DataSource = patientList;
            patientHRI = analyticsRepository.GetPatientHRI();
            analyticsBindingSource.DataSource = patientHRI;
            resultList = patientResultRepository.GetAllPatientResult();
            ResultBindingSource.DataSource = resultList;
        }

        //Result
        private void PatientResult_ResultSearchRequested(object? sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(this.patientResult.ResultSearchQuery);
            if (emptyValue == false)
                resultList = patientResultRepository.GetPatientResultByName(this.patientResult.ResultSearchQuery);
            else resultList = patientResultRepository.GetAllPatientResult();
            ResultBindingSource.DataSource = resultList;
        }
        //Analytics
        private void AnalyticsActionView_AnalyticsSubmitRequested(object? sender, EventArgs e)
        {
            var patientModel = new PatientModel
            {
                Id = analyticsActionView.Id,
                Result = analyticsActionView.Result
            };

            try
            {
                new Common.ModelDataValidation().Validate(patientModel);

                if (analyticsActionView.IsEdit) // Use IsEdit to check if it's an edit operation
                {
                    MessageBox.Show($"HPatient ID: {patientModel.Id}");

                    patientRepository.EditResult(patientModel);
                    analyticsActionView.Message = "Patient updated successfully.";
                }

                else // Add new patient
                {

                    MessageBox.Show("Adding patient..."); // Debugging step
                    analyticsRepository.AddPatientAnalytics(patientModel);
                    analyticsActionView.Message = "Patient added successfully.";
                }

                analyticsActionView.IsSuccessful = true;
                LoadAllPatientList(); // Refresh the list
                CleanviewFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message); // Debugging step
                analyticsActionView.IsSuccessful = false;
                analyticsActionView.Message = ex.Message;
            }
        }



        private void AnalyticsActionView_AnalyticsSaveRequested(object? sender, EventArgs e)
        {
            var patientModel = new PatientModel
            {
                Id = analyticsActionView.Id,
                FirstName = analyticsActionView.FirstName,
                LastName = analyticsActionView.LastName,
                MiddleInitial = analyticsActionView.MiddleInitial,
                Age = int.TryParse(analyticsActionView.Age, out int age) ? age : 0,
                Sex = analyticsActionView.Sex,
                Birthdate = analyticsActionView.Birthdate < new DateTime(1753, 1, 1)
                ? DateTime.Now
                : analyticsActionView.Birthdate,
                Address = analyticsActionView.Address,
                CivilStatus = analyticsActionView.CivilStatus,
                Religion = analyticsActionView.Religion,
                Contact = analyticsActionView.Contact,
                Test = analyticsActionView.Test,
                DateCreated = DateTime.Now,
                Result = analyticsActionView.Result
            };

            try
            {
                new Common.ModelDataValidation().Validate(patientModel);

                if (analyticsActionView.IsEdit) // Use IsEdit to check if it's an edit operation
                {
                    MessageBox.Show($"HPatient ID: {patientModel.Id}");

                    analyticsRepository.EditPatientAnalytics(patientModel);
                    analyticsActionView.Message = "Patient updated successfully.";
                }

                else // Add new patient
                {

                    MessageBox.Show("Adding patient..."); // Debugging step
                    analyticsRepository.AddPatientAnalytics(patientModel);
                    analyticsActionView.Message = "Patient added successfully.";
                }

                patientActionView.IsSuccessful = true;
                LoadAllPatientList(); // Refresh the list
                CleanviewFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message); // Debugging step
                analyticsActionView.IsSuccessful = false;
                analyticsActionView.Message = ex.Message;
            }
        }

        private void PatientAnalyticsView_AnalyticsActionRequested(object? sender, EventArgs e)
        {

            var patientModel = (PatientModel)analyticsBindingSource.Current;

            analyticsActionView.Id = patientModel.Id;
            analyticsActionView.FirstName = patientModel.FirstName;
            analyticsActionView.LastName = patientModel.LastName;
            analyticsActionView.MiddleInitial = patientModel.MiddleInitial;
            analyticsActionView.Age = patientModel.Age.ToString();
            analyticsActionView.Sex = patientModel.Sex;
            analyticsActionView.Birthdate = patientModel.Birthdate;
            analyticsActionView.Address = patientModel.Address;
            analyticsActionView.CivilStatus = patientModel.CivilStatus;
            analyticsActionView.Religion = patientModel.Religion;
            analyticsActionView.Contact = patientModel.Contact;
            analyticsActionView.Test = patientModel.Test;
            analyticsActionView.Result = patientModel.Result;

            analyticsActionView.IsEdit = true;

            analyticsActionView.AnalyticsSaveRequested -= AnalyticsActionView_AnalyticsSaveRequested;
            analyticsActionView.AnalyticsSaveRequested += AnalyticsActionView_AnalyticsSaveRequested;


            ((Form)analyticsActionView).ShowDialog();
            CleanviewFields();
        }

        //Analytics
        private void PatientAnalyticsView_SearchRequestedByHIR(object? sender, EventArgs e)
        {
            string inputId = patientAnalyticsView.SearchQueryByHIR.Trim();
            if (string.IsNullOrWhiteSpace(inputId))
            {
                patientAnalyticsView.ShowMessage("Please enter a User ID.");
                return;
            }
            if (int.TryParse(patientAnalyticsView.SearchQueryByHIR, out int userId))
            {
                var user = analyticsRepository.GetPatientByHRI(userId);
                if (user != null)
                {
                    MessageBox.Show("Hoy");
                    analyticsRepository.AddPatientAnalytics(user); // Save to SearchHistory DB
                    patientHRI.Add(user); // Add to local history
                    analyticsBindingSource.ResetBindings(false); // Refresh UI
                    patientAnalyticsView.BindPatientAnalyticsList(analyticsBindingSource);
                }
                else
                {
                    patientAnalyticsView.ShowMessage("User not found!");
                }
            }
            else
            {
                patientAnalyticsView.ShowMessage("Invalid User ID!");
            }
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
    }
}
