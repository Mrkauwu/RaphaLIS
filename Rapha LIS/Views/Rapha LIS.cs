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
    public partial class Rapha_LIS : MaterialForm, IUserControlView //IPatientAnalyticsView
    {
        private bool isEdit;
        public Rapha_LIS()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            materialSkinManager.ColorScheme = new ColorScheme(
            (Primary)0xFFFFFF,  // Pure white background
            (Primary)0xF1F8E9,  // Very light green (subtle medical feel)
            (Primary)0xC8E6C9,  // Slightly darker green (depth)
            (Accent)0x66BB6A,   // Soft green accent (natural and calming)
            TextShade.BLACK     // Black text for contrast
            );
        }

        //IUser Control

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
            dgvUserControlPatients.DataSource = patientControlList;
        }

        
        //IAnalyticsView
        /*public string SearchQueryById
        {
            get { return txtAnalyticsSearch.Text; }
            set { txtAnalyticsSearch.Text = value; }
        }

        public void BindPatientAnalyticsList(BindingSource patientAnalyticsList)
        {
            dgvAnalyticsPatients.DataSource = patientAnalyticsList;
        }*/

        //IPatientAction Eventhandler
        public event EventHandler? SearchRequestedByName;
        public event EventHandler? AddRequested;
        public event EventHandler? ActionRequested;
        //IAnalytics EventHandler
        //public event EventHandler? SearchRequestedById;
        //public event EventHandler? RemovePatientRequested;
    }
}
