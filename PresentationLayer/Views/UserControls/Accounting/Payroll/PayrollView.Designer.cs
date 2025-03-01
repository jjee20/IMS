using Guna.UI2.WinForms;

namespace PresentationLayer.Views.UserControls
{
    partial class PayrollView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PayrollView));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            dgList = new Guna2DataGridView();
            panel2 = new Panel();
            guna2HtmlLabel7 = new Guna2HtmlLabel();
            txtStartDate = new Guna2DateTimePicker();
            guna2HtmlLabel6 = new Guna2HtmlLabel();
            txtEndDate = new Guna2DateTimePicker();
            btnBenefits = new MaterialSkin.Controls.MaterialSwitch();
            btnContribution = new MaterialSkin.Controls.MaterialSwitch();
            btnPrint = new Guna2Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            guna2Separator1 = new Guna2Separator();
            materialCard1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgList).BeginInit();
            panel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // materialCard1
            // 
            materialCard1.AutoSize = true;
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(dgList);
            materialCard1.Controls.Add(panel2);
            materialCard1.Controls.Add(tableLayoutPanel1);
            materialCard1.Depth = 0;
            materialCard1.Dock = DockStyle.Fill;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(0, 0);
            materialCard1.Margin = new Padding(16, 19, 16, 19);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(16, 19, 16, 19);
            materialCard1.Size = new Size(1356, 701);
            materialCard1.TabIndex = 2;
            // 
            // dgList
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            dgList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 14F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgList.ColumnHeadersHeight = 50;
            dgList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(222, 0, 0, 0);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgList.DefaultCellStyle = dataGridViewCellStyle3;
            dgList.Dock = DockStyle.Fill;
            dgList.GridColor = Color.FromArgb(231, 229, 255);
            dgList.Location = new Point(16, 139);
            dgList.Margin = new Padding(10);
            dgList.Name = "dgList";
            dgList.RowHeadersVisible = false;
            dgList.RowHeadersWidth = 51;
            dgList.RowTemplate.Height = 29;
            dgList.Size = new Size(1324, 543);
            dgList.TabIndex = 6;
            dgList.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgList.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgList.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgList.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgList.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgList.ThemeStyle.BackColor = Color.White;
            dgList.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dgList.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgList.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgList.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dgList.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgList.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgList.ThemeStyle.HeaderStyle.Height = 50;
            dgList.ThemeStyle.ReadOnly = false;
            dgList.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgList.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgList.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgList.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(222, 0, 0, 0);
            dgList.ThemeStyle.RowsStyle.Height = 29;
            dgList.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgList.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(guna2HtmlLabel7);
            panel2.Controls.Add(txtStartDate);
            panel2.Controls.Add(guna2HtmlLabel6);
            panel2.Controls.Add(txtEndDate);
            panel2.Controls.Add(btnBenefits);
            panel2.Controls.Add(btnContribution);
            panel2.Controls.Add(btnPrint);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(16, 89);
            panel2.Margin = new Padding(3, 13, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(1324, 50);
            panel2.TabIndex = 3;
            // 
            // guna2HtmlLabel7
            // 
            guna2HtmlLabel7.BackColor = Color.Transparent;
            guna2HtmlLabel7.Dock = DockStyle.Right;
            guna2HtmlLabel7.Location = new Point(342, 0);
            guna2HtmlLabel7.Name = "guna2HtmlLabel7";
            guna2HtmlLabel7.Size = new Size(34, 17);
            guna2HtmlLabel7.TabIndex = 14;
            guna2HtmlLabel7.Text = "From:";
            guna2HtmlLabel7.TextAlignment = ContentAlignment.MiddleRight;
            // 
            // txtStartDate
            // 
            txtStartDate.Checked = true;
            txtStartDate.CustomizableEdges = customizableEdges1;
            txtStartDate.Dock = DockStyle.Right;
            txtStartDate.FillColor = Color.White;
            txtStartDate.Font = new Font("Segoe UI", 9F);
            txtStartDate.Format = DateTimePickerFormat.Long;
            txtStartDate.Location = new Point(376, 0);
            txtStartDate.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            txtStartDate.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            txtStartDate.Name = "txtStartDate";
            txtStartDate.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtStartDate.Size = new Size(250, 50);
            txtStartDate.TabIndex = 13;
            txtStartDate.Value = new DateTime(2025, 1, 12, 10, 14, 55, 9);
            // 
            // guna2HtmlLabel6
            // 
            guna2HtmlLabel6.BackColor = Color.Transparent;
            guna2HtmlLabel6.Dock = DockStyle.Right;
            guna2HtmlLabel6.Location = new Point(626, 0);
            guna2HtmlLabel6.Name = "guna2HtmlLabel6";
            guna2HtmlLabel6.Size = new Size(19, 17);
            guna2HtmlLabel6.TabIndex = 12;
            guna2HtmlLabel6.Text = "To:";
            guna2HtmlLabel6.TextAlignment = ContentAlignment.MiddleRight;
            // 
            // txtEndDate
            // 
            txtEndDate.Checked = true;
            txtEndDate.CustomizableEdges = customizableEdges3;
            txtEndDate.Dock = DockStyle.Right;
            txtEndDate.FillColor = Color.White;
            txtEndDate.Font = new Font("Segoe UI", 9F);
            txtEndDate.Format = DateTimePickerFormat.Long;
            txtEndDate.Location = new Point(645, 0);
            txtEndDate.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            txtEndDate.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            txtEndDate.Name = "txtEndDate";
            txtEndDate.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtEndDate.Size = new Size(250, 50);
            txtEndDate.TabIndex = 11;
            txtEndDate.Value = new DateTime(2025, 1, 12, 10, 14, 55, 9);
            // 
            // btnBenefits
            // 
            btnBenefits.AutoSize = true;
            btnBenefits.Depth = 0;
            btnBenefits.Dock = DockStyle.Right;
            btnBenefits.Location = new Point(895, 0);
            btnBenefits.Margin = new Padding(0);
            btnBenefits.MouseLocation = new Point(-1, -1);
            btnBenefits.MouseState = MaterialSkin.MouseState.HOVER;
            btnBenefits.Name = "btnBenefits";
            btnBenefits.Ripple = true;
            btnBenefits.Size = new Size(171, 50);
            btnBenefits.TabIndex = 16;
            btnBenefits.Text = "Include Benefits";
            btnBenefits.UseVisualStyleBackColor = true;
            // 
            // btnContribution
            // 
            btnContribution.AutoSize = true;
            btnContribution.Depth = 0;
            btnContribution.Dock = DockStyle.Right;
            btnContribution.Location = new Point(1066, 0);
            btnContribution.Margin = new Padding(0);
            btnContribution.MouseLocation = new Point(-1, -1);
            btnContribution.MouseState = MaterialSkin.MouseState.HOVER;
            btnContribution.Name = "btnContribution";
            btnContribution.Ripple = true;
            btnContribution.Size = new Size(208, 50);
            btnContribution.TabIndex = 15;
            btnContribution.Text = "Include Contributions";
            btnContribution.UseVisualStyleBackColor = true;
            // 
            // btnPrint
            // 
            btnPrint.CustomizableEdges = customizableEdges5;
            btnPrint.DisabledState.BorderColor = Color.DarkGray;
            btnPrint.DisabledState.CustomBorderColor = Color.DarkGray;
            btnPrint.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnPrint.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnPrint.Dock = DockStyle.Right;
            btnPrint.FillColor = Color.Transparent;
            btnPrint.Font = new Font("Segoe UI", 9F);
            btnPrint.ForeColor = Color.White;
            btnPrint.Image = (Image)resources.GetObject("btnPrint.Image");
            btnPrint.ImageSize = new Size(30, 30);
            btnPrint.Location = new Point(1274, 0);
            btnPrint.Name = "btnPrint";
            btnPrint.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnPrint.Size = new Size(50, 50);
            btnPrint.TabIndex = 10;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Controls.Add(guna2Separator1, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(16, 19);
            tableLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 76F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 24F));
            tableLayoutPanel1.Size = new Size(1324, 70);
            tableLayoutPanel1.TabIndex = 5;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.BackColor = Color.White;
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(materialLabel1, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Margin = new Padding(0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(1324, 53);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // materialLabel1
            // 
            materialLabel1.Depth = 0;
            materialLabel1.Dock = DockStyle.Left;
            materialLabel1.Font = new Font("Roboto", 34F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialLabel1.FontType = MaterialSkin.MaterialSkinManager.fontType.H4;
            materialLabel1.ForeColor = Color.FromArgb(255, 246, 233);
            materialLabel1.ImageAlign = ContentAlignment.MiddleLeft;
            materialLabel1.Location = new Point(3, 0);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(1318, 53);
            materialLabel1.TabIndex = 3;
            materialLabel1.Text = "Payroll Details";
            materialLabel1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // guna2Separator1
            // 
            guna2Separator1.Dock = DockStyle.Fill;
            guna2Separator1.Location = new Point(3, 56);
            guna2Separator1.Name = "guna2Separator1";
            guna2Separator1.Size = new Size(1318, 11);
            guna2Separator1.TabIndex = 1;
            // 
            // PayrollView
            // 
            AutoScaleMode = AutoScaleMode.Inherit;
            AutoSize = true;
            Controls.Add(materialCard1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "PayrollView";
            Size = new Size(1356, 701);
            materialCard1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgList).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialCard materialCard1;
        private Panel panel2;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private Guna2Button btnPrint;
        private Guna2Separator guna2Separator1;
        private Guna2HtmlLabel guna2HtmlLabel6;
        private Guna2DateTimePicker txtEndDate;
        private Guna2HtmlLabel guna2HtmlLabel7;
        private Guna2DateTimePicker txtStartDate;
        private Guna2DataGridView dgList;
        private MaterialSkin.Controls.MaterialSwitch btnContribution;
        private MaterialSkin.Controls.MaterialSwitch btnBenefits;
    }
}
