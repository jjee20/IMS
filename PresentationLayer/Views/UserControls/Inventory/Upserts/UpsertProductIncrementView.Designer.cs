namespace RavenTech_ERP.Views.UserControls.Inventory
{
    partial class UpsertProductIncrementView
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(UpsertProductIncrementView));
            autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            btnSave = new Syncfusion.WinForms.Controls.SfButton();
            txtDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
            txtIncrement = new Syncfusion.Windows.Forms.Tools.DoubleTextBox();
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            ((System.ComponentModel.ISupportInitialize)txtIncrement).BeginInit();
            materialCard1.SuspendLayout();
            SuspendLayout();
            // 
            // autoLabel1
            // 
            autoLabel1.Dock = DockStyle.Top;
            autoLabel1.Location = new Point(9, 9);
            autoLabel1.Name = "autoLabel1";
            autoLabel1.Size = new Size(31, 15);
            autoLabel1.TabIndex = 0;
            autoLabel1.Text = "Date";
            // 
            // autoLabel2
            // 
            autoLabel2.Dock = DockStyle.Top;
            autoLabel2.Location = new Point(9, 51);
            autoLabel2.Name = "autoLabel2";
            autoLabel2.Size = new Size(61, 15);
            autoLabel2.TabIndex = 2;
            autoLabel2.Text = "Increment";
            // 
            // btnSave
            // 
            btnSave.BackColor = SystemColors.HotTrack;
            btnSave.Dock = DockStyle.Bottom;
            btnSave.Font = new Font("Segoe UI Semibold", 9F);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(9, 147);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(309, 31);
            btnSave.Style.BackColor = SystemColors.HotTrack;
            btnSave.Style.ForeColor = Color.White;
            btnSave.TabIndex = 4;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // txtDate
            // 
            txtDate.DateTimeIcon = null;
            txtDate.Dock = DockStyle.Top;
            txtDate.Location = new Point(9, 24);
            txtDate.Margin = new Padding(2);
            txtDate.Name = "txtDate";
            txtDate.Size = new Size(309, 27);
            txtDate.TabIndex = 5;
            txtDate.ToolTipText = "";
            // 
            // txtIncrement
            // 
            txtIncrement.AccessibilityEnabled = true;
            txtIncrement.BeforeTouchSize = new Size(309, 23);
            txtIncrement.Dock = DockStyle.Top;
            txtIncrement.DoubleValue = 1D;
            txtIncrement.Location = new Point(9, 66);
            txtIncrement.Margin = new Padding(2);
            txtIncrement.Name = "txtIncrement";
            txtIncrement.Size = new Size(309, 23);
            txtIncrement.TabIndex = 6;
            txtIncrement.Text = "1.00";
            // 
            // materialCard1
            // 
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(btnSave);
            materialCard1.Controls.Add(txtIncrement);
            materialCard1.Controls.Add(autoLabel2);
            materialCard1.Controls.Add(txtDate);
            materialCard1.Controls.Add(autoLabel1);
            materialCard1.Depth = 0;
            materialCard1.Dock = DockStyle.Fill;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(2, 2);
            materialCard1.Margin = new Padding(9);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(9);
            materialCard1.Size = new Size(327, 187);
            materialCard1.TabIndex = 7;
            // 
            // UpsertProductIncrementView
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(331, 191);
            Controls.Add(materialCard1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "UpsertProductIncrementView";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Style.MdiChild.IconHorizontalAlignment = HorizontalAlignment.Center;
            Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            Text = "Add Product Increment";
            Load += UpsertProductIncrementView_Load;
            ((System.ComponentModel.ISupportInitialize)txtIncrement).EndInit();
            materialCard1.ResumeLayout(false);
            materialCard1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private Syncfusion.WinForms.Controls.SfButton btnSave;
        private Syncfusion.WinForms.Input.SfDateTimeEdit txtDate;
        private Syncfusion.Windows.Forms.Tools.DoubleTextBox txtIncrement;
        private MaterialSkin.Controls.MaterialCard materialCard1;
    }
}