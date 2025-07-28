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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(UpsertBenefitView));
            autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtOther = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            btnSave = new Syncfusion.WinForms.Controls.SfButton();
            autoLabel3 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtBenefitType = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            txtEmployee = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            autoLabel5 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtAmount = new Syncfusion.Windows.Forms.Tools.DoubleTextBox();
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            ((System.ComponentModel.ISupportInitialize)txtOther).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtBenefitType).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtEmployee).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtAmount).BeginInit();
            materialCard1.SuspendLayout();
            SuspendLayout();
            // 
            // autoLabel1
            // 
            autoLabel1.Dock = DockStyle.Top;
            autoLabel1.Location = new Point(14, 50);
            autoLabel1.Name = "autoLabel1";
            autoLabel1.Size = new Size(59, 15);
            autoLabel1.TabIndex = 0;
            autoLabel1.Text = "Employee";
            // 
            // txtOther
            // 
            txtOther.BeforeTouchSize = new Size(304, 23);
            txtOther.Dock = DockStyle.Top;
            txtOther.Location = new Point(14, 139);
            txtOther.Name = "txtOther";
            txtOther.Size = new Size(304, 23);
            txtOther.TabIndex = 1;
            // 
            // autoLabel2
            // 
            autoLabel2.Dock = DockStyle.Top;
            autoLabel2.Location = new Point(14, 124);
            autoLabel2.Name = "autoLabel2";
            autoLabel2.Size = new Size(37, 15);
            autoLabel2.TabIndex = 2;
            autoLabel2.Text = "Other";
            // 
            // btnSave
            // 
            btnSave.BackColor = SystemColors.HotTrack;
            btnSave.Dock = DockStyle.Bottom;
            btnSave.Font = new Font("Segoe UI Semibold", 9F);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(14, 219);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(304, 28);
            btnSave.Style.BackColor = SystemColors.HotTrack;
            btnSave.Style.ForeColor = Color.White;
            btnSave.TabIndex = 4;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // autoLabel3
            // 
            autoLabel3.Dock = DockStyle.Top;
            autoLabel3.Location = new Point(14, 14);
            autoLabel3.Name = "autoLabel3";
            autoLabel3.Size = new Size(31, 15);
            autoLabel3.TabIndex = 5;
            autoLabel3.Text = "Type";
            // 
            // txtBenefitType
            // 
            txtBenefitType.BackColor = Color.FromArgb(255, 255, 255);
            txtBenefitType.Dock = DockStyle.Top;
            txtBenefitType.ForeColor = Color.FromArgb(68, 68, 68);
            txtBenefitType.Height = 21;
            txtBenefitType.Location = new Point(14, 29);
            txtBenefitType.Name = "txtBenefitType";
            txtBenefitType.Size = new Size(304, 21);
            txtBenefitType.TabIndex = 7;
            txtBenefitType.Text = "~Select~";
            txtBenefitType.TextBoxHeight = 28;
            txtBenefitType.ThemeName = "Office2016Colorful";
            // 
            // txtEmployee
            // 
            txtEmployee.BackColor = Color.FromArgb(255, 255, 255);
            txtEmployee.Dock = DockStyle.Top;
            txtEmployee.ForeColor = Color.FromArgb(68, 68, 68);
            txtEmployee.Height = 21;
            txtEmployee.Location = new Point(14, 65);
            txtEmployee.Name = "txtEmployee";
            txtEmployee.Size = new Size(304, 21);
            txtEmployee.TabIndex = 9;
            txtEmployee.Text = "~Select~";
            txtEmployee.TextBoxHeight = 28;
            txtEmployee.ThemeName = "Office2016Colorful";
            // 
            // autoLabel5
            // 
            autoLabel5.Dock = DockStyle.Top;
            autoLabel5.Location = new Point(14, 86);
            autoLabel5.Name = "autoLabel5";
            autoLabel5.Size = new Size(51, 15);
            autoLabel5.TabIndex = 10;
            autoLabel5.Text = "Amount";
            // 
            // txtAmount
            // 
            txtAmount.AccessibilityEnabled = true;
            txtAmount.BeforeTouchSize = new Size(304, 23);
            txtAmount.Dock = DockStyle.Top;
            txtAmount.DoubleValue = 0D;
            txtAmount.Location = new Point(14, 101);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(304, 23);
            txtAmount.TabIndex = 0;
            txtAmount.Text = "0.00";
            // 
            // materialCard1
            // 
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(txtOther);
            materialCard1.Controls.Add(autoLabel2);
            materialCard1.Controls.Add(txtAmount);
            materialCard1.Controls.Add(autoLabel5);
            materialCard1.Controls.Add(txtEmployee);
            materialCard1.Controls.Add(autoLabel1);
            materialCard1.Controls.Add(txtBenefitType);
            materialCard1.Controls.Add(btnSave);
            materialCard1.Controls.Add(autoLabel3);
            materialCard1.Depth = 0;
            materialCard1.Dock = DockStyle.Fill;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(2, 2);
            materialCard1.Margin = new Padding(14);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(14);
            materialCard1.Size = new Size(332, 261);
            materialCard1.TabIndex = 12;
            // 
            // UpsertBenefitView
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(336, 265);
            Controls.Add(materialCard1);
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
            materialCard1.ResumeLayout(false);
            materialCard1.PerformLayout();
            ResumeLayout(false);
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
        private MaterialSkin.Controls.MaterialCard materialCard1;
    }
}