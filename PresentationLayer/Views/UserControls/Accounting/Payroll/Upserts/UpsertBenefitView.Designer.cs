namespace RavenTech_ERP.Views.UserControls.Inventory
{
    partial class UpsertBenefitView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpsertBenefitView));
            autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtOther = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            btnSave = new Syncfusion.WinForms.Controls.SfButton();
            autoLabel3 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtBenefitType = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            txtEmployee = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            autoLabel5 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtAmount = new Syncfusion.Windows.Forms.Tools.DoubleTextBox();
            ((System.ComponentModel.ISupportInitialize)txtOther).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtBenefitType).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtEmployee).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtAmount).BeginInit();
            SuspendLayout();
            // 
            // autoLabel1
            // 
            autoLabel1.Location = new Point(98, 76);
            autoLabel1.Name = "autoLabel1";
            autoLabel1.Size = new Size(59, 15);
            autoLabel1.TabIndex = 0;
            autoLabel1.Text = "Employee";
            // 
            // txtOther
            // 
            txtOther.BeforeTouchSize = new Size(206, 23);
            txtOther.Location = new Point(180, 191);
            txtOther.Name = "txtOther";
            txtOther.Size = new Size(206, 23);
            txtOther.TabIndex = 3;
            // 
            // autoLabel2
            // 
            autoLabel2.Location = new Point(98, 194);
            autoLabel2.Name = "autoLabel2";
            autoLabel2.Size = new Size(37, 15);
            autoLabel2.TabIndex = 2;
            autoLabel2.Text = "Other";
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
            autoLabel3.Location = new Point(98, 118);
            autoLabel3.Name = "autoLabel3";
            autoLabel3.Size = new Size(31, 15);
            autoLabel3.TabIndex = 5;
            autoLabel3.Text = "Type";
            // 
            // txtBenefitType
            // 
            txtBenefitType.BackColor = Color.FromArgb(255, 255, 255);
            txtBenefitType.ForeColor = Color.FromArgb(68, 68, 68);
            txtBenefitType.Height = 31;
            txtBenefitType.Location = new Point(180, 113);
            txtBenefitType.Name = "txtBenefitType";
            txtBenefitType.Size = new Size(206, 31);
            txtBenefitType.TabIndex = 7;
            txtBenefitType.Text = "~Select~";
            txtBenefitType.TextBoxHeight = 23;
            txtBenefitType.ThemeName = "Office2016Colorful";
            // 
            // txtEmployee
            // 
            txtEmployee.BackColor = Color.FromArgb(255, 255, 255);
            txtEmployee.ForeColor = Color.FromArgb(68, 68, 68);
            txtEmployee.Height = 31;
            txtEmployee.Location = new Point(180, 70);
            txtEmployee.Name = "txtEmployee";
            txtEmployee.Size = new Size(206, 31);
            txtEmployee.TabIndex = 9;
            txtEmployee.Text = "~Select~";
            txtEmployee.TextBoxHeight = 23;
            txtEmployee.ThemeName = "Office2016Colorful";
            // 
            // autoLabel5
            // 
            autoLabel5.Location = new Point(98, 159);
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
            txtAmount.Location = new Point(180, 156);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(206, 23);
            txtAmount.TabIndex = 11;
            txtAmount.Text = "0.00";
            // 
            // UpsertBenefitView
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 341);
            Controls.Add(txtAmount);
            Controls.Add(autoLabel5);
            Controls.Add(txtEmployee);
            Controls.Add(txtBenefitType);
            Controls.Add(autoLabel3);
            Controls.Add(btnSave);
            Controls.Add(txtOther);
            Controls.Add(autoLabel2);
            Controls.Add(autoLabel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "UpsertBenefitView";
            StartPosition = FormStartPosition.CenterScreen;
            Style.MdiChild.IconHorizontalAlignment = HorizontalAlignment.Center;
            Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            Text = "Add Benefit";
            ((System.ComponentModel.ISupportInitialize)txtOther).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtBenefitType).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtEmployee).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtAmount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtOther;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private Syncfusion.WinForms.Controls.SfButton btnSave;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel3;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv txtBenefitType;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv txtEmployee;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel5;
        private Syncfusion.Windows.Forms.Tools.DoubleTextBox txtAmount;
    }
}