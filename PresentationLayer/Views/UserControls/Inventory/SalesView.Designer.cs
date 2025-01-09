namespace PresentationLayer.Views.UserControls
{
    partial class SalesView
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
            tbCustomer = new TabPage();
            tbSalesOrder = new TabPage();
            tbShipment = new TabPage();
            tbInvoice = new TabPage();
            tbPaymentReceive = new TabPage();
            tbSettings = new TabPage();
            tcMain.SuspendLayout();
            SuspendLayout();
            // 
            // tcMain
            // 
            tcMain.Controls.Add(tbSalesOrder);
            tcMain.Controls.Add(tbCustomer);
            tcMain.Controls.Add(tbShipment);
            tcMain.Controls.Add(tbInvoice);
            tcMain.Controls.Add(tbPaymentReceive);
            tcMain.Controls.Add(tbSettings);
            tcMain.Dock = DockStyle.Fill;
            tcMain.ItemSize = new Size(180, 40);
            tcMain.Location = new Point(0, 0);
            tcMain.Name = "tcMain";
            tcMain.SelectedIndex = 0;
            tcMain.Size = new Size(1366, 768);
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
            // tbCustomer
            // 
            tbCustomer.Location = new Point(4, 44);
            tbCustomer.Name = "tbCustomer";
            tbCustomer.Padding = new Padding(3);
            tbCustomer.Size = new Size(1358, 720);
            tbCustomer.TabIndex = 0;
            tbCustomer.Text = "Customer";
            tbCustomer.UseVisualStyleBackColor = true;
            // 
            // tbSalesOrder
            // 
            tbSalesOrder.Location = new Point(4, 44);
            tbSalesOrder.Name = "tbSalesOrder";
            tbSalesOrder.Padding = new Padding(3);
            tbSalesOrder.Size = new Size(1358, 720);
            tbSalesOrder.TabIndex = 1;
            tbSalesOrder.Text = "Sales Order";
            tbSalesOrder.UseVisualStyleBackColor = true;
            // 
            // tbShipment
            // 
            tbShipment.Location = new Point(4, 44);
            tbShipment.Name = "tbShipment";
            tbShipment.Size = new Size(1358, 720);
            tbShipment.TabIndex = 2;
            tbShipment.Text = "Shipment";
            tbShipment.UseVisualStyleBackColor = true;
            // 
            // tbInvoice
            // 
            tbInvoice.Location = new Point(4, 44);
            tbInvoice.Name = "tbInvoice";
            tbInvoice.Size = new Size(1358, 720);
            tbInvoice.TabIndex = 3;
            tbInvoice.Text = "Sales Invoice";
            tbInvoice.UseVisualStyleBackColor = true;
            // 
            // tbPaymentReceive
            // 
            tbPaymentReceive.Location = new Point(4, 44);
            tbPaymentReceive.Name = "tbPaymentReceive";
            tbPaymentReceive.Size = new Size(1358, 720);
            tbPaymentReceive.TabIndex = 4;
            tbPaymentReceive.Text = "Payment Receive";
            tbPaymentReceive.UseVisualStyleBackColor = true;
            // 
            // tbSettings
            // 
            tbSettings.Location = new Point(4, 44);
            tbSettings.Name = "tbSettings";
            tbSettings.Size = new Size(1358, 720);
            tbSettings.TabIndex = 5;
            tbSettings.Text = "Settings";
            tbSettings.UseVisualStyleBackColor = true;
            // 
            // SalesView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tcMain);
            Name = "SalesView";
            Size = new Size(1366, 768);
            tcMain.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2TabControl tcMain;
        private TabPage tbCustomer;
        private TabPage tbSalesOrder;
        private TabPage tbShipment;
        private TabPage tbInvoice;
        private TabPage tbPaymentReceive;
        private TabPage tbSettings;
    }
}
