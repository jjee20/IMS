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
            var gridTextColumn2 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            var gridTextColumn3 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            var gridTextColumn4 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            var gridTextColumn5 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            var gridTextColumn6 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            var gridTextColumn7 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
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
            ((System.ComponentModel.ISupportInitialize)txtTitle).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtExamFormat).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgList).BeginInit();
            SuspendLayout();
            // 
            // autoLabel1
            // 
            autoLabel1.Location = new Point(15, 52);
            autoLabel1.Margin = new Padding(4, 0, 4, 0);
            autoLabel1.Name = "autoLabel1";
            autoLabel1.Size = new Size(44, 25);
            autoLabel1.TabIndex = 0;
            autoLabel1.Text = "Title";
            // 
            // txtTitle
            // 
            txtTitle.BeforeTouchSize = new Size(293, 31);
            txtTitle.Location = new Point(67, 46);
            txtTitle.Margin = new Padding(4, 5, 4, 5);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(293, 31);
            txtTitle.TabIndex = 1;
            // 
            // autoLabel2
            // 
            autoLabel2.Location = new Point(380, 52);
            autoLabel2.Margin = new Padding(4, 0, 4, 0);
            autoLabel2.Name = "autoLabel2";
            autoLabel2.Size = new Size(49, 25);
            autoLabel2.TabIndex = 2;
            autoLabel2.Text = "Date";
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI Semibold", 9F);
            btnSave.Location = new Point(1198, 30);
            btnSave.Margin = new Padding(4, 5, 4, 5);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(137, 47);
            btnSave.TabIndex = 4;
            btnSave.Text = "Save";
            btnSave.Click += btnSave_Click;
            // 
            // autoLabel3
            // 
            autoLabel3.Location = new Point(754, 52);
            autoLabel3.Margin = new Padding(4, 0, 4, 0);
            autoLabel3.Name = "autoLabel3";
            autoLabel3.Size = new Size(116, 25);
            autoLabel3.TabIndex = 5;
            autoLabel3.Text = "Exam Format";
            // 
            // txtDate
            // 
            txtDate.DateTimeIcon = null;
            txtDate.Location = new Point(436, 44);
            txtDate.Name = "txtDate";
            txtDate.Size = new Size(293, 33);
            txtDate.TabIndex = 8;
            txtDate.ToolTipText = "";
            // 
            // txtExamFormat
            // 
            txtExamFormat.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            txtExamFormat.Location = new Point(877, 41);
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
            gridTextColumn2.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.ColumnHeader;
            gridTextColumn2.HeaderText = "#1";
            gridTextColumn2.MappingName = "Choice1";
            gridTextColumn3.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.ColumnHeader;
            gridTextColumn3.HeaderText = "#2";
            gridTextColumn3.MappingName = "Choice2";
            gridTextColumn4.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.ColumnHeader;
            gridTextColumn4.HeaderText = "#3";
            gridTextColumn4.MappingName = "Choice3";
            gridTextColumn5.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.ColumnHeader;
            gridTextColumn5.HeaderText = "#4";
            gridTextColumn5.MappingName = "Choice4";
            gridTextColumn6.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.ColumnHeader;
            gridTextColumn6.HeaderText = "Answer";
            gridTextColumn6.MappingName = "Answer";
            gridTextColumn7.HeaderText = " ";
            gridTextColumn7.MappingName = "Delete";
            gridTextColumn7.MaximumWidth = 30D;
            gridTextColumn7.MinimumWidth = 30D;
            dgList.Columns.Add(gridTextColumn1);
            dgList.Columns.Add(gridTextColumn2);
            dgList.Columns.Add(gridTextColumn3);
            dgList.Columns.Add(gridTextColumn4);
            dgList.Columns.Add(gridTextColumn5);
            dgList.Columns.Add(gridTextColumn6);
            dgList.Columns.Add(gridTextColumn7);
            dgList.Location = new Point(15, 105);
            dgList.Name = "dgList";
            dgList.NewItemPlaceholderPosition = Syncfusion.Data.NewItemPlaceholderPosition.AtBeginning;
            dgList.PreviewRowHeight = 42;
            dgList.Size = new Size(1320, 598);
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
            gridSummaryColumn1.MappingName = "Question";
            gridTableSummaryRow1.SummaryColumns.Add(gridSummaryColumn1);
            gridTableSummaryRow1.Title = "Total Questions";
            dgList.TableSummaryRows.Add(gridTableSummaryRow1);
            dgList.Text = "sfDataGrid1";
            // 
            // UpsertExamView
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1350, 729);
            Controls.Add(dgList);
            Controls.Add(txtExamFormat);
            Controls.Add(txtDate);
            Controls.Add(autoLabel3);
            Controls.Add(btnSave);
            Controls.Add(autoLabel2);
            Controls.Add(txtTitle);
            Controls.Add(autoLabel1);
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
            ResumeLayout(false);
            PerformLayout();
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
    }
}