using Guna.UI2.WinForms;

namespace PresentationLayer.Views.UserControls
{
    partial class TaxView
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
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaxView));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            Guna2TabControl1 = new Guna2TabControl();
            tabPage1 = new TabPage();
            materialCard4 = new MaterialSkin.Controls.MaterialCard();
            panel1 = new Panel();
            dgList = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            dgPager = new Syncfusion.WinForms.DataPager.SfDataPager();
            tabPage2 = new TabPage();
            materialCard2 = new MaterialSkin.Controls.MaterialCard();
            txtTaxRate = new Guna2TextBox();
            txtMaximumSalary = new Guna2TextBox();
            guna2HtmlLabel4 = new Guna2HtmlLabel();
            guna2HtmlLabel3 = new Guna2HtmlLabel();
            guna2HtmlLabel2 = new Guna2HtmlLabel();
            txtMinimumSalary = new Guna2TextBox();
            panel2 = new Panel();
            btnPrint = new Button();
            imageList1 = new ImageList(components);
            btnDelete = new Button();
            btnSave = new Button();
            btnEdit = new Button();
            btnAdd = new Button();
            btnReturn = new Button();
            txtSearch = new Guna2TextBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            guna2Separator1 = new Guna2Separator();
            guna2HtmlToolTip2 = new Guna2HtmlToolTip();
            materialCard1.SuspendLayout();
            Guna2TabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            materialCard4.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgList).BeginInit();
            tabPage2.SuspendLayout();
            materialCard2.SuspendLayout();
            panel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // materialCard1
            // 
            materialCard1.AutoSize = true;
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(Guna2TabControl1);
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
            materialCard1.Size = new Size(1340, 662);
            materialCard1.TabIndex = 2;
            // 
            // Guna2TabControl1
            // 
            Guna2TabControl1.Controls.Add(tabPage1);
            Guna2TabControl1.Controls.Add(tabPage2);
            Guna2TabControl1.Dock = DockStyle.Fill;
            Guna2TabControl1.ItemSize = new Size(180, 40);
            Guna2TabControl1.Location = new Point(16, 151);
            Guna2TabControl1.Margin = new Padding(3, 4, 3, 4);
            Guna2TabControl1.Name = "Guna2TabControl1";
            Guna2TabControl1.SelectedIndex = 0;
            Guna2TabControl1.Size = new Size(1308, 492);
            Guna2TabControl1.TabButtonHoverState.BorderColor = Color.Empty;
            Guna2TabControl1.TabButtonHoverState.FillColor = Color.FromArgb(40, 52, 70);
            Guna2TabControl1.TabButtonHoverState.Font = new Font("Segoe UI Semibold", 10F);
            Guna2TabControl1.TabButtonHoverState.ForeColor = Color.White;
            Guna2TabControl1.TabButtonHoverState.InnerColor = Color.FromArgb(40, 52, 70);
            Guna2TabControl1.TabButtonIdleState.BorderColor = Color.Empty;
            Guna2TabControl1.TabButtonIdleState.FillColor = Color.FromArgb(33, 42, 57);
            Guna2TabControl1.TabButtonIdleState.Font = new Font("Segoe UI Semibold", 10F);
            Guna2TabControl1.TabButtonIdleState.ForeColor = Color.FromArgb(156, 160, 167);
            Guna2TabControl1.TabButtonIdleState.InnerColor = Color.FromArgb(33, 42, 57);
            Guna2TabControl1.TabButtonSelectedState.BorderColor = Color.Empty;
            Guna2TabControl1.TabButtonSelectedState.FillColor = Color.FromArgb(29, 37, 49);
            Guna2TabControl1.TabButtonSelectedState.Font = new Font("Segoe UI Semibold", 10F);
            Guna2TabControl1.TabButtonSelectedState.ForeColor = Color.White;
            Guna2TabControl1.TabButtonSelectedState.InnerColor = Color.FromArgb(76, 132, 255);
            Guna2TabControl1.TabButtonSize = new Size(180, 40);
            Guna2TabControl1.TabIndex = 4;
            Guna2TabControl1.TabMenuBackColor = Color.White;
            Guna2TabControl1.TabMenuOrientation = TabMenuOrientation.HorizontalTop;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(materialCard4);
            tabPage1.Location = new Point(4, 44);
            tabPage1.Margin = new Padding(3, 4, 3, 4);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3, 4, 3, 4);
            tabPage1.Size = new Size(1300, 444);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "List";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // materialCard4
            // 
            materialCard4.BackColor = Color.FromArgb(255, 255, 255);
            materialCard4.Controls.Add(panel1);
            materialCard4.Depth = 0;
            materialCard4.Dock = DockStyle.Fill;
            materialCard4.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard4.Location = new Point(3, 4);
            materialCard4.Margin = new Padding(14);
            materialCard4.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard4.Name = "materialCard4";
            materialCard4.Padding = new Padding(14);
            materialCard4.Size = new Size(1294, 436);
            materialCard4.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.Controls.Add(dgList);
            panel1.Controls.Add(dgPager);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(14, 14);
            panel1.Name = "panel1";
            panel1.Size = new Size(1266, 408);
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
            dgList.Size = new Size(1266, 372);
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
            dgPager.Location = new Point(0, 372);
            dgPager.Name = "dgPager";
            dgPager.PageCount = 1;
            dgPager.PageSize = 15;
            dgPager.Size = new Size(1266, 36);
            dgPager.TabIndex = 8;
            dgPager.Text = "sfDataPager1";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(materialCard2);
            tabPage2.Location = new Point(4, 44);
            tabPage2.Margin = new Padding(3, 4, 3, 4);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3, 4, 3, 4);
            tabPage2.Size = new Size(1316, 483);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Add New";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // materialCard2
            // 
            materialCard2.BackColor = Color.FromArgb(255, 255, 255);
            materialCard2.Controls.Add(txtTaxRate);
            materialCard2.Controls.Add(txtMaximumSalary);
            materialCard2.Controls.Add(guna2HtmlLabel4);
            materialCard2.Controls.Add(guna2HtmlLabel3);
            materialCard2.Controls.Add(guna2HtmlLabel2);
            materialCard2.Controls.Add(txtMinimumSalary);
            materialCard2.Depth = 0;
            materialCard2.Dock = DockStyle.Fill;
            materialCard2.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard2.Location = new Point(3, 4);
            materialCard2.Margin = new Padding(16, 19, 16, 19);
            materialCard2.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard2.Name = "materialCard2";
            materialCard2.Padding = new Padding(16, 19, 16, 19);
            materialCard2.Size = new Size(1310, 475);
            materialCard2.TabIndex = 0;
            // 
            // txtTaxRate
            // 
            txtTaxRate.Anchor = AnchorStyles.None;
            txtTaxRate.CustomizableEdges = customizableEdges1;
            txtTaxRate.DefaultText = "";
            txtTaxRate.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtTaxRate.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtTaxRate.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtTaxRate.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtTaxRate.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtTaxRate.Font = new Font("Segoe UI", 10F);
            txtTaxRate.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtTaxRate.Location = new Point(398, 324);
            txtTaxRate.Margin = new Padding(3, 5, 3, 5);
            txtTaxRate.Name = "txtTaxRate";
            txtTaxRate.PlaceholderText = "Enter Tax Rate";
            txtTaxRate.SelectedText = "";
            txtTaxRate.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtTaxRate.Size = new Size(514, 56);
            txtTaxRate.TabIndex = 16;
            // 
            // txtMaximumSalary
            // 
            txtMaximumSalary.Anchor = AnchorStyles.None;
            txtMaximumSalary.CustomizableEdges = customizableEdges3;
            txtMaximumSalary.DefaultText = "";
            txtMaximumSalary.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtMaximumSalary.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtMaximumSalary.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtMaximumSalary.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtMaximumSalary.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtMaximumSalary.Font = new Font("Segoe UI", 10F);
            txtMaximumSalary.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtMaximumSalary.Location = new Point(398, 224);
            txtMaximumSalary.Margin = new Padding(3, 5, 3, 5);
            txtMaximumSalary.Name = "txtMaximumSalary";
            txtMaximumSalary.PlaceholderText = "Enter Maximum Salary";
            txtMaximumSalary.SelectedText = "";
            txtMaximumSalary.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtMaximumSalary.Size = new Size(514, 56);
            txtMaximumSalary.TabIndex = 15;
            // 
            // guna2HtmlLabel4
            // 
            guna2HtmlLabel4.Anchor = AnchorStyles.None;
            guna2HtmlLabel4.BackColor = Color.Transparent;
            guna2HtmlLabel4.Font = new Font("Segoe UI", 10F);
            guna2HtmlLabel4.Location = new Point(398, 297);
            guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            guna2HtmlLabel4.Size = new Size(53, 19);
            guna2HtmlLabel4.TabIndex = 14;
            guna2HtmlLabel4.Text = "Tax Rate";
            // 
            // guna2HtmlLabel3
            // 
            guna2HtmlLabel3.Anchor = AnchorStyles.None;
            guna2HtmlLabel3.BackColor = Color.Transparent;
            guna2HtmlLabel3.Font = new Font("Segoe UI", 10F);
            guna2HtmlLabel3.Location = new Point(398, 196);
            guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            guna2HtmlLabel3.Size = new Size(99, 19);
            guna2HtmlLabel3.TabIndex = 12;
            guna2HtmlLabel3.Text = "Maximum Salary";
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.Anchor = AnchorStyles.None;
            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.Font = new Font("Segoe UI", 10F);
            guna2HtmlLabel2.Location = new Point(398, 95);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(96, 19);
            guna2HtmlLabel2.TabIndex = 11;
            guna2HtmlLabel2.Text = "Minimum Salary";
            // 
            // txtMinimumSalary
            // 
            txtMinimumSalary.Anchor = AnchorStyles.None;
            txtMinimumSalary.CustomizableEdges = customizableEdges5;
            txtMinimumSalary.DefaultText = "";
            txtMinimumSalary.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtMinimumSalary.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtMinimumSalary.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtMinimumSalary.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtMinimumSalary.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtMinimumSalary.Font = new Font("Segoe UI", 10F);
            txtMinimumSalary.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtMinimumSalary.Location = new Point(398, 122);
            txtMinimumSalary.Margin = new Padding(3, 5, 3, 5);
            txtMinimumSalary.Name = "txtMinimumSalary";
            txtMinimumSalary.PlaceholderText = "Enter Minimum Salary";
            txtMinimumSalary.SelectedText = "";
            txtMinimumSalary.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtMinimumSalary.Size = new Size(514, 56);
            txtMinimumSalary.TabIndex = 8;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(btnPrint);
            panel2.Controls.Add(btnDelete);
            panel2.Controls.Add(btnSave);
            panel2.Controls.Add(btnEdit);
            panel2.Controls.Add(btnAdd);
            panel2.Controls.Add(btnReturn);
            panel2.Controls.Add(txtSearch);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(16, 89);
            panel2.Margin = new Padding(3, 13, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(1308, 62);
            panel2.TabIndex = 5;
            // 
            // btnPrint
            // 
            btnPrint.Dock = DockStyle.Left;
            btnPrint.FlatAppearance.BorderSize = 0;
            btnPrint.FlatStyle = FlatStyle.Flat;
            btnPrint.ImageKey = "printing.png";
            btnPrint.ImageList = imageList1;
            btnPrint.Location = new Point(375, 0);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(75, 62);
            btnPrint.TabIndex = 24;
            btnPrint.Text = "Print";
            btnPrint.TextImageRelation = TextImageRelation.ImageAboveText;
            btnPrint.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "add.png");
            imageList1.Images.SetKeyName(1, "delete.png");
            imageList1.Images.SetKeyName(2, "diskette.png");
            imageList1.Images.SetKeyName(3, "edit-text.png");
            imageList1.Images.SetKeyName(4, "printing.png");
            imageList1.Images.SetKeyName(5, "return.png");
            // 
            // btnDelete
            // 
            btnDelete.Dock = DockStyle.Left;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.ImageKey = "delete.png";
            btnDelete.ImageList = imageList1;
            btnDelete.Location = new Point(300, 0);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 62);
            btnDelete.TabIndex = 23;
            btnDelete.Text = "Delete";
            btnDelete.TextImageRelation = TextImageRelation.ImageAboveText;
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Dock = DockStyle.Left;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.ImageKey = "diskette.png";
            btnSave.ImageList = imageList1;
            btnSave.Location = new Point(225, 0);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 62);
            btnSave.TabIndex = 26;
            btnSave.Text = "Save";
            btnSave.TextImageRelation = TextImageRelation.ImageAboveText;
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            btnEdit.Dock = DockStyle.Left;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.ImageKey = "edit-text.png";
            btnEdit.ImageList = imageList1;
            btnEdit.Location = new Point(150, 0);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(75, 62);
            btnEdit.TabIndex = 22;
            btnEdit.Text = "Edit";
            btnEdit.TextImageRelation = TextImageRelation.ImageAboveText;
            btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            btnAdd.Dock = DockStyle.Left;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.ImageKey = "add.png";
            btnAdd.ImageList = imageList1;
            btnAdd.Location = new Point(75, 0);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 62);
            btnAdd.TabIndex = 21;
            btnAdd.Text = "Add";
            btnAdd.TextImageRelation = TextImageRelation.ImageAboveText;
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnReturn
            // 
            btnReturn.Dock = DockStyle.Left;
            btnReturn.FlatAppearance.BorderSize = 0;
            btnReturn.FlatStyle = FlatStyle.Flat;
            btnReturn.ImageKey = "return.png";
            btnReturn.ImageList = imageList1;
            btnReturn.Location = new Point(0, 0);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(75, 62);
            btnReturn.TabIndex = 20;
            btnReturn.Text = "Return";
            btnReturn.TextImageRelation = TextImageRelation.ImageAboveText;
            btnReturn.UseVisualStyleBackColor = true;
            btnReturn.Visible = false;
            // 
            // txtSearch
            // 
            txtSearch.CharacterCasing = CharacterCasing.Upper;
            txtSearch.CustomizableEdges = customizableEdges7;
            txtSearch.DefaultText = "";
            txtSearch.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtSearch.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtSearch.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtSearch.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtSearch.Dock = DockStyle.Right;
            txtSearch.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtSearch.Font = new Font("Segoe UI", 9F);
            txtSearch.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtSearch.IconRight = (Image)resources.GetObject("txtSearch.IconRight");
            txtSearch.Location = new Point(930, 0);
            txtSearch.Margin = new Padding(3, 4, 3, 4);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search here";
            txtSearch.SelectedText = "";
            txtSearch.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtSearch.Size = new Size(378, 62);
            txtSearch.TabIndex = 11;
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
            tableLayoutPanel1.Size = new Size(1308, 70);
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
            tableLayoutPanel2.Size = new Size(1308, 53);
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
            materialLabel1.Text = "Tax Management";
            materialLabel1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // guna2Separator1
            // 
            guna2Separator1.Dock = DockStyle.Fill;
            guna2Separator1.Location = new Point(3, 56);
            guna2Separator1.Name = "guna2Separator1";
            guna2Separator1.Size = new Size(1302, 11);
            guna2Separator1.TabIndex = 1;
            // 
            // guna2HtmlToolTip2
            // 
            guna2HtmlToolTip2.AllowLinksHandling = true;
            guna2HtmlToolTip2.AutoPopDelay = 5000;
            guna2HtmlToolTip2.InitialDelay = 500;
            guna2HtmlToolTip2.MaximumSize = new Size(0, 0);
            guna2HtmlToolTip2.ReshowDelay = 100;
            guna2HtmlToolTip2.ToolTipIcon = ToolTipIcon.Info;
            // 
            // TaxView
            // 
            AutoScaleMode = AutoScaleMode.Inherit;
            AutoSize = true;
            ClientSize = new Size(1340, 662);
            Controls.Add(materialCard1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "TaxView";
            materialCard1.ResumeLayout(false);
            Guna2TabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            materialCard4.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgList).EndInit();
            tabPage2.ResumeLayout(false);
            materialCard2.ResumeLayout(false);
            materialCard2.PerformLayout();
            panel2.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialCard materialCard1;
        private Guna2TabControl Guna2TabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private Guna2Separator guna2Separator1;
        private MaterialSkin.Controls.MaterialCard materialCard2;
        private Guna2TextBox txtMinimumSalary;
        private Guna2HtmlLabel guna2HtmlLabel2;
        private Guna2HtmlLabel guna2HtmlLabel3;
        private Guna2HtmlLabel guna2HtmlLabel4;
        private Guna2TextBox txtTaxRate;
        private Guna2TextBox txtMaximumSalary;
        private Guna2HtmlToolTip guna2HtmlToolTip2;
        private Panel panel2;
        private Button btnPrint;
        private ImageList imageList1;
        private Button btnDelete;
        private Button btnEdit;
        private Button btnAdd;
        private Button btnReturn;
        private Guna2TextBox txtSearch;
        private Button btnSave;
        private MaterialSkin.Controls.MaterialCard materialCard4;
        private Panel panel1;
        private Syncfusion.WinForms.DataGrid.SfDataGrid dgList;
        private Syncfusion.WinForms.DataPager.SfDataPager dgPager;
    }
}
