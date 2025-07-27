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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(UpsertEmployeeContributionView));
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
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            ((System.ComponentModel.ISupportInitialize)txtEmployee).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtPagIbig).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtSSSWISP).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtSSS).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtPhilHealth).BeginInit();
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
            // btnSave
            // 
            btnSave.BackColor = SystemColors.HotTrack;
            btnSave.Dock = DockStyle.Bottom;
            btnSave.Font = new Font("Segoe UI Semibold", 9F);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(14, 238);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(336, 28);
            btnSave.Style.BackColor = SystemColors.HotTrack;
            btnSave.Style.ForeColor = Color.White;
            btnSave.TabIndex = 4;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // txtEmployee
            // 
            txtEmployee.BackColor = Color.FromArgb(255, 255, 255);
            txtEmployee.Dock = DockStyle.Top;
            txtEmployee.ForeColor = Color.FromArgb(68, 68, 68);
            txtEmployee.Height = 36;
            txtEmployee.Location = new Point(14, 29);
            txtEmployee.Name = "txtEmployee";
            txtEmployee.Size = new Size(336, 36);
            txtEmployee.TabIndex = 9;
            txtEmployee.Text = "~Select~";
            txtEmployee.TextBoxHeight = 28;
            txtEmployee.ThemeName = "Office2016Colorful";
            // 
            // autoLabel5
            // 
            autoLabel5.Dock = DockStyle.Top;
            autoLabel5.Location = new Point(14, 65);
            autoLabel5.Name = "autoLabel5";
            autoLabel5.Size = new Size(47, 15);
            autoLabel5.TabIndex = 10;
            autoLabel5.Text = "PagIbig";
            // 
            // txtPagIbig
            // 
            txtPagIbig.AccessibilityEnabled = true;
            txtPagIbig.BeforeTouchSize = new Size(240, 23);
            txtPagIbig.Dock = DockStyle.Top;
            txtPagIbig.DoubleValue = 0D;
            txtPagIbig.Location = new Point(14, 80);
            txtPagIbig.Name = "txtPagIbig";
            txtPagIbig.Size = new Size(336, 23);
            txtPagIbig.TabIndex = 0;
            txtPagIbig.Text = "0.00";
            // 
            // txtSSSWISP
            // 
            txtSSSWISP.AccessibilityEnabled = true;
            txtSSSWISP.BeforeTouchSize = new Size(240, 23);
            txtSSSWISP.Dock = DockStyle.Top;
            txtSSSWISP.DoubleValue = 0D;
            txtSSSWISP.Location = new Point(14, 194);
            txtSSSWISP.Name = "txtSSSWISP";
            txtSSSWISP.Size = new Size(336, 23);
            txtSSSWISP.TabIndex = 3;
            txtSSSWISP.Text = "0.00";
            // 
            // autoLabel2
            // 
            autoLabel2.Dock = DockStyle.Top;
            autoLabel2.Location = new Point(14, 179);
            autoLabel2.Name = "autoLabel2";
            autoLabel2.Size = new Size(57, 15);
            autoLabel2.TabIndex = 12;
            autoLabel2.Text = "SSS-WISP";
            // 
            // txtSSS
            // 
            txtSSS.AccessibilityEnabled = true;
            txtSSS.BeforeTouchSize = new Size(240, 23);
            txtSSS.Dock = DockStyle.Top;
            txtSSS.DoubleValue = 0D;
            txtSSS.Location = new Point(14, 156);
            txtSSS.Name = "txtSSS";
            txtSSS.Size = new Size(336, 23);
            txtSSS.TabIndex = 2;
            txtSSS.Text = "0.00";
            // 
            // autoLabel3
            // 
            autoLabel3.Dock = DockStyle.Top;
            autoLabel3.Location = new Point(14, 141);
            autoLabel3.Name = "autoLabel3";
            autoLabel3.Size = new Size(25, 15);
            autoLabel3.TabIndex = 14;
            autoLabel3.Text = "SSS";
            // 
            // txtPhilHealth
            // 
            txtPhilHealth.AccessibilityEnabled = true;
            txtPhilHealth.BeforeTouchSize = new Size(240, 23);
            txtPhilHealth.Dock = DockStyle.Top;
            txtPhilHealth.DoubleValue = 0D;
            txtPhilHealth.Location = new Point(14, 118);
            txtPhilHealth.Name = "txtPhilHealth";
            txtPhilHealth.Size = new Size(336, 23);
            txtPhilHealth.TabIndex = 1;
            txtPhilHealth.Text = "0.00";
            // 
            // autoLabel4
            // 
            autoLabel4.Dock = DockStyle.Top;
            autoLabel4.Location = new Point(14, 103);
            autoLabel4.Name = "autoLabel4";
            autoLabel4.Size = new Size(62, 15);
            autoLabel4.TabIndex = 16;
            autoLabel4.Text = "PhilHealth";
            // 
            // materialCard1
            // 
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(btnSave);
            materialCard1.Controls.Add(txtSSSWISP);
            materialCard1.Controls.Add(autoLabel2);
            materialCard1.Controls.Add(txtSSS);
            materialCard1.Controls.Add(autoLabel3);
            materialCard1.Controls.Add(txtPhilHealth);
            materialCard1.Controls.Add(autoLabel4);
            materialCard1.Controls.Add(txtPagIbig);
            materialCard1.Controls.Add(autoLabel5);
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
            materialCard1.Size = new Size(364, 280);
            materialCard1.TabIndex = 18;
            // 
            // UpsertEmployeeContributionView
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(368, 284);
            Controls.Add(materialCard1);
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
            materialCard1.ResumeLayout(false);
            materialCard1.PerformLayout();
            ResumeLayout(false);
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
        private MaterialSkin.Controls.MaterialCard materialCard1;
    }
}