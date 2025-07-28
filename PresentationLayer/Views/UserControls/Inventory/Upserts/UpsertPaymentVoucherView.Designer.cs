namespace RavenTech_ERP.Views.UserControls
{
    partial class UpsertPaymentVoucherView
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
            autoLabel4 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtCashBank = new Syncfusion.WinForms.ListView.SfComboBox();
            btnSave = new Syncfusion.WinForms.Controls.SfButton();
            txtFullPayment = new Syncfusion.Windows.Forms.Tools.CheckBoxAdv();
            autoLabel3 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtAmount = new Syncfusion.Windows.Forms.Tools.DoubleTextBox();
            autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtPaymentType = new Syncfusion.WinForms.ListView.SfComboBox();
            txtPaymentDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
            autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            linkPaymentList = new LinkLabel();
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            ((System.ComponentModel.ISupportInitialize)txtCashBank).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtFullPayment).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtAmount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtPaymentType).BeginInit();
            materialCard1.SuspendLayout();
            SuspendLayout();
            // 
            // autoLabel4
            // 
            autoLabel4.Dock = DockStyle.Top;
            autoLabel4.Location = new Point(9, 45);
            autoLabel4.Name = "autoLabel4";
            autoLabel4.Size = new Size(62, 15);
            autoLabel4.TabIndex = 88;
            autoLabel4.Text = "Cash Bank";
            // 
            // txtCashBank
            // 
            txtCashBank.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtCashBank.AutoCompleteSuggestMode = Syncfusion.WinForms.ListView.Enums.AutoCompleteSuggestMode.Contains;
            txtCashBank.Dock = DockStyle.Top;
            txtCashBank.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            txtCashBank.Location = new Point(9, 60);
            txtCashBank.Name = "txtCashBank";
            txtCashBank.Size = new Size(380, 21);
            txtCashBank.Style.TokenStyle.CloseButtonBackColor = Color.FromArgb(255, 255, 255);
            txtCashBank.TabIndex = 1;
            txtCashBank.TabStop = false;
            // 
            // btnSave
            // 
            btnSave.BackColor = SystemColors.Highlight;
            btnSave.Dock = DockStyle.Bottom;
            btnSave.Font = new Font("Segoe UI Semibold", 9F);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(9, 231);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(380, 31);
            btnSave.Style.BackColor = SystemColors.Highlight;
            btnSave.Style.ForeColor = Color.White;
            btnSave.TabIndex = 5;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnConfirm_Click;
            // 
            // txtFullPayment
            // 
            txtFullPayment.AccessibilityEnabled = true;
            txtFullPayment.BeforeTouchSize = new Size(273, 23);
            txtFullPayment.Checked = true;
            txtFullPayment.CheckState = CheckState.Checked;
            txtFullPayment.Dock = DockStyle.Top;
            txtFullPayment.ImageCheckBoxSize = new Size(19, 19);
            txtFullPayment.Location = new Point(9, 155);
            txtFullPayment.Name = "txtFullPayment";
            txtFullPayment.Size = new Size(273, 23);
            txtFullPayment.TabIndex = 4;
            txtFullPayment.Text = "Full Payment?";
            // 
            // autoLabel3
            // 
            autoLabel3.Dock = DockStyle.Top;
            autoLabel3.Location = new Point(9, 117);
            autoLabel3.Name = "autoLabel3";
            autoLabel3.Size = new Size(51, 15);
            autoLabel3.TabIndex = 84;
            autoLabel3.Text = "Amount";
            // 
            // txtAmount
            // 
            txtAmount.AccessibilityEnabled = true;
            txtAmount.BeforeTouchSize = new Size(380, 23);
            txtAmount.Dock = DockStyle.Top;
            txtAmount.DoubleValue = 1D;
            txtAmount.Location = new Point(9, 132);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(380, 23);
            txtAmount.TabIndex = 3;
            txtAmount.Text = "1.00";
            // 
            // autoLabel2
            // 
            autoLabel2.Dock = DockStyle.Top;
            autoLabel2.Location = new Point(9, 9);
            autoLabel2.Name = "autoLabel2";
            autoLabel2.Size = new Size(31, 15);
            autoLabel2.TabIndex = 82;
            autoLabel2.Text = "Type";
            // 
            // txtPaymentType
            // 
            txtPaymentType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtPaymentType.AutoCompleteSuggestMode = Syncfusion.WinForms.ListView.Enums.AutoCompleteSuggestMode.Contains;
            txtPaymentType.Dock = DockStyle.Top;
            txtPaymentType.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            txtPaymentType.Location = new Point(9, 24);
            txtPaymentType.Name = "txtPaymentType";
            txtPaymentType.Size = new Size(380, 21);
            txtPaymentType.Style.TokenStyle.CloseButtonBackColor = Color.FromArgb(255, 255, 255);
            txtPaymentType.TabIndex = 0;
            txtPaymentType.TabStop = false;
            // 
            // txtPaymentDate
            // 
            txtPaymentDate.DateTimeIcon = null;
            txtPaymentDate.DateTimePattern = Syncfusion.WinForms.Input.Enums.DateTimePattern.Custom;
            txtPaymentDate.Dock = DockStyle.Top;
            txtPaymentDate.Format = "MMMM dd, yyyy";
            txtPaymentDate.Location = new Point(9, 96);
            txtPaymentDate.Name = "txtPaymentDate";
            txtPaymentDate.Size = new Size(380, 21);
            txtPaymentDate.TabIndex = 2;
            txtPaymentDate.ToolTipText = "";
            // 
            // autoLabel1
            // 
            autoLabel1.Dock = DockStyle.Top;
            autoLabel1.Location = new Point(9, 81);
            autoLabel1.Name = "autoLabel1";
            autoLabel1.Size = new Size(31, 15);
            autoLabel1.TabIndex = 79;
            autoLabel1.Text = "Date";
            // 
            // linkPaymentList
            // 
            linkPaymentList.AutoSize = true;
            linkPaymentList.Dock = DockStyle.Right;
            linkPaymentList.Location = new Point(282, 155);
            linkPaymentList.Name = "linkPaymentList";
            linkPaymentList.Size = new Size(107, 15);
            linkPaymentList.TabIndex = 6;
            linkPaymentList.TabStop = true;
            linkPaymentList.Text = "Show Payment List";
            linkPaymentList.LinkClicked += linkPaymentList_LinkClicked;
            // 
            // materialCard1
            // 
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(txtFullPayment);
            materialCard1.Controls.Add(linkPaymentList);
            materialCard1.Controls.Add(btnSave);
            materialCard1.Controls.Add(txtAmount);
            materialCard1.Controls.Add(autoLabel3);
            materialCard1.Controls.Add(txtPaymentDate);
            materialCard1.Controls.Add(autoLabel1);
            materialCard1.Controls.Add(txtCashBank);
            materialCard1.Controls.Add(autoLabel4);
            materialCard1.Controls.Add(txtPaymentType);
            materialCard1.Controls.Add(autoLabel2);
            materialCard1.Depth = 0;
            materialCard1.Dock = DockStyle.Fill;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(1, 1);
            materialCard1.Margin = new Padding(9, 9, 9, 9);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(9, 9, 9, 9);
            materialCard1.Size = new Size(398, 271);
            materialCard1.TabIndex = 89;
            // 
            // UpsertPaymentVoucherView
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(400, 273);
            Controls.Add(materialCard1);
            Name = "UpsertPaymentVoucherView";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Style.MdiChild.IconHorizontalAlignment = HorizontalAlignment.Center;
            Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            Text = "Payment Voucher";
            ((System.ComponentModel.ISupportInitialize)txtCashBank).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtFullPayment).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtAmount).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtPaymentType).EndInit();
            materialCard1.ResumeLayout(false);
            materialCard1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel4;
        private Syncfusion.WinForms.ListView.SfComboBox txtCashBank;
        private Syncfusion.WinForms.Controls.SfButton btnSave;
        private Syncfusion.Windows.Forms.Tools.CheckBoxAdv txtFullPayment;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel3;
        private Syncfusion.Windows.Forms.Tools.DoubleTextBox txtAmount;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private Syncfusion.WinForms.ListView.SfComboBox txtPaymentType;
        private Syncfusion.WinForms.Input.SfDateTimeEdit txtPaymentDate;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private LinkLabel linkPaymentList;
        private MaterialSkin.Controls.MaterialCard materialCard1;
    }
}