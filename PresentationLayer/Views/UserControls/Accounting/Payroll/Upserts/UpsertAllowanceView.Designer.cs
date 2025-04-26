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
            txtDate = new Syncfusion.Windows.Forms.Tools.DateTimePickerAdv();
            txtEmployee = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            autoLabel5 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtAmount = new Syncfusion.Windows.Forms.Tools.DoubleTextBox();
            txtIsRecurring = new Syncfusion.Windows.Forms.Tools.CheckBoxAdv();
            ((System.ComponentModel.ISupportInitialize)txtDescription).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtAllowanceType).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtDate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtDate.Calendar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtEmployee).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtAmount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtIsRecurring).BeginInit();
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
            txtDescription.BeforeTouchSize = new Size(206, 23);
            txtDescription.Location = new Point(180, 192);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(206, 23);
            txtDescription.TabIndex = 3;
            // 
            // autoLabel2
            // 
            autoLabel2.Location = new Point(98, 195);
            autoLabel2.Name = "autoLabel2";
            autoLabel2.Size = new Size(67, 15);
            autoLabel2.TabIndex = 2;
            autoLabel2.Text = "Description";
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI Semibold", 9F);
            btnSave.Location = new Point(195, 269);
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
            autoLabel3.Size = new Size(31, 15);
            autoLabel3.TabIndex = 5;
            autoLabel3.Text = "Type";
            // 
            // autoLabel4
            // 
            autoLabel4.Location = new Point(98, 123);
            autoLabel4.Name = "autoLabel4";
            autoLabel4.Size = new Size(31, 15);
            autoLabel4.TabIndex = 6;
            autoLabel4.Text = "Date";
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
            txtDate.Location = new Point(180, 119);
            txtDate.MetroColor = Color.FromArgb(22, 165, 220);
            txtDate.MinValue = new DateTime(0L);
            txtDate.Name = "txtDate";
            txtDate.Size = new Size(206, 20);
            txtDate.TabIndex = 8;
            txtDate.Value = new DateTime(2025, 4, 10, 22, 35, 0, 415);
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
            autoLabel5.Location = new Point(98, 156);
            autoLabel5.Name = "autoLabel5";
            autoLabel5.Size = new Size(51, 15);
            autoLabel5.TabIndex = 10;
            autoLabel5.Text = "Amount";
            // 
            // txtAmount
            // 
            txtAmount.AccessibilityEnabled = true;
            txtAmount.BeforeTouchSize = new Size(206, 23);
            txtAmount.DoubleValue = 0D;
            txtAmount.Location = new Point(180, 152);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(206, 23);
            txtAmount.TabIndex = 11;
            txtAmount.Text = "0.00";
            // 
            // txtIsRecurring
            // 
            txtIsRecurring.AccessibilityEnabled = true;
            txtIsRecurring.Border3DStyle = Border3DStyle.RaisedOuter;
            txtIsRecurring.Location = new Point(180, 231);
            txtIsRecurring.Name = "txtIsRecurring";
            txtIsRecurring.Size = new Size(150, 21);
            txtIsRecurring.TabIndex = 12;
            txtIsRecurring.Text = "Is Recurring?";
            // 
            // UpsertAllowanceView
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 341);
            Controls.Add(txtIsRecurring);
            Controls.Add(txtAmount);
            Controls.Add(autoLabel5);
            Controls.Add(txtEmployee);
            Controls.Add(txtDate);
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
            ((System.ComponentModel.ISupportInitialize)txtDate.Calendar).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtDate).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtEmployee).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtAmount).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtIsRecurring).EndInit();
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
        private Syncfusion.Windows.Forms.Tools.DateTimePickerAdv txtDate;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv txtEmployee;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel5;
        private Syncfusion.Windows.Forms.Tools.DoubleTextBox txtAmount;
        private Syncfusion.Windows.Forms.Tools.CheckBoxAdv txtIsRecurring;
    }
}