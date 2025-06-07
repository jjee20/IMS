namespace RavenTech_ERP.Views.UserControls.Inventory
{
    partial class UpsertEmployeeView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpsertEmployeeView));
            txtAddress = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            btnSave = new Syncfusion.WinForms.Controls.SfButton();
            autoLabel4 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtBirthDate = new Syncfusion.Windows.Forms.Tools.DateTimePickerAdv();
            txtFirstName = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            autoLabel7 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtLastName = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            autoLabel8 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel9 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtGender = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            txtContactNumber = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            autoLabel10 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtEmail = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            autoLabel11 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel12 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtLeaveCredits = new Syncfusion.Windows.Forms.Tools.DoubleTextBox();
            txtIsDeducted = new Syncfusion.Windows.Forms.Tools.CheckBoxAdv();
            txtShift = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            autoLabel3 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel6 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtJobPosition = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            txtDepartment = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            autoLabel5 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtBasicSalary = new Syncfusion.Windows.Forms.Tools.DoubleTextBox();
            txtStartDate = new Syncfusion.Windows.Forms.Tools.DateTimePickerAdv();
            autoLabel13 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtEndDate = new Syncfusion.Windows.Forms.Tools.DateTimePickerAdv();
            autoLabel14 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtIsActive = new Syncfusion.Windows.Forms.Tools.CheckBoxAdv();
            popupMenu1 = new Syncfusion.Windows.Forms.Tools.XPMenus.PopupMenu(components);
            autoLabel15 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            ((System.ComponentModel.ISupportInitialize)txtAddress).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtBirthDate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtBirthDate.Calendar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtFirstName).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtLastName).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtGender).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtContactNumber).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtEmail).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtLeaveCredits).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtIsDeducted).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtShift).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtJobPosition).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtDepartment).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtBasicSalary).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtStartDate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtStartDate.Calendar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtEndDate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtEndDate.Calendar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtIsActive).BeginInit();
            SuspendLayout();
            // 
            // txtAddress
            // 
            txtAddress.BeforeTouchSize = new Size(100, 23);
            txtAddress.Location = new Point(179, 239);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(206, 89);
            txtAddress.TabIndex = 3;
            // 
            // autoLabel2
            // 
            autoLabel2.Location = new Point(100, 240);
            autoLabel2.Name = "autoLabel2";
            autoLabel2.Size = new Size(49, 15);
            autoLabel2.TabIndex = 2;
            autoLabel2.Text = "Address";
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI Semibold", 9F);
            btnSave.Location = new Point(196, 677);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(96, 28);
            btnSave.TabIndex = 4;
            btnSave.Text = "Save";
            btnSave.Click += btnSave_Click;
            // 
            // autoLabel4
            // 
            autoLabel4.Location = new Point(98, 111);
            autoLabel4.Name = "autoLabel4";
            autoLabel4.Size = new Size(59, 15);
            autoLabel4.TabIndex = 6;
            autoLabel4.Text = "Birth Date";
            // 
            // txtBirthDate
            // 
            txtBirthDate.BorderColor = Color.Empty;
            // 
            // 
            // 
            txtBirthDate.Calendar.AllowMultipleSelection = false;
            txtBirthDate.Calendar.BottomHeight = 25;
            txtBirthDate.Calendar.DayNamesFont = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtBirthDate.Calendar.DaysFont = new Font("Segoe UI", 9F);
            txtBirthDate.Calendar.Dock = DockStyle.Fill;
            txtBirthDate.Calendar.Font = new Font("Segoe UI", 9F);
            txtBirthDate.Calendar.ForeColor = SystemColors.ControlText;
            txtBirthDate.Calendar.HeaderFont = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtBirthDate.Calendar.Location = new Point(0, 0);
            txtBirthDate.Calendar.MetroColor = Color.FromArgb(22, 165, 220);
            txtBirthDate.Calendar.Name = "monthCalendar";
            txtBirthDate.Calendar.Size = new Size(187, 174);
            txtBirthDate.Calendar.SizeToFit = true;
            txtBirthDate.Calendar.TabIndex = 0;
            // 
            // 
            // 
            txtBirthDate.Calendar.NoneButton.AutoSize = true;
            txtBirthDate.Calendar.NoneButton.Location = new Point(115, 0);
            txtBirthDate.Calendar.NoneButton.Text = "None";
            // 
            // 
            // 
            txtBirthDate.Calendar.TodayButton.AutoSize = true;
            txtBirthDate.Calendar.TodayButton.Location = new Point(0, 0);
            txtBirthDate.Calendar.TodayButton.Text = "Today";
            txtBirthDate.CalendarForeColor = SystemColors.ControlText;
            txtBirthDate.CalendarSize = new Size(189, 176);
            txtBirthDate.DropDownImage = null;
            txtBirthDate.Font = new Font("Segoe UI", 9F);
            txtBirthDate.Location = new Point(179, 106);
            txtBirthDate.MetroColor = Color.FromArgb(22, 165, 220);
            txtBirthDate.MinValue = new DateTime(0L);
            txtBirthDate.Name = "txtBirthDate";
            txtBirthDate.Size = new Size(206, 20);
            txtBirthDate.TabIndex = 8;
            txtBirthDate.Value = new DateTime(2025, 4, 10, 22, 35, 0, 415);
            // 
            // txtFirstName
            // 
            txtFirstName.BeforeTouchSize = new Size(100, 23);
            txtFirstName.Location = new Point(179, 42);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(206, 23);
            txtFirstName.TabIndex = 17;
            // 
            // autoLabel7
            // 
            autoLabel7.Location = new Point(98, 45);
            autoLabel7.Name = "autoLabel7";
            autoLabel7.Size = new Size(64, 15);
            autoLabel7.TabIndex = 16;
            autoLabel7.Text = "First Name";
            // 
            // txtLastName
            // 
            txtLastName.BeforeTouchSize = new Size(100, 23);
            txtLastName.Location = new Point(179, 74);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(206, 23);
            txtLastName.TabIndex = 19;
            // 
            // autoLabel8
            // 
            autoLabel8.Location = new Point(98, 78);
            autoLabel8.Name = "autoLabel8";
            autoLabel8.Size = new Size(63, 15);
            autoLabel8.TabIndex = 18;
            autoLabel8.Text = "Last Name";
            // 
            // autoLabel9
            // 
            autoLabel9.Location = new Point(98, 144);
            autoLabel9.Name = "autoLabel9";
            autoLabel9.Size = new Size(45, 15);
            autoLabel9.TabIndex = 20;
            autoLabel9.Text = "Gender";
            // 
            // txtGender
            // 
            txtGender.BackColor = Color.FromArgb(255, 255, 255);
            txtGender.ForeColor = Color.FromArgb(68, 68, 68);
            txtGender.Height = 31;
            txtGender.Location = new Point(179, 135);
            txtGender.Name = "txtGender";
            txtGender.Size = new Size(206, 31);
            txtGender.TabIndex = 21;
            txtGender.Text = "~Select~";
            txtGender.TextBoxHeight = 23;
            txtGender.ThemeName = "Office2016Colorful";
            // 
            // txtContactNumber
            // 
            txtContactNumber.BeforeTouchSize = new Size(100, 23);
            txtContactNumber.Location = new Point(179, 175);
            txtContactNumber.Name = "txtContactNumber";
            txtContactNumber.Size = new Size(206, 23);
            txtContactNumber.TabIndex = 23;
            // 
            // autoLabel10
            // 
            autoLabel10.Location = new Point(98, 177);
            autoLabel10.Name = "autoLabel10";
            autoLabel10.Size = new Size(59, 15);
            autoLabel10.TabIndex = 22;
            autoLabel10.Text = "Contact #";
            // 
            // txtEmail
            // 
            txtEmail.BeforeTouchSize = new Size(100, 23);
            txtEmail.Location = new Point(179, 207);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(206, 23);
            txtEmail.TabIndex = 25;
            // 
            // autoLabel11
            // 
            autoLabel11.Location = new Point(98, 210);
            autoLabel11.Name = "autoLabel11";
            autoLabel11.Size = new Size(36, 15);
            autoLabel11.TabIndex = 24;
            autoLabel11.Text = "Email";
            // 
            // autoLabel1
            // 
            autoLabel1.Location = new Point(98, 347);
            autoLabel1.Name = "autoLabel1";
            autoLabel1.Size = new Size(70, 15);
            autoLabel1.TabIndex = 26;
            autoLabel1.Text = "Department";
            // 
            // autoLabel12
            // 
            autoLabel12.Location = new Point(98, 488);
            autoLabel12.Name = "autoLabel12";
            autoLabel12.Size = new Size(77, 15);
            autoLabel12.TabIndex = 35;
            autoLabel12.Text = "Leave Credits";
            // 
            // txtLeaveCredits
            // 
            txtLeaveCredits.AccessibilityEnabled = true;
            txtLeaveCredits.BeforeTouchSize = new Size(100, 23);
            txtLeaveCredits.DoubleValue = 0D;
            txtLeaveCredits.Location = new Point(179, 486);
            txtLeaveCredits.Name = "txtLeaveCredits";
            txtLeaveCredits.Size = new Size(206, 23);
            txtLeaveCredits.TabIndex = 36;
            txtLeaveCredits.Text = "0.00";
            // 
            // txtIsDeducted
            // 
            txtIsDeducted.AccessibilityEnabled = true;
            txtIsDeducted.BeforeTouchSize = new Size(113, 26);
            txtIsDeducted.Border3DStyle = Border3DStyle.RaisedOuter;
            txtIsDeducted.Location = new Point(179, 515);
            txtIsDeducted.Name = "txtIsDeducted";
            txtIsDeducted.Size = new Size(113, 26);
            txtIsDeducted.TabIndex = 32;
            txtIsDeducted.Text = "Is Deducted?";
            // 
            // txtShift
            // 
            txtShift.BackColor = Color.FromArgb(255, 255, 255);
            txtShift.ForeColor = Color.FromArgb(68, 68, 68);
            txtShift.Height = 31;
            txtShift.Location = new Point(179, 415);
            txtShift.Name = "txtShift";
            txtShift.Size = new Size(206, 31);
            txtShift.TabIndex = 34;
            txtShift.Text = "~Select~";
            txtShift.TextBoxHeight = 23;
            txtShift.ThemeName = "Office2016Colorful";
            // 
            // autoLabel3
            // 
            autoLabel3.Location = new Point(98, 383);
            autoLabel3.Name = "autoLabel3";
            autoLabel3.Size = new Size(71, 15);
            autoLabel3.TabIndex = 27;
            autoLabel3.Text = "Job Position";
            // 
            // autoLabel6
            // 
            autoLabel6.Location = new Point(98, 423);
            autoLabel6.Name = "autoLabel6";
            autoLabel6.Size = new Size(31, 15);
            autoLabel6.TabIndex = 33;
            autoLabel6.Text = "Shift";
            // 
            // txtJobPosition
            // 
            txtJobPosition.BackColor = Color.FromArgb(255, 255, 255);
            txtJobPosition.ForeColor = Color.FromArgb(68, 68, 68);
            txtJobPosition.Height = 31;
            txtJobPosition.Location = new Point(179, 378);
            txtJobPosition.Name = "txtJobPosition";
            txtJobPosition.Size = new Size(206, 31);
            txtJobPosition.TabIndex = 28;
            txtJobPosition.Text = "~Select~";
            txtJobPosition.TextBoxHeight = 23;
            txtJobPosition.ThemeName = "Office2016Colorful";
            // 
            // txtDepartment
            // 
            txtDepartment.BackColor = Color.FromArgb(255, 255, 255);
            txtDepartment.ForeColor = Color.FromArgb(68, 68, 68);
            txtDepartment.Height = 31;
            txtDepartment.Location = new Point(179, 340);
            txtDepartment.Name = "txtDepartment";
            txtDepartment.Size = new Size(206, 31);
            txtDepartment.TabIndex = 29;
            txtDepartment.Text = "~Select~";
            txtDepartment.TextBoxHeight = 23;
            txtDepartment.ThemeName = "Office2016Colorful";
            // 
            // autoLabel5
            // 
            autoLabel5.Location = new Point(98, 457);
            autoLabel5.Name = "autoLabel5";
            autoLabel5.Size = new Size(68, 15);
            autoLabel5.TabIndex = 30;
            autoLabel5.Text = "Basic Salary";
            // 
            // txtBasicSalary
            // 
            txtBasicSalary.AccessibilityEnabled = true;
            txtBasicSalary.BeforeTouchSize = new Size(100, 23);
            txtBasicSalary.DoubleValue = 0D;
            txtBasicSalary.Location = new Point(179, 455);
            txtBasicSalary.Name = "txtBasicSalary";
            txtBasicSalary.Size = new Size(206, 23);
            txtBasicSalary.TabIndex = 31;
            txtBasicSalary.Text = "0.00";
            // 
            // txtStartdate
            // 
            txtStartDate.BorderColor = Color.Empty;
            // 
            // 
            // 
            txtStartDate.Calendar.AllowMultipleSelection = false;
            txtStartDate.Calendar.BottomHeight = 25;
            txtStartDate.Calendar.DayNamesFont = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtStartDate.Calendar.DaysFont = new Font("Segoe UI", 9F);
            txtStartDate.Calendar.Dock = DockStyle.Fill;
            txtStartDate.Calendar.Font = new Font("Segoe UI", 9F);
            txtStartDate.Calendar.ForeColor = SystemColors.ControlText;
            txtStartDate.Calendar.HeaderFont = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtStartDate.Calendar.Location = new Point(0, 0);
            txtStartDate.Calendar.MetroColor = Color.FromArgb(22, 165, 220);
            txtStartDate.Calendar.Name = "monthCalendar";
            txtStartDate.Calendar.Size = new Size(187, 174);
            txtStartDate.Calendar.SizeToFit = true;
            txtStartDate.Calendar.TabIndex = 0;
            // 
            // 
            // 
            txtStartDate.Calendar.NoneButton.AutoSize = true;
            txtStartDate.Calendar.NoneButton.Location = new Point(115, 0);
            txtStartDate.Calendar.NoneButton.Text = "None";
            // 
            // 
            // 
            txtStartDate.Calendar.TodayButton.AutoSize = true;
            txtStartDate.Calendar.TodayButton.Location = new Point(0, 0);
            txtStartDate.Calendar.TodayButton.Text = "Today";
            txtStartDate.CalendarForeColor = SystemColors.ControlText;
            txtStartDate.CalendarSize = new Size(189, 176);
            txtStartDate.DropDownImage = null;
            txtStartDate.Font = new Font("Segoe UI", 9F);
            txtStartDate.Location = new Point(181, 571);
            txtStartDate.MetroColor = Color.FromArgb(22, 165, 220);
            txtStartDate.MinValue = new DateTime(0L);
            txtStartDate.Name = "txtStartdate";
            txtStartDate.Size = new Size(206, 20);
            txtStartDate.TabIndex = 38;
            txtStartDate.Value = new DateTime(2025, 4, 10, 22, 35, 0, 415);
            // 
            // autoLabel13
            // 
            autoLabel13.Location = new Point(100, 576);
            autoLabel13.Name = "autoLabel13";
            autoLabel13.Size = new Size(58, 15);
            autoLabel13.TabIndex = 37;
            autoLabel13.Text = "Start Date";
            // 
            // txtEndDate
            // 
            txtEndDate.BorderColor = Color.Empty;
            // 
            // 
            // 
            txtEndDate.Calendar.AllowMultipleSelection = false;
            txtEndDate.Calendar.BottomHeight = 25;
            txtEndDate.Calendar.DayNamesFont = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtEndDate.Calendar.DaysFont = new Font("Segoe UI", 9F);
            txtEndDate.Calendar.Dock = DockStyle.Fill;
            txtEndDate.Calendar.Font = new Font("Segoe UI", 9F);
            txtEndDate.Calendar.ForeColor = SystemColors.ControlText;
            txtEndDate.Calendar.HeaderFont = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtEndDate.Calendar.Location = new Point(0, 0);
            txtEndDate.Calendar.MetroColor = Color.FromArgb(22, 165, 220);
            txtEndDate.Calendar.Name = "monthCalendar";
            txtEndDate.Calendar.Size = new Size(187, 174);
            txtEndDate.Calendar.SizeToFit = true;
            txtEndDate.Calendar.TabIndex = 0;
            // 
            // 
            // 
            txtEndDate.Calendar.NoneButton.AutoSize = true;
            txtEndDate.Calendar.NoneButton.Location = new Point(115, 0);
            txtEndDate.Calendar.NoneButton.Text = "None";
            // 
            // 
            // 
            txtEndDate.Calendar.TodayButton.AutoSize = true;
            txtEndDate.Calendar.TodayButton.Location = new Point(0, 0);
            txtEndDate.Calendar.TodayButton.Text = "Today";
            txtEndDate.CalendarForeColor = SystemColors.ControlText;
            txtEndDate.CalendarSize = new Size(189, 176);
            txtEndDate.DropDownImage = null;
            txtEndDate.Font = new Font("Segoe UI", 9F);
            txtEndDate.Location = new Point(181, 600);
            txtEndDate.MetroColor = Color.FromArgb(22, 165, 220);
            txtEndDate.MinValue = new DateTime(0L);
            txtEndDate.Name = "txtEndDate";
            txtEndDate.Size = new Size(206, 20);
            txtEndDate.TabIndex = 40;
            txtEndDate.Value = new DateTime(2025, 4, 10, 22, 35, 0, 415);
            // 
            // autoLabel14
            // 
            autoLabel14.Location = new Point(100, 605);
            autoLabel14.Name = "autoLabel14";
            autoLabel14.Size = new Size(54, 15);
            autoLabel14.TabIndex = 39;
            autoLabel14.Text = "End Date";
            // 
            // txtIsActive
            // 
            txtIsActive.AccessibilityEnabled = true;
            txtIsActive.BeforeTouchSize = new Size(113, 26);
            txtIsActive.Border3DStyle = Border3DStyle.RaisedOuter;
            txtIsActive.Location = new Point(179, 626);
            txtIsActive.Name = "txtIsActive";
            txtIsActive.Size = new Size(113, 26);
            txtIsActive.TabIndex = 41;
            txtIsActive.Text = "Is Active?";
            // 
            // autoLabel15
            // 
            autoLabel15.Location = new Point(100, 553);
            autoLabel15.Name = "autoLabel15";
            autoLabel15.Size = new Size(119, 15);
            autoLabel15.TabIndex = 42;
            autoLabel15.Text = "Contract Information";
            // 
            // UpsertEmployeeView
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 729);
            Controls.Add(autoLabel15);
            Controls.Add(txtIsActive);
            Controls.Add(txtEndDate);
            Controls.Add(autoLabel14);
            Controls.Add(txtStartDate);
            Controls.Add(autoLabel13);
            Controls.Add(autoLabel1);
            Controls.Add(autoLabel12);
            Controls.Add(txtLeaveCredits);
            Controls.Add(txtIsDeducted);
            Controls.Add(txtShift);
            Controls.Add(autoLabel3);
            Controls.Add(autoLabel6);
            Controls.Add(txtJobPosition);
            Controls.Add(txtDepartment);
            Controls.Add(autoLabel5);
            Controls.Add(txtBasicSalary);
            Controls.Add(txtEmail);
            Controls.Add(autoLabel11);
            Controls.Add(txtContactNumber);
            Controls.Add(autoLabel10);
            Controls.Add(autoLabel9);
            Controls.Add(txtGender);
            Controls.Add(txtLastName);
            Controls.Add(autoLabel8);
            Controls.Add(txtFirstName);
            Controls.Add(autoLabel7);
            Controls.Add(txtBirthDate);
            Controls.Add(autoLabel4);
            Controls.Add(btnSave);
            Controls.Add(txtAddress);
            Controls.Add(autoLabel2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "UpsertEmployeeView";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Style.MdiChild.IconHorizontalAlignment = HorizontalAlignment.Center;
            Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            Text = "Add Employee";
            ((System.ComponentModel.ISupportInitialize)txtAddress).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtBirthDate.Calendar).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtBirthDate).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtFirstName).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtLastName).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtGender).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtContactNumber).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtEmail).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtLeaveCredits).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtIsDeducted).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtShift).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtJobPosition).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtDepartment).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtBasicSalary).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtStartDate.Calendar).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtStartDate).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtEndDate.Calendar).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtEndDate).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtIsActive).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtAddress;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private Syncfusion.WinForms.Controls.SfButton btnSave;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel4;
        private Syncfusion.Windows.Forms.Tools.DateTimePickerAdv txtBirthDate;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtFirstName;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel7;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtLastName;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel8;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel9;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv txtGender;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtContactNumber;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel10;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtEmail;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel11;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel12;
        private Syncfusion.Windows.Forms.Tools.DoubleTextBox txtLeaveCredits;
        private Syncfusion.Windows.Forms.Tools.CheckBoxAdv txtIsDeducted;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv txtShift;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel3;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel6;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv txtJobPosition;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv txtDepartment;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel5;
        private Syncfusion.Windows.Forms.Tools.DoubleTextBox txtBasicSalary;
        private Syncfusion.Windows.Forms.Tools.DateTimePickerAdv txtStartDate;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel13;
        private Syncfusion.Windows.Forms.Tools.DateTimePickerAdv txtEndDate;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel14;
        private Syncfusion.Windows.Forms.Tools.CheckBoxAdv txtIsActive;
        private Syncfusion.Windows.Forms.Tools.XPMenus.PopupMenu popupMenu1;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel15;
    }
}