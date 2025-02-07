namespace PresentationLayer.Views.UserControls
{
    partial class PurchaseView
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
            tcMain = new Guna.UI2.WinForms.Guna2TabControl();
            tbPurchaseOrder = new TabPage();
            tbGoodsReceiveNote = new TabPage();
            tbBill = new TabPage();
            tbPaymentVoucher = new TabPage();
            tbVendor = new TabPage();
            tbSettings = new TabPage();
            tcMain.SuspendLayout();
            SuspendLayout();
            // 
            // tcMain
            // 
            tcMain.Controls.Add(tbPurchaseOrder);
            tcMain.Controls.Add(tbGoodsReceiveNote);
            tcMain.Controls.Add(tbBill);
            tcMain.Controls.Add(tbPaymentVoucher);
            tcMain.Controls.Add(tbVendor);
            tcMain.Controls.Add(tbSettings);
            tcMain.Dock = DockStyle.Fill;
            tcMain.ItemSize = new Size(180, 40);
            tcMain.Location = new Point(0, 0);
            tcMain.Margin = new Padding(3, 2, 3, 2);
            tcMain.Name = "tcMain";
            tcMain.SelectedIndex = 0;
            tcMain.Size = new Size(1667, 734);
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
            // tbPurchaseOrder
            // 
            tbPurchaseOrder.Location = new Point(4, 44);
            tbPurchaseOrder.Margin = new Padding(3, 2, 3, 2);
            tbPurchaseOrder.Name = "tbPurchaseOrder";
            tbPurchaseOrder.Padding = new Padding(3, 2, 3, 2);
            tbPurchaseOrder.Size = new Size(1659, 686);
            tbPurchaseOrder.TabIndex = 1;
            tbPurchaseOrder.Text = "Purchase Order";
            tbPurchaseOrder.UseVisualStyleBackColor = true;
            // 
            // tbGoodsReceiveNote
            // 
            tbGoodsReceiveNote.Location = new Point(4, 44);
            tbGoodsReceiveNote.Margin = new Padding(3, 2, 3, 2);
            tbGoodsReceiveNote.Name = "tbGoodsReceiveNote";
            tbGoodsReceiveNote.Size = new Size(1659, 686);
            tbGoodsReceiveNote.TabIndex = 2;
            tbGoodsReceiveNote.Text = "Goods Receive Note";
            tbGoodsReceiveNote.UseVisualStyleBackColor = true;
            // 
            // tbBill
            // 
            tbBill.Location = new Point(4, 44);
            tbBill.Margin = new Padding(3, 2, 3, 2);
            tbBill.Name = "tbBill";
            tbBill.Size = new Size(1659, 686);
            tbBill.TabIndex = 3;
            tbBill.Text = "Bill";
            tbBill.UseVisualStyleBackColor = true;
            // 
            // tbPaymentVoucher
            // 
            tbPaymentVoucher.Location = new Point(4, 44);
            tbPaymentVoucher.Margin = new Padding(3, 2, 3, 2);
            tbPaymentVoucher.Name = "tbPaymentVoucher";
            tbPaymentVoucher.Size = new Size(1659, 686);
            tbPaymentVoucher.TabIndex = 4;
            tbPaymentVoucher.Text = "Payment Voucher";
            tbPaymentVoucher.UseVisualStyleBackColor = true;
            // 
            // tbVendor
            // 
            tbVendor.Location = new Point(4, 44);
            tbVendor.Margin = new Padding(2, 2, 2, 2);
            tbVendor.Name = "tbVendor";
            tbVendor.Size = new Size(1659, 686);
            tbVendor.TabIndex = 6;
            tbVendor.Text = "Vendor";
            tbVendor.UseVisualStyleBackColor = true;
            // 
            // tbSettings
            // 
            tbSettings.Location = new Point(4, 44);
            tbSettings.Margin = new Padding(3, 2, 3, 2);
            tbSettings.Name = "tbSettings";
            tbSettings.Size = new Size(1659, 686);
            tbSettings.TabIndex = 5;
            tbSettings.Text = "Settings";
            tbSettings.UseVisualStyleBackColor = true;
            // 
            // PurchaseView
            // 
            AutoScaleMode = AutoScaleMode.Inherit;
            Controls.Add(tcMain);
            Margin = new Padding(3, 2, 3, 2);
            Name = "PurchaseView";
            Size = new Size(1667, 734);
            tcMain.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2TabControl tcMain;
        private TabPage tbPurchaseOrder;
        private TabPage tbGoodsReceiveNote;
        private TabPage tbBill;
        private TabPage tbPaymentVoucher;
        private TabPage tbSettings;
        private TabPage tbVendor;
    }
}
