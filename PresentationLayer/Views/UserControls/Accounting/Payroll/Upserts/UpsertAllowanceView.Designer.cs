namespace RavenTech_ERP.Views.UserControls.Inventory
{
    partial class UpsertAllowanceView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpsertAllowanceView));
            autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtDescription = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            btnSave = new Syncfusion.WinForms.Controls.SfButton();
            autoLabel3 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel4 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtAllowanceType = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            txtStartDate = new Syncfusion.Windows.Forms.Tools.DateTimePickerAdv();
            txtEmployee = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            autoLabel5 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtAmount = new Syncfusion.Windows.Forms.Tools.DoubleTextBox();
            txtEndDate = new Syncfusion.Windows.Forms.Tools.DateTimePickerAdv();
            autoLabel6 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            ((System.ComponentModel.ISupportInitialize)txtDescription).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtAllowanceType).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtStartDate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtStartDate.Calendar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtEmployee).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtAmount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtEndDate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtEndDate.Calendar).BeginInit();
            SuspendLayout();
            // 
            // autoLabel1
            // 
            autoLabel1.Location = new Point(98, 49);
            autoLabel1.Name = "autoLabel1";
            autoLabel1.Size = new Size(59, 15);
            autoLabel1.TabIndex = 0;
            autoLabel1.Text = "Employee";
            // 
            // txtDescription
            // 
            txtDescription.BeforeTouchSize = new Size(100, 23);
            txtDescription.Location = new Point(180, 205);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(206, 23);
            txtDescription.TabIndex = 3;
            // 
            // autoLabel2
            // 
            autoLabel2.Location = new Point(98, 208);
            autoLabel2.Name = "autoLabel2";
            autoLabel2.Size = new Size(67, 15);
            autoLabel2.TabIndex = 2;
            autoLabel2.Text = "Description";
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI Semibold", 9F);
            btnSave.Location = new Point(193, 278);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(96, 28);
            btnSave.TabIndex = 4;
            btnSave.Text = "Save";
            btnSave.Click += btnSave_Click;
            // 
            // autoLabel3
            // 
            autoLabel3.Location = new Point(98, 84);
            autoLabel3.Name = "autoLabel3";
            autoLabel3.Size = new Size(32, 15);
            autoLabel3.TabIndex = 5;
            autoLabel3.Text = "Type";
            // 
            // autoLabel4
            // 
            autoLabel4.Location = new Point(98, 123);
            autoLabel4.Name = "autoLabel4";
            autoLabel4.Size = new Size(58, 15);
            autoLabel4.TabIndex = 6;
            autoLabel4.Text = "Start Date";
            // 
            // txtAllowanceType
            // 
            txtAllowanceType.BackColor = Color.FromArgb(255, 255, 255);
            txtAllowanceType.ForeColor = Color.FromArgb(68, 68, 68);
            txtAllowanceType.Height = 31;
            txtAllowanceType.Location = new Point(180, 81);
            txtAllowanceType.Name = "txtAllowanceType";
            txtAllowanceType.Size = new Size(206, 31);
            txtAllowanceType.TabIndex = 7;
            txtAllowanceType.Text = "~Select~";
            txtAllowanceType.TextBoxHeight = 23;
            txtAllowanceType.ThemeName = "Office2016Colorful";
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
            txtStartDate.Location = new Point(180, 119);
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
            txtEmployee.Location = new Point(180, 43);
            txtEmployee.Name = "txtEmployee";
            txtEmployee.Size = new Size(206, 31);
            txtEmployee.TabIndex = 9;
            txtEmployee.Text = "~Select~";
            txtEmployee.TextBoxHeight = 23;
            txtEmployee.ThemeName = "Office2016Colorful";
            // 
            // autoLabel5
            // 
            autoLabel5.Location = new Point(98, 177);
            autoLabel5.Name = "autoLabel5";
            autoLabel5.Size = new Size(51, 15);
            autoLabel5.TabIndex = 10;
            autoLabel5.Text = "Amount";
            // 
            // txtAmount
            // 
            txtAmount.AccessibilityEnabled = true;
            txtAmount.BeforeTouchSize = new Size(100, 23);
            txtAmount.DoubleValue = 0D;
            txtAmount.Location = new Point(180, 173);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(206, 23);
            txtAmount.TabIndex = 11;
            txtAmount.Text = "0.00";
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
            txtEndDate.Location = new Point(180, 146);
            txtEndDate.MetroColor = Color.FromArgb(22, 165, 220);
            txtEndDate.MinValue = new DateTime(0L);
            txtEndDate.Name = "txtEndDate";
            txtEndDate.Size = new Size(206, 20);
            txtEndDate.TabIndex = 14;
            txtEndDate.Value = new DateTime(2025, 4, 10, 22, 35, 0, 415);
            // 
            // autoLabel6
            // 
            autoLabel6.Location = new Point(98, 150);
            autoLabel6.Name = "autoLabel6";
            autoLabel6.Size = new Size(54, 15);
            autoLabel6.TabIndex = 13;
            autoLabel6.Text = "End Date";
            // 
            // UpsertAllowanceView
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 341);
            Controls.Add(txtEndDate);
            Controls.Add(autoLabel6);
            Controls.Add(txtAmount);
            Controls.Add(autoLabel5);
            Controls.Add(txtEmployee);
            Controls.Add(txtStartDate);
            Controls.Add(txtAllowanceType);
            Controls.Add(autoLabel4);
            Controls.Add(autoLabel3);
            Controls.Add(btnSave);
            Controls.Add(txtDescription);
            Controls.Add(autoLabel2);
            Controls.Add(autoLabel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "UpsertAllowanceView";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Style.MdiChild.IconHorizontalAlignment = HorizontalAlignment.Center;
            Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            Text = "Add Allowance";
            ((System.ComponentModel.ISupportInitialize)txtDescription).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtAllowanceType).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtStartDate.Calendar).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtStartDate).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtEmployee).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtAmount).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtEndDate.Calendar).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtEndDate).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtDescription;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private Syncfusion.WinForms.Controls.SfButton btnSave;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel3;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel4;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv txtAllowanceType;
        private Syncfusion.Windows.Forms.Tools.DateTimePickerAdv txtStartDate;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv txtEmployee;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel5;
        private Syncfusion.Windows.Forms.Tools.DoubleTextBox txtAmount;
        private Syncfusion.Windows.Forms.Tools.DateTimePickerAdv txtEndDate;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel6;
    }
}