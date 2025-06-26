namespace RavenTech_ERP.Views.UserControls.Inventory
{
    partial class UpsertProductView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpsertProductView));
            autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtName = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            txtDescription = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel4 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtColor = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            autoLabel5 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            btnSave = new Syncfusion.WinForms.Controls.SfButton();
            txtProductCode = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            autoLabel6 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtBarcode = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            autoLabel7 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtProductType = new Syncfusion.WinForms.ListView.SfComboBox();
            autoLabel3 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel8 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel9 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtUOM = new Syncfusion.WinForms.ListView.SfComboBox();
            autoLabel10 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtBranch = new Syncfusion.WinForms.ListView.SfComboBox();
            txtReorderLevel = new Syncfusion.Windows.Forms.Tools.DoubleTextBox();
            autoLabel11 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtDefaultBuyingPrice = new Syncfusion.Windows.Forms.Tools.DoubleTextBox();
            autoLabel12 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtDefaultSellingPrice = new Syncfusion.Windows.Forms.Tools.DoubleTextBox();
            autoLabel13 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtBrand = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            txtSize = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            ((System.ComponentModel.ISupportInitialize)txtName).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtDescription).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtColor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtProductCode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtBarcode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtProductType).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtUOM).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtBranch).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtReorderLevel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtDefaultBuyingPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtDefaultSellingPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtBrand).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtSize).BeginInit();
            SuspendLayout();
            // 
            // autoLabel1
            // 
            autoLabel1.Location = new Point(116, 83);
            autoLabel1.Margin = new Padding(4, 0, 4, 0);
            autoLabel1.Name = "autoLabel1";
            autoLabel1.Size = new Size(59, 25);
            autoLabel1.TabIndex = 0;
            autoLabel1.Text = "Name";
            // 
            // txtName
            // 
            txtName.BeforeTouchSize = new Size(94, 31);
            txtName.Location = new Point(259, 73);
            txtName.Margin = new Padding(4, 5, 4, 5);
            txtName.Name = "txtName";
            txtName.Size = new Size(293, 31);
            txtName.TabIndex = 1;
            // 
            // txtDescription
            // 
            txtDescription.BeforeTouchSize = new Size(94, 31);
            txtDescription.Location = new Point(259, 262);
            txtDescription.Margin = new Padding(4, 5, 4, 5);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(293, 31);
            txtDescription.TabIndex = 3;
            // 
            // autoLabel2
            // 
            autoLabel2.Location = new Point(116, 270);
            autoLabel2.Margin = new Padding(4, 0, 4, 0);
            autoLabel2.Name = "autoLabel2";
            autoLabel2.Size = new Size(102, 25);
            autoLabel2.TabIndex = 2;
            autoLabel2.Text = "Description";
            // 
            // autoLabel4
            // 
            autoLabel4.Location = new Point(634, 83);
            autoLabel4.Margin = new Padding(4, 0, 4, 0);
            autoLabel4.Name = "autoLabel4";
            autoLabel4.Size = new Size(58, 25);
            autoLabel4.TabIndex = 9;
            autoLabel4.Text = "Brand";
            // 
            // txtColor
            // 
            txtColor.BeforeTouchSize = new Size(94, 31);
            txtColor.Location = new Point(777, 137);
            txtColor.Margin = new Padding(4, 5, 4, 5);
            txtColor.Name = "txtColor";
            txtColor.Size = new Size(131, 31);
            txtColor.TabIndex = 12;
            // 
            // autoLabel5
            // 
            autoLabel5.Location = new Point(634, 147);
            autoLabel5.Margin = new Padding(4, 0, 4, 0);
            autoLabel5.Name = "autoLabel5";
            autoLabel5.Size = new Size(55, 25);
            autoLabel5.TabIndex = 11;
            autoLabel5.Text = "Color";
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI Semibold", 9F);
            btnSave.Location = new Point(524, 487);
            btnSave.Margin = new Padding(4, 5, 4, 5);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(137, 47);
            btnSave.TabIndex = 15;
            btnSave.Text = "Save";
            btnSave.Click += btnSave_Click;
            // 
            // txtProductCode
            // 
            txtProductCode.BeforeTouchSize = new Size(94, 31);
            txtProductCode.Location = new Point(259, 137);
            txtProductCode.Margin = new Padding(4, 5, 4, 5);
            txtProductCode.Name = "txtProductCode";
            txtProductCode.Size = new Size(293, 31);
            txtProductCode.TabIndex = 17;
            // 
            // autoLabel6
            // 
            autoLabel6.Location = new Point(116, 147);
            autoLabel6.Margin = new Padding(4, 0, 4, 0);
            autoLabel6.Name = "autoLabel6";
            autoLabel6.Size = new Size(121, 25);
            autoLabel6.TabIndex = 16;
            autoLabel6.Text = "Product Code";
            // 
            // txtBarcode
            // 
            txtBarcode.BeforeTouchSize = new Size(94, 31);
            txtBarcode.Location = new Point(259, 200);
            txtBarcode.Margin = new Padding(4, 5, 4, 5);
            txtBarcode.Name = "txtBarcode";
            txtBarcode.Size = new Size(293, 31);
            txtBarcode.TabIndex = 19;
            // 
            // autoLabel7
            // 
            autoLabel7.Location = new Point(116, 210);
            autoLabel7.Margin = new Padding(4, 0, 4, 0);
            autoLabel7.Name = "autoLabel7";
            autoLabel7.Size = new Size(76, 25);
            autoLabel7.TabIndex = 18;
            autoLabel7.Text = "Barcode";
            // 
            // txtProductType
            // 
            txtProductType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtProductType.AutoCompleteSuggestMode = Syncfusion.WinForms.ListView.Enums.AutoCompleteSuggestMode.Contains;
            txtProductType.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            txtProductType.Location = new Point(259, 325);
            txtProductType.Margin = new Padding(4, 5, 4, 5);
            txtProductType.Name = "txtProductType";
            txtProductType.Padding = new Padding(10, 0, 0, 0);
            txtProductType.Size = new Size(294, 43);
            txtProductType.Style.TokenStyle.CloseButtonBackColor = Color.FromArgb(255, 255, 255);
            txtProductType.TabIndex = 20;
            txtProductType.TabStop = false;
            // 
            // autoLabel3
            // 
            autoLabel3.Location = new Point(116, 333);
            autoLabel3.Margin = new Padding(4, 0, 4, 0);
            autoLabel3.Name = "autoLabel3";
            autoLabel3.Size = new Size(49, 25);
            autoLabel3.TabIndex = 21;
            autoLabel3.Text = "Type";
            // 
            // autoLabel8
            // 
            autoLabel8.Location = new Point(926, 143);
            autoLabel8.Margin = new Padding(4, 0, 4, 0);
            autoLabel8.Name = "autoLabel8";
            autoLabel8.Size = new Size(43, 25);
            autoLabel8.TabIndex = 22;
            autoLabel8.Text = "Size";
            // 
            // autoLabel9
            // 
            autoLabel9.Location = new Point(639, 402);
            autoLabel9.Margin = new Padding(4, 0, 4, 0);
            autoLabel9.Name = "autoLabel9";
            autoLabel9.Size = new Size(54, 25);
            autoLabel9.TabIndex = 26;
            autoLabel9.Text = "UOM";
            // 
            // txtUOM
            // 
            txtUOM.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtUOM.AutoCompleteSuggestMode = Syncfusion.WinForms.ListView.Enums.AutoCompleteSuggestMode.Contains;
            txtUOM.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            txtUOM.Location = new Point(777, 393);
            txtUOM.Margin = new Padding(4, 5, 4, 5);
            txtUOM.Name = "txtUOM";
            txtUOM.Padding = new Padding(10, 0, 0, 0);
            txtUOM.Size = new Size(294, 43);
            txtUOM.Style.TokenStyle.CloseButtonBackColor = Color.FromArgb(255, 255, 255);
            txtUOM.TabIndex = 25;
            txtUOM.TabStop = false;
            // 
            // autoLabel10
            // 
            autoLabel10.Location = new Point(116, 402);
            autoLabel10.Margin = new Padding(4, 0, 4, 0);
            autoLabel10.Name = "autoLabel10";
            autoLabel10.Size = new Size(65, 25);
            autoLabel10.TabIndex = 28;
            autoLabel10.Text = "Branch";
            // 
            // txtBranch
            // 
            txtBranch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtBranch.AutoCompleteSuggestMode = Syncfusion.WinForms.ListView.Enums.AutoCompleteSuggestMode.Contains;
            txtBranch.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            txtBranch.Location = new Point(259, 393);
            txtBranch.Margin = new Padding(4, 5, 4, 5);
            txtBranch.Name = "txtBranch";
            txtBranch.Padding = new Padding(10, 0, 0, 0);
            txtBranch.Size = new Size(294, 43);
            txtBranch.Style.TokenStyle.CloseButtonBackColor = Color.FromArgb(255, 255, 255);
            txtBranch.TabIndex = 27;
            txtBranch.TabStop = false;
            // 
            // txtReorderLevel
            // 
            txtReorderLevel.AccessibilityEnabled = true;
            txtReorderLevel.BeforeTouchSize = new Size(94, 31);
            txtReorderLevel.DoubleValue = 1D;
            txtReorderLevel.Location = new Point(777, 200);
            txtReorderLevel.Margin = new Padding(4, 5, 4, 5);
            txtReorderLevel.Name = "txtReorderLevel";
            txtReorderLevel.Size = new Size(293, 31);
            txtReorderLevel.TabIndex = 30;
            txtReorderLevel.Text = "1.00";
            // 
            // autoLabel11
            // 
            autoLabel11.Location = new Point(634, 210);
            autoLabel11.Margin = new Padding(4, 0, 4, 0);
            autoLabel11.Name = "autoLabel11";
            autoLabel11.Size = new Size(118, 25);
            autoLabel11.TabIndex = 29;
            autoLabel11.Text = "Reorder Level";
            // 
            // txtDefaultBuyingPrice
            // 
            txtDefaultBuyingPrice.AccessibilityEnabled = true;
            txtDefaultBuyingPrice.BeforeTouchSize = new Size(94, 31);
            txtDefaultBuyingPrice.DoubleValue = 1D;
            txtDefaultBuyingPrice.Location = new Point(777, 262);
            txtDefaultBuyingPrice.Margin = new Padding(4, 5, 4, 5);
            txtDefaultBuyingPrice.Name = "txtDefaultBuyingPrice";
            txtDefaultBuyingPrice.Size = new Size(293, 31);
            txtDefaultBuyingPrice.TabIndex = 32;
            txtDefaultBuyingPrice.Text = "1.00";
            // 
            // autoLabel12
            // 
            autoLabel12.Location = new Point(634, 270);
            autoLabel12.Margin = new Padding(4, 0, 4, 0);
            autoLabel12.Name = "autoLabel12";
            autoLabel12.Size = new Size(108, 25);
            autoLabel12.TabIndex = 31;
            autoLabel12.Text = "Buying Price";
            // 
            // txtDefaultSellingPrice
            // 
            txtDefaultSellingPrice.AccessibilityEnabled = true;
            txtDefaultSellingPrice.BeforeTouchSize = new Size(94, 31);
            txtDefaultSellingPrice.DoubleValue = 1D;
            txtDefaultSellingPrice.Location = new Point(777, 325);
            txtDefaultSellingPrice.Margin = new Padding(4, 5, 4, 5);
            txtDefaultSellingPrice.Name = "txtDefaultSellingPrice";
            txtDefaultSellingPrice.Size = new Size(293, 31);
            txtDefaultSellingPrice.TabIndex = 34;
            txtDefaultSellingPrice.Text = "1.00";
            // 
            // autoLabel13
            // 
            autoLabel13.Location = new Point(634, 333);
            autoLabel13.Margin = new Padding(4, 0, 4, 0);
            autoLabel13.Name = "autoLabel13";
            autoLabel13.Size = new Size(106, 25);
            autoLabel13.TabIndex = 33;
            autoLabel13.Text = "Selling Price";
            // 
            // txtBrand
            // 
            txtBrand.BeforeTouchSize = new Size(94, 31);
            txtBrand.Location = new Point(777, 73);
            txtBrand.Margin = new Padding(4, 5, 4, 5);
            txtBrand.Name = "txtBrand";
            txtBrand.Size = new Size(293, 31);
            txtBrand.TabIndex = 35;
            // 
            // txtSize
            // 
            txtSize.BeforeTouchSize = new Size(94, 31);
            txtSize.Location = new Point(977, 137);
            txtSize.Margin = new Padding(4, 5, 4, 5);
            txtSize.Name = "txtSize";
            txtSize.Size = new Size(94, 31);
            txtSize.TabIndex = 36;
            // 
            // UpsertProductView
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1183, 597);
            Controls.Add(txtSize);
            Controls.Add(txtBrand);
            Controls.Add(txtDefaultSellingPrice);
            Controls.Add(autoLabel13);
            Controls.Add(txtDefaultBuyingPrice);
            Controls.Add(autoLabel12);
            Controls.Add(txtReorderLevel);
            Controls.Add(autoLabel11);
            Controls.Add(autoLabel10);
            Controls.Add(txtBranch);
            Controls.Add(autoLabel9);
            Controls.Add(txtUOM);
            Controls.Add(autoLabel8);
            Controls.Add(autoLabel3);
            Controls.Add(txtProductType);
            Controls.Add(txtBarcode);
            Controls.Add(autoLabel7);
            Controls.Add(txtProductCode);
            Controls.Add(autoLabel6);
            Controls.Add(btnSave);
            Controls.Add(txtColor);
            Controls.Add(autoLabel5);
            Controls.Add(autoLabel4);
            Controls.Add(txtDescription);
            Controls.Add(autoLabel2);
            Controls.Add(txtName);
            Controls.Add(autoLabel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 5, 4, 5);
            Name = "UpsertProductView";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Style.MdiChild.IconHorizontalAlignment = HorizontalAlignment.Center;
            Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            Text = "Add Product";
            ((System.ComponentModel.ISupportInitialize)txtName).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtDescription).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtColor).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtProductCode).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtBarcode).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtProductType).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtUOM).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtBranch).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtReorderLevel).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtDefaultBuyingPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtDefaultSellingPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtBrand).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtSize).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtName;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtDescription;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private Syncfusion.Windows.Forms.Tools.MaskedEditBox txtPhone;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel4;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtColor;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel5;
        private Syncfusion.WinForms.Controls.SfButton btnSave;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtProductCode;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel6;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtBarcode;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel7;
        private Syncfusion.WinForms.ListView.SfComboBox txtProductType;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel3;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel8;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel9;
        private Syncfusion.WinForms.ListView.SfComboBox txtUOM;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel10;
        private Syncfusion.WinForms.ListView.SfComboBox txtBranch;
        private Syncfusion.Windows.Forms.Tools.DoubleTextBox txtReorderLevel;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel11;
        private Syncfusion.Windows.Forms.Tools.DoubleTextBox txtDefaultBuyingPrice;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel12;
        private Syncfusion.Windows.Forms.Tools.DoubleTextBox txtDefaultSellingPrice;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel13;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtBrand;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtSize;
    }
}