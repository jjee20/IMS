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
            ((System.ComponentModel.ISupportInitialize)txtFullReceive).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtRemarks).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtWarehouse).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtVendorDONumber).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtVendorInvoiceNumber).BeginInit();
            SuspendLayout();
            // 
            // txtFullReceive
            // 
            txtFullReceive.AccessibilityEnabled = true;
            txtFullReceive.Checked = true;
            txtFullReceive.CheckState = CheckState.Checked;
            txtFullReceive.Location = new Point(159, 338);
            txtFullReceive.Name = "txtFullReceive";
            txtFullReceive.Size = new Size(150, 21);
            txtFullReceive.TabIndex = 82;
            txtFullReceive.Text = "Is Full Received?";
            // 
            // txtRemarks
            // 
            txtRemarks.BeforeTouchSize = new Size(206, 82);
            txtRemarks.Location = new Point(159, 234);
            txtRemarks.Multiline = true;
            txtRemarks.Name = "txtRemarks";
            txtRemarks.Size = new Size(265, 89);
            txtRemarks.TabIndex = 81;
            // 
            // autoLabel5
            // 
            autoLabel5.Location = new Point(50, 239);
            autoLabel5.Name = "autoLabel5";
            autoLabel5.Size = new Size(52, 15);
            autoLabel5.TabIndex = 80;
            autoLabel5.Text = "Remarks";
            // 
            // autoLabel4
            // 
            autoLabel4.Location = new Point(50, 200);
            autoLabel4.Name = "autoLabel4";
            autoLabel4.Size = new Size(95, 15);
            autoLabel4.TabIndex = 79;
            autoLabel4.Text = "Vendor Invoice #";
            // 
            // autoLabel3
            // 
            autoLabel3.Location = new Point(50, 162);
            autoLabel3.Name = "autoLabel3";
            autoLabel3.Size = new Size(80, 15);
            autoLabel3.TabIndex = 78;
            autoLabel3.Text = "Vendor D.O. #";
            // 
            // autoLabel2
            // 
            autoLabel2.Location = new Point(50, 121);
            autoLabel2.Name = "autoLabel2";
            autoLabel2.Size = new Size(66, 15);
            autoLabel2.TabIndex = 77;
            autoLabel2.Text = "Warehouse";
            // 
            // txtWarehouse
            // 
            txtWarehouse.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtWarehouse.AutoCompleteSuggestMode = Syncfusion.WinForms.ListView.Enums.AutoCompleteSuggestMode.Contains;
            txtWarehouse.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            txtWarehouse.Location = new Point(159, 116);
            txtWarehouse.Name = "txtWarehouse";
            txtWarehouse.Size = new Size(265, 26);
            txtWarehouse.Style.TokenStyle.CloseButtonBackColor = Color.FromArgb(255, 255, 255);
            txtWarehouse.TabIndex = 76;
            txtWarehouse.TabStop = false;
            // 
            // autoLabel1
            // 
            autoLabel1.Location = new Point(50, 79);
            autoLabel1.Name = "autoLabel1";
            autoLabel1.Size = new Size(58, 15);
            autoLabel1.TabIndex = 75;
            autoLabel1.Text = "GRN Date";
            // 
            // txtGRNDate
            // 
            txtGRNDate.DateTimeIcon = null;
            txtGRNDate.Location = new Point(159, 76);
            txtGRNDate.Name = "txtGRNDate";
            txtGRNDate.Size = new Size(265, 23);
            txtGRNDate.TabIndex = 74;
            txtGRNDate.ToolTipText = "";
            // 
            // linkGRNs
            // 
            linkGRNs.AutoSize = true;
            linkGRNs.Location = new Point(340, 340);
            linkGRNs.Name = "linkGRNs";
            linkGRNs.Size = new Size(84, 15);
            linkGRNs.TabIndex = 73;
            linkGRNs.TabStop = true;
            linkGRNs.Text = "Show GRN List";
            linkGRNs.LinkClicked += linkGRNs_LinkClicked;
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI Semibold", 9F);
            btnSave.Location = new Point(189, 381);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(96, 28);
            btnSave.TabIndex = 83;
            btnSave.Text = "Save";
            btnSave.Click += btnConfirm_Click;
            // 
            // txtVendorDONumber
            // 
            txtVendorDONumber.BeforeTouchSize = new Size(206, 82);
            txtVendorDONumber.Location = new Point(159, 156);
            txtVendorDONumber.Multiline = true;
            txtVendorDONumber.Name = "txtVendorDONumber";
            txtVendorDONumber.Size = new Size(265, 26);
            txtVendorDONumber.TabIndex = 84;
            // 
            // txtVendorInvoiceNumber
            // 
            txtVendorInvoiceNumber.BeforeTouchSize = new Size(206, 82);
            txtVendorInvoiceNumber.Location = new Point(159, 195);
            txtVendorInvoiceNumber.Multiline = true;
            txtVendorInvoiceNumber.Name = "txtVendorInvoiceNumber";
            txtVendorInvoiceNumber.Size = new Size(265, 26);
            txtVendorInvoiceNumber.TabIndex = 85;
            // 
            // UpsertGoodsReceivedNoteView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(474, 463);
            Controls.Add(txtVendorInvoiceNumber);
            Controls.Add(txtVendorDONumber);
            Controls.Add(btnSave);
            Controls.Add(txtFullReceive);
            Controls.Add(txtRemarks);
            Controls.Add(autoLabel5);
            Controls.Add(autoLabel4);
            Controls.Add(autoLabel3);
            Controls.Add(autoLabel2);
            Controls.Add(txtWarehouse);
            Controls.Add(autoLabel1);
            Controls.Add(txtGRNDate);
            Controls.Add(linkGRNs);
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
            ResumeLayout(false);
            PerformLayout();
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
    }
}