namespace RavenTech_ERP.Views.UserControls.Inventory
{
    partial class UpsertHolidayView
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(UpsertHolidayView));
            autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtName = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            txtDescription = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            btnSave = new Syncfusion.WinForms.Controls.SfButton();
            autoLabel3 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel4 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtHolidayType = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            txtDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
            ((System.ComponentModel.ISupportInitialize)txtName).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtDescription).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtHolidayType).BeginInit();
            materialCard1.SuspendLayout();
            SuspendLayout();
            // 
            // autoLabel1
            // 
            autoLabel1.Dock = DockStyle.Top;
            autoLabel1.Location = new Point(14, 60);
            autoLabel1.Name = "autoLabel1";
            autoLabel1.Size = new Size(39, 15);
            autoLabel1.TabIndex = 0;
            autoLabel1.Text = "Name";
            // 
            // txtName
            // 
            txtName.BeforeTouchSize = new Size(240, 23);
            txtName.Dock = DockStyle.Top;
            txtName.Location = new Point(14, 75);
            txtName.Name = "txtName";
            txtName.Size = new Size(283, 23);
            txtName.TabIndex = 1;
            // 
            // txtDescription
            // 
            txtDescription.BeforeTouchSize = new Size(240, 23);
            txtDescription.Dock = DockStyle.Top;
            txtDescription.Location = new Point(14, 151);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(283, 23);
            txtDescription.TabIndex = 3;
            // 
            // autoLabel2
            // 
            autoLabel2.Dock = DockStyle.Top;
            autoLabel2.Location = new Point(14, 136);
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
            btnSave.Location = new Point(14, 207);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(283, 28);
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
            autoLabel4.Location = new Point(14, 98);
            autoLabel4.Name = "autoLabel4";
            autoLabel4.Size = new Size(31, 15);
            autoLabel4.TabIndex = 6;
            autoLabel4.Text = "Date";
            // 
            // txtHolidayType
            // 
            txtHolidayType.BackColor = Color.FromArgb(255, 255, 255);
            txtHolidayType.Dock = DockStyle.Top;
            txtHolidayType.ForeColor = Color.FromArgb(68, 68, 68);
            txtHolidayType.Height = 31;
            txtHolidayType.Location = new Point(14, 29);
            txtHolidayType.Name = "txtHolidayType";
            txtHolidayType.Size = new Size(283, 31);
            txtHolidayType.TabIndex = 7;
            txtHolidayType.Text = "~Select~";
            txtHolidayType.TextBoxHeight = 23;
            txtHolidayType.ThemeName = "Office2016Colorful";
            // 
            // materialCard1
            // 
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(txtDescription);
            materialCard1.Controls.Add(autoLabel2);
            materialCard1.Controls.Add(txtDate);
            materialCard1.Controls.Add(autoLabel4);
            materialCard1.Controls.Add(txtName);
            materialCard1.Controls.Add(autoLabel1);
            materialCard1.Controls.Add(txtHolidayType);
            materialCard1.Controls.Add(autoLabel3);
            materialCard1.Controls.Add(btnSave);
            materialCard1.Depth = 0;
            materialCard1.Dock = DockStyle.Fill;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(2, 2);
            materialCard1.Margin = new Padding(14);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(14);
            materialCard1.Size = new Size(311, 249);
            materialCard1.TabIndex = 9;
            // 
            // txtDate
            // 
            txtDate.DateTimeIcon = null;
            txtDate.Dock = DockStyle.Top;
            txtDate.Location = new Point(14, 113);
            txtDate.Name = "txtDate";
            txtDate.Size = new Size(283, 23);
            txtDate.TabIndex = 8;
            txtDate.ToolTipText = "";
            // 
            // UpsertHolidayView
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(315, 253);
            Controls.Add(materialCard1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "UpsertHolidayView";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Style.MdiChild.IconHorizontalAlignment = HorizontalAlignment.Center;
            Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            Text = "Add Holiday";
            ((System.ComponentModel.ISupportInitialize)txtName).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtDescription).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtHolidayType).EndInit();
            materialCard1.ResumeLayout(false);
            materialCard1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtName;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtDescription;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private Syncfusion.WinForms.Controls.SfButton btnSave;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel3;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel4;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv txtHolidayType;
        private MaterialSkin.Controls.MaterialCard materialCard1;
        private Syncfusion.WinForms.Input.SfDateTimeEdit txtDate;
    }
}