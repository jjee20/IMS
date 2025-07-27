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
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            ((System.ComponentModel.ISupportInitialize)txtFullPayment).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtAmount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtPaymentType).BeginInit();
            materialCard1.SuspendLayout();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.BackColor = SystemColors.HotTrack;
            btnSave.Dock = DockStyle.Bottom;
            btnSave.Font = new Font("Segoe UI Semibold", 9F);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(9, 143);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(285, 31);
            btnSave.Style.BackColor = SystemColors.HotTrack;
            btnSave.Style.ForeColor = Color.White;
            btnSave.TabIndex = 3;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnConfirm_Click;
            // 
            // txtFullPayment
            // 
            txtFullPayment.AccessibilityEnabled = true;
            txtFullPayment.BeforeTouchSize = new Size(178, 23);
            txtFullPayment.Checked = true;
            txtFullPayment.CheckState = CheckState.Checked;
            txtFullPayment.Dock = DockStyle.Top;
            txtFullPayment.ImageCheckBoxSize = new Size(19, 19);
            txtFullPayment.Location = new Point(9, 83);
            txtFullPayment.Name = "txtFullPayment";
            txtFullPayment.Size = new Size(178, 23);
            txtFullPayment.TabIndex = 2;
            txtFullPayment.Text = "Full Payment?";
            // 
            // autoLabel3
            // 
            autoLabel3.Dock = DockStyle.Top;
            autoLabel3.Location = new Point(9, 45);
            autoLabel3.Name = "autoLabel3";
            autoLabel3.Size = new Size(51, 15);
            autoLabel3.TabIndex = 65;
            autoLabel3.Text = "Amount";
            // 
            // txtAmount
            // 
            txtAmount.AccessibilityEnabled = true;
            txtAmount.BeforeTouchSize = new Size(285, 23);
            txtAmount.Dock = DockStyle.Top;
            txtAmount.DoubleValue = 1D;
            txtAmount.Location = new Point(9, 60);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(285, 23);
            txtAmount.TabIndex = 1;
            txtAmount.Text = "1.00";
            // 
            // autoLabel2
            // 
            autoLabel2.Dock = DockStyle.Top;
            autoLabel2.Location = new Point(9, 9);
            autoLabel2.Name = "autoLabel2";
            autoLabel2.Size = new Size(31, 15);
            autoLabel2.TabIndex = 63;
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
            txtPaymentType.Size = new Size(285, 21);
            txtPaymentType.Style.TokenStyle.CloseButtonBackColor = Color.FromArgb(255, 255, 255);
            txtPaymentType.TabIndex = 0;
            txtPaymentType.TabStop = false;
            // 
            // txtPaymentDate
            // 
            txtPaymentDate.DateTimeIcon = null;
            txtPaymentDate.Location = new Point(133, -26);
            txtPaymentDate.Name = "txtPaymentDate";
            txtPaymentDate.Size = new Size(221, 25);
            txtPaymentDate.TabIndex = 61;
            txtPaymentDate.ToolTipText = "";
            // 
            // autoLabel1
            // 
            autoLabel1.Location = new Point(29, -17);
            autoLabel1.Name = "autoLabel1";
            autoLabel1.Size = new Size(31, 15);
            autoLabel1.TabIndex = 60;
            autoLabel1.Text = "Date";
            // 
            // linkPaymentList
            // 
            linkPaymentList.AutoSize = true;
            linkPaymentList.Dock = DockStyle.Right;
            linkPaymentList.Location = new Point(187, 83);
            linkPaymentList.Name = "linkPaymentList";
            linkPaymentList.Size = new Size(107, 15);
            linkPaymentList.TabIndex = 4;
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
            materialCard1.Controls.Add(autoLabel1);
            materialCard1.Controls.Add(txtPaymentDate);
            materialCard1.Controls.Add(txtAmount);
            materialCard1.Controls.Add(autoLabel3);
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
            materialCard1.Size = new Size(303, 183);
            materialCard1.TabIndex = 68;
            // 
            // UpsertPaymentReceiveView
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(305, 185);
            Controls.Add(materialCard1);
            Name = "UpsertPaymentReceiveView";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Style.MdiChild.IconHorizontalAlignment = HorizontalAlignment.Center;
            Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            Text = "Payment Details";
            ((System.ComponentModel.ISupportInitialize)txtFullPayment).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtAmount).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtPaymentType).EndInit();
            materialCard1.ResumeLayout(false);
            materialCard1.PerformLayout();
            ResumeLayout(false);
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
        private MaterialSkin.Controls.MaterialCard materialCard1;
    }
}