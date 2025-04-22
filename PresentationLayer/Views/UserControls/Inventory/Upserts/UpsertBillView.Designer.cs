namespace RavenTech_ERP.Views.UserControls.Inventory
{
    partial class UpsertBillView
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
            autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
            txtDueDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
            autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtBillType = new Syncfusion.WinForms.ListView.SfComboBox();
            autoLabel3 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel4 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtVendorDONumber = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            txtVendorInvoiceNumber = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            autoLabel5 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            btnSave = new Syncfusion.WinForms.Controls.SfButton();
            ((System.ComponentModel.ISupportInitialize)txtBillType).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtVendorDONumber).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtVendorInvoiceNumber).BeginInit();
            SuspendLayout();
            // 
            // autoLabel1
            // 
            autoLabel1.Location = new Point(50, 59);
            autoLabel1.Name = "autoLabel1";
            autoLabel1.Size = new Size(50, 15);
            autoLabel1.TabIndex = 70;
            autoLabel1.Text = "Bill Date";
            // 
            // txtDate
            // 
            txtDate.DateTimeIcon = null;
            txtDate.Location = new Point(166, 54);
            txtDate.Name = "txtDate";
            txtDate.Size = new Size(258, 23);
            txtDate.TabIndex = 71;
            txtDate.ToolTipText = "";
            // 
            // txtDueDate
            // 
            txtDueDate.DateTimeIcon = null;
            txtDueDate.Location = new Point(166, 94);
            txtDueDate.Name = "txtDueDate";
            txtDueDate.Size = new Size(258, 23);
            txtDueDate.TabIndex = 73;
            txtDueDate.ToolTipText = "";
            // 
            // autoLabel2
            // 
            autoLabel2.Location = new Point(50, 99);
            autoLabel2.Name = "autoLabel2";
            autoLabel2.Size = new Size(74, 15);
            autoLabel2.TabIndex = 72;
            autoLabel2.Text = "Bill Due Date";
            // 
            // txtBillType
            // 
            txtBillType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtBillType.AutoCompleteSuggestMode = Syncfusion.WinForms.ListView.Enums.AutoCompleteSuggestMode.Contains;
            txtBillType.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            txtBillType.Location = new Point(166, 135);
            txtBillType.Name = "txtBillType";
            txtBillType.Size = new Size(258, 26);
            txtBillType.Style.TokenStyle.CloseButtonBackColor = Color.FromArgb(255, 255, 255);
            txtBillType.TabIndex = 74;
            txtBillType.TabStop = false;
            // 
            // autoLabel3
            // 
            autoLabel3.Location = new Point(50, 140);
            autoLabel3.Name = "autoLabel3";
            autoLabel3.Size = new Size(50, 15);
            autoLabel3.TabIndex = 75;
            autoLabel3.Text = "Bill Type";
            // 
            // autoLabel4
            // 
            autoLabel4.Location = new Point(50, 184);
            autoLabel4.Name = "autoLabel4";
            autoLabel4.Size = new Size(80, 15);
            autoLabel4.TabIndex = 76;
            autoLabel4.Text = "Vendor D.O. #";
            // 
            // txtVendorDONumber
            // 
            txtVendorDONumber.BeforeTouchSize = new Size(258, 23);
            txtVendorDONumber.Location = new Point(166, 181);
            txtVendorDONumber.Name = "txtVendorDONumber";
            txtVendorDONumber.Size = new Size(258, 23);
            txtVendorDONumber.TabIndex = 77;
            // 
            // txtVendorInvoiceNumber
            // 
            txtVendorInvoiceNumber.BeforeTouchSize = new Size(258, 23);
            txtVendorInvoiceNumber.Location = new Point(166, 222);
            txtVendorInvoiceNumber.Name = "txtVendorInvoiceNumber";
            txtVendorInvoiceNumber.Size = new Size(258, 23);
            txtVendorInvoiceNumber.TabIndex = 79;
            // 
            // autoLabel5
            // 
            autoLabel5.Location = new Point(50, 225);
            autoLabel5.Name = "autoLabel5";
            autoLabel5.Size = new Size(95, 15);
            autoLabel5.TabIndex = 78;
            autoLabel5.Text = "Vendor Invoice #";
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI Semibold", 9F);
            btnSave.Location = new Point(189, 281);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(96, 28);
            btnSave.TabIndex = 80;
            btnSave.Text = "Save";
            btnSave.Click += btnConfirm_Click;
            // 
            // UpsertBillView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(474, 353);
            Controls.Add(btnSave);
            Controls.Add(txtVendorInvoiceNumber);
            Controls.Add(autoLabel5);
            Controls.Add(txtVendorDONumber);
            Controls.Add(autoLabel4);
            Controls.Add(autoLabel3);
            Controls.Add(txtBillType);
            Controls.Add(txtDueDate);
            Controls.Add(autoLabel2);
            Controls.Add(txtDate);
            Controls.Add(autoLabel1);
            Name = "UpsertBillView";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Style.MdiChild.IconHorizontalAlignment = HorizontalAlignment.Center;
            Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            Text = "Bill Details";
            ((System.ComponentModel.ISupportInitialize)txtBillType).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtVendorDONumber).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtVendorInvoiceNumber).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.WinForms.Input.SfDateTimeEdit txtDate;
        private Syncfusion.WinForms.Input.SfDateTimeEdit txtDueDate;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private Syncfusion.WinForms.ListView.SfComboBox txtBillType;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel3;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel4;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtVendorDONumber;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtVendorInvoiceNumber;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel5;
        private Syncfusion.WinForms.Controls.SfButton btnSave;
    }
}