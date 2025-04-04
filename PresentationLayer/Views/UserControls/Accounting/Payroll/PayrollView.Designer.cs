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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PayrollView));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            materialCard4 = new MaterialSkin.Controls.MaterialCard();
            panel1 = new Panel();
            dgList = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            dgPager = new Syncfusion.WinForms.DataPager.SfDataPager();
            panel2 = new Panel();
            btnAll = new MaterialSkin.Controls.MaterialSwitch();
            txtProject = new MaterialSkin.Controls.MaterialComboBox();
            guna2HtmlLabel7 = new Guna2HtmlLabel();
            txtStartDate = new Guna2DateTimePicker();
            guna2HtmlLabel6 = new Guna2HtmlLabel();
            txtEndDate = new Guna2DateTimePicker();
            btnBenifits = new MaterialSkin.Controls.MaterialSwitch();
            btnContribution = new MaterialSkin.Controls.MaterialSwitch();
            btnPrint = new Guna2Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            guna2Separator1 = new Guna2Separator();
            materialCard1.SuspendLayout();
            materialCard4.SuspendLayout();
            panel1.SuspendLayout();
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
            materialCard1.Controls.Add(materialCard4);
            materialCard1.Controls.Add(panel2);
            materialCard1.Controls.Add(tableLayoutPanel1);
            materialCard1.Depth = 0;
            materialCard1.Dock = DockStyle.Fill;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(2, 2);
            materialCard1.Margin = new Padding(16, 19, 16, 19);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(16, 19, 16, 19);
            materialCard1.Size = new Size(1496, 1048);
            materialCard1.TabIndex = 2;
            // 
            // materialCard4
            // 
            materialCard4.BackColor = Color.FromArgb(255, 255, 255);
            materialCard4.Controls.Add(panel1);
            materialCard4.Depth = 0;
            materialCard4.Dock = DockStyle.Fill;
            materialCard4.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard4.Location = new Point(16, 146);
            materialCard4.Margin = new Padding(14);
            materialCard4.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard4.Name = "materialCard4";
            materialCard4.Padding = new Padding(14);
            materialCard4.Size = new Size(1464, 883);
            materialCard4.TabIndex = 6;
            // 
            // panel1
            // 
            panel1.Controls.Add(dgList);
            panel1.Controls.Add(dgPager);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(14, 14);
            panel1.Name = "panel1";
            panel1.Size = new Size(1436, 855);
            panel1.TabIndex = 1;
            // 
            // dgList
            // 
            dgList.AccessibleName = "Table";
            dgList.AllowFiltering = true;
            dgList.AllowTriStateSorting = true;
            dgList.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.Fill;
            dgList.Dock = DockStyle.Fill;
            dgList.FrozenColumnCount = 2;
            dgList.FrozenRowCount = 1;
            dgList.Location = new Point(0, 0);
            dgList.Name = "dgList";
            dgList.ShowGroupDropArea = true;
            dgList.Size = new Size(1436, 819);
            dgList.Style.BorderColor = Color.FromArgb(100, 100, 100);
            dgList.Style.CheckBoxStyle.CheckedBackColor = Color.FromArgb(0, 120, 215);
            dgList.Style.CheckBoxStyle.CheckedBorderColor = Color.FromArgb(0, 120, 215);
            dgList.Style.CheckBoxStyle.IndeterminateBorderColor = Color.FromArgb(0, 120, 215);
            dgList.Style.HyperlinkStyle.DefaultLinkColor = Color.FromArgb(0, 120, 215);
            dgList.TabIndex = 7;
            dgList.Text = "sfDataGrid1";
            // 
            // dgPager
            // 
            dgPager.AccessibleName = "DataPager";
            dgPager.CanOverrideStyle = true;
            dgPager.DataSource = dgList.DataBindings;
            dgPager.Dock = DockStyle.Bottom;
            dgPager.HorizontalAlignment = HorizontalAlignment.Center;
            dgPager.Location = new Point(0, 819);
            dgPager.Name = "dgPager";
            dgPager.PageCount = 1;
            dgPager.PageSize = 15;
            dgPager.Size = new Size(1436, 36);
            dgPager.TabIndex = 8;
            dgPager.Text = "sfDataPager1";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(btnAll);
            panel2.Controls.Add(txtProject);
            panel2.Controls.Add(guna2HtmlLabel7);
            panel2.Controls.Add(txtStartDate);
            panel2.Controls.Add(guna2HtmlLabel6);
            panel2.Controls.Add(txtEndDate);
            panel2.Controls.Add(btnBenifits);
            panel2.Controls.Add(btnContribution);
            panel2.Controls.Add(btnPrint);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(16, 89);
            panel2.Margin = new Padding(3, 13, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(1464, 57);
            panel2.TabIndex = 3;
            // 
            // btnAll
            // 
            btnAll.AutoSize = true;
            btnAll.Checked = true;
            btnAll.CheckState = CheckState.Checked;
            btnAll.Depth = 0;
            btnAll.Dock = DockStyle.Left;
            btnAll.Location = new Point(264, 0);
            btnAll.Margin = new Padding(0);
            btnAll.MouseLocation = new Point(-1, -1);
            btnAll.MouseState = MaterialSkin.MouseState.HOVER;
            btnAll.Name = "btnAll";
            btnAll.Ripple = true;
            btnAll.Size = new Size(76, 57);
            btnAll.TabIndex = 18;
            btnAll.Text = "All";
            btnAll.UseVisualStyleBackColor = true;
            // 
            // txtProject
            // 
            txtProject.AutoResize = false;
            txtProject.BackColor = Color.FromArgb(255, 255, 255);
            txtProject.Depth = 0;
            txtProject.Dock = DockStyle.Left;
            txtProject.DrawMode = DrawMode.OwnerDrawVariable;
            txtProject.DropDownHeight = 174;
            txtProject.DropDownStyle = ComboBoxStyle.DropDownList;
            txtProject.DropDownWidth = 121;
            txtProject.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            txtProject.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtProject.FormattingEnabled = true;
            txtProject.Hint = "Project";
            txtProject.IntegralHeight = false;
            txtProject.ItemHeight = 43;
            txtProject.Location = new Point(0, 0);
            txtProject.MaxDropDownItems = 4;
            txtProject.MouseState = MaterialSkin.MouseState.OUT;
            txtProject.Name = "txtProject";
            txtProject.Size = new Size(264, 49);
            txtProject.StartIndex = 0;
            txtProject.TabIndex = 17;
            // 
            // guna2HtmlLabel7
            // 
            guna2HtmlLabel7.BackColor = Color.Transparent;
            guna2HtmlLabel7.Dock = DockStyle.Right;
            guna2HtmlLabel7.Location = new Point(594, 0);
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
            txtStartDate.Location = new Point(628, 0);
            txtStartDate.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            txtStartDate.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            txtStartDate.Name = "txtStartDate";
            txtStartDate.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtStartDate.Size = new Size(191, 57);
            txtStartDate.TabIndex = 13;
            txtStartDate.Value = new DateTime(2025, 1, 12, 10, 14, 55, 9);
            // 
            // guna2HtmlLabel6
            // 
            guna2HtmlLabel6.BackColor = Color.Transparent;
            guna2HtmlLabel6.Dock = DockStyle.Right;
            guna2HtmlLabel6.Location = new Point(819, 0);
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
            txtEndDate.Location = new Point(838, 0);
            txtEndDate.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            txtEndDate.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            txtEndDate.Name = "txtEndDate";
            txtEndDate.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtEndDate.Size = new Size(197, 57);
            txtEndDate.TabIndex = 11;
            txtEndDate.Value = new DateTime(2025, 1, 12, 10, 14, 55, 9);
            // 
            // btnBenifits
            // 
            btnBenifits.AutoSize = true;
            btnBenifits.Depth = 0;
            btnBenifits.Dock = DockStyle.Right;
            btnBenifits.Location = new Point(1035, 0);
            btnBenifits.Margin = new Padding(0);
            btnBenifits.MouseLocation = new Point(-1, -1);
            btnBenifits.MouseState = MaterialSkin.MouseState.HOVER;
            btnBenifits.Name = "btnBenifits";
            btnBenifits.Ripple = true;
            btnBenifits.Size = new Size(171, 57);
            btnBenifits.TabIndex = 16;
            btnBenifits.Text = "Include Benefits";
            btnBenifits.UseVisualStyleBackColor = true;
            // 
            // btnContribution
            // 
            btnContribution.AutoSize = true;
            btnContribution.Depth = 0;
            btnContribution.Dock = DockStyle.Right;
            btnContribution.Location = new Point(1206, 0);
            btnContribution.Margin = new Padding(0);
            btnContribution.MouseLocation = new Point(-1, -1);
            btnContribution.MouseState = MaterialSkin.MouseState.HOVER;
            btnContribution.Name = "btnContribution";
            btnContribution.Ripple = true;
            btnContribution.Size = new Size(208, 57);
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
            btnPrint.Location = new Point(1414, 0);
            btnPrint.Name = "btnPrint";
            btnPrint.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnPrint.Size = new Size(50, 57);
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
            tableLayoutPanel1.Size = new Size(1464, 70);
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
            tableLayoutPanel2.Size = new Size(1464, 53);
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
            materialLabel1.Size = new Size(1302, 53);
            materialLabel1.TabIndex = 3;
            materialLabel1.Text = "Payroll Management";
            materialLabel1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // guna2Separator1
            // 
            guna2Separator1.Dock = DockStyle.Fill;
            guna2Separator1.Location = new Point(3, 56);
            guna2Separator1.Name = "guna2Separator1";
            guna2Separator1.Size = new Size(1458, 11);
            guna2Separator1.TabIndex = 1;
            // 
            // PayrollView
            // 
            AutoScaleMode = AutoScaleMode.Inherit;
            AutoSize = true;
            ClientSize = new Size(1500, 1052);
            Controls.Add(materialCard1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "PayrollView";
            Style.MdiChild.IconHorizontalAlignment = HorizontalAlignment.Center;
            Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            Load += PayrollView_Load;
            materialCard1.ResumeLayout(false);
            materialCard4.ResumeLayout(false);
            panel1.ResumeLayout(false);
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
        private MaterialSkin.Controls.MaterialSwitch btnContribution;
        private MaterialSkin.Controls.MaterialSwitch btnBenifits;
        private MaterialSkin.Controls.MaterialComboBox txtProject;
        private MaterialSkin.Controls.MaterialSwitch btnAll;
        private MaterialSkin.Controls.MaterialCard materialCard4;
        private Panel panel1;
        private Syncfusion.WinForms.DataGrid.SfDataGrid dgList;
        private Syncfusion.WinForms.DataPager.SfDataPager dgPager;
    }
}
