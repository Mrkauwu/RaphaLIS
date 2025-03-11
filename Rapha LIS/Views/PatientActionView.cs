using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Rapha_LIS.Views
{
    public partial class PatientActionView : Form, IPatientActionView
    {
        private string message = string.Empty;
        private bool isSuccessful;
        private bool isEdit;                                                                                     
        

        public PatientActionView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
        }

        private void AssociateAndRaiseViewEvents()
        {
            btnSave.Click += (s, e) =>
            {
                SaveRequested?.Invoke(this, EventArgs.Empty);
            };

            btnDelete.Click += (s, e) =>
            {
                DeleteRequested?.Invoke(this, EventArgs.Empty);
            };

        }

        

        public string? FirstName
        {
            get { return txtFirstName.Text; }
            set { txtFirstName.Text = value; }
        }
        public string? LastName
        {
            get { return txtLastName.Text; }
            set { txtLastName.Text = value; }
        }

        public string? MiddleInitial
        {
            get { return txtMiddleInitial.Text; }
            set { txtMiddleInitial.Text = value; }
        }

        public string Age
        {
            get { return txtAge.Text; }
            set { txtAge.Text = value; }
        }

        public string? Sex
        {
            get { return cmbSex.Text; }
            set { cmbSex.Text = value; }
        }

        public string? Address
        {
            get { return txtAddress.Text; }
            set { txtAddress.Text = value; }
        }
        public string? CivilStatus
        {
            get { return txtCivilStatus.Text; }
            set { txtCivilStatus.Text = value; }
        }
        public string? Religion
        {
            get { return txtReligion.Text; }
            set { txtReligion.Text = value; }
        }
        public string? Contact
        {
            get { return txtContact.Text; }
            set { txtContact.Text = value; }
        }


        string? IPatientActionView.Test
        {
            get { return txtTest.Text; }
            set { txtTest.Text = value; }
        }

        public DateTime Birthdate { get; set; }


        public bool IsSuccessful
        {
            get { return isSuccessful; }
            set { isSuccessful = value; }
        }   
        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        public bool IsEdit                                                  
        {
            get { return isEdit; }
            set { isEdit = value; }
        }

        public DateTime DateCreated => DateTime.Now;

        public int Id { get; set; }

        public event EventHandler? SaveRequested;
        
        public event EventHandler? DeleteRequested;
    }
}
