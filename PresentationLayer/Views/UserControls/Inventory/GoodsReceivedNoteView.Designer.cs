namespace RavenTech_ERP.Views.UserControls.Inventory
{
    partial class GoodsReceivedNoteView
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            linkGRNs = new LinkLabel();
            txtRemarks = new MaterialSkin.Controls.MaterialMultiLineTextBox();
            btnConfirm = new MaterialSkin.Controls.MaterialButton();
            txtFullReceive = new MaterialSkin.Controls.MaterialSwitch();
            txtVendorInvoiceNumber = new MaterialSkin.Controls.MaterialTextBox();
            txtVendorDONumber = new MaterialSkin.Controls.MaterialTextBox();
            txtWarehouse = new MaterialSkin.Controls.MaterialComboBox();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            txtGRNDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            materialCard1.SuspendLayout();
            SuspendLayout();
            // 
            // materialCard1
            // 
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(linkGRNs);
            materialCard1.Controls.Add(txtRemarks);
            materialCard1.Controls.Add(btnConfirm);
            materialCard1.Controls.Add(txtFullReceive);
            materialCard1.Controls.Add(txtVendorInvoiceNumber);
            materialCard1.Controls.Add(txtVendorDONumber);
            materialCard1.Controls.Add(txtWarehouse);
            materialCard1.Controls.Add(materialLabel1);
            materialCard1.Controls.Add(txtGRNDate);
            materialCard1.Depth = 0;
            materialCard1.Dock = DockStyle.Fill;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(3, 64);
            materialCard1.Margin = new Padding(14);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(14);
            materialCard1.Size = new Size(468, 588);
            materialCard1.TabIndex = 0;
            // 
            // linkGRNs
            // 
            linkGRNs.AutoSize = true;
            linkGRNs.Location = new Point(337, 481);
            linkGRNs.Name = "linkGRNs";
            linkGRNs.Size = new Size(84, 15);
            linkGRNs.TabIndex = 60;
            linkGRNs.TabStop = true;
            linkGRNs.Text = "Show GRN List";
            // 
            // txtRemarks
            // 
            txtRemarks.BackColor = Color.FromArgb(255, 255, 255);
            txtRemarks.BorderStyle = BorderStyle.None;
            txtRemarks.Depth = 0;
            txtRemarks.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtRemarks.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtRemarks.Hint = "Remarks";
            txtRemarks.Location = new Point(47, 354);
            txtRemarks.MouseState = MaterialSkin.MouseState.HOVER;
            txtRemarks.Name = "txtRemarks";
            txtRemarks.Size = new Size(374, 96);
            txtRemarks.TabIndex = 59;
            txtRemarks.Text = "";
            // 
            // btnConfirm
            // 
            btnConfirm.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnConfirm.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnConfirm.Depth = 0;
            btnConfirm.HighEmphasis = true;
            btnConfirm.Icon = null;
            btnConfirm.Location = new Point(191, 527);
            btnConfirm.Margin = new Padding(4, 6, 4, 6);
            btnConfirm.MouseState = MaterialSkin.MouseState.HOVER;
            btnConfirm.Name = "btnConfirm";
            btnConfirm.NoAccentTextColor = Color.Empty;
            btnConfirm.Size = new Size(86, 36);
            btnConfirm.TabIndex = 58;
            btnConfirm.Text = "confirm";
            btnConfirm.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnConfirm.UseAccentColor = false;
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // txtFullReceive
            // 
            txtFullReceive.AutoSize = true;
            txtFullReceive.Checked = true;
            txtFullReceive.CheckState = CheckState.Checked;
            txtFullReceive.Depth = 0;
            txtFullReceive.Location = new Point(47, 471);
            txtFullReceive.Margin = new Padding(0);
            txtFullReceive.MouseLocation = new Point(-1, -1);
            txtFullReceive.MouseState = MaterialSkin.MouseState.HOVER;
            txtFullReceive.Name = "txtFullReceive";
            txtFullReceive.Ripple = true;
            txtFullReceive.Size = new Size(151, 37);
            txtFullReceive.TabIndex = 57;
            txtFullReceive.Text = "Full Received";
            txtFullReceive.UseVisualStyleBackColor = true;
            // 
            // txtVendorInvoiceNumber
            // 
            txtVendorInvoiceNumber.AnimateReadOnly = false;
            txtVendorInvoiceNumber.BorderStyle = BorderStyle.None;
            txtVendorInvoiceNumber.Depth = 0;
            txtVendorInvoiceNumber.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtVendorInvoiceNumber.Hint = "Vendor Invoice #";
            txtVendorInvoiceNumber.LeadingIcon = null;
            txtVendorInvoiceNumber.Location = new Point(47, 279);
            txtVendorInvoiceNumber.MaxLength = 50;
            txtVendorInvoiceNumber.MouseState = MaterialSkin.MouseState.OUT;
            txtVendorInvoiceNumber.Multiline = false;
            txtVendorInvoiceNumber.Name = "txtVendorInvoiceNumber";
            txtVendorInvoiceNumber.Size = new Size(374, 50);
            txtVendorInvoiceNumber.TabIndex = 56;
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
            txtVendorDONumber.Location = new Point(47, 206);
            txtVendorDONumber.MaxLength = 50;
            txtVendorDONumber.MouseState = MaterialSkin.MouseState.OUT;
            txtVendorDONumber.Multiline = false;
            txtVendorDONumber.Name = "txtVendorDONumber";
            txtVendorDONumber.Size = new Size(374, 50);
            txtVendorDONumber.TabIndex = 55;
            txtVendorDONumber.Text = "";
            txtVendorDONumber.TrailingIcon = null;
            // 
            // txtWarehouse
            // 
            txtWarehouse.AutoResize = false;
            txtWarehouse.BackColor = Color.FromArgb(255, 255, 255);
            txtWarehouse.Depth = 0;
            txtWarehouse.DrawMode = DrawMode.OwnerDrawVariable;
            txtWarehouse.DropDownHeight = 174;
            txtWarehouse.DropDownStyle = ComboBoxStyle.DropDownList;
            txtWarehouse.DropDownWidth = 121;
            txtWarehouse.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            txtWarehouse.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtWarehouse.FormattingEnabled = true;
            txtWarehouse.Hint = "Select Warehouse";
            txtWarehouse.IntegralHeight = false;
            txtWarehouse.ItemHeight = 43;
            txtWarehouse.Location = new Point(47, 134);
            txtWarehouse.MaxDropDownItems = 4;
            txtWarehouse.MouseState = MaterialSkin.MouseState.OUT;
            txtWarehouse.Name = "txtWarehouse";
            txtWarehouse.Size = new Size(374, 49);
            txtWarehouse.StartIndex = 0;
            txtWarehouse.TabIndex = 54;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(47, 26);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(70, 19);
            materialLabel1.TabIndex = 53;
            materialLabel1.Text = "GRN Date";
            // 
            // txtGRNDate
            // 
            txtGRNDate.Checked = true;
            txtGRNDate.CustomizableEdges = customizableEdges7;
            txtGRNDate.FillColor = Color.MidnightBlue;
            txtGRNDate.Font = new Font("Segoe UI", 10F);
            txtGRNDate.ForeColor = Color.White;
            txtGRNDate.Format = DateTimePickerFormat.Long;
            txtGRNDate.Location = new Point(47, 57);
            txtGRNDate.Margin = new Padding(3, 2, 3, 2);
            txtGRNDate.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            txtGRNDate.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            txtGRNDate.Name = "txtGRNDate";
            txtGRNDate.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtGRNDate.Size = new Size(374, 53);
            txtGRNDate.TabIndex = 52;
            txtGRNDate.Value = new DateTime(2024, 11, 27, 9, 17, 37, 932);
            // 
            // GoodsReceivedNoteView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(474, 655);
            Controls.Add(materialCard1);
            Name = "GoodsReceivedNoteView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Goods Received Note Details";
            materialCard1.ResumeLayout(false);
            materialCard1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialCard materialCard1;
        private LinkLabel linkGRNs;
        private MaterialSkin.Controls.MaterialMultiLineTextBox txtRemarks;
        private MaterialSkin.Controls.MaterialButton btnConfirm;
        private MaterialSkin.Controls.MaterialSwitch txtFullReceive;
        private MaterialSkin.Controls.MaterialTextBox txtVendorInvoiceNumber;
        private MaterialSkin.Controls.MaterialTextBox txtVendorDONumber;
        private MaterialSkin.Controls.MaterialComboBox txtWarehouse;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private Guna.UI2.WinForms.Guna2DateTimePicker txtGRNDate;
    }
}