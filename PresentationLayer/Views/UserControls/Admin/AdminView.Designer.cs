namespace PresentationLayer.Views
{
    partial class AdminView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminView));
            imageList1 = new ImageList(components);
            tcMain = new MaterialSkin.Controls.MaterialTabControl();
            tbRegister = new TabPage();
            tbInventory = new TabPage();
            tbPayroll = new TabPage();
            tbProfile = new TabPage();
            tcMain.SuspendLayout();
            SuspendLayout();
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
            // tcMain
            // 
            tcMain.Controls.Add(tbProfile);
            tcMain.Controls.Add(tbRegister);
            tcMain.Controls.Add(tbInventory);
            tcMain.Controls.Add(tbPayroll);
            tcMain.Depth = 0;
            tcMain.Dock = DockStyle.Fill;
            tcMain.ImageList = imageList1;
            tcMain.Location = new Point(3, 64);
            tcMain.MouseState = MaterialSkin.MouseState.HOVER;
            tcMain.Multiline = true;
            tcMain.Name = "tcMain";
            tcMain.SelectedIndex = 0;
            tcMain.Size = new Size(1914, 1012);
            tcMain.TabIndex = 4;
            // 
            // tbRegister
            // 
            tbRegister.Location = new Point(4, 29);
            tbRegister.Name = "tbRegister";
            tbRegister.Size = new Size(1906, 979);
            tbRegister.TabIndex = 0;
            tbRegister.Text = "Register Account";
            tbRegister.UseVisualStyleBackColor = true;
            // 
            // tbInventory
            // 
            tbInventory.Location = new Point(4, 29);
            tbInventory.Name = "tbInventory";
            tbInventory.Size = new Size(1906, 979);
            tbInventory.TabIndex = 1;
            tbInventory.Text = "Inventory";
            tbInventory.UseVisualStyleBackColor = true;
            // 
            // tbPayroll
            // 
            tbPayroll.Location = new Point(4, 29);
            tbPayroll.Name = "tbPayroll";
            tbPayroll.Size = new Size(1906, 979);
            tbPayroll.TabIndex = 2;
            tbPayroll.Text = "Payroll";
            tbPayroll.UseVisualStyleBackColor = true;
            // 
            // tbProfile
            // 
            tbProfile.Location = new Point(4, 29);
            tbProfile.Name = "tbProfile";
            tbProfile.Size = new Size(1906, 979);
            tbProfile.TabIndex = 3;
            tbProfile.Text = "Profile";
            tbProfile.UseVisualStyleBackColor = true;
            // 
            // AdminView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1920, 1080);
            Controls.Add(tcMain);
            DrawerAutoShow = true;
            DrawerShowIconsWhenHidden = true;
            DrawerTabControl = tcMain;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            Name = "AdminView";
            Padding = new Padding(3, 64, 3, 4);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Admin Management System";
            tcMain.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private ImageList imageList1;
        private MaterialSkin.Controls.MaterialTabControl tcMain;
        private TabPage tbRegister;
        private TabPage tbInventory;
        private TabPage tbPayroll;
        private TabPage tbProfile;
    }
}