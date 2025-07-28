namespace RavenTech_ERP.Views.UserControls.Inventory
{
    partial class UpsertGoodsReceivedNoteView
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
            txtFullReceive = new Syncfusion.Windows.Forms.Tools.CheckBoxAdv();
            txtRemarks = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            autoLabel5 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel4 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel3 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtWarehouse = new Syncfusion.WinForms.ListView.SfComboBox();
            autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtGRNDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
            linkGRNs = new LinkLabel();
            btnSave = new Syncfusion.WinForms.Controls.SfButton();
            txtVendorDONumber = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            txtVendorInvoiceNumber = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            ((System.ComponentModel.ISupportInitialize)txtFullReceive).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtRemarks).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtWarehouse).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtVendorDONumber).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtVendorInvoiceNumber).BeginInit();
            materialCard1.SuspendLayout();
            SuspendLayout();
            // 
            // txtFullReceive
            // 
            txtFullReceive.AccessibilityEnabled = true;
            txtFullReceive.BeforeTouchSize = new Size(266, 23);
            txtFullReceive.Checked = true;
            txtFullReceive.CheckState = CheckState.Checked;
            txtFullReceive.Dock = DockStyle.Top;
            txtFullReceive.ImageCheckBoxSize = new Size(19, 19);
            txtFullReceive.Location = new Point(9, 269);
            txtFullReceive.Name = "txtFullReceive";
            txtFullReceive.Size = new Size(266, 23);
            txtFullReceive.TabIndex = 5;
            txtFullReceive.Text = "Is Full Received?";
            // 
            // txtRemarks
            // 
            txtRemarks.BeforeTouchSize = new Size(350, 22);
            txtRemarks.Dock = DockStyle.Top;
            txtRemarks.Location = new Point(9, 170);
            txtRemarks.Multiline = true;
            txtRemarks.Name = "txtRemarks";
            txtRemarks.Size = new Size(350, 99);
            txtRemarks.TabIndex = 4;
            // 
            // autoLabel5
            // 
            autoLabel5.Dock = DockStyle.Top;
            autoLabel5.Location = new Point(9, 155);
            autoLabel5.Name = "autoLabel5";
            autoLabel5.Size = new Size(52, 15);
            autoLabel5.TabIndex = 80;
            autoLabel5.Text = "Remarks";
            // 
            // autoLabel4
            // 
            autoLabel4.Dock = DockStyle.Top;
            autoLabel4.Location = new Point(9, 118);
            autoLabel4.Name = "autoLabel4";
            autoLabel4.Size = new Size(95, 15);
            autoLabel4.TabIndex = 79;
            autoLabel4.Text = "Vendor Invoice #";
            // 
            // autoLabel3
            // 
            autoLabel3.Dock = DockStyle.Top;
            autoLabel3.Location = new Point(9, 81);
            autoLabel3.Name = "autoLabel3";
            autoLabel3.Size = new Size(80, 15);
            autoLabel3.TabIndex = 78;
            autoLabel3.Text = "Vendor D.O. #";
            // 
            // autoLabel2
            // 
            autoLabel2.Dock = DockStyle.Top;
            autoLabel2.Location = new Point(9, 45);
            autoLabel2.Name = "autoLabel2";
            autoLabel2.Size = new Size(66, 15);
            autoLabel2.TabIndex = 77;
            autoLabel2.Text = "Warehouse";
            // 
            // txtWarehouse
            // 
            txtWarehouse.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtWarehouse.AutoCompleteSuggestMode = Syncfusion.WinForms.ListView.Enums.AutoCompleteSuggestMode.Contains;
            txtWarehouse.Dock = DockStyle.Top;
            txtWarehouse.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            txtWarehouse.Location = new Point(9, 60);
            txtWarehouse.Name = "txtWarehouse";
            txtWarehouse.Size = new Size(350, 21);
            txtWarehouse.Style.TokenStyle.CloseButtonBackColor = Color.FromArgb(255, 255, 255);
            txtWarehouse.TabIndex = 1;
            txtWarehouse.TabStop = false;
            // 
            // autoLabel1
            // 
            autoLabel1.Dock = DockStyle.Top;
            autoLabel1.Location = new Point(9, 9);
            autoLabel1.Name = "autoLabel1";
            autoLabel1.Size = new Size(58, 15);
            autoLabel1.TabIndex = 75;
            autoLabel1.Text = "GRN Date";
            // 
            // txtGRNDate
            // 
            txtGRNDate.DateTimeIcon = null;
            txtGRNDate.DateTimePattern = Syncfusion.WinForms.Input.Enums.DateTimePattern.Custom;
            txtGRNDate.Dock = DockStyle.Top;
            txtGRNDate.Format = "MMMM dd, yyyy";
            txtGRNDate.Location = new Point(9, 24);
            txtGRNDate.Name = "txtGRNDate";
            txtGRNDate.Size = new Size(350, 21);
            txtGRNDate.TabIndex = 0;
            txtGRNDate.ToolTipText = "";
            // 
            // linkGRNs
            // 
            linkGRNs.AutoSize = true;
            linkGRNs.Dock = DockStyle.Right;
            linkGRNs.Location = new Point(275, 269);
            linkGRNs.Name = "linkGRNs";
            linkGRNs.Size = new Size(84, 15);
            linkGRNs.TabIndex = 7;
            linkGRNs.TabStop = true;
            linkGRNs.Text = "Show GRN List";
            linkGRNs.LinkClicked += linkGRNs_LinkClicked;
            // 
            // btnSave
            // 
            btnSave.BackColor = SystemColors.HotTrack;
            btnSave.Dock = DockStyle.Bottom;
            btnSave.Font = new Font("Segoe UI Semibold", 9F);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(9, 321);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(350, 31);
            btnSave.Style.BackColor = SystemColors.HotTrack;
            btnSave.Style.ForeColor = Color.White;
            btnSave.TabIndex = 6;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnConfirm_Click;
            // 
            // txtVendorDONumber
            // 
            txtVendorDONumber.BeforeTouchSize = new Size(350, 22);
            txtVendorDONumber.Dock = DockStyle.Top;
            txtVendorDONumber.Location = new Point(9, 96);
            txtVendorDONumber.Multiline = true;
            txtVendorDONumber.Name = "txtVendorDONumber";
            txtVendorDONumber.Size = new Size(350, 22);
            txtVendorDONumber.TabIndex = 2;
            // 
            // txtVendorInvoiceNumber
            // 
            txtVendorInvoiceNumber.BeforeTouchSize = new Size(350, 22);
            txtVendorInvoiceNumber.Dock = DockStyle.Top;
            txtVendorInvoiceNumber.Location = new Point(9, 133);
            txtVendorInvoiceNumber.Multiline = true;
            txtVendorInvoiceNumber.Name = "txtVendorInvoiceNumber";
            txtVendorInvoiceNumber.Size = new Size(350, 22);
            txtVendorInvoiceNumber.TabIndex = 3;
            // 
            // materialCard1
            // 
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(txtFullReceive);
            materialCard1.Controls.Add(linkGRNs);
            materialCard1.Controls.Add(btnSave);
            materialCard1.Controls.Add(txtRemarks);
            materialCard1.Controls.Add(autoLabel5);
            materialCard1.Controls.Add(txtVendorInvoiceNumber);
            materialCard1.Controls.Add(autoLabel4);
            materialCard1.Controls.Add(txtVendorDONumber);
            materialCard1.Controls.Add(autoLabel3);
            materialCard1.Controls.Add(txtWarehouse);
            materialCard1.Controls.Add(autoLabel2);
            materialCard1.Controls.Add(txtGRNDate);
            materialCard1.Controls.Add(autoLabel1);
            materialCard1.Depth = 0;
            materialCard1.Dock = DockStyle.Fill;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(1, 1);
            materialCard1.Margin = new Padding(9, 9, 9, 9);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(9, 9, 9, 9);
            materialCard1.Size = new Size(368, 361);
            materialCard1.TabIndex = 86;
            // 
            // UpsertGoodsReceivedNoteView
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(370, 363);
            Controls.Add(materialCard1);
            Name = "UpsertGoodsReceivedNoteView";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Style.MdiChild.IconHorizontalAlignment = HorizontalAlignment.Center;
            Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            Text = "Goods Received Note Details";
            ((System.ComponentModel.ISupportInitialize)txtFullReceive).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtRemarks).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtWarehouse).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtVendorDONumber).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtVendorInvoiceNumber).EndInit();
            materialCard1.ResumeLayout(false);
            materialCard1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtVendorDONumber;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtDescription;
        private Syncfusion.Windows.Forms.Tools.CheckBoxAdv txtFullReceive;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtRemarks;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel5;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel4;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel3;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private Syncfusion.WinForms.ListView.SfComboBox txtWarehouse;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.WinForms.Input.SfDateTimeEdit txtGRNDate;
        private LinkLabel linkGRNs;
        private Syncfusion.WinForms.Controls.SfButton btnSave;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtVendorInvoiceNumber;
        private MaterialSkin.Controls.MaterialCard materialCard1;
    }
}