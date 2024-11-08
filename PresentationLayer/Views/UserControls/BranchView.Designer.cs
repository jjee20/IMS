namespace PresentationLayer.Views.UserControls
{
    partial class BranchView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BranchView));
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            dgList = new DataGridView();
            tabPage2 = new TabPage();
            materialCard2 = new MaterialSkin.Controls.MaterialCard();
            txtEmail = new MaterialSkin.Controls.MaterialTextBox();
            txtPhone = new MaterialSkin.Controls.MaterialMaskedTextBox();
            groupBox1 = new GroupBox();
            txtRegion = new MaterialSkin.Controls.MaterialTextBox();
            txtProvince = new MaterialSkin.Controls.MaterialTextBox();
            txtMunicipality = new MaterialSkin.Controls.MaterialTextBox();
            txtBarangay = new MaterialSkin.Controls.MaterialTextBox();
            txtZipCode = new MaterialSkin.Controls.MaterialTextBox();
            txtContactPerson = new MaterialSkin.Controls.MaterialTextBox();
            txtCurrency = new MaterialSkin.Controls.MaterialComboBox();
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
            txtDescription = new MaterialSkin.Controls.MaterialTextBox();
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
            materialCard2.Controls.Add(txtDescription);
            materialCard2.Controls.Add(txtEmail);
            materialCard2.Controls.Add(txtPhone);
            materialCard2.Controls.Add(groupBox1);
            materialCard2.Controls.Add(txtContactPerson);
            materialCard2.Controls.Add(txtCurrency);
            materialCard2.Controls.Add(txtId);
            materialCard2.Controls.Add(txtName);
            materialCard2.Depth = 0;
            materialCard2.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard2.Location = new Point(284, 40);
            materialCard2.Margin = new Padding(20, 23, 20, 23);
            materialCard2.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard2.Name = "materialCard2";
            materialCard2.Padding = new Padding(20, 23, 20, 23);
            materialCard2.Size = new Size(1316, 780);
            materialCard2.TabIndex = 0;
            // 
            // txtEmail
            // 
            txtEmail.AnimateReadOnly = false;
            txtEmail.BorderStyle = BorderStyle.None;
            txtEmail.Depth = 0;
            txtEmail.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtEmail.Hint = "Enter Email Address";
            txtEmail.LeadingIcon = null;
            txtEmail.Location = new Point(653, 330);
            txtEmail.Margin = new Padding(4, 5, 4, 5);
            txtEmail.MaxLength = 50;
            txtEmail.MouseState = MaterialSkin.MouseState.OUT;
            txtEmail.Multiline = false;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(577, 50);
            txtEmail.TabIndex = 2;
            txtEmail.Text = "";
            txtEmail.TrailingIcon = null;
            // 
            // txtPhone
            // 
            txtPhone.AllowPromptAsInput = true;
            txtPhone.AnimateReadOnly = false;
            txtPhone.AsciiOnly = false;
            txtPhone.BackgroundImageLayout = ImageLayout.None;
            txtPhone.BeepOnError = false;
            txtPhone.CutCopyMaskFormat = MaskFormat.IncludeLiterals;
            txtPhone.Depth = 0;
            txtPhone.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtPhone.HelperText = "Enter Phone Number";
            txtPhone.HidePromptOnLeave = false;
            txtPhone.HideSelection = true;
            txtPhone.Hint = "Enter Phone Number";
            txtPhone.InsertKeyMode = InsertKeyMode.Default;
            txtPhone.LeadingIcon = null;
            txtPhone.Location = new Point(83, 270);
            txtPhone.Margin = new Padding(4, 5, 4, 5);
            txtPhone.Mask = "0000-000-0000";
            txtPhone.MaxLength = 32767;
            txtPhone.MouseState = MaterialSkin.MouseState.OUT;
            txtPhone.Name = "txtPhone";
            txtPhone.PasswordChar = '\0';
            txtPhone.PrefixSuffixText = "Enter phone number: ";
            txtPhone.PromptChar = '_';
            txtPhone.ReadOnly = false;
            txtPhone.RejectInputOnFirstFailure = false;
            txtPhone.ResetOnPrompt = true;
            txtPhone.ResetOnSpace = true;
            txtPhone.RightToLeft = RightToLeft.No;
            txtPhone.SelectedText = "";
            txtPhone.SelectionLength = 0;
            txtPhone.SelectionStart = 0;
            txtPhone.ShortcutsEnabled = true;
            txtPhone.Size = new Size(513, 48);
            txtPhone.SkipLiterals = true;
            txtPhone.TabIndex = 3;
            txtPhone.TabStop = false;
            txtPhone.Text = "____-___-____";
            txtPhone.TextAlign = HorizontalAlignment.Left;
            txtPhone.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            txtPhone.TrailingIcon = null;
            txtPhone.UseSystemPasswordChar = false;
            txtPhone.ValidatingType = null;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtRegion);
            groupBox1.Controls.Add(txtProvince);
            groupBox1.Controls.Add(txtMunicipality);
            groupBox1.Controls.Add(txtBarangay);
            groupBox1.Controls.Add(txtZipCode);
            groupBox1.Font = new Font("Segoe UI", 12F);
            groupBox1.Location = new Point(83, 385);
            groupBox1.Margin = new Padding(4, 5, 4, 5);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 5, 4, 5);
            groupBox1.Size = new Size(1147, 335);
            groupBox1.TabIndex = 16;
            groupBox1.TabStop = false;
            groupBox1.Text = "Address Information";
            // 
            // txtRegion
            // 
            txtRegion.AnimateReadOnly = false;
            txtRegion.BorderStyle = BorderStyle.None;
            txtRegion.Depth = 0;
            txtRegion.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtRegion.Hint = "Enter Region";
            txtRegion.LeadingIcon = null;
            txtRegion.Location = new Point(570, 143);
            txtRegion.Margin = new Padding(4, 5, 4, 5);
            txtRegion.MaxLength = 50;
            txtRegion.MouseState = MaterialSkin.MouseState.OUT;
            txtRegion.Multiline = false;
            txtRegion.Name = "txtRegion";
            txtRegion.Size = new Size(544, 50);
            txtRegion.TabIndex = 8;
            txtRegion.Text = "";
            txtRegion.TrailingIcon = null;
            // 
            // txtProvince
            // 
            txtProvince.AnimateReadOnly = false;
            txtProvince.BorderStyle = BorderStyle.None;
            txtProvince.Depth = 0;
            txtProvince.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtProvince.Hint = "Enter Province";
            txtProvince.LeadingIcon = null;
            txtProvince.Location = new Point(34, 143);
            txtProvince.Margin = new Padding(4, 5, 4, 5);
            txtProvince.MaxLength = 50;
            txtProvince.MouseState = MaterialSkin.MouseState.OUT;
            txtProvince.Multiline = false;
            txtProvince.Name = "txtProvince";
            txtProvince.Size = new Size(479, 50);
            txtProvince.TabIndex = 7;
            txtProvince.Text = "";
            txtProvince.TrailingIcon = null;
            // 
            // txtMunicipality
            // 
            txtMunicipality.AnimateReadOnly = false;
            txtMunicipality.BorderStyle = BorderStyle.None;
            txtMunicipality.Depth = 0;
            txtMunicipality.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtMunicipality.Hint = "Enter Municipality";
            txtMunicipality.LeadingIcon = null;
            txtMunicipality.Location = new Point(570, 47);
            txtMunicipality.Margin = new Padding(4, 5, 4, 5);
            txtMunicipality.MaxLength = 50;
            txtMunicipality.MouseState = MaterialSkin.MouseState.OUT;
            txtMunicipality.Multiline = false;
            txtMunicipality.Name = "txtMunicipality";
            txtMunicipality.Size = new Size(544, 50);
            txtMunicipality.TabIndex = 6;
            txtMunicipality.Text = "";
            txtMunicipality.TrailingIcon = null;
            // 
            // txtBarangay
            // 
            txtBarangay.AnimateReadOnly = false;
            txtBarangay.BorderStyle = BorderStyle.None;
            txtBarangay.Depth = 0;
            txtBarangay.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtBarangay.Hint = "Enter Barangay";
            txtBarangay.LeadingIcon = null;
            txtBarangay.Location = new Point(34, 47);
            txtBarangay.Margin = new Padding(4, 5, 4, 5);
            txtBarangay.MaxLength = 50;
            txtBarangay.MouseState = MaterialSkin.MouseState.OUT;
            txtBarangay.Multiline = false;
            txtBarangay.Name = "txtBarangay";
            txtBarangay.Size = new Size(479, 50);
            txtBarangay.TabIndex = 5;
            txtBarangay.Text = "";
            txtBarangay.TrailingIcon = null;
            // 
            // txtZipCode
            // 
            txtZipCode.AnimateReadOnly = false;
            txtZipCode.BorderStyle = BorderStyle.None;
            txtZipCode.Depth = 0;
            txtZipCode.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtZipCode.Hint = "Enter Zip Code";
            txtZipCode.LeadingIcon = null;
            txtZipCode.Location = new Point(34, 240);
            txtZipCode.Margin = new Padding(4, 5, 4, 5);
            txtZipCode.MaxLength = 50;
            txtZipCode.MouseState = MaterialSkin.MouseState.OUT;
            txtZipCode.Multiline = false;
            txtZipCode.Name = "txtZipCode";
            txtZipCode.Size = new Size(479, 50);
            txtZipCode.TabIndex = 9;
            txtZipCode.Text = "";
            txtZipCode.TrailingIcon = null;
            // 
            // txtContactPerson
            // 
            txtContactPerson.AnimateReadOnly = false;
            txtContactPerson.BorderStyle = BorderStyle.None;
            txtContactPerson.Depth = 0;
            txtContactPerson.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtContactPerson.Hint = "Enter Contact Person";
            txtContactPerson.LeadingIcon = null;
            txtContactPerson.Location = new Point(653, 270);
            txtContactPerson.Margin = new Padding(4, 5, 4, 5);
            txtContactPerson.MaxLength = 50;
            txtContactPerson.MouseState = MaterialSkin.MouseState.OUT;
            txtContactPerson.Multiline = false;
            txtContactPerson.Name = "txtContactPerson";
            txtContactPerson.Size = new Size(577, 50);
            txtContactPerson.TabIndex = 4;
            txtContactPerson.Text = "";
            txtContactPerson.TrailingIcon = null;
            // 
            // txtCurrency
            // 
            txtCurrency.AutoResize = false;
            txtCurrency.BackColor = Color.FromArgb(255, 255, 255);
            txtCurrency.Depth = 0;
            txtCurrency.DrawMode = DrawMode.OwnerDrawVariable;
            txtCurrency.DropDownHeight = 174;
            txtCurrency.DropDownStyle = ComboBoxStyle.DropDownList;
            txtCurrency.DropDownWidth = 121;
            txtCurrency.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            txtCurrency.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtCurrency.FormattingEnabled = true;
            txtCurrency.Hint = "Select Currency";
            txtCurrency.IntegralHeight = false;
            txtCurrency.ItemHeight = 43;
            txtCurrency.Location = new Point(653, 77);
            txtCurrency.Margin = new Padding(4, 5, 4, 5);
            txtCurrency.MaxDropDownItems = 4;
            txtCurrency.MouseState = MaterialSkin.MouseState.OUT;
            txtCurrency.Name = "txtCurrency";
            txtCurrency.Size = new Size(575, 49);
            txtCurrency.StartIndex = 0;
            txtCurrency.TabIndex = 14;
            // 
            // txtId
            // 
            txtId.AnimateReadOnly = true;
            txtId.BorderStyle = BorderStyle.None;
            txtId.Depth = 0;
            txtId.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtId.Hint = "Id";
            txtId.LeadingIcon = null;
            txtId.Location = new Point(83, 75);
            txtId.Margin = new Padding(4, 5, 4, 5);
            txtId.MaxLength = 50;
            txtId.MouseState = MaterialSkin.MouseState.OUT;
            txtId.Multiline = false;
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(513, 50);
            txtId.TabIndex = 99;
            txtId.Text = "";
            txtId.TrailingIcon = null;
            // 
            // txtName
            // 
            txtName.AnimateReadOnly = false;
            txtName.BorderStyle = BorderStyle.None;
            txtName.Depth = 0;
            txtName.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtName.Hint = "Enter Name";
            txtName.LeadingIcon = null;
            txtName.Location = new Point(83, 170);
            txtName.Margin = new Padding(4, 5, 4, 5);
            txtName.MaxLength = 50;
            txtName.MouseState = MaterialSkin.MouseState.OUT;
            txtName.Multiline = false;
            txtName.Name = "txtName";
            txtName.Size = new Size(513, 50);
            txtName.TabIndex = 1;
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
            txtSearch.Size = new Size(309, 36);
            txtSearch.TabIndex = 4;
            txtSearch.Text = "";
            txtSearch.TrailingIcon = (Image)resources.GetObject("txtSearch.TrailingIcon");
            txtSearch.UseTallSize = false;
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
            tableLayoutPanel1.BackColor = Color.White;
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
            materialLabel1.Size = new Size(156, 63);
            materialLabel1.TabIndex = 3;
            materialLabel1.Text = "Branch Details";
            materialLabel1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtDescription
            // 
            txtDescription.AnimateReadOnly = false;
            txtDescription.BorderStyle = BorderStyle.None;
            txtDescription.Depth = 0;
            txtDescription.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtDescription.Hint = "Enter Description";
            txtDescription.LeadingIcon = null;
            txtDescription.Location = new Point(653, 170);
            txtDescription.Margin = new Padding(4, 5, 4, 5);
            txtDescription.MaxLength = 50;
            txtDescription.MouseState = MaterialSkin.MouseState.OUT;
            txtDescription.Multiline = false;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(577, 50);
            txtDescription.TabIndex = 100;
            txtDescription.Text = "";
            txtDescription.TrailingIcon = null;
            // 
            // BranchView
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(materialCard1);
            Margin = new Padding(4, 5, 4, 5);
            Name = "BranchView";
            Size = new Size(1936, 1088);
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
        private MaterialSkin.Controls.MaterialTextBox txtZipCode;
        private MaterialSkin.Controls.MaterialComboBox txtCurrency;
        private GroupBox groupBox1;
        private MaterialSkin.Controls.MaterialTextBox txtContactPerson;
        private MaterialSkin.Controls.MaterialTextBox txtRegion;
        private MaterialSkin.Controls.MaterialTextBox txtProvince;
        private MaterialSkin.Controls.MaterialTextBox txtMunicipality;
        private MaterialSkin.Controls.MaterialTextBox txtBarangay;
        private MaterialSkin.Controls.MaterialMaskedTextBox txtPhone;
        private MaterialSkin.Controls.MaterialTextBox txtEmail;
        private MaterialSkin.Controls.MaterialTextBox txtDescription;
    }
}
