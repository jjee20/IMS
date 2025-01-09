namespace PresentationLayer.Views.UserControls
{
    partial class SalesSettingsView
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
            tbCustomerType = new TabPage();
            tcMain = new Guna.UI2.WinForms.Guna2TabControl();
            tbSalesType = new TabPage();
            tbShipmentType = new TabPage();
            tbInvoiceType = new TabPage();
            tcMain.SuspendLayout();
            SuspendLayout();
            // 
            // tbCustomerType
            // 
            tbCustomerType.Location = new Point(4, 44);
            tbCustomerType.Margin = new Padding(4, 3, 4, 3);
            tbCustomerType.Name = "tbCustomerType";
            tbCustomerType.Padding = new Padding(4, 3, 4, 3);
            tbCustomerType.Size = new Size(1699, 912);
            tbCustomerType.TabIndex = 1;
            tbCustomerType.Text = "Customer Type";
            tbCustomerType.UseVisualStyleBackColor = true;
            // 
            // tcMain
            // 
            tcMain.Controls.Add(tbSalesType);
            tcMain.Controls.Add(tbCustomerType);
            tcMain.Controls.Add(tbShipmentType);
            tcMain.Controls.Add(tbInvoiceType);
            tcMain.Dock = DockStyle.Fill;
            tcMain.ItemSize = new Size(180, 40);
            tcMain.Location = new Point(0, 0);
            tcMain.Margin = new Padding(4, 3, 4, 3);
            tcMain.Name = "tcMain";
            tcMain.SelectedIndex = 0;
            tcMain.Size = new Size(1707, 960);
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
            // tbSalesType
            // 
            tbSalesType.Location = new Point(4, 44);
            tbSalesType.Margin = new Padding(4, 3, 4, 3);
            tbSalesType.Name = "tbSalesType";
            tbSalesType.Size = new Size(1699, 912);
            tbSalesType.TabIndex = 2;
            tbSalesType.Text = "Sales Type";
            tbSalesType.UseVisualStyleBackColor = true;
            // 
            // tbShipmentType
            // 
            tbShipmentType.Location = new Point(4, 44);
            tbShipmentType.Margin = new Padding(4, 3, 4, 3);
            tbShipmentType.Name = "tbShipmentType";
            tbShipmentType.Size = new Size(1699, 912);
            tbShipmentType.TabIndex = 3;
            tbShipmentType.Text = "Shipment Type";
            tbShipmentType.UseVisualStyleBackColor = true;
            // 
            // tbInvoiceType
            // 
            tbInvoiceType.Location = new Point(4, 44);
            tbInvoiceType.Margin = new Padding(4, 3, 4, 3);
            tbInvoiceType.Name = "tbInvoiceType";
            tbInvoiceType.Size = new Size(1699, 912);
            tbInvoiceType.TabIndex = 4;
            tbInvoiceType.Text = "Invoice Type";
            tbInvoiceType.UseVisualStyleBackColor = true;
            // 
            // SalesSettingsView
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tcMain);
            Margin = new Padding(4, 3, 4, 3);
            Name = "SalesSettingsView";
            Size = new Size(1707, 960);
            tcMain.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabPage tbCustomerType;
        private Guna.UI2.WinForms.Guna2TabControl tcMain;
        private TabPage tbSalesType;
        private TabPage tbShipmentType;
        private TabPage tbInvoiceType;
    }
}
