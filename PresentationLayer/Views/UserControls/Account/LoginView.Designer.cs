namespace RavenTech_ERP.Views.UserControls.Account
{
    partial class LoginView
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
            var customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            var customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            var customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            var customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            var customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            var customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            var customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            var customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            var customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            var customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginView));
            var customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(components);
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
            guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            btnLogin = new Guna.UI2.WinForms.Guna2Button();
            txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            txtUsername = new Guna.UI2.WinForms.Guna2TextBox();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            btnExit = new Guna.UI2.WinForms.Guna2ImageButton();
            guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            materialCard1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
            SuspendLayout();
            // 
            // guna2Elipse1
            // 
            guna2Elipse1.BorderRadius = 15;
            guna2Elipse1.TargetControl = this;
            // 
            // materialCard1
            // 
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(guna2PictureBox2);
            materialCard1.Controls.Add(guna2HtmlLabel2);
            materialCard1.Controls.Add(guna2HtmlLabel1);
            materialCard1.Controls.Add(btnLogin);
            materialCard1.Controls.Add(txtPassword);
            materialCard1.Controls.Add(txtUsername);
            materialCard1.Depth = 0;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(401, 46);
            materialCard1.Margin = new Padding(14);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(14);
            materialCard1.Size = new Size(376, 381);
            materialCard1.TabIndex = 3;
            // 
            // guna2PictureBox2
            // 
            guna2PictureBox2.BackColor = Color.Transparent;
            guna2PictureBox2.CustomizableEdges = customizableEdges6;
            guna2PictureBox2.FillColor = Color.Transparent;
            guna2PictureBox2.Image = (Image)resources.GetObject("guna2PictureBox2.Image");
            guna2PictureBox2.ImageRotate = 0F;
            guna2PictureBox2.Location = new Point(191, 59);
            guna2PictureBox2.Name = "guna2PictureBox2";
            guna2PictureBox2.ShadowDecoration.CustomizableEdges = customizableEdges7;
            guna2PictureBox2.Size = new Size(30, 30);
            guna2PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            guna2PictureBox2.TabIndex = 5;
            guna2PictureBox2.TabStop = false;
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.Font = new Font("Segoe UI", 16F);
            guna2HtmlLabel2.Location = new Point(37, 95);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(184, 32);
            guna2HtmlLabel2.TabIndex = 86;
            guna2HtmlLabel2.Text = "Login your Account";
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Segoe UI", 24F);
            guna2HtmlLabel1.Location = new Point(37, 42);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(146, 47);
            guna2HtmlLabel1.TabIndex = 85;
            guna2HtmlLabel1.Text = "Welcome!";
            // 
            // btnLogin
            // 
            btnLogin.Anchor = AnchorStyles.None;
            btnLogin.BorderRadius = 5;
            btnLogin.CustomizableEdges = customizableEdges1;
            btnLogin.DisabledState.BorderColor = Color.DarkGray;
            btnLogin.DisabledState.CustomBorderColor = Color.DarkGray;
            btnLogin.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnLogin.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnLogin.Font = new Font("Segoe UI", 9F);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(37, 306);
            btnLogin.Name = "btnLogin";
            btnLogin.PressedColor = Color.White;
            btnLogin.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnLogin.Size = new Size(308, 45);
            btnLogin.TabIndex = 84;
            btnLogin.Text = "Login";
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.None;
            txtPassword.BorderRadius = 5;
            txtPassword.CustomizableEdges = customizableEdges8;
            txtPassword.DefaultText = "pass@123";
            txtPassword.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtPassword.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtPassword.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtPassword.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtPassword.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPassword.Font = new Font("Segoe UI", 9F);
            txtPassword.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPassword.IconLeft = (Image)resources.GetObject("txtPassword.IconLeft");
            txtPassword.IconRight = (Image)resources.GetObject("txtPassword.IconRight");
            txtPassword.Location = new Point(37, 238);
            txtPassword.Margin = new Padding(4, 5, 4, 5);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.PlaceholderText = "Password";
            txtPassword.SelectedText = "";
            txtPassword.ShadowDecoration.CustomizableEdges = customizableEdges9;
            txtPassword.Size = new Size(308, 50);
            txtPassword.TabIndex = 83;
            txtPassword.IconRightClick += txtPassword_IconRightClick;
            // 
            // txtUsername
            // 
            txtUsername.Anchor = AnchorStyles.None;
            txtUsername.BorderRadius = 5;
            txtUsername.CustomizableEdges = customizableEdges10;
            txtUsername.DefaultText = "superadmin";
            txtUsername.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtUsername.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtUsername.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtUsername.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtUsername.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtUsername.Font = new Font("Segoe UI", 9F);
            txtUsername.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtUsername.IconLeft = (Image)resources.GetObject("txtUsername.IconLeft");
            txtUsername.Location = new Point(37, 168);
            txtUsername.Margin = new Padding(4, 5, 4, 5);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "Username";
            txtUsername.SelectedText = "";
            txtUsername.ShadowDecoration.CustomizableEdges = customizableEdges11;
            txtUsername.Size = new Size(308, 50);
            txtUsername.TabIndex = 82;
            // 
            // btnExit
            // 
            btnExit.CheckedState.ImageSize = new Size(64, 64);
            btnExit.HoverState.ImageSize = new Size(64, 64);
            btnExit.Image = (Image)resources.GetObject("btnExit.Image");
            btnExit.ImageOffset = new Point(0, 0);
            btnExit.ImageRotate = 0F;
            btnExit.ImageSize = new Size(20, 20);
            btnExit.Location = new Point(761, 12);
            btnExit.Name = "btnExit";
            btnExit.PressedState.ImageSize = new Size(64, 64);
            btnExit.ShadowDecoration.CustomizableEdges = customizableEdges5;
            btnExit.Size = new Size(22, 17);
            btnExit.TabIndex = 4;
            btnExit.Click += btnExit_Click;
            // 
            // guna2PictureBox1
            // 
            guna2PictureBox1.BackColor = Color.Transparent;
            guna2PictureBox1.CustomizableEdges = customizableEdges3;
            guna2PictureBox1.FillColor = Color.Transparent;
            guna2PictureBox1.Image = (Image)resources.GetObject("guna2PictureBox1.Image");
            guna2PictureBox1.ImageRotate = 0F;
            guna2PictureBox1.Location = new Point(28, 46);
            guna2PictureBox1.Name = "guna2PictureBox1";
            guna2PictureBox1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2PictureBox1.Size = new Size(356, 381);
            guna2PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            guna2PictureBox1.TabIndex = 6;
            guna2PictureBox1.TabStop = false;
            // 
            // LoginView
            // 
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.GhostWhite;
            ClientSize = new Size(800, 450);
            Controls.Add(guna2PictureBox1);
            Controls.Add(btnExit);
            Controls.Add(materialCard1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "LoginView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginView";
            materialCard1.ResumeLayout(false);
            materialCard1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private MaterialSkin.Controls.MaterialCard materialCard1;
        private Guna.UI2.WinForms.Guna2Button btnLogin;
        private Guna.UI2.WinForms.Guna2TextBox txtPassword;
        private Guna.UI2.WinForms.Guna2TextBox txtUsername;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Guna.UI2.WinForms.Guna2ImageButton btnExit;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox2;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
    }
}