using Rapha_LIS.Models;
using Rapha_LIS.Repositories;
using Rapha_LIS.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rapha_LIS.Presenters
{
    public class UserPresenter
    {
        private readonly IUserActionVIew userActionVIew;
        private readonly IUserControlRepository userRepository;
        private readonly IUserControlView userControlView;
        private readonly BindingSource UserControlBindingSource;
        private IEnumerable<UserModel>? userList;

        public UserPresenter(IUserControlView userControlView, IUserControlRepository userRepository, IUserActionVIew userActionVIew) 
        {
            //PatientControlView
            this.userControlView = userControlView ?? throw new ArgumentNullException(nameof(userControlView));
            this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));

            //PatientActionView
            this.userActionVIew = userActionVIew ?? throw new ArgumentNullException(nameof(userActionVIew));

            //PatientControlView
            this.userControlView.UserSearchRequestedByName += UserControlView_UserSearchRequestedByName;
            this.userControlView.UserAddRequested += UserControlView_UserAddRequested;
            this.userControlView.UserActionRequested += UserControlView_UserActionRequested;
            this.UserControlBindingSource = new BindingSource();  // ✅ Initialize first
            this.userControlView.BindUserControlList(UserControlBindingSource);

            //PatientActionView
            this.userActionVIew.UserSaveRequested += UserActionVIew_UserSaveRequested;
            this.userActionVIew.UserDeleteRequested += UserActionVIew_UserDeleteRequested;

            
            LoadAllPatientList();
            this.userControlView.Show();
        }

        private void LoadAllPatientList()
        {
            userActionVIew.DeleteButtonVisible = userActionVIew.IsEdit;
            userList = userRepository.GetAll();
            UserControlBindingSource.DataSource = userList;
        }

        private void CleanviewFields()
        {
            userActionVIew.FirstName = "";
            userActionVIew.LastName = "";
            userActionVIew.MiddleInitial = "";
            userActionVIew.Age = "";
            userActionVIew.Address = "";
            userActionVIew.CivilStatus = "";
            userActionVIew.Religion = "";
            userActionVIew.Contact = "";
        }

        //User Control

        private void UserControlView_UserActionRequested(object? sender, EventArgs e)
        {
            var userModel = (UserModel)UserControlBindingSource.Current;

            userActionVIew.Id = userModel.Id;
            userActionVIew.FirstName = userModel.FirstName;
            userActionVIew.LastName = userModel.LastName;
            userActionVIew.MiddleInitial = userModel.MiddleInitial;
            userActionVIew.Age = userModel.Age.ToString();
            userActionVIew.Sex = userModel.Sex;
            userActionVIew.Birthdate = userModel.Birthdate;
            userActionVIew.Address = userModel.Address;
            userActionVIew.CivilStatus = userModel.CivilStatus;
            userActionVIew.Religion = userModel.Religion;
            userActionVIew.Contact = userModel.Contact;

            userActionVIew.IsEdit = true;

            userActionVIew.UserSaveRequested -= UserActionVIew_UserSaveRequested;
            userActionVIew.UserSaveRequested += UserActionVIew_UserSaveRequested;


            ((Form)userActionVIew).ShowDialog();
            CleanviewFields();
        }

        private void UserControlView_UserAddRequested(object? sender, EventArgs e)
        {
            userActionVIew.IsEdit = false;
            ((Form)userActionVIew).ShowDialog();
        }

        private void UserControlView_UserSearchRequestedByName(object? sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(this.userControlView.UserSearchQueryByName);
            if (emptyValue == false)
                userList = userRepository.GetByName(this.userControlView.UserSearchQueryByName); 
            else userList = userRepository.GetAll();
            UserControlBindingSource.DataSource = userList;
        }

        //User Action
        private void UserActionVIew_UserSaveRequested(object? sender, EventArgs e)
        {
            var userModel = new UserModel()
            {
                Id = userActionVIew.Id,
                FirstName = userActionVIew.FirstName,
                LastName = userActionVIew.LastName,
                MiddleInitial = userActionVIew.MiddleInitial,
                Age = int.TryParse(userActionVIew.Age, out int age) ? age : 0,
                Sex = userActionVIew.Sex,
                Birthdate = userActionVIew.Birthdate < new DateTime(1753, 1, 1)
                ? DateTime.Now
                : userActionVIew.Birthdate,
                Address = userActionVIew.Address,
                CivilStatus = userActionVIew.CivilStatus,
                Religion = userActionVIew.Religion,
                Contact = userActionVIew.Contact,
                DateCreated = DateTime.Now
            };

            try
            {
                new Common.ModelDataValidation().Validate(userModel);

                if (userActionVIew.IsEdit) // Use IsEdit to check if it's an edit operation
                {
                    MessageBox.Show($"Patient ID: {userModel.Id}");

                    userRepository.EditUser(userModel);
                    userActionVIew.Message = "Patient updated successfully.";
                }
                else // Add new patient
                {

                    MessageBox.Show("Adding patient..."); // Debugging step
                    userRepository.AddUser(userModel);
                    userActionVIew.Message = "Patient added successfully.";
                }

                userActionVIew.IsSuccessful = true;
                LoadAllPatientList(); // Refresh the list
                CleanviewFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message); // Debugging step
                userActionVIew.IsSuccessful = false;
                userActionVIew.Message = ex.Message;
            }
        }

        private void UserActionVIew_UserDeleteRequested(object? sender, EventArgs e)
        {
            var user = (UserModel)UserControlBindingSource.Current;
            userRepository.DeleteUser(user.Id);
            userActionVIew.IsSuccessful = true;
            userActionVIew.Message = "User Deleted Successfuly";
            LoadAllPatientList();
        }
    }
}
