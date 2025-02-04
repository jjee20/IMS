namespace PresentationLayer.Views.UserControls
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
            tbProductType = new TabPage();
            tbUnitOfMeasure = new TabPage();
            tcMain.SuspendLayout();
            SuspendLayout();
            // 
            // tcMain
            // 
            tcMain.Controls.Add(tbProduct);
            tcMain.Controls.Add(tbProductType);
            tcMain.Controls.Add(tbUnitOfMeasure);
            tcMain.Dock = DockStyle.Fill;
            tcMain.ItemSize = new Size(180, 40);
            tcMain.Location = new Point(0, 0);
            tcMain.Margin = new Padding(3, 2, 3, 2);
            tcMain.Name = "tcMain";
            tcMain.SelectedIndex = 0;
            tcMain.Size = new Size(1668, 734);
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
            // tbProduct
            // 
            tbProduct.Location = new Point(4, 44);
            tbProduct.Margin = new Padding(3, 2, 3, 2);
            tbProduct.Name = "tbProduct";
            tbProduct.Size = new Size(1660, 686);
            tbProduct.TabIndex = 2;
            tbProduct.Text = "Product";
            tbProduct.UseVisualStyleBackColor = true;
            // 
            // tbProductType
            // 
            tbProductType.Location = new Point(4, 44);
            tbProductType.Margin = new Padding(3, 2, 3, 2);
            tbProductType.Name = "tbProductType";
            tbProductType.Padding = new Padding(3, 2, 3, 2);
            tbProductType.Size = new Size(1660, 686);
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
            tbUnitOfMeasure.Size = new Size(1660, 686);
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
            Size = new Size(1668, 734);
            tcMain.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2TabControl tcMain;
        private TabPage tbProductType;
        private TabPage tbUnitOfMeasure;
        private TabPage tbProduct;
    }
}
