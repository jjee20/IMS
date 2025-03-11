namespace RavenTech_ERP.Views.UserControls.Inventory
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            dgList = new Guna.UI2.WinForms.Guna2DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgList).BeginInit();
            SuspendLayout();
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
            dgList.ColumnHeadersHeight = 40;
            dgList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgList.DefaultCellStyle = dataGridViewCellStyle3;
            dgList.Dock = DockStyle.Fill;
            dgList.GridColor = Color.FromArgb(231, 229, 255);
            dgList.Location = new Point(3, 64);
            dgList.Name = "dgList";
            dgList.RowHeadersVisible = false;
            dgList.Size = new Size(794, 383);
            dgList.TabIndex = 0;
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
            dgList.ThemeStyle.HeaderStyle.Height = 40;
            dgList.ThemeStyle.ReadOnly = false;
            dgList.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgList.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgList.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgList.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgList.ThemeStyle.RowsStyle.Height = 25;
            dgList.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgList.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dgList.CellContentDoubleClick += dgList_CellContentDoubleClick;
            // 
            // PaymentVoucherListView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgList);
            Name = "PaymentVoucherListView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Payment List";
            ((System.ComponentModel.ISupportInitialize)dgList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView dgList;
    }
}