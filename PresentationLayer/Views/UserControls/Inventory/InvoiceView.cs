using DomainLayer.Models.Inventory;
using InfastructureLayer.DataAccess.Repositories;
using MaterialSkin.Controls;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Reports;
using ServiceLayer.Services.IRepositories;
using Syncfusion.WinForms.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Unity.Storage.RegistrationSet;

namespace RavenTech_ERP.Views.UserControls.Inventory
{
    public partial class InvoiceView : SfForm
    {
        private readonly SalesOrder _salesOrder;
        private readonly IUnitOfWork _unitOfWork;

        public InvoiceView(IUnitOfWork unitOfWork, SalesOrder salesOrder)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            _salesOrder = salesOrder;

            LoadAllInvoiceTypes();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            if (_salesOrder.Invoice == null)
            {
                _salesOrder.Invoice = new Invoice
                {
                    InvoiceName = Guid.NewGuid().ToString(),
                    InvoiceDate = DateTime.Now,
                    InvoiceDueDate = DateTime.Now,
                    InvoiceTypeId = (int)txtInvoiceType.SelectedValue
                };
            }
            _unitOfWork.SalesOrder.Value.Detach(_salesOrder);
            _unitOfWork.SalesOrder.Value.Update(_salesOrder);
            _unitOfWork.Save();

            string reportFileName = "InvoiceReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports", "Inventory");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("SalesOrderLine", _salesOrder.SalesOrderLines);
            var parameters = new List<ReportParameter>
            {
                new ReportParameter("InvoiceNumber", _salesOrder.Invoice.InvoiceName ?? string.Empty),
                new ReportParameter("InvoiceDate", _salesOrder.Invoice.InvoiceDate.ToString("MMM dd, yyyy")),
                new ReportParameter("Customer", _salesOrder.Customer.CustomerName),
                new ReportParameter("CustomerAddress", string.IsNullOrEmpty(_salesOrder.Customer.Address) ? " " : _salesOrder.Customer.Address),
                new ReportParameter("TotalSales", _salesOrder.SubTotal.ToString()),
                new ReportParameter("VATRate", "12%"),
                new ReportParameter("VAT", _salesOrder.Tax.ToString("N2")),
                new ReportParameter("NetOfVAT", _salesOrder.Total.ToString("N2")),
            };
            var reportView = new ReportView(reportPath, reportDataSource, localReport, parameters);
            reportView.ShowDialog();
        }

        private void LoadAllInvoiceTypes()
        {
            var invoiceTypes = _unitOfWork.InvoiceType.Value.GetAll();
            txtInvoiceType.DataSource = invoiceTypes;
            txtInvoiceType.DisplayMember = "InvoiceTypeName";
            txtInvoiceType.ValueMember = "InvoiceTypeId";
        }
    }
}
