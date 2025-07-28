namespace RavenTech_ERP.Views.UserControls.Inventory
{
    partial class UpsertLeaveView
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(UpsertLeaveView));
            autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtOther = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            btnSave = new Syncfusion.WinForms.Controls.SfButton();
            autoLabel3 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel4 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtLeaveType = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            txtEmployee = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            autoLabel5 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtNotes = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            txtStatus = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            autoLabel6 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel7 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            txtEndDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
            txtStartDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
            ((System.ComponentModel.ISupportInitialize)txtOther).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtLeaveType).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtEmployee).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtNotes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtStatus).BeginInit();
            materialCard1.SuspendLayout();
            SuspendLayout();
            // 
            // autoLabel1
            // 
            autoLabel1.Dock = DockStyle.Top;
            autoLabel1.Location = new Point(14, 14);
            autoLabel1.Name = "autoLabel1";
            autoLabel1.Size = new Size(59, 15);
            autoLabel1.TabIndex = 0;
            autoLabel1.Text = "Employee";
            // 
            // txtOther
            // 
            txtOther.BeforeTouchSize = new Size(240, 23);
            txtOther.Dock = DockStyle.Top;
            txtOther.Location = new Point(14, 207);
            txtOther.Name = "txtOther";
            txtOther.Size = new Size(293, 23);
            txtOther.TabIndex = 3;
            // 
            // autoLabel2
            // 
            autoLabel2.Dock = DockStyle.Top;
            autoLabel2.Location = new Point(14, 192);
            autoLabel2.Name = "autoLabel2";
            autoLabel2.Size = new Size(42, 15);
            autoLabel2.TabIndex = 2;
            autoLabel2.Text = "Others";
            // 
            // btnSave
            // 
            btnSave.BackColor = SystemColors.HotTrack;
            btnSave.Dock = DockStyle.Bottom;
            btnSave.Font = new Font("Segoe UI Semibold", 9F);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(14, 395);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(293, 28);
            btnSave.Style.BackColor = SystemColors.HotTrack;
            btnSave.Style.ForeColor = Color.White;
            btnSave.TabIndex = 1;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // autoLabel3
            // 
            autoLabel3.Dock = DockStyle.Top;
            autoLabel3.Location = new Point(14, 141);
            autoLabel3.Name = "autoLabel3";
            autoLabel3.Size = new Size(31, 15);
            autoLabel3.TabIndex = 5;
            autoLabel3.Text = "Type";
            // 
            // autoLabel4
            // 
            autoLabel4.Dock = DockStyle.Top;
            autoLabel4.Location = new Point(14, 65);
            autoLabel4.Name = "autoLabel4";
            autoLabel4.Size = new Size(58, 15);
            autoLabel4.TabIndex = 6;
            autoLabel4.Text = "Start Date";
            // 
            // txtLeaveType
            // 
            txtLeaveType.BackColor = Color.FromArgb(255, 255, 255);
            txtLeaveType.Dock = DockStyle.Top;
            txtLeaveType.ForeColor = Color.FromArgb(68, 68, 68);
            txtLeaveType.Height = 36;
            txtLeaveType.Location = new Point(14, 156);
            txtLeaveType.Name = "txtLeaveType";
            txtLeaveType.Size = new Size(293, 36);
            txtLeaveType.TabIndex = 7;
            txtLeaveType.Text = "~Select~";
            txtLeaveType.TextBoxHeight = 28;
            txtLeaveType.ThemeName = "Office2016Colorful";
            // 
            // txtEmployee
            // 
            txtEmployee.BackColor = Color.FromArgb(255, 255, 255);
            txtEmployee.Dock = DockStyle.Top;
            txtEmployee.ForeColor = Color.FromArgb(68, 68, 68);
            txtEmployee.Height = 36;
            txtEmployee.Location = new Point(14, 29);
            txtEmployee.Name = "txtEmployee";
            txtEmployee.Size = new Size(293, 36);
            txtEmployee.TabIndex = 9;
            txtEmployee.Text = "~Select~";
            txtEmployee.TextBoxHeight = 28;
            txtEmployee.ThemeName = "Office2016Colorful";
            // 
            // autoLabel5
            // 
            autoLabel5.Dock = DockStyle.Top;
            autoLabel5.Location = new Point(14, 230);
            autoLabel5.Name = "autoLabel5";
            autoLabel5.Size = new Size(38, 15);
            autoLabel5.TabIndex = 10;
            autoLabel5.Text = "Notes";
            // 
            // txtNotes
            // 
            txtNotes.BeforeTouchSize = new Size(240, 23);
            txtNotes.Dock = DockStyle.Top;
            txtNotes.Location = new Point(14, 245);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(293, 78);
            txtNotes.TabIndex = 0;
            // 
            // txtStatus
            // 
            txtStatus.BackColor = Color.FromArgb(255, 255, 255);
            txtStatus.Dock = DockStyle.Top;
            txtStatus.ForeColor = Color.FromArgb(68, 68, 68);
            txtStatus.Height = 36;
            txtStatus.Location = new Point(14, 338);
            txtStatus.Name = "txtStatus";
            txtStatus.Size = new Size(293, 36);
            txtStatus.TabIndex = 13;
            txtStatus.Text = "~Select~";
            txtStatus.TextBoxHeight = 28;
            txtStatus.ThemeName = "Office2016Colorful";
            // 
            // autoLabel6
            // 
            autoLabel6.Dock = DockStyle.Top;
            autoLabel6.Location = new Point(14, 323);
            autoLabel6.Name = "autoLabel6";
            autoLabel6.Size = new Size(39, 15);
            autoLabel6.TabIndex = 12;
            autoLabel6.Text = "Status";
            // 
            // autoLabel7
            // 
            autoLabel7.Dock = DockStyle.Top;
            autoLabel7.Location = new Point(14, 103);
            autoLabel7.Name = "autoLabel7";
            autoLabel7.Size = new Size(54, 15);
            autoLabel7.TabIndex = 14;
            autoLabel7.Text = "End Date";
            // 
            // materialCard1
            // 
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(txtStatus);
            materialCard1.Controls.Add(autoLabel6);
            materialCard1.Controls.Add(btnSave);
            materialCard1.Controls.Add(txtNotes);
            materialCard1.Controls.Add(autoLabel5);
            materialCard1.Controls.Add(txtOther);
            materialCard1.Controls.Add(autoLabel2);
            materialCard1.Controls.Add(txtLeaveType);
            materialCard1.Controls.Add(autoLabel3);
            materialCard1.Controls.Add(txtEndDate);
            materialCard1.Controls.Add(autoLabel7);
            materialCard1.Controls.Add(txtStartDate);
            materialCard1.Controls.Add(autoLabel4);
            materialCard1.Controls.Add(txtEmployee);
            materialCard1.Controls.Add(autoLabel1);
            materialCard1.Depth = 0;
            materialCard1.Dock = DockStyle.Fill;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(2, 2);
            materialCard1.Margin = new Padding(14);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(14);
            materialCard1.Size = new Size(321, 437);
            materialCard1.TabIndex = 16;
            // 
            // txtEndDate
            // 
            txtEndDate.DateTimeIcon = null;
            txtEndDate.Dock = DockStyle.Top;
            txtEndDate.Location = new Point(14, 118);
            txtEndDate.Name = "txtEndDate";
            txtEndDate.Size = new Size(293, 23);
            txtEndDate.TabIndex = 17;
            txtEndDate.ToolTipText = "";
            // 
            // txtStartDate
            // 
            txtStartDate.DateTimeIcon = null;
            txtStartDate.Dock = DockStyle.Top;
            txtStartDate.Location = new Point(14, 80);
            txtStartDate.Name = "txtStartDate";
            txtStartDate.Size = new Size(293, 23);
            txtStartDate.TabIndex = 16;
            txtStartDate.ToolTipText = "";
            // 
            // UpsertLeaveView
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(325, 441);
            Controls.Add(materialCard1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "UpsertLeaveView";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Style.MdiChild.IconHorizontalAlignment = HorizontalAlignment.Center;
            Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            Text = "Add Leave";
            ((System.ComponentModel.ISupportInitialize)txtOther).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtLeaveType).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtEmployee).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtNotes).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtStatus).EndInit();
            materialCard1.ResumeLayout(false);
            materialCard1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtOther;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private Syncfusion.WinForms.Controls.SfButton btnSave;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel3;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel4;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv txtLeaveType;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv txtEmployee;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel5;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtNotes;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv txtStatus;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel6;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel7;
        private MaterialSkin.Controls.MaterialCard materialCard1;
        private Syncfusion.WinForms.Input.SfDateTimeEdit txtEndDate;
        private Syncfusion.WinForms.Input.SfDateTimeEdit txtStartDate;
    }
}