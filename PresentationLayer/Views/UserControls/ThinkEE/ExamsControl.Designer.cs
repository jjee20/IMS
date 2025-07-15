namespace RavenTech_ERP.Views.UserControls.ThinkEE;

partial class ExamsControl
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
        lblTitle = new Syncfusion.Windows.Forms.Tools.AutoLabel();
        lblType = new Syncfusion.Windows.Forms.Tools.AutoLabel();
        lblDate = new Syncfusion.Windows.Forms.Tools.AutoLabel();
        lblTime = new Syncfusion.Windows.Forms.Tools.AutoLabel();
        lblStatus = new Syncfusion.Windows.Forms.Tools.AutoLabel();
        tableLayoutPanel1 = new TableLayoutPanel();
        btnTake = new Syncfusion.WinForms.Controls.SfButton();
        lblScore = new Syncfusion.Windows.Forms.Tools.AutoLabel();
        tableLayoutPanel1.SuspendLayout();
        SuspendLayout();
        // 
        // lblTitle
        // 
        lblTitle.Dock = DockStyle.Fill;
        lblTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblTitle.Location = new Point(3, 0);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(344, 42);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Title";
        lblTitle.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblType
        // 
        lblType.Dock = DockStyle.Fill;
        lblType.Location = new Point(3, 42);
        lblType.Name = "lblType";
        lblType.Size = new Size(344, 42);
        lblType.TabIndex = 1;
        lblType.Text = "Type";
        lblType.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblDate
        // 
        lblDate.Dock = DockStyle.Fill;
        lblDate.Location = new Point(3, 84);
        lblDate.Name = "lblDate";
        lblDate.Size = new Size(344, 30);
        lblDate.TabIndex = 2;
        lblDate.Text = "Date";
        lblDate.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblTime
        // 
        lblTime.Dock = DockStyle.Fill;
        lblTime.Location = new Point(3, 114);
        lblTime.Name = "lblTime";
        lblTime.Size = new Size(344, 30);
        lblTime.TabIndex = 3;
        lblTime.Text = "Time";
        lblTime.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblStatus
        // 
        lblStatus.Dock = DockStyle.Fill;
        lblStatus.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
        lblStatus.ForeColor = Color.FromArgb(0, 192, 192);
        lblStatus.Location = new Point(3, 144);
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new Size(344, 30);
        lblStatus.TabIndex = 4;
        lblStatus.Text = "Status";
        lblStatus.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // tableLayoutPanel1
        // 
        tableLayoutPanel1.BackColor = Color.FromArgb(192, 255, 255);
        tableLayoutPanel1.ColumnCount = 1;
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tableLayoutPanel1.Controls.Add(lblScore, 0, 5);
        tableLayoutPanel1.Controls.Add(lblTitle, 0, 0);
        tableLayoutPanel1.Controls.Add(lblStatus, 0, 4);
        tableLayoutPanel1.Controls.Add(lblType, 0, 1);
        tableLayoutPanel1.Controls.Add(lblTime, 0, 3);
        tableLayoutPanel1.Controls.Add(lblDate, 0, 2);
        tableLayoutPanel1.Controls.Add(btnTake, 0, 6);
        tableLayoutPanel1.Dock = DockStyle.Fill;
        tableLayoutPanel1.Location = new Point(0, 0);
        tableLayoutPanel1.Name = "tableLayoutPanel1";
        tableLayoutPanel1.RowCount = 7;
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 17.0073032F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 17.0073F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.2452564F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.2452564F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.2452564F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.2421942F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 17.0074348F));
        tableLayoutPanel1.Size = new Size(350, 250);
        tableLayoutPanel1.TabIndex = 5;
        // 
        // btnTake
        // 
        btnTake.BackColor = Color.DodgerBlue;
        btnTake.Dock = DockStyle.Fill;
        btnTake.Font = new Font("Segoe UI Semibold", 9F);
        btnTake.Location = new Point(3, 207);
        btnTake.Name = "btnTake";
        btnTake.Size = new Size(344, 40);
        btnTake.Style.BackColor = Color.DodgerBlue;
        btnTake.TabIndex = 5;
        btnTake.Text = "Take";
        btnTake.UseVisualStyleBackColor = false;
        btnTake.Click += btnTake_Click;
        // 
        // lblScore
        // 
        lblScore.Dock = DockStyle.Fill;
        lblScore.Location = new Point(3, 174);
        lblScore.Name = "lblScore";
        lblScore.Size = new Size(344, 30);
        lblScore.TabIndex = 6;
        lblScore.Text = "Score";
        lblScore.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // ExamsControl
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(tableLayoutPanel1);
        Name = "ExamsControl";
        Size = new Size(350, 250);
        tableLayoutPanel1.ResumeLayout(false);
        tableLayoutPanel1.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private Syncfusion.Windows.Forms.Tools.AutoLabel lblTitle;
    private Syncfusion.Windows.Forms.Tools.AutoLabel lblType;
    private Syncfusion.Windows.Forms.Tools.AutoLabel lblDate;
    private Syncfusion.Windows.Forms.Tools.AutoLabel lblTime;
    private Syncfusion.Windows.Forms.Tools.AutoLabel lblStatus;
    private TableLayoutPanel tableLayoutPanel1;
    private Syncfusion.WinForms.Controls.SfButton btnTake;
    private Syncfusion.Windows.Forms.Tools.AutoLabel lblScore;
}
