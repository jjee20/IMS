namespace RavenTech_ERP.Views.UserControls.Inventory
{
    partial class UpsertExamView
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            var gridTextColumn1 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            var gridComboBoxColumn1 = new Syncfusion.WinForms.DataGrid.GridComboBoxColumn();
            var gridTextColumn2 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            var gridTextColumn3 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            var gridTextColumn4 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            var gridTextColumn5 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            var gridTextColumn6 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            var gridImageColumn1 = new Syncfusion.WinForms.DataGrid.GridImageColumn();
            var stackedHeaderRow1 = new Syncfusion.WinForms.DataGrid.StackedHeaderRow();
            var stackedColumn1 = new Syncfusion.WinForms.DataGrid.StackedColumn();
            var gridTableSummaryRow1 = new Syncfusion.WinForms.DataGrid.GridTableSummaryRow();
            var gridSummaryColumn1 = new Syncfusion.WinForms.DataGrid.GridSummaryColumn();
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(UpsertExamView));
            autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtTitle = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            btnSave = new Syncfusion.WinForms.Controls.SfButton();
            autoLabel3 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtDate = new Syncfusion.WinForms.Input.SfDateTimeEdit();
            txtExamFormat = new Syncfusion.WinForms.ListView.SfComboBox();
            dgList = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            panel1 = new Panel();
            panel2 = new Panel();
            ((System.ComponentModel.ISupportInitialize)txtTitle).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtExamFormat).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgList).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // autoLabel1
            // 
            autoLabel1.Location = new Point(13, 44);
            autoLabel1.Margin = new Padding(4, 0, 4, 0);
            autoLabel1.Name = "autoLabel1";
            autoLabel1.Size = new Size(44, 25);
            autoLabel1.TabIndex = 0;
            autoLabel1.Text = "Title";
            // 
            // txtTitle
            // 
            txtTitle.BeforeTouchSize = new Size(293, 31);
            txtTitle.Location = new Point(65, 38);
            txtTitle.Margin = new Padding(4, 5, 4, 5);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(293, 31);
            txtTitle.TabIndex = 1;
            // 
            // autoLabel2
            // 
            autoLabel2.Location = new Point(378, 44);
            autoLabel2.Margin = new Padding(4, 0, 4, 0);
            autoLabel2.Name = "autoLabel2";
            autoLabel2.Size = new Size(49, 25);
            autoLabel2.TabIndex = 2;
            autoLabel2.Text = "Date";
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI Semibold", 9F);
            btnSave.Location = new Point(1196, 22);
            btnSave.Margin = new Padding(4, 5, 4, 5);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(137, 47);
            btnSave.TabIndex = 4;
            btnSave.Text = "Save";
            btnSave.Click += btnSave_Click;
            // 
            // autoLabel3
            // 
            autoLabel3.Location = new Point(752, 44);
            autoLabel3.Margin = new Padding(4, 0, 4, 0);
            autoLabel3.Name = "autoLabel3";
            autoLabel3.Size = new Size(116, 25);
            autoLabel3.TabIndex = 5;
            autoLabel3.Text = "Exam Format";
            // 
            // txtDate
            // 
            txtDate.DateTimeIcon = null;
            txtDate.Location = new Point(434, 36);
            txtDate.Name = "txtDate";
            txtDate.Size = new Size(293, 33);
            txtDate.TabIndex = 8;
            txtDate.ToolTipText = "";
            // 
            // txtExamFormat
            // 
            txtExamFormat.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            txtExamFormat.Location = new Point(875, 33);
            txtExamFormat.Name = "txtExamFormat";
            txtExamFormat.Size = new Size(293, 36);
            txtExamFormat.Style.TokenStyle.CloseButtonBackColor = Color.FromArgb(255, 255, 255);
            txtExamFormat.TabIndex = 9;
            txtExamFormat.TabStop = false;
            // 
            // dgList
            // 
            dgList.AccessibleName = "Table";
            dgList.AddNewRowPosition = Syncfusion.WinForms.DataGrid.Enums.RowPosition.FixedTop;
            dgList.AddNewRowText = "Click here to add new question";
            dgList.AllowDeleting = true;
            dgList.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.Fill;
            gridTextColumn1.HeaderText = "Question";
            gridTextColumn1.MappingName = "Question";
            gridComboBoxColumn1.DisplayMember = "Name";
            gridComboBoxColumn1.HeaderText = "Topic";
            gridComboBoxColumn1.MappingName = "ExamTopicId";
            gridComboBoxColumn1.MaximumWidth = 200D;
            gridComboBoxColumn1.MinimumWidth = 200D;
            gridComboBoxColumn1.ValueMember = "ExamTopicId";
            gridTextColumn2.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.AllCells;
            gridTextColumn2.HeaderText = "#1";
            gridTextColumn2.MappingName = "Choice1";
            gridTextColumn3.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.AllCells;
            gridTextColumn3.HeaderText = "#2";
            gridTextColumn3.MappingName = "Choice2";
            gridTextColumn4.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.AllCells;
            gridTextColumn4.HeaderText = "#3";
            gridTextColumn4.MappingName = "Choice3";
            gridTextColumn5.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.AllCells;
            gridTextColumn5.HeaderText = "#4";
            gridTextColumn5.MappingName = "Choice4";
            gridTextColumn6.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.AllCells;
            gridTextColumn6.HeaderText = "Answer";
            gridTextColumn6.MappingName = "Answer";
            gridImageColumn1.AllowGrouping = false;
            gridImageColumn1.AllowSorting = false;
            gridImageColumn1.HeaderText = " ";
            gridImageColumn1.MappingName = "Delete";
            gridImageColumn1.MaximumWidth = 30D;
            gridImageColumn1.MinimumWidth = 30D;
            dgList.Columns.Add(gridTextColumn1);
            dgList.Columns.Add(gridComboBoxColumn1);
            dgList.Columns.Add(gridTextColumn2);
            dgList.Columns.Add(gridTextColumn3);
            dgList.Columns.Add(gridTextColumn4);
            dgList.Columns.Add(gridTextColumn5);
            dgList.Columns.Add(gridTextColumn6);
            dgList.Columns.Add(gridImageColumn1);
            dgList.Dock = DockStyle.Fill;
            dgList.Location = new Point(0, 0);
            dgList.Name = "dgList";
            dgList.NewItemPlaceholderPosition = Syncfusion.Data.NewItemPlaceholderPosition.AtBeginning;
            dgList.PreviewRowHeight = 42;
            dgList.Size = new Size(1346, 635);
            stackedHeaderRow1.Name = "StackedHeaderRow1";
            stackedColumn1.ChildColumns = "Choice1,Choice2,Choice3,Choice4";
            stackedColumn1.HeaderText = "Choices";
            stackedHeaderRow1.StackedColumns.Add(stackedColumn1);
            dgList.StackedHeaderRows.Add(stackedHeaderRow1);
            dgList.Style.BorderColor = Color.FromArgb(100, 100, 100);
            dgList.Style.CheckBoxStyle.CheckedBackColor = Color.FromArgb(0, 120, 215);
            dgList.Style.CheckBoxStyle.CheckedBorderColor = Color.FromArgb(0, 120, 215);
            dgList.Style.CheckBoxStyle.IndeterminateBorderColor = Color.FromArgb(0, 120, 215);
            dgList.Style.HyperlinkStyle.DefaultLinkColor = Color.FromArgb(0, 120, 215);
            dgList.TabIndex = 10;
            gridSummaryColumn1.Format = "{Count}";
            gridSummaryColumn1.MappingName = "Question";
            gridSummaryColumn1.Name = "Question";
            gridTableSummaryRow1.SummaryColumns.Add(gridSummaryColumn1);
            gridTableSummaryRow1.Title = "Total Questions : {Question}";
            dgList.TableSummaryRows.Add(gridTableSummaryRow1);
            dgList.Text = "sfDataGrid1";
            dgList.QueryCellStyle += dgList_QueryCellStyle;
            dgList.QueryImageCellStyle += dgList_QueryImageCellStyle;
            // 
            // panel1
            // 
            panel1.Controls.Add(dgList);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(2, 92);
            panel1.Name = "panel1";
            panel1.Size = new Size(1346, 635);
            panel1.TabIndex = 12;
            // 
            // panel2
            // 
            panel2.Controls.Add(autoLabel1);
            panel2.Controls.Add(txtTitle);
            panel2.Controls.Add(txtExamFormat);
            panel2.Controls.Add(autoLabel2);
            panel2.Controls.Add(txtDate);
            panel2.Controls.Add(btnSave);
            panel2.Controls.Add(autoLabel3);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(2, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(1346, 90);
            panel2.TabIndex = 13;
            // 
            // UpsertExamView
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1350, 729);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 5, 4, 5);
            Name = "UpsertExamView";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Style.MdiChild.IconHorizontalAlignment = HorizontalAlignment.Center;
            Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            Text = "Add Exam";
            Load += UpsertExamView_Load;
            ((System.ComponentModel.ISupportInitialize)txtTitle).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtExamFormat).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgList).EndInit();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtTitle;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private Syncfusion.WinForms.Controls.SfButton btnSave;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel3;
        private Syncfusion.WinForms.Input.SfDateTimeEdit txtDate;
        private Syncfusion.WinForms.ListView.SfComboBox txtExamFormat;
        private Syncfusion.WinForms.DataGrid.SfDataGrid dgList;
        private Panel panel1;
        private Panel panel2;
    }
}