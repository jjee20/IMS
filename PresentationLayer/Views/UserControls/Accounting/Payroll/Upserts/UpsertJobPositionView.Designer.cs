﻿namespace RavenTech_ERP.Views.UserControls.Inventory
{
    partial class UpsertJobPositionView
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(UpsertJobPositionView));
            txtDescription = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            btnSave = new Syncfusion.WinForms.Controls.SfButton();
            txtName = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            ((System.ComponentModel.ISupportInitialize)txtDescription).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtName).BeginInit();
            materialCard1.SuspendLayout();
            SuspendLayout();
            // 
            // txtDescription
            // 
            txtDescription.BeforeTouchSize = new Size(240, 23);
            txtDescription.Dock = DockStyle.Top;
            txtDescription.Location = new Point(14, 67);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(250, 23);
            txtDescription.TabIndex = 1;
            // 
            // autoLabel2
            // 
            autoLabel2.Dock = DockStyle.Top;
            autoLabel2.Location = new Point(14, 52);
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
            btnSave.Location = new Point(14, 141);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(250, 28);
            btnSave.Style.BackColor = SystemColors.HotTrack;
            btnSave.Style.ForeColor = Color.White;
            btnSave.TabIndex = 2;
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
            txtName.Size = new Size(250, 23);
            txtName.TabIndex = 0;
            // 
            // autoLabel1
            // 
            autoLabel1.Dock = DockStyle.Top;
            autoLabel1.Location = new Point(14, 14);
            autoLabel1.Name = "autoLabel1";
            autoLabel1.Size = new Size(29, 15);
            autoLabel1.TabIndex = 5;
            autoLabel1.Text = "Title";
            // 
            // materialCard1
            // 
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(txtDescription);
            materialCard1.Controls.Add(autoLabel2);
            materialCard1.Controls.Add(txtName);
            materialCard1.Controls.Add(autoLabel1);
            materialCard1.Controls.Add(btnSave);
            materialCard1.Depth = 0;
            materialCard1.Dock = DockStyle.Fill;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(2, 2);
            materialCard1.Margin = new Padding(14);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(14);
            materialCard1.Size = new Size(278, 183);
            materialCard1.TabIndex = 7;
            // 
            // UpsertJobPositionView
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(282, 187);
            Controls.Add(materialCard1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "UpsertJobPositionView";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Style.MdiChild.IconHorizontalAlignment = HorizontalAlignment.Center;
            Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            Text = "Add Job Position";
            ((System.ComponentModel.ISupportInitialize)txtDescription).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtName).EndInit();
            materialCard1.ResumeLayout(false);
            materialCard1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtDescription;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private Syncfusion.WinForms.Controls.SfButton btnSave;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtName;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private MaterialSkin.Controls.MaterialCard materialCard1;
    }
}