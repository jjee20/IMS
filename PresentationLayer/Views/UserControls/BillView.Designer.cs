namespace PresentationLayer.Views.UserControls
{
    partial class BillView
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BillView));
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            dgList = new DataGridView();
            tabPage2 = new TabPage();
            materialCard2 = new MaterialSkin.Controls.MaterialCard();
            txtBillType = new MaterialSkin.Controls.MaterialComboBox();
            txtBillDueDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            txtBillDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            txtVendorInvoiceNumber = new MaterialSkin.Controls.MaterialTextBox();
            txtVendorDONumber = new MaterialSkin.Controls.MaterialTextBox();
            txtGoodsReceivedNote = new MaterialSkin.Controls.MaterialComboBox();
            txtId = new MaterialSkin.Controls.MaterialTextBox();
            txtName = new MaterialSkin.Controls.MaterialTextBox();
            panel2 = new Panel();
            btnPrint = new Button();
            txtSearch = new MaterialSkin.Controls.MaterialTextBox();
            btnDelete = new Button();
            btnSave = new Button();
            btnEdit = new Button();
            btnAdd = new Button();
            btnReturn = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            materialCard1.SuspendLayout();
            tabControl1.SuspendLayout();
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
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(tabControl1);
            materialCard1.Controls.Add(panel2);
            materialCard1.Controls.Add(tableLayoutPanel1);
            materialCard1.Depth = 0;
            materialCard1.Dock = DockStyle.Fill;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(0, 0);
            materialCard1.Margin = new Padding(20, 23, 20, 23);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(20, 23, 20, 23);
            materialCard1.Size = new Size(1936, 1088);
            materialCard1.TabIndex = 2;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(20, 156);
            tabControl1.Margin = new Padding(4, 5, 4, 5);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1896, 909);
            tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(dgList);
            tabPage1.Location = new Point(4, 34);
            tabPage1.Margin = new Padding(4, 5, 4, 5);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(4, 5, 4, 5);
            tabPage1.Size = new Size(1888, 871);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "List";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgList
            // 
            dgList.AllowUserToAddRows = false;
            dgList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgList.BackgroundColor = Color.White;
            dgList.BorderStyle = BorderStyle.None;
            dgList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.Transparent;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 11F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(64, 162, 227);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(222, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(187, 226, 236);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(222, 0, 0, 0);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgList.DefaultCellStyle = dataGridViewCellStyle2;
            dgList.Dock = DockStyle.Fill;
            dgList.Location = new Point(4, 5);
            dgList.Margin = new Padding(4, 5, 4, 5);
            dgList.Name = "dgList";
            dgList.RowHeadersVisible = false;
            dgList.RowHeadersWidth = 62;
            dgList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgList.Size = new Size(1880, 861);
            dgList.TabIndex = 4;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(materialCard2);
            tabPage2.Location = new Point(4, 34);
            tabPage2.Margin = new Padding(4, 5, 4, 5);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(4, 5, 4, 5);
            tabPage2.Size = new Size(1888, 871);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Add New";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // materialCard2
            // 
            materialCard2.BackColor = Color.FromArgb(255, 255, 255);
            materialCard2.Controls.Add(materialLabel3);
            materialCard2.Controls.Add(materialLabel2);
            materialCard2.Controls.Add(txtBillType);
            materialCard2.Controls.Add(txtBillDueDate);
            materialCard2.Controls.Add(txtBillDate);
            materialCard2.Controls.Add(txtVendorInvoiceNumber);
            materialCard2.Controls.Add(txtVendorDONumber);
            materialCard2.Controls.Add(txtGoodsReceivedNote);
            materialCard2.Controls.Add(txtId);
            materialCard2.Controls.Add(txtName);
            materialCard2.Depth = 0;
            materialCard2.Dock = DockStyle.Fill;
            materialCard2.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard2.Location = new Point(4, 5);
            materialCard2.Margin = new Padding(20, 23, 20, 23);
            materialCard2.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard2.Name = "materialCard2";
            materialCard2.Padding = new Padding(20, 23, 20, 23);
            materialCard2.Size = new Size(1880, 861);
            materialCard2.TabIndex = 0;
            // 
            // txtBillType
            // 
            txtBillType.AutoResize = false;
            txtBillType.BackColor = Color.FromArgb(255, 255, 255);
            txtBillType.Depth = 0;
            txtBillType.DrawMode = DrawMode.OwnerDrawVariable;
            txtBillType.DropDownHeight = 174;
            txtBillType.DropDownStyle = ComboBoxStyle.DropDownList;
            txtBillType.DropDownWidth = 121;
            txtBillType.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            txtBillType.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtBillType.FormattingEnabled = true;
            txtBillType.Hint = "Select Bill Type";
            txtBillType.IntegralHeight = false;
            txtBillType.ItemHeight = 43;
            txtBillType.Location = new Point(742, 725);
            txtBillType.Margin = new Padding(4, 5, 4, 5);
            txtBillType.MaxDropDownItems = 4;
            txtBillType.MouseState = MaterialSkin.MouseState.OUT;
            txtBillType.Name = "txtBillType";
            txtBillType.Size = new Size(406, 49);
            txtBillType.StartIndex = 0;
            txtBillType.TabIndex = 20;
            // 
            // txtBillDueDate
            // 
            txtBillDueDate.Checked = true;
            txtBillDueDate.CustomizableEdges = customizableEdges1;
            txtBillDueDate.Font = new Font("Segoe UI", 9F);
            txtBillDueDate.Format = DateTimePickerFormat.Long;
            txtBillDueDate.Location = new Point(741, 634);
            txtBillDueDate.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            txtBillDueDate.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            txtBillDueDate.Name = "txtBillDueDate";
            txtBillDueDate.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtBillDueDate.Size = new Size(405, 54);
            txtBillDueDate.TabIndex = 19;
            txtBillDueDate.Value = new DateTime(2024, 11, 8, 11, 53, 55, 455);
            // 
            // txtBillDate
            // 
            txtBillDate.Checked = true;
            txtBillDate.CustomizableEdges = customizableEdges3;
            txtBillDate.Font = new Font("Segoe UI", 9F);
            txtBillDate.Format = DateTimePickerFormat.Long;
            txtBillDate.Location = new Point(741, 518);
            txtBillDate.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            txtBillDate.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            txtBillDate.Name = "txtBillDate";
            txtBillDate.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtBillDate.Size = new Size(405, 54);
            txtBillDate.TabIndex = 18;
            txtBillDate.Value = new DateTime(2024, 11, 8, 11, 53, 55, 455);
            // 
            // txtVendorInvoiceNumber
            // 
            txtVendorInvoiceNumber.AnimateReadOnly = false;
            txtVendorInvoiceNumber.BorderStyle = BorderStyle.None;
            txtVendorInvoiceNumber.Depth = 0;
            txtVendorInvoiceNumber.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtVendorInvoiceNumber.Hint = "Enter Vendor Invoice Number";
            txtVendorInvoiceNumber.LeadingIcon = null;
            txtVendorInvoiceNumber.Location = new Point(741, 406);
            txtVendorInvoiceNumber.Margin = new Padding(4, 5, 4, 5);
            txtVendorInvoiceNumber.MaxLength = 50;
            txtVendorInvoiceNumber.MouseState = MaterialSkin.MouseState.OUT;
            txtVendorInvoiceNumber.Multiline = false;
            txtVendorInvoiceNumber.Name = "txtVendorInvoiceNumber";
            txtVendorInvoiceNumber.Size = new Size(406, 50);
            txtVendorInvoiceNumber.TabIndex = 17;
            txtVendorInvoiceNumber.Text = "";
            txtVendorInvoiceNumber.TrailingIcon = null;
            // 
            // txtVendorDONumber
            // 
            txtVendorDONumber.AnimateReadOnly = false;
            txtVendorDONumber.BorderStyle = BorderStyle.None;
            txtVendorDONumber.Depth = 0;
            txtVendorDONumber.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtVendorDONumber.Hint = "Enter Vendor DO Number";
            txtVendorDONumber.LeadingIcon = null;
            txtVendorDONumber.Location = new Point(741, 319);
            txtVendorDONumber.Margin = new Padding(4, 5, 4, 5);
            txtVendorDONumber.MaxLength = 50;
            txtVendorDONumber.MouseState = MaterialSkin.MouseState.OUT;
            txtVendorDONumber.Multiline = false;
            txtVendorDONumber.Name = "txtVendorDONumber";
            txtVendorDONumber.Size = new Size(406, 50);
            txtVendorDONumber.TabIndex = 16;
            txtVendorDONumber.Text = "";
            txtVendorDONumber.TrailingIcon = null;
            // 
            // txtGoodsReceivedNote
            // 
            txtGoodsReceivedNote.AutoResize = false;
            txtGoodsReceivedNote.BackColor = Color.FromArgb(255, 255, 255);
            txtGoodsReceivedNote.Depth = 0;
            txtGoodsReceivedNote.DrawMode = DrawMode.OwnerDrawVariable;
            txtGoodsReceivedNote.DropDownHeight = 174;
            txtGoodsReceivedNote.DropDownStyle = ComboBoxStyle.DropDownList;
            txtGoodsReceivedNote.DropDownWidth = 121;
            txtGoodsReceivedNote.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            txtGoodsReceivedNote.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtGoodsReceivedNote.FormattingEnabled = true;
            txtGoodsReceivedNote.Hint = "Select GRN";
            txtGoodsReceivedNote.IntegralHeight = false;
            txtGoodsReceivedNote.ItemHeight = 43;
            txtGoodsReceivedNote.Location = new Point(741, 233);
            txtGoodsReceivedNote.Margin = new Padding(4, 5, 4, 5);
            txtGoodsReceivedNote.MaxDropDownItems = 4;
            txtGoodsReceivedNote.MouseState = MaterialSkin.MouseState.OUT;
            txtGoodsReceivedNote.Name = "txtGoodsReceivedNote";
            txtGoodsReceivedNote.Size = new Size(406, 49);
            txtGoodsReceivedNote.StartIndex = 0;
            txtGoodsReceivedNote.TabIndex = 15;
            // 
            // txtId
            // 
            txtId.AnimateReadOnly = false;
            txtId.BorderStyle = BorderStyle.None;
            txtId.Depth = 0;
            txtId.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtId.Hint = "Id";
            txtId.LeadingIcon = null;
            txtId.Location = new Point(741, 59);
            txtId.Margin = new Padding(4, 5, 4, 5);
            txtId.MaxLength = 50;
            txtId.MouseState = MaterialSkin.MouseState.OUT;
            txtId.Multiline = false;
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(406, 50);
            txtId.TabIndex = 6;
            txtId.Text = "";
            txtId.TrailingIcon = null;
            // 
            // txtName
            // 
            txtName.AnimateReadOnly = false;
            txtName.BorderStyle = BorderStyle.None;
            txtName.Depth = 0;
            txtName.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtName.Hint = "Enter Bill Name";
            txtName.LeadingIcon = null;
            txtName.Location = new Point(741, 146);
            txtName.Margin = new Padding(4, 5, 4, 5);
            txtName.MaxLength = 50;
            txtName.MouseState = MaterialSkin.MouseState.OUT;
            txtName.Multiline = false;
            txtName.Name = "txtName";
            txtName.Size = new Size(406, 50);
            txtName.TabIndex = 4;
            txtName.Text = "";
            txtName.TrailingIcon = null;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.Controls.Add(btnPrint);
            panel2.Controls.Add(txtSearch);
            panel2.Controls.Add(btnDelete);
            panel2.Controls.Add(btnSave);
            panel2.Controls.Add(btnEdit);
            panel2.Controls.Add(btnAdd);
            panel2.Controls.Add(btnReturn);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(20, 106);
            panel2.Margin = new Padding(4, 17, 4, 5);
            panel2.Name = "panel2";
            panel2.Size = new Size(1896, 50);
            panel2.TabIndex = 3;
            // 
            // btnPrint
            // 
            btnPrint.Dock = DockStyle.Left;
            btnPrint.FlatAppearance.BorderSize = 0;
            btnPrint.FlatStyle = FlatStyle.Flat;
            btnPrint.Image = (Image)resources.GetObject("btnPrint.Image");
            btnPrint.Location = new Point(524, 0);
            btnPrint.Margin = new Padding(4, 5, 4, 5);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(43, 50);
            btnPrint.TabIndex = 5;
            btnPrint.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            txtSearch.AnimateReadOnly = false;
            txtSearch.BackColor = Color.White;
            txtSearch.BorderStyle = BorderStyle.None;
            txtSearch.Depth = 0;
            txtSearch.Dock = DockStyle.Left;
            txtSearch.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtSearch.Hint = "Search here";
            txtSearch.LeadingIcon = null;
            txtSearch.Location = new Point(215, 0);
            txtSearch.Margin = new Padding(4, 5, 4, 5);
            txtSearch.MaxLength = 30;
            txtSearch.MouseState = MaterialSkin.MouseState.OUT;
            txtSearch.Multiline = false;
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(309, 50);
            txtSearch.TabIndex = 4;
            txtSearch.Text = "";
            txtSearch.TrailingIcon = (Image)resources.GetObject("txtSearch.TrailingIcon");
            // 
            // btnDelete
            // 
            btnDelete.Dock = DockStyle.Left;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Image = (Image)resources.GetObject("btnDelete.Image");
            btnDelete.Location = new Point(172, 0);
            btnDelete.Margin = new Padding(4, 5, 4, 5);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(43, 50);
            btnDelete.TabIndex = 2;
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Dock = DockStyle.Left;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Image = (Image)resources.GetObject("btnSave.Image");
            btnSave.Location = new Point(129, 0);
            btnSave.Margin = new Padding(4, 5, 4, 5);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(43, 50);
            btnSave.TabIndex = 1;
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            btnEdit.Dock = DockStyle.Left;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Image = (Image)resources.GetObject("btnEdit.Image");
            btnEdit.Location = new Point(86, 0);
            btnEdit.Margin = new Padding(4, 5, 4, 5);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(43, 50);
            btnEdit.TabIndex = 0;
            btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            btnAdd.Dock = DockStyle.Left;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Image = (Image)resources.GetObject("btnAdd.Image");
            btnAdd.Location = new Point(43, 0);
            btnAdd.Margin = new Padding(4, 5, 4, 5);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(43, 50);
            btnAdd.TabIndex = 3;
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnReturn
            // 
            btnReturn.Dock = DockStyle.Left;
            btnReturn.FlatAppearance.BorderSize = 0;
            btnReturn.FlatStyle = FlatStyle.Flat;
            btnReturn.Image = (Image)resources.GetObject("btnReturn.Image");
            btnReturn.Location = new Point(0, 0);
            btnReturn.Margin = new Padding(4, 5, 4, 5);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(43, 50);
            btnReturn.TabIndex = 6;
            btnReturn.UseVisualStyleBackColor = true;
            btnReturn.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(20, 23);
            tableLayoutPanel1.Margin = new Padding(4, 5, 4, 5);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 76F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 24F));
            tableLayoutPanel1.Size = new Size(1896, 83);
            tableLayoutPanel1.TabIndex = 5;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.BackColor = Color.FromArgb(187, 226, 236);
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(materialLabel1, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Margin = new Padding(0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(1896, 63);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Dock = DockStyle.Left;
            materialLabel1.Font = new Font("Roboto", 24F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialLabel1.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            materialLabel1.ForeColor = Color.FromArgb(255, 246, 233);
            materialLabel1.ImageAlign = ContentAlignment.MiddleLeft;
            materialLabel1.Location = new Point(4, 0);
            materialLabel1.Margin = new Padding(4, 0, 4, 0);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(114, 63);
            materialLabel1.TabIndex = 3;
            materialLabel1.Text = "Bill Details";
            materialLabel1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.Location = new Point(742, 477);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(60, 19);
            materialLabel2.TabIndex = 21;
            materialLabel2.Text = "Bill Date";
            // 
            // materialLabel3
            // 
            materialLabel3.AutoSize = true;
            materialLabel3.Depth = 0;
            materialLabel3.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel3.Location = new Point(741, 593);
            materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel3.Name = "materialLabel3";
            materialLabel3.Size = new Size(92, 19);
            materialLabel3.TabIndex = 22;
            materialLabel3.Text = "Bill Due Date";
            // 
            // BillView
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(materialCard1);
            Margin = new Padding(4, 5, 4, 5);
            Name = "BillView";
            Size = new Size(1936, 1088);
            materialCard1.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgList).EndInit();
            tabPage2.ResumeLayout(false);
            materialCard2.ResumeLayout(false);
            materialCard2.PerformLayout();
            panel2.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialCard materialCard1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private DataGridView dgList;
        private TabPage tabPage2;
        private MaterialSkin.Controls.MaterialCard materialCard2;
        private MaterialSkin.Controls.MaterialTextBox txtId;
        private MaterialSkin.Controls.MaterialTextBox txtName;
        private Panel panel2;
        private Button btnPrint;
        private MaterialSkin.Controls.MaterialTextBox txtSearch;
        private Button btnDelete;
        private Button btnSave;
        private Button btnEdit;
        private Button btnAdd;
        private Button btnReturn;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialComboBox txtGoodsReceivedNote;
        private MaterialSkin.Controls.MaterialTextBox txtVendorInvoiceNumber;
        private MaterialSkin.Controls.MaterialTextBox txtVendorDONumber;
        private MaterialSkin.Controls.MaterialComboBox txtBillType;
        private Guna.UI2.WinForms.Guna2DateTimePicker txtBillDueDate;
        private Guna.UI2.WinForms.Guna2DateTimePicker txtBillDate;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
    }
}
