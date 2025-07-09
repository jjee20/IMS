namespace RavenTech_ERP.Views.UserControls.Inventory
{
    partial class UpsertExamTopicView
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(UpsertExamTopicView));
            autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtName = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            txtCategory = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            btnSave = new Syncfusion.WinForms.Controls.SfButton();
            autoLabel3 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtReviewTopic = new Syncfusion.WinForms.ListView.SfComboBox();
            ((System.ComponentModel.ISupportInitialize)txtName).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtCategory).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtReviewTopic).BeginInit();
            SuspendLayout();
            // 
            // autoLabel1
            // 
            autoLabel1.Location = new Point(139, 154);
            autoLabel1.Margin = new Padding(4, 0, 4, 0);
            autoLabel1.Name = "autoLabel1";
            autoLabel1.Size = new Size(59, 25);
            autoLabel1.TabIndex = 0;
            autoLabel1.Text = "Name";
            // 
            // txtName
            // 
            txtName.BeforeTouchSize = new Size(293, 31);
            txtName.Location = new Point(256, 148);
            txtName.Margin = new Padding(4, 5, 4, 5);
            txtName.Name = "txtName";
            txtName.Size = new Size(293, 31);
            txtName.TabIndex = 1;
            // 
            // txtCategory
            // 
            txtCategory.BeforeTouchSize = new Size(293, 31);
            txtCategory.Location = new Point(256, 213);
            txtCategory.Margin = new Padding(4, 5, 4, 5);
            txtCategory.Name = "txtCategory";
            txtCategory.Size = new Size(293, 31);
            txtCategory.TabIndex = 3;
            // 
            // autoLabel2
            // 
            autoLabel2.Location = new Point(139, 219);
            autoLabel2.Margin = new Padding(4, 0, 4, 0);
            autoLabel2.Name = "autoLabel2";
            autoLabel2.Size = new Size(84, 25);
            autoLabel2.TabIndex = 2;
            autoLabel2.Text = "Category";
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI Semibold", 9F);
            btnSave.Location = new Point(278, 373);
            btnSave.Margin = new Padding(4, 5, 4, 5);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(137, 47);
            btnSave.TabIndex = 4;
            btnSave.Text = "Save";
            btnSave.Click += btnSave_Click;
            // 
            // autoLabel3
            // 
            autoLabel3.Location = new Point(139, 289);
            autoLabel3.Margin = new Padding(4, 0, 4, 0);
            autoLabel3.Name = "autoLabel3";
            autoLabel3.Size = new Size(112, 25);
            autoLabel3.TabIndex = 5;
            autoLabel3.Text = "Review Topic";
            // 
            // txtReviewTopic
            // 
            txtReviewTopic.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            txtReviewTopic.Location = new Point(256, 279);
            txtReviewTopic.Name = "txtReviewTopic";
            txtReviewTopic.Size = new Size(293, 35);
            txtReviewTopic.Style.TokenStyle.CloseButtonBackColor = Color.FromArgb(255, 255, 255);
            txtReviewTopic.TabIndex = 6;
            txtReviewTopic.TabStop = false;
            // 
            // UpsertExamTopicView
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(689, 557);
            Controls.Add(txtReviewTopic);
            Controls.Add(autoLabel3);
            Controls.Add(btnSave);
            Controls.Add(txtCategory);
            Controls.Add(autoLabel2);
            Controls.Add(txtName);
            Controls.Add(autoLabel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 5, 4, 5);
            Name = "UpsertExamTopicView";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Style.MdiChild.IconHorizontalAlignment = HorizontalAlignment.Center;
            Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            Text = "Add Exam Topic";
            ((System.ComponentModel.ISupportInitialize)txtName).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtCategory).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtReviewTopic).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtName;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtCategory;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private Syncfusion.WinForms.Controls.SfButton btnSave;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel3;
        private Syncfusion.WinForms.ListView.SfComboBox txtReviewTopic;
    }
}