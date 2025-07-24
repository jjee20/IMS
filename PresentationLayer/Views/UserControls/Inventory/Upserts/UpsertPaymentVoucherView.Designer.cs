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
            autoLabel4.Location = new Point(14, 70);
            autoLabel4.Margin = new Padding(4, 0, 4, 0);
            autoLabel4.Name = "autoLabel4";
            autoLabel4.Size = new Size(93, 25);
            autoLabel4.TabIndex = 88;
            autoLabel4.Text = "Cash Bank";
            // 
            // txtCashBank
            // 
            txtCashBank.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtCashBank.AutoCompleteSuggestMode = Syncfusion.WinForms.ListView.Enums.AutoCompleteSuggestMode.Contains;
            txtCashBank.Dock = DockStyle.Top;
            txtCashBank.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            txtCashBank.Location = new Point(14, 95);
            txtCashBank.Margin = new Padding(4, 5, 4, 5);
            txtCashBank.Name = "txtCashBank";
            txtCashBank.Padding = new Padding(10, 0, 0, 0);
            txtCashBank.Size = new Size(566, 31);
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
            btnSave.Location = new Point(14, 343);
            btnSave.Margin = new Padding(4, 5, 4, 5);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(566, 47);
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
            txtFullPayment.BeforeTouchSize = new Size(406, 35);
            txtFullPayment.Checked = true;
            txtFullPayment.CheckState = CheckState.Checked;
            txtFullPayment.Dock = DockStyle.Top;
            txtFullPayment.ImageCheckBoxSize = new Size(19, 19);
            txtFullPayment.Location = new Point(14, 238);
            txtFullPayment.Margin = new Padding(4, 5, 4, 5);
            txtFullPayment.Name = "txtFullPayment";
            txtFullPayment.Size = new Size(406, 35);
            txtFullPayment.TabIndex = 4;
            txtFullPayment.Text = "Full Payment?";
            // 
            // autoLabel3
            // 
            autoLabel3.Dock = DockStyle.Top;
            autoLabel3.Location = new Point(14, 182);
            autoLabel3.Margin = new Padding(4, 0, 4, 0);
            autoLabel3.Name = "autoLabel3";
            autoLabel3.Size = new Size(77, 25);
            autoLabel3.TabIndex = 84;
            autoLabel3.Text = "Amount";
            // 
            // txtAmount
            // 
            txtAmount.AccessibilityEnabled = true;
            txtAmount.BeforeTouchSize = new Size(759, 31);
            txtAmount.Dock = DockStyle.Top;
            txtAmount.DoubleValue = 1D;
            txtAmount.Location = new Point(14, 207);
            txtAmount.Margin = new Padding(4, 5, 4, 5);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(566, 31);
            txtAmount.TabIndex = 3;
            txtAmount.Text = "1.00";
            // 
            // autoLabel2
            // 
            autoLabel2.Dock = DockStyle.Top;
            autoLabel2.Location = new Point(14, 14);
            autoLabel2.Margin = new Padding(4, 0, 4, 0);
            autoLabel2.Name = "autoLabel2";
            autoLabel2.Size = new Size(49, 25);
            autoLabel2.TabIndex = 82;
            autoLabel2.Text = "Type";
            // 
            // txtPaymentType
            // 
            txtPaymentType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtPaymentType.AutoCompleteSuggestMode = Syncfusion.WinForms.ListView.Enums.AutoCompleteSuggestMode.Contains;
            txtPaymentType.Dock = DockStyle.Top;
            txtPaymentType.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            txtPaymentType.Location = new Point(14, 39);
            txtPaymentType.Margin = new Padding(4, 5, 4, 5);
            txtPaymentType.Name = "txtPaymentType";
            txtPaymentType.Padding = new Padding(10, 0, 0, 0);
            txtPaymentType.Size = new Size(566, 31);
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
            txtPaymentDate.Location = new Point(14, 151);
            txtPaymentDate.Margin = new Padding(4, 5, 4, 5);
            txtPaymentDate.Name = "txtPaymentDate";
            txtPaymentDate.Size = new Size(566, 31);
            txtPaymentDate.TabIndex = 2;
            txtPaymentDate.ToolTipText = "";
            // 
            // autoLabel1
            // 
            autoLabel1.Dock = DockStyle.Top;
            autoLabel1.Location = new Point(14, 126);
            autoLabel1.Margin = new Padding(4, 0, 4, 0);
            autoLabel1.Name = "autoLabel1";
            autoLabel1.Size = new Size(49, 25);
            autoLabel1.TabIndex = 79;
            autoLabel1.Text = "Date";
            // 
            // linkPaymentList
            // 
            linkPaymentList.AutoSize = true;
            linkPaymentList.Dock = DockStyle.Right;
            linkPaymentList.Location = new Point(420, 238);
            linkPaymentList.Margin = new Padding(4, 0, 4, 0);
            linkPaymentList.Name = "linkPaymentList";
            linkPaymentList.Size = new Size(160, 25);
            linkPaymentList.TabIndex = 6;
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
            materialCard1.Location = new Point(3, 3);
            materialCard1.Margin = new Padding(14);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(14);
            materialCard1.Size = new Size(594, 404);
            materialCard1.TabIndex = 89;
            // 
            // UpsertPaymentVoucherView
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(144F, 144F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(600, 410);
            Controls.Add(materialCard1);
            Margin = new Padding(4, 5, 4, 5);
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