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
            tbProfile = new TabPage();
            tbRegister = new TabPage();
            tbInventory = new TabPage();
            contextMenuStrip1 = new ContextMenuStrip(components);
            sampleToolStripMenuItem = new ToolStripMenuItem();
            sampleToolStripMenuItem1 = new ToolStripMenuItem();
            sampleToolStripMenuItem3 = new ToolStripMenuItem();
            sampleToolStripMenuItem4 = new ToolStripMenuItem();
            sampleToolStripMenuItem2 = new ToolStripMenuItem();
            tbPayroll = new TabPage();
            tcMain.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
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
            tcMain.Font = new Font("Segoe UI", 12F);
            tcMain.ImageList = imageList1;
            tcMain.Location = new Point(3, 64);
            tcMain.Margin = new Padding(3, 2, 3, 2);
            tcMain.MouseState = MaterialSkin.MouseState.HOVER;
            tcMain.Multiline = true;
            tcMain.Name = "tcMain";
            tcMain.SelectedIndex = 0;
            tcMain.Size = new Size(1203, 521);
            tcMain.TabIndex = 4;
            // 
            // tbProfile
            // 
            tbProfile.Location = new Point(4, 30);
            tbProfile.Margin = new Padding(3, 2, 3, 2);
            tbProfile.Name = "tbProfile";
            tbProfile.Size = new Size(1195, 487);
            tbProfile.TabIndex = 3;
            tbProfile.Text = "Profile";
            tbProfile.UseVisualStyleBackColor = true;
            // 
            // tbRegister
            // 
            tbRegister.Location = new Point(4, 30);
            tbRegister.Margin = new Padding(3, 2, 3, 2);
            tbRegister.Name = "tbRegister";
            tbRegister.Size = new Size(1195, 487);
            tbRegister.TabIndex = 0;
            tbRegister.Text = "User Account";
            tbRegister.UseVisualStyleBackColor = true;
            // 
            // tbInventory
            // 
            tbInventory.AllowDrop = true;
            tbInventory.ContextMenuStrip = contextMenuStrip1;
            tbInventory.Location = new Point(4, 30);
            tbInventory.Margin = new Padding(3, 2, 3, 2);
            tbInventory.Name = "tbInventory";
            tbInventory.Size = new Size(1195, 487);
            tbInventory.TabIndex = 1;
            tbInventory.Text = "Inventory";
            tbInventory.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { sampleToolStripMenuItem, sampleToolStripMenuItem1, sampleToolStripMenuItem2 });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(114, 70);
            // 
            // sampleToolStripMenuItem
            // 
            sampleToolStripMenuItem.Name = "sampleToolStripMenuItem";
            sampleToolStripMenuItem.Size = new Size(113, 22);
            sampleToolStripMenuItem.Text = "Sample";
            // 
            // sampleToolStripMenuItem1
            // 
            sampleToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { sampleToolStripMenuItem3, sampleToolStripMenuItem4 });
            sampleToolStripMenuItem1.Name = "sampleToolStripMenuItem1";
            sampleToolStripMenuItem1.Size = new Size(113, 22);
            sampleToolStripMenuItem1.Text = "Sample";
            // 
            // sampleToolStripMenuItem3
            // 
            sampleToolStripMenuItem3.Name = "sampleToolStripMenuItem3";
            sampleToolStripMenuItem3.Size = new Size(113, 22);
            sampleToolStripMenuItem3.Text = "Sample";
            // 
            // sampleToolStripMenuItem4
            // 
            sampleToolStripMenuItem4.Name = "sampleToolStripMenuItem4";
            sampleToolStripMenuItem4.Size = new Size(113, 22);
            sampleToolStripMenuItem4.Text = "Sample";
            // 
            // sampleToolStripMenuItem2
            // 
            sampleToolStripMenuItem2.Name = "sampleToolStripMenuItem2";
            sampleToolStripMenuItem2.Size = new Size(113, 22);
            sampleToolStripMenuItem2.Text = "Sample";
            // 
            // tbPayroll
            // 
            tbPayroll.Location = new Point(4, 30);
            tbPayroll.Margin = new Padding(3, 2, 3, 2);
            tbPayroll.Name = "tbPayroll";
            tbPayroll.Size = new Size(1195, 487);
            tbPayroll.TabIndex = 2;
            tbPayroll.Text = "Payroll";
            tbPayroll.UseVisualStyleBackColor = true;
            // 
            // AdminView
            // 
            AutoScaleMode = AutoScaleMode.Inherit;
            AutoScroll = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(1209, 588);
            Controls.Add(tcMain);
            DrawerAutoHide = false;
            DrawerAutoShow = true;
            DrawerTabControl = tcMain;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AdminView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Admin Management System";
            WindowState = FormWindowState.Maximized;
            FormClosing += AdminView_FormClosing;
            Load += AdminView_Load;
            tcMain.ResumeLayout(false);
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private ImageList imageList1;
        private MaterialSkin.Controls.MaterialTabControl tcMain;
        private TabPage tbRegister;
        private TabPage tbInventory;
        private TabPage tbPayroll;
        private TabPage tbProfile;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem sampleToolStripMenuItem;
        private ToolStripMenuItem sampleToolStripMenuItem1;
        private ToolStripMenuItem sampleToolStripMenuItem3;
        private ToolStripMenuItem sampleToolStripMenuItem4;
        private ToolStripMenuItem sampleToolStripMenuItem2;
    }
}