namespace RavenTech_ERP.Views.UserControls.ThinkEE;

partial class AvailableExamView
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
        var resources = new System.ComponentModel.ComponentResourceManager(typeof(AvailableExamView));
        flowLayoutPanelExams = new FlowLayoutPanel();
        btnRefresh = new Syncfusion.WinForms.Controls.SfButton();
        SuspendLayout();
        // 
        // flowLayoutPanelExams
        // 
        flowLayoutPanelExams.Dock = DockStyle.Fill;
        flowLayoutPanelExams.Location = new Point(2, 44);
        flowLayoutPanelExams.Name = "flowLayoutPanelExams";
        flowLayoutPanelExams.Padding = new Padding(20);
        flowLayoutPanelExams.Size = new Size(1340, 666);
        flowLayoutPanelExams.TabIndex = 0;
        // 
        // btnRefresh
        // 
        btnRefresh.BackColor = Color.DodgerBlue;
        btnRefresh.Dock = DockStyle.Top;
        btnRefresh.Font = new Font("Segoe UI Semibold", 9F);
        btnRefresh.ForeColor = Color.White;
        btnRefresh.Location = new Point(2, 2);
        btnRefresh.Name = "btnRefresh";
        btnRefresh.Size = new Size(1340, 42);
        btnRefresh.Style.BackColor = Color.DodgerBlue;
        btnRefresh.Style.ForeColor = Color.White;
        btnRefresh.TabIndex = 0;
        btnRefresh.Text = "Refresh Page";
        btnRefresh.UseVisualStyleBackColor = false;
        btnRefresh.Click += btnRefresh_Click;
        // 
        // AvailableExamView
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1344, 712);
        Controls.Add(flowLayoutPanelExams);
        Controls.Add(btnRefresh);
        Icon = (Icon)resources.GetObject("$this.Icon");
        Name = "AvailableExamView";
        StartPosition = FormStartPosition.Manual;
        Style.MdiChild.IconHorizontalAlignment = HorizontalAlignment.Center;
        Style.MdiChild.IconVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
        Text = "Available Exams/Quizzes";
        ResumeLayout(false);
    }

    #endregion

    private FlowLayoutPanel flowLayoutPanelExams;
    private Syncfusion.WinForms.Controls.SfButton btnRefresh;
}