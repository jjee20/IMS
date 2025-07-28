namespace RavenTech_ERP.Views.UserControls.ThinkEE;

partial class ExamTaken
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
        components = new System.ComponentModel.Container();
        var resources = new System.ComponentModel.ComponentResourceManager(typeof(ExamTaken));
        tableLayoutPanel1 = new TableLayoutPanel();
        panel1 = new Panel();
        panelQuestions = new Panel();
        tableLayoutPanel2 = new TableLayoutPanel();
        pBarPercentage = new Syncfusion.Windows.Forms.Tools.ProgressBarAdv();
        lblProgress = new Syncfusion.Windows.Forms.Tools.AutoLabel();
        tableLayoutPanel3 = new TableLayoutPanel();
        panel3 = new Panel();
        txtQuestionNo = new Syncfusion.WinForms.ListView.SfComboBox();
        btnForward = new Syncfusion.WinForms.Controls.SfButton();
        btnBackward = new Syncfusion.WinForms.Controls.SfButton();
        btnNext = new Syncfusion.WinForms.Controls.SfButton();
        btnPrevious = new Syncfusion.WinForms.Controls.SfButton();
        lblTimeRemaining = new Syncfusion.Windows.Forms.Tools.AutoLabel();
        backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
        examTimer = new System.Windows.Forms.Timer(components);
        tableLayoutPanel1.SuspendLayout();
        panel1.SuspendLayout();
        tableLayoutPanel2.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pBarPercentage).BeginInit();
        tableLayoutPanel3.SuspendLayout();
        panel3.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)txtQuestionNo).BeginInit();
        SuspendLayout();
        // 
        // tableLayoutPanel1
        // 
        tableLayoutPanel1.ColumnCount = 3;
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 35F));
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 35F));
        tableLayoutPanel1.Controls.Add(panel1, 1, 1);
        tableLayoutPanel1.Controls.Add(lblTimeRemaining, 1, 2);
        tableLayoutPanel1.Dock = DockStyle.Fill;
        tableLayoutPanel1.Location = new Point(1, 1);
        tableLayoutPanel1.Margin = new Padding(2, 2, 2, 2);
        tableLayoutPanel1.Name = "tableLayoutPanel1";
        tableLayoutPanel1.RowCount = 4;
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
        tableLayoutPanel1.Size = new Size(943, 435);
        tableLayoutPanel1.TabIndex = 0;
        // 
        // panel1
        // 
        panel1.Controls.Add(panelQuestions);
        panel1.Controls.Add(tableLayoutPanel2);
        panel1.Dock = DockStyle.Fill;
        panel1.Location = new Point(35, 30);
        panel1.Margin = new Padding(0);
        panel1.Name = "panel1";
        panel1.Size = new Size(873, 357);
        panel1.TabIndex = 0;
        // 
        // panelQuestions
        // 
        panelQuestions.Dock = DockStyle.Fill;
        panelQuestions.Location = new Point(0, 0);
        panelQuestions.Margin = new Padding(0);
        panelQuestions.Name = "panelQuestions";
        panelQuestions.Size = new Size(873, 280);
        panelQuestions.TabIndex = 5;
        // 
        // tableLayoutPanel2
        // 
        tableLayoutPanel2.ColumnCount = 1;
        tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tableLayoutPanel2.Controls.Add(pBarPercentage, 0, 1);
        tableLayoutPanel2.Controls.Add(lblProgress, 0, 2);
        tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 0, 0);
        tableLayoutPanel2.Dock = DockStyle.Bottom;
        tableLayoutPanel2.Location = new Point(0, 280);
        tableLayoutPanel2.Margin = new Padding(2, 2, 2, 2);
        tableLayoutPanel2.Name = "tableLayoutPanel2";
        tableLayoutPanel2.RowCount = 3;
        tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
        tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
        tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
        tableLayoutPanel2.Size = new Size(873, 77);
        tableLayoutPanel2.TabIndex = 4;
        // 
        // pBarPercentage
        // 
        pBarPercentage.BackgroundStyle = Syncfusion.Windows.Forms.Tools.ProgressBarBackgroundStyles.Gradient;
        pBarPercentage.BackMultipleColors = new Color[]
{
    Color.Empty
};
        pBarPercentage.BackSegments = false;
        pBarPercentage.BorderColor = Color.FromArgb(147, 149, 152);
        pBarPercentage.BorderStyle = BorderStyle.FixedSingle;
        pBarPercentage.CustomText = null;
        pBarPercentage.CustomWaitingRender = false;
        pBarPercentage.Dock = DockStyle.Fill;
        pBarPercentage.ForegroundImage = null;
        pBarPercentage.GradientEndColor = Color.FromArgb(22, 165, 220);
        pBarPercentage.GradientStartColor = Color.FromArgb(22, 165, 220);
        pBarPercentage.Location = new Point(2, 27);
        pBarPercentage.Margin = new Padding(2, 2, 2, 2);
        pBarPercentage.MultipleColors = new Color[]
{
    Color.Empty
};
        pBarPercentage.Name = "pBarPercentage";
        pBarPercentage.ProgressStyle = Syncfusion.Windows.Forms.Tools.ProgressBarStyles.Metro;
        pBarPercentage.SegmentWidth = 12;
        pBarPercentage.Size = new Size(869, 21);
        pBarPercentage.TabIndex = 8;
        pBarPercentage.ThemeName = "Metro";
        pBarPercentage.WaitingGradientWidth = 400;
        // 
        // lblProgress
        // 
        lblProgress.Dock = DockStyle.Fill;
        lblProgress.Location = new Point(2, 50);
        lblProgress.Margin = new Padding(2, 0, 2, 0);
        lblProgress.Name = "lblProgress";
        lblProgress.Size = new Size(869, 27);
        lblProgress.TabIndex = 9;
        lblProgress.Text = "1 out of 100";
        lblProgress.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // tableLayoutPanel3
        // 
        tableLayoutPanel3.ColumnCount = 3;
        tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 350F));
        tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tableLayoutPanel3.Controls.Add(panel3, 1, 0);
        tableLayoutPanel3.Dock = DockStyle.Fill;
        tableLayoutPanel3.Location = new Point(2, 2);
        tableLayoutPanel3.Margin = new Padding(2, 2, 2, 2);
        tableLayoutPanel3.Name = "tableLayoutPanel3";
        tableLayoutPanel3.RowCount = 1;
        tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tableLayoutPanel3.Size = new Size(869, 21);
        tableLayoutPanel3.TabIndex = 10;
        // 
        // panel3
        // 
        panel3.Controls.Add(txtQuestionNo);
        panel3.Controls.Add(btnForward);
        panel3.Controls.Add(btnBackward);
        panel3.Controls.Add(btnNext);
        panel3.Controls.Add(btnPrevious);
        panel3.Dock = DockStyle.Fill;
        panel3.Location = new Point(259, 0);
        panel3.Margin = new Padding(0);
        panel3.Name = "panel3";
        panel3.Size = new Size(350, 21);
        panel3.TabIndex = 12;
        // 
        // txtQuestionNo
        // 
        txtQuestionNo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        txtQuestionNo.Dock = DockStyle.Fill;
        txtQuestionNo.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
        txtQuestionNo.Location = new Point(137, 0);
        txtQuestionNo.Margin = new Padding(2, 2, 2, 2);
        txtQuestionNo.Name = "txtQuestionNo";
        txtQuestionNo.Padding = new Padding(5, 0, 0, 0);
        txtQuestionNo.Size = new Size(76, 21);
        txtQuestionNo.Style.TokenStyle.CloseButtonBackColor = Color.FromArgb(255, 255, 255);
        txtQuestionNo.TabIndex = 5;
        txtQuestionNo.TabStop = false;
        txtQuestionNo.SelectedIndexChanged += txtQuestionNo_SelectedIndexChanged;
        // 
        // btnForward
        // 
        btnForward.Dock = DockStyle.Right;
        btnForward.Font = new Font("Segoe UI Semibold", 9F);
        btnForward.Location = new Point(213, 0);
        btnForward.Margin = new Padding(2, 2, 2, 2);
        btnForward.Name = "btnForward";
        btnForward.Size = new Size(36, 21);
        btnForward.Style.Image = (Image)resources.GetObject("resource.Image");
        btnForward.TabIndex = 4;
        btnForward.Click += btnForward_Click;
        // 
        // btnBackward
        // 
        btnBackward.Dock = DockStyle.Left;
        btnBackward.Font = new Font("Segoe UI Semibold", 9F);
        btnBackward.Location = new Point(101, 0);
        btnBackward.Margin = new Padding(2, 2, 2, 2);
        btnBackward.Name = "btnBackward";
        btnBackward.Size = new Size(36, 21);
        btnBackward.Style.Image = (Image)resources.GetObject("resource.Image1");
        btnBackward.TabIndex = 3;
        btnBackward.Click += btnBackward_Click;
        // 
        // btnNext
        // 
        btnNext.BackColor = Color.DodgerBlue;
        btnNext.Dock = DockStyle.Right;
        btnNext.Font = new Font("Segoe UI Semibold", 9F);
        btnNext.ForeColor = Color.Black;
        btnNext.Location = new Point(249, 0);
        btnNext.Margin = new Padding(2, 2, 2, 2);
        btnNext.Name = "btnNext";
        btnNext.Size = new Size(101, 21);
        btnNext.Style.BackColor = Color.DodgerBlue;
        btnNext.Style.ForeColor = Color.Black;
        btnNext.TabIndex = 1;
        btnNext.Text = "Next";
        btnNext.UseVisualStyleBackColor = false;
        btnNext.Click += btnNext_Click;
        // 
        // btnPrevious
        // 
        btnPrevious.BackColor = Color.Teal;
        btnPrevious.Dock = DockStyle.Left;
        btnPrevious.Font = new Font("Segoe UI Semibold", 9F);
        btnPrevious.ForeColor = Color.White;
        btnPrevious.Location = new Point(0, 0);
        btnPrevious.Margin = new Padding(2, 2, 2, 2);
        btnPrevious.Name = "btnPrevious";
        btnPrevious.Size = new Size(101, 21);
        btnPrevious.Style.BackColor = Color.Teal;
        btnPrevious.Style.ForeColor = Color.White;
        btnPrevious.TabIndex = 0;
        btnPrevious.Text = "Previous";
        btnPrevious.UseVisualStyleBackColor = false;
        btnPrevious.Click += btnPrevious_Click;
        // 
        // lblTimeRemaining
        // 
        lblTimeRemaining.Dock = DockStyle.Fill;
        lblTimeRemaining.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
        lblTimeRemaining.Location = new Point(37, 387);
        lblTimeRemaining.Margin = new Padding(2, 0, 2, 0);
        lblTimeRemaining.Name = "lblTimeRemaining";
        lblTimeRemaining.Size = new Size(869, 24);
        lblTimeRemaining.TabIndex = 10;
        lblTimeRemaining.Text = "Time Remaining";
        lblTimeRemaining.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // backgroundWorker1
        // 
        backgroundWorker1.DoWork += backgroundWorker1_DoWork;
        backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
        backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
        // 
        // examTimer
        // 
        examTimer.Interval = 1000;
        examTimer.Tick += examTimer_Tick;
        // 
        // ExamTaken
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(945, 437);
        Controls.Add(tableLayoutPanel1);
        Icon = (Icon)resources.GetObject("$this.Icon");
        Margin = new Padding(2, 2, 2, 2);
        Name = "ExamTaken";
        StartPosition = FormStartPosition.CenterScreen;
        Style.MdiChild.IconHorizontalAlignment = HorizontalAlignment.Center;
        Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
        Text = "Exam";
        FormClosing += ExamTaken_FormClosing;
        tableLayoutPanel1.ResumeLayout(false);
        tableLayoutPanel1.PerformLayout();
        panel1.ResumeLayout(false);
        tableLayoutPanel2.ResumeLayout(false);
        tableLayoutPanel2.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)pBarPercentage).EndInit();
        tableLayoutPanel3.ResumeLayout(false);
        panel3.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)txtQuestionNo).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel tableLayoutPanel1;
    private Panel panel1;
    private TableLayoutPanel tableLayoutPanel2;
    private Syncfusion.Windows.Forms.Tools.ProgressBarAdv pBarPercentage;
    private Syncfusion.Windows.Forms.Tools.AutoLabel lblProgress;
    private Panel panelQuestions;
    private TableLayoutPanel tableLayoutPanel3;
    private Panel panel3;
    private Syncfusion.WinForms.Controls.SfButton btnForward;
    private Syncfusion.WinForms.Controls.SfButton btnBackward;
    private Syncfusion.WinForms.Controls.SfButton btnNext;
    private Syncfusion.WinForms.Controls.SfButton btnPrevious;
    private Syncfusion.WinForms.ListView.SfComboBox txtQuestionNo;
    private Syncfusion.Windows.Forms.Tools.AutoLabel lblTimeRemaining;
    private System.ComponentModel.BackgroundWorker backgroundWorker1;
    private System.Windows.Forms.Timer examTimer;
}