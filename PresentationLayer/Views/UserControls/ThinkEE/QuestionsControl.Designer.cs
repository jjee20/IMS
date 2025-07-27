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
        panel1 = new Panel();
        btnShowAnswer = new Syncfusion.WinForms.Controls.SfButton();
        tableLayoutPanel1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)btnChoice1).BeginInit();
        ((System.ComponentModel.ISupportInitialize)btnChoice2).BeginInit();
        ((System.ComponentModel.ISupportInitialize)btnChoice3).BeginInit();
        ((System.ComponentModel.ISupportInitialize)btnChoice4).BeginInit();
        panel1.SuspendLayout();
        SuspendLayout();
        // 
        // lblQuestionNo
        // 
        lblQuestionNo.BackColor = Color.Blue;
        lblQuestionNo.Dock = DockStyle.Fill;
        lblQuestionNo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblQuestionNo.ForeColor = Color.FromArgb(192, 255, 255);
        lblQuestionNo.Location = new Point(37, 24);
        lblQuestionNo.Margin = new Padding(2, 0, 2, 0);
        lblQuestionNo.Name = "lblQuestionNo";
        lblQuestionNo.Size = new Size(486, 24);
        lblQuestionNo.TabIndex = 1;
        lblQuestionNo.Text = "Question #";
        // 
        // lblQuestionText
        // 
        lblQuestionText.Dock = DockStyle.Fill;
        lblQuestionText.Location = new Point(37, 48);
        lblQuestionText.Margin = new Padding(2, 0, 2, 0);
        lblQuestionText.Name = "lblQuestionText";
        lblQuestionText.Size = new Size(486, 41);
        lblQuestionText.TabIndex = 2;
        lblQuestionText.Text = "Question";
        // 
        // tableLayoutPanel1
        // 
        tableLayoutPanel1.BackColor = SystemColors.ButtonFace;
        tableLayoutPanel1.ColumnCount = 3;
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 35F));
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 35F));
        tableLayoutPanel1.Controls.Add(lblQuestionNo, 1, 1);
        tableLayoutPanel1.Controls.Add(lblQuestionText, 1, 2);
        tableLayoutPanel1.Controls.Add(btnChoice1, 1, 3);
        tableLayoutPanel1.Controls.Add(btnChoice2, 1, 4);
        tableLayoutPanel1.Controls.Add(btnChoice3, 1, 5);
        tableLayoutPanel1.Controls.Add(btnChoice4, 1, 6);
        tableLayoutPanel1.Controls.Add(panel1, 1, 7);
        tableLayoutPanel1.Dock = DockStyle.Fill;
        tableLayoutPanel1.Location = new Point(0, 0);
        tableLayoutPanel1.Margin = new Padding(2, 2, 2, 2);
        tableLayoutPanel1.Name = "tableLayoutPanel1";
        tableLayoutPanel1.RowCount = 10;
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 86.99435F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 13.0056553F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
        tableLayoutPanel1.Size = new Size(560, 240);
        tableLayoutPanel1.TabIndex = 3;
        // 
        // btnChoice1
        // 
        btnChoice1.AccessibilityEnabled = true;
        btnChoice1.BackColor = Color.AliceBlue;
        btnChoice1.BeforeTouchSize = new Size(486, 20);
        btnChoice1.Dock = DockStyle.Fill;
        btnChoice1.ImageCheckBoxSize = new Size(19, 19);
        btnChoice1.Location = new Point(37, 91);
        btnChoice1.Margin = new Padding(2, 2, 2, 2);
        btnChoice1.MetroColor = Color.FromArgb(88, 89, 91);
        btnChoice1.Name = "btnChoice1";
        btnChoice1.Size = new Size(486, 20);
        btnChoice1.TabIndex = 3;
        btnChoice1.Text = "Choice 1";
        // 
        // btnChoice2
        // 
        btnChoice2.AccessibilityEnabled = true;
        btnChoice2.BackColor = Color.AliceBlue;
        btnChoice2.BeforeTouchSize = new Size(486, 20);
        btnChoice2.Dock = DockStyle.Fill;
        btnChoice2.ImageCheckBoxSize = new Size(19, 19);
        btnChoice2.Location = new Point(37, 115);
        btnChoice2.Margin = new Padding(2, 2, 2, 2);
        btnChoice2.MetroColor = Color.FromArgb(88, 89, 91);
        btnChoice2.Name = "btnChoice2";
        btnChoice2.Size = new Size(486, 20);
        btnChoice2.TabIndex = 4;
        btnChoice2.Text = "Choice 2";
        // 
        // btnChoice3
        // 
        btnChoice3.AccessibilityEnabled = true;
        btnChoice3.BackColor = Color.AliceBlue;
        btnChoice3.BeforeTouchSize = new Size(486, 20);
        btnChoice3.Dock = DockStyle.Fill;
        btnChoice3.ImageCheckBoxSize = new Size(19, 19);
        btnChoice3.Location = new Point(37, 139);
        btnChoice3.Margin = new Padding(2, 2, 2, 2);
        btnChoice3.MetroColor = Color.FromArgb(88, 89, 91);
        btnChoice3.Name = "btnChoice3";
        btnChoice3.Size = new Size(486, 20);
        btnChoice3.TabIndex = 5;
        btnChoice3.Text = "Choice 3";
        // 
        // btnChoice4
        // 
        btnChoice4.AccessibilityEnabled = true;
        btnChoice4.BackColor = Color.AliceBlue;
        btnChoice4.BeforeTouchSize = new Size(486, 20);
        btnChoice4.Dock = DockStyle.Fill;
        btnChoice4.ImageCheckBoxSize = new Size(19, 19);
        btnChoice4.Location = new Point(37, 163);
        btnChoice4.Margin = new Padding(2, 2, 2, 2);
        btnChoice4.MetroColor = Color.FromArgb(88, 89, 91);
        btnChoice4.Name = "btnChoice4";
        btnChoice4.Size = new Size(486, 20);
        btnChoice4.TabIndex = 6;
        btnChoice4.Text = "Choice 4";
        // 
        // panel1
        // 
        panel1.Controls.Add(btnShowAnswer);
        panel1.Dock = DockStyle.Top;
        panel1.Location = new Point(35, 185);
        panel1.Margin = new Padding(0);
        panel1.Name = "panel1";
        panel1.Size = new Size(490, 24);
        panel1.TabIndex = 7;
        // 
        // btnShowAnswer
        // 
        btnShowAnswer.BackColor = Color.MediumAquamarine;
        btnShowAnswer.Dock = DockStyle.Right;
        btnShowAnswer.Font = new Font("Segoe UI Semibold", 9F);
        btnShowAnswer.ForeColor = Color.FromArgb(0, 64, 64);
        btnShowAnswer.Location = new Point(394, 0);
        btnShowAnswer.Name = "btnShowAnswer";
        btnShowAnswer.Size = new Size(96, 24);
        btnShowAnswer.Style.BackColor = Color.MediumAquamarine;
        btnShowAnswer.Style.ForeColor = Color.FromArgb(0, 64, 64);
        btnShowAnswer.TabIndex = 8;
        btnShowAnswer.Text = "Show Answer";
        btnShowAnswer.UseVisualStyleBackColor = false;
        btnShowAnswer.Click += btnShowAnswer_Click;
        // 
        // QuestionsControl
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(tableLayoutPanel1);
        Margin = new Padding(0);
        Name = "QuestionsControl";
        Size = new Size(560, 240);
        tableLayoutPanel1.ResumeLayout(false);
        tableLayoutPanel1.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)btnChoice1).EndInit();
        ((System.ComponentModel.ISupportInitialize)btnChoice2).EndInit();
        ((System.ComponentModel.ISupportInitialize)btnChoice3).EndInit();
        ((System.ComponentModel.ISupportInitialize)btnChoice4).EndInit();
        panel1.ResumeLayout(false);
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
    private Panel panel1;
    private Syncfusion.WinForms.Controls.SfButton btnShowAnswer;
}
