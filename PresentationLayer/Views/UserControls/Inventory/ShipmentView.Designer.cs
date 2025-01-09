using Guna.UI2.WinForms;

namespace PresentationLayer.Views.UserControls
{
    partial class ShipmentView
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShipmentView));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            Guna2TabControl1 = new Guna2TabControl();
            tabPage1 = new TabPage();
            dgList = new Guna2DataGridView();
            tabPage2 = new TabPage();
            materialCard2 = new MaterialSkin.Controls.MaterialCard();
            txtIsFullShipment = new MaterialSkin.Controls.MaterialSwitch();
            txtWarehouse = new MaterialSkin.Controls.MaterialComboBox();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            txtShipmentType = new MaterialSkin.Controls.MaterialComboBox();
            txtShipmentDate = new Guna2DateTimePicker();
            txtSalesOrder = new MaterialSkin.Controls.MaterialComboBox();
            txtId = new MaterialSkin.Controls.MaterialTextBox();
            txtName = new MaterialSkin.Controls.MaterialTextBox();
            panel2 = new Panel();
            txtSearch = new Guna2TextBox();
            btnPrint = new Guna2Button();
            btnDelete = new Guna2Button();
            btnSave = new Guna2Button();
            btnEdit = new Guna2Button();
            btnAdd = new Guna2Button();
            btnReturn = new Guna2Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            guna2Separator1 = new Guna2Separator();
            tableLayoutPanel2 = new TableLayoutPanel();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
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
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(Guna2TabControl1);
            materialCard1.Controls.Add(panel2);
            materialCard1.Controls.Add(tableLayoutPanel1);
            materialCard1.Depth = 0;
            materialCard1.Dock = DockStyle.Fill;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(0, 0);
            materialCard1.Margin = new Padding(20, 22, 20, 22);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(20, 22, 20, 22);
            materialCard1.Size = new Size(2382, 1224);
            materialCard1.TabIndex = 2;
            // 
            // Guna2TabControl1
            // 
            Guna2TabControl1.Controls.Add(tabPage1);
            Guna2TabControl1.Controls.Add(tabPage2);
            Guna2TabControl1.Dock = DockStyle.Fill;
            Guna2TabControl1.ItemSize = new Size(180, 40);
            Guna2TabControl1.Location = new Point(20, 166);
            Guna2TabControl1.Margin = new Padding(4, 5, 4, 5);
            Guna2TabControl1.Name = "Guna2TabControl1";
            Guna2TabControl1.SelectedIndex = 0;
            Guna2TabControl1.Size = new Size(2342, 1036);
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
            tabPage1.Margin = new Padding(4, 5, 4, 5);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(4, 5, 4, 5);
            tabPage1.Size = new Size(2334, 988);
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
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgList.ColumnHeadersHeight = 50;
            dgList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(222, 0, 0, 0);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgList.DefaultCellStyle = dataGridViewCellStyle3;
            dgList.Dock = DockStyle.Fill;
            dgList.GridColor = Color.FromArgb(231, 229, 255);
            dgList.Location = new Point(4, 5);
            dgList.Margin = new Padding(4, 4, 4, 4);
            dgList.Name = "dgList";
            dgList.RowHeadersVisible = false;
            dgList.RowHeadersWidth = 51;
            dgList.RowTemplate.Height = 29;
            dgList.Size = new Size(2326, 978);
            dgList.TabIndex = 1;
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
            tabPage2.Margin = new Padding(4, 5, 4, 5);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(4, 5, 4, 5);
            tabPage2.Size = new Size(2334, 986);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Add New";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // materialCard2
            // 
            materialCard2.Anchor = AnchorStyles.None;
            materialCard2.BackColor = Color.FromArgb(255, 255, 255);
            materialCard2.Controls.Add(txtIsFullShipment);
            materialCard2.Controls.Add(txtWarehouse);
            materialCard2.Controls.Add(materialLabel2);
            materialCard2.Controls.Add(txtShipmentType);
            materialCard2.Controls.Add(txtShipmentDate);
            materialCard2.Controls.Add(txtSalesOrder);
            materialCard2.Controls.Add(txtId);
            materialCard2.Controls.Add(txtName);
            materialCard2.Depth = 0;
            materialCard2.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard2.Location = new Point(24, 29);
            materialCard2.Margin = new Padding(20, 22, 20, 22);
            materialCard2.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard2.Name = "materialCard2";
            materialCard2.Padding = new Padding(20, 22, 20, 22);
            materialCard2.Size = new Size(2285, 909);
            materialCard2.TabIndex = 0;
            // 
            // txtIsFullShipment
            // 
            txtIsFullShipment.AutoSize = true;
            txtIsFullShipment.Depth = 0;
            txtIsFullShipment.Location = new Point(736, 686);
            txtIsFullShipment.Margin = new Padding(0);
            txtIsFullShipment.MouseLocation = new Point(-1, -1);
            txtIsFullShipment.MouseState = MaterialSkin.MouseState.HOVER;
            txtIsFullShipment.Name = "txtIsFullShipment";
            txtIsFullShipment.Ripple = true;
            txtIsFullShipment.Size = new Size(164, 37);
            txtIsFullShipment.TabIndex = 23;
            txtIsFullShipment.Text = "Full Shipment?";
            txtIsFullShipment.UseVisualStyleBackColor = true;
            // 
            // txtWarehouse
            // 
            txtWarehouse.AutoResize = false;
            txtWarehouse.BackColor = Color.FromArgb(255, 255, 255);
            txtWarehouse.Depth = 0;
            txtWarehouse.DrawMode = DrawMode.OwnerDrawVariable;
            txtWarehouse.DropDownHeight = 174;
            txtWarehouse.DropDownStyle = ComboBoxStyle.DropDownList;
            txtWarehouse.DropDownWidth = 121;
            txtWarehouse.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            txtWarehouse.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtWarehouse.FormattingEnabled = true;
            txtWarehouse.Hint = "Select Warehouse";
            txtWarehouse.IntegralHeight = false;
            txtWarehouse.ItemHeight = 43;
            txtWarehouse.Location = new Point(738, 604);
            txtWarehouse.Margin = new Padding(4, 5, 4, 5);
            txtWarehouse.MaxDropDownItems = 4;
            txtWarehouse.MouseState = MaterialSkin.MouseState.OUT;
            txtWarehouse.Name = "txtWarehouse";
            txtWarehouse.Size = new Size(406, 49);
            txtWarehouse.StartIndex = 0;
            txtWarehouse.TabIndex = 22;
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.Location = new Point(738, 382);
            materialLabel2.Margin = new Padding(2, 0, 2, 0);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(106, 19);
            materialLabel2.TabIndex = 21;
            materialLabel2.Text = "Shipment Date";
            // 
            // txtShipmentType
            // 
            txtShipmentType.AutoResize = false;
            txtShipmentType.BackColor = Color.FromArgb(255, 255, 255);
            txtShipmentType.Depth = 0;
            txtShipmentType.DrawMode = DrawMode.OwnerDrawVariable;
            txtShipmentType.DropDownHeight = 174;
            txtShipmentType.DropDownStyle = ComboBoxStyle.DropDownList;
            txtShipmentType.DropDownWidth = 121;
            txtShipmentType.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            txtShipmentType.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtShipmentType.FormattingEnabled = true;
            txtShipmentType.Hint = "Select Shipment Type";
            txtShipmentType.IntegralHeight = false;
            txtShipmentType.ItemHeight = 43;
            txtShipmentType.Location = new Point(738, 522);
            txtShipmentType.Margin = new Padding(4, 5, 4, 5);
            txtShipmentType.MaxDropDownItems = 4;
            txtShipmentType.MouseState = MaterialSkin.MouseState.OUT;
            txtShipmentType.Name = "txtShipmentType";
            txtShipmentType.Size = new Size(406, 49);
            txtShipmentType.StartIndex = 0;
            txtShipmentType.TabIndex = 20;
            // 
            // txtShipmentDate
            // 
            txtShipmentDate.Checked = true;
            txtShipmentDate.CustomizableEdges = customizableEdges1;
            txtShipmentDate.Font = new Font("Segoe UI", 9F);
            txtShipmentDate.Format = DateTimePickerFormat.Long;
            txtShipmentDate.Location = new Point(738, 435);
            txtShipmentDate.Margin = new Padding(2);
            txtShipmentDate.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            txtShipmentDate.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            txtShipmentDate.Name = "txtShipmentDate";
            txtShipmentDate.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtShipmentDate.Size = new Size(405, 54);
            txtShipmentDate.TabIndex = 18;
            txtShipmentDate.Value = new DateTime(2024, 11, 8, 11, 53, 55, 455);
            // 
            // txtSalesOrder
            // 
            txtSalesOrder.AutoResize = false;
            txtSalesOrder.BackColor = Color.FromArgb(255, 255, 255);
            txtSalesOrder.Depth = 0;
            txtSalesOrder.DrawMode = DrawMode.OwnerDrawVariable;
            txtSalesOrder.DropDownHeight = 174;
            txtSalesOrder.DropDownStyle = ComboBoxStyle.DropDownList;
            txtSalesOrder.DropDownWidth = 121;
            txtSalesOrder.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            txtSalesOrder.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtSalesOrder.FormattingEnabled = true;
            txtSalesOrder.Hint = "Select Sales Order";
            txtSalesOrder.IntegralHeight = false;
            txtSalesOrder.ItemHeight = 43;
            txtSalesOrder.Location = new Point(738, 301);
            txtSalesOrder.Margin = new Padding(4, 5, 4, 5);
            txtSalesOrder.MaxDropDownItems = 4;
            txtSalesOrder.MouseState = MaterialSkin.MouseState.OUT;
            txtSalesOrder.Name = "txtSalesOrder";
            txtSalesOrder.Size = new Size(406, 49);
            txtSalesOrder.StartIndex = 0;
            txtSalesOrder.TabIndex = 15;
            // 
            // txtId
            // 
            txtId.AnimateReadOnly = false;
            txtId.BorderStyle = BorderStyle.None;
            txtId.Depth = 0;
            txtId.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtId.Hint = "Id";
            txtId.LeadingIcon = null;
            txtId.Location = new Point(738, 135);
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
            txtName.Hint = "Enter Shipment #";
            txtName.LeadingIcon = null;
            txtName.Location = new Point(738, 218);
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
            panel2.BackColor = Color.White;
            panel2.Controls.Add(txtSearch);
            panel2.Controls.Add(btnPrint);
            panel2.Controls.Add(btnDelete);
            panel2.Controls.Add(btnSave);
            panel2.Controls.Add(btnEdit);
            panel2.Controls.Add(btnAdd);
            panel2.Controls.Add(btnReturn);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(20, 104);
            panel2.Margin = new Padding(4, 16, 4, 5);
            panel2.Name = "panel2";
            panel2.Size = new Size(2342, 62);
            panel2.TabIndex = 6;
            // 
            // txtSearch
            // 
            txtSearch.CustomizableEdges = customizableEdges3;
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
            txtSearch.Location = new Point(1870, 0);
            txtSearch.Margin = new Padding(4, 5, 4, 5);
            txtSearch.Name = "txtSearch";
            txtSearch.PasswordChar = '\0';
            txtSearch.PlaceholderText = "Search here";
            txtSearch.SelectedText = "";
            txtSearch.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtSearch.Size = new Size(472, 62);
            txtSearch.TabIndex = 11;
            // 
            // btnPrint
            // 
            btnPrint.CustomizableEdges = customizableEdges5;
            btnPrint.DisabledState.BorderColor = Color.DarkGray;
            btnPrint.DisabledState.CustomBorderColor = Color.DarkGray;
            btnPrint.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnPrint.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnPrint.Dock = DockStyle.Left;
            btnPrint.FillColor = Color.Transparent;
            btnPrint.Font = new Font("Segoe UI", 9F);
            btnPrint.ForeColor = Color.White;
            btnPrint.Image = (Image)resources.GetObject("btnPrint.Image");
            btnPrint.ImageSize = new Size(30, 30);
            btnPrint.Location = new Point(310, 0);
            btnPrint.Margin = new Padding(4, 4, 4, 4);
            btnPrint.Name = "btnPrint";
            btnPrint.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnPrint.Size = new Size(62, 62);
            btnPrint.TabIndex = 10;
            // 
            // btnDelete
            // 
            btnDelete.CustomizableEdges = customizableEdges7;
            btnDelete.DisabledState.BorderColor = Color.DarkGray;
            btnDelete.DisabledState.CustomBorderColor = Color.DarkGray;
            btnDelete.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnDelete.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnDelete.Dock = DockStyle.Left;
            btnDelete.FillColor = Color.Transparent;
            btnDelete.Font = new Font("Segoe UI", 9F);
            btnDelete.ForeColor = Color.White;
            btnDelete.Image = (Image)resources.GetObject("btnDelete.Image");
            btnDelete.ImageSize = new Size(30, 30);
            btnDelete.Location = new Point(248, 0);
            btnDelete.Margin = new Padding(4, 4, 4, 4);
            btnDelete.Name = "btnDelete";
            btnDelete.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnDelete.Size = new Size(62, 62);
            btnDelete.TabIndex = 9;
            // 
            // btnSave
            // 
            btnSave.CustomizableEdges = customizableEdges9;
            btnSave.DisabledState.BorderColor = Color.DarkGray;
            btnSave.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSave.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSave.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSave.Dock = DockStyle.Left;
            btnSave.FillColor = Color.Transparent;
            btnSave.Font = new Font("Segoe UI", 9F);
            btnSave.ForeColor = Color.White;
            btnSave.Image = (Image)resources.GetObject("btnSave.Image");
            btnSave.ImageSize = new Size(30, 30);
            btnSave.Location = new Point(186, 0);
            btnSave.Margin = new Padding(4, 4, 4, 4);
            btnSave.Name = "btnSave";
            btnSave.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnSave.Size = new Size(62, 62);
            btnSave.TabIndex = 8;
            // 
            // btnEdit
            // 
            btnEdit.CustomizableEdges = customizableEdges11;
            btnEdit.DisabledState.BorderColor = Color.DarkGray;
            btnEdit.DisabledState.CustomBorderColor = Color.DarkGray;
            btnEdit.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnEdit.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnEdit.Dock = DockStyle.Left;
            btnEdit.FillColor = Color.Transparent;
            btnEdit.Font = new Font("Segoe UI", 9F);
            btnEdit.ForeColor = Color.White;
            btnEdit.Image = (Image)resources.GetObject("btnEdit.Image");
            btnEdit.ImageSize = new Size(30, 30);
            btnEdit.Location = new Point(124, 0);
            btnEdit.Margin = new Padding(4, 4, 4, 4);
            btnEdit.Name = "btnEdit";
            btnEdit.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnEdit.Size = new Size(62, 62);
            btnEdit.TabIndex = 7;
            // 
            // btnAdd
            // 
            btnAdd.CustomizableEdges = customizableEdges13;
            btnAdd.DisabledState.BorderColor = Color.DarkGray;
            btnAdd.DisabledState.CustomBorderColor = Color.DarkGray;
            btnAdd.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnAdd.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnAdd.Dock = DockStyle.Left;
            btnAdd.FillColor = Color.Transparent;
            btnAdd.Font = new Font("Segoe UI", 9F);
            btnAdd.ForeColor = Color.White;
            btnAdd.Image = (Image)resources.GetObject("btnAdd.Image");
            btnAdd.ImageSize = new Size(30, 30);
            btnAdd.Location = new Point(62, 0);
            btnAdd.Margin = new Padding(4, 4, 4, 4);
            btnAdd.Name = "btnAdd";
            btnAdd.ShadowDecoration.CustomizableEdges = customizableEdges14;
            btnAdd.Size = new Size(62, 62);
            btnAdd.TabIndex = 6;
            // 
            // btnReturn
            // 
            btnReturn.CustomizableEdges = customizableEdges15;
            btnReturn.DisabledState.BorderColor = Color.DarkGray;
            btnReturn.DisabledState.CustomBorderColor = Color.DarkGray;
            btnReturn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnReturn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnReturn.Dock = DockStyle.Left;
            btnReturn.FillColor = Color.Transparent;
            btnReturn.Font = new Font("Segoe UI", 9F);
            btnReturn.ForeColor = Color.White;
            btnReturn.Image = (Image)resources.GetObject("btnReturn.Image");
            btnReturn.ImageSize = new Size(30, 30);
            btnReturn.Location = new Point(0, 0);
            btnReturn.Margin = new Padding(4, 4, 4, 4);
            btnReturn.Name = "btnReturn";
            btnReturn.ShadowDecoration.CustomizableEdges = customizableEdges16;
            btnReturn.Size = new Size(62, 62);
            btnReturn.TabIndex = 5;
            btnReturn.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(guna2Separator1, 0, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(20, 22);
            tableLayoutPanel1.Margin = new Padding(4, 5, 4, 5);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 76F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 24F));
            tableLayoutPanel1.Size = new Size(2342, 82);
            tableLayoutPanel1.TabIndex = 5;
            // 
            // guna2Separator1
            // 
            guna2Separator1.Dock = DockStyle.Fill;
            guna2Separator1.Location = new Point(4, 66);
            guna2Separator1.Margin = new Padding(4, 4, 4, 4);
            guna2Separator1.Name = "guna2Separator1";
            guna2Separator1.Size = new Size(2334, 12);
            guna2Separator1.TabIndex = 2;
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
            tableLayoutPanel2.Size = new Size(2342, 62);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
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
            materialLabel1.Size = new Size(257, 62);
            materialLabel1.TabIndex = 3;
            materialLabel1.Text = "Shipment Details";
            materialLabel1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ShipmentView
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(materialCard1);
            Margin = new Padding(4, 5, 4, 5);
            Name = "ShipmentView";
            Size = new Size(2382, 1224);
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
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialCard materialCard1;
        private Guna2TabControl Guna2TabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private MaterialSkin.Controls.MaterialCard materialCard2;
        private MaterialSkin.Controls.MaterialTextBox txtId;
        private MaterialSkin.Controls.MaterialTextBox txtName;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialComboBox txtSalesOrder;
        private MaterialSkin.Controls.MaterialComboBox txtShipmentType;
        private Guna.UI2.WinForms.Guna2DateTimePicker txtShipmentDate;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialComboBox txtWarehouse;
        private MaterialSkin.Controls.MaterialSwitch txtIsFullShipment;
        private Guna2DataGridView dgList;
        private Guna2Separator guna2Separator1;
        private Panel panel2;
        private Guna2TextBox txtSearch;
        private Guna2Button btnPrint;
        private Guna2Button btnDelete;
        private Guna2Button btnSave;
        private Guna2Button btnEdit;
        private Guna2Button btnAdd;
        private Guna2Button btnReturn;
    }
}
