namespace RavenTech_ERP.Views.UserControls.Account
{
    partial class EditAccountInformationView
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
            txtFirstName = new MaterialSkin.Controls.MaterialTextBox();
            txtLastName = new MaterialSkin.Controls.MaterialTextBox();
            txtEmail = new MaterialSkin.Controls.MaterialTextBox();
            txtPhone = new MaterialSkin.Controls.MaterialTextBox();
            btnSave = new MaterialSkin.Controls.MaterialButton();
            SuspendLayout();
            // 
            // txtFirstName
            // 
            txtFirstName.AnimateReadOnly = false;
            txtFirstName.BorderStyle = BorderStyle.None;
            txtFirstName.Depth = 0;
            txtFirstName.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtFirstName.Hint = "First Name";
            txtFirstName.LeadingIcon = null;
            txtFirstName.Location = new Point(73, 113);
            txtFirstName.MaxLength = 50;
            txtFirstName.MouseState = MaterialSkin.MouseState.OUT;
            txtFirstName.Multiline = false;
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(203, 50);
            txtFirstName.TabIndex = 0;
            txtFirstName.Text = "";
            txtFirstName.TrailingIcon = null;
            // 
            // txtLastName
            // 
            txtLastName.AnimateReadOnly = false;
            txtLastName.BorderStyle = BorderStyle.None;
            txtLastName.Depth = 0;
            txtLastName.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtLastName.Hint = "Last Name";
            txtLastName.LeadingIcon = null;
            txtLastName.Location = new Point(282, 113);
            txtLastName.MaxLength = 50;
            txtLastName.MouseState = MaterialSkin.MouseState.OUT;
            txtLastName.Multiline = false;
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(203, 50);
            txtLastName.TabIndex = 1;
            txtLastName.Text = "";
            txtLastName.TrailingIcon = null;
            // 
            // txtEmail
            // 
            txtEmail.AnimateReadOnly = false;
            txtEmail.BorderStyle = BorderStyle.None;
            txtEmail.Depth = 0;
            txtEmail.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtEmail.Hint = "Email";
            txtEmail.LeadingIcon = null;
            txtEmail.Location = new Point(73, 187);
            txtEmail.MaxLength = 50;
            txtEmail.MouseState = MaterialSkin.MouseState.OUT;
            txtEmail.Multiline = false;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(412, 50);
            txtEmail.TabIndex = 2;
            txtEmail.Text = "";
            txtEmail.TrailingIcon = null;
            // 
            // txtPhone
            // 
            txtPhone.AnimateReadOnly = false;
            txtPhone.BorderStyle = BorderStyle.None;
            txtPhone.Depth = 0;
            txtPhone.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtPhone.Hint = "Phone Number";
            txtPhone.LeadingIcon = null;
            txtPhone.Location = new Point(73, 261);
            txtPhone.MaxLength = 50;
            txtPhone.MouseState = MaterialSkin.MouseState.OUT;
            txtPhone.Multiline = false;
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(412, 50);
            txtPhone.TabIndex = 3;
            txtPhone.Text = "";
            txtPhone.TrailingIcon = null;
            // 
            // btnSave
            // 
            btnSave.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSave.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSave.Depth = 0;
            btnSave.HighEmphasis = true;
            btnSave.Icon = null;
            btnSave.Location = new Point(217, 342);
            btnSave.Margin = new Padding(4, 6, 4, 6);
            btnSave.MouseState = MaterialSkin.MouseState.HOVER;
            btnSave.Name = "btnSave";
            btnSave.NoAccentTextColor = Color.Empty;
            btnSave.Size = new Size(129, 36);
            btnSave.TabIndex = 4;
            btnSave.Text = "save changes";
            btnSave.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnSave.UseAccentColor = false;
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // EditAccountInformationView
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(563, 419);
            Controls.Add(btnSave);
            Controls.Add(txtPhone);
            Controls.Add(txtEmail);
            Controls.Add(txtLastName);
            Controls.Add(txtFirstName);
            Name = "EditAccountInformationView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Edit Account Information";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialTextBox txtFirstName;
        private MaterialSkin.Controls.MaterialTextBox txtLastName;
        private MaterialSkin.Controls.MaterialTextBox txtEmail;
        private MaterialSkin.Controls.MaterialTextBox txtPhone;
        private MaterialSkin.Controls.MaterialButton btnSave;
    }
}