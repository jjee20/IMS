namespace RavenTech_ERP.Views.UserControls.Inventory
{
    partial class UpsertTaxView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpsertTaxView));
            autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            btnSave = new Syncfusion.WinForms.Controls.SfButton();
            autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel3 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtMinimumSalary = new Syncfusion.Windows.Forms.Tools.DoubleTextBox();
            txtMaximumSalary = new Syncfusion.Windows.Forms.Tools.DoubleTextBox();
            txtTaxRate = new Syncfusion.Windows.Forms.Tools.DoubleTextBox();
            ((System.ComponentModel.ISupportInitialize)txtMinimumSalary).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtMaximumSalary).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtTaxRate).BeginInit();
            SuspendLayout();
            // 
            // autoLabel2
            // 
            autoLabel2.Location = new Point(68, 86);
            autoLabel2.Name = "autoLabel2";
            autoLabel2.Size = new Size(94, 15);
            autoLabel2.TabIndex = 2;
            autoLabel2.Text = "Minimum Salary";
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI Semibold", 9F);
            btnSave.Location = new Point(195, 237);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(96, 28);
            btnSave.TabIndex = 4;
            btnSave.Text = "Save";
            btnSave.Click += btnSave_Click;
            // 
            // autoLabel1
            // 
            autoLabel1.Location = new Point(68, 162);
            autoLabel1.Name = "autoLabel1";
            autoLabel1.Size = new Size(50, 15);
            autoLabel1.TabIndex = 5;
            autoLabel1.Text = "Tax Rate";
            // 
            // autoLabel3
            // 
            autoLabel3.Location = new Point(68, 124);
            autoLabel3.Name = "autoLabel3";
            autoLabel3.Size = new Size(96, 15);
            autoLabel3.TabIndex = 6;
            autoLabel3.Text = "Maximum Salary";
            // 
            // txtMinimumSalary
            // 
            txtMinimumSalary.AccessibilityEnabled = true;
            txtMinimumSalary.BeforeTouchSize = new Size(194, 23);
            txtMinimumSalary.DoubleValue = 1D;
            txtMinimumSalary.Location = new Point(191, 82);
            txtMinimumSalary.Name = "txtMinimumSalary";
            txtMinimumSalary.Size = new Size(194, 23);
            txtMinimumSalary.TabIndex = 7;
            txtMinimumSalary.Text = "1.00";
            // 
            // txtMaximumSalary
            // 
            txtMaximumSalary.AccessibilityEnabled = true;
            txtMaximumSalary.BeforeTouchSize = new Size(194, 23);
            txtMaximumSalary.DoubleValue = 1D;
            txtMaximumSalary.Location = new Point(191, 119);
            txtMaximumSalary.Name = "txtMaximumSalary";
            txtMaximumSalary.Size = new Size(194, 23);
            txtMaximumSalary.TabIndex = 8;
            txtMaximumSalary.Text = "1.00";
            // 
            // txtTaxRate
            // 
            txtTaxRate.AccessibilityEnabled = true;
            txtTaxRate.BeforeTouchSize = new Size(194, 23);
            txtTaxRate.DoubleValue = 1D;
            txtTaxRate.Location = new Point(191, 157);
            txtTaxRate.Name = "txtTaxRate";
            txtTaxRate.Size = new Size(194, 23);
            txtTaxRate.TabIndex = 9;
            txtTaxRate.Text = "1.00";
            // 
            // UpsertTaxView
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 341);
            Controls.Add(txtTaxRate);
            Controls.Add(txtMaximumSalary);
            Controls.Add(txtMinimumSalary);
            Controls.Add(autoLabel3);
            Controls.Add(autoLabel1);
            Controls.Add(btnSave);
            Controls.Add(autoLabel2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "UpsertTaxView";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Style.MdiChild.IconHorizontalAlignment = HorizontalAlignment.Center;
            Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            Text = "Add Tax";
            ((System.ComponentModel.ISupportInitialize)txtMinimumSalary).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtMaximumSalary).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtTaxRate).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private Syncfusion.WinForms.Controls.SfButton btnSave;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel3;
        private Syncfusion.Windows.Forms.Tools.DoubleTextBox txtMinimumSalary;
        private Syncfusion.Windows.Forms.Tools.DoubleTextBox txtMaximumSalary;
        private Syncfusion.Windows.Forms.Tools.DoubleTextBox txtTaxRate;
    }
}