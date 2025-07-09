namespace RavenTech_ERP.Views.UserControls.Inventory
{
    partial class ProjectInformationView
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
            var gridTextColumn1 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            var gridTextColumn2 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            var gridTextColumn3 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            var gridNumericColumn1 = new Syncfusion.WinForms.DataGrid.GridNumericColumn();
            var gridNumericColumn2 = new Syncfusion.WinForms.DataGrid.GridNumericColumn();
            var gridNumericColumn3 = new Syncfusion.WinForms.DataGrid.GridNumericColumn();
            var gridNumericColumn4 = new Syncfusion.WinForms.DataGrid.GridNumericColumn();
            var gridNumericColumn5 = new Syncfusion.WinForms.DataGrid.GridNumericColumn();
            var gridNumericColumn6 = new Syncfusion.WinForms.DataGrid.GridNumericColumn();
            var gridNumericColumn7 = new Syncfusion.WinForms.DataGrid.GridNumericColumn();
            var gridNumericColumn8 = new Syncfusion.WinForms.DataGrid.GridNumericColumn();
            var gridNumericColumn9 = new Syncfusion.WinForms.DataGrid.GridNumericColumn();
            var stackedHeaderRow1 = new Syncfusion.WinForms.DataGrid.StackedHeaderRow();
            var stackedColumn1 = new Syncfusion.WinForms.DataGrid.StackedColumn();
            var stackedColumn2 = new Syncfusion.WinForms.DataGrid.StackedColumn();
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            panel1 = new Panel();
            dgProjectLines = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            dgPager = new Syncfusion.WinForms.DataPager.SfDataPager();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            txtActualAmount = new MaterialSkin.Controls.MaterialLabel();
            materialLabel9 = new MaterialSkin.Controls.MaterialLabel();
            txtVariance = new MaterialSkin.Controls.MaterialLabel();
            materialLabel7 = new MaterialSkin.Controls.MaterialLabel();
            txtTotalRevenue = new MaterialSkin.Controls.MaterialLabel();
            guna2Separator3 = new Guna.UI2.WinForms.Guna2Separator();
            materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            txtDeduction = new MaterialSkin.Controls.MaterialLabel();
            materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            txtPayroll = new MaterialSkin.Controls.MaterialLabel();
            guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            materialLabel15 = new MaterialSkin.Controls.MaterialLabel();
            txtBudget = new MaterialSkin.Controls.MaterialLabel();
            txtEndDate = new MaterialSkin.Controls.MaterialLabel();
            materialLabel10 = new MaterialSkin.Controls.MaterialLabel();
            txtStartDate = new MaterialSkin.Controls.MaterialLabel();
            materialLabel12 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            txtRevenue = new MaterialSkin.Controls.MaterialLabel();
            txtDescription = new MaterialSkin.Controls.MaterialLabel();
            materialLabel8 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            txtClient = new MaterialSkin.Controls.MaterialLabel();
            txtProjectName = new MaterialSkin.Controls.MaterialLabel();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            materialCard1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgProjectLines).BeginInit();
            SuspendLayout();
            // 
            // materialCard1
            // 
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(panel1);
            materialCard1.Controls.Add(materialLabel2);
            materialCard1.Controls.Add(txtActualAmount);
            materialCard1.Controls.Add(materialLabel9);
            materialCard1.Controls.Add(txtVariance);
            materialCard1.Controls.Add(materialLabel7);
            materialCard1.Controls.Add(txtTotalRevenue);
            materialCard1.Controls.Add(guna2Separator3);
            materialCard1.Controls.Add(materialLabel6);
            materialCard1.Controls.Add(txtDeduction);
            materialCard1.Controls.Add(materialLabel4);
            materialCard1.Controls.Add(txtPayroll);
            materialCard1.Controls.Add(guna2Separator1);
            materialCard1.Controls.Add(materialLabel15);
            materialCard1.Controls.Add(txtBudget);
            materialCard1.Controls.Add(txtEndDate);
            materialCard1.Controls.Add(materialLabel10);
            materialCard1.Controls.Add(txtStartDate);
            materialCard1.Controls.Add(materialLabel12);
            materialCard1.Controls.Add(materialLabel5);
            materialCard1.Controls.Add(txtRevenue);
            materialCard1.Controls.Add(txtDescription);
            materialCard1.Controls.Add(materialLabel8);
            materialCard1.Controls.Add(materialLabel3);
            materialCard1.Controls.Add(txtClient);
            materialCard1.Controls.Add(txtProjectName);
            materialCard1.Controls.Add(materialLabel1);
            materialCard1.Depth = 0;
            materialCard1.Dock = DockStyle.Fill;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(2, 2);
            materialCard1.Margin = new Padding(20, 23, 20, 23);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(20, 23, 20, 23);
            materialCard1.Size = new Size(1346, 725);
            materialCard1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(dgProjectLines);
            panel1.Controls.Add(dgPager);
            panel1.Location = new Point(21, 168);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1304, 335);
            panel1.TabIndex = 40;
            // 
            // dgProjectLines
            // 
            dgProjectLines.AccessibleName = "Table";
            dgProjectLines.AllowFiltering = true;
            dgProjectLines.AllowTriStateSorting = true;
            dgProjectLines.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgProjectLines.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.Fill;
            gridTextColumn1.AllowFiltering = true;
            gridTextColumn1.AllowTextWrapping = true;
            gridTextColumn1.HeaderText = "Name";
            gridTextColumn1.MappingName = "Name";
            gridTextColumn1.ShowToolTip = true;
            gridTextColumn2.AllowFiltering = true;
            gridTextColumn2.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.ColumnHeader;
            gridTextColumn2.HeaderText = "UOM";
            gridTextColumn2.MappingName = "UOM";
            gridTextColumn2.ShowToolTip = true;
            gridTextColumn3.AllowFiltering = true;
            gridTextColumn3.AllowTextWrapping = true;
            gridTextColumn3.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.ColumnHeader;
            gridTextColumn3.HeaderText = "Category";
            gridTextColumn3.MappingName = "Category";
            gridTextColumn3.ShowToolTip = true;
            gridNumericColumn1.AllowFiltering = true;
            gridNumericColumn1.AllowTextWrapping = true;
            gridNumericColumn1.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.ColumnHeader;
            gridNumericColumn1.FormatMode = Syncfusion.WinForms.Input.Enums.FormatMode.Currency;
            gridNumericColumn1.HeaderText = "Cost";
            gridNumericColumn1.MappingName = "Cost";
            gridNumericColumn1.ShowToolTip = true;
            gridNumericColumn2.AllowFiltering = true;
            gridNumericColumn2.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.ColumnHeader;
            gridNumericColumn2.Format = "N2";
            gridNumericColumn2.HeaderText = "Qty";
            gridNumericColumn2.MappingName = "Qty";
            gridNumericColumn2.ShowToolTip = true;
            gridNumericColumn3.AllowFiltering = true;
            gridNumericColumn3.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.ColumnHeader;
            gridNumericColumn3.Format = "N2";
            gridNumericColumn3.HeaderText = "Actual";
            gridNumericColumn3.MappingName = "ActualQty";
            gridNumericColumn3.ShowToolTip = true;
            gridNumericColumn4.AllowFiltering = true;
            gridNumericColumn4.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.ColumnHeader;
            gridNumericColumn4.Format = "N2";
            gridNumericColumn4.HeaderText = "Remaining";
            gridNumericColumn4.MappingName = "RemainingQty";
            gridNumericColumn4.ShowToolTip = true;
            gridNumericColumn5.AllowFiltering = true;
            gridNumericColumn5.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.ColumnHeader;
            gridNumericColumn5.Format = "N2";
            gridNumericColumn5.FormatMode = Syncfusion.WinForms.Input.Enums.FormatMode.Percent;
            gridNumericColumn5.HeaderText = "%";
            gridNumericColumn5.MappingName = "PercentageQty";
            gridNumericColumn5.ShowToolTip = true;
            gridNumericColumn6.AllowFiltering = true;
            gridNumericColumn6.FormatMode = Syncfusion.WinForms.Input.Enums.FormatMode.Currency;
            gridNumericColumn6.HeaderText = "Amount";
            gridNumericColumn6.MappingName = "Amount";
            gridNumericColumn6.ShowToolTip = true;
            gridNumericColumn7.AllowFiltering = true;
            gridNumericColumn7.FormatMode = Syncfusion.WinForms.Input.Enums.FormatMode.Currency;
            gridNumericColumn7.HeaderText = "Actual";
            gridNumericColumn7.MappingName = "ActualAmount";
            gridNumericColumn7.ShowToolTip = true;
            gridNumericColumn8.AllowFiltering = true;
            gridNumericColumn8.FormatMode = Syncfusion.WinForms.Input.Enums.FormatMode.Currency;
            gridNumericColumn8.HeaderText = "Remaining";
            gridNumericColumn8.MappingName = "RemainingAmount";
            gridNumericColumn8.ShowToolTip = true;
            gridNumericColumn9.AllowFiltering = true;
            gridNumericColumn9.FormatMode = Syncfusion.WinForms.Input.Enums.FormatMode.Percent;
            gridNumericColumn9.HeaderText = "%";
            gridNumericColumn9.MappingName = "PercentageAmount";
            gridNumericColumn9.ShowToolTip = true;
            dgProjectLines.Columns.Add(gridTextColumn1);
            dgProjectLines.Columns.Add(gridTextColumn2);
            dgProjectLines.Columns.Add(gridTextColumn3);
            dgProjectLines.Columns.Add(gridNumericColumn1);
            dgProjectLines.Columns.Add(gridNumericColumn2);
            dgProjectLines.Columns.Add(gridNumericColumn3);
            dgProjectLines.Columns.Add(gridNumericColumn4);
            dgProjectLines.Columns.Add(gridNumericColumn5);
            dgProjectLines.Columns.Add(gridNumericColumn6);
            dgProjectLines.Columns.Add(gridNumericColumn7);
            dgProjectLines.Columns.Add(gridNumericColumn8);
            dgProjectLines.Columns.Add(gridNumericColumn9);
            dgProjectLines.FrozenColumnCount = 1;
            dgProjectLines.Location = new Point(0, 0);
            dgProjectLines.Margin = new Padding(4);
            dgProjectLines.Name = "dgProjectLines";
            dgProjectLines.PreviewRowHeight = 42;
            dgProjectLines.SelectionMode = Syncfusion.WinForms.DataGrid.Enums.GridSelectionMode.Multiple;
            dgProjectLines.ShowToolTip = true;
            dgProjectLines.Size = new Size(1304, 281);
            stackedHeaderRow1.Name = "StackedHeaderRow1";
            stackedColumn1.ChildColumns = "Qty,ActualQty,RemainingQty,PercentageQty";
            stackedColumn1.HeaderText = "Quantity Details";
            stackedColumn2.ChildColumns = "Amount,ActualAmount,RemainingAmount,PercentageAmount";
            stackedColumn2.HeaderText = "Amount Details";
            stackedHeaderRow1.StackedColumns.Add(stackedColumn1);
            stackedHeaderRow1.StackedColumns.Add(stackedColumn2);
            dgProjectLines.StackedHeaderRows.Add(stackedHeaderRow1);
            dgProjectLines.Style.BorderColor = Color.FromArgb(100, 100, 100);
            dgProjectLines.Style.CheckBoxStyle.CheckedBackColor = Color.FromArgb(0, 120, 215);
            dgProjectLines.Style.CheckBoxStyle.CheckedBorderColor = Color.FromArgb(0, 120, 215);
            dgProjectLines.Style.CheckBoxStyle.IndeterminateBorderColor = Color.FromArgb(0, 120, 215);
            dgProjectLines.Style.HyperlinkStyle.DefaultLinkColor = Color.FromArgb(0, 120, 215);
            dgProjectLines.TabIndex = 7;
            dgProjectLines.Text = "sfDataGrid1";
            // 
            // dgPager
            // 
            dgPager.AccessibleName = "DataPager";
            dgPager.CanOverrideStyle = true;
            dgPager.Dock = DockStyle.Bottom;
            dgPager.HorizontalAlignment = HorizontalAlignment.Center;
            dgPager.Location = new Point(0, 281);
            dgPager.Margin = new Padding(4);
            dgPager.Name = "dgPager";
            dgPager.PageSize = 15;
            dgPager.Size = new Size(1304, 54);
            dgPager.TabIndex = 8;
            dgPager.Text = "sfDataPager1";
            // 
            // materialLabel2
            // 
            materialLabel2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.Location = new Point(791, 582);
            materialLabel2.Margin = new Padding(4, 0, 4, 0);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(151, 19);
            materialLabel2.TabIndex = 39;
            materialLabel2.Text = "Total Actual Amount:";
            // 
            // txtActualAmount
            // 
            txtActualAmount.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            txtActualAmount.AutoSize = true;
            txtActualAmount.Depth = 0;
            txtActualAmount.Font = new Font("Roboto Medium", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            txtActualAmount.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle2;
            txtActualAmount.Location = new Point(1043, 586);
            txtActualAmount.Margin = new Padding(4, 0, 4, 0);
            txtActualAmount.MouseState = MaterialSkin.MouseState.HOVER;
            txtActualAmount.Name = "txtActualAmount";
            txtActualAmount.Size = new Size(136, 17);
            txtActualAmount.TabIndex = 38;
            txtActualAmount.Text = "Total Actual Amount:";
            // 
            // materialLabel9
            // 
            materialLabel9.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            materialLabel9.AutoSize = true;
            materialLabel9.Depth = 0;
            materialLabel9.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel9.Location = new Point(791, 648);
            materialLabel9.Margin = new Padding(4, 0, 4, 0);
            materialLabel9.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel9.Name = "materialLabel9";
            materialLabel9.Size = new Size(67, 19);
            materialLabel9.TabIndex = 37;
            materialLabel9.Text = "Variance:";
            // 
            // txtVariance
            // 
            txtVariance.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            txtVariance.AutoSize = true;
            txtVariance.Depth = 0;
            txtVariance.Font = new Font("Roboto Medium", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            txtVariance.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle2;
            txtVariance.Location = new Point(1043, 648);
            txtVariance.Margin = new Padding(4, 0, 4, 0);
            txtVariance.MouseState = MaterialSkin.MouseState.HOVER;
            txtVariance.Name = "txtVariance";
            txtVariance.Size = new Size(62, 17);
            txtVariance.TabIndex = 36;
            txtVariance.Text = "Variance:";
            // 
            // materialLabel7
            // 
            materialLabel7.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            materialLabel7.AutoSize = true;
            materialLabel7.Depth = 0;
            materialLabel7.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel7.Location = new Point(791, 681);
            materialLabel7.Margin = new Padding(4, 0, 4, 0);
            materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel7.Name = "materialLabel7";
            materialLabel7.Size = new Size(106, 19);
            materialLabel7.TabIndex = 35;
            materialLabel7.Text = "Total Revenue:";
            // 
            // txtTotalRevenue
            // 
            txtTotalRevenue.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            txtTotalRevenue.AutoSize = true;
            txtTotalRevenue.Depth = 0;
            txtTotalRevenue.Font = new Font("Roboto Medium", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            txtTotalRevenue.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle2;
            txtTotalRevenue.Location = new Point(1043, 679);
            txtTotalRevenue.Margin = new Padding(4, 0, 4, 0);
            txtTotalRevenue.MouseState = MaterialSkin.MouseState.HOVER;
            txtTotalRevenue.Name = "txtTotalRevenue";
            txtTotalRevenue.Size = new Size(98, 17);
            txtTotalRevenue.TabIndex = 34;
            txtTotalRevenue.Text = "Total Revenue:";
            // 
            // guna2Separator3
            // 
            guna2Separator3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            guna2Separator3.Location = new Point(16, 512);
            guna2Separator3.Margin = new Padding(4, 5, 4, 5);
            guna2Separator3.Name = "guna2Separator3";
            guna2Separator3.Size = new Size(1304, 17);
            guna2Separator3.TabIndex = 33;
            // 
            // materialLabel6
            // 
            materialLabel6.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            materialLabel6.AutoSize = true;
            materialLabel6.Depth = 0;
            materialLabel6.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel6.Location = new Point(791, 615);
            materialLabel6.Margin = new Padding(4, 0, 4, 0);
            materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel6.Name = "materialLabel6";
            materialLabel6.Size = new Size(118, 19);
            materialLabel6.TabIndex = 32;
            materialLabel6.Text = "Total Deduction:";
            // 
            // txtDeduction
            // 
            txtDeduction.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            txtDeduction.AutoSize = true;
            txtDeduction.Depth = 0;
            txtDeduction.Font = new Font("Roboto Medium", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            txtDeduction.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle2;
            txtDeduction.Location = new Point(1043, 617);
            txtDeduction.Margin = new Padding(4, 0, 4, 0);
            txtDeduction.MouseState = MaterialSkin.MouseState.HOVER;
            txtDeduction.Name = "txtDeduction";
            txtDeduction.Size = new Size(107, 17);
            txtDeduction.TabIndex = 31;
            txtDeduction.Text = "Total Deduction:";
            // 
            // materialLabel4
            // 
            materialLabel4.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            materialLabel4.AutoSize = true;
            materialLabel4.Depth = 0;
            materialLabel4.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel4.Location = new Point(791, 553);
            materialLabel4.Margin = new Padding(4, 0, 4, 0);
            materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel4.Name = "materialLabel4";
            materialLabel4.Size = new Size(95, 19);
            materialLabel4.TabIndex = 30;
            materialLabel4.Text = "Total Payroll:";
            // 
            // txtPayroll
            // 
            txtPayroll.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            txtPayroll.AutoSize = true;
            txtPayroll.Depth = 0;
            txtPayroll.Font = new Font("Roboto Medium", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            txtPayroll.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle2;
            txtPayroll.Location = new Point(1043, 555);
            txtPayroll.Margin = new Padding(4, 0, 4, 0);
            txtPayroll.MouseState = MaterialSkin.MouseState.HOVER;
            txtPayroll.Name = "txtPayroll";
            txtPayroll.Size = new Size(87, 17);
            txtPayroll.TabIndex = 29;
            txtPayroll.Text = "Total Payroll:";
            // 
            // guna2Separator1
            // 
            guna2Separator1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            guna2Separator1.Location = new Point(24, 142);
            guna2Separator1.Margin = new Padding(4, 5, 4, 5);
            guna2Separator1.Name = "guna2Separator1";
            guna2Separator1.Size = new Size(1300, 17);
            guna2Separator1.TabIndex = 20;
            // 
            // materialLabel15
            // 
            materialLabel15.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            materialLabel15.AutoSize = true;
            materialLabel15.Depth = 0;
            materialLabel15.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel15.Location = new Point(800, 56);
            materialLabel15.Margin = new Padding(4, 0, 4, 0);
            materialLabel15.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel15.Name = "materialLabel15";
            materialLabel15.Size = new Size(103, 19);
            materialLabel15.TabIndex = 17;
            materialLabel15.Text = "Bidding Value:";
            // 
            // txtBudget
            // 
            txtBudget.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtBudget.AutoSize = true;
            txtBudget.Depth = 0;
            txtBudget.Font = new Font("Roboto Medium", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            txtBudget.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle2;
            txtBudget.Location = new Point(1044, 58);
            txtBudget.Margin = new Padding(4, 0, 4, 0);
            txtBudget.MouseState = MaterialSkin.MouseState.HOVER;
            txtBudget.Name = "txtBudget";
            txtBudget.Size = new Size(94, 17);
            txtBudget.TabIndex = 16;
            txtBudget.Text = "Bidding Value:";
            // 
            // txtEndDate
            // 
            txtEndDate.AutoSize = true;
            txtEndDate.Depth = 0;
            txtEndDate.Font = new Font("Roboto Medium", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            txtEndDate.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle2;
            txtEndDate.Location = new Point(234, 120);
            txtEndDate.Margin = new Padding(4, 0, 4, 0);
            txtEndDate.MouseState = MaterialSkin.MouseState.HOVER;
            txtEndDate.Name = "txtEndDate";
            txtEndDate.Size = new Size(62, 17);
            txtEndDate.TabIndex = 15;
            txtEndDate.Text = "End Date:";
            // 
            // materialLabel10
            // 
            materialLabel10.AutoSize = true;
            materialLabel10.Depth = 0;
            materialLabel10.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel10.Location = new Point(20, 116);
            materialLabel10.Margin = new Padding(4, 0, 4, 0);
            materialLabel10.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel10.Name = "materialLabel10";
            materialLabel10.Size = new Size(69, 19);
            materialLabel10.TabIndex = 14;
            materialLabel10.Text = "End Date:";
            // 
            // txtStartDate
            // 
            txtStartDate.AutoSize = true;
            txtStartDate.Depth = 0;
            txtStartDate.Font = new Font("Roboto Medium", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            txtStartDate.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle2;
            txtStartDate.Location = new Point(234, 89);
            txtStartDate.Margin = new Padding(4, 0, 4, 0);
            txtStartDate.MouseState = MaterialSkin.MouseState.HOVER;
            txtStartDate.Name = "txtStartDate";
            txtStartDate.Size = new Size(69, 17);
            txtStartDate.TabIndex = 13;
            txtStartDate.Text = "Start Date:";
            // 
            // materialLabel12
            // 
            materialLabel12.AutoSize = true;
            materialLabel12.Depth = 0;
            materialLabel12.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel12.Location = new Point(20, 85);
            materialLabel12.Margin = new Padding(4, 0, 4, 0);
            materialLabel12.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel12.Name = "materialLabel12";
            materialLabel12.Size = new Size(76, 19);
            materialLabel12.TabIndex = 12;
            materialLabel12.Text = "Start Date:";
            // 
            // materialLabel5
            // 
            materialLabel5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            materialLabel5.AutoSize = true;
            materialLabel5.Depth = 0;
            materialLabel5.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel5.Location = new Point(800, 89);
            materialLabel5.Margin = new Padding(4, 0, 4, 0);
            materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel5.Name = "materialLabel5";
            materialLabel5.Size = new Size(115, 19);
            materialLabel5.TabIndex = 11;
            materialLabel5.Text = "Target Revenue:";
            // 
            // txtRevenue
            // 
            txtRevenue.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtRevenue.AutoSize = true;
            txtRevenue.Depth = 0;
            txtRevenue.Font = new Font("Roboto Medium", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            txtRevenue.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle2;
            txtRevenue.Location = new Point(1044, 89);
            txtRevenue.Margin = new Padding(4, 0, 4, 0);
            txtRevenue.MouseState = MaterialSkin.MouseState.HOVER;
            txtRevenue.Name = "txtRevenue";
            txtRevenue.Size = new Size(61, 17);
            txtRevenue.TabIndex = 10;
            txtRevenue.Text = "Revenue:";
            // 
            // txtDescription
            // 
            txtDescription.AutoSize = true;
            txtDescription.Depth = 0;
            txtDescription.Font = new Font("Roboto Medium", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            txtDescription.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle2;
            txtDescription.Location = new Point(234, 58);
            txtDescription.Margin = new Padding(4, 0, 4, 0);
            txtDescription.MouseState = MaterialSkin.MouseState.HOVER;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(78, 17);
            txtDescription.TabIndex = 9;
            txtDescription.Text = "Description:";
            // 
            // materialLabel8
            // 
            materialLabel8.AutoSize = true;
            materialLabel8.Depth = 0;
            materialLabel8.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel8.Location = new Point(20, 54);
            materialLabel8.Margin = new Padding(4, 0, 4, 0);
            materialLabel8.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel8.Name = "materialLabel8";
            materialLabel8.Size = new Size(85, 19);
            materialLabel8.TabIndex = 8;
            materialLabel8.Text = "Description:";
            // 
            // materialLabel3
            // 
            materialLabel3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            materialLabel3.AutoSize = true;
            materialLabel3.Depth = 0;
            materialLabel3.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel3.Location = new Point(800, 23);
            materialLabel3.Margin = new Padding(4, 0, 4, 0);
            materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel3.Name = "materialLabel3";
            materialLabel3.Size = new Size(45, 19);
            materialLabel3.TabIndex = 7;
            materialLabel3.Text = "Client:";
            // 
            // txtClient
            // 
            txtClient.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtClient.AutoSize = true;
            txtClient.Depth = 0;
            txtClient.Font = new Font("Roboto Medium", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            txtClient.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle2;
            txtClient.Location = new Point(1044, 27);
            txtClient.Margin = new Padding(4, 0, 4, 0);
            txtClient.MouseState = MaterialSkin.MouseState.HOVER;
            txtClient.Name = "txtClient";
            txtClient.Size = new Size(43, 17);
            txtClient.TabIndex = 6;
            txtClient.Text = "Client:";
            // 
            // txtProjectName
            // 
            txtProjectName.AutoSize = true;
            txtProjectName.Depth = 0;
            txtProjectName.Font = new Font("Roboto Medium", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            txtProjectName.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle2;
            txtProjectName.Location = new Point(234, 27);
            txtProjectName.Margin = new Padding(4, 0, 4, 0);
            txtProjectName.MouseState = MaterialSkin.MouseState.HOVER;
            txtProjectName.Name = "txtProjectName";
            txtProjectName.Size = new Size(43, 17);
            txtProjectName.TabIndex = 5;
            txtProjectName.Text = "Name:";
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(20, 23);
            materialLabel1.Margin = new Padding(4, 0, 4, 0);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(47, 19);
            materialLabel1.TabIndex = 4;
            materialLabel1.Text = "Name:";
            // 
            // ProjectInformationView
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1350, 729);
            Controls.Add(materialCard1);
            Margin = new Padding(4, 5, 4, 5);
            Name = "ProjectInformationView";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Style.MdiChild.IconHorizontalAlignment = HorizontalAlignment.Center;
            Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            Text = "Project Information (#: )";
            materialCard1.ResumeLayout(false);
            materialCard1.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgProjectLines).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialCard materialCard1;
        private MaterialSkin.Controls.MaterialLabel txtEndDate;
        private MaterialSkin.Controls.MaterialLabel materialLabel10;
        private MaterialSkin.Controls.MaterialLabel txtStartDate;
        private MaterialSkin.Controls.MaterialLabel materialLabel12;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialLabel txtRevenue;
        private MaterialSkin.Controls.MaterialLabel txtDescription;
        private MaterialSkin.Controls.MaterialLabel materialLabel8;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel txtClient;
        private MaterialSkin.Controls.MaterialLabel txtProjectName;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private MaterialSkin.Controls.MaterialLabel materialLabel15;
        private MaterialSkin.Controls.MaterialLabel txtBudget;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialLabel txtPayroll;
        private MaterialSkin.Controls.MaterialLabel materialLabel7;
        private MaterialSkin.Controls.MaterialLabel txtTotalRevenue;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator3;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private MaterialSkin.Controls.MaterialLabel txtDeduction;
        private MaterialSkin.Controls.MaterialLabel materialLabel9;
        private MaterialSkin.Controls.MaterialLabel txtVariance;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel txtActualAmount;
        private Panel panel1;
        private Syncfusion.WinForms.DataGrid.SfDataGrid dgProjectLines;
        private Syncfusion.WinForms.DataPager.SfDataPager dgPager;
    }
}