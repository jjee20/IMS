namespace RavenTech_ERP.Views.UserControls.Inventory
{
    partial class UpsertRegisterAccountView
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(UpsertRegisterAccountView));
            autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtEmail = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            txtPassword = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            lblPassword = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            btnSave = new Syncfusion.WinForms.Controls.SfButton();
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            groupBox1 = new GroupBox();
            btnOverride = new Syncfusion.Windows.Forms.Tools.CheckBoxAdv();
            btnView = new Syncfusion.Windows.Forms.Tools.CheckBoxAdv();
            btnDelete = new Syncfusion.Windows.Forms.Tools.CheckBoxAdv();
            btnEdit = new Syncfusion.Windows.Forms.Tools.CheckBoxAdv();
            btnAdd = new Syncfusion.Windows.Forms.Tools.CheckBoxAdv();
            txtConfirmPassword = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            lblConfirmPassword = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtDepartment = new Syncfusion.WinForms.ListView.SfComboBox();
            autoLabel4 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            ((System.ComponentModel.ISupportInitialize)txtEmail).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtPassword).BeginInit();
            materialCard1.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnOverride).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnDelete).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnEdit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnAdd).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtConfirmPassword).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtDepartment).BeginInit();
            SuspendLayout();
            // 
            // autoLabel1
            // 
            autoLabel1.Dock = DockStyle.Top;
            autoLabel1.Location = new Point(9, 50);
            autoLabel1.Name = "autoLabel1";
            autoLabel1.Size = new Size(36, 15);
            autoLabel1.TabIndex = 0;
            autoLabel1.Text = "Email";
            // 
            // txtEmail
            // 
            txtEmail.BeforeTouchSize = new Size(258, 23);
            txtEmail.Dock = DockStyle.Top;
            txtEmail.Location = new Point(9, 65);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(258, 23);
            txtEmail.TabIndex = 0;
            // 
            // txtPassword
            // 
            txtPassword.BeforeTouchSize = new Size(258, 23);
            txtPassword.Dock = DockStyle.Top;
            txtPassword.Location = new Point(9, 103);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.Size = new Size(258, 23);
            txtPassword.TabIndex = 1;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // lblPassword
            // 
            lblPassword.Dock = DockStyle.Top;
            lblPassword.Location = new Point(9, 88);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(57, 15);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Password";
            // 
            // btnSave
            // 
            btnSave.BackColor = SystemColors.HotTrack;
            btnSave.Dock = DockStyle.Bottom;
            btnSave.Font = new Font("Segoe UI Semibold", 9F);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(9, 308);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(258, 31);
            btnSave.Style.BackColor = SystemColors.HotTrack;
            btnSave.Style.ForeColor = Color.White;
            btnSave.TabIndex = 3;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // materialCard1
            // 
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(groupBox1);
            materialCard1.Controls.Add(txtConfirmPassword);
            materialCard1.Controls.Add(lblConfirmPassword);
            materialCard1.Controls.Add(btnSave);
            materialCard1.Controls.Add(txtPassword);
            materialCard1.Controls.Add(lblPassword);
            materialCard1.Controls.Add(txtEmail);
            materialCard1.Controls.Add(autoLabel1);
            materialCard1.Controls.Add(txtDepartment);
            materialCard1.Controls.Add(autoLabel4);
            materialCard1.Depth = 0;
            materialCard1.Dock = DockStyle.Fill;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(2, 2);
            materialCard1.Margin = new Padding(9);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(9);
            materialCard1.Size = new Size(276, 348);
            materialCard1.TabIndex = 5;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnOverride);
            groupBox1.Controls.Add(btnView);
            groupBox1.Controls.Add(btnDelete);
            groupBox1.Controls.Add(btnEdit);
            groupBox1.Controls.Add(btnAdd);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(9, 164);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(258, 131);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Task/s";
            // 
            // btnOverride
            // 
            btnOverride.AccessibilityEnabled = true;
            btnOverride.BeforeTouchSize = new Size(252, 21);
            btnOverride.Dock = DockStyle.Top;
            btnOverride.Location = new Point(3, 103);
            btnOverride.Name = "btnOverride";
            btnOverride.Size = new Size(252, 21);
            btnOverride.TabIndex = 4;
            btnOverride.Text = "Override";
            // 
            // btnView
            // 
            btnView.AccessibilityEnabled = true;
            btnView.BeforeTouchSize = new Size(252, 21);
            btnView.Dock = DockStyle.Top;
            btnView.Location = new Point(3, 82);
            btnView.Name = "btnView";
            btnView.Size = new Size(252, 21);
            btnView.TabIndex = 3;
            btnView.Text = "View (Product only)";
            // 
            // btnDelete
            // 
            btnDelete.AccessibilityEnabled = true;
            btnDelete.BeforeTouchSize = new Size(252, 21);
            btnDelete.Dock = DockStyle.Top;
            btnDelete.Location = new Point(3, 61);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(252, 21);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Delete";
            // 
            // btnEdit
            // 
            btnEdit.AccessibilityEnabled = true;
            btnEdit.BeforeTouchSize = new Size(252, 21);
            btnEdit.Dock = DockStyle.Top;
            btnEdit.Location = new Point(3, 40);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(252, 21);
            btnEdit.TabIndex = 1;
            btnEdit.Text = "Edit";
            // 
            // btnAdd
            // 
            btnAdd.AccessibilityEnabled = true;
            btnAdd.BeforeTouchSize = new Size(252, 21);
            btnAdd.Checked = true;
            btnAdd.CheckState = CheckState.Checked;
            btnAdd.Dock = DockStyle.Top;
            btnAdd.Location = new Point(3, 19);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(252, 21);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Add";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.BeforeTouchSize = new Size(258, 23);
            txtConfirmPassword.Dock = DockStyle.Top;
            txtConfirmPassword.Location = new Point(9, 141);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PasswordChar = '●';
            txtConfirmPassword.Size = new Size(258, 23);
            txtConfirmPassword.TabIndex = 2;
            txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.Dock = DockStyle.Top;
            lblConfirmPassword.Location = new Point(9, 126);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(104, 15);
            lblConfirmPassword.TabIndex = 6;
            lblConfirmPassword.Text = "Confirm Password";
            // 
            // txtDepartment
            // 
            txtDepartment.Dock = DockStyle.Top;
            txtDepartment.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            txtDepartment.Location = new Point(9, 24);
            txtDepartment.Name = "txtDepartment";
            txtDepartment.Size = new Size(258, 26);
            txtDepartment.Style.TokenStyle.CloseButtonBackColor = Color.FromArgb(255, 255, 255);
            txtDepartment.TabIndex = 9;
            txtDepartment.TabStop = false;
            // 
            // autoLabel4
            // 
            autoLabel4.Dock = DockStyle.Top;
            autoLabel4.Location = new Point(9, 9);
            autoLabel4.Name = "autoLabel4";
            autoLabel4.Size = new Size(70, 15);
            autoLabel4.TabIndex = 8;
            autoLabel4.Text = "Department";
            // 
            // UpsertRegisterAccountView
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(280, 352);
            Controls.Add(materialCard1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "UpsertRegisterAccountView";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Style.MdiChild.IconHorizontalAlignment = HorizontalAlignment.Center;
            Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            Text = "Add Account";
            ((System.ComponentModel.ISupportInitialize)txtEmail).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtPassword).EndInit();
            materialCard1.ResumeLayout(false);
            materialCard1.PerformLayout();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)btnOverride).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnView).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnDelete).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnEdit).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnAdd).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtConfirmPassword).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtDepartment).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtEmail;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtPassword;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lblPassword;
        private Syncfusion.WinForms.Controls.SfButton btnSave;
        private MaterialSkin.Controls.MaterialCard materialCard1;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtConfirmPassword;
        private Syncfusion.Windows.Forms.Tools.AutoLabel lblConfirmPassword;
        private GroupBox groupBox1;
        private Syncfusion.Windows.Forms.Tools.CheckBoxAdv btnOverride;
        private Syncfusion.Windows.Forms.Tools.CheckBoxAdv btnView;
        private Syncfusion.Windows.Forms.Tools.CheckBoxAdv btnDelete;
        private Syncfusion.Windows.Forms.Tools.CheckBoxAdv btnEdit;
        private Syncfusion.Windows.Forms.Tools.CheckBoxAdv btnAdd;
        private Syncfusion.WinForms.ListView.SfComboBox txtDepartment;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel4;
    }
}