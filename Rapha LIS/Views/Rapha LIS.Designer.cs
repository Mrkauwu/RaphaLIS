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
            imageList1 = new ImageList(components);
            materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            btnAddPatient = new Button();
            txtPatientControlSearch = new TextBox();
            dgvUserControlPatients = new DataGridView();
            tabPage3 = new TabPage();
            tabPage4 = new TabPage();
            dgvAnalyticsPatients = new DataGridView();
            txtAnalyticsSearch = new TextBox();
            tabPage5 = new TabPage();
            tabPage6 = new TabPage();
            materialTabControl1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUserControlPatients).BeginInit();
            tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAnalyticsPatients).BeginInit();
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
            // materialTabControl1
            // 
            materialTabControl1.Controls.Add(tabPage1);
            materialTabControl1.Controls.Add(tabPage2);
            materialTabControl1.Controls.Add(tabPage3);
            materialTabControl1.Controls.Add(tabPage4);
            materialTabControl1.Controls.Add(tabPage5);
            materialTabControl1.Controls.Add(tabPage6);
            materialTabControl1.Depth = 0;
            materialTabControl1.Dock = DockStyle.Fill;
            materialTabControl1.ImageList = imageList1;
            materialTabControl1.Location = new Point(3, 64);
            materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            materialTabControl1.Multiline = true;
            materialTabControl1.Name = "materialTabControl1";
            materialTabControl1.SelectedIndex = 0;
            materialTabControl1.Size = new Size(1380, 721);
            materialTabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.ImageKey = "Dashboard.png";
            tabPage1.Location = new Point(4, 31);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1372, 686);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Dashboard";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(btnAddPatient);
            tabPage2.Controls.Add(txtPatientControlSearch);
            tabPage2.Controls.Add(dgvUserControlPatients);
            tabPage2.ImageKey = "Patient Management.png";
            tabPage2.Location = new Point(4, 31);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1372, 686);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Patient Control";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnAddPatient
            // 
            btnAddPatient.Location = new Point(375, 111);
            btnAddPatient.Name = "btnAddPatient";
            btnAddPatient.Size = new Size(75, 23);
            btnAddPatient.TabIndex = 4;
            btnAddPatient.Text = "button1";
            btnAddPatient.UseVisualStyleBackColor = true;
            // 
            // txtPatientControlSearch
            // 
            txtPatientControlSearch.Location = new Point(546, 106);
            txtPatientControlSearch.Name = "txtPatientControlSearch";
            txtPatientControlSearch.Size = new Size(100, 23);
            txtPatientControlSearch.TabIndex = 3;
            // 
            // dgvUserControlPatients
            // 
            dgvUserControlPatients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUserControlPatients.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvUserControlPatients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUserControlPatients.Location = new Point(6, 203);
            dgvUserControlPatients.Name = "dgvUserControlPatients";
            dgvUserControlPatients.Size = new Size(1360, 150);
            dgvUserControlPatients.TabIndex = 2;
            dgvUserControlPatients.CellDoubleClick += dgvUserControlPatients_CellDoubleClick;
            // 
            // tabPage3
            // 
            tabPage3.ImageKey = "User Management.png";
            tabPage3.Location = new Point(4, 31);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(1372, 686);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "User Control";
            tabPage3.UseVisualStyleBackColor = true;
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
            // Rapha_LIS
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1386, 788);
            Controls.Add(materialTabControl1);
            DrawerShowIconsWhenHidden = true;
            DrawerTabControl = materialTabControl1;
            Name = "Rapha_LIS";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Rapha_LIS";
            WindowState = FormWindowState.Maximized;
            materialTabControl1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUserControlPatients).EndInit();
            tabPage4.ResumeLayout(false);
            tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAnalyticsPatients).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ImageList imageList1;
        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private TabPage tabPage6;
        private DataGridView dgvUserControlPatients;
        private Button btnAddPatient;
        private TextBox txtPatientControlSearch;
        private TextBox txtAnalyticsSearch;
        private DataGridView dgvAnalyticsPatients;
    }
}