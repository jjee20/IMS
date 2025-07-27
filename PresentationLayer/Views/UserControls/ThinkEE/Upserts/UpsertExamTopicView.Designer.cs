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
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            ((System.ComponentModel.ISupportInitialize)txtName).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtCategory).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtReviewTopic).BeginInit();
            materialCard1.SuspendLayout();
            SuspendLayout();
            // 
            // autoLabel1
            // 
            autoLabel1.Dock = DockStyle.Top;
            autoLabel1.Location = new Point(14, 14);
            autoLabel1.Name = "autoLabel1";
            autoLabel1.Size = new Size(39, 15);
            autoLabel1.TabIndex = 0;
            autoLabel1.Text = "Name";
            // 
            // txtName
            // 
            txtName.BeforeTouchSize = new Size(291, 23);
            txtName.Dock = DockStyle.Top;
            txtName.Location = new Point(14, 29);
            txtName.Name = "txtName";
            txtName.Size = new Size(255, 23);
            txtName.TabIndex = 1;
            // 
            // txtCategory
            // 
            txtCategory.BeforeTouchSize = new Size(291, 23);
            txtCategory.Dock = DockStyle.Top;
            txtCategory.Location = new Point(14, 67);
            txtCategory.Name = "txtCategory";
            txtCategory.Size = new Size(255, 23);
            txtCategory.TabIndex = 3;
            // 
            // autoLabel2
            // 
            autoLabel2.Dock = DockStyle.Top;
            autoLabel2.Location = new Point(14, 52);
            autoLabel2.Name = "autoLabel2";
            autoLabel2.Size = new Size(55, 15);
            autoLabel2.TabIndex = 2;
            autoLabel2.Text = "Category";
            // 
            // btnSave
            // 
            btnSave.BackColor = SystemColors.HotTrack;
            btnSave.Dock = DockStyle.Bottom;
            btnSave.Font = new Font("Segoe UI Semibold", 9F);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(14, 164);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(255, 28);
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
            autoLabel3.Location = new Point(14, 90);
            autoLabel3.Name = "autoLabel3";
            autoLabel3.Size = new Size(75, 15);
            autoLabel3.TabIndex = 5;
            autoLabel3.Text = "Review Topic";
            // 
            // txtReviewTopic
            // 
            txtReviewTopic.Dock = DockStyle.Top;
            txtReviewTopic.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            txtReviewTopic.Location = new Point(14, 105);
            txtReviewTopic.Margin = new Padding(2, 2, 2, 2);
            txtReviewTopic.Name = "txtReviewTopic";
            txtReviewTopic.Padding = new Padding(5, 0, 0, 0);
            txtReviewTopic.Size = new Size(255, 23);
            txtReviewTopic.Style.TokenStyle.CloseButtonBackColor = Color.FromArgb(255, 255, 255);
            txtReviewTopic.TabIndex = 6;
            txtReviewTopic.TabStop = false;
            // 
            // materialCard1
            // 
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(txtReviewTopic);
            materialCard1.Controls.Add(autoLabel3);
            materialCard1.Controls.Add(btnSave);
            materialCard1.Controls.Add(txtCategory);
            materialCard1.Controls.Add(autoLabel2);
            materialCard1.Controls.Add(txtName);
            materialCard1.Controls.Add(autoLabel1);
            materialCard1.Depth = 0;
            materialCard1.Dock = DockStyle.Fill;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(1, 1);
            materialCard1.Margin = new Padding(14);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(14);
            materialCard1.Size = new Size(283, 206);
            materialCard1.TabIndex = 7;
            // 
            // UpsertExamTopicView
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(285, 208);
            Controls.Add(materialCard1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "UpsertExamTopicView";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Style.MdiChild.IconHorizontalAlignment = HorizontalAlignment.Center;
            Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            Text = "Add Exam Topic";
            ((System.ComponentModel.ISupportInitialize)txtName).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtCategory).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtReviewTopic).EndInit();
            materialCard1.ResumeLayout(false);
            materialCard1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtName;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtCategory;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private Syncfusion.WinForms.Controls.SfButton btnSave;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel3;
        private Syncfusion.WinForms.ListView.SfComboBox txtReviewTopic;
        private MaterialSkin.Controls.MaterialCard materialCard1;
    }
}