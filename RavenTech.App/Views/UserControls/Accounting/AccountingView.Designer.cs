namespace RavenTech_ERP.Views.UserControls.Accounting
{
    partial class AccountingView
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
            tcMain = new MaterialSkin.Controls.MaterialTabControl();
            tbPayroll = new TabPage();
            tbAccount = new TabPage();
            tbBudget = new TabPage();
            tbChartOfAccount = new TabPage();
            tbFinancialTransaction = new TabPage();
            tbInvoice = new TabPage();
            tbLedgerEntry = new TabPage();
            tcMain.SuspendLayout();
            SuspendLayout();
            // 
            // tcMain
            // 
            tcMain.Controls.Add(tbPayroll);
            tcMain.Controls.Add(tbAccount);
            tcMain.Controls.Add(tbBudget);
            tcMain.Controls.Add(tbChartOfAccount);
            tcMain.Controls.Add(tbFinancialTransaction);
            tcMain.Controls.Add(tbInvoice);
            tcMain.Controls.Add(tbLedgerEntry);
            tcMain.Depth = 0;
            tcMain.Dock = DockStyle.Fill;
            tcMain.Location = new Point(3, 64);
            tcMain.MouseState = MaterialSkin.MouseState.HOVER;
            tcMain.Multiline = true;
            tcMain.Name = "tcMain";
            tcMain.SelectedIndex = 0;
            tcMain.Size = new Size(1203, 521);
            tcMain.TabIndex = 0;
            // 
            // tbPayroll
            // 
            tbPayroll.Location = new Point(4, 24);
            tbPayroll.Name = "tbPayroll";
            tbPayroll.Padding = new Padding(3);
            tbPayroll.Size = new Size(1195, 493);
            tbPayroll.TabIndex = 0;
            tbPayroll.Text = "Payroll";
            tbPayroll.UseVisualStyleBackColor = true;
            // 
            // tbAccount
            // 
            tbAccount.Location = new Point(4, 24);
            tbAccount.Name = "tbAccount";
            tbAccount.Padding = new Padding(3);
            tbAccount.Size = new Size(1195, 493);
            tbAccount.TabIndex = 1;
            tbAccount.Text = "Account";
            tbAccount.UseVisualStyleBackColor = true;
            // 
            // tbBudget
            // 
            tbBudget.Location = new Point(4, 24);
            tbBudget.Name = "tbBudget";
            tbBudget.Size = new Size(1195, 493);
            tbBudget.TabIndex = 2;
            tbBudget.Text = "Budget";
            tbBudget.UseVisualStyleBackColor = true;
            // 
            // tbChartOfAccount
            // 
            tbChartOfAccount.Location = new Point(4, 24);
            tbChartOfAccount.Name = "tbChartOfAccount";
            tbChartOfAccount.Size = new Size(1195, 493);
            tbChartOfAccount.TabIndex = 3;
            tbChartOfAccount.Text = "Chart Of Account";
            tbChartOfAccount.UseVisualStyleBackColor = true;
            // 
            // tbFinancialTransaction
            // 
            tbFinancialTransaction.Location = new Point(4, 24);
            tbFinancialTransaction.Name = "tbFinancialTransaction";
            tbFinancialTransaction.Size = new Size(1195, 493);
            tbFinancialTransaction.TabIndex = 4;
            tbFinancialTransaction.Text = "Financial Transaction";
            tbFinancialTransaction.UseVisualStyleBackColor = true;
            // 
            // tbInvoice
            // 
            tbInvoice.Location = new Point(4, 24);
            tbInvoice.Name = "tbInvoice";
            tbInvoice.Size = new Size(1195, 493);
            tbInvoice.TabIndex = 5;
            tbInvoice.Text = "Invoice";
            tbInvoice.UseVisualStyleBackColor = true;
            // 
            // tbLedgerEntry
            // 
            tbLedgerEntry.Location = new Point(4, 24);
            tbLedgerEntry.Name = "tbLedgerEntry";
            tbLedgerEntry.Size = new Size(1195, 493);
            tbLedgerEntry.TabIndex = 6;
            tbLedgerEntry.Text = "Ledger Entry";
            tbLedgerEntry.UseVisualStyleBackColor = true;
            // 
            // AccountingView
            // 
            AutoScaleMode = AutoScaleMode.Inherit;
            ClientSize = new Size(1209, 588);
            Controls.Add(tcMain);
            DrawerAutoShow = true;
            DrawerTabControl = tcMain;
            Name = "AccountingView";
            Text = "Accounting Management System";
            WindowState = FormWindowState.Maximized;
            tcMain.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl tcMain;
        private TabPage tbPayroll;
        private TabPage tbAccount;
        private TabPage tbBudget;
        private TabPage tbChartOfAccount;
        private TabPage tbFinancialTransaction;
        private TabPage tbInvoice;
        private TabPage tbLedgerEntry;
    }
}