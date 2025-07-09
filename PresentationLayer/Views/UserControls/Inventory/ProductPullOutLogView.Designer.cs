using Guna.UI2.WinForms;

namespace PresentationLayer.Views.UserControls
{
    partial class ProductPullOutLogView
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductPullOutLogView));
            var customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            var customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            var customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            var customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            var customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            var gridTextColumn8 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            var gridTextColumn9 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            var gridTextColumn10 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            var gridTextColumn11 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            var gridTextColumn12 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            var gridTextColumn13 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            var gridDateTimeColumn3 = new Syncfusion.WinForms.DataGrid.GridDateTimeColumn();
            var gridTextColumn14 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            var gridDateTimeColumn4 = new Syncfusion.WinForms.DataGrid.GridDateTimeColumn();
            var gridImageColumn3 = new Syncfusion.WinForms.DataGrid.GridImageColumn();
            var gridImageColumn4 = new Syncfusion.WinForms.DataGrid.GridImageColumn();
            panel2 = new Panel();
            btnPrint = new Guna2ImageButton();
            btnAdd = new Syncfusion.WinForms.Controls.SfButton();
            txtSearch = new Guna2TextBox();
            toolstripitemExcel = new Syncfusion.Windows.Forms.Tools.toolstripitem();
            toolstripitemPDF = new Syncfusion.Windows.Forms.Tools.toolstripitem();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            btnRefresh = new Guna2Button();
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
            panel2.Location = new Point(2, 82);
            panel2.Margin = new Padding(4, 20, 4, 6);
            panel2.Name = "panel2";
            panel2.Size = new Size(1346, 93);
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
            btnPrint.Location = new Point(1265, 15);
            btnPrint.Margin = new Padding(4);
            btnPrint.Name = "btnPrint";
            btnPrint.PressedState.ImageSize = new Size(64, 64);
            btnPrint.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnPrint.Size = new Size(60, 60);
            btnPrint.TabIndex = 26;
            btnPrint.Click += btnPrint_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.AliceBlue;
            btnAdd.Font = new Font("Segoe UI Semibold", 9F);
            btnAdd.ForeColor = Color.Black;
            btnAdd.ImageMargin = new Padding(5, 3, 3, 3);
            btnAdd.Location = new Point(22, 15);
            btnAdd.Margin = new Padding(4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(142, 58);
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
            txtSearch.CustomizableEdges = customizableEdges7;
            txtSearch.DefaultText = "";
            txtSearch.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtSearch.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtSearch.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtSearch.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtSearch.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtSearch.Font = new Font("Segoe UI", 9F);
            txtSearch.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtSearch.IconRight = (Image)resources.GetObject("txtSearch.IconRight");
            txtSearch.Location = new Point(825, 15);
            txtSearch.Margin = new Padding(4, 6, 4, 6);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search here";
            txtSearch.SelectedText = "";
            txtSearch.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtSearch.Size = new Size(430, 58);
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
            tableLayoutPanel1.Margin = new Padding(4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 76F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 24F));
            tableLayoutPanel1.Size = new Size(1346, 80);
            tableLayoutPanel1.TabIndex = 8;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.BackColor = Color.White;
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            tableLayoutPanel2.Controls.Add(btnRefresh, 1, 0);
            tableLayoutPanel2.Controls.Add(materialLabel1, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Margin = new Padding(0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(1346, 60);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // btnRefresh
            // 
            btnRefresh.CustomizableEdges = customizableEdges9;
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
            btnRefresh.Location = new Point(1300, 4);
            btnRefresh.Margin = new Padding(4);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnRefresh.Size = new Size(42, 52);
            btnRefresh.TabIndex = 12;
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
            materialLabel1.Location = new Point(4, 0);
            materialLabel1.Margin = new Padding(4, 0, 4, 0);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(1288, 60);
            materialLabel1.TabIndex = 3;
            materialLabel1.Text = "Product Pull-Out Log Management";
            materialLabel1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // guna2Separator1
            // 
            guna2Separator1.Dock = DockStyle.Fill;
            guna2Separator1.Location = new Point(4, 63);
            guna2Separator1.Margin = new Padding(4, 3, 4, 3);
            guna2Separator1.Name = "guna2Separator1";
            guna2Separator1.Size = new Size(1338, 14);
            guna2Separator1.TabIndex = 1;
            // 
            // materialCard4
            // 
            materialCard4.BackColor = Color.FromArgb(255, 255, 255);
            materialCard4.Controls.Add(panel1);
            materialCard4.Depth = 0;
            materialCard4.Dock = DockStyle.Fill;
            materialCard4.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard4.Location = new Point(2, 175);
            materialCard4.Margin = new Padding(21);
            materialCard4.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard4.Name = "materialCard4";
            materialCard4.Padding = new Padding(21);
            materialCard4.Size = new Size(1346, 552);
            materialCard4.TabIndex = 10;
            // 
            // panel1
            // 
            panel1.Controls.Add(dgList);
            panel1.Controls.Add(dgPager);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(21, 21);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1304, 510);
            panel1.TabIndex = 1;
            // 
            // dgList
            // 
            dgList.AccessibleName = "Table";
            dgList.AllowFiltering = true;
            dgList.AllowTriStateSorting = true;
            dgList.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.Fill;
            gridTextColumn8.AllowFiltering = true;
            gridTextColumn8.HeaderText = "Id";
            gridTextColumn8.MappingName = "ProductPullOutLogId";
            gridTextColumn8.MaximumWidth = 100D;
            gridTextColumn8.MinimumWidth = 100D;
            gridTextColumn8.ShowToolTip = true;
            gridTextColumn8.Visible = false;
            gridTextColumn8.Width = 100D;
            gridTextColumn9.AllowFiltering = true;
            gridTextColumn9.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.ColumnHeader;
            gridTextColumn9.HeaderText = "Project";
            gridTextColumn9.MappingName = "Project";
            gridTextColumn9.ShowToolTip = true;
            gridTextColumn10.AllowFiltering = true;
            gridTextColumn10.AllowTextWrapping = true;
            gridTextColumn10.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.Fill;
            gridTextColumn10.HeaderText = "Product Information";
            gridTextColumn10.MappingName = "ProductPullOutLogLines";
            gridTextColumn10.ShowToolTip = true;
            gridTextColumn11.AllowFiltering = true;
            gridTextColumn11.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.ColumnHeader;
            gridTextColumn11.HeaderText = "Notes";
            gridTextColumn11.MappingName = "Notes";
            gridTextColumn11.ShowToolTip = true;
            gridTextColumn12.AllowFiltering = true;
            gridTextColumn12.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.ColumnHeader;
            gridTextColumn12.HeaderText = "Status";
            gridTextColumn12.MappingName = "ProductStatus";
            gridTextColumn12.ShowToolTip = true;
            gridTextColumn13.AllowFiltering = true;
            gridTextColumn13.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.ColumnHeader;
            gridTextColumn13.HeaderText = "Delivered By";
            gridTextColumn13.MappingName = "DeliveredBy";
            gridTextColumn13.ShowToolTip = true;
            gridDateTimeColumn3.AllowFiltering = true;
            gridDateTimeColumn3.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.ColumnHeader;
            gridDateTimeColumn3.HeaderText = "Delivered Date";
            gridDateTimeColumn3.MappingName = "DeliveredDate";
            gridDateTimeColumn3.MaxDateTime = new DateTime(9999, 12, 31, 23, 59, 59, 999);
            gridDateTimeColumn3.ShowToolTip = true;
            gridTextColumn14.AllowFiltering = true;
            gridTextColumn14.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.ColumnHeader;
            gridTextColumn14.HeaderText = "Received By";
            gridTextColumn14.MappingName = "ReceivedBy";
            gridTextColumn14.ShowToolTip = true;
            gridDateTimeColumn4.AllowFiltering = true;
            gridDateTimeColumn4.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.ColumnHeader;
            gridDateTimeColumn4.HeaderText = "Received Date";
            gridDateTimeColumn4.MappingName = "ReceivedDate";
            gridDateTimeColumn4.MaxDateTime = new DateTime(9999, 12, 31, 23, 59, 59, 999);
            gridDateTimeColumn4.ShowToolTip = true;
            gridImageColumn3.AllowEditing = false;
            gridImageColumn3.AllowGrouping = false;
            gridImageColumn3.AllowSorting = false;
            gridImageColumn3.HeaderStyle.HoverTextColor = Color.White;
            gridImageColumn3.HeaderStyle.PressedTextColor = Color.White;
            gridImageColumn3.HeaderStyle.TextColor = Color.White;
            gridImageColumn3.HeaderText = "Edit";
            gridImageColumn3.ImageLayout = ImageLayout.Zoom;
            gridImageColumn3.MappingName = "Edit";
            gridImageColumn3.MaximumWidth = 30D;
            gridImageColumn3.MinimumWidth = 30D;
            gridImageColumn3.ShowToolTip = true;
            gridImageColumn3.Width = 30D;
            gridImageColumn4.AllowEditing = false;
            gridImageColumn4.AllowGrouping = false;
            gridImageColumn4.AllowSorting = false;
            gridImageColumn4.HeaderStyle.HoverTextColor = Color.White;
            gridImageColumn4.HeaderStyle.PressedTextColor = Color.White;
            gridImageColumn4.HeaderStyle.TextColor = Color.White;
            gridImageColumn4.HeaderText = "Delete";
            gridImageColumn4.ImageLayout = ImageLayout.Zoom;
            gridImageColumn4.MappingName = "Delete";
            gridImageColumn4.MaximumWidth = 30D;
            gridImageColumn4.MinimumWidth = 30D;
            gridImageColumn4.ShowFilterRowOptions = false;
            gridImageColumn4.ShowToolTip = true;
            gridImageColumn4.Width = 30D;
            dgList.Columns.Add(gridTextColumn8);
            dgList.Columns.Add(gridTextColumn9);
            dgList.Columns.Add(gridTextColumn10);
            dgList.Columns.Add(gridTextColumn11);
            dgList.Columns.Add(gridTextColumn12);
            dgList.Columns.Add(gridTextColumn13);
            dgList.Columns.Add(gridDateTimeColumn3);
            dgList.Columns.Add(gridTextColumn14);
            dgList.Columns.Add(gridDateTimeColumn4);
            dgList.Columns.Add(gridImageColumn3);
            dgList.Columns.Add(gridImageColumn4);
            dgList.Dock = DockStyle.Fill;
            dgList.FrozenColumnCount = 2;
            dgList.FrozenRowCount = 1;
            dgList.Location = new Point(0, 0);
            dgList.Margin = new Padding(4);
            dgList.Name = "dgList";
            dgList.PreviewRowHeight = 42;
            dgList.SelectionMode = Syncfusion.WinForms.DataGrid.Enums.GridSelectionMode.Multiple;
            dgList.ShowGroupDropArea = true;
            dgList.ShowToolTip = true;
            dgList.Size = new Size(1304, 456);
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
            dgPager.Location = new Point(0, 456);
            dgPager.Margin = new Padding(4);
            dgPager.Name = "dgPager";
            dgPager.PageCount = 1;
            dgPager.PageSize = 15;
            dgPager.Size = new Size(1304, 54);
            dgPager.TabIndex = 8;
            dgPager.Text = "sfDataPager1";
            // 
            // ProductPullOutLogView
            // 
            AutoScaleDimensions = new SizeF(144F, 144F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            ClientSize = new Size(1350, 729);
            Controls.Add(materialCard4);
            Controls.Add(panel2);
            Controls.Add(tableLayoutPanel1);
            KeyPreview = true;
            Margin = new Padding(4);
            Name = "ProductPullOutLogView";
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
        private Syncfusion.WinForms.DataGrid.SfDataGrid dgList;
        private Syncfusion.WinForms.DataPager.SfDataPager dgPager;
        private Syncfusion.WinForms.Controls.SfButton btnAdd;
        private Syncfusion.Windows.Forms.Tools.toolstripitem toolstripitemExcel;
        private Syncfusion.Windows.Forms.Tools.toolstripitem toolstripitemPDF;
        private Guna2ImageButton btnPrint;
        private Guna2Button btnRefresh;
    }
}
