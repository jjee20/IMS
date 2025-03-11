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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InventoryView));
            tbInventory = new TabPage();
            tbPurchase = new TabPage();
            tbSales = new TabPage();
            tbDashboard = new TabPage();
            tcMain = new MaterialSkin.Controls.MaterialTabControl();
            tbProject = new TabPage();
            tbTargetGoals = new TabPage();
            tbSettings = new TabPage();
            tbSalesReport = new TabPage();
            tbPurchaseReport = new TabPage();
            tcMain.SuspendLayout();
            SuspendLayout();
            // 
            // tbInventory
            // 
            tbInventory.ImageKey = "(none)";
            tbInventory.Location = new Point(4, 24);
            tbInventory.Margin = new Padding(3, 2, 3, 2);
            tbInventory.Name = "tbInventory";
            tbInventory.Size = new Size(1352, 689);
            tbInventory.TabIndex = 4;
            tbInventory.Text = "Product/Service";
            tbInventory.UseVisualStyleBackColor = true;
            // 
            // tbPurchase
            // 
            tbPurchase.ImageKey = "(none)";
            tbPurchase.Location = new Point(4, 24);
            tbPurchase.Margin = new Padding(3, 2, 3, 2);
            tbPurchase.Name = "tbPurchase";
            tbPurchase.Size = new Size(1352, 689);
            tbPurchase.TabIndex = 3;
            tbPurchase.Text = "Purchase Listing";
            tbPurchase.UseVisualStyleBackColor = true;
            // 
            // tbSales
            // 
            tbSales.ImageKey = "(none)";
            tbSales.Location = new Point(4, 24);
            tbSales.Margin = new Padding(3, 2, 3, 2);
            tbSales.Name = "tbSales";
            tbSales.Size = new Size(1352, 689);
            tbSales.TabIndex = 2;
            tbSales.Text = "Sales Listing";
            tbSales.UseVisualStyleBackColor = true;
            // 
            // tbDashboard
            // 
            tbDashboard.ImageKey = "(none)";
            tbDashboard.Location = new Point(4, 24);
            tbDashboard.Margin = new Padding(3, 2, 3, 2);
            tbDashboard.Name = "tbDashboard";
            tbDashboard.Padding = new Padding(3, 2, 3, 2);
            tbDashboard.Size = new Size(1352, 689);
            tbDashboard.TabIndex = 1;
            tbDashboard.Text = "Dashboard";
            tbDashboard.UseVisualStyleBackColor = true;
            // 
            // tcMain
            // 
            tcMain.Controls.Add(tbDashboard);
            tcMain.Controls.Add(tbInventory);
            tcMain.Controls.Add(tbSales);
            tcMain.Controls.Add(tbPurchase);
            tcMain.Controls.Add(tbProject);
            tcMain.Controls.Add(tbSalesReport);
            tcMain.Controls.Add(tbPurchaseReport);
            tcMain.Controls.Add(tbTargetGoals);
            tcMain.Controls.Add(tbSettings);
            tcMain.Depth = 0;
            tcMain.Dock = DockStyle.Fill;
            tcMain.Location = new Point(3, 48);
            tcMain.Margin = new Padding(3, 2, 3, 2);
            tcMain.MouseState = MaterialSkin.MouseState.HOVER;
            tcMain.Multiline = true;
            tcMain.Name = "tcMain";
            tcMain.SelectedIndex = 0;
            tcMain.Size = new Size(1360, 717);
            tcMain.TabIndex = 4;
            // 
            // tbProject
            // 
            tbProject.Location = new Point(4, 24);
            tbProject.Name = "tbProject";
            tbProject.Padding = new Padding(3);
            tbProject.Size = new Size(1352, 689);
            tbProject.TabIndex = 5;
            tbProject.Text = "Project Listing";
            tbProject.UseVisualStyleBackColor = true;
            // 
            // tbTargetGoals
            // 
            tbTargetGoals.Location = new Point(4, 24);
            tbTargetGoals.Name = "tbTargetGoals";
            tbTargetGoals.Size = new Size(1352, 689);
            tbTargetGoals.TabIndex = 6;
            tbTargetGoals.Text = "Target Goals";
            tbTargetGoals.UseVisualStyleBackColor = true;
            // 
            // tbSettings
            // 
            tbSettings.Location = new Point(4, 24);
            tbSettings.Name = "tbSettings";
            tbSettings.Size = new Size(1352, 689);
            tbSettings.TabIndex = 7;
            tbSettings.Text = "Settings";
            tbSettings.UseVisualStyleBackColor = true;
            // 
            // tbSalesReport
            // 
            tbSalesReport.Location = new Point(4, 24);
            tbSalesReport.Name = "tbSalesReport";
            tbSalesReport.Size = new Size(1352, 689);
            tbSalesReport.TabIndex = 8;
            tbSalesReport.Text = "Sales Report";
            tbSalesReport.UseVisualStyleBackColor = true;
            // 
            // tbPurchaseReport
            // 
            tbPurchaseReport.Location = new Point(4, 24);
            tbPurchaseReport.Name = "tbPurchaseReport";
            tbPurchaseReport.Size = new Size(1352, 689);
            tbPurchaseReport.TabIndex = 9;
            tbPurchaseReport.Text = "Purchase Report";
            tbPurchaseReport.UseVisualStyleBackColor = true;
            // 
            // InventoryView
            // 
            AutoScaleMode = AutoScaleMode.Inherit;
            AutoScroll = true;
            ClientSize = new Size(1366, 768);
            Controls.Add(tcMain);
            DrawerAutoShow = true;
            DrawerTabControl = tcMain;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "InventoryView";
            Padding = new Padding(3, 48, 3, 3);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Inventory Management System";
            WindowState = FormWindowState.Maximized;
            FormClosing += InventoryView_FormClosing;
            tcMain.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private TabPage tbInventory;
        private TabPage tbPurchase;
        private TabPage tbSales;
        private TabPage tbDashboard;
        private MaterialSkin.Controls.MaterialTabControl tcMain;
        private TabPage tbProject;
        private TabPage tbTargetGoals;
        private TabPage tbSettings;
        private TabPage tbSalesReport;
        private TabPage tbPurchaseReport;
    }
}