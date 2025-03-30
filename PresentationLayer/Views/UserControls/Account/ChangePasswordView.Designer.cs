using Guna.UI2.WinForms;

namespace PresentationLayer.Views.UserControls
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePasswordView));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            Guna2TabControl1 = new Guna2TabControl();
            tabPage2 = new TabPage();
            materialCard2 = new MaterialSkin.Controls.MaterialCard();
            btnSave = new Guna2Button();
            txtConfirmNewPassword = new Guna2TextBox();
            guna2HtmlLabel5 = new Guna2HtmlLabel();
            txtNewPassword = new Guna2TextBox();
            guna2HtmlLabel3 = new Guna2HtmlLabel();
            guna2HtmlLabel2 = new Guna2HtmlLabel();
            txtPassword = new Guna2TextBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            guna2Separator1 = new Guna2Separator();
            tableLayoutPanel2 = new TableLayoutPanel();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            materialCard1.SuspendLayout();
            Guna2TabControl1.SuspendLayout();
            tabPage2.SuspendLayout();
            materialCard2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // materialCard1
            // 
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(Guna2TabControl1);
            materialCard1.Controls.Add(tableLayoutPanel1);
            materialCard1.Depth = 0;
            materialCard1.Dock = DockStyle.Fill;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(0, 0);
            materialCard1.Margin = new Padding(14);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(14);
            materialCard1.Size = new Size(1668, 734);
            materialCard1.TabIndex = 2;
            // 
            // Guna2TabControl1
            // 
            Guna2TabControl1.Controls.Add(tabPage2);
            Guna2TabControl1.Dock = DockStyle.Fill;
            Guna2TabControl1.ItemSize = new Size(180, 40);
            Guna2TabControl1.Location = new Point(14, 64);
            Guna2TabControl1.Name = "Guna2TabControl1";
            Guna2TabControl1.SelectedIndex = 0;
            Guna2TabControl1.Size = new Size(1640, 656);
            Guna2TabControl1.TabButtonHoverState.BorderColor = Color.Empty;
            Guna2TabControl1.TabButtonHoverState.FillColor = Color.FromArgb(40, 52, 70);
            Guna2TabControl1.TabButtonHoverState.Font = new Font("Segoe UI Semibold", 10F);
            Guna2TabControl1.TabButtonHoverState.ForeColor = Color.White;
            Guna2TabControl1.TabButtonHoverState.InnerColor = Color.FromArgb(40, 52, 70);
            Guna2TabControl1.TabButtonIdleState.BorderColor = Color.Empty;
            Guna2TabControl1.TabButtonIdleState.FillColor = Color.FromArgb(33, 42, 57);
            Guna2TabControl1.TabButtonIdleState.Font = new Font("Segoe UI Semibold", 10F);
            Guna2TabControl1.TabButtonIdleState.ForeColor = Color.FromArgb(156, 160, 167);
            Guna2TabControl1.TabButtonIdleState.InnerColor = Color.FromArgb(33, 42, 57);
            Guna2TabControl1.TabButtonSelectedState.BorderColor = Color.Empty;
            Guna2TabControl1.TabButtonSelectedState.FillColor = Color.FromArgb(29, 37, 49);
            Guna2TabControl1.TabButtonSelectedState.Font = new Font("Segoe UI Semibold", 10F);
            Guna2TabControl1.TabButtonSelectedState.ForeColor = Color.White;
            Guna2TabControl1.TabButtonSelectedState.InnerColor = Color.FromArgb(76, 132, 255);
            Guna2TabControl1.TabButtonSize = new Size(180, 40);
            Guna2TabControl1.TabIndex = 4;
            Guna2TabControl1.TabMenuBackColor = Color.White;
            Guna2TabControl1.TabMenuOrientation = TabMenuOrientation.HorizontalTop;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(materialCard2);
            tabPage2.Location = new Point(4, 44);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1632, 608);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Edit";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // materialCard2
            // 
            materialCard2.BackColor = Color.FromArgb(255, 255, 255);
            materialCard2.Controls.Add(btnSave);
            materialCard2.Controls.Add(txtConfirmNewPassword);
            materialCard2.Controls.Add(guna2HtmlLabel5);
            materialCard2.Controls.Add(txtNewPassword);
            materialCard2.Controls.Add(guna2HtmlLabel3);
            materialCard2.Controls.Add(guna2HtmlLabel2);
            materialCard2.Controls.Add(txtPassword);
            materialCard2.Depth = 0;
            materialCard2.Dock = DockStyle.Fill;
            materialCard2.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard2.Location = new Point(3, 3);
            materialCard2.Margin = new Padding(14);
            materialCard2.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard2.Name = "materialCard2";
            materialCard2.Padding = new Padding(14);
            materialCard2.Size = new Size(1626, 602);
            materialCard2.TabIndex = 5;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.None;
            btnSave.CustomizableEdges = customizableEdges1;
            btnSave.DisabledState.BorderColor = Color.DarkGray;
            btnSave.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSave.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSave.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSave.Font = new Font("Segoe UI", 9F);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(588, 439);
            btnSave.Name = "btnSave";
            btnSave.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnSave.Size = new Size(450, 45);
            btnSave.TabIndex = 62;
            btnSave.Text = "Save";
            // 
            // txtConfirmNewPassword
            // 
            txtConfirmNewPassword.Anchor = AnchorStyles.None;
            txtConfirmNewPassword.CustomizableEdges = customizableEdges3;
            txtConfirmNewPassword.DefaultText = "";
            txtConfirmNewPassword.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtConfirmNewPassword.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtConfirmNewPassword.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtConfirmNewPassword.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtConfirmNewPassword.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtConfirmNewPassword.Font = new Font("Segoe UI", 10.2F);
            txtConfirmNewPassword.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtConfirmNewPassword.IconRight = (Image)resources.GetObject("txtConfirmNewPassword.IconRight");
            txtConfirmNewPassword.Location = new Point(588, 365);
            txtConfirmNewPassword.Margin = new Padding(3, 4, 3, 4);
            txtConfirmNewPassword.Name = "txtConfirmNewPassword";
            txtConfirmNewPassword.PasswordChar = '*';
            txtConfirmNewPassword.PlaceholderText = "Confirm New Password";
            txtConfirmNewPassword.SelectedText = "";
            txtConfirmNewPassword.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtConfirmNewPassword.Size = new Size(450, 42);
            txtConfirmNewPassword.TabIndex = 60;
            txtConfirmNewPassword.TextChanged += txtConfirmNewPassword_TextChanged;
            // 
            // guna2HtmlLabel5
            // 
            guna2HtmlLabel5.Anchor = AnchorStyles.None;
            guna2HtmlLabel5.BackColor = Color.Transparent;
            guna2HtmlLabel5.Font = new Font("Segoe UI", 10F);
            guna2HtmlLabel5.Location = new Point(588, 324);
            guna2HtmlLabel5.Margin = new Padding(3, 2, 3, 2);
            guna2HtmlLabel5.Name = "guna2HtmlLabel5";
            guna2HtmlLabel5.Size = new Size(139, 19);
            guna2HtmlLabel5.TabIndex = 59;
            guna2HtmlLabel5.Text = "Confirm New Password";
            // 
            // txtNewPassword
            // 
            txtNewPassword.Anchor = AnchorStyles.None;
            txtNewPassword.CustomizableEdges = customizableEdges5;
            txtNewPassword.DefaultText = "";
            txtNewPassword.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtNewPassword.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtNewPassword.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtNewPassword.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtNewPassword.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtNewPassword.Font = new Font("Segoe UI", 10.2F);
            txtNewPassword.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtNewPassword.IconRight = (Image)resources.GetObject("txtNewPassword.IconRight");
            txtNewPassword.Location = new Point(588, 262);
            txtNewPassword.Margin = new Padding(3, 4, 3, 4);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.PasswordChar = '*';
            txtNewPassword.PlaceholderText = "Enter New Password";
            txtNewPassword.SelectedText = "";
            txtNewPassword.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtNewPassword.Size = new Size(450, 42);
            txtNewPassword.TabIndex = 56;
            txtNewPassword.TextChanged += txtNewPassword_TextChanged;
            // 
            // guna2HtmlLabel3
            // 
            guna2HtmlLabel3.Anchor = AnchorStyles.None;
            guna2HtmlLabel3.BackColor = Color.Transparent;
            guna2HtmlLabel3.Font = new Font("Segoe UI", 10F);
            guna2HtmlLabel3.Location = new Point(588, 221);
            guna2HtmlLabel3.Margin = new Padding(3, 2, 3, 2);
            guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            guna2HtmlLabel3.Size = new Size(89, 19);
            guna2HtmlLabel3.TabIndex = 48;
            guna2HtmlLabel3.Text = "New Password";
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.Anchor = AnchorStyles.None;
            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.Font = new Font("Segoe UI", 10F);
            guna2HtmlLabel2.Location = new Point(588, 118);
            guna2HtmlLabel2.Margin = new Padding(3, 2, 3, 2);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(84, 19);
            guna2HtmlLabel2.TabIndex = 47;
            guna2HtmlLabel2.Text = "Old Password";
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.None;
            txtPassword.CustomizableEdges = customizableEdges7;
            txtPassword.DefaultText = "";
            txtPassword.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtPassword.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtPassword.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtPassword.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtPassword.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPassword.Font = new Font("Segoe UI", 10.2F);
            txtPassword.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPassword.IconRight = (Image)resources.GetObject("txtPassword.IconRight");
            txtPassword.Location = new Point(588, 159);
            txtPassword.Margin = new Padding(3, 4, 3, 4);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.PlaceholderText = "Enter Old Password";
            txtPassword.SelectedText = "";
            txtPassword.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtPassword.Size = new Size(450, 42);
            txtPassword.TabIndex = 44;
            txtPassword.TextChanged += txtPassword_TextChanged;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(guna2Separator1, 0, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(14, 14);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 76F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 24F));
            tableLayoutPanel1.Size = new Size(1640, 50);
            tableLayoutPanel1.TabIndex = 5;
            // 
            // guna2Separator1
            // 
            guna2Separator1.Dock = DockStyle.Fill;
            guna2Separator1.Location = new Point(3, 40);
            guna2Separator1.Margin = new Padding(3, 2, 3, 2);
            guna2Separator1.Name = "guna2Separator1";
            guna2Separator1.Size = new Size(1634, 8);
            guna2Separator1.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.BackColor = Color.White;
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(materialLabel1, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Margin = new Padding(0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(1640, 38);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Dock = DockStyle.Left;
            materialLabel1.Font = new Font("Roboto", 34F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialLabel1.FontType = MaterialSkin.MaterialSkinManager.fontType.H4;
            materialLabel1.ForeColor = Color.FromArgb(255, 246, 233);
            materialLabel1.ImageAlign = ContentAlignment.MiddleLeft;
            materialLabel1.Location = new Point(3, 0);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(277, 38);
            materialLabel1.TabIndex = 3;
            materialLabel1.Text = "Change Password";
            materialLabel1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ChangePasswordView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(materialCard1);
            Name = "ChangePasswordView";
            Size = new Size(1668, 734);
            materialCard1.ResumeLayout(false);
            Guna2TabControl1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            materialCard2.ResumeLayout(false);
            materialCard2.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialCard materialCard1;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private Guna2Separator guna2Separator1;
        private Guna2TabControl Guna2TabControl1;
        private TabPage tabPage2;
        private MaterialSkin.Controls.MaterialCard materialCard2;
        private Guna2TextBox txtNewPassword;
        private Guna2HtmlLabel guna2HtmlLabel3;
        private Guna2HtmlLabel guna2HtmlLabel2;
        private Guna2TextBox txtPassword;
        private Guna2TextBox txtConfirmNewPassword;
        private Guna2HtmlLabel guna2HtmlLabel5;
        private Guna2Button btnSave;
    }
}
