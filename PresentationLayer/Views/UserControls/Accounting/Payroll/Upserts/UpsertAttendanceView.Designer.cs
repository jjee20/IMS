namespace RavenTech_ERP.Views.UserControls.Accounting.Payroll.Upserts
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
            txtIsPresent = new Syncfusion.Windows.Forms.Tools.CheckBoxAdv();
            txtIsHalfDay = new Syncfusion.Windows.Forms.Tools.CheckBoxAdv();
            autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel3 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel4 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel5 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel6 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            btnSave = new Syncfusion.WinForms.Controls.SfButton();
            txtHoursWorked = new Syncfusion.Windows.Forms.Tools.DoubleTextBox();
            txtEmployee = new Syncfusion.WinForms.ListView.SfComboBox();
            txtProject = new Syncfusion.WinForms.ListView.SfComboBox();
            txtDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
            txtTimein = new Syncfusion.WinForms.Input.SfDateTimeEdit();
            txtTimeout = new Syncfusion.WinForms.Input.SfDateTimeEdit();
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            ((System.ComponentModel.ISupportInitialize)txtIsPresent).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtIsHalfDay).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtHoursWorked).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtEmployee).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtProject).BeginInit();
            materialCard1.SuspendLayout();
            SuspendLayout();
            // 
            // autoLabel1
            // 
            autoLabel1.Dock = DockStyle.Top;
            autoLabel1.Location = new Point(14, 14);
            autoLabel1.Name = "autoLabel1";
            autoLabel1.Size = new Size(59, 15);
            autoLabel1.TabIndex = 0;
            autoLabel1.Text = "Employee";
            // 
            // txtIsPresent
            // 
            txtIsPresent.AccessibilityEnabled = true;
            txtIsPresent.BeforeTouchSize = new Size(326, 21);
            txtIsPresent.Checked = true;
            txtIsPresent.CheckState = CheckState.Checked;
            txtIsPresent.Dock = DockStyle.Top;
            txtIsPresent.ImageCheckBoxSize = new Size(19, 19);
            txtIsPresent.Location = new Point(14, 242);
            txtIsPresent.Name = "txtIsPresent";
            txtIsPresent.Size = new Size(326, 21);
            txtIsPresent.TabIndex = 6;
            txtIsPresent.Text = "Is Present?";
            // 
            // txtIsHalfDay
            // 
            txtIsHalfDay.AccessibilityEnabled = true;
            txtIsHalfDay.BeforeTouchSize = new Size(326, 21);
            txtIsHalfDay.Dock = DockStyle.Top;
            txtIsHalfDay.ImageCheckBoxSize = new Size(19, 19);
            txtIsHalfDay.Location = new Point(14, 263);
            txtIsHalfDay.Name = "txtIsHalfDay";
            txtIsHalfDay.Size = new Size(326, 21);
            txtIsHalfDay.TabIndex = 7;
            txtIsHalfDay.Text = "Is Halfday?";
            // 
            // autoLabel2
            // 
            autoLabel2.Dock = DockStyle.Top;
            autoLabel2.Location = new Point(14, 90);
            autoLabel2.Name = "autoLabel2";
            autoLabel2.Size = new Size(31, 15);
            autoLabel2.TabIndex = 9;
            autoLabel2.Text = "Date";
            // 
            // autoLabel3
            // 
            autoLabel3.Dock = DockStyle.Top;
            autoLabel3.Location = new Point(14, 128);
            autoLabel3.Name = "autoLabel3";
            autoLabel3.Size = new Size(48, 15);
            autoLabel3.TabIndex = 10;
            autoLabel3.Text = "Time-In";
            // 
            // autoLabel4
            // 
            autoLabel4.Dock = DockStyle.Top;
            autoLabel4.Location = new Point(14, 166);
            autoLabel4.Name = "autoLabel4";
            autoLabel4.Size = new Size(58, 15);
            autoLabel4.TabIndex = 11;
            autoLabel4.Text = "Time-Out";
            // 
            // autoLabel5
            // 
            autoLabel5.Dock = DockStyle.Top;
            autoLabel5.Location = new Point(14, 204);
            autoLabel5.Name = "autoLabel5";
            autoLabel5.Size = new Size(83, 15);
            autoLabel5.TabIndex = 12;
            autoLabel5.Text = "Hours Worked";
            // 
            // autoLabel6
            // 
            autoLabel6.Dock = DockStyle.Top;
            autoLabel6.Location = new Point(14, 52);
            autoLabel6.Name = "autoLabel6";
            autoLabel6.Size = new Size(44, 15);
            autoLabel6.TabIndex = 13;
            autoLabel6.Text = "Project";
            // 
            // btnSave
            // 
            btnSave.BackColor = SystemColors.HotTrack;
            btnSave.Dock = DockStyle.Bottom;
            btnSave.Font = new Font("Segoe UI Semibold", 9F);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(14, 326);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(326, 28);
            btnSave.Style.BackColor = SystemColors.HotTrack;
            btnSave.Style.ForeColor = Color.White;
            btnSave.TabIndex = 14;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // txtHoursWorked
            // 
            txtHoursWorked.AccessibilityEnabled = true;
            txtHoursWorked.BeforeTouchSize = new Size(240, 23);
            txtHoursWorked.Dock = DockStyle.Top;
            txtHoursWorked.DoubleValue = 8D;
            txtHoursWorked.Location = new Point(14, 219);
            txtHoursWorked.Margin = new Padding(2);
            txtHoursWorked.Name = "txtHoursWorked";
            txtHoursWorked.Size = new Size(326, 23);
            txtHoursWorked.TabIndex = 0;
            txtHoursWorked.Text = "8.00";
            // 
            // txtEmployee
            // 
            txtEmployee.Dock = DockStyle.Top;
            txtEmployee.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            txtEmployee.Location = new Point(14, 29);
            txtEmployee.Name = "txtEmployee";
            txtEmployee.Size = new Size(326, 23);
            txtEmployee.Style.TokenStyle.CloseButtonBackColor = Color.FromArgb(255, 255, 255);
            txtEmployee.TabIndex = 16;
            txtEmployee.TabStop = false;
            txtEmployee.Text = "~Select~";
            // 
            // txtProject
            // 
            txtProject.Dock = DockStyle.Top;
            txtProject.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            txtProject.Location = new Point(14, 67);
            txtProject.Name = "txtProject";
            txtProject.Size = new Size(326, 23);
            txtProject.Style.TokenStyle.CloseButtonBackColor = Color.FromArgb(255, 255, 255);
            txtProject.TabIndex = 17;
            txtProject.TabStop = false;
            txtProject.Text = "~Select~";
            // 
            // txtDate
            // 
            txtDate.DateTimeIcon = null;
            txtDate.Dock = DockStyle.Top;
            txtDate.Location = new Point(14, 105);
            txtDate.Name = "txtDate";
            txtDate.Size = new Size(326, 23);
            txtDate.TabIndex = 18;
            txtDate.ToolTipText = "";
            // 
            // txtTimein
            // 
            txtTimein.DateTimeIcon = null;
            txtTimein.DateTimePattern = Syncfusion.WinForms.Input.Enums.DateTimePattern.ShortTime;
            txtTimein.Dock = DockStyle.Top;
            txtTimein.Location = new Point(14, 143);
            txtTimein.Name = "txtTimein";
            txtTimein.Size = new Size(326, 23);
            txtTimein.TabIndex = 19;
            txtTimein.ToolTipText = "";
            txtTimein.Value = new DateTime(2025, 7, 26, 8, 0, 0, 0);
            // 
            // txtTimeout
            // 
            txtTimeout.DateTimeIcon = null;
            txtTimeout.DateTimePattern = Syncfusion.WinForms.Input.Enums.DateTimePattern.ShortTime;
            txtTimeout.Dock = DockStyle.Top;
            txtTimeout.Location = new Point(14, 181);
            txtTimeout.Name = "txtTimeout";
            txtTimeout.Size = new Size(326, 23);
            txtTimeout.TabIndex = 20;
            txtTimeout.ToolTipText = "";
            txtTimeout.Value = new DateTime(2025, 7, 26, 17, 0, 0, 0);
            // 
            // materialCard1
            // 
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(btnSave);
            materialCard1.Controls.Add(txtIsHalfDay);
            materialCard1.Controls.Add(txtIsPresent);
            materialCard1.Controls.Add(txtHoursWorked);
            materialCard1.Controls.Add(autoLabel5);
            materialCard1.Controls.Add(txtTimeout);
            materialCard1.Controls.Add(autoLabel4);
            materialCard1.Controls.Add(txtTimein);
            materialCard1.Controls.Add(autoLabel3);
            materialCard1.Controls.Add(txtDate);
            materialCard1.Controls.Add(autoLabel2);
            materialCard1.Controls.Add(txtProject);
            materialCard1.Controls.Add(autoLabel6);
            materialCard1.Controls.Add(txtEmployee);
            materialCard1.Controls.Add(autoLabel1);
            materialCard1.Depth = 0;
            materialCard1.Dock = DockStyle.Fill;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(2, 2);
            materialCard1.Margin = new Padding(14);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(14);
            materialCard1.Size = new Size(354, 368);
            materialCard1.TabIndex = 21;
            // 
            // UpsertAttendanceView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(358, 372);
            Controls.Add(materialCard1);
            Name = "UpsertAttendanceView";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Style.MdiChild.IconHorizontalAlignment = HorizontalAlignment.Center;
            Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            Text = "Add Attendance";
            Load += UpsertAttendanceView_Load;
            ((System.ComponentModel.ISupportInitialize)txtIsPresent).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtIsHalfDay).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtHoursWorked).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtEmployee).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtProject).EndInit();
            materialCard1.ResumeLayout(false);
            materialCard1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.Windows.Forms.Tools.CheckBoxAdv txtIsPresent;
        private Syncfusion.Windows.Forms.Tools.CheckBoxAdv txtIsHalfDay;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel3;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel4;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel5;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel6;
        private Syncfusion.WinForms.Controls.SfButton btnSave;
        private Syncfusion.Windows.Forms.Tools.DoubleTextBox txtHoursWorked;
        private Syncfusion.WinForms.ListView.SfComboBox txtEmployee;
        private Syncfusion.WinForms.ListView.SfComboBox txtProject;
        private Syncfusion.WinForms.Input.SfDateTimeEdit txtDate;
        private Syncfusion.WinForms.Input.SfDateTimeEdit txtTimein;
        private Syncfusion.WinForms.Input.SfDateTimeEdit txtTimeout;
        private MaterialSkin.Controls.MaterialCard materialCard1;
    }
}