using Guna.UI2.WinForms;

namespace PresentationLayer.Views.UserControls
{
    partial class DepartmentView
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DepartmentView));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            Guna2TabControl1 = new Guna2TabControl();
            tabPage1 = new TabPage();
            dgList = new Guna2DataGridView();
            tabPage2 = new TabPage();
            materialCard2 = new MaterialSkin.Controls.MaterialCard();
            guna2HtmlLabel3 = new Guna2HtmlLabel();
            guna2HtmlLabel2 = new Guna2HtmlLabel();
            txtDescription = new Guna2TextBox();
            txtName = new Guna2TextBox();
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
            materialCard1.Size = new Size(1356, 701);
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
            Guna2TabControl1.Size = new Size(1324, 531);
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
            tabPage1.Controls.Add(dgList);
            tabPage1.Location = new Point(4, 44);
            tabPage1.Margin = new Padding(3, 4, 3, 4);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3, 4, 3, 4);
            tabPage1.Size = new Size(1316, 483);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "List";
            tabPage1.UseVisualStyleBackColor = true;
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
            dgList.Location = new Point(3, 4);
            dgList.Name = "dgList";
            dgList.RowHeadersVisible = false;
            dgList.RowHeadersWidth = 51;
            dgList.RowTemplate.Height = 29;
            dgList.Size = new Size(1310, 475);
            dgList.TabIndex = 0;
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
            materialCard2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            materialCard2.BackColor = Color.FromArgb(255, 255, 255);
            materialCard2.Controls.Add(guna2HtmlLabel3);
            materialCard2.Controls.Add(guna2HtmlLabel2);
            materialCard2.Controls.Add(txtDescription);
            materialCard2.Controls.Add(txtName);
            materialCard2.Depth = 0;
            materialCard2.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard2.Location = new Point(19, 23);
            materialCard2.Margin = new Padding(16, 19, 16, 19);
            materialCard2.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard2.Name = "materialCard2";
            materialCard2.Padding = new Padding(16, 19, 16, 19);
            materialCard2.Size = new Size(1278, 437);
            materialCard2.TabIndex = 0;
            // 
            // guna2HtmlLabel3
            // 
            guna2HtmlLabel3.Anchor = AnchorStyles.None;
            guna2HtmlLabel3.BackColor = Color.Transparent;
            guna2HtmlLabel3.Font = new Font("Segoe UI", 10F);
            guna2HtmlLabel3.Location = new Point(382, 229);
            guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            guna2HtmlLabel3.Size = new Size(69, 19);
            guna2HtmlLabel3.TabIndex = 12;
            guna2HtmlLabel3.Text = "Description";
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.Anchor = AnchorStyles.None;
            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.Font = new Font("Segoe UI", 10F);
            guna2HtmlLabel2.Location = new Point(382, 122);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(111, 19);
            guna2HtmlLabel2.TabIndex = 11;
            guna2HtmlLabel2.Text = "Department Name";
            // 
            // txtDescription
            // 
            txtDescription.Anchor = AnchorStyles.None;
            txtDescription.CustomizableEdges = customizableEdges1;
            txtDescription.DefaultText = "";
            txtDescription.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtDescription.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtDescription.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtDescription.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtDescription.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtDescription.Font = new Font("Segoe UI", 10F);
            txtDescription.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtDescription.Location = new Point(382, 258);
            txtDescription.Margin = new Padding(4, 7, 4, 7);
            txtDescription.Name = "txtDescription";
            txtDescription.PasswordChar = '\0';
            txtDescription.PlaceholderText = "Enter Department Description";
            txtDescription.SelectedText = "";
            txtDescription.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtDescription.Size = new Size(514, 56);
            txtDescription.TabIndex = 9;
            // 
            // txtName
            // 
            txtName.Anchor = AnchorStyles.None;
            txtName.CustomizableEdges = customizableEdges3;
            txtName.DefaultText = "";
            txtName.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtName.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtName.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtName.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtName.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtName.Font = new Font("Segoe UI", 10F);
            txtName.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtName.Location = new Point(382, 149);
            txtName.Margin = new Padding(3, 5, 3, 5);
            txtName.Name = "txtName";
            txtName.PasswordChar = '\0';
            txtName.PlaceholderText = "Enter Department Name";
            txtName.SelectedText = "";
            txtName.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtName.Size = new Size(514, 56);
            txtName.TabIndex = 8;
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
            panel2.Size = new Size(1324, 62);
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
            txtSearch.CustomizableEdges = customizableEdges5;
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
            txtSearch.Location = new Point(946, 0);
            txtSearch.Margin = new Padding(3, 4, 3, 4);
            txtSearch.Name = "txtSearch";
            txtSearch.PasswordChar = '\0';
            txtSearch.PlaceholderText = "Search here";
            txtSearch.SelectedText = "";
            txtSearch.ShadowDecoration.CustomizableEdges = customizableEdges6;
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
            materialLabel1.Text = "Department Details";
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
            // guna2HtmlToolTip2
            // 
            guna2HtmlToolTip2.AllowLinksHandling = true;
            guna2HtmlToolTip2.AutoPopDelay = 5000;
            guna2HtmlToolTip2.InitialDelay = 500;
            guna2HtmlToolTip2.MaximumSize = new Size(0, 0);
            guna2HtmlToolTip2.ReshowDelay = 100;
            guna2HtmlToolTip2.ToolTipIcon = ToolTipIcon.Info;
            // 
            // DepartmentView
            // 
            AutoScaleMode = AutoScaleMode.Inherit;
            AutoSize = true;
            Controls.Add(materialCard1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "DepartmentView";
            Size = new Size(1356, 701);
            materialCard1.ResumeLayout(false);
            Guna2TabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
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
        private Guna2DataGridView dgList;
        private MaterialSkin.Controls.MaterialCard materialCard2;
        private Guna2TextBox txtDescription;
        private Guna2TextBox txtName;
        private Guna2HtmlLabel guna2HtmlLabel3;
        private Guna2HtmlLabel guna2HtmlLabel2;
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
    }
}
