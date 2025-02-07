using Microsoft.Reporting.WinForms;

namespace PresentationLayer.Reports
{
    public partial class ReportView : Form
    {
        private readonly string _path;
        private readonly ReportDataSource _dataSource;
        private readonly LocalReport _localReport;
        private readonly List<ReportParameter>? _reportParameters;

        public ReportView(string path, ReportDataSource dataSource, LocalReport localReport, List<ReportParameter>? reportParameters = null)
        {
            InitializeComponent();
            _path = path;
            _dataSource = dataSource;
            _localReport = localReport;
            _reportParameters = reportParameters;
            _localReport = reportViewer1.LocalReport;
            _localReport.ReportPath = _path;
            _localReport.DataSources.Clear();
            _localReport.DataSources.Add(_dataSource);
            if (_reportParameters != null) _localReport.SetParameters(reportParameters);
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