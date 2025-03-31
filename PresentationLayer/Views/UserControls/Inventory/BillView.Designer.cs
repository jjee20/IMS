namespace RavenTech_ERP.Views.UserControls.Inventory
{
    partial class BillView
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            txtDueDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            btnConfirm = new MaterialSkin.Controls.MaterialButton();
            txtVendorInvoiceNumber = new MaterialSkin.Controls.MaterialTextBox();
            txtVendorDONumber = new MaterialSkin.Controls.MaterialTextBox();
            txtBillType = new MaterialSkin.Controls.MaterialComboBox();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            txtDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            materialCard1.SuspendLayout();
            SuspendLayout();
            // 
            // materialCard1
            // 
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(materialLabel2);
            materialCard1.Controls.Add(txtDueDate);
            materialCard1.Controls.Add(btnConfirm);
            materialCard1.Controls.Add(txtVendorInvoiceNumber);
            materialCard1.Controls.Add(txtVendorDONumber);
            materialCard1.Controls.Add(txtBillType);
            materialCard1.Controls.Add(materialLabel1);
            materialCard1.Controls.Add(txtDate);
            materialCard1.Depth = 0;
            materialCard1.Dock = DockStyle.Fill;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(3, 64);
            materialCard1.Margin = new Padding(14);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(14);
            materialCard1.Size = new Size(468, 530);
            materialCard1.TabIndex = 0;
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.Location = new Point(47, 126);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(92, 19);
            materialLabel2.TabIndex = 61;
            materialLabel2.Text = "Bill Due Date";
            // 
            // txtDueDate
            // 
            txtDueDate.Checked = true;
            txtDueDate.CustomizableEdges = customizableEdges5;
            txtDueDate.FillColor = Color.MidnightBlue;
            txtDueDate.Font = new Font("Segoe UI", 10F);
            txtDueDate.ForeColor = Color.White;
            txtDueDate.Format = DateTimePickerFormat.Long;
            txtDueDate.Location = new Point(47, 157);
            txtDueDate.Margin = new Padding(3, 2, 3, 2);
            txtDueDate.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            txtDueDate.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            txtDueDate.Name = "txtDueDate";
            txtDueDate.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtDueDate.Size = new Size(374, 53);
            txtDueDate.TabIndex = 60;
            txtDueDate.Value = new DateTime(2024, 11, 27, 9, 17, 37, 932);
            // 
            // btnConfirm
            // 
            btnConfirm.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnConfirm.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnConfirm.Depth = 0;
            btnConfirm.HighEmphasis = true;
            btnConfirm.Icon = null;
            btnConfirm.Location = new Point(191, 468);
            btnConfirm.Margin = new Padding(4, 6, 4, 6);
            btnConfirm.MouseState = MaterialSkin.MouseState.HOVER;
            btnConfirm.Name = "btnConfirm";
            btnConfirm.NoAccentTextColor = Color.Empty;
            btnConfirm.Size = new Size(86, 36);
            btnConfirm.TabIndex = 59;
            btnConfirm.Text = "confirm";
            btnConfirm.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnConfirm.UseAccentColor = false;
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // txtVendorInvoiceNumber
            // 
            txtVendorInvoiceNumber.AnimateReadOnly = false;
            txtVendorInvoiceNumber.BorderStyle = BorderStyle.None;
            txtVendorInvoiceNumber.Depth = 0;
            txtVendorInvoiceNumber.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtVendorInvoiceNumber.Hint = "Vendor Invoice #";
            txtVendorInvoiceNumber.LeadingIcon = null;
            txtVendorInvoiceNumber.Location = new Point(47, 379);
            txtVendorInvoiceNumber.MaxLength = 50;
            txtVendorInvoiceNumber.MouseState = MaterialSkin.MouseState.OUT;
            txtVendorInvoiceNumber.Multiline = false;
            txtVendorInvoiceNumber.Name = "txtVendorInvoiceNumber";
            txtVendorInvoiceNumber.Size = new Size(374, 50);
            txtVendorInvoiceNumber.TabIndex = 58;
            txtVendorInvoiceNumber.Text = "";
            txtVendorInvoiceNumber.TrailingIcon = null;
            // 
            // txtVendorDONumber
            // 
            txtVendorDONumber.AnimateReadOnly = false;
            txtVendorDONumber.BorderStyle = BorderStyle.None;
            txtVendorDONumber.Depth = 0;
            txtVendorDONumber.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtVendorDONumber.Hint = "Vendor D.O. #";
            txtVendorDONumber.LeadingIcon = null;
            txtVendorDONumber.Location = new Point(47, 306);
            txtVendorDONumber.MaxLength = 50;
            txtVendorDONumber.MouseState = MaterialSkin.MouseState.OUT;
            txtVendorDONumber.Multiline = false;
            txtVendorDONumber.Name = "txtVendorDONumber";
            txtVendorDONumber.Size = new Size(374, 50);
            txtVendorDONumber.TabIndex = 57;
            txtVendorDONumber.Text = "";
            txtVendorDONumber.TrailingIcon = null;
            // 
            // txtBillType
            // 
            txtBillType.AutoResize = false;
            txtBillType.BackColor = Color.FromArgb(255, 255, 255);
            txtBillType.Depth = 0;
            txtBillType.DrawMode = DrawMode.OwnerDrawVariable;
            txtBillType.DropDownHeight = 174;
            txtBillType.DropDownStyle = ComboBoxStyle.DropDownList;
            txtBillType.DropDownWidth = 121;
            txtBillType.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            txtBillType.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtBillType.FormattingEnabled = true;
            txtBillType.Hint = "Select Bill Type";
            txtBillType.IntegralHeight = false;
            txtBillType.ItemHeight = 43;
            txtBillType.Location = new Point(47, 234);
            txtBillType.MaxDropDownItems = 4;
            txtBillType.MouseState = MaterialSkin.MouseState.OUT;
            txtBillType.Name = "txtBillType";
            txtBillType.Size = new Size(374, 49);
            txtBillType.StartIndex = 0;
            txtBillType.TabIndex = 56;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(47, 26);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(60, 19);
            materialLabel1.TabIndex = 55;
            materialLabel1.Text = "Bill Date";
            // 
            // txtDate
            // 
            txtDate.Checked = true;
            txtDate.CustomizableEdges = customizableEdges7;
            txtDate.FillColor = Color.MidnightBlue;
            txtDate.Font = new Font("Segoe UI", 10F);
            txtDate.ForeColor = Color.White;
            txtDate.Format = DateTimePickerFormat.Long;
            txtDate.Location = new Point(47, 57);
            txtDate.Margin = new Padding(3, 2, 3, 2);
            txtDate.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            txtDate.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            txtDate.Name = "txtDate";
            txtDate.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtDate.Size = new Size(374, 53);
            txtDate.TabIndex = 54;
            txtDate.Value = new DateTime(2024, 11, 27, 9, 17, 37, 932);
            // 
            // BillView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(474, 597);
            Controls.Add(materialCard1);
            Name = "BillView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bill Details";
            materialCard1.ResumeLayout(false);
            materialCard1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialCard materialCard1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private Guna.UI2.WinForms.Guna2DateTimePicker txtDueDate;
        private MaterialSkin.Controls.MaterialButton btnConfirm;
        private MaterialSkin.Controls.MaterialTextBox txtVendorInvoiceNumber;
        private MaterialSkin.Controls.MaterialTextBox txtVendorDONumber;
        private MaterialSkin.Controls.MaterialComboBox txtBillType;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private Guna.UI2.WinForms.Guna2DateTimePicker txtDate;
    }
}