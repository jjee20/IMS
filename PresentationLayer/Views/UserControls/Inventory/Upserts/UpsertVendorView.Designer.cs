namespace RavenTech_ERP.Views.UserControls.Inventory
{
    partial class UpsertVendorView
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(UpsertVendorView));
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            btnSave = new Syncfusion.WinForms.Controls.SfButton();
            txtAddress = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            autoLabel6 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtContactPerson = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            autoLabel5 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtEmail = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            autoLabel4 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtPhone = new Syncfusion.Windows.Forms.Tools.MaskedEditBox();
            autoLabel3 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtName = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtVendorType = new Syncfusion.WinForms.ListView.SfComboBox();
            autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            materialCard1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtAddress).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtContactPerson).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtEmail).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtPhone).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtName).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtVendorType).BeginInit();
            SuspendLayout();
            // 
            // materialCard1
            // 
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(btnSave);
            materialCard1.Controls.Add(txtAddress);
            materialCard1.Controls.Add(autoLabel6);
            materialCard1.Controls.Add(txtContactPerson);
            materialCard1.Controls.Add(autoLabel5);
            materialCard1.Controls.Add(txtEmail);
            materialCard1.Controls.Add(autoLabel4);
            materialCard1.Controls.Add(txtPhone);
            materialCard1.Controls.Add(autoLabel3);
            materialCard1.Controls.Add(txtName);
            materialCard1.Controls.Add(autoLabel1);
            materialCard1.Controls.Add(txtVendorType);
            materialCard1.Controls.Add(autoLabel2);
            materialCard1.Depth = 0;
            materialCard1.Dock = DockStyle.Fill;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(2, 2);
            materialCard1.Margin = new Padding(14);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(14);
            materialCard1.Size = new Size(371, 390);
            materialCard1.TabIndex = 0;
            // 
            // btnSave
            // 
            btnSave.BackColor = SystemColors.HotTrack;
            btnSave.Dock = DockStyle.Bottom;
            btnSave.Font = new Font("Segoe UI Semibold", 9F);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(14, 348);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(343, 28);
            btnSave.Style.BackColor = SystemColors.HotTrack;
            btnSave.Style.ForeColor = Color.White;
            btnSave.TabIndex = 28;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // txtAddress
            // 
            txtAddress.BeforeTouchSize = new Size(289, 23);
            txtAddress.Dock = DockStyle.Top;
            txtAddress.Location = new Point(14, 222);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(343, 82);
            txtAddress.TabIndex = 27;
            // 
            // autoLabel6
            // 
            autoLabel6.Dock = DockStyle.Top;
            autoLabel6.Location = new Point(14, 207);
            autoLabel6.Name = "autoLabel6";
            autoLabel6.Size = new Size(49, 15);
            autoLabel6.TabIndex = 26;
            autoLabel6.Text = "Address";
            // 
            // txtContactPerson
            // 
            txtContactPerson.BeforeTouchSize = new Size(289, 23);
            txtContactPerson.Dock = DockStyle.Top;
            txtContactPerson.Location = new Point(14, 184);
            txtContactPerson.Name = "txtContactPerson";
            txtContactPerson.Size = new Size(343, 23);
            txtContactPerson.TabIndex = 25;
            // 
            // autoLabel5
            // 
            autoLabel5.Dock = DockStyle.Top;
            autoLabel5.Location = new Point(14, 169);
            autoLabel5.Name = "autoLabel5";
            autoLabel5.Size = new Size(88, 15);
            autoLabel5.TabIndex = 24;
            autoLabel5.Text = "Contact Person";
            // 
            // txtEmail
            // 
            txtEmail.BeforeTouchSize = new Size(289, 23);
            txtEmail.Dock = DockStyle.Top;
            txtEmail.Location = new Point(14, 146);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(343, 23);
            txtEmail.TabIndex = 23;
            // 
            // autoLabel4
            // 
            autoLabel4.Dock = DockStyle.Top;
            autoLabel4.Location = new Point(14, 131);
            autoLabel4.Name = "autoLabel4";
            autoLabel4.Size = new Size(36, 15);
            autoLabel4.TabIndex = 22;
            autoLabel4.Text = "Email";
            // 
            // txtPhone
            // 
            txtPhone.AccessibilityEnabled = true;
            txtPhone.BeforeTouchSize = new Size(289, 23);
            txtPhone.Dock = DockStyle.Top;
            txtPhone.Lines = new string[]
    {
    "(    )-(   )-(    )"
    };
            txtPhone.Location = new Point(14, 108);
            txtPhone.Mask = "(####)-(###)-(####)";
            txtPhone.MaxLength = 19;
            txtPhone.Modified = false;
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(343, 23);
            txtPhone.TabIndex = 20;
            // 
            // autoLabel3
            // 
            autoLabel3.Dock = DockStyle.Top;
            autoLabel3.Location = new Point(14, 93);
            autoLabel3.Name = "autoLabel3";
            autoLabel3.Size = new Size(51, 15);
            autoLabel3.TabIndex = 21;
            autoLabel3.Text = "Phone #";
            // 
            // txtName
            // 
            txtName.BeforeTouchSize = new Size(289, 23);
            txtName.Dock = DockStyle.Top;
            txtName.Location = new Point(14, 70);
            txtName.Name = "txtName";
            txtName.Size = new Size(343, 23);
            txtName.TabIndex = 18;
            // 
            // autoLabel1
            // 
            autoLabel1.Dock = DockStyle.Top;
            autoLabel1.Location = new Point(14, 55);
            autoLabel1.Name = "autoLabel1";
            autoLabel1.Size = new Size(39, 15);
            autoLabel1.TabIndex = 17;
            autoLabel1.Text = "Name";
            // 
            // txtVendorType
            // 
            txtVendorType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtVendorType.AutoCompleteSuggestMode = Syncfusion.WinForms.ListView.Enums.AutoCompleteSuggestMode.Contains;
            txtVendorType.Dock = DockStyle.Top;
            txtVendorType.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            txtVendorType.Location = new Point(14, 29);
            txtVendorType.Name = "txtVendorType";
            txtVendorType.Size = new Size(343, 26);
            txtVendorType.Style.TokenStyle.CloseButtonBackColor = Color.FromArgb(255, 255, 255);
            txtVendorType.TabIndex = 29;
            txtVendorType.TabStop = false;
            // 
            // autoLabel2
            // 
            autoLabel2.Dock = DockStyle.Top;
            autoLabel2.Location = new Point(14, 14);
            autoLabel2.Name = "autoLabel2";
            autoLabel2.Size = new Size(31, 15);
            autoLabel2.TabIndex = 19;
            autoLabel2.Text = "Type";
            // 
            // UpsertVendorView
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(375, 394);
            Controls.Add(materialCard1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "UpsertVendorView";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Style.MdiChild.IconHorizontalAlignment = HorizontalAlignment.Center;
            Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            Text = "Add Vendor";
            materialCard1.ResumeLayout(false);
            materialCard1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtAddress).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtContactPerson).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtEmail).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtPhone).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtName).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtVendorType).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialCard materialCard1;
        private Syncfusion.WinForms.Controls.SfButton btnSave;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtAddress;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel6;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtContactPerson;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel5;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtEmail;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel4;
        private Syncfusion.Windows.Forms.Tools.MaskedEditBox txtPhone;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel3;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtName;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.WinForms.ListView.SfComboBox txtVendorType;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
    }
}