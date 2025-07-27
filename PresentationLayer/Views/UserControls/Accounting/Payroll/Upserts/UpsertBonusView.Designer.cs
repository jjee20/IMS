namespace RavenTech_ERP.Views.UserControls.Inventory
{
    partial class UpsertBonusView
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(UpsertBonusView));
            autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtDescription = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            btnSave = new Syncfusion.WinForms.Controls.SfButton();
            autoLabel3 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel4 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtBonusType = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            txtEmployee = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            autoLabel5 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtAmount = new Syncfusion.Windows.Forms.Tools.DoubleTextBox();
            txtIsOneTime = new Syncfusion.Windows.Forms.Tools.CheckBoxAdv();
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            txtDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
            ((System.ComponentModel.ISupportInitialize)txtDescription).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtBonusType).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtEmployee).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtAmount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtIsOneTime).BeginInit();
            materialCard1.SuspendLayout();
            SuspendLayout();
            // 
            // autoLabel1
            // 
            autoLabel1.Dock = DockStyle.Top;
            autoLabel1.Location = new Point(14, 50);
            autoLabel1.Name = "autoLabel1";
            autoLabel1.Size = new Size(59, 15);
            autoLabel1.TabIndex = 0;
            autoLabel1.Text = "Employee";
            // 
            // txtDescription
            // 
            txtDescription.BeforeTouchSize = new Size(206, 23);
            txtDescription.Dock = DockStyle.Top;
            txtDescription.Location = new Point(14, 177);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(305, 23);
            txtDescription.TabIndex = 1;
            // 
            // autoLabel2
            // 
            autoLabel2.Dock = DockStyle.Top;
            autoLabel2.Location = new Point(14, 162);
            autoLabel2.Name = "autoLabel2";
            autoLabel2.Size = new Size(67, 15);
            autoLabel2.TabIndex = 2;
            autoLabel2.Text = "Description";
            // 
            // btnSave
            // 
            btnSave.BackColor = SystemColors.HotTrack;
            btnSave.Dock = DockStyle.Bottom;
            btnSave.Font = new Font("Segoe UI Semibold", 9F);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(14, 286);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(305, 28);
            btnSave.Style.BackColor = SystemColors.HotTrack;
            btnSave.Style.ForeColor = Color.White;
            btnSave.TabIndex = 4;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // autoLabel3
            // 
            autoLabel3.Dock = DockStyle.Top;
            autoLabel3.Location = new Point(14, 14);
            autoLabel3.Name = "autoLabel3";
            autoLabel3.Size = new Size(31, 15);
            autoLabel3.TabIndex = 5;
            autoLabel3.Text = "Type";
            // 
            // autoLabel4
            // 
            autoLabel4.Dock = DockStyle.Top;
            autoLabel4.Location = new Point(14, 86);
            autoLabel4.Name = "autoLabel4";
            autoLabel4.Size = new Size(31, 15);
            autoLabel4.TabIndex = 6;
            autoLabel4.Text = "Date";
            // 
            // txtBonusType
            // 
            txtBonusType.BackColor = Color.FromArgb(255, 255, 255);
            txtBonusType.Dock = DockStyle.Top;
            txtBonusType.ForeColor = Color.FromArgb(68, 68, 68);
            txtBonusType.Height = 21;
            txtBonusType.Location = new Point(14, 29);
            txtBonusType.Name = "txtBonusType";
            txtBonusType.Size = new Size(305, 21);
            txtBonusType.TabIndex = 7;
            txtBonusType.Text = "~Select~";
            txtBonusType.TextBoxHeight = 28;
            txtBonusType.ThemeName = "Office2016Colorful";
            // 
            // txtEmployee
            // 
            txtEmployee.BackColor = Color.FromArgb(255, 255, 255);
            txtEmployee.Dock = DockStyle.Top;
            txtEmployee.ForeColor = Color.FromArgb(68, 68, 68);
            txtEmployee.Height = 21;
            txtEmployee.Location = new Point(14, 65);
            txtEmployee.Name = "txtEmployee";
            txtEmployee.Size = new Size(305, 21);
            txtEmployee.TabIndex = 9;
            txtEmployee.Text = "~Select~";
            txtEmployee.TextBoxHeight = 27;
            txtEmployee.ThemeName = "Office2016Colorful";
            // 
            // autoLabel5
            // 
            autoLabel5.Dock = DockStyle.Top;
            autoLabel5.Location = new Point(14, 124);
            autoLabel5.Name = "autoLabel5";
            autoLabel5.Size = new Size(51, 15);
            autoLabel5.TabIndex = 10;
            autoLabel5.Text = "Amount";
            // 
            // txtAmount
            // 
            txtAmount.AccessibilityEnabled = true;
            txtAmount.BeforeTouchSize = new Size(206, 23);
            txtAmount.Dock = DockStyle.Top;
            txtAmount.DoubleValue = 0D;
            txtAmount.Location = new Point(14, 139);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(305, 23);
            txtAmount.TabIndex = 0;
            txtAmount.Text = "0.00";
            // 
            // txtIsOneTime
            // 
            txtIsOneTime.AccessibilityEnabled = true;
            txtIsOneTime.BeforeTouchSize = new Size(305, 21);
            txtIsOneTime.Border3DStyle = Border3DStyle.RaisedOuter;
            txtIsOneTime.Checked = true;
            txtIsOneTime.CheckState = CheckState.Checked;
            txtIsOneTime.Dock = DockStyle.Top;
            txtIsOneTime.Location = new Point(14, 200);
            txtIsOneTime.Name = "txtIsOneTime";
            txtIsOneTime.Size = new Size(305, 21);
            txtIsOneTime.TabIndex = 12;
            txtIsOneTime.Text = "Is One-Time?";
            // 
            // materialCard1
            // 
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(txtIsOneTime);
            materialCard1.Controls.Add(txtDescription);
            materialCard1.Controls.Add(autoLabel2);
            materialCard1.Controls.Add(txtAmount);
            materialCard1.Controls.Add(autoLabel5);
            materialCard1.Controls.Add(txtDate);
            materialCard1.Controls.Add(btnSave);
            materialCard1.Controls.Add(autoLabel4);
            materialCard1.Controls.Add(txtEmployee);
            materialCard1.Controls.Add(autoLabel1);
            materialCard1.Controls.Add(txtBonusType);
            materialCard1.Controls.Add(autoLabel3);
            materialCard1.Depth = 0;
            materialCard1.Dock = DockStyle.Fill;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(2, 2);
            materialCard1.Margin = new Padding(14);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(14);
            materialCard1.Size = new Size(333, 328);
            materialCard1.TabIndex = 13;
            // 
            // txtDate
            // 
            txtDate.DateTimeIcon = null;
            txtDate.Dock = DockStyle.Top;
            txtDate.Location = new Point(14, 101);
            txtDate.Name = "txtDate";
            txtDate.Size = new Size(305, 23);
            txtDate.TabIndex = 13;
            txtDate.ToolTipText = "";
            // 
            // UpsertBonusView
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(337, 332);
            Controls.Add(materialCard1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "UpsertBonusView";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Style.MdiChild.IconHorizontalAlignment = HorizontalAlignment.Center;
            Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            Text = "Add Bonus";
            ((System.ComponentModel.ISupportInitialize)txtDescription).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtBonusType).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtEmployee).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtAmount).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtIsOneTime).EndInit();
            materialCard1.ResumeLayout(false);
            materialCard1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtDescription;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private Syncfusion.WinForms.Controls.SfButton btnSave;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel3;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel4;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv txtBonusType;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv txtEmployee;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel5;
        private Syncfusion.Windows.Forms.Tools.DoubleTextBox txtAmount;
        private Syncfusion.Windows.Forms.Tools.CheckBoxAdv txtIsOneTime;
        private MaterialSkin.Controls.MaterialCard materialCard1;
        private Syncfusion.WinForms.Input.SfDateTimeEdit txtDate;
    }
}