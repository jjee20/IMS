namespace PresentationLayer.Views.UserControls
{
    partial class PurchaseSettingsView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tbCashBank = new TabPage();
            tbBranch = new TabPage();
            tcMain = new Guna.UI2.WinForms.Guna2TabControl();
            tbPaymentType = new TabPage();
            tbVendorType = new TabPage();
            tbPurchaseType = new TabPage();
            tbBillType = new TabPage();
            tcMain.SuspendLayout();
            SuspendLayout();
            // 
            // tbCashBank
            // 
            tbCashBank.Location = new Point(4, 44);
            tbCashBank.Margin = new Padding(3, 2, 3, 2);
            tbCashBank.Name = "tbCashBank";
            tbCashBank.Padding = new Padding(3, 2, 3, 2);
            tbCashBank.Size = new Size(1660, 686);
            tbCashBank.TabIndex = 1;
            tbCashBank.Text = "Cash Bank";
            tbCashBank.UseVisualStyleBackColor = true;
            // 
            // tbBranch
            // 
            tbBranch.Location = new Point(4, 44);
            tbBranch.Margin = new Padding(3, 2, 3, 2);
            tbBranch.Name = "tbBranch";
            tbBranch.Padding = new Padding(3, 2, 3, 2);
            tbBranch.Size = new Size(1660, 686);
            tbBranch.TabIndex = 0;
            tbBranch.Text = "Branch";
            tbBranch.UseVisualStyleBackColor = true;
            // 
            // tcMain
            // 
            tcMain.Controls.Add(tbBranch);
            tcMain.Controls.Add(tbCashBank);
            tcMain.Controls.Add(tbPaymentType);
            tcMain.Controls.Add(tbVendorType);
            tcMain.Controls.Add(tbPurchaseType);
            tcMain.Controls.Add(tbBillType);
            tcMain.Dock = DockStyle.Fill;
            tcMain.ItemSize = new Size(180, 40);
            tcMain.Location = new Point(0, 0);
            tcMain.Margin = new Padding(3, 2, 3, 2);
            tcMain.Name = "tcMain";
            tcMain.SelectedIndex = 0;
            tcMain.Size = new Size(1668, 734);
            tcMain.TabButtonHoverState.BorderColor = Color.Empty;
            tcMain.TabButtonHoverState.FillColor = Color.FromArgb(40, 52, 70);
            tcMain.TabButtonHoverState.Font = new Font("Segoe UI Semibold", 10F);
            tcMain.TabButtonHoverState.ForeColor = Color.White;
            tcMain.TabButtonHoverState.InnerColor = Color.FromArgb(40, 52, 70);
            tcMain.TabButtonIdleState.BorderColor = Color.Empty;
            tcMain.TabButtonIdleState.FillColor = Color.FromArgb(33, 42, 57);
            tcMain.TabButtonIdleState.Font = new Font("Segoe UI Semibold", 10F);
            tcMain.TabButtonIdleState.ForeColor = Color.FromArgb(156, 160, 167);
            tcMain.TabButtonIdleState.InnerColor = Color.FromArgb(33, 42, 57);
            tcMain.TabButtonSelectedState.BorderColor = Color.Empty;
            tcMain.TabButtonSelectedState.FillColor = Color.FromArgb(29, 37, 49);
            tcMain.TabButtonSelectedState.Font = new Font("Segoe UI Semibold", 10F);
            tcMain.TabButtonSelectedState.ForeColor = Color.White;
            tcMain.TabButtonSelectedState.InnerColor = Color.FromArgb(76, 132, 255);
            tcMain.TabButtonSize = new Size(180, 40);
            tcMain.TabIndex = 0;
            tcMain.TabMenuBackColor = Color.FromArgb(33, 42, 57);
            tcMain.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalTop;
            // 
            // tbPaymentType
            // 
            tbPaymentType.Location = new Point(4, 44);
            tbPaymentType.Margin = new Padding(3, 2, 3, 2);
            tbPaymentType.Name = "tbPaymentType";
            tbPaymentType.Size = new Size(1660, 686);
            tbPaymentType.TabIndex = 2;
            tbPaymentType.Text = "Payment Type";
            tbPaymentType.UseVisualStyleBackColor = true;
            // 
            // tbVendorType
            // 
            tbVendorType.Location = new Point(4, 44);
            tbVendorType.Margin = new Padding(3, 2, 3, 2);
            tbVendorType.Name = "tbVendorType";
            tbVendorType.Size = new Size(1660, 686);
            tbVendorType.TabIndex = 3;
            tbVendorType.Text = "Vendor Type";
            tbVendorType.UseVisualStyleBackColor = true;
            // 
            // tbPurchaseType
            // 
            tbPurchaseType.Location = new Point(4, 44);
            tbPurchaseType.Margin = new Padding(3, 2, 3, 2);
            tbPurchaseType.Name = "tbPurchaseType";
            tbPurchaseType.Size = new Size(1660, 686);
            tbPurchaseType.TabIndex = 4;
            tbPurchaseType.Text = "Purchase Type";
            tbPurchaseType.UseVisualStyleBackColor = true;
            // 
            // tbBillType
            // 
            tbBillType.Location = new Point(4, 44);
            tbBillType.Margin = new Padding(3, 2, 3, 2);
            tbBillType.Name = "tbBillType";
            tbBillType.Size = new Size(1660, 686);
            tbBillType.TabIndex = 5;
            tbBillType.Text = "Bill Type";
            tbBillType.UseVisualStyleBackColor = true;
            // 
            // PurchaseSettingsView
            // 
            AutoScaleMode = AutoScaleMode.Inherit;
            Controls.Add(tcMain);
            Margin = new Padding(3, 2, 3, 2);
            Name = "PurchaseSettingsView";
            Size = new Size(1668, 734);
            tcMain.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabPage tbCashBank;
        private TabPage tbBranch;
        private Guna.UI2.WinForms.Guna2TabControl tcMain;
        private TabPage tbPaymentType;
        private TabPage tbVendorType;
        private TabPage tbPurchaseType;
        private TabPage tbBillType;
    }
}
