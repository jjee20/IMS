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
            txtOldPassword = new MaterialSkin.Controls.MaterialTextBox();
            txtNewPassword = new MaterialSkin.Controls.MaterialTextBox();
            txtConfirmNewPassword = new MaterialSkin.Controls.MaterialTextBox();
            btnSave = new MaterialSkin.Controls.MaterialButton();
            SuspendLayout();
            // 
            // txtOldPassword
            // 
            txtOldPassword.AnimateReadOnly = false;
            txtOldPassword.BorderStyle = BorderStyle.None;
            txtOldPassword.Depth = 0;
            txtOldPassword.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtOldPassword.Hint = "Old Password";
            txtOldPassword.LeadingIcon = null;
            txtOldPassword.Location = new Point(65, 124);
            txtOldPassword.MaxLength = 50;
            txtOldPassword.MouseState = MaterialSkin.MouseState.OUT;
            txtOldPassword.Multiline = false;
            txtOldPassword.Name = "txtOldPassword";
            txtOldPassword.Size = new Size(338, 50);
            txtOldPassword.TabIndex = 0;
            txtOldPassword.Text = "";
            txtOldPassword.TrailingIcon = null;
            // 
            // txtNewPassword
            // 
            txtNewPassword.AnimateReadOnly = false;
            txtNewPassword.BorderStyle = BorderStyle.None;
            txtNewPassword.Depth = 0;
            txtNewPassword.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtNewPassword.Hint = "New Password";
            txtNewPassword.LeadingIcon = null;
            txtNewPassword.Location = new Point(65, 202);
            txtNewPassword.MaxLength = 50;
            txtNewPassword.MouseState = MaterialSkin.MouseState.OUT;
            txtNewPassword.Multiline = false;
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.Size = new Size(338, 50);
            txtNewPassword.TabIndex = 1;
            txtNewPassword.Text = "";
            txtNewPassword.TrailingIcon = null;
            // 
            // txtConfirmNewPassword
            // 
            txtConfirmNewPassword.AnimateReadOnly = false;
            txtConfirmNewPassword.BorderStyle = BorderStyle.None;
            txtConfirmNewPassword.Depth = 0;
            txtConfirmNewPassword.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtConfirmNewPassword.Hint = "Confirm New Password";
            txtConfirmNewPassword.LeadingIcon = null;
            txtConfirmNewPassword.Location = new Point(65, 280);
            txtConfirmNewPassword.MaxLength = 50;
            txtConfirmNewPassword.MouseState = MaterialSkin.MouseState.OUT;
            txtConfirmNewPassword.Multiline = false;
            txtConfirmNewPassword.Name = "txtConfirmNewPassword";
            txtConfirmNewPassword.Size = new Size(338, 50);
            txtConfirmNewPassword.TabIndex = 2;
            txtConfirmNewPassword.Text = "";
            txtConfirmNewPassword.TrailingIcon = null;
            // 
            // btnSave
            // 
            btnSave.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSave.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSave.Depth = 0;
            btnSave.HighEmphasis = true;
            btnSave.Icon = null;
            btnSave.Location = new Point(170, 362);
            btnSave.Margin = new Padding(4, 6, 4, 6);
            btnSave.MouseState = MaterialSkin.MouseState.HOVER;
            btnSave.Name = "btnSave";
            btnSave.NoAccentTextColor = Color.Empty;
            btnSave.Size = new Size(129, 36);
            btnSave.TabIndex = 3;
            btnSave.Text = "save changes";
            btnSave.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnSave.UseAccentColor = false;
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // ChangePasswordView
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(468, 450);
            Controls.Add(btnSave);
            Controls.Add(txtConfirmNewPassword);
            Controls.Add(txtNewPassword);
            Controls.Add(txtOldPassword);
            Name = "ChangePasswordView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Change Password";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialTextBox txtOldPassword;
        private MaterialSkin.Controls.MaterialTextBox txtNewPassword;
        private MaterialSkin.Controls.MaterialTextBox txtConfirmNewPassword;
        private MaterialSkin.Controls.MaterialButton btnSave;
    }
}