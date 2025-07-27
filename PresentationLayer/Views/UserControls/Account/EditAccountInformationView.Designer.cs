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
            components = new System.ComponentModel.Container();
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            btnSave = new Syncfusion.WinForms.Controls.SfButton();
            txtPhone = new Syncfusion.Windows.Forms.Tools.MaskedEditBox();
            autoLabel4 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtEmail = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            autoLabel3 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtLastName = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtFirstName = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            materialCard1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtPhone).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtEmail).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtLastName).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtFirstName).BeginInit();
            SuspendLayout();
            // 
            // materialCard1
            // 
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(btnSave);
            materialCard1.Controls.Add(txtPhone);
            materialCard1.Controls.Add(autoLabel4);
            materialCard1.Controls.Add(txtEmail);
            materialCard1.Controls.Add(autoLabel3);
            materialCard1.Controls.Add(txtLastName);
            materialCard1.Controls.Add(autoLabel2);
            materialCard1.Controls.Add(txtFirstName);
            materialCard1.Controls.Add(autoLabel1);
            materialCard1.Depth = 0;
            materialCard1.Dock = DockStyle.Fill;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(2, 2);
            materialCard1.Margin = new Padding(14);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(14);
            materialCard1.Size = new Size(424, 246);
            materialCard1.TabIndex = 14;
            // 
            // btnSave
            // 
            btnSave.BackColor = SystemColors.HotTrack;
            btnSave.Dock = DockStyle.Bottom;
            btnSave.Font = new Font("Segoe UI Semibold", 9F);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(14, 204);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(396, 28);
            btnSave.Style.BackColor = SystemColors.HotTrack;
            btnSave.Style.ForeColor = Color.White;
            btnSave.TabIndex = 22;
            btnSave.Text = "Save Changes";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // txtPhone
            // 
            txtPhone.AccessibilityEnabled = true;
            txtPhone.BeforeTouchSize = new Size(396, 23);
            txtPhone.Dock = DockStyle.Top;
            txtPhone.Lines = new string[]
    {
    "(    )-(   )-(    )"
    };
            txtPhone.Location = new Point(14, 143);
            txtPhone.Mask = "(####)-(###)-(####)";
            txtPhone.MaxLength = 19;
            txtPhone.Modified = false;
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(396, 23);
            txtPhone.TabIndex = 21;
            // 
            // autoLabel4
            // 
            autoLabel4.Dock = DockStyle.Top;
            autoLabel4.Location = new Point(14, 128);
            autoLabel4.Name = "autoLabel4";
            autoLabel4.Size = new Size(63, 15);
            autoLabel4.TabIndex = 20;
            autoLabel4.Text = "Phone No.";
            // 
            // txtEmail
            // 
            txtEmail.BeforeTouchSize = new Size(396, 23);
            txtEmail.Dock = DockStyle.Top;
            txtEmail.Location = new Point(14, 105);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(396, 23);
            txtEmail.TabIndex = 19;
            // 
            // autoLabel3
            // 
            autoLabel3.Dock = DockStyle.Top;
            autoLabel3.Location = new Point(14, 90);
            autoLabel3.Name = "autoLabel3";
            autoLabel3.Size = new Size(36, 15);
            autoLabel3.TabIndex = 18;
            autoLabel3.Text = "Email";
            // 
            // txtLastName
            // 
            txtLastName.BeforeTouchSize = new Size(396, 23);
            txtLastName.Dock = DockStyle.Top;
            txtLastName.Location = new Point(14, 67);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(396, 23);
            txtLastName.TabIndex = 17;
            // 
            // autoLabel2
            // 
            autoLabel2.Dock = DockStyle.Top;
            autoLabel2.Location = new Point(14, 52);
            autoLabel2.Name = "autoLabel2";
            autoLabel2.Size = new Size(63, 15);
            autoLabel2.TabIndex = 16;
            autoLabel2.Text = "Last Name";
            // 
            // txtFirstName
            // 
            txtFirstName.BeforeTouchSize = new Size(396, 23);
            txtFirstName.Dock = DockStyle.Top;
            txtFirstName.Location = new Point(14, 29);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(396, 23);
            txtFirstName.TabIndex = 15;
            // 
            // autoLabel1
            // 
            autoLabel1.Dock = DockStyle.Top;
            autoLabel1.Location = new Point(14, 14);
            autoLabel1.Name = "autoLabel1";
            autoLabel1.Size = new Size(64, 15);
            autoLabel1.TabIndex = 14;
            autoLabel1.Text = "First Name";
            // 
            // EditAccountInformationView
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(428, 250);
            Controls.Add(materialCard1);
            Name = "EditAccountInformationView";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Style.MdiChild.IconHorizontalAlignment = HorizontalAlignment.Center;
            Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            Text = "Edit Account Information";
            materialCard1.ResumeLayout(false);
            materialCard1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtPhone).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtEmail).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtLastName).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtFirstName).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialCard materialCard1;
        private Syncfusion.WinForms.Controls.SfButton btnSave;
        private Syncfusion.Windows.Forms.Tools.MaskedEditBox txtPhone;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel4;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtEmail;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel3;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtLastName;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtFirstName;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
    }
}