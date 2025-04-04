﻿namespace PresentationLayer.Views.UserControls
{
    partial class ProductInventoryView
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
            tbProduct = new TabPage();
            tbStockIn = new TabPage();
            tbStockMonitoring = new TabPage();
            tbProductType = new TabPage();
            tbUnitOfMeasure = new TabPage();
            tcMain.SuspendLayout();
            SuspendLayout();
            // 
            // tcMain
            // 
            tcMain.Controls.Add(tbProduct);
            tcMain.Controls.Add(tbStockIn);
            tcMain.Controls.Add(tbStockMonitoring);
            tcMain.Controls.Add(tbProductType);
            tcMain.Controls.Add(tbUnitOfMeasure);
            tcMain.Dock = DockStyle.Fill;
            tcMain.ItemSize = new Size(180, 40);
            tcMain.Location = new Point(0, 0);
            tcMain.Margin = new Padding(3, 2, 3, 2);
            tcMain.Name = "tcMain";
            tcMain.SelectedIndex = 0;
            tcMain.Size = new Size(1356, 701);
            tcMain.TabButtonHoverState.BorderColor = Color.Empty;
            tcMain.TabButtonHoverState.FillColor = Color.FromArgb(40, 52, 70);
            tcMain.TabButtonHoverState.Font = new Font("Segoe UI Semibold", 10F);
            tcMain.TabButtonHoverState.ForeColor = Color.White;
            tcMain.TabButtonHoverState.InnerColor = Color.FromArgb(40, 52, 70);
            tcMain.TabButtonIdleState.BorderColor = Color.Empty;
            tcMain.TabButtonIdleState.FillColor = Color.Transparent;
            tcMain.TabButtonIdleState.Font = new Font("Segoe UI Semibold", 10F);
            tcMain.TabButtonIdleState.ForeColor = Color.MidnightBlue;
            tcMain.TabButtonIdleState.InnerColor = Color.LightCyan;
            tcMain.TabButtonSelectedState.BorderColor = Color.Empty;
            tcMain.TabButtonSelectedState.FillColor = Color.Transparent;
            tcMain.TabButtonSelectedState.Font = new Font("Segoe UI Semibold", 10F);
            tcMain.TabButtonSelectedState.ForeColor = Color.MidnightBlue;
            tcMain.TabButtonSelectedState.InnerColor = Color.MidnightBlue;
            tcMain.TabButtonSize = new Size(180, 40);
            tcMain.TabIndex = 0;
            tcMain.TabMenuBackColor = Color.White;
            tcMain.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalTop;
            // 
            // tbProduct
            // 
            tbProduct.Location = new Point(4, 44);
            tbProduct.Margin = new Padding(3, 2, 3, 2);
            tbProduct.Name = "tbProduct";
            tbProduct.Size = new Size(1348, 653);
            tbProduct.TabIndex = 2;
            tbProduct.Text = "Product/Service";
            tbProduct.UseVisualStyleBackColor = true;
            // 
            // tbStockIn
            // 
            tbStockIn.Location = new Point(4, 44);
            tbStockIn.Name = "tbStockIn";
            tbStockIn.Padding = new Padding(3);
            tbStockIn.Size = new Size(1348, 653);
            tbStockIn.TabIndex = 3;
            tbStockIn.Text = "Stock In Log";
            tbStockIn.UseVisualStyleBackColor = true;
            // 
            // tbStockMonitoring
            // 
            tbStockMonitoring.Location = new Point(4, 44);
            tbStockMonitoring.Name = "tbStockMonitoring";
            tbStockMonitoring.Size = new Size(1348, 653);
            tbStockMonitoring.TabIndex = 4;
            tbStockMonitoring.Text = "Stock Monitoring";
            tbStockMonitoring.UseVisualStyleBackColor = true;
            // 
            // tbProductType
            // 
            tbProductType.Location = new Point(4, 44);
            tbProductType.Margin = new Padding(3, 2, 3, 2);
            tbProductType.Name = "tbProductType";
            tbProductType.Padding = new Padding(3, 2, 3, 2);
            tbProductType.Size = new Size(1348, 653);
            tbProductType.TabIndex = 0;
            tbProductType.Text = "Product Type";
            tbProductType.UseVisualStyleBackColor = true;
            // 
            // tbUnitOfMeasure
            // 
            tbUnitOfMeasure.Location = new Point(4, 44);
            tbUnitOfMeasure.Margin = new Padding(3, 2, 3, 2);
            tbUnitOfMeasure.Name = "tbUnitOfMeasure";
            tbUnitOfMeasure.Padding = new Padding(3, 2, 3, 2);
            tbUnitOfMeasure.Size = new Size(1348, 653);
            tbUnitOfMeasure.TabIndex = 1;
            tbUnitOfMeasure.Text = "Unit Of Measure";
            tbUnitOfMeasure.UseVisualStyleBackColor = true;
            // 
            // ProductInventoryView
            // 
            AutoScaleMode = AutoScaleMode.Inherit;
            Controls.Add(tcMain);
            Margin = new Padding(3, 2, 3, 2);
            Name = "ProductInventoryView";
            Size = new Size(1356, 701);
            tcMain.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2TabControl tcMain;
        private TabPage tbProductType;
        private TabPage tbUnitOfMeasure;
        private TabPage tbProduct;
        private TabPage tbStockIn;
        private TabPage tbStockMonitoring;
    }
}
