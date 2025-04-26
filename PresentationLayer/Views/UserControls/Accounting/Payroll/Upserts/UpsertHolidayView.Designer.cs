namespace RavenTech_ERP.Views.UserControls.Inventory
{
    partial class UpsertHolidayView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpsertHolidayView));
            autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtName = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            txtDescription = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            btnSave = new Syncfusion.WinForms.Controls.SfButton();
            autoLabel3 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel4 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtHolidayType = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            txtDate = new Syncfusion.Windows.Forms.Tools.DateTimePickerAdv();
            ((System.ComponentModel.ISupportInitialize)txtName).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtDescription).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtHolidayType).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtDate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtDate.Calendar).BeginInit();
            SuspendLayout();
            // 
            // autoLabel1
            // 
            autoLabel1.Location = new Point(98, 78);
            autoLabel1.Name = "autoLabel1";
            autoLabel1.Size = new Size(39, 15);
            autoLabel1.TabIndex = 0;
            autoLabel1.Text = "Name";
            // 
            // txtName
            // 
            txtName.BeforeTouchSize = new Size(100, 23);
            txtName.Location = new Point(180, 72);
            txtName.Name = "txtName";
            txtName.Size = new Size(206, 23);
            txtName.TabIndex = 1;
            // 
            // txtDescription
            // 
            txtDescription.BeforeTouchSize = new Size(100, 23);
            txtDescription.Location = new Point(180, 183);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(206, 23);
            txtDescription.TabIndex = 3;
            // 
            // autoLabel2
            // 
            autoLabel2.Location = new Point(98, 186);
            autoLabel2.Name = "autoLabel2";
            autoLabel2.Size = new Size(67, 15);
            autoLabel2.TabIndex = 2;
            autoLabel2.Text = "Description";
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI Semibold", 9F);
            btnSave.Location = new Point(194, 240);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(96, 28);
            btnSave.TabIndex = 4;
            btnSave.Text = "Save";
            btnSave.Click += btnSave_Click;
            // 
            // autoLabel3
            // 
            autoLabel3.Location = new Point(98, 113);
            autoLabel3.Name = "autoLabel3";
            autoLabel3.Size = new Size(31, 15);
            autoLabel3.TabIndex = 5;
            autoLabel3.Text = "Type";
            // 
            // autoLabel4
            // 
            autoLabel4.Location = new Point(98, 148);
            autoLabel4.Name = "autoLabel4";
            autoLabel4.Size = new Size(31, 15);
            autoLabel4.TabIndex = 6;
            autoLabel4.Text = "Date";
            // 
            // txtHolidayType
            // 
            txtHolidayType.BackColor = Color.FromArgb(255, 255, 255);
            txtHolidayType.ForeColor = Color.FromArgb(68, 68, 68);
            txtHolidayType.Height = 23;
            txtHolidayType.Location = new Point(180, 110);
            txtHolidayType.Name = "txtHolidayType";
            txtHolidayType.Size = new Size(206, 23);
            txtHolidayType.TabIndex = 7;
            txtHolidayType.Text = "~Select~";
            txtHolidayType.TextBoxHeight = 23;
            txtHolidayType.ThemeName = "Office2016Colorful";
            // 
            // txtDate
            // 
            txtDate.BorderColor = Color.Empty;
            // 
            // 
            // 
            txtDate.Calendar.AllowMultipleSelection = false;
            txtDate.Calendar.BottomHeight = 25;
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
            txtDate.Location = new Point(180, 148);
            txtDate.MetroColor = Color.FromArgb(22, 165, 220);
            txtDate.MinValue = new DateTime(0L);
            txtDate.Name = "txtDate";
            txtDate.Size = new Size(206, 20);
            txtDate.TabIndex = 8;
            txtDate.Value = new DateTime(2025, 4, 10, 22, 35, 0, 415);
            // 
            // UpsertHolidayView
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 341);
            Controls.Add(txtDate);
            Controls.Add(txtHolidayType);
            Controls.Add(autoLabel4);
            Controls.Add(autoLabel3);
            Controls.Add(btnSave);
            Controls.Add(txtDescription);
            Controls.Add(autoLabel2);
            Controls.Add(txtName);
            Controls.Add(autoLabel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "UpsertHolidayView";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Style.MdiChild.IconHorizontalAlignment = HorizontalAlignment.Center;
            Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            Text = "Add Holiday";
            ((System.ComponentModel.ISupportInitialize)txtName).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtDescription).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtHolidayType).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtDate.Calendar).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtDate).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtName;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtDescription;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private Syncfusion.WinForms.Controls.SfButton btnSave;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel3;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel4;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv txtHolidayType;
        private Syncfusion.Windows.Forms.Tools.DateTimePickerAdv txtDate;
    }
}