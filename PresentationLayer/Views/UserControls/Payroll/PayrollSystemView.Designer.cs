namespace PresentationLayer.Views.UserControls.Payroll
{
    partial class PayrollSystemView
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
            tcMain = new MaterialSkin.Controls.MaterialTabControl();
            tbAttendance = new TabPage();
            tbContribution = new TabPage();
            tbDeduction = new TabPage();
            tbDepartment = new TabPage();
            tbEmployee = new TabPage();
            tbJobPosition = new TabPage();
            tbLeave = new TabPage();
            tbShift = new TabPage();
            tbTax = new TabPage();
            tbPayroll = new TabPage();
            tbProject = new TabPage();
            tcMain.SuspendLayout();
            SuspendLayout();
            // 
            // tcMain
            // 
            tcMain.Controls.Add(tbAttendance);
            tcMain.Controls.Add(tbContribution);
            tcMain.Controls.Add(tbDeduction);
            tcMain.Controls.Add(tbDepartment);
            tcMain.Controls.Add(tbEmployee);
            tcMain.Controls.Add(tbJobPosition);
            tcMain.Controls.Add(tbLeave);
            tcMain.Controls.Add(tbShift);
            tcMain.Controls.Add(tbTax);
            tcMain.Controls.Add(tbPayroll);
            tcMain.Controls.Add(tbProject);
            tcMain.Depth = 0;
            tcMain.Dock = DockStyle.Fill;
            tcMain.Location = new Point(2, 51);
            tcMain.MouseState = MaterialSkin.MouseState.HOVER;
            tcMain.Multiline = true;
            tcMain.Name = "tcMain";
            tcMain.SelectedIndex = 0;
            tcMain.Size = new Size(1916, 1027);
            tcMain.TabIndex = 5;
            // 
            // tbAttendance
            // 
            tbAttendance.ImageKey = "user.png";
            tbAttendance.Location = new Point(4, 29);
            tbAttendance.Name = "tbAttendance";
            tbAttendance.Padding = new Padding(3);
            tbAttendance.Size = new Size(1908, 994);
            tbAttendance.TabIndex = 0;
            tbAttendance.Text = "Attendance";
            tbAttendance.UseVisualStyleBackColor = true;
            // 
            // tbContribution
            // 
            tbContribution.ImageKey = "dashboard.png";
            tbContribution.Location = new Point(4, 29);
            tbContribution.Name = "tbContribution";
            tbContribution.Padding = new Padding(3);
            tbContribution.Size = new Size(1908, 994);
            tbContribution.TabIndex = 1;
            tbContribution.Text = "Contribution";
            tbContribution.UseVisualStyleBackColor = true;
            // 
            // tbDeduction
            // 
            tbDeduction.ImageKey = "sales-order.png";
            tbDeduction.Location = new Point(4, 29);
            tbDeduction.Name = "tbDeduction";
            tbDeduction.Size = new Size(1908, 994);
            tbDeduction.TabIndex = 2;
            tbDeduction.Text = "Deduction";
            tbDeduction.UseVisualStyleBackColor = true;
            // 
            // tbDepartment
            // 
            tbDepartment.ImageKey = "purchase-order.png";
            tbDepartment.Location = new Point(4, 29);
            tbDepartment.Name = "tbDepartment";
            tbDepartment.Size = new Size(1908, 994);
            tbDepartment.TabIndex = 3;
            tbDepartment.Text = "Department";
            tbDepartment.UseVisualStyleBackColor = true;
            // 
            // tbEmployee
            // 
            tbEmployee.ImageKey = "product.png";
            tbEmployee.Location = new Point(4, 29);
            tbEmployee.Name = "tbEmployee";
            tbEmployee.Size = new Size(1908, 994);
            tbEmployee.TabIndex = 4;
            tbEmployee.Text = "Employee";
            tbEmployee.UseVisualStyleBackColor = true;
            // 
            // tbJobPosition
            // 
            tbJobPosition.ImageKey = "setting.png";
            tbJobPosition.Location = new Point(4, 29);
            tbJobPosition.Name = "tbJobPosition";
            tbJobPosition.Size = new Size(1908, 994);
            tbJobPosition.TabIndex = 5;
            tbJobPosition.Text = "Job Position";
            tbJobPosition.UseVisualStyleBackColor = true;
            // 
            // tbLeave
            // 
            tbLeave.Location = new Point(4, 29);
            tbLeave.Margin = new Padding(2);
            tbLeave.Name = "tbLeave";
            tbLeave.Size = new Size(1908, 994);
            tbLeave.TabIndex = 6;
            tbLeave.Text = "Leave";
            tbLeave.UseVisualStyleBackColor = true;
            // 
            // tbShift
            // 
            tbShift.Location = new Point(4, 29);
            tbShift.Margin = new Padding(2);
            tbShift.Name = "tbShift";
            tbShift.Size = new Size(1908, 994);
            tbShift.TabIndex = 7;
            tbShift.Text = "Shift";
            tbShift.UseVisualStyleBackColor = true;
            // 
            // tbTax
            // 
            tbTax.Location = new Point(4, 29);
            tbTax.Margin = new Padding(2);
            tbTax.Name = "tbTax";
            tbTax.Size = new Size(1908, 994);
            tbTax.TabIndex = 8;
            tbTax.Text = "Tax";
            tbTax.UseVisualStyleBackColor = true;
            // 
            // tbPayroll
            // 
            tbPayroll.Location = new Point(4, 29);
            tbPayroll.Margin = new Padding(2);
            tbPayroll.Name = "tbPayroll";
            tbPayroll.Size = new Size(1908, 994);
            tbPayroll.TabIndex = 9;
            tbPayroll.Text = "Payroll";
            tbPayroll.UseVisualStyleBackColor = true;
            // 
            // tbProject
            // 
            tbProject.Location = new Point(4, 29);
            tbProject.Name = "tbProject";
            tbProject.Size = new Size(1908, 994);
            tbProject.TabIndex = 10;
            tbProject.Text = "Project";
            tbProject.UseVisualStyleBackColor = true;
            // 
            // PayrollSystemView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1920, 1080);
            Controls.Add(tcMain);
            DrawerAutoShow = true;
            DrawerShowIconsWhenHidden = true;
            DrawerTabControl = tcMain;
            Margin = new Padding(2);
            Name = "PayrollSystemView";
            Padding = new Padding(2, 51, 2, 2);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Payroll System";
            WindowState = FormWindowState.Maximized;
            tcMain.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl tcMain;
        private TabPage tbContribution;
        private TabPage tbAttendance;
        private TabPage tbDeduction;
        private TabPage tbDepartment;
        private TabPage tbEmployee;
        private TabPage tbJobPosition;
        private TabPage tbLeave;
        private TabPage tbShift;
        private TabPage tbTax;
        private TabPage tbPayroll;
        private TabPage tbProject;
    }
}