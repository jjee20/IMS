namespace RavenTech_ERP.Views.UserControls.Inventory
{
    partial class UpsertLeaveView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpsertLeaveView));
            autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtOther = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            btnSave = new Syncfusion.WinForms.Controls.SfButton();
            autoLabel3 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel4 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtLeaveType = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            txtStartDate = new Syncfusion.Windows.Forms.Tools.DateTimePickerAdv();
            txtEmployee = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            autoLabel5 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtNotes = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            txtStatus = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            autoLabel6 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtEndDate = new Syncfusion.Windows.Forms.Tools.DateTimePickerAdv();
            autoLabel7 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            ((System.ComponentModel.ISupportInitialize)txtOther).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtLeaveType).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtStartDate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtStartDate.Calendar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtEmployee).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtNotes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtStatus).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtEndDate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtEndDate.Calendar).BeginInit();
            SuspendLayout();
            // 
            // autoLabel1
            // 
            autoLabel1.Location = new Point(99, 56);
            autoLabel1.Name = "autoLabel1";
            autoLabel1.Size = new Size(59, 15);
            autoLabel1.TabIndex = 0;
            autoLabel1.Text = "Employee";
            // 
            // txtOther
            // 
            txtOther.BeforeTouchSize = new Size(100, 23);
            txtOther.Location = new Point(181, 216);
            txtOther.Name = "txtOther";
            txtOther.Size = new Size(206, 23);
            txtOther.TabIndex = 3;
            // 
            // autoLabel2
            // 
            autoLabel2.Location = new Point(99, 225);
            autoLabel2.Name = "autoLabel2";
            autoLabel2.Size = new Size(42, 15);
            autoLabel2.TabIndex = 2;
            autoLabel2.Text = "Others";
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI Semibold", 9F);
            btnSave.Location = new Point(194, 313);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(96, 28);
            btnSave.TabIndex = 4;
            btnSave.Text = "Save";
            btnSave.Click += btnSave_Click;
            // 
            // autoLabel3
            // 
            autoLabel3.Location = new Point(99, 91);
            autoLabel3.Name = "autoLabel3";
            autoLabel3.Size = new Size(31, 15);
            autoLabel3.TabIndex = 5;
            autoLabel3.Text = "Type";
            // 
            // autoLabel4
            // 
            autoLabel4.Location = new Point(99, 130);
            autoLabel4.Name = "autoLabel4";
            autoLabel4.Size = new Size(58, 15);
            autoLabel4.TabIndex = 6;
            autoLabel4.Text = "Start Date";
            // 
            // txtLeaveType
            // 
            txtLeaveType.BackColor = Color.FromArgb(255, 255, 255);
            txtLeaveType.ForeColor = Color.FromArgb(68, 68, 68);
            txtLeaveType.Height = 31;
            txtLeaveType.Location = new Point(181, 88);
            txtLeaveType.Name = "txtLeaveType";
            txtLeaveType.Size = new Size(206, 31);
            txtLeaveType.TabIndex = 7;
            txtLeaveType.Text = "~Select~";
            txtLeaveType.TextBoxHeight = 23;
            txtLeaveType.ThemeName = "Office2016Colorful";
            // 
            // txtStartDate
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
            txtStartDate.Location = new Point(181, 126);
            txtStartDate.MetroColor = Color.FromArgb(22, 165, 220);
            txtStartDate.MinValue = new DateTime(0L);
            txtStartDate.Name = "txtStartDate";
            txtStartDate.Size = new Size(206, 20);
            txtStartDate.TabIndex = 8;
            txtStartDate.Value = new DateTime(2025, 4, 10, 22, 35, 0, 415);
            // 
            // txtEmployee
            // 
            txtEmployee.BackColor = Color.FromArgb(255, 255, 255);
            txtEmployee.ForeColor = Color.FromArgb(68, 68, 68);
            txtEmployee.Height = 31;
            txtEmployee.Location = new Point(181, 50);
            txtEmployee.Name = "txtEmployee";
            txtEmployee.Size = new Size(206, 31);
            txtEmployee.TabIndex = 9;
            txtEmployee.Text = "~Select~";
            txtEmployee.TextBoxHeight = 23;
            txtEmployee.ThemeName = "Office2016Colorful";
            // 
            // autoLabel5
            // 
            autoLabel5.Location = new Point(99, 190);
            autoLabel5.Name = "autoLabel5";
            autoLabel5.Size = new Size(38, 15);
            autoLabel5.TabIndex = 10;
            autoLabel5.Text = "Notes";
            // 
            // txtNotes
            // 
            txtNotes.BeforeTouchSize = new Size(100, 23);
            txtNotes.Location = new Point(181, 183);
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(206, 23);
            txtNotes.TabIndex = 11;
            // 
            // txtStatus
            // 
            txtStatus.BackColor = Color.FromArgb(255, 255, 255);
            txtStatus.ForeColor = Color.FromArgb(68, 68, 68);
            txtStatus.Height = 31;
            txtStatus.Location = new Point(181, 250);
            txtStatus.Name = "txtStatus";
            txtStatus.Size = new Size(206, 31);
            txtStatus.TabIndex = 13;
            txtStatus.Text = "~Select~";
            txtStatus.TextBoxHeight = 23;
            txtStatus.ThemeName = "Office2016Colorful";
            // 
            // autoLabel6
            // 
            autoLabel6.Location = new Point(99, 257);
            autoLabel6.Name = "autoLabel6";
            autoLabel6.Size = new Size(39, 15);
            autoLabel6.TabIndex = 12;
            autoLabel6.Text = "Status";
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
            txtEndDate.Location = new Point(181, 153);
            txtEndDate.MetroColor = Color.FromArgb(22, 165, 220);
            txtEndDate.MinValue = new DateTime(0L);
            txtEndDate.Name = "txtEndDate";
            txtEndDate.Size = new Size(206, 20);
            txtEndDate.TabIndex = 15;
            txtEndDate.Value = new DateTime(2025, 4, 10, 22, 35, 0, 415);
            // 
            // autoLabel7
            // 
            autoLabel7.Location = new Point(97, 157);
            autoLabel7.Name = "autoLabel7";
            autoLabel7.Size = new Size(54, 15);
            autoLabel7.TabIndex = 14;
            autoLabel7.Text = "End Date";
            // 
            // UpsertLeaveView
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 390);
            Controls.Add(txtEndDate);
            Controls.Add(autoLabel7);
            Controls.Add(txtStatus);
            Controls.Add(autoLabel6);
            Controls.Add(txtNotes);
            Controls.Add(autoLabel5);
            Controls.Add(txtEmployee);
            Controls.Add(txtStartDate);
            Controls.Add(txtLeaveType);
            Controls.Add(autoLabel4);
            Controls.Add(autoLabel3);
            Controls.Add(btnSave);
            Controls.Add(txtOther);
            Controls.Add(autoLabel2);
            Controls.Add(autoLabel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "UpsertLeaveView";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Style.MdiChild.IconHorizontalAlignment = HorizontalAlignment.Center;
            Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            Text = "Add Leave";
            ((System.ComponentModel.ISupportInitialize)txtOther).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtLeaveType).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtStartDate.Calendar).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtStartDate).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtEmployee).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtNotes).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtStatus).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtEndDate.Calendar).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtEndDate).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtOther;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private Syncfusion.WinForms.Controls.SfButton btnSave;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel3;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel4;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv txtLeaveType;
        private Syncfusion.Windows.Forms.Tools.DateTimePickerAdv txtStartDate;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv txtEmployee;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel5;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtNotes;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv txtStatus;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel6;
        private Syncfusion.Windows.Forms.Tools.DateTimePickerAdv txtEndDate;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel7;
    }
}