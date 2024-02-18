using Microsoft.Reporting.WinForms;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Reports
{
    public static class Reports
    {
        public static void Load(string path, ReportDataSource? dataSource, LocalReport? report, List<ReportParameter>? parameters = null)
        {
            // Sample
            // Load report definition
            using (var fs = new FileStream(path, FileMode.Open))
            {
                report.LoadReportDefinition(fs);
                report.DataSources.Add(dataSource);
                report.SetParameters(parameters);
            }
        }
    }
    
}
