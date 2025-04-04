using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels.Inventory;
using MaterialSkin.Controls;
using PresentationLayer;
using ServiceLayer.Services.IRepositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RavenTech_ERP.Views.UserControls.Inventory
{
    public partial class SalesOrderInformationView: MaterialForm
    {
        private readonly SalesOrder _salesOrder;
        private readonly SalesOrderViewModel _salesOrderVM;
        private readonly IUnitOfWork _unitOfWork;
        public SalesOrderInformationView(SalesOrder salesOrder, SalesOrderViewModel salesOrderVM, IUnitOfWork unitOfWork)
        {
            InitializeComponent();
            _salesOrder = salesOrder;
            _salesOrderVM = salesOrderVM;

            LoadSalesOrderInformation();
            _unitOfWork = unitOfWork;
        }

        private void LoadSalesOrderInformation()
        {
            txtSalesOrderName.Text = _salesOrder.SalesOrderName ?? "";
            txtSalesOrderBranch.Text = _salesOrderVM.Branch ?? "";
            txtSalesOrderRemarks.Text = _salesOrderVM.Remarks ?? "";
            txtSalesOrderCustomer.Text = _salesOrderVM.Customer ?? "";
            txtSalesOrderCustomerRefNo.Text = _salesOrderVM.CustomerRefNumber ?? "";
            txtSalesOrderDate.Text = _salesOrderVM.OrderDate.Date.ToLongDateString() ?? "";
            txtSalesOrderDeliveryDate.Text = _salesOrderVM.DeliveryDate.Date.ToLongDateString() ?? "";
            txtSalesOrderType.Text = _salesOrderVM.SalesType ?? "";
            txtSalesOrderTotalSales.Text = _salesOrderVM.SubTotal.ToString("N2") ?? "";
            txtSalesOrderDiscount.Text = _salesOrderVM.Discount.ToString("N2") ?? "";
            txtSalesOrderVAT.Text = _salesOrderVM.Tax.ToString("N2") ?? "";
            txtSalesOrderFreight.Text = _salesOrderVM.Freight.ToString("N2") ?? "";
            txtSalesOrderTotalNET.Text = _salesOrderVM.Total.ToString("N2") ?? "";
            txtShipmentNo.Text = _salesOrder.Shipment != null ? _salesOrder.Shipment.ShipmentName : "";
            txtShipmentDate.Text = _salesOrder.Shipment != null ? _salesOrder.Shipment.ShipmentDate.Date.ToLongDateString() : "";
            txtShipmentType.Text = _salesOrder.Shipment != null ? _salesOrder.Shipment.ShipmentType.ShipmentTypeName.ToString() : "";
            txtShipmentWarehouse.Text = _salesOrder.Shipment != null ? _salesOrder.Shipment.Warehouse.WarehouseName : "";
            txtInvoiceName.Text = _salesOrder.Invoice.InvoiceName ?? "";
            txtInvoiceDate.Text = _salesOrder.Invoice.InvoiceDate.Date.ToLongDateString() ?? "";
            txtInvoiceDueDate.Text = _salesOrder.Invoice.InvoiceDueDate.Date.ToLongDateString() ?? "";
            txtInvoiceType.Text = _salesOrder.Invoice.InvoiceType.InvoiceTypeName.ToString() ?? "";

            var paymentReceiveVM = Program.Mapper.Map<IEnumerable<PaymentReceiveInfoViewModel>>(_salesOrder.PaymentReceive);
            dgPaymentReceive.DataSource = paymentReceiveVM;

            var salesOrderLineVM = Program.Mapper.Map<IEnumerable<SalesOrderLineInfoViewModel>>(_salesOrder.SalesOrderLines);
            dgSalesOrderLines.DataSource = salesOrderLineVM;
        }
    }
}
