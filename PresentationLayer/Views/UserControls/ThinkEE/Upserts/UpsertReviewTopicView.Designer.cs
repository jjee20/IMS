namespace RavenTech_ERP.Views.UserControls.Inventory
{
    partial class UpsertReviewTopicView
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(UpsertReviewTopicView));
            autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtName = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            txtCode = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            btnSave = new Syncfusion.WinForms.Controls.SfButton();
            ((System.ComponentModel.ISupportInitialize)txtName).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtCode).BeginInit();
            SuspendLayout();
            // 
            // autoLabel1
            // 
            autoLabel1.Location = new Point(139, 254);
            autoLabel1.Margin = new Padding(4, 0, 4, 0);
            autoLabel1.Name = "autoLabel1";
            autoLabel1.Size = new Size(59, 25);
            autoLabel1.TabIndex = 0;
            autoLabel1.Text = "Name";
            // 
            // txtName
            // 
            txtName.BeforeTouchSize = new Size(293, 31);
            txtName.Location = new Point(256, 248);
            txtName.Margin = new Padding(4, 5, 4, 5);
            txtName.Name = "txtName";
            txtName.Size = new Size(293, 31);
            txtName.TabIndex = 1;
            // 
            // txtCode
            // 
            txtCode.BeforeTouchSize = new Size(293, 31);
            txtCode.Location = new Point(256, 178);
            txtCode.Margin = new Padding(4, 5, 4, 5);
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(293, 31);
            txtCode.TabIndex = 3;
            // 
            // autoLabel2
            // 
            autoLabel2.Location = new Point(139, 184);
            autoLabel2.Margin = new Padding(4, 0, 4, 0);
            autoLabel2.Name = "autoLabel2";
            autoLabel2.Size = new Size(54, 25);
            autoLabel2.TabIndex = 2;
            autoLabel2.Text = "Code";
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI Semibold", 9F);
            btnSave.Location = new Point(277, 348);
            btnSave.Margin = new Padding(4, 5, 4, 5);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(137, 47);
            btnSave.TabIndex = 4;
            btnSave.Text = "Save";
            btnSave.Click += btnSave_Click;
            // 
            // UpsertReviewTopicView
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(689, 557);
            Controls.Add(btnSave);
            Controls.Add(txtCode);
            Controls.Add(autoLabel2);
            Controls.Add(txtName);
            Controls.Add(autoLabel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 5, 4, 5);
            Name = "UpsertReviewTopicView";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Style.MdiChild.IconHorizontalAlignment = HorizontalAlignment.Center;
            Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            Text = "Add Review Topic";
            ((System.ComponentModel.ISupportInitialize)txtName).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtCode).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtName;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtCode;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private Syncfusion.WinForms.Controls.SfButton btnSave;
    }
}