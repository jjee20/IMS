namespace RavenTech_ERP.Views.UserControls.Inventory
{
    partial class UpsertEmployeeContributionView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpsertEmployeeContributionView));
            autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            btnSave = new Syncfusion.WinForms.Controls.SfButton();
            txtEmployee = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            autoLabel5 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtPagIbig = new Syncfusion.Windows.Forms.Tools.DoubleTextBox();
            txtSSSWISP = new Syncfusion.Windows.Forms.Tools.DoubleTextBox();
            autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtSSS = new Syncfusion.Windows.Forms.Tools.DoubleTextBox();
            autoLabel3 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtPhilHealth = new Syncfusion.Windows.Forms.Tools.DoubleTextBox();
            autoLabel4 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            ((System.ComponentModel.ISupportInitialize)txtEmployee).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtPagIbig).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtSSSWISP).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtSSS).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtPhilHealth).BeginInit();
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
            autoLabel5.Size = new Size(47, 15);
            autoLabel5.TabIndex = 10;
            autoLabel5.Text = "PagIbig";
            // 
            // txtPagIbig
            // 
            txtPagIbig.AccessibilityEnabled = true;
            txtPagIbig.BeforeTouchSize = new Size(206, 23);
            txtPagIbig.DoubleValue = 0D;
            txtPagIbig.Location = new Point(180, 152);
            txtPagIbig.Name = "txtPagIbig";
            txtPagIbig.Size = new Size(206, 23);
            txtPagIbig.TabIndex = 11;
            txtPagIbig.Text = "0.00";
            // 
            // txtSSSWISP
            // 
            txtSSSWISP.AccessibilityEnabled = true;
            txtSSSWISP.BeforeTouchSize = new Size(206, 23);
            txtSSSWISP.DoubleValue = 0D;
            txtSSSWISP.Location = new Point(180, 118);
            txtSSSWISP.Name = "txtSSSWISP";
            txtSSSWISP.Size = new Size(206, 23);
            txtSSSWISP.TabIndex = 13;
            txtSSSWISP.Text = "0.00";
            // 
            // autoLabel2
            // 
            autoLabel2.Location = new Point(98, 122);
            autoLabel2.Name = "autoLabel2";
            autoLabel2.Size = new Size(57, 15);
            autoLabel2.TabIndex = 12;
            autoLabel2.Text = "SSS-WISP";
            // 
            // txtSSS
            // 
            txtSSS.AccessibilityEnabled = true;
            txtSSS.BeforeTouchSize = new Size(206, 23);
            txtSSS.DoubleValue = 0D;
            txtSSS.Location = new Point(180, 85);
            txtSSS.Name = "txtSSS";
            txtSSS.Size = new Size(206, 23);
            txtSSS.TabIndex = 15;
            txtSSS.Text = "0.00";
            // 
            // autoLabel3
            // 
            autoLabel3.Location = new Point(98, 89);
            autoLabel3.Name = "autoLabel3";
            autoLabel3.Size = new Size(25, 15);
            autoLabel3.TabIndex = 14;
            autoLabel3.Text = "SSS";
            // 
            // txtPhilHealth
            // 
            txtPhilHealth.AccessibilityEnabled = true;
            txtPhilHealth.BeforeTouchSize = new Size(206, 23);
            txtPhilHealth.DoubleValue = 0D;
            txtPhilHealth.Location = new Point(180, 187);
            txtPhilHealth.Name = "txtPhilHealth";
            txtPhilHealth.Size = new Size(206, 23);
            txtPhilHealth.TabIndex = 17;
            txtPhilHealth.Text = "0.00";
            // 
            // autoLabel4
            // 
            autoLabel4.Location = new Point(98, 191);
            autoLabel4.Name = "autoLabel4";
            autoLabel4.Size = new Size(62, 15);
            autoLabel4.TabIndex = 16;
            autoLabel4.Text = "PhilHealth";
            // 
            // UpsertEmployeeContributionView
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 341);
            Controls.Add(txtPhilHealth);
            Controls.Add(autoLabel4);
            Controls.Add(txtSSS);
            Controls.Add(autoLabel3);
            Controls.Add(txtSSSWISP);
            Controls.Add(autoLabel2);
            Controls.Add(txtPagIbig);
            Controls.Add(autoLabel5);
            Controls.Add(txtEmployee);
            Controls.Add(btnSave);
            Controls.Add(autoLabel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "UpsertEmployeeContributionView";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Style.MdiChild.IconHorizontalAlignment = HorizontalAlignment.Center;
            Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            Text = "Add Employee Contribution";
            ((System.ComponentModel.ISupportInitialize)txtEmployee).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtPagIbig).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtSSSWISP).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtSSS).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtPhilHealth).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtDescription;
        private Syncfusion.WinForms.Controls.SfButton btnSave;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv txtEmployeeContributionType;
        private Syncfusion.Windows.Forms.Tools.DateTimePickerAdv txtDate;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv txtEmployee;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel5;
        private Syncfusion.Windows.Forms.Tools.DoubleTextBox txtPagIbig;
        private Syncfusion.Windows.Forms.Tools.DoubleTextBox txtSSSWISP;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private Syncfusion.Windows.Forms.Tools.DoubleTextBox txtSSS;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel3;
        private Syncfusion.Windows.Forms.Tools.DoubleTextBox txtPhilHealth;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel4;
        private Syncfusion.Windows.Forms.Tools.CheckBoxAdv txtIsRecurring;
    }
}