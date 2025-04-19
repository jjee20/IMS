namespace RavenTech_ERP.Views.UserControls.Accounting.Payroll
{
    partial class _Upsert13thMonthView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_Upsert13thMonthView));
            autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtId = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtName = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel4 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtDepartment = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel6 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            txtRoles = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel8 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            txtRate = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel10 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            dgList = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            txtTotal = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            autoLabel12 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            buttonGenerate = new Syncfusion.WinForms.Controls.SfButton();
            buttonSave = new Syncfusion.WinForms.Controls.SfButton();
            ((System.ComponentModel.ISupportInitialize)dgList).BeginInit();
            SuspendLayout();
            // 
            // autoLabel1
            // 
            autoLabel1.Location = new Point(30, 23);
            autoLabel1.Name = "autoLabel1";
            autoLabel1.Size = new Size(27, 15);
            autoLabel1.TabIndex = 2;
            autoLabel1.Text = "I.D.:";
            // 
            // txtId
            // 
            txtId.Location = new Point(78, 23);
            txtId.Name = "txtId";
            txtId.Size = new Size(24, 15);
            txtId.TabIndex = 3;
            txtId.Text = "I.D.";
            // 
            // txtName
            // 
            txtName.Location = new Point(78, 38);
            txtName.Name = "txtName";
            txtName.Size = new Size(39, 15);
            txtName.TabIndex = 5;
            txtName.Text = "Name";
            // 
            // autoLabel4
            // 
            autoLabel4.Location = new Point(30, 38);
            autoLabel4.Name = "autoLabel4";
            autoLabel4.Size = new Size(42, 15);
            autoLabel4.TabIndex = 4;
            autoLabel4.Text = "Name:";
            // 
            // txtDepartment
            // 
            txtDepartment.Location = new Point(516, 23);
            txtDepartment.Name = "txtDepartment";
            txtDepartment.Size = new Size(70, 15);
            txtDepartment.TabIndex = 7;
            txtDepartment.Text = "Department";
            // 
            // autoLabel6
            // 
            autoLabel6.Location = new Point(437, 23);
            autoLabel6.Name = "autoLabel6";
            autoLabel6.Size = new Size(73, 15);
            autoLabel6.TabIndex = 6;
            autoLabel6.Text = "Department:";
            // 
            // txtRoles
            // 
            txtRoles.Location = new Point(516, 38);
            txtRoles.Name = "txtRoles";
            txtRoles.Size = new Size(29, 15);
            txtRoles.TabIndex = 9;
            txtRoles.Text = "Title";
            // 
            // autoLabel8
            // 
            autoLabel8.Location = new Point(437, 38);
            autoLabel8.Name = "autoLabel8";
            autoLabel8.Size = new Size(32, 15);
            autoLabel8.TabIndex = 8;
            autoLabel8.Text = "Title:";
            // 
            // guna2Separator1
            // 
            guna2Separator1.Location = new Point(30, 84);
            guna2Separator1.Name = "guna2Separator1";
            guna2Separator1.Size = new Size(742, 10);
            guna2Separator1.TabIndex = 10;
            // 
            // txtRate
            // 
            txtRate.Location = new Point(78, 53);
            txtRate.Name = "txtRate";
            txtRate.Size = new Size(30, 15);
            txtRate.TabIndex = 12;
            txtRate.Text = "Rate";
            // 
            // autoLabel10
            // 
            autoLabel10.Location = new Point(30, 53);
            autoLabel10.Name = "autoLabel10";
            autoLabel10.Size = new Size(33, 15);
            autoLabel10.TabIndex = 11;
            autoLabel10.Text = "Rate:";
            // 
            // dgList
            // 
            dgList.AccessibleName = "Table";
            dgList.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.Fill;
            gridTextColumn1.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.ColumnHeader;
            gridTextColumn1.HeaderText = "Month";
            gridTextColumn1.MappingName = "Month";
            gridTextColumn2.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.ColumnHeader;
            gridTextColumn2.HeaderText = "Days Worked";
            gridTextColumn2.MappingName = "DaysWorked";
            gridTextColumn3.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.Fill;
            gridTextColumn3.HeaderText = "Amount";
            gridTextColumn3.MappingName = "Amount";
            dgList.Columns.Add(gridTextColumn1);
            dgList.Columns.Add(gridTextColumn2);
            dgList.Columns.Add(gridTextColumn3);
            dgList.Location = new Point(30, 100);
            dgList.Name = "dgList";
            dgList.Size = new Size(742, 300);
            dgList.Style.BorderColor = Color.FromArgb(100, 100, 100);
            dgList.Style.CheckBoxStyle.CheckedBackColor = Color.FromArgb(0, 120, 215);
            dgList.Style.CheckBoxStyle.CheckedBorderColor = Color.FromArgb(0, 120, 215);
            dgList.Style.CheckBoxStyle.IndeterminateBorderColor = Color.FromArgb(0, 120, 215);
            dgList.Style.HyperlinkStyle.DefaultLinkColor = Color.FromArgb(0, 120, 215);
            dgList.TabIndex = 13;
            dgList.Text = "sfDataGrid1";
            // 
            // txtTotal
            // 
            txtTotal.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            txtTotal.Location = new Point(641, 412);
            txtTotal.Name = "txtTotal";
            txtTotal.Size = new Size(34, 15);
            txtTotal.TabIndex = 15;
            txtTotal.Text = "Total";
            // 
            // autoLabel12
            // 
            autoLabel12.Location = new Point(593, 412);
            autoLabel12.Name = "autoLabel12";
            autoLabel12.Size = new Size(35, 15);
            autoLabel12.TabIndex = 14;
            autoLabel12.Text = "Total:";
            // 
            // buttonGenerate
            // 
            buttonGenerate.BackColor = Color.FromArgb(192, 255, 192);
            buttonGenerate.Font = new Font("Segoe UI Semibold", 9F);
            buttonGenerate.Location = new Point(676, 23);
            buttonGenerate.Name = "buttonGenerate";
            buttonGenerate.Size = new Size(96, 28);
            buttonGenerate.Style.BackColor = Color.FromArgb(192, 255, 192);
            buttonGenerate.TabIndex = 16;
            buttonGenerate.Text = "Generate";
            buttonGenerate.UseVisualStyleBackColor = false;
            buttonGenerate.Click += buttonGenerate_Click;
            // 
            // buttonSave
            // 
            buttonSave.BackColor = Color.AliceBlue;
            buttonSave.Font = new Font("Segoe UI Semibold", 9F);
            buttonSave.Location = new Point(676, 53);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(96, 28);
            buttonSave.Style.BackColor = Color.AliceBlue;
            buttonSave.TabIndex = 17;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = false;
            buttonSave.Click += buttonSave_Click;
            // 
            // _Upsert13thMonthView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonSave);
            Controls.Add(buttonGenerate);
            Controls.Add(txtTotal);
            Controls.Add(autoLabel12);
            Controls.Add(dgList);
            Controls.Add(txtRate);
            Controls.Add(autoLabel10);
            Controls.Add(guna2Separator1);
            Controls.Add(txtRoles);
            Controls.Add(autoLabel8);
            Controls.Add(txtDepartment);
            Controls.Add(autoLabel6);
            Controls.Add(txtName);
            Controls.Add(autoLabel4);
            Controls.Add(txtId);
            Controls.Add(autoLabel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "_Upsert13thMonthView";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Style.MdiChild.IconHorizontalAlignment = HorizontalAlignment.Center;
            Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            Text = "13th Month Pay Computation";
            ((System.ComponentModel.ISupportInitialize)dgList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.Windows.Forms.Tools.AutoLabel txtId;
        private Syncfusion.Windows.Forms.Tools.AutoLabel txtName;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel4;
        private Syncfusion.Windows.Forms.Tools.AutoLabel txtDepartment;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel6;
        private Syncfusion.Windows.Forms.Tools.AutoLabel txtRoles;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel8;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private Syncfusion.Windows.Forms.Tools.AutoLabel txtRate;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel10;
        private Syncfusion.WinForms.DataGrid.SfDataGrid dgList;
        private Syncfusion.Windows.Forms.Tools.AutoLabel txtTotal;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel12;
        private Syncfusion.WinForms.Controls.SfButton buttonGenerate;
        private Syncfusion.WinForms.Controls.SfButton buttonSave;
    }
}