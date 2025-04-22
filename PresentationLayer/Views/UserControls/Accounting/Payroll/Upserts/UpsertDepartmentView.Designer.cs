namespace RavenTech_ERP.Views.UserControls.Inventory
{
    partial class UpsertDepartmentView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpsertDepartmentView));
            txtDescription = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            btnSave = new Syncfusion.WinForms.Controls.SfButton();
            txtName = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            ((System.ComponentModel.ISupportInitialize)txtDescription).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtName).BeginInit();
            SuspendLayout();
            // 
            // txtDescription
            // 
            txtDescription.BeforeTouchSize = new Size(206, 23);
            txtDescription.Location = new Point(180, 137);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(206, 23);
            txtDescription.TabIndex = 3;
            // 
            // autoLabel2
            // 
            autoLabel2.Location = new Point(98, 140);
            autoLabel2.Name = "autoLabel2";
            autoLabel2.Size = new Size(67, 15);
            autoLabel2.TabIndex = 2;
            autoLabel2.Text = "Description";
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI Semibold", 9F);
            btnSave.Location = new Point(195, 214);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(96, 28);
            btnSave.TabIndex = 4;
            btnSave.Text = "Save";
            btnSave.Click += btnSave_Click;
            // 
            // txtName
            // 
            txtName.BeforeTouchSize = new Size(206, 23);
            txtName.Location = new Point(180, 99);
            txtName.Name = "txtName";
            txtName.Size = new Size(206, 23);
            txtName.TabIndex = 6;
            // 
            // autoLabel1
            // 
            autoLabel1.Location = new Point(98, 102);
            autoLabel1.Name = "autoLabel1";
            autoLabel1.Size = new Size(39, 15);
            autoLabel1.TabIndex = 5;
            autoLabel1.Text = "Name";
            // 
            // UpsertDepartmentView
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 341);
            Controls.Add(txtName);
            Controls.Add(autoLabel1);
            Controls.Add(btnSave);
            Controls.Add(txtDescription);
            Controls.Add(autoLabel2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "UpsertDepartmentView";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Style.MdiChild.IconHorizontalAlignment = HorizontalAlignment.Center;
            Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            Text = "Add Department";
            ((System.ComponentModel.ISupportInitialize)txtDescription).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtName).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtDescription;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private Syncfusion.WinForms.Controls.SfButton btnSave;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtName;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
    }
}