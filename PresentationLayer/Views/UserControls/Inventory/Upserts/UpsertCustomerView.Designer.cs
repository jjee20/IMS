﻿namespace RavenTech_ERP.Views.UserControls.Inventory
{
    partial class UpsertCustomerView
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(UpsertCustomerView));
            autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtName = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtPhone = new Syncfusion.Windows.Forms.Tools.MaskedEditBox();
            autoLabel3 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel4 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtEmail = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            txtContactPerson = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            autoLabel5 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel6 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtAddress = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            btnSave = new Syncfusion.WinForms.Controls.SfButton();
            txtCustomerType = new Syncfusion.WinForms.ListView.SfComboBox();
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            ((System.ComponentModel.ISupportInitialize)txtName).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtPhone).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtEmail).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtContactPerson).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtAddress).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtCustomerType).BeginInit();
            materialCard1.SuspendLayout();
            SuspendLayout();
            // 
            // autoLabel1
            // 
            autoLabel1.Dock = DockStyle.Top;
            autoLabel1.Location = new Point(9, 45);
            autoLabel1.Name = "autoLabel1";
            autoLabel1.Size = new Size(39, 15);
            autoLabel1.TabIndex = 0;
            autoLabel1.Text = "Name";
            // 
            // txtName
            // 
            txtName.BeforeTouchSize = new Size(396, 23);
            txtName.Dock = DockStyle.Top;
            txtName.Location = new Point(9, 60);
            txtName.Name = "txtName";
            txtName.Size = new Size(361, 23);
            txtName.TabIndex = 1;
            // 
            // autoLabel2
            // 
            autoLabel2.Dock = DockStyle.Top;
            autoLabel2.Location = new Point(9, 9);
            autoLabel2.Name = "autoLabel2";
            autoLabel2.Size = new Size(31, 15);
            autoLabel2.TabIndex = 2;
            autoLabel2.Text = "Type";
            // 
            // txtPhone
            // 
            txtPhone.AccessibilityEnabled = true;
            txtPhone.BeforeTouchSize = new Size(396, 23);
            txtPhone.Dock = DockStyle.Top;
            txtPhone.Lines = new string[]
    {
    "(    )-(   )-(    )"
    };
            txtPhone.Location = new Point(9, 136);
            txtPhone.Mask = "(####)-(###)-(####)";
            txtPhone.MaxLength = 19;
            txtPhone.Modified = false;
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(361, 23);
            txtPhone.TabIndex = 3;
            // 
            // autoLabel3
            // 
            autoLabel3.Dock = DockStyle.Top;
            autoLabel3.Location = new Point(9, 121);
            autoLabel3.Name = "autoLabel3";
            autoLabel3.Size = new Size(51, 15);
            autoLabel3.TabIndex = 7;
            autoLabel3.Text = "Phone #";
            // 
            // autoLabel4
            // 
            autoLabel4.Dock = DockStyle.Top;
            autoLabel4.Location = new Point(9, 83);
            autoLabel4.Name = "autoLabel4";
            autoLabel4.Size = new Size(36, 15);
            autoLabel4.TabIndex = 9;
            autoLabel4.Text = "Email";
            // 
            // txtEmail
            // 
            txtEmail.BeforeTouchSize = new Size(396, 23);
            txtEmail.Dock = DockStyle.Top;
            txtEmail.Location = new Point(9, 98);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(361, 23);
            txtEmail.TabIndex = 2;
            // 
            // txtContactPerson
            // 
            txtContactPerson.BeforeTouchSize = new Size(396, 23);
            txtContactPerson.Dock = DockStyle.Top;
            txtContactPerson.Location = new Point(9, 174);
            txtContactPerson.Name = "txtContactPerson";
            txtContactPerson.Size = new Size(361, 23);
            txtContactPerson.TabIndex = 4;
            // 
            // autoLabel5
            // 
            autoLabel5.Dock = DockStyle.Top;
            autoLabel5.Location = new Point(9, 159);
            autoLabel5.Name = "autoLabel5";
            autoLabel5.Size = new Size(88, 15);
            autoLabel5.TabIndex = 11;
            autoLabel5.Text = "Contact Person";
            // 
            // autoLabel6
            // 
            autoLabel6.Dock = DockStyle.Top;
            autoLabel6.Location = new Point(9, 197);
            autoLabel6.Name = "autoLabel6";
            autoLabel6.Size = new Size(49, 15);
            autoLabel6.TabIndex = 13;
            autoLabel6.Text = "Address";
            // 
            // txtAddress
            // 
            txtAddress.BeforeTouchSize = new Size(396, 23);
            txtAddress.Dock = DockStyle.Top;
            txtAddress.Location = new Point(9, 212);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(361, 91);
            txtAddress.TabIndex = 5;
            // 
            // btnSave
            // 
            btnSave.BackColor = SystemColors.HotTrack;
            btnSave.Dock = DockStyle.Bottom;
            btnSave.Font = new Font("Segoe UI Semibold", 9F);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(9, 341);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(361, 31);
            btnSave.Style.BackColor = SystemColors.HotTrack;
            btnSave.Style.ForeColor = Color.White;
            btnSave.TabIndex = 6;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // txtCustomerType
            // 
            txtCustomerType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtCustomerType.AutoCompleteSuggestMode = Syncfusion.WinForms.ListView.Enums.AutoCompleteSuggestMode.Contains;
            txtCustomerType.Dock = DockStyle.Top;
            txtCustomerType.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            txtCustomerType.Location = new Point(9, 24);
            txtCustomerType.Name = "txtCustomerType";
            txtCustomerType.Size = new Size(361, 21);
            txtCustomerType.Style.TokenStyle.CloseButtonBackColor = Color.FromArgb(255, 255, 255);
            txtCustomerType.TabIndex = 0;
            txtCustomerType.TabStop = false;
            // 
            // materialCard1
            // 
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(btnSave);
            materialCard1.Controls.Add(txtAddress);
            materialCard1.Controls.Add(autoLabel6);
            materialCard1.Controls.Add(txtContactPerson);
            materialCard1.Controls.Add(autoLabel5);
            materialCard1.Controls.Add(txtPhone);
            materialCard1.Controls.Add(autoLabel3);
            materialCard1.Controls.Add(txtEmail);
            materialCard1.Controls.Add(autoLabel4);
            materialCard1.Controls.Add(txtName);
            materialCard1.Controls.Add(autoLabel1);
            materialCard1.Controls.Add(txtCustomerType);
            materialCard1.Controls.Add(autoLabel2);
            materialCard1.Depth = 0;
            materialCard1.Dock = DockStyle.Fill;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(2, 2);
            materialCard1.Margin = new Padding(9);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(9);
            materialCard1.Size = new Size(379, 381);
            materialCard1.TabIndex = 17;
            // 
            // UpsertCustomerView
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(383, 385);
            Controls.Add(materialCard1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "UpsertCustomerView";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Style.MdiChild.IconHorizontalAlignment = HorizontalAlignment.Center;
            Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            Text = "Add Customer";
            ((System.ComponentModel.ISupportInitialize)txtName).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtPhone).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtEmail).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtContactPerson).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtAddress).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtCustomerType).EndInit();
            materialCard1.ResumeLayout(false);
            materialCard1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtName;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private Syncfusion.Windows.Forms.Tools.MaskedEditBox txtPhone;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel3;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel4;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtEmail;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtContactPerson;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel5;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel6;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtAddress;
        private Syncfusion.WinForms.Controls.SfButton btnSave;
        private Syncfusion.WinForms.ListView.SfComboBox txtCustomerType;
        private MaterialSkin.Controls.MaterialCard materialCard1;
    }
}