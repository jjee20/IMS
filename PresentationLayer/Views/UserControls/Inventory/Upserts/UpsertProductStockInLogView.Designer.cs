namespace RavenTech_ERP.Views.UserControls.Inventory
{
    partial class UpsertProductStockInLogView
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpsertProductStockInLogView));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel6 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtNotes = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            btnSave = new Syncfusion.WinForms.Controls.SfButton();
            txtProduct = new Syncfusion.WinForms.ListView.SfComboBox();
            txtStockQuantity = new Syncfusion.Windows.Forms.Tools.DoubleTextBox();
            txtProductStatus = new Syncfusion.WinForms.ListView.SfComboBox();
            autoLabel5 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
            autoLabel3 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            btnSearchProduct = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)txtNotes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtProduct).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtStockQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtProductStatus).BeginInit();
            SuspendLayout();
            // 
            // autoLabel1
            // 
            autoLabel1.Location = new Point(89, 57);
            autoLabel1.Name = "autoLabel1";
            autoLabel1.Size = new Size(49, 15);
            autoLabel1.TabIndex = 0;
            autoLabel1.Text = "Product";
            // 
            // autoLabel2
            // 
            autoLabel2.Location = new Point(89, 97);
            autoLabel2.Name = "autoLabel2";
            autoLabel2.Size = new Size(85, 15);
            autoLabel2.TabIndex = 2;
            autoLabel2.Text = "Stock Quantity";
            // 
            // autoLabel6
            // 
            autoLabel6.Location = new Point(89, 217);
            autoLabel6.Name = "autoLabel6";
            autoLabel6.Size = new Size(38, 15);
            autoLabel6.TabIndex = 13;
            autoLabel6.Text = "Notes";
            // 
            // txtNotes
            // 
            txtNotes.BeforeTouchSize = new Size(161, 23);
            txtNotes.Location = new Point(189, 216);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(206, 82);
            txtNotes.TabIndex = 14;
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI Semibold", 9F);
            btnSave.Location = new Point(194, 328);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(96, 28);
            btnSave.TabIndex = 15;
            btnSave.Text = "Save";
            btnSave.Click += btnSave_Click;
            // 
            // txtProduct
            // 
            txtProduct.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            txtProduct.Location = new Point(189, 49);
            txtProduct.Name = "txtProduct";
            txtProduct.Size = new Size(173, 26);
            txtProduct.Style.TokenStyle.CloseButtonBackColor = Color.FromArgb(255, 255, 255);
            txtProduct.TabIndex = 16;
            txtProduct.TabStop = false;
            // 
            // txtStockQuantity
            // 
            txtStockQuantity.AccessibilityEnabled = true;
            txtStockQuantity.BeforeTouchSize = new Size(161, 23);
            txtStockQuantity.DoubleValue = 1D;
            txtStockQuantity.Location = new Point(189, 93);
            txtStockQuantity.Name = "txtStockQuantity";
            txtStockQuantity.Size = new Size(206, 23);
            txtStockQuantity.TabIndex = 17;
            txtStockQuantity.Text = "1.00";
            // 
            // txtProductStatus
            // 
            txtProductStatus.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            txtProductStatus.Location = new Point(189, 173);
            txtProductStatus.Name = "txtProductStatus";
            txtProductStatus.Size = new Size(206, 26);
            txtProductStatus.Style.TokenStyle.CloseButtonBackColor = Color.FromArgb(255, 255, 255);
            txtProductStatus.TabIndex = 19;
            txtProductStatus.TabStop = false;
            // 
            // autoLabel5
            // 
            autoLabel5.Location = new Point(89, 181);
            autoLabel5.Name = "autoLabel5";
            autoLabel5.Size = new Size(39, 15);
            autoLabel5.TabIndex = 18;
            autoLabel5.Text = "Status";
            // 
            // txtDate
            // 
            txtDate.DateTimeIcon = null;
            txtDate.Location = new Point(189, 134);
            txtDate.Name = "txtDate";
            txtDate.Size = new Size(206, 23);
            txtDate.TabIndex = 20;
            txtDate.ToolTipText = "";
            // 
            // autoLabel3
            // 
            autoLabel3.Location = new Point(89, 140);
            autoLabel3.Name = "autoLabel3";
            autoLabel3.Size = new Size(31, 15);
            autoLabel3.TabIndex = 21;
            autoLabel3.Text = "Date";
            // 
            // btnSearchProduct
            // 
            btnSearchProduct.CustomizableEdges = customizableEdges1;
            btnSearchProduct.DisabledState.BorderColor = Color.DarkGray;
            btnSearchProduct.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSearchProduct.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSearchProduct.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSearchProduct.FillColor = Color.Transparent;
            btnSearchProduct.Font = new Font("Segoe UI", 9F);
            btnSearchProduct.ForeColor = Color.White;
            btnSearchProduct.Image = (Image)resources.GetObject("btnSearchProduct.Image");
            btnSearchProduct.Location = new Point(368, 49);
            btnSearchProduct.Margin = new Padding(3, 2, 3, 2);
            btnSearchProduct.Name = "btnSearchProduct";
            btnSearchProduct.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnSearchProduct.Size = new Size(27, 26);
            btnSearchProduct.TabIndex = 28;
            btnSearchProduct.Click += btnSearchProduct_Click;
            // 
            // UpsertProductStockInLogView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 405);
            Controls.Add(btnSearchProduct);
            Controls.Add(autoLabel3);
            Controls.Add(txtDate);
            Controls.Add(txtProductStatus);
            Controls.Add(autoLabel5);
            Controls.Add(txtStockQuantity);
            Controls.Add(txtProduct);
            Controls.Add(btnSave);
            Controls.Add(txtNotes);
            Controls.Add(autoLabel6);
            Controls.Add(autoLabel2);
            Controls.Add(autoLabel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "UpsertProductStockInLogView";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Style.MdiChild.IconHorizontalAlignment = HorizontalAlignment.Center;
            Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            Text = "Add Product Stock In Log";
            ((System.ComponentModel.ISupportInitialize)txtNotes).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtProduct).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtStockQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtProductStatus).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private Syncfusion.Windows.Forms.Tools.MaskedEditBox txtPhone;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel4;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtEmail;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtContactPerson;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel6;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtNotes;
        private Syncfusion.WinForms.Controls.SfButton btnSave;
        private Syncfusion.WinForms.ListView.SfComboBox txtProduct;
        private Syncfusion.Windows.Forms.Tools.DoubleTextBox txtStockQuantity;
        private Syncfusion.WinForms.ListView.SfComboBox txtProductStatus;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel5;
        private Syncfusion.WinForms.Input.SfDateTimeEdit txtDate;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel3;
        private Guna.UI2.WinForms.Guna2Button btnSearchProduct;
    }
}