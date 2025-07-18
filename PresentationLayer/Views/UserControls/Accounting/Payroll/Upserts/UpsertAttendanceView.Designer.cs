﻿namespace RavenTech_ERP.Views.UserControls.Accounting.Payroll.Upserts
{
    partial class UpsertAttendanceView
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
            autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtEmployee = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            txtDate = new Syncfusion.Windows.Forms.Tools.DateTimePickerAdv();
            txtTimein = new Syncfusion.Windows.Forms.Tools.DateTimePickerAdv();
            txtTimeout = new Syncfusion.Windows.Forms.Tools.DateTimePickerAdv();
            txtIsPresent = new Syncfusion.Windows.Forms.Tools.CheckBoxAdv();
            txtIsHalfDay = new Syncfusion.Windows.Forms.Tools.CheckBoxAdv();
            txtProject = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel3 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel4 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel5 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel6 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            btnSave = new Syncfusion.WinForms.Controls.SfButton();
            txtHoursWorked = new Syncfusion.Windows.Forms.Tools.DoubleTextBox();
            ((System.ComponentModel.ISupportInitialize)txtEmployee).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtDate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtDate.Calendar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtTimein).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtTimein.Calendar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtTimeout).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtTimeout.Calendar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtIsPresent).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtIsHalfDay).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtProject).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtHoursWorked).BeginInit();
            SuspendLayout();
            // 
            // autoLabel1
            // 
            autoLabel1.Location = new Point(174, 103);
            autoLabel1.Margin = new Padding(4, 0, 4, 0);
            autoLabel1.Name = "autoLabel1";
            autoLabel1.Size = new Size(90, 25);
            autoLabel1.TabIndex = 0;
            autoLabel1.Text = "Employee";
            // 
            // txtEmployee
            // 
            txtEmployee.Height = 33;
            txtEmployee.Location = new Point(304, 97);
            txtEmployee.Margin = new Padding(4, 5, 4, 5);
            txtEmployee.Name = "txtEmployee";
            txtEmployee.Size = new Size(330, 33);
            txtEmployee.TabIndex = 2;
            txtEmployee.Text = "~Select~";
            txtEmployee.TextBoxHeight = 23;
            // 
            // txtDate
            // 
            txtDate.BorderColor = Color.Empty;
            // 
            // 
            // 
            txtDate.Calendar.AllowMultipleSelection = false;
            txtDate.Calendar.BottomHeight = 35;
            txtDate.Calendar.DayNamesFont = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtDate.Calendar.DaysFont = new Font("Segoe UI", 9F);
            txtDate.Calendar.Dock = DockStyle.Fill;
            txtDate.Calendar.Font = new Font("Segoe UI", 9F);
            txtDate.Calendar.ForeColor = SystemColors.ControlText;
            txtDate.Calendar.HeaderFont = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtDate.Calendar.Location = new Point(0, 0);
            txtDate.Calendar.MetroColor = Color.FromArgb(22, 165, 220);
            txtDate.Calendar.Name = "monthCalendar";
            txtDate.Calendar.Size = new Size(187, 174);
            txtDate.Calendar.SizeToFit = true;
            txtDate.Calendar.TabIndex = 0;
            // 
            // 
            // 
            txtDate.Calendar.NoneButton.AutoSize = true;
            txtDate.Calendar.NoneButton.Location = new Point(115, 0);
            txtDate.Calendar.NoneButton.Text = "None";
            // 
            // 
            // 
            txtDate.Calendar.TodayButton.AutoSize = true;
            txtDate.Calendar.TodayButton.Location = new Point(0, 0);
            txtDate.Calendar.TodayButton.Text = "Today";
            txtDate.CalendarForeColor = SystemColors.ControlText;
            txtDate.CalendarSize = new Size(189, 176);
            txtDate.DropDownImage = null;
            txtDate.Font = new Font("Segoe UI", 9F);
            txtDate.Location = new Point(304, 175);
            txtDate.Margin = new Padding(4, 5, 4, 5);
            txtDate.MetroColor = Color.FromArgb(22, 165, 220);
            txtDate.MinValue = new DateTime(0L);
            txtDate.Name = "txtDate";
            txtDate.Size = new Size(330, 31);
            txtDate.TabIndex = 3;
            txtDate.Value = new DateTime(2025, 4, 11, 11, 46, 39, 652);
            // 
            // txtTimein
            // 
            txtTimein.BorderColor = Color.Empty;
            // 
            // 
            // 
            txtTimein.Calendar.AllowMultipleSelection = false;
            txtTimein.Calendar.BottomHeight = 35;
            txtTimein.Calendar.DayNamesFont = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtTimein.Calendar.DaysFont = new Font("Segoe UI", 9F);
            txtTimein.Calendar.Dock = DockStyle.Fill;
            txtTimein.Calendar.Font = new Font("Segoe UI", 9F);
            txtTimein.Calendar.ForeColor = SystemColors.ControlText;
            txtTimein.Calendar.HeaderFont = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtTimein.Calendar.Location = new Point(0, 0);
            txtTimein.Calendar.MetroColor = Color.FromArgb(22, 165, 220);
            txtTimein.Calendar.Name = "monthCalendar";
            txtTimein.Calendar.Size = new Size(187, 174);
            txtTimein.Calendar.SizeToFit = true;
            txtTimein.Calendar.TabIndex = 0;
            // 
            // 
            // 
            txtTimein.Calendar.NoneButton.AutoSize = true;
            txtTimein.Calendar.NoneButton.Location = new Point(115, 0);
            txtTimein.Calendar.NoneButton.Text = "None";
            // 
            // 
            // 
            txtTimein.Calendar.TodayButton.AutoSize = true;
            txtTimein.Calendar.TodayButton.Location = new Point(0, 0);
            txtTimein.Calendar.TodayButton.Text = "Today";
            txtTimein.CalendarForeColor = SystemColors.ControlText;
            txtTimein.CalendarSize = new Size(189, 176);
            txtTimein.CustomFormat = "HH:mm tt";
            txtTimein.DropDownImage = null;
            txtTimein.Font = new Font("Segoe UI", 9F);
            txtTimein.Format = DateTimePickerFormat.Custom;
            txtTimein.Location = new Point(304, 248);
            txtTimein.Margin = new Padding(4, 5, 4, 5);
            txtTimein.MetroColor = Color.FromArgb(22, 165, 220);
            txtTimein.MinValue = new DateTime(0L);
            txtTimein.Name = "txtTimein";
            txtTimein.Size = new Size(330, 31);
            txtTimein.TabIndex = 4;
            txtTimein.Value = new DateTime(2025, 4, 11, 8, 0, 0, 0);
            // 
            // txtTimeout
            // 
            txtTimeout.BorderColor = Color.Empty;
            // 
            // 
            // 
            txtTimeout.Calendar.AllowMultipleSelection = false;
            txtTimeout.Calendar.BottomHeight = 35;
            txtTimeout.Calendar.DayNamesFont = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtTimeout.Calendar.DaysFont = new Font("Segoe UI", 9F);
            txtTimeout.Calendar.Dock = DockStyle.Fill;
            txtTimeout.Calendar.Font = new Font("Segoe UI", 9F);
            txtTimeout.Calendar.ForeColor = SystemColors.ControlText;
            txtTimeout.Calendar.HeaderFont = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtTimeout.Calendar.Location = new Point(0, 0);
            txtTimeout.Calendar.MetroColor = Color.FromArgb(22, 165, 220);
            txtTimeout.Calendar.Name = "monthCalendar";
            txtTimeout.Calendar.Size = new Size(187, 174);
            txtTimeout.Calendar.SizeToFit = true;
            txtTimeout.Calendar.TabIndex = 0;
            // 
            // 
            // 
            txtTimeout.Calendar.NoneButton.AutoSize = true;
            txtTimeout.Calendar.NoneButton.Location = new Point(115, 0);
            txtTimeout.Calendar.NoneButton.Text = "None";
            // 
            // 
            // 
            txtTimeout.Calendar.TodayButton.AutoSize = true;
            txtTimeout.Calendar.TodayButton.Location = new Point(0, 0);
            txtTimeout.Calendar.TodayButton.Text = "Today";
            txtTimeout.CalendarForeColor = SystemColors.ControlText;
            txtTimeout.CalendarSize = new Size(189, 176);
            txtTimeout.CustomFormat = "hh:mm tt";
            txtTimeout.DropDownImage = null;
            txtTimeout.Font = new Font("Segoe UI", 9F);
            txtTimeout.Format = DateTimePickerFormat.Custom;
            txtTimeout.Location = new Point(304, 322);
            txtTimeout.Margin = new Padding(4, 5, 4, 5);
            txtTimeout.MetroColor = Color.FromArgb(22, 165, 220);
            txtTimeout.MinValue = new DateTime(0L);
            txtTimeout.Name = "txtTimeout";
            txtTimeout.Size = new Size(330, 31);
            txtTimeout.TabIndex = 5;
            txtTimeout.Value = new DateTime(2025, 4, 11, 17, 0, 0, 0);
            // 
            // txtIsPresent
            // 
            txtIsPresent.AccessibilityEnabled = true;
            txtIsPresent.BeforeTouchSize = new Size(214, 35);
            txtIsPresent.ImageCheckBoxSize = new Size(19, 19);
            txtIsPresent.Location = new Point(304, 535);
            txtIsPresent.Margin = new Padding(4, 5, 4, 5);
            txtIsPresent.Name = "txtIsPresent";
            txtIsPresent.Size = new Size(214, 35);
            txtIsPresent.TabIndex = 6;
            txtIsPresent.Text = "Is Present?";
            // 
            // txtIsHalfDay
            // 
            txtIsHalfDay.AccessibilityEnabled = true;
            txtIsHalfDay.BeforeTouchSize = new Size(214, 35);
            txtIsHalfDay.ImageCheckBoxSize = new Size(19, 19);
            txtIsHalfDay.Location = new Point(421, 535);
            txtIsHalfDay.Margin = new Padding(4, 5, 4, 5);
            txtIsHalfDay.Name = "txtIsHalfDay";
            txtIsHalfDay.Size = new Size(214, 35);
            txtIsHalfDay.TabIndex = 7;
            txtIsHalfDay.Text = "Is Halfday?";
            // 
            // txtProject
            // 
            txtProject.Height = 33;
            txtProject.Location = new Point(304, 473);
            txtProject.Margin = new Padding(4, 5, 4, 5);
            txtProject.Name = "txtProject";
            txtProject.Size = new Size(330, 33);
            txtProject.TabIndex = 8;
            txtProject.Text = "~Select~";
            txtProject.TextBoxHeight = 23;
            // 
            // autoLabel2
            // 
            autoLabel2.Location = new Point(174, 178);
            autoLabel2.Margin = new Padding(4, 0, 4, 0);
            autoLabel2.Name = "autoLabel2";
            autoLabel2.Size = new Size(49, 25);
            autoLabel2.TabIndex = 9;
            autoLabel2.Text = "Date";
            // 
            // autoLabel3
            // 
            autoLabel3.Location = new Point(174, 253);
            autoLabel3.Margin = new Padding(4, 0, 4, 0);
            autoLabel3.Name = "autoLabel3";
            autoLabel3.Size = new Size(64, 25);
            autoLabel3.TabIndex = 10;
            autoLabel3.Text = "Timein";
            // 
            // autoLabel4
            // 
            autoLabel4.Location = new Point(174, 328);
            autoLabel4.Margin = new Padding(4, 0, 4, 0);
            autoLabel4.Name = "autoLabel4";
            autoLabel4.Size = new Size(77, 25);
            autoLabel4.TabIndex = 11;
            autoLabel4.Text = "Timeout";
            // 
            // autoLabel5
            // 
            autoLabel5.Location = new Point(174, 403);
            autoLabel5.Margin = new Padding(4, 0, 4, 0);
            autoLabel5.Name = "autoLabel5";
            autoLabel5.Size = new Size(127, 25);
            autoLabel5.TabIndex = 12;
            autoLabel5.Text = "Hours Worked";
            // 
            // autoLabel6
            // 
            autoLabel6.Location = new Point(174, 478);
            autoLabel6.Margin = new Padding(4, 0, 4, 0);
            autoLabel6.Name = "autoLabel6";
            autoLabel6.Size = new Size(66, 25);
            autoLabel6.TabIndex = 13;
            autoLabel6.Text = "Project";
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI Semibold", 9F);
            btnSave.Location = new Point(336, 607);
            btnSave.Margin = new Padding(4, 5, 4, 5);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(137, 47);
            btnSave.TabIndex = 14;
            btnSave.Text = "Save";
            btnSave.Click += btnSave_Click;
            // 
            // txtHoursWorked
            // 
            txtHoursWorked.AccessibilityEnabled = true;
            txtHoursWorked.BeforeTouchSize = new Size(330, 31);
            txtHoursWorked.DoubleValue = 8D;
            txtHoursWorked.Location = new Point(304, 403);
            txtHoursWorked.Name = "txtHoursWorked";
            txtHoursWorked.Size = new Size(330, 31);
            txtHoursWorked.TabIndex = 15;
            txtHoursWorked.Text = "8.00";
            // 
            // UpsertAttendanceView
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(807, 739);
            Controls.Add(txtHoursWorked);
            Controls.Add(btnSave);
            Controls.Add(autoLabel6);
            Controls.Add(autoLabel5);
            Controls.Add(autoLabel4);
            Controls.Add(autoLabel3);
            Controls.Add(autoLabel2);
            Controls.Add(txtProject);
            Controls.Add(txtIsHalfDay);
            Controls.Add(txtIsPresent);
            Controls.Add(txtTimeout);
            Controls.Add(txtTimein);
            Controls.Add(txtDate);
            Controls.Add(txtEmployee);
            Controls.Add(autoLabel1);
            Margin = new Padding(4, 5, 4, 5);
            Name = "UpsertAttendanceView";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Style.MdiChild.IconHorizontalAlignment = HorizontalAlignment.Center;
            Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            Text = "Add Attendance";
            Load += UpsertAttendanceView_Load;
            ((System.ComponentModel.ISupportInitialize)txtEmployee).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtDate.Calendar).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtDate).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtTimein.Calendar).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtTimein).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtTimeout.Calendar).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtTimeout).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtIsPresent).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtIsHalfDay).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtProject).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtHoursWorked).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv txtEmployee;
        private Syncfusion.Windows.Forms.Tools.DateTimePickerAdv txtDate;
        private Syncfusion.Windows.Forms.Tools.DateTimePickerAdv txtTimein;
        private Syncfusion.Windows.Forms.Tools.DateTimePickerAdv txtTimeout;
        private Syncfusion.Windows.Forms.Tools.CheckBoxAdv txtIsPresent;
        private Syncfusion.Windows.Forms.Tools.CheckBoxAdv txtIsHalfDay;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv txtProject;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel3;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel4;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel5;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel6;
        private Syncfusion.WinForms.Controls.SfButton btnSave;
        private Syncfusion.Windows.Forms.Tools.DoubleTextBox txtHoursWorked;
    }
}