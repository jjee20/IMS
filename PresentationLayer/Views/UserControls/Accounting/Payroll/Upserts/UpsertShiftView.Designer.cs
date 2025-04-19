namespace RavenTech_ERP.Views.UserControls.Inventory
{
    partial class UpsertShiftView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpsertShiftView));
            autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            btnSave = new Syncfusion.WinForms.Controls.SfButton();
            txtName = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel3 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtStartTime = new Syncfusion.Windows.Forms.Tools.DateTimePickerAdv();
            txtEndTime = new Syncfusion.Windows.Forms.Tools.DateTimePickerAdv();
            autoLabel4 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtRegularHours = new Syncfusion.Windows.Forms.Tools.DoubleTextBox();
            ((System.ComponentModel.ISupportInitialize)txtName).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtStartTime).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtStartTime.Calendar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtEndTime).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtEndTime.Calendar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtRegularHours).BeginInit();
            SuspendLayout();
            // 
            // autoLabel2
            // 
            autoLabel2.Location = new Point(90, 177);
            autoLabel2.Name = "autoLabel2";
            autoLabel2.Size = new Size(82, 15);
            autoLabel2.TabIndex = 2;
            autoLabel2.Text = "Regular Hours";
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI Semibold", 9F);
            btnSave.Location = new Point(194, 245);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(96, 28);
            btnSave.TabIndex = 4;
            btnSave.Text = "Save";
            btnSave.Click += btnSave_Click;
            // 
            // txtName
            // 
            txtName.BeforeTouchSize = new Size(205, 23);
            txtName.Location = new Point(189, 68);
            txtName.Name = "txtName";
            txtName.Size = new Size(206, 23);
            txtName.TabIndex = 6;
            // 
            // autoLabel1
            // 
            autoLabel1.Location = new Point(90, 72);
            autoLabel1.Name = "autoLabel1";
            autoLabel1.Size = new Size(39, 15);
            autoLabel1.TabIndex = 5;
            autoLabel1.Text = "Name";
            // 
            // autoLabel3
            // 
            autoLabel3.Location = new Point(89, 112);
            autoLabel3.Name = "autoLabel3";
            autoLabel3.Size = new Size(60, 15);
            autoLabel3.TabIndex = 7;
            autoLabel3.Text = "Start Time";
            // 
            // txtStartTime
            // 
            txtStartTime.BorderColor = Color.Empty;
            // 
            // 
            // 
            txtStartTime.Calendar.AllowMultipleSelection = false;
            txtStartTime.Calendar.BottomHeight = 25;
            txtStartTime.Calendar.DayNamesFont = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtStartTime.Calendar.DaysFont = new Font("Segoe UI", 9F);
            txtStartTime.Calendar.Dock = DockStyle.Fill;
            txtStartTime.Calendar.Font = new Font("Segoe UI", 9F);
            txtStartTime.Calendar.ForeColor = SystemColors.ControlText;
            txtStartTime.Calendar.HeaderFont = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtStartTime.Calendar.Location = new Point(0, 0);
            txtStartTime.Calendar.MetroColor = Color.FromArgb(22, 165, 220);
            txtStartTime.Calendar.Name = "monthCalendar";
            txtStartTime.Calendar.Size = new Size(187, 174);
            txtStartTime.Calendar.SizeToFit = true;
            txtStartTime.Calendar.TabIndex = 0;
            // 
            // 
            // 
            txtStartTime.Calendar.NoneButton.AutoSize = true;
            txtStartTime.Calendar.NoneButton.Location = new Point(115, 0);
            txtStartTime.Calendar.NoneButton.Text = "None";
            // 
            // 
            // 
            txtStartTime.Calendar.TodayButton.AutoSize = true;
            txtStartTime.Calendar.TodayButton.Location = new Point(0, 0);
            txtStartTime.Calendar.TodayButton.Text = "Today";
            txtStartTime.CalendarForeColor = SystemColors.ControlText;
            txtStartTime.CalendarSize = new Size(189, 176);
            txtStartTime.CustomFormat = "hh:mm tt";
            txtStartTime.DropDownImage = null;
            txtStartTime.Font = new Font("Segoe UI", 9F);
            txtStartTime.Format = DateTimePickerFormat.Custom;
            txtStartTime.Location = new Point(189, 109);
            txtStartTime.MetroColor = Color.FromArgb(22, 165, 220);
            txtStartTime.MinValue = new DateTime(0L);
            txtStartTime.Name = "txtStartTime";
            txtStartTime.Size = new Size(206, 20);
            txtStartTime.TabIndex = 8;
            txtStartTime.Value = new DateTime(2025, 4, 15, 8, 0, 0, 0);
            // 
            // txtEndTime
            // 
            txtEndTime.BorderColor = Color.Empty;
            // 
            // 
            // 
            txtEndTime.Calendar.AllowMultipleSelection = false;
            txtEndTime.Calendar.BottomHeight = 25;
            txtEndTime.Calendar.DayNamesFont = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtEndTime.Calendar.DaysFont = new Font("Segoe UI", 9F);
            txtEndTime.Calendar.Dock = DockStyle.Fill;
            txtEndTime.Calendar.Font = new Font("Segoe UI", 9F);
            txtEndTime.Calendar.ForeColor = SystemColors.ControlText;
            txtEndTime.Calendar.HeaderFont = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtEndTime.Calendar.Location = new Point(0, 0);
            txtEndTime.Calendar.MetroColor = Color.FromArgb(22, 165, 220);
            txtEndTime.Calendar.Name = "monthCalendar";
            txtEndTime.Calendar.Size = new Size(187, 174);
            txtEndTime.Calendar.SizeToFit = true;
            txtEndTime.Calendar.TabIndex = 0;
            // 
            // 
            // 
            txtEndTime.Calendar.NoneButton.AutoSize = true;
            txtEndTime.Calendar.NoneButton.Location = new Point(115, 0);
            txtEndTime.Calendar.NoneButton.Text = "None";
            // 
            // 
            // 
            txtEndTime.Calendar.TodayButton.AutoSize = true;
            txtEndTime.Calendar.TodayButton.Location = new Point(0, 0);
            txtEndTime.Calendar.TodayButton.Text = "Today";
            txtEndTime.CalendarForeColor = SystemColors.ControlText;
            txtEndTime.CalendarSize = new Size(189, 176);
            txtEndTime.CustomFormat = "hh:mm tt";
            txtEndTime.DropDownImage = null;
            txtEndTime.Font = new Font("Segoe UI", 9F);
            txtEndTime.Format = DateTimePickerFormat.Custom;
            txtEndTime.Location = new Point(189, 140);
            txtEndTime.MetroColor = Color.FromArgb(22, 165, 220);
            txtEndTime.MinValue = new DateTime(0L);
            txtEndTime.Name = "txtEndTime";
            txtEndTime.Size = new Size(206, 20);
            txtEndTime.TabIndex = 10;
            txtEndTime.Value = new DateTime(2025, 4, 15, 17, 0, 0, 0);
            // 
            // autoLabel4
            // 
            autoLabel4.Location = new Point(90, 143);
            autoLabel4.Name = "autoLabel4";
            autoLabel4.Size = new Size(56, 15);
            autoLabel4.TabIndex = 9;
            autoLabel4.Text = "End Time";
            // 
            // txtRegularHours
            // 
            txtRegularHours.AccessibilityEnabled = true;
            txtRegularHours.BeforeTouchSize = new Size(205, 23);
            txtRegularHours.DoubleValue = 8D;
            txtRegularHours.Location = new Point(190, 173);
            txtRegularHours.Name = "txtRegularHours";
            txtRegularHours.NumberDecimalDigits = 1;
            txtRegularHours.Size = new Size(205, 23);
            txtRegularHours.TabIndex = 11;
            txtRegularHours.Text = "8.0";
            // 
            // UpsertShiftView
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 341);
            Controls.Add(txtRegularHours);
            Controls.Add(txtEndTime);
            Controls.Add(autoLabel4);
            Controls.Add(txtStartTime);
            Controls.Add(autoLabel3);
            Controls.Add(txtName);
            Controls.Add(autoLabel1);
            Controls.Add(btnSave);
            Controls.Add(autoLabel2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "UpsertShiftView";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Style.MdiChild.IconHorizontalAlignment = HorizontalAlignment.Center;
            Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            Text = "Add Shift";
            ((System.ComponentModel.ISupportInitialize)txtName).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtStartTime.Calendar).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtStartTime).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtEndTime.Calendar).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtEndTime).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtRegularHours).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private Syncfusion.WinForms.Controls.SfButton btnSave;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtName;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel3;
        private Syncfusion.Windows.Forms.Tools.DateTimePickerAdv txtStartTime;
        private Syncfusion.Windows.Forms.Tools.DateTimePickerAdv txtEndTime;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel4;
        private Syncfusion.Windows.Forms.Tools.DoubleTextBox txtRegularHours;
    }
}