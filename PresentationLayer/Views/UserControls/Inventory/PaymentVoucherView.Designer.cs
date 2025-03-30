namespace RavenTech_ERP.Views.UserControls
{
    partial class PaymentVoucherView
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
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            txtCashBank = new MaterialSkin.Controls.MaterialComboBox();
            linkPaymentList = new LinkLabel();
            btnConfirm = new MaterialSkin.Controls.MaterialButton();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            txtFullPayment = new MaterialSkin.Controls.MaterialSwitch();
            txtPaymentDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            txtAmount = new MaterialSkin.Controls.MaterialTextBox();
            txtPaymentType = new MaterialSkin.Controls.MaterialComboBox();
            materialCard1.SuspendLayout();
            SuspendLayout();
            // 
            // materialCard1
            // 
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(txtCashBank);
            materialCard1.Controls.Add(linkPaymentList);
            materialCard1.Controls.Add(btnConfirm);
            materialCard1.Controls.Add(materialLabel1);
            materialCard1.Controls.Add(txtFullPayment);
            materialCard1.Controls.Add(txtPaymentDate);
            materialCard1.Controls.Add(txtAmount);
            materialCard1.Controls.Add(txtPaymentType);
            materialCard1.Depth = 0;
            materialCard1.Dock = DockStyle.Fill;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(3, 64);
            materialCard1.Margin = new Padding(14);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(14);
            materialCard1.Size = new Size(527, 511);
            materialCard1.TabIndex = 0;
            // 
            // txtCashBank
            // 
            txtCashBank.AutoResize = false;
            txtCashBank.BackColor = Color.FromArgb(255, 255, 255);
            txtCashBank.Depth = 0;
            txtCashBank.DrawMode = DrawMode.OwnerDrawVariable;
            txtCashBank.DropDownHeight = 174;
            txtCashBank.DropDownStyle = ComboBoxStyle.DropDownList;
            txtCashBank.DropDownWidth = 121;
            txtCashBank.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            txtCashBank.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtCashBank.FormattingEnabled = true;
            txtCashBank.Hint = "Select Cash Bank";
            txtCashBank.IntegralHeight = false;
            txtCashBank.ItemHeight = 43;
            txtCashBank.Location = new Point(76, 298);
            txtCashBank.MaxDropDownItems = 4;
            txtCashBank.MouseState = MaterialSkin.MouseState.OUT;
            txtCashBank.Name = "txtCashBank";
            txtCashBank.Size = new Size(374, 49);
            txtCashBank.StartIndex = 0;
            txtCashBank.TabIndex = 52;
            // 
            // linkPaymentList
            // 
            linkPaymentList.AutoSize = true;
            linkPaymentList.Location = new Point(343, 382);
            linkPaymentList.Name = "linkPaymentList";
            linkPaymentList.Size = new Size(107, 15);
            linkPaymentList.TabIndex = 51;
            linkPaymentList.TabStop = true;
            linkPaymentList.Text = "Show Payment List";
            // 
            // btnConfirm
            // 
            btnConfirm.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnConfirm.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnConfirm.Depth = 0;
            btnConfirm.HighEmphasis = true;
            btnConfirm.Icon = null;
            btnConfirm.Location = new Point(185, 434);
            btnConfirm.Margin = new Padding(4, 6, 4, 6);
            btnConfirm.MouseState = MaterialSkin.MouseState.HOVER;
            btnConfirm.Name = "btnConfirm";
            btnConfirm.NoAccentTextColor = Color.Empty;
            btnConfirm.Size = new Size(159, 36);
            btnConfirm.TabIndex = 50;
            btnConfirm.Text = "confirm voucher";
            btnConfirm.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnConfirm.UseAccentColor = false;
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(76, 40);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(101, 19);
            materialLabel1.TabIndex = 49;
            materialLabel1.Text = "Payment Date";
            // 
            // txtFullPayment
            // 
            txtFullPayment.AutoSize = true;
            txtFullPayment.Checked = true;
            txtFullPayment.CheckState = CheckState.Checked;
            txtFullPayment.Depth = 0;
            txtFullPayment.Location = new Point(76, 372);
            txtFullPayment.Margin = new Padding(0);
            txtFullPayment.MouseLocation = new Point(-1, -1);
            txtFullPayment.MouseState = MaterialSkin.MouseState.HOVER;
            txtFullPayment.Name = "txtFullPayment";
            txtFullPayment.Ripple = true;
            txtFullPayment.Size = new Size(159, 37);
            txtFullPayment.TabIndex = 48;
            txtFullPayment.Text = "Full Payment?";
            txtFullPayment.UseVisualStyleBackColor = true;
            // 
            // txtPaymentDate
            // 
            txtPaymentDate.Checked = true;
            txtPaymentDate.CustomizableEdges = customizableEdges5;
            txtPaymentDate.FillColor = Color.MidnightBlue;
            txtPaymentDate.Font = new Font("Segoe UI", 10F);
            txtPaymentDate.ForeColor = Color.White;
            txtPaymentDate.Format = DateTimePickerFormat.Long;
            txtPaymentDate.Location = new Point(76, 71);
            txtPaymentDate.Margin = new Padding(3, 2, 3, 2);
            txtPaymentDate.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            txtPaymentDate.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            txtPaymentDate.Name = "txtPaymentDate";
            txtPaymentDate.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtPaymentDate.Size = new Size(374, 53);
            txtPaymentDate.TabIndex = 47;
            txtPaymentDate.Value = new DateTime(2024, 11, 27, 9, 17, 37, 932);
            // 
            // txtAmount
            // 
            txtAmount.AnimateReadOnly = false;
            txtAmount.BorderStyle = BorderStyle.None;
            txtAmount.Depth = 0;
            txtAmount.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtAmount.Hint = "Amount";
            txtAmount.LeadingIcon = null;
            txtAmount.Location = new Point(76, 223);
            txtAmount.MaxLength = 50;
            txtAmount.MouseState = MaterialSkin.MouseState.OUT;
            txtAmount.Multiline = false;
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(374, 50);
            txtAmount.TabIndex = 46;
            txtAmount.Text = "";
            txtAmount.TrailingIcon = null;
            // 
            // txtPaymentType
            // 
            txtPaymentType.AutoResize = false;
            txtPaymentType.BackColor = Color.FromArgb(255, 255, 255);
            txtPaymentType.Depth = 0;
            txtPaymentType.DrawMode = DrawMode.OwnerDrawVariable;
            txtPaymentType.DropDownHeight = 174;
            txtPaymentType.DropDownStyle = ComboBoxStyle.DropDownList;
            txtPaymentType.DropDownWidth = 121;
            txtPaymentType.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            txtPaymentType.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtPaymentType.FormattingEnabled = true;
            txtPaymentType.Hint = "Select Payment Type";
            txtPaymentType.IntegralHeight = false;
            txtPaymentType.ItemHeight = 43;
            txtPaymentType.Location = new Point(76, 149);
            txtPaymentType.MaxDropDownItems = 4;
            txtPaymentType.MouseState = MaterialSkin.MouseState.OUT;
            txtPaymentType.Name = "txtPaymentType";
            txtPaymentType.Size = new Size(374, 49);
            txtPaymentType.StartIndex = 0;
            txtPaymentType.TabIndex = 45;
            // 
            // PaymentVoucherView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(533, 578);
            Controls.Add(materialCard1);
            Name = "PaymentVoucherView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "x";
            materialCard1.ResumeLayout(false);
            materialCard1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialCard materialCard1;
        private MaterialSkin.Controls.MaterialComboBox txtCashBank;
        private LinkLabel linkPaymentList;
        private MaterialSkin.Controls.MaterialButton btnConfirm;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialSwitch txtFullPayment;
        private Guna.UI2.WinForms.Guna2DateTimePicker txtPaymentDate;
        private MaterialSkin.Controls.MaterialTextBox txtAmount;
        private MaterialSkin.Controls.MaterialComboBox txtPaymentType;
    }
}