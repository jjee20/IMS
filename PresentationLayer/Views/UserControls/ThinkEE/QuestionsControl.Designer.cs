namespace RavenTech_ERP.Views.UserControls.ThinkEE;

partial class QuestionsControl
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
        lblQuestionNo = new Syncfusion.Windows.Forms.Tools.AutoLabel();
        lblQuestionText = new Syncfusion.Windows.Forms.Tools.AutoLabel();
        tableLayoutPanel1 = new TableLayoutPanel();
        btnChoice1 = new Syncfusion.Windows.Forms.Tools.RadioButtonAdv();
        btnChoice2 = new Syncfusion.Windows.Forms.Tools.RadioButtonAdv();
        btnChoice3 = new Syncfusion.Windows.Forms.Tools.RadioButtonAdv();
        btnChoice4 = new Syncfusion.Windows.Forms.Tools.RadioButtonAdv();
        tableLayoutPanel1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)btnChoice1).BeginInit();
        ((System.ComponentModel.ISupportInitialize)btnChoice2).BeginInit();
        ((System.ComponentModel.ISupportInitialize)btnChoice3).BeginInit();
        ((System.ComponentModel.ISupportInitialize)btnChoice4).BeginInit();
        SuspendLayout();
        // 
        // lblQuestionNo
        // 
        lblQuestionNo.Dock = DockStyle.Fill;
        lblQuestionNo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblQuestionNo.Location = new Point(53, 40);
        lblQuestionNo.Name = "lblQuestionNo";
        lblQuestionNo.Size = new Size(694, 40);
        lblQuestionNo.TabIndex = 1;
        lblQuestionNo.Text = "Question #";
        // 
        // lblQuestionText
        // 
        lblQuestionText.Dock = DockStyle.Fill;
        lblQuestionText.Location = new Point(53, 80);
        lblQuestionText.Name = "lblQuestionText";
        lblQuestionText.Size = new Size(694, 104);
        lblQuestionText.TabIndex = 2;
        lblQuestionText.Text = "Question";
        // 
        // tableLayoutPanel1
        // 
        tableLayoutPanel1.BackColor = SystemColors.ButtonFace;
        tableLayoutPanel1.ColumnCount = 3;
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
        tableLayoutPanel1.Controls.Add(lblQuestionNo, 1, 1);
        tableLayoutPanel1.Controls.Add(lblQuestionText, 1, 2);
        tableLayoutPanel1.Controls.Add(btnChoice1, 1, 3);
        tableLayoutPanel1.Controls.Add(btnChoice2, 1, 4);
        tableLayoutPanel1.Controls.Add(btnChoice3, 1, 5);
        tableLayoutPanel1.Controls.Add(btnChoice4, 1, 6);
        tableLayoutPanel1.Dock = DockStyle.Fill;
        tableLayoutPanel1.Location = new Point(0, 0);
        tableLayoutPanel1.Name = "tableLayoutPanel1";
        tableLayoutPanel1.RowCount = 9;
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 86.95652F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 13.043478F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
        tableLayoutPanel1.Size = new Size(800, 400);
        tableLayoutPanel1.TabIndex = 3;
        // 
        // btnChoice1
        // 
        btnChoice1.AccessibilityEnabled = true;
        btnChoice1.BackColor = Color.AliceBlue;
        btnChoice1.BeforeTouchSize = new Size(694, 34);
        btnChoice1.Dock = DockStyle.Fill;
        btnChoice1.ImageCheckBoxSize = new Size(19, 19);
        btnChoice1.Location = new Point(53, 187);
        btnChoice1.MetroColor = Color.FromArgb(88, 89, 91);
        btnChoice1.Name = "btnChoice1";
        btnChoice1.Size = new Size(694, 34);
        btnChoice1.TabIndex = 3;
        btnChoice1.Text = "Choice 1";
        // 
        // btnChoice2
        // 
        btnChoice2.AccessibilityEnabled = true;
        btnChoice2.BackColor = Color.AliceBlue;
        btnChoice2.BeforeTouchSize = new Size(694, 34);
        btnChoice2.Dock = DockStyle.Fill;
        btnChoice2.ImageCheckBoxSize = new Size(19, 19);
        btnChoice2.Location = new Point(53, 227);
        btnChoice2.MetroColor = Color.FromArgb(88, 89, 91);
        btnChoice2.Name = "btnChoice2";
        btnChoice2.Size = new Size(694, 34);
        btnChoice2.TabIndex = 4;
        btnChoice2.Text = "Choice 2";
        // 
        // btnChoice3
        // 
        btnChoice3.AccessibilityEnabled = true;
        btnChoice3.BackColor = Color.AliceBlue;
        btnChoice3.BeforeTouchSize = new Size(694, 34);
        btnChoice3.Dock = DockStyle.Fill;
        btnChoice3.ImageCheckBoxSize = new Size(19, 19);
        btnChoice3.Location = new Point(53, 267);
        btnChoice3.MetroColor = Color.FromArgb(88, 89, 91);
        btnChoice3.Name = "btnChoice3";
        btnChoice3.Size = new Size(694, 34);
        btnChoice3.TabIndex = 5;
        btnChoice3.Text = "Choice 3";
        // 
        // btnChoice4
        // 
        btnChoice4.AccessibilityEnabled = true;
        btnChoice4.BackColor = Color.AliceBlue;
        btnChoice4.BeforeTouchSize = new Size(694, 34);
        btnChoice4.Dock = DockStyle.Fill;
        btnChoice4.ImageCheckBoxSize = new Size(19, 19);
        btnChoice4.Location = new Point(53, 307);
        btnChoice4.MetroColor = Color.FromArgb(88, 89, 91);
        btnChoice4.Name = "btnChoice4";
        btnChoice4.Size = new Size(694, 34);
        btnChoice4.TabIndex = 6;
        btnChoice4.Text = "Choice 4";
        // 
        // QuestionsControl
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(tableLayoutPanel1);
        Margin = new Padding(0);
        Name = "QuestionsControl";
        Size = new Size(800, 400);
        tableLayoutPanel1.ResumeLayout(false);
        tableLayoutPanel1.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)btnChoice1).EndInit();
        ((System.ComponentModel.ISupportInitialize)btnChoice2).EndInit();
        ((System.ComponentModel.ISupportInitialize)btnChoice3).EndInit();
        ((System.ComponentModel.ISupportInitialize)btnChoice4).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private Syncfusion.Windows.Forms.Tools.AutoLabel lblQuestionNo;
    private Syncfusion.Windows.Forms.Tools.AutoLabel lblQuestionText;
    private TableLayoutPanel tableLayoutPanel1;
    private Syncfusion.Windows.Forms.Tools.RadioButtonAdv btnChoice1;
    private Syncfusion.Windows.Forms.Tools.RadioButtonAdv btnChoice2;
    private Syncfusion.Windows.Forms.Tools.RadioButtonAdv btnChoice3;
    private Syncfusion.Windows.Forms.Tools.RadioButtonAdv btnChoice4;
}
