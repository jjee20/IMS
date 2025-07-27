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
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            btnSave = new Syncfusion.WinForms.Controls.SfButton();
            ((System.ComponentModel.ISupportInitialize)txtBillType).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtVendorDONumber).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtVendorInvoiceNumber).BeginInit();
            materialCard1.SuspendLayout();
            SuspendLayout();
            // 
            // autoLabel1
            // 
            autoLabel1.Dock = DockStyle.Top;
            autoLabel1.Location = new Point(9, 53);
            autoLabel1.Name = "autoLabel1";
            autoLabel1.Size = new Size(50, 15);
            autoLabel1.TabIndex = 70;
            autoLabel1.Text = "Bill Date";
            // 
            // txtDate
            // 
            txtDate.DateTimeIcon = null;
            txtDate.Dock = DockStyle.Top;
            txtDate.Location = new Point(9, 68);
            txtDate.Name = "txtDate";
            txtDate.Size = new Size(321, 28);
            txtDate.TabIndex = 71;
            txtDate.ToolTipText = "";
            // 
            // txtDueDate
            // 
            txtDueDate.DateTimeIcon = null;
            txtDueDate.Dock = DockStyle.Top;
            txtDueDate.Location = new Point(9, 111);
            txtDueDate.Name = "txtDueDate";
            txtDueDate.Size = new Size(321, 25);
            txtDueDate.TabIndex = 73;
            txtDueDate.ToolTipText = "";
            // 
            // autoLabel2
            // 
            autoLabel2.Dock = DockStyle.Top;
            autoLabel2.Location = new Point(9, 96);
            autoLabel2.Name = "autoLabel2";
            autoLabel2.Size = new Size(74, 15);
            autoLabel2.TabIndex = 72;
            autoLabel2.Text = "Bill Due Date";
            // 
            // txtBillType
            // 
            txtBillType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtBillType.AutoCompleteSuggestMode = Syncfusion.WinForms.ListView.Enums.AutoCompleteSuggestMode.Contains;
            txtBillType.Dock = DockStyle.Top;
            txtBillType.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            txtBillType.Location = new Point(9, 24);
            txtBillType.Name = "txtBillType";
            txtBillType.Size = new Size(321, 29);
            txtBillType.Style.TokenStyle.CloseButtonBackColor = Color.FromArgb(255, 255, 255);
            txtBillType.TabIndex = 74;
            txtBillType.TabStop = false;
            // 
            // autoLabel3
            // 
            autoLabel3.Dock = DockStyle.Top;
            autoLabel3.Location = new Point(9, 9);
            autoLabel3.Name = "autoLabel3";
            autoLabel3.Size = new Size(50, 15);
            autoLabel3.TabIndex = 75;
            autoLabel3.Text = "Bill Type";
            // 
            // autoLabel4
            // 
            autoLabel4.Dock = DockStyle.Top;
            autoLabel4.Location = new Point(9, 136);
            autoLabel4.Name = "autoLabel4";
            autoLabel4.Size = new Size(80, 15);
            autoLabel4.TabIndex = 76;
            autoLabel4.Text = "Vendor D.O. #";
            // 
            // txtVendorDONumber
            // 
            txtVendorDONumber.BeforeTouchSize = new Size(321, 23);
            txtVendorDONumber.Dock = DockStyle.Top;
            txtVendorDONumber.Location = new Point(9, 151);
            txtVendorDONumber.Name = "txtVendorDONumber";
            txtVendorDONumber.Size = new Size(321, 23);
            txtVendorDONumber.TabIndex = 77;
            // 
            // txtVendorInvoiceNumber
            // 
            txtVendorInvoiceNumber.BeforeTouchSize = new Size(321, 23);
            txtVendorInvoiceNumber.Dock = DockStyle.Top;
            txtVendorInvoiceNumber.Location = new Point(9, 189);
            txtVendorInvoiceNumber.Name = "txtVendorInvoiceNumber";
            txtVendorInvoiceNumber.Size = new Size(321, 23);
            txtVendorInvoiceNumber.TabIndex = 79;
            // 
            // autoLabel5
            // 
            autoLabel5.Dock = DockStyle.Top;
            autoLabel5.Location = new Point(9, 174);
            autoLabel5.Name = "autoLabel5";
            autoLabel5.Size = new Size(95, 15);
            autoLabel5.TabIndex = 78;
            autoLabel5.Text = "Vendor Invoice #";
            // 
            // materialCard1
            // 
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(btnSave);
            materialCard1.Controls.Add(txtVendorInvoiceNumber);
            materialCard1.Controls.Add(autoLabel5);
            materialCard1.Controls.Add(txtVendorDONumber);
            materialCard1.Controls.Add(autoLabel4);
            materialCard1.Controls.Add(txtDueDate);
            materialCard1.Controls.Add(autoLabel2);
            materialCard1.Controls.Add(txtDate);
            materialCard1.Controls.Add(autoLabel1);
            materialCard1.Controls.Add(txtBillType);
            materialCard1.Controls.Add(autoLabel3);
            materialCard1.Depth = 0;
            materialCard1.Dock = DockStyle.Fill;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(2, 2);
            materialCard1.Margin = new Padding(9);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(9);
            materialCard1.Size = new Size(339, 312);
            materialCard1.TabIndex = 81;
            // 
            // btnSave
            // 
            btnSave.BackColor = SystemColors.HotTrack;
            btnSave.Dock = DockStyle.Bottom;
            btnSave.Font = new Font("Segoe UI Semibold", 9F);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(9, 272);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(321, 31);
            btnSave.Style.BackColor = SystemColors.HotTrack;
            btnSave.Style.ForeColor = Color.White;
            btnSave.TabIndex = 80;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnConfirm_Click;
            // 
            // UpsertBillView
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(343, 316);
            Controls.Add(materialCard1);
            Name = "UpsertBillView";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Style.MdiChild.IconHorizontalAlignment = HorizontalAlignment.Center;
            Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            Text = "Bill Details";
            ((System.ComponentModel.ISupportInitialize)txtBillType).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtVendorDONumber).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtVendorInvoiceNumber).EndInit();
            materialCard1.ResumeLayout(false);
            materialCard1.PerformLayout();
            ResumeLayout(false);
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
        private MaterialSkin.Controls.MaterialCard materialCard1;
        private Syncfusion.WinForms.Controls.SfButton btnSave;
    }
}