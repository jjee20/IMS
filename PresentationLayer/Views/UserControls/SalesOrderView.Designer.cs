namespace PresentationLayer.Views.UserControls
{
    partial class SalesOrderView
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalesOrderView));
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            dgList = new DataGridView();
            tabPage2 = new TabPage();
            materialCard2 = new MaterialSkin.Controls.MaterialCard();
            guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            txtAmount = new MaterialSkin.Controls.MaterialTextBox();
            txtDiscount = new MaterialSkin.Controls.MaterialTextBox();
            txtTax = new MaterialSkin.Controls.MaterialTextBox();
            txtSubTotal = new MaterialSkin.Controls.MaterialTextBox();
            txtFreight = new MaterialSkin.Controls.MaterialTextBox();
            txtTotal = new MaterialSkin.Controls.MaterialTextBox();
            dgOrderLine = new Guna.UI2.WinForms.Guna2DataGridView();
            txtRemarks = new MaterialSkin.Controls.MaterialTextBox();
            txtSalesType = new MaterialSkin.Controls.MaterialComboBox();
            txtCurrency = new MaterialSkin.Controls.MaterialComboBox();
            txtCustomer = new MaterialSkin.Controls.MaterialComboBox();
            materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            txtSalesOrderDueDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            txtSalesOrderDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            txtBranch = new MaterialSkin.Controls.MaterialComboBox();
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
            txtCustomerRefNumber = new MaterialSkin.Controls.MaterialTextBox();
            materialCard1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgList).BeginInit();
            tabPage2.SuspendLayout();
            materialCard2.SuspendLayout();
            guna2GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgOrderLine).BeginInit();
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
            materialCard2.Controls.Add(txtCustomerRefNumber);
            materialCard2.Controls.Add(guna2GroupBox1);
            materialCard2.Controls.Add(dgOrderLine);
            materialCard2.Controls.Add(txtRemarks);
            materialCard2.Controls.Add(txtSalesType);
            materialCard2.Controls.Add(txtCurrency);
            materialCard2.Controls.Add(txtCustomer);
            materialCard2.Controls.Add(materialLabel3);
            materialCard2.Controls.Add(materialLabel2);
            materialCard2.Controls.Add(txtSalesOrderDueDate);
            materialCard2.Controls.Add(txtSalesOrderDate);
            materialCard2.Controls.Add(txtBranch);
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
            // guna2GroupBox1
            // 
            guna2GroupBox1.Controls.Add(txtAmount);
            guna2GroupBox1.Controls.Add(txtDiscount);
            guna2GroupBox1.Controls.Add(txtTax);
            guna2GroupBox1.Controls.Add(txtSubTotal);
            guna2GroupBox1.Controls.Add(txtFreight);
            guna2GroupBox1.Controls.Add(txtTotal);
            guna2GroupBox1.CustomizableEdges = customizableEdges1;
            guna2GroupBox1.Font = new Font("Segoe UI", 9F);
            guna2GroupBox1.ForeColor = Color.FromArgb(125, 137, 149);
            guna2GroupBox1.Location = new Point(1279, 284);
            guna2GroupBox1.Name = "guna2GroupBox1";
            guna2GroupBox1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2GroupBox1.Size = new Size(548, 526);
            guna2GroupBox1.TabIndex = 35;
            guna2GroupBox1.Text = "Payment Details";
            // 
            // txtAmount
            // 
            txtAmount.AnimateReadOnly = false;
            txtAmount.BorderStyle = BorderStyle.None;
            txtAmount.Depth = 0;
            txtAmount.Font = new Font("Microsoft Sans Serif", 8F);
            txtAmount.Hint = "Enter Amount";
            txtAmount.LeadingIcon = null;
            txtAmount.Location = new Point(26, 449);
            txtAmount.Margin = new Padding(4, 5, 4, 5);
            txtAmount.MaxLength = 50;
            txtAmount.MouseState = MaterialSkin.MouseState.OUT;
            txtAmount.Multiline = false;
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(497, 50);
            txtAmount.TabIndex = 28;
            txtAmount.Text = "0";
            txtAmount.TrailingIcon = null;
            // 
            // txtDiscount
            // 
            txtDiscount.AnimateReadOnly = false;
            txtDiscount.BorderStyle = BorderStyle.None;
            txtDiscount.Depth = 0;
            txtDiscount.Font = new Font("Microsoft Sans Serif", 8F);
            txtDiscount.Hint = "Enter Discount";
            txtDiscount.LeadingIcon = null;
            txtDiscount.Location = new Point(26, 145);
            txtDiscount.Margin = new Padding(4, 5, 4, 5);
            txtDiscount.MaxLength = 50;
            txtDiscount.MouseState = MaterialSkin.MouseState.OUT;
            txtDiscount.Multiline = false;
            txtDiscount.Name = "txtDiscount";
            txtDiscount.Size = new Size(497, 50);
            txtDiscount.TabIndex = 26;
            txtDiscount.Text = "0";
            txtDiscount.TrailingIcon = null;
            // 
            // txtTax
            // 
            txtTax.AnimateReadOnly = false;
            txtTax.BorderStyle = BorderStyle.None;
            txtTax.Depth = 0;
            txtTax.Font = new Font("Microsoft Sans Serif", 8F);
            txtTax.Hint = "Tax";
            txtTax.LeadingIcon = null;
            txtTax.Location = new Point(26, 221);
            txtTax.Margin = new Padding(4, 5, 4, 5);
            txtTax.MaxLength = 50;
            txtTax.MouseState = MaterialSkin.MouseState.OUT;
            txtTax.Multiline = false;
            txtTax.Name = "txtTax";
            txtTax.Size = new Size(497, 50);
            txtTax.TabIndex = 32;
            txtTax.Text = "12";
            txtTax.TrailingIcon = null;
            // 
            // txtSubTotal
            // 
            txtSubTotal.AnimateReadOnly = false;
            txtSubTotal.BorderStyle = BorderStyle.None;
            txtSubTotal.Depth = 0;
            txtSubTotal.Font = new Font("Microsoft Sans Serif", 8F);
            txtSubTotal.Hint = "SubTotal";
            txtSubTotal.LeadingIcon = null;
            txtSubTotal.Location = new Point(26, 69);
            txtSubTotal.Margin = new Padding(4, 5, 4, 5);
            txtSubTotal.MaxLength = 50;
            txtSubTotal.MouseState = MaterialSkin.MouseState.OUT;
            txtSubTotal.Multiline = false;
            txtSubTotal.Name = "txtSubTotal";
            txtSubTotal.Size = new Size(497, 50);
            txtSubTotal.TabIndex = 27;
            txtSubTotal.Text = "0";
            txtSubTotal.TrailingIcon = null;
            // 
            // txtFreight
            // 
            txtFreight.AnimateReadOnly = false;
            txtFreight.BorderStyle = BorderStyle.None;
            txtFreight.Depth = 0;
            txtFreight.Font = new Font("Microsoft Sans Serif", 8F);
            txtFreight.Hint = "Enter Freight";
            txtFreight.LeadingIcon = null;
            txtFreight.Location = new Point(26, 297);
            txtFreight.Margin = new Padding(4, 5, 4, 5);
            txtFreight.MaxLength = 50;
            txtFreight.MouseState = MaterialSkin.MouseState.OUT;
            txtFreight.Multiline = false;
            txtFreight.Name = "txtFreight";
            txtFreight.Size = new Size(497, 50);
            txtFreight.TabIndex = 31;
            txtFreight.Text = "0";
            txtFreight.TrailingIcon = null;
            // 
            // txtTotal
            // 
            txtTotal.AnimateReadOnly = false;
            txtTotal.BorderStyle = BorderStyle.None;
            txtTotal.Depth = 0;
            txtTotal.Font = new Font("Microsoft Sans Serif", 8F);
            txtTotal.Hint = "Total";
            txtTotal.LeadingIcon = null;
            txtTotal.Location = new Point(26, 373);
            txtTotal.Margin = new Padding(4, 5, 4, 5);
            txtTotal.MaxLength = 50;
            txtTotal.MouseState = MaterialSkin.MouseState.OUT;
            txtTotal.Multiline = false;
            txtTotal.Name = "txtTotal";
            txtTotal.Size = new Size(497, 50);
            txtTotal.TabIndex = 30;
            txtTotal.Text = "0";
            txtTotal.TrailingIcon = null;
            // 
            // dgOrderLine
            // 
            dataGridViewCellStyle3.BackColor = Color.White;
            dgOrderLine.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            dgOrderLine.BackgroundColor = Color.WhiteSmoke;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = Color.White;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgOrderLine.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgOrderLine.ColumnHeadersHeight = 4;
            dgOrderLine.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.White;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle5.ForeColor = Color.FromArgb(222, 0, 0, 0);
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle5.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            dgOrderLine.DefaultCellStyle = dataGridViewCellStyle5;
            dgOrderLine.GridColor = Color.FromArgb(231, 229, 255);
            dgOrderLine.Location = new Point(54, 284);
            dgOrderLine.Name = "dgOrderLine";
            dgOrderLine.RowHeadersVisible = false;
            dgOrderLine.RowHeadersWidth = 62;
            dgOrderLine.Size = new Size(1159, 526);
            dgOrderLine.TabIndex = 33;
            dgOrderLine.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgOrderLine.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgOrderLine.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgOrderLine.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgOrderLine.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgOrderLine.ThemeStyle.BackColor = Color.WhiteSmoke;
            dgOrderLine.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dgOrderLine.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgOrderLine.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgOrderLine.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dgOrderLine.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgOrderLine.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgOrderLine.ThemeStyle.HeaderStyle.Height = 4;
            dgOrderLine.ThemeStyle.ReadOnly = false;
            dgOrderLine.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgOrderLine.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgOrderLine.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgOrderLine.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(222, 0, 0, 0);
            dgOrderLine.ThemeStyle.RowsStyle.Height = 33;
            dgOrderLine.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgOrderLine.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // txtRemarks
            // 
            txtRemarks.AnimateReadOnly = false;
            txtRemarks.BorderStyle = BorderStyle.None;
            txtRemarks.Depth = 0;
            txtRemarks.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtRemarks.Hint = "Enter Remarks";
            txtRemarks.LeadingIcon = null;
            txtRemarks.Location = new Point(1279, 194);
            txtRemarks.Margin = new Padding(4, 5, 4, 5);
            txtRemarks.MaxLength = 50;
            txtRemarks.MouseState = MaterialSkin.MouseState.OUT;
            txtRemarks.Multiline = false;
            txtRemarks.Name = "txtRemarks";
            txtRemarks.Size = new Size(548, 50);
            txtRemarks.TabIndex = 29;
            txtRemarks.Text = "";
            txtRemarks.TrailingIcon = null;
            // 
            // txtSalesType
            // 
            txtSalesType.AutoResize = false;
            txtSalesType.BackColor = Color.FromArgb(255, 255, 255);
            txtSalesType.Depth = 0;
            txtSalesType.DrawMode = DrawMode.OwnerDrawVariable;
            txtSalesType.DropDownHeight = 174;
            txtSalesType.DropDownStyle = ComboBoxStyle.DropDownList;
            txtSalesType.DropDownWidth = 121;
            txtSalesType.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            txtSalesType.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtSalesType.FormattingEnabled = true;
            txtSalesType.Hint = "Select Sales Type";
            txtSalesType.IntegralHeight = false;
            txtSalesType.ItemHeight = 43;
            txtSalesType.Location = new Point(53, 195);
            txtSalesType.Margin = new Padding(4, 5, 4, 5);
            txtSalesType.MaxDropDownItems = 4;
            txtSalesType.MouseState = MaterialSkin.MouseState.OUT;
            txtSalesType.Name = "txtSalesType";
            txtSalesType.Size = new Size(257, 49);
            txtSalesType.StartIndex = 0;
            txtSalesType.TabIndex = 25;
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
            txtCurrency.Location = new Point(333, 195);
            txtCurrency.Margin = new Padding(4, 5, 4, 5);
            txtCurrency.MaxDropDownItems = 4;
            txtCurrency.MouseState = MaterialSkin.MouseState.OUT;
            txtCurrency.Name = "txtCurrency";
            txtCurrency.Size = new Size(268, 49);
            txtCurrency.StartIndex = 0;
            txtCurrency.TabIndex = 24;
            // 
            // txtCustomer
            // 
            txtCustomer.AutoResize = false;
            txtCustomer.BackColor = Color.FromArgb(255, 255, 255);
            txtCustomer.Depth = 0;
            txtCustomer.DrawMode = DrawMode.OwnerDrawVariable;
            txtCustomer.DropDownHeight = 174;
            txtCustomer.DropDownStyle = ComboBoxStyle.DropDownList;
            txtCustomer.DropDownWidth = 121;
            txtCustomer.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            txtCustomer.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtCustomer.FormattingEnabled = true;
            txtCustomer.Hint = "Select Customer";
            txtCustomer.IntegralHeight = false;
            txtCustomer.ItemHeight = 43;
            txtCustomer.Location = new Point(666, 127);
            txtCustomer.Margin = new Padding(4, 5, 4, 5);
            txtCustomer.MaxDropDownItems = 4;
            txtCustomer.MouseState = MaterialSkin.MouseState.OUT;
            txtCustomer.Name = "txtCustomer";
            txtCustomer.Size = new Size(548, 49);
            txtCustomer.StartIndex = 0;
            txtCustomer.TabIndex = 23;
            // 
            // materialLabel3
            // 
            materialLabel3.AutoSize = true;
            materialLabel3.Depth = 0;
            materialLabel3.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel3.Location = new Point(666, 23);
            materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel3.Name = "materialLabel3";
            materialLabel3.Size = new Size(179, 19);
            materialLabel3.TabIndex = 22;
            materialLabel3.Text = "Sales Order Delivery Date";
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.Location = new Point(55, 23);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(119, 19);
            materialLabel2.TabIndex = 21;
            materialLabel2.Text = "Sales Order Date";
            // 
            // txtSalesOrderDueDate
            // 
            txtSalesOrderDueDate.Checked = true;
            txtSalesOrderDueDate.CustomizableEdges = customizableEdges3;
            txtSalesOrderDueDate.Font = new Font("Segoe UI", 9F);
            txtSalesOrderDueDate.Format = DateTimePickerFormat.Long;
            txtSalesOrderDueDate.Location = new Point(666, 55);
            txtSalesOrderDueDate.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            txtSalesOrderDueDate.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            txtSalesOrderDueDate.Name = "txtSalesOrderDueDate";
            txtSalesOrderDueDate.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtSalesOrderDueDate.Size = new Size(548, 54);
            txtSalesOrderDueDate.TabIndex = 19;
            txtSalesOrderDueDate.Value = new DateTime(2024, 11, 8, 11, 53, 55, 455);
            // 
            // txtSalesOrderDate
            // 
            txtSalesOrderDate.Checked = true;
            txtSalesOrderDate.CustomizableEdges = customizableEdges5;
            txtSalesOrderDate.Font = new Font("Segoe UI", 9F);
            txtSalesOrderDate.Format = DateTimePickerFormat.Long;
            txtSalesOrderDate.Location = new Point(54, 55);
            txtSalesOrderDate.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            txtSalesOrderDate.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            txtSalesOrderDate.Name = "txtSalesOrderDate";
            txtSalesOrderDate.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtSalesOrderDate.Size = new Size(547, 54);
            txtSalesOrderDate.TabIndex = 18;
            txtSalesOrderDate.Value = new DateTime(2024, 11, 8, 11, 53, 55, 455);
            // 
            // txtBranch
            // 
            txtBranch.AutoResize = false;
            txtBranch.BackColor = Color.FromArgb(255, 255, 255);
            txtBranch.Depth = 0;
            txtBranch.DrawMode = DrawMode.OwnerDrawVariable;
            txtBranch.DropDownHeight = 174;
            txtBranch.DropDownStyle = ComboBoxStyle.DropDownList;
            txtBranch.DropDownWidth = 121;
            txtBranch.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            txtBranch.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtBranch.FormattingEnabled = true;
            txtBranch.Hint = "Select Branch";
            txtBranch.IntegralHeight = false;
            txtBranch.ItemHeight = 43;
            txtBranch.Location = new Point(666, 195);
            txtBranch.Margin = new Padding(4, 5, 4, 5);
            txtBranch.MaxDropDownItems = 4;
            txtBranch.MouseState = MaterialSkin.MouseState.OUT;
            txtBranch.Name = "txtBranch";
            txtBranch.Size = new Size(548, 49);
            txtBranch.StartIndex = 0;
            txtBranch.TabIndex = 15;
            // 
            // txtId
            // 
            txtId.AnimateReadOnly = false;
            txtId.BorderStyle = BorderStyle.None;
            txtId.Depth = 0;
            txtId.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtId.Hint = "Sales Order # (Auto-Generated)";
            txtId.LeadingIcon = null;
            txtId.Location = new Point(1279, 59);
            txtId.Margin = new Padding(4, 5, 4, 5);
            txtId.MaxLength = 50;
            txtId.MouseState = MaterialSkin.MouseState.OUT;
            txtId.Multiline = false;
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(548, 50);
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
            txtName.Hint = "Enter Sales Order Name";
            txtName.LeadingIcon = null;
            txtName.Location = new Point(53, 132);
            txtName.Margin = new Padding(4, 5, 4, 5);
            txtName.MaxLength = 50;
            txtName.MouseState = MaterialSkin.MouseState.OUT;
            txtName.Multiline = false;
            txtName.Name = "txtName";
            txtName.Size = new Size(548, 50);
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
            materialLabel1.Size = new Size(205, 63);
            materialLabel1.TabIndex = 3;
            materialLabel1.Text = "Sales Order Details";
            materialLabel1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtCustomerRefNumber
            // 
            txtCustomerRefNumber.AnimateReadOnly = false;
            txtCustomerRefNumber.BorderStyle = BorderStyle.None;
            txtCustomerRefNumber.Depth = 0;
            txtCustomerRefNumber.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtCustomerRefNumber.Hint = "Enter Customer Reference Number";
            txtCustomerRefNumber.LeadingIcon = null;
            txtCustomerRefNumber.Location = new Point(1279, 126);
            txtCustomerRefNumber.Margin = new Padding(4, 5, 4, 5);
            txtCustomerRefNumber.MaxLength = 50;
            txtCustomerRefNumber.MouseState = MaterialSkin.MouseState.OUT;
            txtCustomerRefNumber.Multiline = false;
            txtCustomerRefNumber.Name = "txtCustomerRefNumber";
            txtCustomerRefNumber.Size = new Size(548, 50);
            txtCustomerRefNumber.TabIndex = 36;
            txtCustomerRefNumber.Text = "";
            txtCustomerRefNumber.TrailingIcon = null;
            // 
            // SalesOrderView
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(materialCard1);
            Margin = new Padding(4, 5, 4, 5);
            Name = "SalesOrderView";
            Size = new Size(1936, 1088);
            materialCard1.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgList).EndInit();
            tabPage2.ResumeLayout(false);
            materialCard2.ResumeLayout(false);
            materialCard2.PerformLayout();
            guna2GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgOrderLine).EndInit();
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
        private MaterialSkin.Controls.MaterialComboBox txtBranch;
        private Guna.UI2.WinForms.Guna2DateTimePicker txtSalesOrderDueDate;
        private Guna.UI2.WinForms.Guna2DateTimePicker txtSalesOrderDate;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialComboBox txtCustomer;
        private MaterialSkin.Controls.MaterialComboBox txtSalesType;
        private MaterialSkin.Controls.MaterialComboBox txtCurrency;
        private MaterialSkin.Controls.MaterialTextBox txtDiscount;
        private MaterialSkin.Controls.MaterialTextBox txtTax;
        private MaterialSkin.Controls.MaterialTextBox txtFreight;
        private MaterialSkin.Controls.MaterialTextBox txtTotal;
        private MaterialSkin.Controls.MaterialTextBox txtRemarks;
        private MaterialSkin.Controls.MaterialTextBox txtAmount;
        private MaterialSkin.Controls.MaterialTextBox txtSubTotal;
        private Guna.UI2.WinForms.Guna2DataGridView dgOrderLine;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private MaterialSkin.Controls.MaterialTextBox txtCustomerRefNumber;
    }
}
