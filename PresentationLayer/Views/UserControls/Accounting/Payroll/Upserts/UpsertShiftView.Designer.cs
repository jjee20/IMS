namespace RavenTech_ERP.Views.UserControls.Inventory
{
    partial class UpsertShiftView
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(UpsertShiftView));
            autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            btnSave = new Syncfusion.WinForms.Controls.SfButton();
            txtName = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel3 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel4 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtRegularHours = new Syncfusion.Windows.Forms.Tools.DoubleTextBox();
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            txtEndTime = new Syncfusion.WinForms.Input.SfDateTimeEdit();
            txtStartTime = new Syncfusion.WinForms.Input.SfDateTimeEdit();
            ((System.ComponentModel.ISupportInitialize)txtName).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtRegularHours).BeginInit();
            materialCard1.SuspendLayout();
            SuspendLayout();
            // 
            // autoLabel2
            // 
            autoLabel2.Dock = DockStyle.Top;
            autoLabel2.Location = new Point(14, 128);
            autoLabel2.Name = "autoLabel2";
            autoLabel2.Size = new Size(82, 15);
            autoLabel2.TabIndex = 2;
            autoLabel2.Text = "Regular Hours";
            // 
            // btnSave
            // 
            btnSave.BackColor = SystemColors.HotTrack;
            btnSave.Dock = DockStyle.Bottom;
            btnSave.Font = new Font("Segoe UI Semibold", 9F);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(14, 197);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(279, 28);
            btnSave.Style.BackColor = SystemColors.HotTrack;
            btnSave.Style.ForeColor = Color.White;
            btnSave.TabIndex = 4;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // txtName
            // 
            txtName.BeforeTouchSize = new Size(240, 23);
            txtName.Dock = DockStyle.Top;
            txtName.Location = new Point(14, 29);
            txtName.Name = "txtName";
            txtName.Size = new Size(279, 23);
            txtName.TabIndex = 0;
            // 
            // autoLabel1
            // 
            autoLabel1.Dock = DockStyle.Top;
            autoLabel1.Location = new Point(14, 14);
            autoLabel1.Name = "autoLabel1";
            autoLabel1.Size = new Size(39, 15);
            autoLabel1.TabIndex = 5;
            autoLabel1.Text = "Name";
            // 
            // autoLabel3
            // 
            autoLabel3.Dock = DockStyle.Top;
            autoLabel3.Location = new Point(14, 52);
            autoLabel3.Name = "autoLabel3";
            autoLabel3.Size = new Size(60, 15);
            autoLabel3.TabIndex = 7;
            autoLabel3.Text = "Start Time";
            // 
            // autoLabel4
            // 
            autoLabel4.Dock = DockStyle.Top;
            autoLabel4.Location = new Point(14, 90);
            autoLabel4.Name = "autoLabel4";
            autoLabel4.Size = new Size(56, 15);
            autoLabel4.TabIndex = 9;
            autoLabel4.Text = "End Time";
            // 
            // txtRegularHours
            // 
            txtRegularHours.AccessibilityEnabled = true;
            txtRegularHours.BeforeTouchSize = new Size(240, 23);
            txtRegularHours.Dock = DockStyle.Top;
            txtRegularHours.DoubleValue = 8D;
            txtRegularHours.Location = new Point(14, 143);
            txtRegularHours.Name = "txtRegularHours";
            txtRegularHours.NumberDecimalDigits = 1;
            txtRegularHours.Size = new Size(279, 23);
            txtRegularHours.TabIndex = 3;
            txtRegularHours.Text = "8.0";
            // 
            // materialCard1
            // 
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(txtRegularHours);
            materialCard1.Controls.Add(autoLabel2);
            materialCard1.Controls.Add(txtEndTime);
            materialCard1.Controls.Add(btnSave);
            materialCard1.Controls.Add(autoLabel4);
            materialCard1.Controls.Add(txtStartTime);
            materialCard1.Controls.Add(autoLabel3);
            materialCard1.Controls.Add(txtName);
            materialCard1.Controls.Add(autoLabel1);
            materialCard1.Depth = 0;
            materialCard1.Dock = DockStyle.Fill;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(2, 2);
            materialCard1.Margin = new Padding(14);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(14);
            materialCard1.Size = new Size(307, 239);
            materialCard1.TabIndex = 12;
            // 
            // txtEndTime
            // 
            txtEndTime.DateTimeIcon = null;
            txtEndTime.DateTimePattern = Syncfusion.WinForms.Input.Enums.DateTimePattern.ShortTime;
            txtEndTime.Dock = DockStyle.Top;
            txtEndTime.Location = new Point(14, 105);
            txtEndTime.Name = "txtEndTime";
            txtEndTime.Size = new Size(279, 23);
            txtEndTime.TabIndex = 2;
            txtEndTime.ToolTipText = "";
            txtEndTime.Value = new DateTime(2025, 7, 26, 17, 0, 0, 0);
            // 
            // txtStartTime
            // 
            txtStartTime.DateTimeIcon = null;
            txtStartTime.DateTimePattern = Syncfusion.WinForms.Input.Enums.DateTimePattern.ShortTime;
            txtStartTime.Dock = DockStyle.Top;
            txtStartTime.Location = new Point(14, 67);
            txtStartTime.Name = "txtStartTime";
            txtStartTime.Size = new Size(279, 23);
            txtStartTime.TabIndex = 1;
            txtStartTime.ToolTipText = "";
            txtStartTime.Value = new DateTime(2025, 7, 26, 8, 0, 0, 0);
            // 
            // UpsertShiftView
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(311, 243);
            Controls.Add(materialCard1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "UpsertShiftView";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Style.MdiChild.IconHorizontalAlignment = HorizontalAlignment.Center;
            Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            Text = "Add Shift";
            ((System.ComponentModel.ISupportInitialize)txtName).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtRegularHours).EndInit();
            materialCard1.ResumeLayout(false);
            materialCard1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private Syncfusion.WinForms.Controls.SfButton btnSave;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtName;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel3;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel4;
        private Syncfusion.Windows.Forms.Tools.DoubleTextBox txtRegularHours;
        private MaterialSkin.Controls.MaterialCard materialCard1;
        private Syncfusion.WinForms.Input.SfDateTimeEdit txtEndTime;
        private Syncfusion.WinForms.Input.SfDateTimeEdit txtStartTime;
    }
}