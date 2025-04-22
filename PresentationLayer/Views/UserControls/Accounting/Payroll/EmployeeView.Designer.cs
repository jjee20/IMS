using Guna.UI2.WinForms;

namespace PresentationLayer.Views.UserControls
{
    partial class EmployeeView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeView));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn14 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn15 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn16 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn17 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn18 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn19 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn20 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn21 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn22 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn23 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn24 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn25 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn26 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridImageColumn gridImageColumn4 = new Syncfusion.WinForms.DataGrid.GridImageColumn();
            Syncfusion.WinForms.DataGrid.GridImageColumn gridImageColumn5 = new Syncfusion.WinForms.DataGrid.GridImageColumn();
            Syncfusion.WinForms.DataGrid.GridImageColumn gridImageColumn6 = new Syncfusion.WinForms.DataGrid.GridImageColumn();
            panel2 = new Panel();
            btnPrint = new Guna2ImageButton();
            btnAdd = new Syncfusion.WinForms.Controls.SfButton();
            txtSearch = new Guna2TextBox();
            toolstripitemExcel = new Syncfusion.Windows.Forms.Tools.toolstripitem();
            toolstripitemPDF = new Syncfusion.Windows.Forms.Tools.toolstripitem();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            guna2Separator1 = new Guna2Separator();
            materialCard4 = new MaterialSkin.Controls.MaterialCard();
            panel1 = new Panel();
            dgList = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            dgPager = new Syncfusion.WinForms.DataPager.SfDataPager();
            panel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            materialCard4.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgList).BeginInit();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(btnPrint);
            panel2.Controls.Add(btnAdd);
            panel2.Controls.Add(txtSearch);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(2, 55);
            panel2.Margin = new Padding(3, 13, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(1346, 62);
            panel2.TabIndex = 9;
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
            btnPrint.Location = new Point(1292, 10);
            btnPrint.Name = "btnPrint";
            btnPrint.PressedState.ImageSize = new Size(64, 64);
            btnPrint.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnPrint.Size = new Size(40, 40);
            btnPrint.TabIndex = 26;
            btnPrint.Click += btnPrint_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.AliceBlue;
            btnAdd.Font = new Font("Segoe UI Semibold", 9F);
            btnAdd.ForeColor = Color.Black;
            btnAdd.ImageMargin = new Padding(5, 3, 3, 3);
            btnAdd.Location = new Point(15, 10);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(95, 39);
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
            txtSearch.CustomizableEdges = customizableEdges5;
            txtSearch.DefaultText = "";
            txtSearch.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtSearch.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtSearch.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtSearch.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtSearch.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtSearch.Font = new Font("Segoe UI", 9F);
            txtSearch.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtSearch.IconRight = (Image)resources.GetObject("txtSearch.IconRight");
            txtSearch.Location = new Point(999, 10);
            txtSearch.Margin = new Padding(3, 4, 3, 4);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search here";
            txtSearch.SelectedText = "";
            txtSearch.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtSearch.Size = new Size(287, 39);
            txtSearch.TabIndex = 11;
            txtSearch.KeyDown += txtSearch_KeyDown;
            // 
            // toolstripitemExcel
            // 
            toolstripitemExcel.Image = (Image)resources.GetObject("toolstripitemExcel.Image");
            toolstripitemExcel.Name = "toolstripitemExcel";
            toolstripitemExcel.Size = new Size(32, 19);
            toolstripitemExcel.Text = "Export Excel";
            // 
            // toolstripitemPDF
            // 
            toolstripitemPDF.Image = (Image)resources.GetObject("toolstripitemPDF.Image");
            toolstripitemPDF.Name = "toolstripitemPDF";
            toolstripitemPDF.Size = new Size(32, 19);
            toolstripitemPDF.Text = "Export PDF";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Controls.Add(guna2Separator1, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(2, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 76F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 24F));
            tableLayoutPanel1.Size = new Size(1346, 53);
            tableLayoutPanel1.TabIndex = 8;
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
            tableLayoutPanel2.Size = new Size(1346, 40);
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
            materialLabel1.Size = new Size(1306, 40);
            materialLabel1.TabIndex = 3;
            materialLabel1.Text = "Employee Management";
            materialLabel1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // guna2Separator1
            // 
            guna2Separator1.Dock = DockStyle.Fill;
            guna2Separator1.Location = new Point(3, 42);
            guna2Separator1.Margin = new Padding(3, 2, 3, 2);
            guna2Separator1.Name = "guna2Separator1";
            guna2Separator1.Size = new Size(1340, 9);
            guna2Separator1.TabIndex = 1;
            // 
            // materialCard4
            // 
            materialCard4.BackColor = Color.FromArgb(255, 255, 255);
            materialCard4.Controls.Add(panel1);
            materialCard4.Depth = 0;
            materialCard4.Dock = DockStyle.Fill;
            materialCard4.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard4.Location = new Point(2, 117);
            materialCard4.Margin = new Padding(14);
            materialCard4.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard4.Name = "materialCard4";
            materialCard4.Padding = new Padding(14);
            materialCard4.Size = new Size(1346, 610);
            materialCard4.TabIndex = 10;
            // 
            // panel1
            // 
            panel1.Controls.Add(dgList);
            panel1.Controls.Add(dgPager);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(14, 14);
            panel1.Name = "panel1";
            panel1.Size = new Size(1318, 582);
            panel1.TabIndex = 1;
            // 
            // dgList
            // 
            dgList.AccessibleName = "Table";
            dgList.AllowFiltering = true;
            dgList.AllowTriStateSorting = true;
            dgList.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.Fill;
            gridTextColumn14.AllowFiltering = true;
            gridTextColumn14.HeaderText = "Id";
            gridTextColumn14.MappingName = "EmployeeId";
            gridTextColumn14.MaximumWidth = 100D;
            gridTextColumn14.MinimumWidth = 100D;
            gridTextColumn14.Visible = false;
            gridTextColumn14.Width = 100D;
            gridTextColumn15.AllowFiltering = true;
            gridTextColumn15.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.Fill;
            gridTextColumn15.HeaderText = "Name";
            gridTextColumn15.MappingName = "Name";
            gridTextColumn16.AllowFiltering = true;
            gridTextColumn16.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.ColumnHeader;
            gridTextColumn16.HeaderText = "Gender";
            gridTextColumn16.MappingName = "Gender";
            gridTextColumn17.AllowFiltering = true;
            gridTextColumn17.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.ColumnHeader;
            gridTextColumn17.Format = "MMMM d, yyyy";
            gridTextColumn17.HeaderText = "Birth Date";
            gridTextColumn17.MappingName = "DateOfBirth";
            gridTextColumn18.AllowFiltering = true;
            gridTextColumn18.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.ColumnHeader;
            gridTextColumn18.HeaderText = "Contact Number";
            gridTextColumn18.MappingName = "ContactNumber";
            gridTextColumn19.AllowFiltering = true;
            gridTextColumn19.HeaderText = "Email";
            gridTextColumn19.MappingName = "Email";
            gridTextColumn20.AllowFiltering = true;
            gridTextColumn20.HeaderText = "Basic Salary";
            gridTextColumn20.MappingName = "BasicSalary";
            gridTextColumn21.AllowFiltering = true;
            gridTextColumn21.HeaderText = "Leave Credits";
            gridTextColumn21.MappingName = "LeaveCredits";
            gridTextColumn22.AllowFiltering = true;
            gridTextColumn22.HeaderText = "Address";
            gridTextColumn22.MappingName = "Address";
            gridTextColumn23.AllowFiltering = true;
            gridTextColumn23.HeaderText = "Department";
            gridTextColumn23.MappingName = "Department";
            gridTextColumn24.AllowFiltering = true;
            gridTextColumn24.HeaderText = "Job Position";
            gridTextColumn24.MappingName = "JobPosition";
            gridTextColumn25.AllowFiltering = true;
            gridTextColumn25.HeaderText = "Shift";
            gridTextColumn25.MappingName = "Shift";
            gridTextColumn26.AllowFiltering = true;
            gridTextColumn26.HeaderText = "Is Deducted?";
            gridTextColumn26.MappingName = "isDeducted";
            gridImageColumn4.AllowEditing = false;
            gridImageColumn4.AllowGrouping = false;
            gridImageColumn4.AllowSorting = false;
            gridImageColumn4.HeaderStyle.HoverTextColor = Color.White;
            gridImageColumn4.HeaderStyle.PressedTextColor = Color.White;
            gridImageColumn4.HeaderStyle.TextColor = Color.White;
            gridImageColumn4.HeaderText = "Edit";
            gridImageColumn4.ImageLayout = ImageLayout.Zoom;
            gridImageColumn4.MappingName = "Edit";
            gridImageColumn4.MaximumWidth = 30D;
            gridImageColumn4.MinimumWidth = 30D;
            gridImageColumn4.Width = 30D;
            gridImageColumn5.AllowEditing = false;
            gridImageColumn5.AllowGrouping = false;
            gridImageColumn5.AllowSorting = false;
            gridImageColumn5.HeaderStyle.HoverTextColor = Color.White;
            gridImageColumn5.HeaderStyle.PressedTextColor = Color.White;
            gridImageColumn5.HeaderStyle.TextColor = Color.White;
            gridImageColumn5.HeaderText = "Delete";
            gridImageColumn5.ImageLayout = ImageLayout.Zoom;
            gridImageColumn5.MappingName = "Delete";
            gridImageColumn5.MaximumWidth = 30D;
            gridImageColumn5.MinimumWidth = 30D;
            gridImageColumn5.ShowFilterRowOptions = false;
            gridImageColumn5.Width = 30D;
            gridImageColumn6.AllowGrouping = false;
            gridImageColumn6.AllowSorting = false;
            gridImageColumn6.HeaderText = " ";
            gridImageColumn6.MappingName = "Details";
            gridImageColumn6.MaximumWidth = 30D;
            gridImageColumn6.MinimumWidth = 30D;
            gridImageColumn6.Width = 30D;
            dgList.Columns.Add(gridTextColumn14);
            dgList.Columns.Add(gridTextColumn15);
            dgList.Columns.Add(gridTextColumn16);
            dgList.Columns.Add(gridTextColumn17);
            dgList.Columns.Add(gridTextColumn18);
            dgList.Columns.Add(gridTextColumn19);
            dgList.Columns.Add(gridTextColumn20);
            dgList.Columns.Add(gridTextColumn21);
            dgList.Columns.Add(gridTextColumn22);
            dgList.Columns.Add(gridTextColumn23);
            dgList.Columns.Add(gridTextColumn24);
            dgList.Columns.Add(gridTextColumn25);
            dgList.Columns.Add(gridTextColumn26);
            dgList.Columns.Add(gridImageColumn4);
            dgList.Columns.Add(gridImageColumn5);
            dgList.Columns.Add(gridImageColumn6);
            dgList.Dock = DockStyle.Fill;
            dgList.FrozenColumnCount = 2;
            dgList.FrozenRowCount = 1;
            dgList.Location = new Point(0, 0);
            dgList.Name = "dgList";
            dgList.SelectionMode = Syncfusion.WinForms.DataGrid.Enums.GridSelectionMode.Multiple;
            dgList.ShowGroupDropArea = true;
            dgList.Size = new Size(1318, 546);
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
            dgPager.Dock = DockStyle.Bottom;
            dgPager.HorizontalAlignment = HorizontalAlignment.Center;
            dgPager.Location = new Point(0, 546);
            dgPager.Name = "dgPager";
            dgPager.PageSize = 15;
            dgPager.Size = new Size(1318, 36);
            dgPager.TabIndex = 8;
            dgPager.Text = "sfDataPager1";
            // 
            // EmployeeView
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            ClientSize = new Size(1350, 729);
            Controls.Add(materialCard4);
            Controls.Add(panel2);
            Controls.Add(tableLayoutPanel1);
            KeyPreview = true;
            Name = "EmployeeView";
            Style.MdiChild.IconHorizontalAlignment = HorizontalAlignment.Center;
            Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            KeyDown += Me_KeyDown;
            panel2.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            materialCard4.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgList).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel2;
        private Guna2TextBox txtSearch;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private Guna2Separator guna2Separator1;
        private MaterialSkin.Controls.MaterialCard materialCard4;
        private Panel panel1;
        private Syncfusion.WinForms.DataPager.SfDataPager dgPager;
        private Syncfusion.WinForms.Controls.SfButton btnAdd;
        private Syncfusion.Windows.Forms.Tools.toolstripitem toolstripitemExcel;
        private Syncfusion.Windows.Forms.Tools.toolstripitem toolstripitemPDF;
        private Guna2ImageButton btnPrint;
        private Syncfusion.WinForms.DataGrid.SfDataGrid dgList;
    }
}
