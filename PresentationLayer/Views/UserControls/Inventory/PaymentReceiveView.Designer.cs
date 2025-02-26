using Guna.UI2.WinForms;

namespace PresentationLayer.Views.UserControls
{
    partial class PaymentReceiveView
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaymentReceiveView));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            Guna2TabControl1 = new Guna2TabControl();
            tabPage1 = new TabPage();
            dgList = new Guna2DataGridView();
            tabPage2 = new TabPage();
            materialCard3 = new MaterialSkin.Controls.MaterialCard();
            txtPaymentAmount = new Guna2TextBox();
            guna2HtmlLabel8 = new Guna2HtmlLabel();
            txtName = new Guna2TextBox();
            guna2HtmlLabel10 = new Guna2HtmlLabel();
            txtIsFullPayment = new Guna2ToggleSwitch();
            guna2HtmlLabel11 = new Guna2HtmlLabel();
            txtInvoice = new Guna2ComboBox();
            txtPaymentDate = new Guna2DateTimePicker();
            guna2HtmlLabel12 = new Guna2HtmlLabel();
            guna2HtmlLabel13 = new Guna2HtmlLabel();
            guna2HtmlLabel14 = new Guna2HtmlLabel();
            txtPaymentType = new Guna2ComboBox();
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
            guna2Separator1 = new Guna2Separator();
            tableLayoutPanel2 = new TableLayoutPanel();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            guna2HtmlToolTip2 = new Guna2HtmlToolTip();
            materialCard1.SuspendLayout();
            Guna2TabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgList).BeginInit();
            tabPage2.SuspendLayout();
            materialCard3.SuspendLayout();
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
            materialCard1.Margin = new Padding(14, 13, 14, 13);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(14, 13, 14, 13);
            materialCard1.Size = new Size(1667, 734);
            materialCard1.TabIndex = 2;
            // 
            // Guna2TabControl1
            // 
            Guna2TabControl1.Controls.Add(tabPage1);
            Guna2TabControl1.Controls.Add(tabPage2);
            Guna2TabControl1.Dock = DockStyle.Fill;
            Guna2TabControl1.ItemSize = new Size(180, 40);
            Guna2TabControl1.Location = new Point(14, 124);
            Guna2TabControl1.Name = "Guna2TabControl1";
            Guna2TabControl1.SelectedIndex = 0;
            Guna2TabControl1.Size = new Size(1639, 597);
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
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1631, 549);
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
            dgList.Location = new Point(3, 3);
            dgList.Margin = new Padding(3, 2, 3, 2);
            dgList.Name = "dgList";
            dgList.RowHeadersVisible = false;
            dgList.RowHeadersWidth = 51;
            dgList.RowTemplate.Height = 29;
            dgList.Size = new Size(1625, 543);
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
            tabPage2.Controls.Add(materialCard3);
            tabPage2.Location = new Point(4, 44);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1631, 549);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Add New";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // materialCard3
            // 
            materialCard3.BackColor = Color.FromArgb(255, 255, 255);
            materialCard3.Controls.Add(txtPaymentAmount);
            materialCard3.Controls.Add(guna2HtmlLabel8);
            materialCard3.Controls.Add(txtName);
            materialCard3.Controls.Add(guna2HtmlLabel10);
            materialCard3.Controls.Add(txtIsFullPayment);
            materialCard3.Controls.Add(guna2HtmlLabel11);
            materialCard3.Controls.Add(txtInvoice);
            materialCard3.Controls.Add(txtPaymentDate);
            materialCard3.Controls.Add(guna2HtmlLabel12);
            materialCard3.Controls.Add(guna2HtmlLabel13);
            materialCard3.Controls.Add(guna2HtmlLabel14);
            materialCard3.Controls.Add(txtPaymentType);
            materialCard3.Depth = 0;
            materialCard3.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard3.Location = new Point(17, 17);
            materialCard3.Margin = new Padding(14, 13, 14, 13);
            materialCard3.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard3.Name = "materialCard3";
            materialCard3.Padding = new Padding(14, 13, 14, 13);
            materialCard3.Size = new Size(1600, 545);
            materialCard3.TabIndex = 3;
            // 
            // txtPaymentAmount
            // 
            txtPaymentAmount.Anchor = AnchorStyles.None;
            txtPaymentAmount.CustomizableEdges = customizableEdges1;
            txtPaymentAmount.DefaultText = "";
            txtPaymentAmount.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtPaymentAmount.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtPaymentAmount.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtPaymentAmount.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtPaymentAmount.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPaymentAmount.Font = new Font("Segoe UI", 10.2F);
            txtPaymentAmount.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPaymentAmount.Location = new Point(826, 160);
            txtPaymentAmount.Margin = new Padding(3, 4, 3, 4);
            txtPaymentAmount.Name = "txtPaymentAmount";
            txtPaymentAmount.PasswordChar = '\0';
            txtPaymentAmount.PlaceholderText = "Enter Payment Amount";
            txtPaymentAmount.SelectedText = "";
            txtPaymentAmount.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtPaymentAmount.Size = new Size(449, 42);
            txtPaymentAmount.TabIndex = 65;
            // 
            // guna2HtmlLabel8
            // 
            guna2HtmlLabel8.Anchor = AnchorStyles.None;
            guna2HtmlLabel8.BackColor = Color.Transparent;
            guna2HtmlLabel8.Font = new Font("Segoe UI", 10.2F);
            guna2HtmlLabel8.Location = new Point(826, 116);
            guna2HtmlLabel8.Margin = new Padding(3, 2, 3, 2);
            guna2HtmlLabel8.Name = "guna2HtmlLabel8";
            guna2HtmlLabel8.Size = new Size(111, 21);
            guna2HtmlLabel8.TabIndex = 64;
            guna2HtmlLabel8.Text = "Payment Amount";
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
            txtName.Font = new Font("Segoe UI", 10.2F);
            txtName.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtName.Location = new Point(326, 160);
            txtName.Margin = new Padding(3, 4, 3, 4);
            txtName.Name = "txtName";
            txtName.PasswordChar = '\0';
            txtName.PlaceholderText = "Enter Payment Received #";
            txtName.SelectedText = "";
            txtName.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtName.Size = new Size(449, 42);
            txtName.TabIndex = 63;
            // 
            // guna2HtmlLabel10
            // 
            guna2HtmlLabel10.Anchor = AnchorStyles.None;
            guna2HtmlLabel10.BackColor = Color.Transparent;
            guna2HtmlLabel10.Font = new Font("Segoe UI", 12F);
            guna2HtmlLabel10.Location = new Point(906, 393);
            guna2HtmlLabel10.Margin = new Padding(3, 2, 3, 2);
            guna2HtmlLabel10.Name = "guna2HtmlLabel10";
            guna2HtmlLabel10.Size = new Size(100, 23);
            guna2HtmlLabel10.TabIndex = 62;
            guna2HtmlLabel10.Text = "Full Payment?";
            // 
            // txtIsFullPayment
            // 
            txtIsFullPayment.Anchor = AnchorStyles.None;
            txtIsFullPayment.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtIsFullPayment.CheckedState.FillColor = Color.FromArgb(94, 148, 255);
            txtIsFullPayment.CheckedState.InnerBorderColor = Color.White;
            txtIsFullPayment.CheckedState.InnerColor = Color.White;
            txtIsFullPayment.CustomizableEdges = customizableEdges5;
            txtIsFullPayment.Location = new Point(837, 385);
            txtIsFullPayment.Margin = new Padding(3, 2, 3, 2);
            txtIsFullPayment.Name = "txtIsFullPayment";
            txtIsFullPayment.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtIsFullPayment.Size = new Size(55, 30);
            txtIsFullPayment.TabIndex = 61;
            txtIsFullPayment.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
            txtIsFullPayment.UncheckedState.FillColor = Color.FromArgb(125, 137, 149);
            txtIsFullPayment.UncheckedState.InnerBorderColor = Color.White;
            txtIsFullPayment.UncheckedState.InnerColor = Color.White;
            // 
            // guna2HtmlLabel11
            // 
            guna2HtmlLabel11.Anchor = AnchorStyles.None;
            guna2HtmlLabel11.BackColor = Color.Transparent;
            guna2HtmlLabel11.Font = new Font("Segoe UI", 10.2F);
            guna2HtmlLabel11.Location = new Point(326, 228);
            guna2HtmlLabel11.Margin = new Padding(3, 2, 3, 2);
            guna2HtmlLabel11.Name = "guna2HtmlLabel11";
            guna2HtmlLabel11.Size = new Size(58, 21);
            guna2HtmlLabel11.TabIndex = 60;
            guna2HtmlLabel11.Text = "Invoice #";
            // 
            // txtInvoice
            // 
            txtInvoice.Anchor = AnchorStyles.None;
            txtInvoice.BackColor = Color.Transparent;
            txtInvoice.CustomizableEdges = customizableEdges7;
            txtInvoice.DisplayMember = "BillTypeId";
            txtInvoice.DrawMode = DrawMode.OwnerDrawFixed;
            txtInvoice.DropDownStyle = ComboBoxStyle.DropDownList;
            txtInvoice.FocusedColor = Color.FromArgb(94, 148, 255);
            txtInvoice.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtInvoice.Font = new Font("Segoe UI", 10.2F);
            txtInvoice.ForeColor = Color.FromArgb(68, 88, 112);
            txtInvoice.ItemHeight = 38;
            txtInvoice.Location = new Point(326, 272);
            txtInvoice.Margin = new Padding(3, 2, 3, 2);
            txtInvoice.Name = "txtInvoice";
            txtInvoice.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtInvoice.Size = new Size(451, 44);
            txtInvoice.TabIndex = 59;
            txtInvoice.ValueMember = "BillTypeId";
            // 
            // txtPaymentDate
            // 
            txtPaymentDate.Anchor = AnchorStyles.None;
            txtPaymentDate.Checked = true;
            txtPaymentDate.CustomizableEdges = customizableEdges9;
            txtPaymentDate.FillColor = Color.MidnightBlue;
            txtPaymentDate.Font = new Font("Segoe UI", 10.2F);
            txtPaymentDate.ForeColor = Color.White;
            txtPaymentDate.Format = DateTimePickerFormat.Long;
            txtPaymentDate.Location = new Point(826, 272);
            txtPaymentDate.Margin = new Padding(3, 2, 3, 2);
            txtPaymentDate.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            txtPaymentDate.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            txtPaymentDate.Name = "txtPaymentDate";
            txtPaymentDate.ShadowDecoration.CustomizableEdges = customizableEdges10;
            txtPaymentDate.Size = new Size(449, 45);
            txtPaymentDate.TabIndex = 54;
            txtPaymentDate.Value = new DateTime(2024, 11, 27, 9, 17, 37, 932);
            // 
            // guna2HtmlLabel12
            // 
            guna2HtmlLabel12.Anchor = AnchorStyles.None;
            guna2HtmlLabel12.BackColor = Color.Transparent;
            guna2HtmlLabel12.Font = new Font("Segoe UI", 10.2F);
            guna2HtmlLabel12.Location = new Point(826, 228);
            guna2HtmlLabel12.Margin = new Padding(3, 2, 3, 2);
            guna2HtmlLabel12.Name = "guna2HtmlLabel12";
            guna2HtmlLabel12.Size = new Size(90, 21);
            guna2HtmlLabel12.TabIndex = 52;
            guna2HtmlLabel12.Text = "Payment Date";
            // 
            // guna2HtmlLabel13
            // 
            guna2HtmlLabel13.Anchor = AnchorStyles.None;
            guna2HtmlLabel13.BackColor = Color.Transparent;
            guna2HtmlLabel13.Font = new Font("Segoe UI", 10.2F);
            guna2HtmlLabel13.Location = new Point(326, 340);
            guna2HtmlLabel13.Margin = new Padding(3, 2, 3, 2);
            guna2HtmlLabel13.Name = "guna2HtmlLabel13";
            guna2HtmlLabel13.Size = new Size(90, 21);
            guna2HtmlLabel13.TabIndex = 48;
            guna2HtmlLabel13.Text = "Payment Type";
            // 
            // guna2HtmlLabel14
            // 
            guna2HtmlLabel14.Anchor = AnchorStyles.None;
            guna2HtmlLabel14.BackColor = Color.Transparent;
            guna2HtmlLabel14.Font = new Font("Segoe UI", 10.2F);
            guna2HtmlLabel14.Location = new Point(326, 116);
            guna2HtmlLabel14.Margin = new Padding(3, 2, 3, 2);
            guna2HtmlLabel14.Name = "guna2HtmlLabel14";
            guna2HtmlLabel14.Size = new Size(118, 21);
            guna2HtmlLabel14.TabIndex = 47;
            guna2HtmlLabel14.Text = "Payment Receive #";
            // 
            // txtPaymentType
            // 
            txtPaymentType.Anchor = AnchorStyles.None;
            txtPaymentType.BackColor = Color.Transparent;
            txtPaymentType.CustomizableEdges = customizableEdges11;
            txtPaymentType.DisplayMember = "BillTypeId";
            txtPaymentType.DrawMode = DrawMode.OwnerDrawFixed;
            txtPaymentType.DropDownStyle = ComboBoxStyle.DropDownList;
            txtPaymentType.FocusedColor = Color.FromArgb(94, 148, 255);
            txtPaymentType.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPaymentType.Font = new Font("Segoe UI", 10.2F);
            txtPaymentType.ForeColor = Color.FromArgb(68, 88, 112);
            txtPaymentType.ItemHeight = 38;
            txtPaymentType.Location = new Point(326, 385);
            txtPaymentType.Margin = new Padding(3, 2, 3, 2);
            txtPaymentType.Name = "txtPaymentType";
            txtPaymentType.ShadowDecoration.CustomizableEdges = customizableEdges12;
            txtPaymentType.Size = new Size(451, 44);
            txtPaymentType.TabIndex = 45;
            txtPaymentType.ValueMember = "BillTypeId";
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
            panel2.Location = new Point(14, 62);
            panel2.Margin = new Padding(3, 13, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(1639, 62);
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
            txtSearch.CustomizableEdges = customizableEdges13;
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
            txtSearch.Location = new Point(1261, 0);
            txtSearch.Margin = new Padding(3, 4, 3, 4);
            txtSearch.Name = "txtSearch";
            txtSearch.PasswordChar = '\0';
            txtSearch.PlaceholderText = "Search here";
            txtSearch.SelectedText = "";
            txtSearch.ShadowDecoration.CustomizableEdges = customizableEdges14;
            txtSearch.Size = new Size(378, 62);
            txtSearch.TabIndex = 11;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(guna2Separator1, 0, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(14, 13);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 76F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 24F));
            tableLayoutPanel1.Size = new Size(1639, 49);
            tableLayoutPanel1.TabIndex = 5;
            // 
            // guna2Separator1
            // 
            guna2Separator1.Dock = DockStyle.Fill;
            guna2Separator1.Location = new Point(3, 39);
            guna2Separator1.Margin = new Padding(3, 2, 3, 2);
            guna2Separator1.Name = "guna2Separator1";
            guna2Separator1.Size = new Size(1633, 8);
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
            tableLayoutPanel2.Size = new Size(1639, 37);
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
            materialLabel1.Location = new Point(3, 0);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(372, 37);
            materialLabel1.TabIndex = 3;
            materialLabel1.Text = "Payment Receive Details";
            materialLabel1.TextAlign = ContentAlignment.MiddleLeft;
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
            // PaymentReceiveView
            // 
            AutoScaleMode = AutoScaleMode.Inherit;
            Controls.Add(materialCard1);
            Name = "PaymentReceiveView";
            Size = new Size(1667, 734);
            materialCard1.ResumeLayout(false);
            Guna2TabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgList).EndInit();
            tabPage2.ResumeLayout(false);
            materialCard3.ResumeLayout(false);
            materialCard3.PerformLayout();
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
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private Guna2DataGridView dgList;
        private Guna2Separator guna2Separator1;
        private MaterialSkin.Controls.MaterialCard materialCard3;
        private Guna2TextBox txtPaymentAmount;
        private Guna2HtmlLabel guna2HtmlLabel8;
        private Guna2TextBox txtName;
        private Guna2HtmlLabel guna2HtmlLabel10;
        private Guna2ToggleSwitch txtIsFullPayment;
        private Guna2HtmlLabel guna2HtmlLabel11;
        private Guna2ComboBox txtInvoice;
        private Guna2DateTimePicker txtPaymentDate;
        private Guna2HtmlLabel guna2HtmlLabel12;
        private Guna2HtmlLabel guna2HtmlLabel13;
        private Guna2HtmlLabel guna2HtmlLabel14;
        private Guna2ComboBox txtPaymentType;
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
