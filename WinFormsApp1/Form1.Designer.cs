namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(components);
            tabControlMenu = new Guna.UI2.WinForms.Guna2TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            btnExit = new Guna.UI2.WinForms.Guna2ImageButton();
            btnMenu = new Guna.UI2.WinForms.Guna2ImageButton();
            guna2ImageButton1 = new Guna.UI2.WinForms.Guna2ImageButton();
            tabControlMenu.SuspendLayout();
            guna2Panel1.SuspendLayout();
            SuspendLayout();
            // 
            // guna2Elipse1
            // 
            guna2Elipse1.TargetControl = this;
            // 
            // tabControlMenu
            // 
            tabControlMenu.Alignment = TabAlignment.Left;
            tabControlMenu.Controls.Add(tabPage1);
            tabControlMenu.Controls.Add(tabPage2);
            tabControlMenu.Dock = DockStyle.Fill;
            tabControlMenu.ItemSize = new Size(180, 40);
            tabControlMenu.Location = new Point(0, 70);
            tabControlMenu.Name = "tabControlMenu";
            tabControlMenu.SelectedIndex = 0;
            tabControlMenu.Size = new Size(1366, 698);
            tabControlMenu.TabButtonHoverState.BorderColor = Color.Empty;
            tabControlMenu.TabButtonHoverState.FillColor = Color.FromArgb(40, 52, 70);
            tabControlMenu.TabButtonHoverState.Font = new Font("Segoe UI Semibold", 10F);
            tabControlMenu.TabButtonHoverState.ForeColor = Color.White;
            tabControlMenu.TabButtonHoverState.InnerColor = Color.FromArgb(40, 52, 70);
            tabControlMenu.TabButtonIdleState.BorderColor = Color.Empty;
            tabControlMenu.TabButtonIdleState.FillColor = Color.FromArgb(33, 42, 57);
            tabControlMenu.TabButtonIdleState.Font = new Font("Segoe UI Semibold", 10F);
            tabControlMenu.TabButtonIdleState.ForeColor = Color.FromArgb(156, 160, 167);
            tabControlMenu.TabButtonIdleState.InnerColor = Color.FromArgb(33, 42, 57);
            tabControlMenu.TabButtonSelectedState.BorderColor = Color.Empty;
            tabControlMenu.TabButtonSelectedState.FillColor = Color.FromArgb(29, 37, 49);
            tabControlMenu.TabButtonSelectedState.Font = new Font("Segoe UI Semibold", 10F);
            tabControlMenu.TabButtonSelectedState.ForeColor = Color.White;
            tabControlMenu.TabButtonSelectedState.InnerColor = Color.FromArgb(76, 132, 255);
            tabControlMenu.TabButtonSize = new Size(180, 40);
            tabControlMenu.TabIndex = 0;
            tabControlMenu.TabMenuBackColor = Color.FromArgb(33, 42, 57);
            // 
            // tabPage1
            // 
            tabPage1.Location = new Point(184, 4);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1178, 690);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(184, 4);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1178, 690);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // guna2Panel1
            // 
            guna2Panel1.BackColor = Color.White;
            guna2Panel1.Controls.Add(guna2ImageButton1);
            guna2Panel1.Controls.Add(btnExit);
            guna2Panel1.Controls.Add(btnMenu);
            guna2Panel1.CustomizableEdges = customizableEdges4;
            guna2Panel1.Dock = DockStyle.Top;
            guna2Panel1.Location = new Point(0, 0);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges5;
            guna2Panel1.Size = new Size(1366, 70);
            guna2Panel1.TabIndex = 1;
            // 
            // btnExit
            // 
            btnExit.CheckedState.ImageSize = new Size(64, 64);
            btnExit.Dock = DockStyle.Right;
            btnExit.HoverState.ImageSize = new Size(64, 64);
            btnExit.Image = (Image)resources.GetObject("btnExit.Image");
            btnExit.ImageOffset = new Point(0, 0);
            btnExit.ImageRotate = 0F;
            btnExit.Location = new Point(1294, 0);
            btnExit.Name = "btnExit";
            btnExit.PressedState.ImageSize = new Size(64, 64);
            btnExit.ShadowDecoration.CustomizableEdges = customizableEdges1;
            btnExit.Size = new Size(72, 70);
            btnExit.TabIndex = 1;
            btnExit.Click += btnExit_Click;
            // 
            // btnMenu
            // 
            btnMenu.CheckedState.ImageSize = new Size(64, 64);
            btnMenu.Dock = DockStyle.Left;
            btnMenu.HoverState.ImageSize = new Size(64, 64);
            btnMenu.Image = (Image)resources.GetObject("btnMenu.Image");
            btnMenu.ImageOffset = new Point(0, 0);
            btnMenu.ImageRotate = 0F;
            btnMenu.Location = new Point(0, 0);
            btnMenu.Name = "btnMenu";
            btnMenu.PressedState.ImageSize = new Size(64, 64);
            btnMenu.ShadowDecoration.CustomizableEdges = customizableEdges3;
            btnMenu.Size = new Size(72, 70);
            btnMenu.TabIndex = 0;
            btnMenu.Click += btnMenu_Click;
            // 
            // guna2ImageButton1
            // 
            guna2ImageButton1.CheckedState.ImageSize = new Size(64, 64);
            guna2ImageButton1.Dock = DockStyle.Left;
            guna2ImageButton1.HoverState.ImageSize = new Size(64, 64);
            guna2ImageButton1.Image = (Image)resources.GetObject("guna2ImageButton1.Image");
            guna2ImageButton1.ImageOffset = new Point(0, 0);
            guna2ImageButton1.ImageRotate = 0F;
            guna2ImageButton1.Location = new Point(72, 0);
            guna2ImageButton1.Name = "guna2ImageButton1";
            guna2ImageButton1.PressedState.ImageSize = new Size(64, 64);
            guna2ImageButton1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2ImageButton1.Size = new Size(72, 70);
            guna2ImageButton1.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnExit;
            ClientSize = new Size(1366, 768);
            Controls.Add(tabControlMenu);
            Controls.Add(guna2Panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            Text = "Form1";
            tabControlMenu.ResumeLayout(false);
            guna2Panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2TabControl tabControlMenu;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2ImageButton btnExit;
        private Guna.UI2.WinForms.Guna2ImageButton btnMenu;
        private Guna.UI2.WinForms.Guna2ImageButton guna2ImageButton1;
    }
}
