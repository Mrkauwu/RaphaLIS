using MaterialSkin;
using MaterialSkin.Controls;
using Rapha_LIS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Rapha_LIS.Views
{
    public partial class Rapha_LIS : MaterialForm, IPatientControlView, IUserControlView
    {
        private bool isEdit;
        private bool isEditUser;
        public Rapha_LIS()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            materialSkinManager.ColorScheme = new ColorScheme(
            (Primary)0xFFFFFF,  // Clean white background
            (Primary)0xF3E5F5,  // Very light purple for a premium look
            (Primary)0xCE93D8,  // Soft purple contrast
            (Accent)0xBA68C8,   // Vibrant purple accent
            TextShade.BLACK     // Dark text for easy reading
            );
        }

        //Patient Control

        private void AssociateAndRaiseViewEvents()
        {


            btnAddPatient.Click += (s, e) =>
            {
                AddRequested?.Invoke(this, EventArgs.Empty);
            };

            txtPatientControlSearch.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    SearchRequestedByName?.Invoke(this, EventArgs.Empty);
            };

            btnAddUser.Click += (s, e) =>
            {
                UserAddRequested?.Invoke(this, EventArgs.Empty);
            };

            txtUserControlSearch.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    UserSearchRequestedByName?.Invoke(this, EventArgs.Empty);
            };

        }

        public bool IsEdit
        {
            get { return isEdit; }
            set { isEdit = value; }
        }

        public string SearchQueryByName
        {
            get { return txtPatientControlSearch.Text; }
            set { txtPatientControlSearch.Text = value; }
        }

        private void dgvUserControlPatients_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ActionRequested?.Invoke(this, EventArgs.Empty);
        }

        public void BindPatientControlList(BindingSource patientControlList)
        {
            dgvPatientControl.DataSource = patientControlList;
        }

        //User Control

        public string UserSearchQueryByName
        {
            get { return txtUserControlSearch.Text; }
            set { txtUserControlSearch.Text = value; }
        }

        public bool UserIsEdit
        {
            get { return isEditUser; }
            set { isEditUser = value; }
        }
        public void BindUserControlList(BindingSource userControlList)
        {
            dgvUserControl.DataSource = userControlList;
        }

        private void dgvUserControl_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            UserActionRequested?.Invoke(this, EventArgs.Empty);
        }




        //IPatientControl Eventhandler
        public event EventHandler? SearchRequestedByName;
        public event EventHandler? AddRequested;
        public event EventHandler? ActionRequested;

        //IUserControlView EventHandler
        public event EventHandler? UserSearchRequestedByName;
        public event EventHandler? UserAddRequested;
        public event EventHandler? UserActionRequested;
    }
}
