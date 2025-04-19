namespace RavenTech_ERP.Views.UserControls
{
    partial class UpsertPaymentReceiveView
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
            btnSave = new Syncfusion.WinForms.Controls.SfButton();
            txtFullPayment = new Syncfusion.Windows.Forms.Tools.CheckBoxAdv();
            autoLabel3 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtAmount = new Syncfusion.Windows.Forms.Tools.DoubleTextBox();
            autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtPaymentType = new Syncfusion.WinForms.ListView.SfComboBox();
            txtPaymentDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
            autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            linkPaymentList = new LinkLabel();
            ((System.ComponentModel.ISupportInitialize)txtFullPayment).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtAmount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtPaymentType).BeginInit();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI Semibold", 9F);
            btnSave.Location = new Point(169, 204);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(96, 28);
            btnSave.TabIndex = 67;
            btnSave.Text = "Save";
            btnSave.Click += btnConfirm_Click;
            // 
            // txtFullPayment
            // 
            txtFullPayment.AccessibilityEnabled = true;
            txtFullPayment.BeforeTouchSize = new Size(119, 21);
            txtFullPayment.Checked = true;
            txtFullPayment.CheckState = CheckState.Checked;
            txtFullPayment.Location = new Point(161, 157);
            txtFullPayment.Name = "txtFullPayment";
            txtFullPayment.Size = new Size(119, 21);
            txtFullPayment.TabIndex = 66;
            txtFullPayment.Text = "Full Payment?";
            // 
            // autoLabel3
            // 
            autoLabel3.Location = new Point(52, 128);
            autoLabel3.Name = "autoLabel3";
            autoLabel3.Size = new Size(51, 15);
            autoLabel3.TabIndex = 65;
            autoLabel3.Text = "Amount";
            // 
            // txtAmount
            // 
            txtAmount.AccessibilityEnabled = true;
            txtAmount.BeforeTouchSize = new Size(232, 23);
            txtAmount.DoubleValue = 1D;
            txtAmount.Location = new Point(161, 120);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(232, 23);
            txtAmount.TabIndex = 64;
            txtAmount.Text = "1.00";
            // 
            // autoLabel2
            // 
            autoLabel2.Location = new Point(52, 88);
            autoLabel2.Name = "autoLabel2";
            autoLabel2.Size = new Size(31, 15);
            autoLabel2.TabIndex = 63;
            autoLabel2.Text = "Type";
            // 
            // txtPaymentType
            // 
            txtPaymentType.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            txtPaymentType.Location = new Point(161, 77);
            txtPaymentType.Name = "txtPaymentType";
            txtPaymentType.Size = new Size(232, 26);
            txtPaymentType.Style.TokenStyle.CloseButtonBackColor = Color.FromArgb(255, 255, 255);
            txtPaymentType.TabIndex = 62;
            txtPaymentType.TabStop = false;
            // 
            // txtPaymentDate
            // 
            txtPaymentDate.DateTimeIcon = null;
            txtPaymentDate.Location = new Point(161, 38);
            txtPaymentDate.Name = "txtPaymentDate";
            txtPaymentDate.Size = new Size(232, 23);
            txtPaymentDate.TabIndex = 61;
            txtPaymentDate.ToolTipText = "";
            // 
            // autoLabel1
            // 
            autoLabel1.Location = new Point(52, 46);
            autoLabel1.Name = "autoLabel1";
            autoLabel1.Size = new Size(31, 15);
            autoLabel1.TabIndex = 60;
            autoLabel1.Text = "Date";
            // 
            // linkPaymentList
            // 
            linkPaymentList.AutoSize = true;
            linkPaymentList.Location = new Point(286, 163);
            linkPaymentList.Name = "linkPaymentList";
            linkPaymentList.Size = new Size(107, 15);
            linkPaymentList.TabIndex = 59;
            linkPaymentList.TabStop = true;
            linkPaymentList.Text = "Show Payment List";
            linkPaymentList.LinkClicked += linkPaymentList_LinkClicked;
            // 
            // PaymentReceiveView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(458, 270);
            Controls.Add(btnSave);
            Controls.Add(txtFullPayment);
            Controls.Add(autoLabel3);
            Controls.Add(txtAmount);
            Controls.Add(autoLabel2);
            Controls.Add(txtPaymentType);
            Controls.Add(txtPaymentDate);
            Controls.Add(autoLabel1);
            Controls.Add(linkPaymentList);
            Name = "PaymentReceiveView";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Style.MdiChild.IconHorizontalAlignment = HorizontalAlignment.Center;
            Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            Text = "Payment Details";
            ((System.ComponentModel.ISupportInitialize)txtFullPayment).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtAmount).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtPaymentType).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Syncfusion.WinForms.Controls.SfButton btnSave;
        private Syncfusion.Windows.Forms.Tools.CheckBoxAdv txtFullPayment;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel3;
        private Syncfusion.Windows.Forms.Tools.DoubleTextBox txtAmount;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private Syncfusion.WinForms.ListView.SfComboBox txtPaymentType;
        private Syncfusion.WinForms.Input.SfDateTimeEdit txtPaymentDate;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private LinkLabel linkPaymentList;
    }
}