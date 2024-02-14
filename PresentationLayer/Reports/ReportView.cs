using Microsoft.Reporting.WinForms;

namespace PresentationLayer.Reports
{
    public partial class ReportView : Form
    {
        private readonly string _path;
        private readonly ReportDataSource _dataSource;
        private readonly LocalReport _localReport;

        public ReportView(string path, ReportDataSource dataSource, LocalReport localReport)
        {
            InitializeComponent();
            _path = path;
            _dataSource = dataSource;
            _localReport = localReport;
            _localReport = reportViewer1.LocalReport;
            Controls.Add(reportViewer1);
        }
        protected override void OnLoad(EventArgs e)
        {

            Reports.Load(_path, _dataSource, _localReport);
            reportViewer1.RefreshReport();
            base.OnLoad(e);
        }
    }
}