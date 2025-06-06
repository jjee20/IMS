﻿namespace RavenTech_ERP.Views.UserControls.Accounting.Payroll
{
    partial class IndividualAttendanceView
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
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn1 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn2 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridDateTimeColumn gridDateTimeColumn1 = new Syncfusion.WinForms.DataGrid.GridDateTimeColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn3 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn4 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn5 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn6 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridImageColumn gridImageColumn1 = new Syncfusion.WinForms.DataGrid.GridImageColumn();
            Syncfusion.WinForms.DataGrid.GridImageColumn gridImageColumn2 = new Syncfusion.WinForms.DataGrid.GridImageColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IndividualAttendanceView));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            materialCard4 = new MaterialSkin.Controls.MaterialCard();
            panel1 = new Panel();
            dgList = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            dgPager = new Syncfusion.WinForms.DataPager.SfDataPager();
            panel2 = new Panel();
            btnPrint = new Guna.UI2.WinForms.Guna2ImageButton();
            autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtStartDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
            txtEndDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
            btnAdd = new Syncfusion.WinForms.Controls.SfButton();
            txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            materialCard4.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgList).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // materialCard4
            // 
            materialCard4.BackColor = Color.FromArgb(255, 255, 255);
            materialCard4.Controls.Add(panel1);
            materialCard4.Depth = 0;
            materialCard4.Dock = DockStyle.Fill;
            materialCard4.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard4.Location = new Point(3, 106);
            materialCard4.Margin = new Padding(20, 23, 20, 23);
            materialCard4.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard4.Name = "materialCard4";
            materialCard4.Padding = new Padding(20, 23, 20, 23);
            materialCard4.Size = new Size(1344, 620);
            materialCard4.TabIndex = 12;
            // 
            // panel1
            // 
            panel1.Controls.Add(dgList);
            panel1.Controls.Add(dgPager);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(20, 23);
            panel1.Margin = new Padding(4, 5, 4, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(1304, 574);
            panel1.TabIndex = 1;
            // 
            // dgList
            // 
            dgList.AccessibleName = "Table";
            dgList.AllowFiltering = true;
            dgList.AllowTriStateSorting = true;
            dgList.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.Fill;
            gridTextColumn1.AllowFiltering = true;
            gridTextColumn1.HeaderText = "Id";
            gridTextColumn1.MappingName = "AttendanceId";
            gridTextColumn1.MaximumWidth = 100D;
            gridTextColumn1.MinimumWidth = 100D;
            gridTextColumn1.ShowToolTip = true;
            gridTextColumn1.Visible = false;
            gridTextColumn1.Width = 100D;
            gridTextColumn2.AllowFiltering = true;
            gridTextColumn2.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.Fill;
            gridTextColumn2.HeaderText = "Project";
            gridTextColumn2.MappingName = "Project";
            gridTextColumn2.ShowToolTip = true;
            gridDateTimeColumn1.AllowFiltering = true;
            gridDateTimeColumn1.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.Fill;
            gridDateTimeColumn1.Format = "MMMM dd, yyyy";
            gridDateTimeColumn1.HeaderText = "Date";
            gridDateTimeColumn1.MappingName = "Date";
            gridDateTimeColumn1.MaxDateTime = new DateTime(9999, 12, 31, 23, 59, 59, 999);
            gridDateTimeColumn1.ShowToolTip = true;
            gridTextColumn3.AllowFiltering = true;
            gridTextColumn3.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.ColumnHeader;
            gridTextColumn3.HeaderText = "Timein";
            gridTextColumn3.MappingName = "TimeIn";
            gridTextColumn3.ShowToolTip = true;
            gridTextColumn4.AllowFiltering = true;
            gridTextColumn4.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.ColumnHeader;
            gridTextColumn4.HeaderText = "Timeout";
            gridTextColumn4.MappingName = "TimeOut";
            gridTextColumn4.ShowToolTip = true;
            gridTextColumn5.AllowFiltering = true;
            gridTextColumn5.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.ColumnHeader;
            gridTextColumn5.HeaderText = "Hours Worked";
            gridTextColumn5.MappingName = "HoursWorked";
            gridTextColumn5.ShowToolTip = true;
            gridTextColumn6.AllowFiltering = true;
            gridTextColumn6.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.ColumnHeader;
            gridTextColumn6.HeaderText = "Status";
            gridTextColumn6.MappingName = "Status";
            gridTextColumn6.ShowToolTip = true;
            gridImageColumn1.AllowEditing = false;
            gridImageColumn1.AllowGrouping = false;
            gridImageColumn1.AllowSorting = false;
            gridImageColumn1.HeaderStyle.HoverTextColor = Color.White;
            gridImageColumn1.HeaderStyle.PressedTextColor = Color.White;
            gridImageColumn1.HeaderStyle.TextColor = Color.White;
            gridImageColumn1.HeaderText = "Edit";
            gridImageColumn1.ImageLayout = ImageLayout.Zoom;
            gridImageColumn1.MappingName = "Edit";
            gridImageColumn1.MaximumWidth = 30D;
            gridImageColumn1.MinimumWidth = 30D;
            gridImageColumn1.ShowToolTip = true;
            gridImageColumn1.Width = 30D;
            gridImageColumn2.AllowGrouping = false;
            gridImageColumn2.AllowSorting = false;
            gridImageColumn2.HeaderText = " ";
            gridImageColumn2.MappingName = "Delete";
            gridImageColumn2.MaximumWidth = 30D;
            gridImageColumn2.MinimumWidth = 30D;
            gridImageColumn2.ShowToolTip = true;
            gridImageColumn2.Width = 30D;
            dgList.Columns.Add(gridTextColumn1);
            dgList.Columns.Add(gridTextColumn2);
            dgList.Columns.Add(gridDateTimeColumn1);
            dgList.Columns.Add(gridTextColumn3);
            dgList.Columns.Add(gridTextColumn4);
            dgList.Columns.Add(gridTextColumn5);
            dgList.Columns.Add(gridTextColumn6);
            dgList.Columns.Add(gridImageColumn1);
            dgList.Columns.Add(gridImageColumn2);
            dgList.Dock = DockStyle.Fill;
            dgList.FrozenColumnCount = 2;
            dgList.FrozenRowCount = 1;
            dgList.Location = new Point(0, 0);
            dgList.Margin = new Padding(4, 5, 4, 5);
            dgList.Name = "dgList";
            dgList.PreviewRowHeight = 42;
            dgList.SelectionMode = Syncfusion.WinForms.DataGrid.Enums.GridSelectionMode.Multiple;
            dgList.ShowGroupDropArea = true;
            dgList.ShowToolTip = true;
            dgList.Size = new Size(1304, 514);
            dgList.Style.BorderColor = Color.FromArgb(100, 100, 100);
            dgList.Style.CheckBoxStyle.CheckedBackColor = Color.FromArgb(0, 120, 215);
            dgList.Style.CheckBoxStyle.CheckedBorderColor = Color.FromArgb(0, 120, 215);
            dgList.Style.CheckBoxStyle.IndeterminateBorderColor = Color.FromArgb(0, 120, 215);
            dgList.Style.HyperlinkStyle.DefaultLinkColor = Color.FromArgb(0, 120, 215);
            dgList.TabIndex = 9;
            dgList.Text = "sfDataGrid1";
            dgList.CellClick += dgList_CellClick;
            // 
            // dgPager
            // 
            dgPager.AccessibleName = "DataPager";
            dgPager.CanOverrideStyle = true;
            dgPager.Dock = DockStyle.Bottom;
            dgPager.HorizontalAlignment = HorizontalAlignment.Center;
            dgPager.Location = new Point(0, 514);
            dgPager.Margin = new Padding(4, 5, 4, 5);
            dgPager.Name = "dgPager";
            dgPager.PageSize = 15;
            dgPager.Size = new Size(1304, 60);
            dgPager.TabIndex = 8;
            dgPager.Text = "sfDataPager1";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(btnPrint);
            panel2.Controls.Add(autoLabel2);
            panel2.Controls.Add(autoLabel1);
            panel2.Controls.Add(txtStartDate);
            panel2.Controls.Add(txtEndDate);
            panel2.Controls.Add(btnAdd);
            panel2.Controls.Add(txtSearch);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(3, 3);
            panel2.Margin = new Padding(4, 22, 4, 7);
            panel2.Name = "panel2";
            panel2.Size = new Size(1344, 103);
            panel2.TabIndex = 11;
            // 
            // btnPrint
            // 
            btnPrint.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            btnPrint.CheckedState.ImageSize = new Size(64, 64);
            btnPrint.HoverState.ImageSize = new Size(64, 64);
            btnPrint.Image = (Image)resources.GetObject("btnPrint.Image");
            btnPrint.ImageOffset = new Point(0, 0);
            btnPrint.ImageRotate = 0F;
            btnPrint.ImageSize = new Size(30, 30);
            btnPrint.Location = new Point(1267, 15);
            btnPrint.Margin = new Padding(4, 5, 4, 5);
            btnPrint.Name = "btnPrint";
            btnPrint.PressedState.ImageSize = new Size(64, 64);
            btnPrint.ShadowDecoration.CustomizableEdges = customizableEdges1;
            btnPrint.Size = new Size(57, 67);
            btnPrint.TabIndex = 31;
            btnPrint.Click += btnPrint_Click;
            // 
            // autoLabel2
            // 
            autoLabel2.Location = new Point(831, 38);
            autoLabel2.Margin = new Padding(4, 0, 4, 0);
            autoLabel2.Name = "autoLabel2";
            autoLabel2.Size = new Size(54, 25);
            autoLabel2.TabIndex = 30;
            autoLabel2.Text = "From";
            // 
            // autoLabel1
            // 
            autoLabel1.Location = new Point(1052, 38);
            autoLabel1.Margin = new Padding(4, 0, 4, 0);
            autoLabel1.Name = "autoLabel1";
            autoLabel1.Size = new Size(29, 25);
            autoLabel1.TabIndex = 29;
            autoLabel1.Text = "to";
            // 
            // txtStartDate
            // 
            txtStartDate.DateTimeIcon = null;
            txtStartDate.Location = new Point(889, 18);
            txtStartDate.Margin = new Padding(4, 5, 4, 5);
            txtStartDate.Name = "txtStartDate";
            txtStartDate.Size = new Size(154, 65);
            txtStartDate.TabIndex = 28;
            txtStartDate.ToolTipText = "";
            txtStartDate.TextChanged += txtStartDate_TextChanged;
            // 
            // txtEndDate
            // 
            txtEndDate.DateTimeIcon = null;
            txtEndDate.Location = new Point(1087, 18);
            txtEndDate.Margin = new Padding(4, 5, 4, 5);
            txtEndDate.Name = "txtEndDate";
            txtEndDate.Size = new Size(154, 65);
            txtEndDate.TabIndex = 27;
            txtEndDate.ToolTipText = "";
            txtEndDate.TextChanged += txtEndDate_TextChanged;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.AliceBlue;
            btnAdd.Font = new Font("Segoe UI Semibold", 9F);
            btnAdd.ForeColor = Color.Black;
            btnAdd.ImageMargin = new Padding(5, 3, 3, 3);
            btnAdd.Location = new Point(21, 17);
            btnAdd.Margin = new Padding(4, 5, 4, 5);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(136, 65);
            btnAdd.Style.BackColor = Color.AliceBlue;
            btnAdd.Style.ForeColor = Color.Black;
            btnAdd.Style.Image = (Image)resources.GetObject("resource.Image");
            btnAdd.TabIndex = 25;
            btnAdd.Text = "Add New";
            btnAdd.TextMargin = new Padding(7, 3, 3, 3);
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            txtSearch.CharacterCasing = CharacterCasing.Upper;
            txtSearch.CustomizableEdges = customizableEdges2;
            txtSearch.DefaultText = "";
            txtSearch.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtSearch.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtSearch.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtSearch.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtSearch.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtSearch.Font = new Font("Segoe UI", 9F);
            txtSearch.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtSearch.IconRight = (Image)resources.GetObject("txtSearch.IconRight");
            txtSearch.Location = new Point(2486, 17);
            txtSearch.Margin = new Padding(4, 7, 4, 7);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search here";
            txtSearch.SelectedText = "";
            txtSearch.ShadowDecoration.CustomizableEdges = customizableEdges3;
            txtSearch.Size = new Size(410, 2);
            txtSearch.TabIndex = 11;
            // 
            // IndividualAttendanceView
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1350, 729);
            Controls.Add(materialCard4);
            Controls.Add(panel2);
            KeyPreview = true;
            Margin = new Padding(4, 5, 4, 5);
            Name = "IndividualAttendanceView";
            StartPosition = FormStartPosition.CenterScreen;
            Style.MdiChild.IconHorizontalAlignment = HorizontalAlignment.Center;
            Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            Text = "Attendance";
            KeyDown += IndividualAttendanceView_KeyDown;
            materialCard4.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgList).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialCard materialCard4;
        private Panel panel1;
        private Syncfusion.WinForms.DataGrid.SfDataGrid dgList;
        private Syncfusion.WinForms.DataPager.SfDataPager dgPager;
        private Panel panel2;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.WinForms.Input.SfDateTimeEdit txtStartDate;
        private Syncfusion.WinForms.Input.SfDateTimeEdit txtEndDate;
        private Syncfusion.WinForms.Controls.SfButton btnAdd;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2ImageButton btnPrint;
    }
}