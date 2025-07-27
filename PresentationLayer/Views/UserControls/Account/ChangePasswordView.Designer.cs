namespace RavenTech_ERP.Views.UserControls.Account
{
    partial class ChangePasswordView
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePasswordView));
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            btnSave = new Syncfusion.WinForms.Controls.SfButton();
            txtConfirmNewPassword = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            autoLabel3 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtNewPassword = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtOldPassword = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            materialCard1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtConfirmNewPassword).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtNewPassword).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtOldPassword).BeginInit();
            SuspendLayout();
            // 
            // materialCard1
            // 
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(btnSave);
            materialCard1.Controls.Add(txtConfirmNewPassword);
            materialCard1.Controls.Add(autoLabel3);
            materialCard1.Controls.Add(txtNewPassword);
            materialCard1.Controls.Add(autoLabel2);
            materialCard1.Controls.Add(txtOldPassword);
            materialCard1.Controls.Add(autoLabel1);
            materialCard1.Depth = 0;
            materialCard1.Dock = DockStyle.Fill;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(2, 2);
            materialCard1.Margin = new Padding(14);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(14);
            materialCard1.Size = new Size(305, 215);
            materialCard1.TabIndex = 0;
            // 
            // btnSave
            // 
            btnSave.BackColor = SystemColors.HotTrack;
            btnSave.Dock = DockStyle.Bottom;
            btnSave.Font = new Font("Segoe UI Semibold", 9F);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(14, 173);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(277, 28);
            btnSave.Style.BackColor = SystemColors.HotTrack;
            btnSave.Style.ForeColor = Color.White;
            btnSave.TabIndex = 17;
            btnSave.Text = "Save Changes";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // txtConfirmNewPassword
            // 
            txtConfirmNewPassword.BeforeTouchSize = new Size(396, 23);
            txtConfirmNewPassword.Dock = DockStyle.Top;
            txtConfirmNewPassword.Location = new Point(14, 105);
            txtConfirmNewPassword.Name = "txtConfirmNewPassword";
            txtConfirmNewPassword.PasswordChar = '●';
            txtConfirmNewPassword.Size = new Size(277, 23);
            txtConfirmNewPassword.TabIndex = 16;
            txtConfirmNewPassword.Text = "textBoxExt3";
            txtConfirmNewPassword.UseSystemPasswordChar = true;
            // 
            // autoLabel3
            // 
            autoLabel3.Dock = DockStyle.Top;
            autoLabel3.Location = new Point(14, 90);
            autoLabel3.Name = "autoLabel3";
            autoLabel3.Size = new Size(131, 15);
            autoLabel3.TabIndex = 13;
            autoLabel3.Text = "Confirm New Password";
            // 
            // txtNewPassword
            // 
            txtNewPassword.BeforeTouchSize = new Size(396, 23);
            txtNewPassword.Dock = DockStyle.Top;
            txtNewPassword.Location = new Point(14, 67);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.PasswordChar = '●';
            txtNewPassword.Size = new Size(277, 23);
            txtNewPassword.TabIndex = 15;
            txtNewPassword.Text = "textBoxExt2";
            txtNewPassword.UseSystemPasswordChar = true;
            // 
            // autoLabel2
            // 
            autoLabel2.Dock = DockStyle.Top;
            autoLabel2.Location = new Point(14, 52);
            autoLabel2.Name = "autoLabel2";
            autoLabel2.Size = new Size(84, 15);
            autoLabel2.TabIndex = 12;
            autoLabel2.Text = "New Password";
            // 
            // txtOldPassword
            // 
            txtOldPassword.BeforeTouchSize = new Size(396, 23);
            txtOldPassword.Dock = DockStyle.Top;
            txtOldPassword.Location = new Point(14, 29);
            txtOldPassword.Name = "txtOldPassword";
            txtOldPassword.Size = new Size(277, 23);
            txtOldPassword.TabIndex = 14;
            // 
            // autoLabel1
            // 
            autoLabel1.Dock = DockStyle.Top;
            autoLabel1.Location = new Point(14, 14);
            autoLabel1.Name = "autoLabel1";
            autoLabel1.Size = new Size(79, 15);
            autoLabel1.TabIndex = 11;
            autoLabel1.Text = "Old Password";
            // 
            // ChangePasswordView
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(309, 219);
            Controls.Add(materialCard1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ChangePasswordView";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Style.MdiChild.IconHorizontalAlignment = HorizontalAlignment.Center;
            Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            Text = "Change Password";
            materialCard1.ResumeLayout(false);
            materialCard1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtConfirmNewPassword).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtNewPassword).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtOldPassword).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialCard materialCard1;
        private Syncfusion.WinForms.Controls.SfButton btnSave;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtConfirmNewPassword;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel3;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtNewPassword;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtOldPassword;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
    }
}