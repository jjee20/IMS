namespace RavenTech_ERP.Views.UserControls.Inventory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpsertCustomerView));
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
            ((System.ComponentModel.ISupportInitialize)txtName).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtPhone).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtEmail).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtContactPerson).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtAddress).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtCustomerType).BeginInit();
            SuspendLayout();
            // 
            // autoLabel1
            // 
            autoLabel1.Location = new Point(89, 57);
            autoLabel1.Name = "autoLabel1";
            autoLabel1.Size = new Size(39, 15);
            autoLabel1.TabIndex = 0;
            autoLabel1.Text = "Name";
            // 
            // txtName
            // 
            txtName.BeforeTouchSize = new Size(206, 82);
            txtName.Location = new Point(189, 51);
            txtName.Name = "txtName";
            txtName.Size = new Size(206, 23);
            txtName.TabIndex = 1;
            // 
            // autoLabel2
            // 
            autoLabel2.Location = new Point(89, 97);
            autoLabel2.Name = "autoLabel2";
            autoLabel2.Size = new Size(31, 15);
            autoLabel2.TabIndex = 2;
            autoLabel2.Text = "Type";
            // 
            // txtPhone
            // 
            txtPhone.AccessibilityEnabled = true;
            txtPhone.BeforeTouchSize = new Size(206, 82);
            txtPhone.Lines = new string[]
    {
    "(    )-(   )-(    )"
    };
            txtPhone.Location = new Point(189, 133);
            txtPhone.Mask = "(####)-(###)-(####)";
            txtPhone.MaxLength = 19;
            txtPhone.Modified = false;
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(206, 23);
            txtPhone.TabIndex = 6;
            // 
            // autoLabel3
            // 
            autoLabel3.Location = new Point(89, 137);
            autoLabel3.Name = "autoLabel3";
            autoLabel3.Size = new Size(51, 15);
            autoLabel3.TabIndex = 7;
            autoLabel3.Text = "Phone #";
            // 
            // autoLabel4
            // 
            autoLabel4.Location = new Point(89, 177);
            autoLabel4.Name = "autoLabel4";
            autoLabel4.Size = new Size(36, 15);
            autoLabel4.TabIndex = 9;
            autoLabel4.Text = "Email";
            // 
            // txtEmail
            // 
            txtEmail.BeforeTouchSize = new Size(206, 82);
            txtEmail.Location = new Point(189, 174);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(206, 23);
            txtEmail.TabIndex = 10;
            // 
            // txtContactPerson
            // 
            txtContactPerson.BeforeTouchSize = new Size(206, 82);
            txtContactPerson.Location = new Point(189, 215);
            txtContactPerson.Name = "txtContactPerson";
            txtContactPerson.Size = new Size(206, 23);
            txtContactPerson.TabIndex = 12;
            // 
            // autoLabel5
            // 
            autoLabel5.Location = new Point(89, 217);
            autoLabel5.Name = "autoLabel5";
            autoLabel5.Size = new Size(88, 15);
            autoLabel5.TabIndex = 11;
            autoLabel5.Text = "Contact Person";
            // 
            // autoLabel6
            // 
            autoLabel6.Location = new Point(89, 257);
            autoLabel6.Name = "autoLabel6";
            autoLabel6.Size = new Size(49, 15);
            autoLabel6.TabIndex = 13;
            autoLabel6.Text = "Address";
            // 
            // txtAddress
            // 
            txtAddress.BeforeTouchSize = new Size(206, 82);
            txtAddress.Location = new Point(189, 256);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(206, 82);
            txtAddress.TabIndex = 14;
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI Semibold", 9F);
            btnSave.Location = new Point(194, 359);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(96, 28);
            btnSave.TabIndex = 15;
            btnSave.Text = "Save";
            btnSave.Click += btnSave_Click;
            // 
            // txtCustomerType
            // 
            txtCustomerType.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            txtCustomerType.Location = new Point(189, 91);
            txtCustomerType.Name = "txtCustomerType";
            txtCustomerType.Size = new Size(206, 26);
            txtCustomerType.Style.TokenStyle.CloseButtonBackColor = Color.FromArgb(255, 255, 255);
            txtCustomerType.TabIndex = 16;
            txtCustomerType.TabStop = false;
            // 
            // UpsertCustomerView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 447);
            Controls.Add(txtCustomerType);
            Controls.Add(btnSave);
            Controls.Add(txtAddress);
            Controls.Add(autoLabel6);
            Controls.Add(txtContactPerson);
            Controls.Add(autoLabel5);
            Controls.Add(txtEmail);
            Controls.Add(autoLabel4);
            Controls.Add(autoLabel3);
            Controls.Add(txtPhone);
            Controls.Add(autoLabel2);
            Controls.Add(txtName);
            Controls.Add(autoLabel1);
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
            ResumeLayout(false);
            PerformLayout();
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
    }
}