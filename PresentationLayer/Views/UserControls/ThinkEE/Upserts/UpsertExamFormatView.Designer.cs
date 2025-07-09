namespace RavenTech_ERP.Views.UserControls.Inventory
{
    partial class UpsertExamFormatView
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(UpsertExamFormatView));
            autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtName = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            txtDescription = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            btnSave = new Syncfusion.WinForms.Controls.SfButton();
            txtDuration = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            autoLabel3 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel4 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            ((System.ComponentModel.ISupportInitialize)txtName).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtDescription).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtDuration).BeginInit();
            SuspendLayout();
            // 
            // autoLabel1
            // 
            autoLabel1.Location = new Point(139, 160);
            autoLabel1.Margin = new Padding(4, 0, 4, 0);
            autoLabel1.Name = "autoLabel1";
            autoLabel1.Size = new Size(59, 25);
            autoLabel1.TabIndex = 0;
            autoLabel1.Text = "Name";
            // 
            // txtName
            // 
            txtName.BeforeTouchSize = new Size(210, 31);
            txtName.Location = new Point(256, 154);
            txtName.Margin = new Padding(4, 5, 4, 5);
            txtName.Name = "txtName";
            txtName.Size = new Size(293, 31);
            txtName.TabIndex = 1;
            // 
            // txtDescription
            // 
            txtDescription.BeforeTouchSize = new Size(210, 31);
            txtDescription.Location = new Point(256, 212);
            txtDescription.Margin = new Padding(4, 5, 4, 5);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(293, 31);
            txtDescription.TabIndex = 3;
            // 
            // autoLabel2
            // 
            autoLabel2.Location = new Point(139, 218);
            autoLabel2.Margin = new Padding(4, 0, 4, 0);
            autoLabel2.Name = "autoLabel2";
            autoLabel2.Size = new Size(54, 25);
            autoLabel2.TabIndex = 2;
            autoLabel2.Text = "Code";
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI Semibold", 9F);
            btnSave.Location = new Point(270, 355);
            btnSave.Margin = new Padding(4, 5, 4, 5);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(137, 47);
            btnSave.TabIndex = 4;
            btnSave.Text = "Save";
            btnSave.Click += btnSave_Click;
            // 
            // txtDuration
            // 
            txtDuration.BeforeTouchSize = new Size(210, 31);
            txtDuration.Location = new Point(256, 274);
            txtDuration.Margin = new Padding(4, 5, 4, 5);
            txtDuration.Name = "txtDuration";
            txtDuration.Size = new Size(210, 31);
            txtDuration.TabIndex = 6;
            // 
            // autoLabel3
            // 
            autoLabel3.Location = new Point(139, 280);
            autoLabel3.Margin = new Padding(4, 0, 4, 0);
            autoLabel3.Name = "autoLabel3";
            autoLabel3.Size = new Size(81, 25);
            autoLabel3.TabIndex = 5;
            autoLabel3.Text = "Duration";
            // 
            // autoLabel4
            // 
            autoLabel4.Location = new Point(474, 280);
            autoLabel4.Margin = new Padding(4, 0, 4, 0);
            autoLabel4.Name = "autoLabel4";
            autoLabel4.Size = new Size(75, 25);
            autoLabel4.TabIndex = 7;
            autoLabel4.Text = "minutes";
            // 
            // UpsertExamFormatView
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(689, 557);
            Controls.Add(autoLabel4);
            Controls.Add(txtDuration);
            Controls.Add(autoLabel3);
            Controls.Add(btnSave);
            Controls.Add(txtDescription);
            Controls.Add(autoLabel2);
            Controls.Add(txtName);
            Controls.Add(autoLabel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 5, 4, 5);
            Name = "UpsertExamFormatView";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Style.MdiChild.IconHorizontalAlignment = HorizontalAlignment.Center;
            Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            Text = "Add Review Topic";
            ((System.ComponentModel.ISupportInitialize)txtName).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtDescription).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtDuration).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtName;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtDescription;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private Syncfusion.WinForms.Controls.SfButton btnSave;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtDuration;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel3;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel4;
    }
}