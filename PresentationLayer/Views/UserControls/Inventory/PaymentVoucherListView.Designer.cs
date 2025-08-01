﻿namespace RavenTech_ERP.Views.UserControls.Inventory
{
    partial class PaymentVoucherListView
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
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn1 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn2 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn3 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridDateTimeColumn gridDateTimeColumn1 = new Syncfusion.WinForms.DataGrid.GridDateTimeColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn4 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn5 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn6 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridTextColumn gridTextColumn7 = new Syncfusion.WinForms.DataGrid.GridTextColumn();
            Syncfusion.WinForms.DataGrid.GridImageColumn gridImageColumn1 = new Syncfusion.WinForms.DataGrid.GridImageColumn();
            panel1 = new Panel();
            dgPager = new Syncfusion.WinForms.DataPager.SfDataPager();
            dgList = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgList).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(dgList);
            panel1.Controls.Add(dgPager);
            panel1.Location = new Point(6, 30);
            panel1.Margin = new Padding(4, 5, 4, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(972, 424);
            panel1.TabIndex = 1;
            // 
            // dgPager
            // 
            dgPager.AccessibleName = "DataPager";
            dgPager.CanOverrideStyle = true;
            dgPager.Dock = DockStyle.Bottom;
            dgPager.HorizontalAlignment = HorizontalAlignment.Center;
            dgPager.Location = new Point(0, 364);
            dgPager.Margin = new Padding(4, 5, 4, 5);
            dgPager.Name = "dgPager";
            dgPager.PageSize = 15;
            dgPager.Size = new Size(972, 60);
            dgPager.TabIndex = 8;
            dgPager.Text = "sfDataPager1";
            // 
            // dgList
            // 
            dgList.AccessibleName = "Table";
            dgList.AllowFiltering = true;
            dgList.AllowTriStateSorting = true;
            dgList.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.Fill;
            gridTextColumn1.AllowFiltering = true;
            gridTextColumn1.HeaderText = "Id";
            gridTextColumn1.MappingName = "PaymentVoucherId";
            gridTextColumn1.ShowToolTip = true;
            gridTextColumn1.Visible = false;
            gridTextColumn2.AllowFiltering = true;
            gridTextColumn2.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.Fill;
            gridTextColumn2.HeaderText = "PR #";
            gridTextColumn2.MappingName = "PaymentVoucherName";
            gridTextColumn2.ShowToolTip = true;
            gridTextColumn3.AllowFiltering = true;
            gridTextColumn3.HeaderText = "S.O. #";
            gridTextColumn3.MappingName = "PurchaseOrder";
            gridTextColumn3.ShowToolTip = true;
            gridTextColumn3.Visible = false;
            gridDateTimeColumn1.AllowFiltering = true;
            gridDateTimeColumn1.Format = "MMMM dd, yyyy";
            gridDateTimeColumn1.HeaderText = "Date";
            gridDateTimeColumn1.MappingName = "PaymentDate";
            gridDateTimeColumn1.MaxDateTime = new DateTime(9999, 12, 31, 23, 59, 59, 999);
            gridDateTimeColumn1.ShowToolTip = true;
            gridTextColumn4.AllowFiltering = true;
            gridTextColumn4.HeaderText = "Payment Type";
            gridTextColumn4.MappingName = "PaymentType";
            gridTextColumn4.ShowToolTip = true;
            gridTextColumn5.AllowFiltering = true;
            gridTextColumn5.HeaderText = "Payment Amount";
            gridTextColumn5.MappingName = "PaymentAmount";
            gridTextColumn5.ShowToolTip = true;
            gridTextColumn6.AllowFiltering = true;
            gridTextColumn6.HeaderText = "Cash Bank";
            gridTextColumn6.MappingName = "CashBank";
            gridTextColumn6.ShowToolTip = true;
            gridTextColumn7.AllowFiltering = true;
            gridTextColumn7.HeaderText = "Is Full Payment?";
            gridTextColumn7.MappingName = "IsFullPayment";
            gridTextColumn7.ShowToolTip = true;
            gridImageColumn1.AllowGrouping = false;
            gridImageColumn1.AllowSorting = false;
            gridImageColumn1.HeaderText = " ";
            gridImageColumn1.MappingName = "Delete";
            gridImageColumn1.MaximumWidth = 30D;
            gridImageColumn1.MinimumWidth = 30D;
            gridImageColumn1.ShowToolTip = true;
            gridImageColumn1.Width = 30D;
            dgList.Columns.Add(gridTextColumn1);
            dgList.Columns.Add(gridTextColumn2);
            dgList.Columns.Add(gridTextColumn3);
            dgList.Columns.Add(gridDateTimeColumn1);
            dgList.Columns.Add(gridTextColumn4);
            dgList.Columns.Add(gridTextColumn5);
            dgList.Columns.Add(gridTextColumn6);
            dgList.Columns.Add(gridTextColumn7);
            dgList.Columns.Add(gridImageColumn1);
            dgList.Dock = DockStyle.Fill;
            dgList.FrozenColumnCount = 2;
            dgList.FrozenRowCount = 1;
            dgList.Location = new Point(0, 0);
            dgList.Margin = new Padding(4, 5, 4, 5);
            dgList.Name = "dgList";
            dgList.PreviewRowHeight = 42;
            dgList.ShowGroupDropArea = true;
            dgList.ShowToolTip = true;
            dgList.Size = new Size(972, 364);
            dgList.Style.BorderColor = Color.FromArgb(100, 100, 100);
            dgList.Style.CheckBoxStyle.CheckedBackColor = Color.FromArgb(0, 120, 215);
            dgList.Style.CheckBoxStyle.CheckedBorderColor = Color.FromArgb(0, 120, 215);
            dgList.Style.CheckBoxStyle.IndeterminateBorderColor = Color.FromArgb(0, 120, 215);
            dgList.Style.HyperlinkStyle.DefaultLinkColor = Color.FromArgb(0, 120, 215);
            dgList.TabIndex = 10;
            dgList.Text = "sfDataGrid1";
            dgList.CellClick += dgList_CellClick;
            // 
            // PaymentVoucherListView
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 461);
            Controls.Add(panel1);
            Margin = new Padding(4, 5, 4, 5);
            Name = "PaymentVoucherListView";
            StartPosition = FormStartPosition.CenterScreen;
            Style.MdiChild.IconHorizontalAlignment = HorizontalAlignment.Center;
            Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            Text = "Payment Voucher List";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgList).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Syncfusion.WinForms.DataPager.SfDataPager dgPager;
        private Syncfusion.WinForms.DataGrid.SfDataGrid dgList;
    }
}