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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(UpsertTaxView));
            autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            btnSave = new Syncfusion.WinForms.Controls.SfButton();
            autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel3 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtMinimumSalary = new Syncfusion.Windows.Forms.Tools.DoubleTextBox();
            txtMaximumSalary = new Syncfusion.Windows.Forms.Tools.DoubleTextBox();
            txtTaxRate = new Syncfusion.Windows.Forms.Tools.DoubleTextBox();
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            ((System.ComponentModel.ISupportInitialize)txtMinimumSalary).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtMaximumSalary).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtTaxRate).BeginInit();
            materialCard1.SuspendLayout();
            SuspendLayout();
            // 
            // autoLabel2
            // 
            autoLabel2.Dock = DockStyle.Top;
            autoLabel2.Location = new Point(14, 14);
            autoLabel2.Name = "autoLabel2";
            autoLabel2.Size = new Size(94, 15);
            autoLabel2.TabIndex = 2;
            autoLabel2.Text = "Minimum Salary";
            // 
            // btnSave
            // 
            btnSave.BackColor = SystemColors.HotTrack;
            btnSave.Dock = DockStyle.Bottom;
            btnSave.Font = new Font("Segoe UI Semibold", 9F);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(14, 167);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(240, 28);
            btnSave.Style.BackColor = SystemColors.HotTrack;
            btnSave.Style.ForeColor = Color.White;
            btnSave.TabIndex = 3;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // autoLabel1
            // 
            autoLabel1.Dock = DockStyle.Top;
            autoLabel1.Location = new Point(14, 90);
            autoLabel1.Name = "autoLabel1";
            autoLabel1.Size = new Size(50, 15);
            autoLabel1.TabIndex = 5;
            autoLabel1.Text = "Tax Rate";
            // 
            // autoLabel3
            // 
            autoLabel3.Dock = DockStyle.Top;
            autoLabel3.Location = new Point(14, 52);
            autoLabel3.Name = "autoLabel3";
            autoLabel3.Size = new Size(96, 15);
            autoLabel3.TabIndex = 6;
            autoLabel3.Text = "Maximum Salary";
            // 
            // txtMinimumSalary
            // 
            txtMinimumSalary.AccessibilityEnabled = true;
            txtMinimumSalary.BeforeTouchSize = new Size(240, 23);
            txtMinimumSalary.Dock = DockStyle.Top;
            txtMinimumSalary.DoubleValue = 1D;
            txtMinimumSalary.Location = new Point(14, 29);
            txtMinimumSalary.Name = "txtMinimumSalary";
            txtMinimumSalary.Size = new Size(240, 23);
            txtMinimumSalary.TabIndex = 0;
            txtMinimumSalary.Text = "1.00";
            // 
            // txtMaximumSalary
            // 
            txtMaximumSalary.AccessibilityEnabled = true;
            txtMaximumSalary.BeforeTouchSize = new Size(240, 23);
            txtMaximumSalary.Dock = DockStyle.Top;
            txtMaximumSalary.DoubleValue = 1D;
            txtMaximumSalary.Location = new Point(14, 67);
            txtMaximumSalary.Name = "txtMaximumSalary";
            txtMaximumSalary.Size = new Size(240, 23);
            txtMaximumSalary.TabIndex = 1;
            txtMaximumSalary.Text = "1.00";
            // 
            // txtTaxRate
            // 
            txtTaxRate.AccessibilityEnabled = true;
            txtTaxRate.BeforeTouchSize = new Size(240, 23);
            txtTaxRate.Dock = DockStyle.Top;
            txtTaxRate.DoubleValue = 1D;
            txtTaxRate.Location = new Point(14, 105);
            txtTaxRate.Name = "txtTaxRate";
            txtTaxRate.Size = new Size(240, 23);
            txtTaxRate.TabIndex = 2;
            txtTaxRate.Text = "1.00";
            // 
            // materialCard1
            // 
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(txtTaxRate);
            materialCard1.Controls.Add(autoLabel1);
            materialCard1.Controls.Add(txtMaximumSalary);
            materialCard1.Controls.Add(btnSave);
            materialCard1.Controls.Add(autoLabel3);
            materialCard1.Controls.Add(txtMinimumSalary);
            materialCard1.Controls.Add(autoLabel2);
            materialCard1.Depth = 0;
            materialCard1.Dock = DockStyle.Fill;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(2, 2);
            materialCard1.Margin = new Padding(14);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(14);
            materialCard1.Size = new Size(268, 209);
            materialCard1.TabIndex = 10;
            // 
            // UpsertTaxView
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(272, 213);
            Controls.Add(materialCard1);
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
            materialCard1.ResumeLayout(false);
            materialCard1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private Syncfusion.WinForms.Controls.SfButton btnSave;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel3;
        private Syncfusion.Windows.Forms.Tools.DoubleTextBox txtMinimumSalary;
        private Syncfusion.Windows.Forms.Tools.DoubleTextBox txtMaximumSalary;
        private Syncfusion.Windows.Forms.Tools.DoubleTextBox txtTaxRate;
        private MaterialSkin.Controls.MaterialCard materialCard1;
    }
}