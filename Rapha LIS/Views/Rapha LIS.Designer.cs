namespace Rapha_LIS.Views
{
    partial class Rapha_LIS
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Rapha_LIS));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            imageList1 = new ImageList(components);
            tabPage6 = new TabPage();
            tabPage5 = new TabPage();
            tabPage4 = new TabPage();
            dgvAnalyticsPatients = new DataGridView();
            txtAnalyticsSearch = new TextBox();
            userTabPage = new TabPage();
            dgvUserControl = new DataGridView();
            txtUserControlSearch = new Guna.UI2.WinForms.Guna2TextBox();
            guna2DateTimePicker1 = new Guna.UI2.WinForms.Guna2DateTimePicker();
            btnAddUser = new Guna.UI2.WinForms.Guna2Button();
            patientTabPage = new TabPage();
            txtPatientControlSearch = new Guna.UI2.WinForms.Guna2TextBox();
            btnAddPatient = new Guna.UI2.WinForms.Guna2Button();
            dtpDateCreated = new Guna.UI2.WinForms.Guna2DateTimePicker();
            dgvPatientControl = new DataGridView();
            tabPage1 = new TabPage();
            materialButton2 = new MaterialSkin.Controls.MaterialButton();
            materialTextBox1 = new MaterialSkin.Controls.MaterialTextBox();
            materialButton1 = new MaterialSkin.Controls.MaterialButton();
            materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAnalyticsPatients).BeginInit();
            userTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUserControl).BeginInit();
            patientTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPatientControl).BeginInit();
            tabPage1.SuspendLayout();
            materialTabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "Analytics.png");
            imageList1.Images.SetKeyName(1, "Dashboard.png");
            imageList1.Images.SetKeyName(2, "Patient Management.png");
            imageList1.Images.SetKeyName(3, "Result.png");
            imageList1.Images.SetKeyName(4, "Settings.png");
            imageList1.Images.SetKeyName(5, "User Management.png");
            // 
            // tabPage6
            // 
            tabPage6.ImageKey = "Settings.png";
            tabPage6.Location = new Point(4, 31);
            tabPage6.Name = "tabPage6";
            tabPage6.Size = new Size(1372, 686);
            tabPage6.TabIndex = 5;
            tabPage6.Text = "Settings";
            tabPage6.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            tabPage5.ImageKey = "Result.png";
            tabPage5.Location = new Point(4, 31);
            tabPage5.Name = "tabPage5";
            tabPage5.Size = new Size(1372, 686);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "Results";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(dgvAnalyticsPatients);
            tabPage4.Controls.Add(txtAnalyticsSearch);
            tabPage4.ImageKey = "Analytics.png";
            tabPage4.Location = new Point(4, 31);
            tabPage4.Name = "tabPage4";
            tabPage4.Size = new Size(1372, 686);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Analytics";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // dgvAnalyticsPatients
            // 
            dgvAnalyticsPatients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAnalyticsPatients.Dock = DockStyle.Bottom;
            dgvAnalyticsPatients.Location = new Point(0, 214);
            dgvAnalyticsPatients.Name = "dgvAnalyticsPatients";
            dgvAnalyticsPatients.Size = new Size(1372, 472);
            dgvAnalyticsPatients.TabIndex = 1;
            // 
            // txtAnalyticsSearch
            // 
            txtAnalyticsSearch.Location = new Point(309, 60);
            txtAnalyticsSearch.Name = "txtAnalyticsSearch";
            txtAnalyticsSearch.Size = new Size(100, 23);
            txtAnalyticsSearch.TabIndex = 0;
            // 
            // userTabPage
            // 
            userTabPage.Controls.Add(dgvUserControl);
            userTabPage.Controls.Add(txtUserControlSearch);
            userTabPage.Controls.Add(guna2DateTimePicker1);
            userTabPage.Controls.Add(btnAddUser);
            userTabPage.ImageKey = "User Management.png";
            userTabPage.Location = new Point(4, 31);
            userTabPage.Name = "userTabPage";
            userTabPage.Size = new Size(1372, 686);
            userTabPage.TabIndex = 2;
            userTabPage.Text = "User Control";
            userTabPage.UseVisualStyleBackColor = true;
            // 
            // dgvUserControl
            // 
            dgvUserControl.AllowUserToAddRows = false;
            dgvUserControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvUserControl.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUserControl.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvUserControl.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(68, 88, 112);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(206, 147, 216);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvUserControl.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvUserControl.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUserControl.GridColor = Color.FromArgb(206, 147, 216);
            dgvUserControl.Location = new Point(6, 203);
            dgvUserControl.MultiSelect = false;
            dgvUserControl.Name = "dgvUserControl";
            dgvUserControl.ReadOnly = true;
            dgvUserControl.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(206, 147, 216);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(68, 88, 112);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(206, 147, 216);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvUserControl.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvUserControl.RowHeadersVisible = false;
            dgvUserControl.ScrollBars = ScrollBars.Vertical;
            dgvUserControl.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUserControl.Size = new Size(1360, 477);
            dgvUserControl.TabIndex = 12;
            dgvUserControl.CellDoubleClick += dgvUserControl_CellDoubleClick;
            // 
            // txtUserControlSearch
            // 
            txtUserControlSearch.Anchor = AnchorStyles.None;
            txtUserControlSearch.Animated = true;
            txtUserControlSearch.BorderColor = Color.FromArgb(243, 229, 245);
            txtUserControlSearch.BorderRadius = 6;
            txtUserControlSearch.BorderThickness = 2;
            txtUserControlSearch.CustomizableEdges = customizableEdges1;
            txtUserControlSearch.DefaultText = "";
            txtUserControlSearch.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtUserControlSearch.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtUserControlSearch.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtUserControlSearch.DisabledState.PlaceholderForeColor = Color.Silver;
            txtUserControlSearch.FocusedState.BorderColor = Color.FromArgb(206, 147, 216);
            txtUserControlSearch.Font = new Font("Segoe UI", 9F);
            txtUserControlSearch.ForeColor = Color.FromArgb(68, 88, 112);
            txtUserControlSearch.HoverState.BorderColor = Color.FromArgb(206, 147, 216);
            txtUserControlSearch.Location = new Point(369, 83);
            txtUserControlSearch.Name = "txtUserControlSearch";
            txtUserControlSearch.PlaceholderForeColor = Color.Silver;
            txtUserControlSearch.PlaceholderText = "Search User";
            txtUserControlSearch.SelectedText = "";
            txtUserControlSearch.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtUserControlSearch.Size = new Size(547, 40);
            txtUserControlSearch.TabIndex = 11;
            txtUserControlSearch.TabStop = false;
            // 
            // guna2DateTimePicker1
            // 
            guna2DateTimePicker1.Anchor = AnchorStyles.None;
            guna2DateTimePicker1.BackColor = Color.White;
            guna2DateTimePicker1.BorderColor = Color.FromArgb(206, 147, 216);
            guna2DateTimePicker1.BorderRadius = 6;
            guna2DateTimePicker1.BorderThickness = 1;
            guna2DateTimePicker1.Checked = true;
            guna2DateTimePicker1.CustomizableEdges = customizableEdges3;
            guna2DateTimePicker1.FillColor = Color.White;
            guna2DateTimePicker1.FocusedColor = Color.FromArgb(206, 147, 216);
            guna2DateTimePicker1.Font = new Font("Segoe UI", 9F);
            guna2DateTimePicker1.ForeColor = Color.FromArgb(68, 88, 112);
            guna2DateTimePicker1.Format = DateTimePickerFormat.Long;
            guna2DateTimePicker1.Location = new Point(979, 83);
            guna2DateTimePicker1.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            guna2DateTimePicker1.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            guna2DateTimePicker1.Name = "guna2DateTimePicker1";
            guna2DateTimePicker1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2DateTimePicker1.Size = new Size(251, 36);
            guna2DateTimePicker1.TabIndex = 10;
            guna2DateTimePicker1.Value = new DateTime(2025, 3, 12, 21, 36, 35, 491);
            // 
            // btnAddUser
            // 
            btnAddUser.Anchor = AnchorStyles.None;
            btnAddUser.Animated = true;
            btnAddUser.BackColor = Color.FromArgb(206, 147, 216);
            btnAddUser.BorderColor = Color.FromArgb(206, 147, 216);
            btnAddUser.BorderRadius = 6;
            btnAddUser.BorderThickness = 1;
            btnAddUser.CustomizableEdges = customizableEdges5;
            btnAddUser.DisabledState.BorderColor = Color.DarkGray;
            btnAddUser.DisabledState.CustomBorderColor = Color.DarkGray;
            btnAddUser.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnAddUser.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnAddUser.FillColor = Color.White;
            btnAddUser.FocusedColor = Color.FromArgb(206, 147, 216);
            btnAddUser.Font = new Font("Segoe UI", 9F);
            btnAddUser.ForeColor = Color.FromArgb(68, 88, 112);
            btnAddUser.HoverState.BorderColor = Color.FromArgb(206, 147, 216);
            btnAddUser.HoverState.FillColor = Color.FromArgb(243, 229, 245);
            btnAddUser.Location = new Point(142, 83);
            btnAddUser.Name = "btnAddUser";
            btnAddUser.PressedColor = Color.FromArgb(206, 147, 216);
            btnAddUser.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnAddUser.Size = new Size(164, 36);
            btnAddUser.TabIndex = 9;
            btnAddUser.Text = "Add User";
            // 
            // patientTabPage
            // 
            patientTabPage.Controls.Add(txtPatientControlSearch);
            patientTabPage.Controls.Add(btnAddPatient);
            patientTabPage.Controls.Add(dtpDateCreated);
            patientTabPage.Controls.Add(dgvPatientControl);
            patientTabPage.ImageKey = "Patient Management.png";
            patientTabPage.Location = new Point(4, 31);
            patientTabPage.Name = "patientTabPage";
            patientTabPage.Padding = new Padding(3);
            patientTabPage.Size = new Size(1372, 686);
            patientTabPage.TabIndex = 1;
            patientTabPage.Text = "Patient Control";
            patientTabPage.UseVisualStyleBackColor = true;
            // 
            // txtPatientControlSearch
            // 
            txtPatientControlSearch.Anchor = AnchorStyles.None;
            txtPatientControlSearch.Animated = true;
            txtPatientControlSearch.BorderColor = Color.FromArgb(243, 229, 245);
            txtPatientControlSearch.BorderRadius = 6;
            txtPatientControlSearch.BorderThickness = 2;
            txtPatientControlSearch.CustomizableEdges = customizableEdges7;
            txtPatientControlSearch.DefaultText = "";
            txtPatientControlSearch.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtPatientControlSearch.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtPatientControlSearch.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtPatientControlSearch.DisabledState.PlaceholderForeColor = Color.Silver;
            txtPatientControlSearch.FocusedState.BorderColor = Color.FromArgb(206, 147, 216);
            txtPatientControlSearch.Font = new Font("Segoe UI", 9F);
            txtPatientControlSearch.ForeColor = Color.FromArgb(68, 88, 112);
            txtPatientControlSearch.HoverState.BorderColor = Color.FromArgb(206, 147, 216);
            txtPatientControlSearch.Location = new Point(369, 83);
            txtPatientControlSearch.Name = "txtPatientControlSearch";
            txtPatientControlSearch.PlaceholderForeColor = Color.Silver;
            txtPatientControlSearch.PlaceholderText = "Search Patient";
            txtPatientControlSearch.SelectedText = "";
            txtPatientControlSearch.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtPatientControlSearch.Size = new Size(547, 40);
            txtPatientControlSearch.TabIndex = 9;
            txtPatientControlSearch.TabStop = false;
            // 
            // btnAddPatient
            // 
            btnAddPatient.Anchor = AnchorStyles.None;
            btnAddPatient.Animated = true;
            btnAddPatient.BackColor = Color.FromArgb(206, 147, 216);
            btnAddPatient.BorderColor = Color.FromArgb(206, 147, 216);
            btnAddPatient.BorderRadius = 6;
            btnAddPatient.BorderThickness = 1;
            btnAddPatient.CustomizableEdges = customizableEdges9;
            btnAddPatient.DisabledState.BorderColor = Color.DarkGray;
            btnAddPatient.DisabledState.CustomBorderColor = Color.DarkGray;
            btnAddPatient.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnAddPatient.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnAddPatient.FillColor = Color.White;
            btnAddPatient.FocusedColor = Color.FromArgb(206, 147, 216);
            btnAddPatient.Font = new Font("Segoe UI", 9F);
            btnAddPatient.ForeColor = Color.FromArgb(68, 88, 112);
            btnAddPatient.HoverState.BorderColor = Color.FromArgb(206, 147, 216);
            btnAddPatient.HoverState.FillColor = Color.FromArgb(243, 229, 245);
            btnAddPatient.Location = new Point(142, 83);
            btnAddPatient.Name = "btnAddPatient";
            btnAddPatient.PressedColor = Color.FromArgb(206, 147, 216);
            btnAddPatient.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnAddPatient.Size = new Size(164, 36);
            btnAddPatient.TabIndex = 8;
            btnAddPatient.Text = "Add Patient";
            // 
            // dtpDateCreated
            // 
            dtpDateCreated.Anchor = AnchorStyles.None;
            dtpDateCreated.BackColor = Color.White;
            dtpDateCreated.BorderColor = Color.FromArgb(206, 147, 216);
            dtpDateCreated.BorderRadius = 6;
            dtpDateCreated.BorderThickness = 1;
            dtpDateCreated.Checked = true;
            dtpDateCreated.CustomizableEdges = customizableEdges11;
            dtpDateCreated.FillColor = Color.White;
            dtpDateCreated.FocusedColor = Color.FromArgb(206, 147, 216);
            dtpDateCreated.Font = new Font("Segoe UI", 9F);
            dtpDateCreated.ForeColor = Color.FromArgb(68, 88, 112);
            dtpDateCreated.Format = DateTimePickerFormat.Long;
            dtpDateCreated.Location = new Point(979, 83);
            dtpDateCreated.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dtpDateCreated.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dtpDateCreated.Name = "dtpDateCreated";
            dtpDateCreated.ShadowDecoration.CustomizableEdges = customizableEdges12;
            dtpDateCreated.Size = new Size(251, 36);
            dtpDateCreated.TabIndex = 7;
            dtpDateCreated.Value = new DateTime(2025, 3, 12, 21, 36, 35, 491);
            // 
            // dgvPatientControl
            // 
            dgvPatientControl.AllowUserToAddRows = false;
            dgvPatientControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPatientControl.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPatientControl.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvPatientControl.BackgroundColor = Color.White;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(68, 88, 112);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(206, 147, 216);
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvPatientControl.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvPatientControl.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPatientControl.GridColor = Color.FromArgb(206, 147, 216);
            dgvPatientControl.Location = new Point(6, 203);
            dgvPatientControl.MultiSelect = false;
            dgvPatientControl.Name = "dgvPatientControl";
            dgvPatientControl.ReadOnly = true;
            dgvPatientControl.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(206, 147, 216);
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(68, 88, 112);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(206, 147, 216);
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvPatientControl.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvPatientControl.RowHeadersVisible = false;
            dgvPatientControl.ScrollBars = ScrollBars.Vertical;
            dgvPatientControl.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPatientControl.Size = new Size(1360, 477);
            dgvPatientControl.TabIndex = 2;
            dgvPatientControl.CellDoubleClick += dgvUserControlPatients_CellDoubleClick;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(materialButton2);
            tabPage1.Controls.Add(materialTextBox1);
            tabPage1.Controls.Add(materialButton1);
            tabPage1.ImageKey = "Dashboard.png";
            tabPage1.Location = new Point(4, 31);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1372, 686);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Dashboard";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // materialButton2
            // 
            materialButton2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton2.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton2.Depth = 0;
            materialButton2.HighEmphasis = true;
            materialButton2.Icon = null;
            materialButton2.Location = new Point(701, 146);
            materialButton2.Margin = new Padding(4, 6, 4, 6);
            materialButton2.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton2.Name = "materialButton2";
            materialButton2.NoAccentTextColor = Color.Empty;
            materialButton2.Size = new Size(158, 36);
            materialButton2.TabIndex = 2;
            materialButton2.Text = "materialButton2";
            materialButton2.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButton2.UseAccentColor = false;
            materialButton2.UseVisualStyleBackColor = true;
            // 
            // materialTextBox1
            // 
            materialTextBox1.AnimateReadOnly = false;
            materialTextBox1.BorderStyle = BorderStyle.None;
            materialTextBox1.Depth = 0;
            materialTextBox1.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialTextBox1.LeadingIcon = null;
            materialTextBox1.Location = new Point(541, 138);
            materialTextBox1.MaxLength = 50;
            materialTextBox1.MouseState = MaterialSkin.MouseState.OUT;
            materialTextBox1.Multiline = false;
            materialTextBox1.Name = "materialTextBox1";
            materialTextBox1.Size = new Size(100, 50);
            materialTextBox1.TabIndex = 1;
            materialTextBox1.Text = "";
            materialTextBox1.TrailingIcon = null;
            // 
            // materialButton1
            // 
            materialButton1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton1.Depth = 0;
            materialButton1.HighEmphasis = true;
            materialButton1.Icon = null;
            materialButton1.Location = new Point(355, 138);
            materialButton1.Margin = new Padding(4, 6, 4, 6);
            materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton1.Name = "materialButton1";
            materialButton1.NoAccentTextColor = Color.Empty;
            materialButton1.Size = new Size(158, 36);
            materialButton1.TabIndex = 0;
            materialButton1.Text = "materialButton1";
            materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButton1.UseAccentColor = false;
            materialButton1.UseVisualStyleBackColor = true;
            // 
            // materialTabControl1
            // 
            materialTabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            materialTabControl1.Controls.Add(tabPage1);
            materialTabControl1.Controls.Add(patientTabPage);
            materialTabControl1.Controls.Add(userTabPage);
            materialTabControl1.Controls.Add(tabPage4);
            materialTabControl1.Controls.Add(tabPage5);
            materialTabControl1.Controls.Add(tabPage6);
            materialTabControl1.Depth = 0;
            materialTabControl1.ImageList = imageList1;
            materialTabControl1.Location = new Point(3, 64);
            materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            materialTabControl1.Multiline = true;
            materialTabControl1.Name = "materialTabControl1";
            materialTabControl1.SelectedIndex = 0;
            materialTabControl1.Size = new Size(1380, 721);
            materialTabControl1.TabIndex = 0;
            // 
            // Rapha_LIS
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1386, 788);
            Controls.Add(materialTabControl1);
            DrawerShowIconsWhenHidden = true;
            DrawerTabControl = materialTabControl1;
            Name = "Rapha_LIS";
            Sizable = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Rapha LIS";
            WindowState = FormWindowState.Maximized;
            tabPage4.ResumeLayout(false);
            tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAnalyticsPatients).EndInit();
            userTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUserControl).EndInit();
            patientTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPatientControl).EndInit();
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            materialTabControl1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ImageList imageList1;
        private TabPage tabPage6;
        private TabPage tabPage5;
        private TabPage tabPage4;
        private DataGridView dgvAnalyticsPatients;
        private TextBox txtAnalyticsSearch;
        private TabPage userTabPage;
        private TabPage patientTabPage;
        private Guna.UI2.WinForms.Guna2TextBox txtPatientControlSearch;
        private Guna.UI2.WinForms.Guna2Button btnAddPatient;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpDateCreated;
        private DataGridView dgvPatientControl;
        private TabPage tabPage1;
        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private MaterialSkin.Controls.MaterialButton materialButton2;
        private MaterialSkin.Controls.MaterialTextBox materialTextBox1;
        private MaterialSkin.Controls.MaterialButton materialButton1;
        private Guna.UI2.WinForms.Guna2Button btnAddUser;
        private Guna.UI2.WinForms.Guna2TextBox txtUserControlSearch;
        private Guna.UI2.WinForms.Guna2DateTimePicker guna2DateTimePicker1;
        private DataGridView dgvUserControl;
    }
}