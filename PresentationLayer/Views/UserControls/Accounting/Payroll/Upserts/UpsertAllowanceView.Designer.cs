namespace RavenTech_ERP.Views.UserControls.Inventory
{
    partial class UpsertAllowanceView
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(UpsertAllowanceView));
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            txtDescription = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtAmount = new Syncfusion.Windows.Forms.Tools.DoubleTextBox();
            autoLabel5 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtEndDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
            autoLabel6 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtStartDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
            autoLabel4 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            btnSave = new Syncfusion.WinForms.Controls.SfButton();
            txtEmployee = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtAllowanceType = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            autoLabel3 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            materialCard1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtDescription).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtAmount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtEmployee).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtAllowanceType).BeginInit();
            SuspendLayout();
            // 
            // materialCard1
            // 
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(txtDescription);
            materialCard1.Controls.Add(autoLabel2);
            materialCard1.Controls.Add(txtAmount);
            materialCard1.Controls.Add(autoLabel5);
            materialCard1.Controls.Add(txtEndDate);
            materialCard1.Controls.Add(autoLabel6);
            materialCard1.Controls.Add(txtStartDate);
            materialCard1.Controls.Add(autoLabel4);
            materialCard1.Controls.Add(btnSave);
            materialCard1.Controls.Add(txtEmployee);
            materialCard1.Controls.Add(autoLabel1);
            materialCard1.Controls.Add(txtAllowanceType);
            materialCard1.Controls.Add(autoLabel3);
            materialCard1.Depth = 0;
            materialCard1.Dock = DockStyle.Fill;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(2, 2);
            materialCard1.Margin = new Padding(14);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(14);
            materialCard1.Size = new Size(336, 384);
            materialCard1.TabIndex = 0;
            // 
            // txtDescription
            // 
            txtDescription.BeforeTouchSize = new Size(304, 23);
            txtDescription.Dock = DockStyle.Top;
            txtDescription.Location = new Point(14, 215);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(308, 59);
            txtDescription.TabIndex = 1;
            // 
            // autoLabel2
            // 
            autoLabel2.Dock = DockStyle.Top;
            autoLabel2.Location = new Point(14, 200);
            autoLabel2.Name = "autoLabel2";
            autoLabel2.Size = new Size(52, 15);
            autoLabel2.TabIndex = 18;
            autoLabel2.Text = "Remarks";
            // 
            // txtAmount
            // 
            txtAmount.AccessibilityEnabled = true;
            txtAmount.BeforeTouchSize = new Size(304, 23);
            txtAmount.Dock = DockStyle.Top;
            txtAmount.DoubleValue = 0D;
            txtAmount.Location = new Point(14, 177);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(308, 23);
            txtAmount.TabIndex = 0;
            txtAmount.Text = "0.00";
            // 
            // autoLabel5
            // 
            autoLabel5.Dock = DockStyle.Top;
            autoLabel5.Location = new Point(14, 162);
            autoLabel5.Name = "autoLabel5";
            autoLabel5.Size = new Size(51, 15);
            autoLabel5.TabIndex = 25;
            autoLabel5.Text = "Amount";
            // 
            // txtEndDate
            // 
            txtEndDate.DateTimeIcon = null;
            txtEndDate.Dock = DockStyle.Top;
            txtEndDate.Location = new Point(14, 139);
            txtEndDate.Name = "txtEndDate";
            txtEndDate.Size = new Size(308, 23);
            txtEndDate.TabIndex = 29;
            txtEndDate.ToolTipText = "";
            // 
            // autoLabel6
            // 
            autoLabel6.Dock = DockStyle.Top;
            autoLabel6.Location = new Point(14, 124);
            autoLabel6.Name = "autoLabel6";
            autoLabel6.Size = new Size(54, 15);
            autoLabel6.TabIndex = 27;
            autoLabel6.Text = "End Date";
            // 
            // txtStartDate
            // 
            txtStartDate.DateTimeIcon = null;
            txtStartDate.Dock = DockStyle.Top;
            txtStartDate.Location = new Point(14, 101);
            txtStartDate.Name = "txtStartDate";
            txtStartDate.Size = new Size(308, 23);
            txtStartDate.TabIndex = 28;
            txtStartDate.ToolTipText = "";
            // 
            // autoLabel4
            // 
            autoLabel4.Dock = DockStyle.Top;
            autoLabel4.Location = new Point(14, 86);
            autoLabel4.Name = "autoLabel4";
            autoLabel4.Size = new Size(58, 15);
            autoLabel4.TabIndex = 22;
            autoLabel4.Text = "Start Date";
            // 
            // btnSave
            // 
            btnSave.BackColor = SystemColors.HotTrack;
            btnSave.Dock = DockStyle.Bottom;
            btnSave.Font = new Font("Segoe UI Semibold", 9F);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(14, 342);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(308, 28);
            btnSave.Style.BackColor = SystemColors.HotTrack;
            btnSave.Style.ForeColor = Color.White;
            btnSave.TabIndex = 20;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // txtEmployee
            // 
            txtEmployee.BackColor = Color.FromArgb(255, 255, 255);
            txtEmployee.Dock = DockStyle.Top;
            txtEmployee.ForeColor = Color.FromArgb(68, 68, 68);
            txtEmployee.Height = 21;
            txtEmployee.Location = new Point(14, 65);
            txtEmployee.Name = "txtEmployee";
            txtEmployee.Size = new Size(308, 21);
            txtEmployee.TabIndex = 24;
            txtEmployee.Text = "~Select~";
            txtEmployee.TextBoxHeight = 28;
            txtEmployee.ThemeName = "Office2016Colorful";
            // 
            // autoLabel1
            // 
            autoLabel1.Dock = DockStyle.Top;
            autoLabel1.Location = new Point(14, 50);
            autoLabel1.Name = "autoLabel1";
            autoLabel1.Size = new Size(59, 15);
            autoLabel1.TabIndex = 17;
            autoLabel1.Text = "Employee";
            // 
            // txtAllowanceType
            // 
            txtAllowanceType.BackColor = Color.FromArgb(255, 255, 255);
            txtAllowanceType.Dock = DockStyle.Top;
            txtAllowanceType.ForeColor = Color.FromArgb(68, 68, 68);
            txtAllowanceType.Height = 21;
            txtAllowanceType.Location = new Point(14, 29);
            txtAllowanceType.Name = "txtAllowanceType";
            txtAllowanceType.Size = new Size(308, 21);
            txtAllowanceType.TabIndex = 23;
            txtAllowanceType.Text = "~Select~";
            txtAllowanceType.TextBoxHeight = 26;
            txtAllowanceType.ThemeName = "Office2016Colorful";
            // 
            // autoLabel3
            // 
            autoLabel3.Dock = DockStyle.Top;
            autoLabel3.Location = new Point(14, 14);
            autoLabel3.Name = "autoLabel3";
            autoLabel3.Size = new Size(31, 15);
            autoLabel3.TabIndex = 21;
            autoLabel3.Text = "Type";
            // 
            // UpsertAllowanceView
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(340, 388);
            Controls.Add(materialCard1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "UpsertAllowanceView";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Style.MdiChild.IconHorizontalAlignment = HorizontalAlignment.Center;
            Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            Text = "Add Allowance";
            materialCard1.ResumeLayout(false);
            materialCard1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtDescription).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtAmount).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtEmployee).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtAllowanceType).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialCard materialCard1;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtDescription;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private Syncfusion.Windows.Forms.Tools.DoubleTextBox txtAmount;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel5;
        private Syncfusion.WinForms.Input.SfDateTimeEdit txtEndDate;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel6;
        private Syncfusion.WinForms.Input.SfDateTimeEdit txtStartDate;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel4;
        private Syncfusion.WinForms.Controls.SfButton btnSave;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv txtEmployee;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv txtAllowanceType;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel3;
    }
}