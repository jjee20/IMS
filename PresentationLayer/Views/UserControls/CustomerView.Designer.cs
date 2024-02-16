namespace PresentationLayer.Views.UserControls
{
    partial class CustomerView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerView));
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            dgList = new DataGridView();
            tabPage2 = new TabPage();
            materialCard2 = new MaterialSkin.Controls.MaterialCard();
            groupBox1 = new GroupBox();
            txtBarangay = new MaterialSkin.Controls.MaterialComboBox();
            txtMunicipality = new MaterialSkin.Controls.MaterialComboBox();
            txtProvince = new MaterialSkin.Controls.MaterialComboBox();
            txtZipCode = new MaterialSkin.Controls.MaterialTextBox();
            txtRegion = new MaterialSkin.Controls.MaterialComboBox();
            txtContactPerson = new MaterialSkin.Controls.MaterialTextBox();
            txtCustomerType = new MaterialSkin.Controls.MaterialComboBox();
            txtEmail = new MaterialSkin.Controls.MaterialTextBox();
            txtPhone = new MaterialSkin.Controls.MaterialTextBox();
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
            materialCard1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgList).BeginInit();
            tabPage2.SuspendLayout();
            materialCard2.SuspendLayout();
            groupBox1.SuspendLayout();
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
            materialCard1.Margin = new Padding(14);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(14);
            materialCard1.Size = new Size(1355, 653);
            materialCard1.TabIndex = 2;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(14, 94);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1327, 545);
            tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(dgList);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1319, 517);
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
            dgList.Location = new Point(3, 3);
            dgList.Name = "dgList";
            dgList.RowHeadersVisible = false;
            dgList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgList.Size = new Size(1313, 511);
            dgList.TabIndex = 4;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(materialCard2);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1319, 517);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Add New";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // materialCard2
            // 
            materialCard2.BackColor = Color.FromArgb(255, 255, 255);
            materialCard2.Controls.Add(groupBox1);
            materialCard2.Controls.Add(txtContactPerson);
            materialCard2.Controls.Add(txtCustomerType);
            materialCard2.Controls.Add(txtEmail);
            materialCard2.Controls.Add(txtPhone);
            materialCard2.Controls.Add(txtId);
            materialCard2.Controls.Add(txtName);
            materialCard2.Depth = 0;
            materialCard2.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard2.Location = new Point(199, 24);
            materialCard2.Margin = new Padding(14);
            materialCard2.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard2.Name = "materialCard2";
            materialCard2.Padding = new Padding(14);
            materialCard2.Size = new Size(921, 468);
            materialCard2.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtBarangay);
            groupBox1.Controls.Add(txtMunicipality);
            groupBox1.Controls.Add(txtProvince);
            groupBox1.Controls.Add(txtZipCode);
            groupBox1.Controls.Add(txtRegion);
            groupBox1.Font = new Font("Segoe UI", 12F);
            groupBox1.Location = new Point(109, 213);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(652, 238);
            groupBox1.TabIndex = 16;
            groupBox1.TabStop = false;
            groupBox1.Text = "Address Information";
            // 
            // txtBarangay
            // 
            txtBarangay.AutoResize = false;
            txtBarangay.BackColor = Color.FromArgb(255, 255, 255);
            txtBarangay.Depth = 0;
            txtBarangay.DrawMode = DrawMode.OwnerDrawVariable;
            txtBarangay.DropDownHeight = 174;
            txtBarangay.DropDownStyle = ComboBoxStyle.DropDownList;
            txtBarangay.DropDownWidth = 121;
            txtBarangay.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            txtBarangay.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtBarangay.FormattingEnabled = true;
            txtBarangay.Hint = "Barangay";
            txtBarangay.IntegralHeight = false;
            txtBarangay.ItemHeight = 43;
            txtBarangay.Location = new Point(24, 40);
            txtBarangay.MaxDropDownItems = 4;
            txtBarangay.MouseState = MaterialSkin.MouseState.OUT;
            txtBarangay.Name = "txtBarangay";
            txtBarangay.Size = new Size(284, 49);
            txtBarangay.StartIndex = 0;
            txtBarangay.TabIndex = 5;
            // 
            // txtMunicipality
            // 
            txtMunicipality.AutoResize = false;
            txtMunicipality.BackColor = Color.FromArgb(255, 255, 255);
            txtMunicipality.Depth = 0;
            txtMunicipality.DrawMode = DrawMode.OwnerDrawVariable;
            txtMunicipality.DropDownHeight = 174;
            txtMunicipality.DropDownStyle = ComboBoxStyle.DropDownList;
            txtMunicipality.DropDownWidth = 121;
            txtMunicipality.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            txtMunicipality.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtMunicipality.FormattingEnabled = true;
            txtMunicipality.Hint = "Municipality";
            txtMunicipality.IntegralHeight = false;
            txtMunicipality.ItemHeight = 43;
            txtMunicipality.Location = new Point(24, 103);
            txtMunicipality.MaxDropDownItems = 4;
            txtMunicipality.MouseState = MaterialSkin.MouseState.OUT;
            txtMunicipality.Name = "txtMunicipality";
            txtMunicipality.Size = new Size(284, 49);
            txtMunicipality.StartIndex = 0;
            txtMunicipality.TabIndex = 6;
            // 
            // txtProvince
            // 
            txtProvince.AutoResize = false;
            txtProvince.BackColor = Color.FromArgb(255, 255, 255);
            txtProvince.Depth = 0;
            txtProvince.DrawMode = DrawMode.OwnerDrawVariable;
            txtProvince.DropDownHeight = 174;
            txtProvince.DropDownStyle = ComboBoxStyle.DropDownList;
            txtProvince.DropDownWidth = 121;
            txtProvince.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            txtProvince.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtProvince.FormattingEnabled = true;
            txtProvince.Hint = "Province";
            txtProvince.IntegralHeight = false;
            txtProvince.ItemHeight = 43;
            txtProvince.Location = new Point(342, 40);
            txtProvince.MaxDropDownItems = 4;
            txtProvince.MouseState = MaterialSkin.MouseState.OUT;
            txtProvince.Name = "txtProvince";
            txtProvince.Size = new Size(284, 49);
            txtProvince.StartIndex = 0;
            txtProvince.TabIndex = 7;
            // 
            // txtZipCode
            // 
            txtZipCode.AnimateReadOnly = false;
            txtZipCode.BorderStyle = BorderStyle.None;
            txtZipCode.Depth = 0;
            txtZipCode.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtZipCode.Hint = "Zip Code";
            txtZipCode.LeadingIcon = null;
            txtZipCode.Location = new Point(182, 166);
            txtZipCode.MaxLength = 50;
            txtZipCode.MouseState = MaterialSkin.MouseState.OUT;
            txtZipCode.Multiline = false;
            txtZipCode.Name = "txtZipCode";
            txtZipCode.Size = new Size(284, 50);
            txtZipCode.TabIndex = 9;
            txtZipCode.Text = "";
            txtZipCode.TrailingIcon = null;
            // 
            // txtRegion
            // 
            txtRegion.AutoResize = false;
            txtRegion.BackColor = Color.FromArgb(255, 255, 255);
            txtRegion.Depth = 0;
            txtRegion.DrawMode = DrawMode.OwnerDrawVariable;
            txtRegion.DropDownHeight = 174;
            txtRegion.DropDownStyle = ComboBoxStyle.DropDownList;
            txtRegion.DropDownWidth = 121;
            txtRegion.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            txtRegion.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtRegion.FormattingEnabled = true;
            txtRegion.Hint = "Region";
            txtRegion.IntegralHeight = false;
            txtRegion.ItemHeight = 43;
            txtRegion.Location = new Point(342, 103);
            txtRegion.MaxDropDownItems = 4;
            txtRegion.MouseState = MaterialSkin.MouseState.OUT;
            txtRegion.Name = "txtRegion";
            txtRegion.Size = new Size(284, 49);
            txtRegion.StartIndex = 0;
            txtRegion.TabIndex = 8;
            // 
            // txtContactPerson
            // 
            txtContactPerson.AnimateReadOnly = false;
            txtContactPerson.BorderStyle = BorderStyle.None;
            txtContactPerson.Depth = 0;
            txtContactPerson.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtContactPerson.Hint = "Enter contact person";
            txtContactPerson.LeadingIcon = null;
            txtContactPerson.Location = new Point(451, 144);
            txtContactPerson.MaxLength = 50;
            txtContactPerson.MouseState = MaterialSkin.MouseState.OUT;
            txtContactPerson.Multiline = false;
            txtContactPerson.Name = "txtContactPerson";
            txtContactPerson.Size = new Size(284, 50);
            txtContactPerson.TabIndex = 4;
            txtContactPerson.Text = "";
            txtContactPerson.TrailingIcon = null;
            // 
            // txtCustomerType
            // 
            txtCustomerType.AutoResize = false;
            txtCustomerType.BackColor = Color.FromArgb(255, 255, 255);
            txtCustomerType.Depth = 0;
            txtCustomerType.DrawMode = DrawMode.OwnerDrawVariable;
            txtCustomerType.DropDownHeight = 174;
            txtCustomerType.DropDownStyle = ComboBoxStyle.DropDownList;
            txtCustomerType.DropDownWidth = 121;
            txtCustomerType.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            txtCustomerType.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtCustomerType.FormattingEnabled = true;
            txtCustomerType.Hint = "Enter customer type";
            txtCustomerType.IntegralHeight = false;
            txtCustomerType.ItemHeight = 43;
            txtCustomerType.Location = new Point(133, 145);
            txtCustomerType.MaxDropDownItems = 4;
            txtCustomerType.MouseState = MaterialSkin.MouseState.OUT;
            txtCustomerType.Name = "txtCustomerType";
            txtCustomerType.Size = new Size(284, 49);
            txtCustomerType.StartIndex = 1;
            txtCustomerType.TabIndex = 14;
            // 
            // txtEmail
            // 
            txtEmail.AnimateReadOnly = false;
            txtEmail.BorderStyle = BorderStyle.None;
            txtEmail.Depth = 0;
            txtEmail.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtEmail.Hint = "Enter email";
            txtEmail.LeadingIcon = null;
            txtEmail.Location = new Point(451, 79);
            txtEmail.MaxLength = 50;
            txtEmail.MouseState = MaterialSkin.MouseState.OUT;
            txtEmail.Multiline = false;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(284, 50);
            txtEmail.TabIndex = 3;
            txtEmail.Text = "";
            txtEmail.TrailingIcon = null;
            // 
            // txtPhone
            // 
            txtPhone.AnimateReadOnly = false;
            txtPhone.BorderStyle = BorderStyle.None;
            txtPhone.Depth = 0;
            txtPhone.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtPhone.Hint = "Enter phone number";
            txtPhone.LeadingIcon = null;
            txtPhone.Location = new Point(451, 17);
            txtPhone.MaxLength = 50;
            txtPhone.MouseState = MaterialSkin.MouseState.OUT;
            txtPhone.Multiline = false;
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(284, 50);
            txtPhone.TabIndex = 2;
            txtPhone.Text = "";
            txtPhone.TrailingIcon = null;
            // 
            // txtId
            // 
            txtId.AnimateReadOnly = false;
            txtId.BorderStyle = BorderStyle.None;
            txtId.Depth = 0;
            txtId.Font = new Font("Microsoft Sans Serif", 12F);
            txtId.LeadingIcon = null;
            txtId.Location = new Point(133, 17);
            txtId.MaxLength = 50;
            txtId.MouseState = MaterialSkin.MouseState.OUT;
            txtId.Multiline = false;
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(284, 50);
            txtId.TabIndex = 6;
            txtId.TabStop = false;
            txtId.Text = "Id";
            txtId.TrailingIcon = null;
            // 
            // txtName
            // 
            txtName.AnimateReadOnly = false;
            txtName.BorderStyle = BorderStyle.None;
            txtName.Depth = 0;
            txtName.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtName.Hint = "Enter name";
            txtName.LeadingIcon = null;
            txtName.Location = new Point(133, 79);
            txtName.MaxLength = 50;
            txtName.MouseState = MaterialSkin.MouseState.OUT;
            txtName.Multiline = false;
            txtName.Name = "txtName";
            txtName.Size = new Size(284, 50);
            txtName.TabIndex = 0;
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
            panel2.Location = new Point(14, 64);
            panel2.Margin = new Padding(3, 10, 3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(1327, 30);
            panel2.TabIndex = 3;
            // 
            // btnPrint
            // 
            btnPrint.Dock = DockStyle.Left;
            btnPrint.FlatAppearance.BorderSize = 0;
            btnPrint.FlatStyle = FlatStyle.Flat;
            btnPrint.Image = (Image)resources.GetObject("btnPrint.Image");
            btnPrint.Location = new Point(366, 0);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(30, 30);
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
            txtSearch.Location = new Point(150, 0);
            txtSearch.MaxLength = 30;
            txtSearch.MouseState = MaterialSkin.MouseState.OUT;
            txtSearch.Multiline = false;
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(216, 50);
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
            btnDelete.Location = new Point(120, 0);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(30, 30);
            btnDelete.TabIndex = 2;
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Dock = DockStyle.Left;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Image = (Image)resources.GetObject("btnSave.Image");
            btnSave.Location = new Point(90, 0);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(30, 30);
            btnSave.TabIndex = 1;
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            btnEdit.Dock = DockStyle.Left;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Image = (Image)resources.GetObject("btnEdit.Image");
            btnEdit.Location = new Point(60, 0);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(30, 30);
            btnEdit.TabIndex = 0;
            btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            btnAdd.Dock = DockStyle.Left;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Image = (Image)resources.GetObject("btnAdd.Image");
            btnAdd.Location = new Point(30, 0);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(30, 30);
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
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(30, 30);
            btnReturn.TabIndex = 6;
            btnReturn.UseVisualStyleBackColor = true;
            btnReturn.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.White;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(14, 14);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 76F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 24F));
            tableLayoutPanel1.Size = new Size(1327, 50);
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
            tableLayoutPanel2.Size = new Size(1327, 38);
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
            materialLabel1.Location = new Point(3, 0);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(186, 38);
            materialLabel1.TabIndex = 3;
            materialLabel1.Text = "Customer Details";
            materialLabel1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // CustomerView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(materialCard1);
            Name = "CustomerView";
            Size = new Size(1355, 653);
            materialCard1.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgList).EndInit();
            tabPage2.ResumeLayout(false);
            materialCard2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
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
        private MaterialSkin.Controls.MaterialComboBox txtBarangay;
        private MaterialSkin.Controls.MaterialTextBox txtZipCode;
        private MaterialSkin.Controls.MaterialTextBox txtEmail;
        private MaterialSkin.Controls.MaterialTextBox txtPhone;
        private MaterialSkin.Controls.MaterialComboBox txtRegion;
        private MaterialSkin.Controls.MaterialComboBox txtProvince;
        private MaterialSkin.Controls.MaterialComboBox txtMunicipality;
        private MaterialSkin.Controls.MaterialComboBox txtCustomerType;
        private GroupBox groupBox1;
        private MaterialSkin.Controls.MaterialTextBox txtContactPerson;
    }
}
