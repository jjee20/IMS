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
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            tcConfiguration.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            materialCard1.SuspendLayout();
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
            tcConfiguration.Location = new Point(14, 64);
            tcConfiguration.Name = "tcConfiguration";
            tcConfiguration.SelectedIndex = 0;
            tcConfiguration.Size = new Size(1327, 575);
            tcConfiguration.TabIndex = 0;
            // 
            // tbCurrency
            // 
            tbCurrency.ImageKey = "Currency.png";
            tbCurrency.Location = new Point(4, 24);
            tbCurrency.Name = "tbCurrency";
            tbCurrency.Padding = new Padding(3);
            tbCurrency.Size = new Size(1319, 547);
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
            tbBranch.Size = new Size(1319, 547);
            tbBranch.TabIndex = 1;
            tbBranch.Text = "Branch";
            tbBranch.UseVisualStyleBackColor = true;
            // 
            // tbWarehouse
            // 
            tbWarehouse.ImageKey = "warehouse.png";
            tbWarehouse.Location = new Point(4, 24);
            tbWarehouse.Name = "tbWarehouse";
            tbWarehouse.Size = new Size(1319, 547);
            tbWarehouse.TabIndex = 2;
            tbWarehouse.Text = "Warehouse";
            tbWarehouse.UseVisualStyleBackColor = true;
            // 
            // tbCashBank
            // 
            tbCashBank.ImageKey = "cash-bank.png";
            tbCashBank.Location = new Point(4, 24);
            tbCashBank.Name = "tbCashBank";
            tbCashBank.Size = new Size(1319, 547);
            tbCashBank.TabIndex = 3;
            tbCashBank.Text = "Cash Bank";
            tbCashBank.UseVisualStyleBackColor = true;
            // 
            // tbPaymentType
            // 
            tbPaymentType.ImageKey = "payment-type.png";
            tbPaymentType.Location = new Point(4, 24);
            tbPaymentType.Name = "tbPaymentType";
            tbPaymentType.Size = new Size(1319, 547);
            tbPaymentType.TabIndex = 4;
            tbPaymentType.Text = "Payment Type";
            tbPaymentType.UseVisualStyleBackColor = true;
            // 
            // tbShipmentType
            // 
            tbShipmentType.ImageKey = "shipment-type.png";
            tbShipmentType.Location = new Point(4, 24);
            tbShipmentType.Name = "tbShipmentType";
            tbShipmentType.Size = new Size(1319, 547);
            tbShipmentType.TabIndex = 5;
            tbShipmentType.Text = "Shipment Type";
            tbShipmentType.UseVisualStyleBackColor = true;
            // 
            // tbInvoiceType
            // 
            tbInvoiceType.ImageKey = "invoice-type.png";
            tbInvoiceType.Location = new Point(4, 24);
            tbInvoiceType.Name = "tbInvoiceType";
            tbInvoiceType.Size = new Size(1319, 547);
            tbInvoiceType.TabIndex = 6;
            tbInvoiceType.Text = "Invoice Type";
            tbInvoiceType.UseVisualStyleBackColor = true;
            // 
            // tbBillType
            // 
            tbBillType.ImageKey = "bill-type.png";
            tbBillType.Location = new Point(4, 24);
            tbBillType.Name = "tbBillType";
            tbBillType.Size = new Size(1319, 547);
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
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(14, 14);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 76F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 24F));
            tableLayoutPanel1.Size = new Size(1327, 50);
            tableLayoutPanel1.TabIndex = 6;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.BackColor = Color.FromArgb(187, 226, 236);
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(materialLabel1, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Margin = new Padding(0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(1327, 38);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Dock = DockStyle.Left;
            materialLabel1.Font = new Font("Roboto", 24F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialLabel1.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            materialLabel1.ForeColor = Color.FromArgb(255, 246, 233);
            materialLabel1.ImageAlign = ContentAlignment.MiddleLeft;
            materialLabel1.Location = new Point(3, 0);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(146, 38);
            materialLabel1.TabIndex = 3;
            materialLabel1.Text = "Configuration";
            materialLabel1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // materialCard1
            // 
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(tcConfiguration);
            materialCard1.Controls.Add(tableLayoutPanel1);
            materialCard1.Depth = 0;
            materialCard1.Dock = DockStyle.Fill;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(0, 0);
            materialCard1.Margin = new Padding(14);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(14);
            materialCard1.Size = new Size(1355, 653);
            materialCard1.TabIndex = 0;
            // 
            // ConfigurationView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(materialCard1);
            Name = "ConfigurationView";
            Size = new Size(1355, 653);
            tcConfiguration.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            materialCard1.ResumeLayout(false);
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
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialCard materialCard1;
    }
}
