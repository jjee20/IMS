namespace PresentationLayer.Views.UserControls
{
    partial class ConfigurationView
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigurationView));
            tcConfiguration = new TabControl();
            tbCurrency = new TabPage();
            tbBranch = new TabPage();
            tbWarehouse = new TabPage();
            tbCashBank = new TabPage();
            tbPaymentType = new TabPage();
            tbShipmentType = new TabPage();
            tbInvoiceType = new TabPage();
            tbBillType = new TabPage();
            imageList1 = new ImageList(components);
            tcConfiguration.SuspendLayout();
            SuspendLayout();
            // 
            // tcConfiguration
            // 
            tcConfiguration.Controls.Add(tbCurrency);
            tcConfiguration.Controls.Add(tbBranch);
            tcConfiguration.Controls.Add(tbWarehouse);
            tcConfiguration.Controls.Add(tbCashBank);
            tcConfiguration.Controls.Add(tbPaymentType);
            tcConfiguration.Controls.Add(tbShipmentType);
            tcConfiguration.Controls.Add(tbInvoiceType);
            tcConfiguration.Controls.Add(tbBillType);
            tcConfiguration.Dock = DockStyle.Fill;
            tcConfiguration.ImageList = imageList1;
            tcConfiguration.Location = new Point(0, 0);
            tcConfiguration.Name = "tcConfiguration";
            tcConfiguration.SelectedIndex = 0;
            tcConfiguration.Size = new Size(1355, 653);
            tcConfiguration.TabIndex = 0;
            // 
            // tbCurrency
            // 
            tbCurrency.ImageKey = "Currency.png";
            tbCurrency.Location = new Point(4, 24);
            tbCurrency.Name = "tbCurrency";
            tbCurrency.Padding = new Padding(3);
            tbCurrency.Size = new Size(1347, 625);
            tbCurrency.TabIndex = 0;
            tbCurrency.Text = "Currency";
            tbCurrency.UseVisualStyleBackColor = true;
            // 
            // tbBranch
            // 
            tbBranch.ImageKey = "branch.png";
            tbBranch.Location = new Point(4, 24);
            tbBranch.Name = "tbBranch";
            tbBranch.Padding = new Padding(3);
            tbBranch.Size = new Size(1347, 625);
            tbBranch.TabIndex = 1;
            tbBranch.Text = "Branch";
            tbBranch.UseVisualStyleBackColor = true;
            // 
            // tbWarehouse
            // 
            tbWarehouse.ImageKey = "warehouse.png";
            tbWarehouse.Location = new Point(4, 24);
            tbWarehouse.Name = "tbWarehouse";
            tbWarehouse.Size = new Size(1347, 625);
            tbWarehouse.TabIndex = 2;
            tbWarehouse.Text = "Warehouse";
            tbWarehouse.UseVisualStyleBackColor = true;
            // 
            // tbCashBank
            // 
            tbCashBank.ImageKey = "cash-bank.png";
            tbCashBank.Location = new Point(4, 24);
            tbCashBank.Name = "tbCashBank";
            tbCashBank.Size = new Size(1347, 625);
            tbCashBank.TabIndex = 3;
            tbCashBank.Text = "CashBank";
            tbCashBank.UseVisualStyleBackColor = true;
            // 
            // tbPaymentType
            // 
            tbPaymentType.ImageKey = "payment-type.png";
            tbPaymentType.Location = new Point(4, 24);
            tbPaymentType.Name = "tbPaymentType";
            tbPaymentType.Size = new Size(1347, 625);
            tbPaymentType.TabIndex = 4;
            tbPaymentType.Text = "Payment Type";
            tbPaymentType.UseVisualStyleBackColor = true;
            // 
            // tbShipmentType
            // 
            tbShipmentType.ImageKey = "shipment-type.png";
            tbShipmentType.Location = new Point(4, 24);
            tbShipmentType.Name = "tbShipmentType";
            tbShipmentType.Size = new Size(1347, 625);
            tbShipmentType.TabIndex = 5;
            tbShipmentType.Text = "Shipment Type";
            tbShipmentType.UseVisualStyleBackColor = true;
            // 
            // tbInvoiceType
            // 
            tbInvoiceType.ImageKey = "invoice-type.png";
            tbInvoiceType.Location = new Point(4, 24);
            tbInvoiceType.Name = "tbInvoiceType";
            tbInvoiceType.Size = new Size(1347, 625);
            tbInvoiceType.TabIndex = 6;
            tbInvoiceType.Text = "Invoice Type";
            tbInvoiceType.UseVisualStyleBackColor = true;
            // 
            // tbBillType
            // 
            tbBillType.ImageKey = "bill-type.png";
            tbBillType.Location = new Point(4, 24);
            tbBillType.Name = "tbBillType";
            tbBillType.Size = new Size(1347, 625);
            tbBillType.TabIndex = 7;
            tbBillType.Text = "Bill Type";
            tbBillType.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "bill-type.png");
            imageList1.Images.SetKeyName(1, "branch.png");
            imageList1.Images.SetKeyName(2, "cash-bank.png");
            imageList1.Images.SetKeyName(3, "Currency.png");
            imageList1.Images.SetKeyName(4, "invoice-type.png");
            imageList1.Images.SetKeyName(5, "payment-type.png");
            imageList1.Images.SetKeyName(6, "shipment-type.png");
            imageList1.Images.SetKeyName(7, "warehouse.png");
            // 
            // ConfigurationView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tcConfiguration);
            Name = "ConfigurationView";
            Size = new Size(1355, 653);
            tcConfiguration.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tcConfiguration;
        private TabPage tbCurrency;
        private TabPage tbBranch;
        private TabPage tbWarehouse;
        private TabPage tbCashBank;
        private TabPage tbPaymentType;
        private TabPage tbShipmentType;
        private TabPage tbInvoiceType;
        private TabPage tbBillType;
        private ImageList imageList1;
    }
}
