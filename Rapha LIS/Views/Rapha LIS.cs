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
    public partial class Rapha_LIS : MaterialForm, IPatientControlView, IUserControlView, IPatientAnalyticsView, IPatientResult
    {
        private bool isEdit;
        private bool isEditUser;
        private bool isEditResult;
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
            lblUserControl.Font = new Font(lblUserControl.Font.FontFamily, 24, FontStyle.Regular);
            lblPatientControl.Font = new Font(lblUserControl.Font.FontFamily, 24, FontStyle.Regular);
            lblAnalytics.Font = new Font(lblUserControl.Font.FontFamily, 24, FontStyle.Regular);
        }

        //Patient Control

        private void AssociateAndRaiseViewEvents()
        {
            //PatientControl TabPage
            btnAddPatient.Click += (s, e) =>
            {
                AddRequested?.Invoke(this, EventArgs.Empty);
            };

            txtPatientControlSearch.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    SearchRequestedByName?.Invoke(this, EventArgs.Empty);
            };

            //User Control TabPage
            btnAddUser.Click += (s, e) =>
            {
                UserAddRequested?.Invoke(this, EventArgs.Empty);
            };

            txtUserControlSearch.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    UserSearchRequestedByName?.Invoke(this, EventArgs.Empty);
            };

            //Analytics TabPage
            txtAnalyticsSearch.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    SearchRequestedByHIR?.Invoke(this, EventArgs.Empty);
            };
            //Result Tabpage
            txtSearchPatientResult.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    ResultSearchRequested?.Invoke(this, EventArgs.Empty);
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

        public string SearchQueryByHIR
        {
            get { return txtAnalyticsSearch.Text; }
            set { txtAnalyticsSearch.Text = value; }
        }

        public void BindPatientAnalyticsList(BindingSource patientAnalyticsList)
        {
            dgvAnalyticsPatients.DataSource = patientAnalyticsList;
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        private void dgvAnalyticsPatients_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AnalyticsActionRequested?.Invoke(this, EventArgs.Empty);
        }

        //Patient Result
        public string ResultSearchQuery
        {
            get { return txtSearchPatientResult.Text; }
            set { txtSearchPatientResult.Text = value; }
        }

        public bool EditResult
        {
            get { return isEditResult; }
            set { isEditResult = value; }
        }

        public void BindPatientResult(BindingSource resultBindingSource)
        {
            dgvPatientResult.DataSource = resultBindingSource;
        }

        private void dgvPatientResult_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ResultActionRequested?.Invoke(this, EventArgs.Empty);
        }

        //IPatientControlView Eventhandler
        public event EventHandler? SearchRequestedByName;
        public event EventHandler? AddRequested;
        public event EventHandler? ActionRequested;

        //IUserControlView EventHandler
        public event EventHandler? UserSearchRequestedByName;
        public event EventHandler? UserAddRequested;
        public event EventHandler? UserActionRequested;

        //IPatientAnalyticsView EventHandler
        public event EventHandler? SearchRequestedByHIR;
        public event EventHandler? AnalyticsActionRequested;

        //IPatientResult EventHandler
        public event EventHandler? ResultSearchRequested;
        public event EventHandler? ResultActionRequested;
    }
}
