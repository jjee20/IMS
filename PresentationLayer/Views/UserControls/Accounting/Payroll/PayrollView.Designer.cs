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
            var gridTextColumn1 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            var gridTextColumn2 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            var gridTextColumn3 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            var gridTextColumn4 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            var gridTextColumn5 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            var gridTextColumn6 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            var gridTextColumn7 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            var gridTextColumn8 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            var gridTextColumn9 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            var gridTextColumn10 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            var gridTextColumn11 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            var gridTextColumn12 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            var gridTextColumn13 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            var gridTextColumn14 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            var gridTextColumn15 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            var gridTextColumn16 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            var gridTextColumn17 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            var gridImageColumn1 = new Syncfusion.WinForms.DataGrid.GridImageColumn();
            var gridImageColumn2 = new Syncfusion.WinForms.DataGrid.GridImageColumn();
            var customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            var customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            var customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            var customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            var customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(PayrollView));
            var customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            var customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            var customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            materialCard4 = new MaterialSkin.Controls.MaterialCard();
            panel1 = new Panel();
            dgList = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            dgPager = new Syncfusion.WinForms.DataPager.SfDataPager();
            panel2 = new Panel();
            panel3 = new Panel();
            guna2HtmlLabel7 = new Guna2HtmlLabel();
            txtStartDate = new Guna2DateTimePicker();
            panel4 = new Panel();
            guna2HtmlLabel6 = new Guna2HtmlLabel();
            txtEndDate = new Guna2DateTimePicker();
            panelProject = new Panel();
            btnAll = new MaterialSkin.Controls.MaterialSwitch();
            txtProject = new MaterialSkin.Controls.MaterialComboBox();
            btnBenifits = new MaterialSkin.Controls.MaterialSwitch();
            btnContribution = new MaterialSkin.Controls.MaterialSwitch();
            btnPrint = new Guna2Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            btnRefresh = new Guna2Button();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            guna2Separator1 = new Guna2Separator();
            materialCard1.SuspendLayout();
            materialCard4.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgList).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panelProject.SuspendLayout();
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
            materialCard1.Size = new Size(896, 482);
            materialCard1.TabIndex = 2;
            // 
            // materialCard4
            // 
            materialCard4.BackColor = Color.FromArgb(255, 255, 255);
            materialCard4.Controls.Add(panel1);
            materialCard4.Depth = 0;
            materialCard4.Dock = DockStyle.Fill;
            materialCard4.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard4.Location = new Point(16, 139);
            materialCard4.Margin = new Padding(14);
            materialCard4.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard4.Name = "materialCard4";
            materialCard4.Padding = new Padding(14);
            materialCard4.Size = new Size(864, 324);
            materialCard4.TabIndex = 6;
            // 
            // panel1
            // 
            panel1.Controls.Add(dgList);
            panel1.Controls.Add(dgPager);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(14, 14);
            panel1.Name = "panel1";
            panel1.Size = new Size(836, 296);
            panel1.TabIndex = 1;
            // 
            // dgList
            // 
            dgList.AccessibleName = "Table";
            dgList.AllowFiltering = true;
            dgList.AllowTriStateSorting = true;
            dgList.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.Fill;
            gridTextColumn1.AllowFiltering = true;
            gridTextColumn1.AllowTextWrapping = true;
            gridTextColumn1.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.Fill;
            gridTextColumn1.HeaderText = "Employee";
            gridTextColumn1.MappingName = "Employee";
            gridTextColumn2.AllowFiltering = true;
            gridTextColumn2.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.ColumnHeader;
            gridTextColumn2.Format = "C2";
            gridTextColumn2.HeaderText = "Daily Rate";
            gridTextColumn2.MappingName = "DailyRate";
            gridTextColumn3.AllowFiltering = true;
            gridTextColumn3.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.ColumnHeader;
            gridTextColumn3.HeaderText = "Days Worked";
            gridTextColumn3.MappingName = "DaysWorked";
            gridTextColumn4.AllowFiltering = true;
            gridTextColumn4.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.ColumnHeader;
            gridTextColumn4.Format = "C2";
            gridTextColumn4.HeaderText = "Basic Salary";
            gridTextColumn4.MappingName = "BasicSalary";
            gridTextColumn5.AllowFiltering = true;
            gridTextColumn5.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.ColumnHeader;
            gridTextColumn5.Format = "C2";
            gridTextColumn5.HeaderText = "Overtime Pay";
            gridTextColumn5.MappingName = "OvertimePay";
            gridTextColumn6.AllowFiltering = true;
            gridTextColumn6.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.ColumnHeader;
            gridTextColumn6.Format = "C2";
            gridTextColumn6.HeaderText = "Allowance";
            gridTextColumn6.MappingName = "Allowances";
            gridTextColumn7.AllowFiltering = true;
            gridTextColumn7.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.ColumnHeader;
            gridTextColumn7.Format = "C2";
            gridTextColumn7.HeaderText = "Benefits";
            gridTextColumn7.MappingName = "Benefits";
            gridTextColumn8.AllowFiltering = true;
            gridTextColumn8.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.ColumnHeader;
            gridTextColumn8.Format = "C2";
            gridTextColumn8.HeaderText = "Bonus";
            gridTextColumn8.MappingName = "Bonuses";
            gridTextColumn9.AllowFiltering = true;
            gridTextColumn9.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.ColumnHeader;
            gridTextColumn9.CellStyle.BackColor = SystemColors.HotTrack;
            gridTextColumn9.Format = "C2";
            gridTextColumn9.HeaderText = "Gross Pay";
            gridTextColumn9.MappingName = "GrossPay";
            gridTextColumn10.AllowFiltering = true;
            gridTextColumn10.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.ColumnHeader;
            gridTextColumn10.Format = "C2";
            gridTextColumn10.HeaderText = "Late/Early";
            gridTextColumn10.MappingName = "LateAndEarly";
            gridTextColumn11.AllowFiltering = true;
            gridTextColumn11.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.ColumnHeader;
            gridTextColumn11.Format = "C2";
            gridTextColumn11.HeaderText = "Absent";
            gridTextColumn11.MappingName = "Absent";
            gridTextColumn12.AllowFiltering = true;
            gridTextColumn12.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.ColumnHeader;
            gridTextColumn12.Format = "C2";
            gridTextColumn12.HeaderText = "SSS";
            gridTextColumn12.MappingName = "SSSContribution";
            gridTextColumn13.AllowFiltering = true;
            gridTextColumn13.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.ColumnHeader;
            gridTextColumn13.Format = "C2";
            gridTextColumn13.HeaderText = "Pag-Ibig";
            gridTextColumn13.MappingName = "PagibigContribution";
            gridTextColumn14.AllowFiltering = true;
            gridTextColumn14.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.ColumnHeader;
            gridTextColumn14.Format = "C2";
            gridTextColumn14.HeaderText = "PhilHealth";
            gridTextColumn14.MappingName = "PhilHealthContribution";
            gridTextColumn15.AllowFiltering = true;
            gridTextColumn15.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.ColumnHeader;
            gridTextColumn15.Format = "C2";
            gridTextColumn15.HeaderText = "Other Deduction";
            gridTextColumn15.MappingName = "Deductions";
            gridTextColumn16.AllowFiltering = true;
            gridTextColumn16.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.ColumnHeader;
            gridTextColumn16.CellStyle.BackColor = Color.IndianRed;
            gridTextColumn16.Format = "C2";
            gridTextColumn16.HeaderText = "Total Deduction";
            gridTextColumn16.MappingName = "TotalDeduction";
            gridTextColumn17.AllowFiltering = true;
            gridTextColumn17.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.ColumnHeader;
            gridTextColumn17.CellStyle.BackColor = Color.LightSeaGreen;
            gridTextColumn17.Format = "C2";
            gridTextColumn17.HeaderText = "Net Pay";
            gridTextColumn17.MappingName = "NetPay";
            gridImageColumn1.AllowGrouping = false;
            gridImageColumn1.AllowSorting = false;
            gridImageColumn1.HeaderText = " ";
            gridImageColumn1.ImageLayout = ImageLayout.Zoom;
            gridImageColumn1.MappingName = "TMonth";
            gridImageColumn1.MaximumWidth = 30D;
            gridImageColumn1.MinimumWidth = 30D;
            gridImageColumn1.Width = 30D;
            gridImageColumn2.AllowGrouping = false;
            gridImageColumn2.AllowSorting = false;
            gridImageColumn2.HeaderText = " ";
            gridImageColumn2.MappingName = "Payslip";
            gridImageColumn2.MaximumWidth = 30D;
            gridImageColumn2.MinimumWidth = 30D;
            gridImageColumn2.Width = 30D;
            dgList.Columns.Add(gridTextColumn1);
            dgList.Columns.Add(gridTextColumn2);
            dgList.Columns.Add(gridTextColumn3);
            dgList.Columns.Add(gridTextColumn4);
            dgList.Columns.Add(gridTextColumn5);
            dgList.Columns.Add(gridTextColumn6);
            dgList.Columns.Add(gridTextColumn7);
            dgList.Columns.Add(gridTextColumn8);
            dgList.Columns.Add(gridTextColumn9);
            dgList.Columns.Add(gridTextColumn10);
            dgList.Columns.Add(gridTextColumn11);
            dgList.Columns.Add(gridTextColumn12);
            dgList.Columns.Add(gridTextColumn13);
            dgList.Columns.Add(gridTextColumn14);
            dgList.Columns.Add(gridTextColumn15);
            dgList.Columns.Add(gridTextColumn16);
            dgList.Columns.Add(gridTextColumn17);
            dgList.Columns.Add(gridImageColumn1);
            dgList.Columns.Add(gridImageColumn2);
            dgList.Dock = DockStyle.Fill;
            dgList.FrozenColumnCount = 2;
            dgList.FrozenRowCount = 1;
            dgList.Location = new Point(0, 0);
            dgList.Name = "dgList";
            dgList.PreviewRowHeight = 42;
            dgList.ShowGroupDropArea = true;
            dgList.Size = new Size(836, 260);
            dgList.Style.BorderColor = Color.FromArgb(100, 100, 100);
            dgList.Style.CheckBoxStyle.CheckedBackColor = Color.FromArgb(0, 120, 215);
            dgList.Style.CheckBoxStyle.CheckedBorderColor = Color.FromArgb(0, 120, 215);
            dgList.Style.CheckBoxStyle.IndeterminateBorderColor = Color.FromArgb(0, 120, 215);
            dgList.Style.HyperlinkStyle.DefaultLinkColor = Color.FromArgb(0, 120, 215);
            dgList.TabIndex = 7;
            dgList.Text = "sfDataGrid1";
            dgList.CellClick += dgList_CellClick;
            // 
            // dgPager
            // 
            dgPager.AccessibleName = "DataPager";
            dgPager.CanOverrideStyle = true;
            dgPager.DataSource = dgList.DataBindings;
            dgPager.Dock = DockStyle.Bottom;
            dgPager.HorizontalAlignment = HorizontalAlignment.Center;
            dgPager.Location = new Point(0, 260);
            dgPager.Name = "dgPager";
            dgPager.PageCount = 1;
            dgPager.PageSize = 15;
            dgPager.Size = new Size(836, 36);
            dgPager.TabIndex = 8;
            dgPager.Text = "sfDataPager1";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(panelProject);
            panel2.Controls.Add(btnBenifits);
            panel2.Controls.Add(btnContribution);
            panel2.Controls.Add(btnPrint);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(16, 89);
            panel2.Margin = new Padding(3, 13, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(864, 50);
            panel2.TabIndex = 3;
            // 
            // panel3
            // 
            panel3.Controls.Add(guna2HtmlLabel7);
            panel3.Controls.Add(txtStartDate);
            panel3.Dock = DockStyle.Right;
            panel3.Location = new Point(-302, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(266, 50);
            panel3.TabIndex = 20;
            // 
            // guna2HtmlLabel7
            // 
            guna2HtmlLabel7.BackColor = Color.Transparent;
            guna2HtmlLabel7.Location = new Point(5, 16);
            guna2HtmlLabel7.Name = "guna2HtmlLabel7";
            guna2HtmlLabel7.Size = new Size(66, 17);
            guna2HtmlLabel7.TabIndex = 14;
            guna2HtmlLabel7.Text = "Date Range:";
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
            txtStartDate.Location = new Point(75, 0);
            txtStartDate.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            txtStartDate.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            txtStartDate.Name = "txtStartDate";
            txtStartDate.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtStartDate.Size = new Size(191, 50);
            txtStartDate.TabIndex = 13;
            txtStartDate.Value = new DateTime(2025, 1, 12, 10, 14, 55, 9);
            txtStartDate.ValueChanged += txtStartDate_ValueChanged;
            // 
            // panel4
            // 
            panel4.Controls.Add(guna2HtmlLabel6);
            panel4.Controls.Add(txtEndDate);
            panel4.Dock = DockStyle.Right;
            panel4.Location = new Point(-36, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(219, 50);
            panel4.TabIndex = 21;
            // 
            // guna2HtmlLabel6
            // 
            guna2HtmlLabel6.BackColor = Color.Transparent;
            guna2HtmlLabel6.Location = new Point(8, 16);
            guna2HtmlLabel6.Name = "guna2HtmlLabel6";
            guna2HtmlLabel6.Size = new Size(8, 17);
            guna2HtmlLabel6.TabIndex = 12;
            guna2HtmlLabel6.Text = "-";
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
            txtEndDate.Location = new Point(22, 0);
            txtEndDate.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            txtEndDate.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            txtEndDate.Name = "txtEndDate";
            txtEndDate.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtEndDate.Size = new Size(197, 50);
            txtEndDate.TabIndex = 11;
            txtEndDate.Value = new DateTime(2025, 1, 12, 10, 14, 55, 9);
            txtEndDate.ValueChanged += txtEndDate_ValueChanged;
            // 
            // panelProject
            // 
            panelProject.Controls.Add(btnAll);
            panelProject.Controls.Add(txtProject);
            panelProject.Dock = DockStyle.Right;
            panelProject.Location = new Point(183, 0);
            panelProject.Name = "panelProject";
            panelProject.Size = new Size(362, 50);
            panelProject.TabIndex = 19;
            // 
            // btnAll
            // 
            btnAll.AutoSize = true;
            btnAll.Checked = true;
            btnAll.CheckState = CheckState.Checked;
            btnAll.Depth = 0;
            btnAll.Dock = DockStyle.Right;
            btnAll.Location = new Point(-3, 0);
            btnAll.Margin = new Padding(0);
            btnAll.MouseLocation = new Point(-1, -1);
            btnAll.MouseState = MaterialSkin.MouseState.HOVER;
            btnAll.Name = "btnAll";
            btnAll.Ripple = true;
            btnAll.Size = new Size(153, 50);
            btnAll.TabIndex = 19;
            btnAll.Text = "  All Projects  ";
            btnAll.UseVisualStyleBackColor = true;
            btnAll.CheckedChanged += btnAll_CheckedChanged;
            // 
            // txtProject
            // 
            txtProject.AutoResize = false;
            txtProject.BackColor = Color.FromArgb(255, 255, 255);
            txtProject.Depth = 0;
            txtProject.Dock = DockStyle.Right;
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
            txtProject.Location = new Point(150, 0);
            txtProject.MaxDropDownItems = 4;
            txtProject.MouseState = MaterialSkin.MouseState.OUT;
            txtProject.Name = "txtProject";
            txtProject.Size = new Size(212, 49);
            txtProject.StartIndex = 0;
            txtProject.TabIndex = 18;
            txtProject.Visible = false;
            txtProject.SelectedIndexChanged += txtProject_SelectedIndexChanged_1;
            // 
            // btnBenifits
            // 
            btnBenifits.AutoSize = true;
            btnBenifits.Depth = 0;
            btnBenifits.Dock = DockStyle.Right;
            btnBenifits.Location = new Point(545, 0);
            btnBenifits.Margin = new Padding(0);
            btnBenifits.MouseLocation = new Point(-1, -1);
            btnBenifits.MouseState = MaterialSkin.MouseState.HOVER;
            btnBenifits.Name = "btnBenifits";
            btnBenifits.Ripple = true;
            btnBenifits.Size = new Size(116, 50);
            btnBenifits.TabIndex = 16;
            btnBenifits.Text = "Benefits";
            btnBenifits.UseVisualStyleBackColor = true;
            btnBenifits.CheckedChanged += btnBenifits_CheckedChanged;
            // 
            // btnContribution
            // 
            btnContribution.AutoSize = true;
            btnContribution.Depth = 0;
            btnContribution.Dock = DockStyle.Right;
            btnContribution.Location = new Point(661, 0);
            btnContribution.Margin = new Padding(0);
            btnContribution.MouseLocation = new Point(-1, -1);
            btnContribution.MouseState = MaterialSkin.MouseState.HOVER;
            btnContribution.Name = "btnContribution";
            btnContribution.Ripple = true;
            btnContribution.Size = new Size(153, 50);
            btnContribution.TabIndex = 15;
            btnContribution.Text = "Contributions";
            btnContribution.UseVisualStyleBackColor = true;
            btnContribution.CheckedChanged += btnContribution_CheckedChanged;
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
            btnPrint.Location = new Point(814, 0);
            btnPrint.Name = "btnPrint";
            btnPrint.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnPrint.Size = new Size(50, 50);
            btnPrint.TabIndex = 10;
            btnPrint.Click += btnPrint_Click;
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
            tableLayoutPanel1.Size = new Size(864, 70);
            tableLayoutPanel1.TabIndex = 5;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.BackColor = Color.White;
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 65F));
            tableLayoutPanel2.Controls.Add(btnRefresh, 1, 0);
            tableLayoutPanel2.Controls.Add(materialLabel1, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Margin = new Padding(0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(864, 53);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // btnRefresh
            // 
            btnRefresh.CustomizableEdges = customizableEdges7;
            btnRefresh.DisabledState.BorderColor = Color.DarkGray;
            btnRefresh.DisabledState.CustomBorderColor = Color.DarkGray;
            btnRefresh.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnRefresh.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnRefresh.Dock = DockStyle.Right;
            btnRefresh.FillColor = Color.Transparent;
            btnRefresh.Font = new Font("Segoe UI", 9F);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Image = (Image)resources.GetObject("btnRefresh.Image");
            btnRefresh.ImageSize = new Size(30, 30);
            btnRefresh.Location = new Point(811, 3);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnRefresh.Size = new Size(50, 47);
            btnRefresh.TabIndex = 11;
            btnRefresh.Click += btnRefresh_Click;
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
            materialLabel1.Size = new Size(793, 53);
            materialLabel1.TabIndex = 3;
            materialLabel1.Text = "Payroll Management";
            materialLabel1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // guna2Separator1
            // 
            guna2Separator1.Dock = DockStyle.Fill;
            guna2Separator1.Location = new Point(3, 56);
            guna2Separator1.Name = "guna2Separator1";
            guna2Separator1.Size = new Size(858, 11);
            guna2Separator1.TabIndex = 1;
            // 
            // PayrollView
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            ClientSize = new Size(900, 486);
            Controls.Add(materialCard1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
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
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panelProject.ResumeLayout(false);
            panelProject.PerformLayout();
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
        private MaterialSkin.Controls.MaterialCard materialCard4;
        private Panel panel1;
        private Syncfusion.WinForms.DataGrid.SfDataGrid dgList;
        private Syncfusion.WinForms.DataPager.SfDataPager dgPager;
        private Panel panelProject;
        private MaterialSkin.Controls.MaterialSwitch btnAll;
        private MaterialSkin.Controls.MaterialComboBox txtProject;
        private Panel panel3;
        private Panel panel4;
        private Guna2Button btnRefresh;
    }
}
