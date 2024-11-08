namespace PresentationLayer.Views
{
    partial class InventoryView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InventoryView));
            tcMain = new MaterialSkin.Controls.MaterialTabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            tabPage3 = new TabPage();
            tbCustomerType = new TabPage();
            tbCustomer = new TabPage();
            tabPage6 = new TabPage();
            tabPage7 = new TabPage();
            tabPage8 = new TabPage();
            tabPage9 = new TabPage();
            tabPage10 = new TabPage();
            tabPage11 = new TabPage();
            tabPage12 = new TabPage();
            tabPage13 = new TabPage();
            tabPage14 = new TabPage();
            tabPage15 = new TabPage();
            tabPage16 = new TabPage();
            tabPage17 = new TabPage();
            tabPage18 = new TabPage();
            tabPage19 = new TabPage();
            tabPage20 = new TabPage();
            tabPage21 = new TabPage();
            tabPage22 = new TabPage();
            tabPage23 = new TabPage();
            tabPage24 = new TabPage();
            imageList1 = new ImageList(components);
            tcMain.SuspendLayout();
            SuspendLayout();
            // 
            // tcMain
            // 
            tcMain.Controls.Add(tabPage1);
            tcMain.Controls.Add(tabPage2);
            tcMain.Controls.Add(tabPage3);
            tcMain.Controls.Add(tbCustomerType);
            tcMain.Controls.Add(tbCustomer);
            tcMain.Controls.Add(tabPage6);
            tcMain.Controls.Add(tabPage7);
            tcMain.Controls.Add(tabPage8);
            tcMain.Controls.Add(tabPage9);
            tcMain.Controls.Add(tabPage10);
            tcMain.Controls.Add(tabPage11);
            tcMain.Controls.Add(tabPage12);
            tcMain.Controls.Add(tabPage13);
            tcMain.Controls.Add(tabPage14);
            tcMain.Controls.Add(tabPage15);
            tcMain.Controls.Add(tabPage16);
            tcMain.Controls.Add(tabPage17);
            tcMain.Controls.Add(tabPage18);
            tcMain.Controls.Add(tabPage19);
            tcMain.Controls.Add(tabPage20);
            tcMain.Controls.Add(tabPage21);
            tcMain.Controls.Add(tabPage22);
            tcMain.Controls.Add(tabPage23);
            tcMain.Controls.Add(tabPage24);
            tcMain.Depth = 0;
            tcMain.Dock = DockStyle.Fill;
            tcMain.ImageList = imageList1;
            tcMain.Location = new Point(0, 64);
            tcMain.MouseState = MaterialSkin.MouseState.HOVER;
            tcMain.Multiline = true;
            tcMain.Name = "tcMain";
            tcMain.SelectedIndex = 0;
            tcMain.Size = new Size(1379, 740);
            tcMain.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.ImageKey = "user.png";
            tabPage1.Location = new Point(4, 44);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1371, 692);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "USER PROFILE";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.ImageKey = "dashboard.png";
            tabPage2.Location = new Point(4, 44);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1371, 692);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "DASHBOARD";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Location = new Point(4, 44);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(1371, 692);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "SALES";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // tbCustomerType
            // 
            tbCustomerType.ImageKey = "setting-1.png";
            tbCustomerType.Location = new Point(4, 44);
            tbCustomerType.Name = "tbCustomerType";
            tbCustomerType.Size = new Size(1371, 692);
            tbCustomerType.TabIndex = 3;
            tbCustomerType.Text = "Customer Type";
            tbCustomerType.UseVisualStyleBackColor = true;
            // 
            // tbCustomer
            // 
            tbCustomer.ImageKey = "customer.png";
            tbCustomer.Location = new Point(4, 44);
            tbCustomer.Name = "tbCustomer";
            tbCustomer.Size = new Size(1371, 692);
            tbCustomer.TabIndex = 4;
            tbCustomer.Text = "Customer";
            tbCustomer.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            tabPage6.ImageKey = "setting-2.png";
            tabPage6.Location = new Point(4, 44);
            tabPage6.Name = "tabPage6";
            tabPage6.Size = new Size(1371, 692);
            tabPage6.TabIndex = 5;
            tabPage6.Text = "Sales Type";
            tabPage6.UseVisualStyleBackColor = true;
            // 
            // tabPage7
            // 
            tabPage7.ImageKey = "sales-order.png";
            tabPage7.Location = new Point(4, 44);
            tabPage7.Name = "tabPage7";
            tabPage7.Size = new Size(1371, 692);
            tabPage7.TabIndex = 6;
            tabPage7.Text = "Sales Order";
            tabPage7.UseVisualStyleBackColor = true;
            // 
            // tabPage8
            // 
            tabPage8.ImageKey = "shipment.png";
            tabPage8.Location = new Point(4, 44);
            tabPage8.Name = "tabPage8";
            tabPage8.Size = new Size(1371, 692);
            tabPage8.TabIndex = 7;
            tabPage8.Text = "Shipment";
            tabPage8.UseVisualStyleBackColor = true;
            // 
            // tabPage9
            // 
            tabPage9.ImageKey = "invoice.png";
            tabPage9.Location = new Point(4, 44);
            tabPage9.Name = "tabPage9";
            tabPage9.Size = new Size(1371, 692);
            tabPage9.TabIndex = 8;
            tabPage9.Text = "Invoice";
            tabPage9.UseVisualStyleBackColor = true;
            // 
            // tabPage10
            // 
            tabPage10.ImageKey = "payment-receive.png";
            tabPage10.Location = new Point(4, 44);
            tabPage10.Name = "tabPage10";
            tabPage10.Size = new Size(1371, 692);
            tabPage10.TabIndex = 9;
            tabPage10.Text = "Payment Receive";
            tabPage10.UseVisualStyleBackColor = true;
            // 
            // tabPage11
            // 
            tabPage11.Location = new Point(4, 44);
            tabPage11.Name = "tabPage11";
            tabPage11.Size = new Size(1371, 692);
            tabPage11.TabIndex = 10;
            tabPage11.Text = "PURCHASE";
            tabPage11.UseVisualStyleBackColor = true;
            // 
            // tabPage12
            // 
            tabPage12.ImageKey = "setting-4.png";
            tabPage12.Location = new Point(4, 44);
            tabPage12.Name = "tabPage12";
            tabPage12.Size = new Size(1371, 692);
            tabPage12.TabIndex = 11;
            tabPage12.Text = "Vendor Type";
            tabPage12.UseVisualStyleBackColor = true;
            // 
            // tabPage13
            // 
            tabPage13.ImageKey = "vendor.png";
            tabPage13.Location = new Point(4, 44);
            tabPage13.Name = "tabPage13";
            tabPage13.Size = new Size(1371, 692);
            tabPage13.TabIndex = 12;
            tabPage13.Text = "Vendor";
            tabPage13.UseVisualStyleBackColor = true;
            // 
            // tabPage14
            // 
            tabPage14.ImageKey = "setting-3.png";
            tabPage14.Location = new Point(4, 44);
            tabPage14.Name = "tabPage14";
            tabPage14.Size = new Size(1371, 692);
            tabPage14.TabIndex = 13;
            tabPage14.Text = "Purchase Type";
            tabPage14.UseVisualStyleBackColor = true;
            // 
            // tabPage15
            // 
            tabPage15.ImageKey = "purchase-order.png";
            tabPage15.Location = new Point(4, 44);
            tabPage15.Name = "tabPage15";
            tabPage15.Size = new Size(1371, 692);
            tabPage15.TabIndex = 14;
            tabPage15.Text = "Purchase Order";
            tabPage15.UseVisualStyleBackColor = true;
            // 
            // tabPage16
            // 
            tabPage16.ImageKey = "goods-received-notes.png";
            tabPage16.Location = new Point(4, 44);
            tabPage16.Name = "tabPage16";
            tabPage16.Size = new Size(1371, 692);
            tabPage16.TabIndex = 15;
            tabPage16.Text = "Goods Received Note";
            tabPage16.UseVisualStyleBackColor = true;
            // 
            // tabPage17
            // 
            tabPage17.ImageKey = "bill.png";
            tabPage17.Location = new Point(4, 44);
            tabPage17.Name = "tabPage17";
            tabPage17.Size = new Size(1371, 692);
            tabPage17.TabIndex = 16;
            tabPage17.Text = "Bill";
            tabPage17.UseVisualStyleBackColor = true;
            // 
            // tabPage18
            // 
            tabPage18.ImageKey = "payment-voucher.png";
            tabPage18.Location = new Point(4, 44);
            tabPage18.Name = "tabPage18";
            tabPage18.Size = new Size(1371, 692);
            tabPage18.TabIndex = 17;
            tabPage18.Text = "Payment Voucher";
            tabPage18.UseVisualStyleBackColor = true;
            // 
            // tabPage19
            // 
            tabPage19.Location = new Point(4, 44);
            tabPage19.Name = "tabPage19";
            tabPage19.Size = new Size(1371, 692);
            tabPage19.TabIndex = 18;
            tabPage19.Text = "INVENTORY";
            tabPage19.UseVisualStyleBackColor = true;
            // 
            // tabPage20
            // 
            tabPage20.ImageKey = "setting-5.png";
            tabPage20.Location = new Point(4, 44);
            tabPage20.Name = "tabPage20";
            tabPage20.Size = new Size(1371, 692);
            tabPage20.TabIndex = 19;
            tabPage20.Text = "Product Type";
            tabPage20.UseVisualStyleBackColor = true;
            // 
            // tabPage21
            // 
            tabPage21.ImageKey = "product.png";
            tabPage21.Location = new Point(4, 44);
            tabPage21.Name = "tabPage21";
            tabPage21.Size = new Size(1371, 692);
            tabPage21.TabIndex = 20;
            tabPage21.Text = "Product";
            tabPage21.UseVisualStyleBackColor = true;
            // 
            // tabPage22
            // 
            tabPage22.ImageKey = "unit-of-measure.png";
            tabPage22.Location = new Point(4, 44);
            tabPage22.Name = "tabPage22";
            tabPage22.Size = new Size(1371, 692);
            tabPage22.TabIndex = 21;
            tabPage22.Text = "Unit of Measure";
            tabPage22.UseVisualStyleBackColor = true;
            // 
            // tabPage23
            // 
            tabPage23.Location = new Point(4, 44);
            tabPage23.Name = "tabPage23";
            tabPage23.Size = new Size(1371, 692);
            tabPage23.TabIndex = 22;
            tabPage23.Text = "CONFIGURATION";
            tabPage23.UseVisualStyleBackColor = true;
            // 
            // tabPage24
            // 
            tabPage24.Location = new Point(4, 44);
            tabPage24.Name = "tabPage24";
            tabPage24.Size = new Size(1371, 692);
            tabPage24.TabIndex = 23;
            tabPage24.Text = "USER & ROLE";
            tabPage24.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "bill.png");
            imageList1.Images.SetKeyName(1, "Configuration.png");
            imageList1.Images.SetKeyName(2, "create.png");
            imageList1.Images.SetKeyName(3, "customer.png");
            imageList1.Images.SetKeyName(4, "dashboard.png");
            imageList1.Images.SetKeyName(5, "editing.png");
            imageList1.Images.SetKeyName(6, "goods-received-notes.png");
            imageList1.Images.SetKeyName(7, "invoice.png");
            imageList1.Images.SetKeyName(8, "list.png");
            imageList1.Images.SetKeyName(9, "magnifying-glass.png");
            imageList1.Images.SetKeyName(10, "payment-receive.png");
            imageList1.Images.SetKeyName(11, "payment-voucher.png");
            imageList1.Images.SetKeyName(12, "product.png");
            imageList1.Images.SetKeyName(13, "purchase-order.png");
            imageList1.Images.SetKeyName(14, "sales-order.png");
            imageList1.Images.SetKeyName(15, "setting.png");
            imageList1.Images.SetKeyName(16, "setting-1.png");
            imageList1.Images.SetKeyName(17, "setting-2.png");
            imageList1.Images.SetKeyName(18, "setting-3.png");
            imageList1.Images.SetKeyName(19, "setting-4.png");
            imageList1.Images.SetKeyName(20, "setting-5.png");
            imageList1.Images.SetKeyName(21, "shipment.png");
            imageList1.Images.SetKeyName(22, "unit-of-measure.png");
            imageList1.Images.SetKeyName(23, "user.png");
            imageList1.Images.SetKeyName(24, "user-and-roles.png");
            imageList1.Images.SetKeyName(25, "vendor.png");
            // 
            // InventoryView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1382, 807);
            Controls.Add(tcMain);
            DrawerAutoShow = true;
            DrawerBackgroundWithAccent = true;
            DrawerIsOpen = true;
            DrawerShowIconsWhenHidden = true;
            DrawerTabControl = tcMain;
            Icon = (Icon)resources.GetObject("$this.Icon");
            IsMdiContainer = true;
            Name = "InventoryView";
            Padding = new Padding(0, 64, 3, 3);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Inventory Management System";
            tcMain.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl tcMain;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private ImageList imageList1;
        private TabPage tabPage3;
        private TabPage tbCustomerType;
        private TabPage tbCustomer;
        private TabPage tabPage6;
        private TabPage tabPage7;
        private TabPage tabPage8;
        private TabPage tabPage9;
        private TabPage tabPage10;
        private TabPage tabPage11;
        private TabPage tabPage12;
        private TabPage tabPage13;
        private TabPage tabPage14;
        private TabPage tabPage15;
        private TabPage tabPage16;
        private TabPage tabPage17;
        private TabPage tabPage18;
        private TabPage tabPage19;
        private TabPage tabPage20;
        private TabPage tabPage21;
        private TabPage tabPage22;
        private TabPage tabPage23;
        private TabPage tabPage24;
    }
}