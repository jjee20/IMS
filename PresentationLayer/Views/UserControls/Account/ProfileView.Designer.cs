﻿namespace PresentationLayer.Views.UserControls
{
    partial class ProfileView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tcMain = new Guna.UI2.WinForms.Guna2TabControl();
            tbEditProfile = new TabPage();
            tbChangePassword = new TabPage();
            tcMain.SuspendLayout();
            SuspendLayout();
            // 
            // tcMain
            // 
            tcMain.Controls.Add(tbEditProfile);
            tcMain.Controls.Add(tbChangePassword);
            tcMain.Dock = DockStyle.Fill;
            tcMain.ItemSize = new Size(180, 40);
            tcMain.Location = new Point(0, 0);
            tcMain.Name = "tcMain";
            tcMain.SelectedIndex = 0;
            tcMain.Size = new Size(1906, 979);
            tcMain.TabButtonHoverState.BorderColor = Color.Empty;
            tcMain.TabButtonHoverState.FillColor = Color.FromArgb(40, 52, 70);
            tcMain.TabButtonHoverState.Font = new Font("Segoe UI Semibold", 10F);
            tcMain.TabButtonHoverState.ForeColor = Color.White;
            tcMain.TabButtonHoverState.InnerColor = Color.FromArgb(40, 52, 70);
            tcMain.TabButtonIdleState.BorderColor = Color.Empty;
            tcMain.TabButtonIdleState.FillColor = Color.FromArgb(33, 42, 57);
            tcMain.TabButtonIdleState.Font = new Font("Segoe UI Semibold", 10F);
            tcMain.TabButtonIdleState.ForeColor = Color.FromArgb(156, 160, 167);
            tcMain.TabButtonIdleState.InnerColor = Color.FromArgb(33, 42, 57);
            tcMain.TabButtonSelectedState.BorderColor = Color.Empty;
            tcMain.TabButtonSelectedState.FillColor = Color.FromArgb(29, 37, 49);
            tcMain.TabButtonSelectedState.Font = new Font("Segoe UI Semibold", 10F);
            tcMain.TabButtonSelectedState.ForeColor = Color.White;
            tcMain.TabButtonSelectedState.InnerColor = Color.FromArgb(76, 132, 255);
            tcMain.TabButtonSize = new Size(180, 40);
            tcMain.TabIndex = 0;
            tcMain.TabMenuBackColor = Color.FromArgb(33, 42, 57);
            tcMain.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalTop;
            // 
            // tbEditProfile
            // 
            tbEditProfile.Location = new Point(4, 44);
            tbEditProfile.Name = "tbEditProfile";
            tbEditProfile.Padding = new Padding(3);
            tbEditProfile.Size = new Size(1898, 931);
            tbEditProfile.TabIndex = 0;
            tbEditProfile.Text = "Edit Profile";
            tbEditProfile.UseVisualStyleBackColor = true;
            // 
            // tbChangePassword
            // 
            tbChangePassword.Location = new Point(4, 44);
            tbChangePassword.Name = "tbChangePassword";
            tbChangePassword.Padding = new Padding(3);
            tbChangePassword.Size = new Size(1898, 931);
            tbChangePassword.TabIndex = 1;
            tbChangePassword.Text = "Change Password";
            tbChangePassword.UseVisualStyleBackColor = true;
            // 
            // ProfileView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tcMain);
            Name = "ProfileView";
            Size = new Size(1906, 979);
            tcMain.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2TabControl tcMain;
        private TabPage tbEditProfile;
        private TabPage tbChangePassword;
    }
}
