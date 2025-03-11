namespace RavenTech_ERP.Views.UserControls
{
    partial class PaymentReceiveView
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            txtPaymentType = new MaterialSkin.Controls.MaterialComboBox();
            txtAmount = new MaterialSkin.Controls.MaterialTextBox();
            txtPaymentDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            txtFullPayment = new MaterialSkin.Controls.MaterialSwitch();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            btnConfirm = new MaterialSkin.Controls.MaterialButton();
            linkPaymentList = new LinkLabel();
            SuspendLayout();
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
            txtPaymentType.Hint = "Payment Type";
            txtPaymentType.IntegralHeight = false;
            txtPaymentType.ItemHeight = 43;
            txtPaymentType.Location = new Point(79, 208);
            txtPaymentType.MaxDropDownItems = 4;
            txtPaymentType.MouseState = MaterialSkin.MouseState.OUT;
            txtPaymentType.Name = "txtPaymentType";
            txtPaymentType.Size = new Size(374, 49);
            txtPaymentType.StartIndex = 0;
            txtPaymentType.TabIndex = 0;
            // 
            // txtAmount
            // 
            txtAmount.AnimateReadOnly = false;
            txtAmount.BorderStyle = BorderStyle.None;
            txtAmount.Depth = 0;
            txtAmount.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtAmount.Hint = "Amount";
            txtAmount.LeadingIcon = null;
            txtAmount.Location = new Point(79, 283);
            txtAmount.MaxLength = 50;
            txtAmount.MouseState = MaterialSkin.MouseState.OUT;
            txtAmount.Multiline = false;
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(374, 50);
            txtAmount.TabIndex = 1;
            txtAmount.Text = "";
            txtAmount.TrailingIcon = null;
            // 
            // txtPaymentDate
            // 
            txtPaymentDate.Checked = true;
            txtPaymentDate.CustomizableEdges = customizableEdges1;
            txtPaymentDate.FillColor = Color.MidnightBlue;
            txtPaymentDate.Font = new Font("Segoe UI", 10F);
            txtPaymentDate.ForeColor = Color.White;
            txtPaymentDate.Format = DateTimePickerFormat.Long;
            txtPaymentDate.Location = new Point(79, 129);
            txtPaymentDate.Margin = new Padding(3, 2, 3, 2);
            txtPaymentDate.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            txtPaymentDate.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            txtPaymentDate.Name = "txtPaymentDate";
            txtPaymentDate.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtPaymentDate.Size = new Size(374, 53);
            txtPaymentDate.TabIndex = 39;
            txtPaymentDate.Value = new DateTime(2024, 11, 27, 9, 17, 37, 932);
            // 
            // txtFullPayment
            // 
            txtFullPayment.AutoSize = true;
            txtFullPayment.Checked = true;
            txtFullPayment.CheckState = CheckState.Checked;
            txtFullPayment.Depth = 0;
            txtFullPayment.Location = new Point(79, 359);
            txtFullPayment.Margin = new Padding(0);
            txtFullPayment.MouseLocation = new Point(-1, -1);
            txtFullPayment.MouseState = MaterialSkin.MouseState.HOVER;
            txtFullPayment.Name = "txtFullPayment";
            txtFullPayment.Ripple = true;
            txtFullPayment.Size = new Size(159, 37);
            txtFullPayment.TabIndex = 40;
            txtFullPayment.Text = "Full Payment?";
            txtFullPayment.UseVisualStyleBackColor = true;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(79, 98);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(101, 19);
            materialLabel1.TabIndex = 41;
            materialLabel1.Text = "Payment Date";
            // 
            // btnConfirm
            // 
            btnConfirm.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnConfirm.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnConfirm.Depth = 0;
            btnConfirm.HighEmphasis = true;
            btnConfirm.Icon = null;
            btnConfirm.Location = new Point(188, 421);
            btnConfirm.Margin = new Padding(4, 6, 4, 6);
            btnConfirm.MouseState = MaterialSkin.MouseState.HOVER;
            btnConfirm.Name = "btnConfirm";
            btnConfirm.NoAccentTextColor = Color.Empty;
            btnConfirm.Size = new Size(159, 36);
            btnConfirm.TabIndex = 42;
            btnConfirm.Text = "confirm Payment";
            btnConfirm.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnConfirm.UseAccentColor = false;
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // linkPaymentList
            // 
            linkPaymentList.AutoSize = true;
            linkPaymentList.Location = new Point(346, 369);
            linkPaymentList.Name = "linkPaymentList";
            linkPaymentList.Size = new Size(107, 15);
            linkPaymentList.TabIndex = 43;
            linkPaymentList.TabStop = true;
            linkPaymentList.Text = "Show Payment List";
            linkPaymentList.LinkClicked += linkPaymentList_LinkClicked;
            // 
            // PaymentReceiveView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(533, 490);
            Controls.Add(linkPaymentList);
            Controls.Add(btnConfirm);
            Controls.Add(materialLabel1);
            Controls.Add(txtFullPayment);
            Controls.Add(txtPaymentDate);
            Controls.Add(txtAmount);
            Controls.Add(txtPaymentType);
            Name = "PaymentReceiveView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Payment Details";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialComboBox txtPaymentType;
        private MaterialSkin.Controls.MaterialTextBox txtAmount;
        private Guna.UI2.WinForms.Guna2DateTimePicker txtPaymentDate;
        private MaterialSkin.Controls.MaterialSwitch txtFullPayment;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialButton btnConfirm;
        private LinkLabel linkPaymentList;
    }
}