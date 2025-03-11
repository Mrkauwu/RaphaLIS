namespace Rapha_LIS.Views
{
    partial class PatientActionView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnSave = new Button();
            txtFirstName = new TextBox();
            txtLastName = new TextBox();
            txtMiddleInitial = new TextBox();
            txtAge = new TextBox();
            txtContact = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            cmbSex = new ComboBox();
            txtTest = new TextBox();
            Test = new Label();
            dtpBirthdate = new DateTimePicker();
            txtAddress = new TextBox();
            txtCivilStatus = new TextBox();
            txtReligion = new TextBox();
            btnDelete = new Button();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.Location = new Point(202, 284);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(35, 35);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(100, 23);
            txtFirstName.TabIndex = 1;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(35, 82);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(100, 23);
            txtLastName.TabIndex = 1;
            // 
            // txtMiddleInitial
            // 
            txtMiddleInitial.Location = new Point(35, 132);
            txtMiddleInitial.Name = "txtMiddleInitial";
            txtMiddleInitial.Size = new Size(100, 23);
            txtMiddleInitial.TabIndex = 1;
            // 
            // txtAge
            // 
            txtAge.Location = new Point(35, 176);
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(100, 23);
            txtAge.TabIndex = 1;
            // 
            // txtContact
            // 
            txtContact.Location = new Point(158, 222);
            txtContact.Name = "txtContact";
            txtContact.Size = new Size(100, 23);
            txtContact.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(35, 17);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 2;
            label1.Text = "label1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(35, 61);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 2;
            label2.Text = "label1";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(35, 114);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 2;
            label3.Text = "label1";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(35, 158);
            label4.Name = "label4";
            label4.Size = new Size(28, 15);
            label4.TabIndex = 2;
            label4.Text = "Age";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(35, 204);
            label5.Name = "label5";
            label5.Size = new Size(25, 15);
            label5.TabIndex = 2;
            label5.Text = "Sex";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(158, 17);
            label6.Name = "label6";
            label6.Size = new Size(38, 15);
            label6.TabIndex = 2;
            label6.Text = "label1";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(158, 61);
            label7.Name = "label7";
            label7.Size = new Size(29, 15);
            label7.TabIndex = 2;
            label7.Text = "Add";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(158, 114);
            label8.Name = "label8";
            label8.Size = new Size(27, 15);
            label8.TabIndex = 2;
            label8.Text = "Stat";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(158, 158);
            label9.Name = "label9";
            label9.Size = new Size(23, 15);
            label9.TabIndex = 2;
            label9.Text = "Rel";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(158, 204);
            label10.Name = "label10";
            label10.Size = new Size(29, 15);
            label10.TabIndex = 2;
            label10.Text = "Con";
            // 
            // cmbSex
            // 
            cmbSex.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSex.FormattingEnabled = true;
            cmbSex.Items.AddRange(new object[] { "Male", "Female" });
            cmbSex.Location = new Point(14, 222);
            cmbSex.Name = "cmbSex";
            cmbSex.Size = new Size(121, 23);
            cmbSex.TabIndex = 3;
            // 
            // txtTest
            // 
            txtTest.Location = new Point(286, 222);
            txtTest.Name = "txtTest";
            txtTest.Size = new Size(100, 23);
            txtTest.TabIndex = 1;
            // 
            // Test
            // 
            Test.AutoSize = true;
            Test.Location = new Point(286, 204);
            Test.Name = "Test";
            Test.Size = new Size(27, 15);
            Test.TabIndex = 2;
            Test.Text = "Test";
            // 
            // dtpBirthdate
            // 
            dtpBirthdate.Location = new Point(158, 35);
            dtpBirthdate.Name = "dtpBirthdate";
            dtpBirthdate.Size = new Size(200, 23);
            dtpBirthdate.TabIndex = 4;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(158, 82);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(100, 23);
            txtAddress.TabIndex = 5;
            // 
            // txtCivilStatus
            // 
            txtCivilStatus.Location = new Point(158, 132);
            txtCivilStatus.Name = "txtCivilStatus";
            txtCivilStatus.Size = new Size(100, 23);
            txtCivilStatus.TabIndex = 5;
            // 
            // txtReligion
            // 
            txtReligion.Location = new Point(158, 178);
            txtReligion.Name = "txtReligion";
            txtReligion.Size = new Size(100, 23);
            txtReligion.TabIndex = 5;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(286, 284);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 6;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // PatientActionView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(405, 333);
            Controls.Add(btnDelete);
            Controls.Add(txtReligion);
            Controls.Add(txtCivilStatus);
            Controls.Add(txtAddress);
            Controls.Add(dtpBirthdate);
            Controls.Add(cmbSex);
            Controls.Add(label10);
            Controls.Add(label5);
            Controls.Add(label9);
            Controls.Add(label4);
            Controls.Add(label8);
            Controls.Add(label3);
            Controls.Add(label7);
            Controls.Add(label2);
            Controls.Add(Test);
            Controls.Add(label6);
            Controls.Add(label1);
            Controls.Add(txtContact);
            Controls.Add(txtAge);
            Controls.Add(txtMiddleInitial);
            Controls.Add(txtTest);
            Controls.Add(txtLastName);
            Controls.Add(txtFirstName);
            Controls.Add(btnSave);
            KeyPreview = true;
            Name = "PatientActionView";
            Text = "AddPatientView";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSave;
        private TextBox txtFirstName;
        private TextBox txtLastName;
        private TextBox txtMiddleInitial;
        private TextBox txtAge;
        private TextBox txtContact;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private ComboBox cmbSex;
        private TextBox txtTest;
        private Label Test;
        private DateTimePicker dtpBirthdate;
        private TextBox txtAddress;
        private TextBox txtCivilStatus;
        private TextBox txtReligion;
        private Button btnDelete;
    }
}