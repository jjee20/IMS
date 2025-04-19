using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels.Inventory;
using MaterialSkin.Controls;
using PresentationLayer;
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

namespace RavenTech_ERP.Views.UserControls.Inventory
{
    public partial class PurchaseOrderInformationView: SfForm
    {
        private readonly PurchaseOrder _PurchaseOrder;
        private readonly PurchaseOrderViewModel _PurchaseOrderVM;
        private readonly IUnitOfWork _unitOfWork;
        public PurchaseOrderInformationView(IUnitOfWork unitOfWork, PurchaseOrder PurchaseOrder, PurchaseOrderViewModel PurchaseOrderVM)
        {
            InitializeComponent();
            _PurchaseOrder = PurchaseOrder;
            _PurchaseOrderVM = PurchaseOrderVM;

            LoadPurchaseOrderInformation();
            _unitOfWork = unitOfWork;
        }

        private void LoadPurchaseOrderInformation()
        {
            txtPurchaseOrderName.Text = _PurchaseOrder.PurchaseOrderName ?? "";
            txtPurchaseOrderBranch.Text = _PurchaseOrderVM.Branch ?? "";
            txtPurchaseOrderRemarks.Text = _PurchaseOrderVM.Remarks ?? "";
            txtPurchaseOrderVendor.Text = _PurchaseOrderVM.Vendor ?? "";
            txtPurchaseOrderDate.Text = _PurchaseOrderVM.OrderDate.Date.ToLongDateString() ?? "";
            txtPurchaseOrderDeliveryDate.Text = _PurchaseOrderVM.DeliveryDate.Date.ToLongDateString() ?? "";
            txtPurchaseOrderType.Text = _PurchaseOrderVM.PurchaseType ?? "";
            txtPurchaseOrderTotalPurchase.Text = _PurchaseOrderVM.SubTotal.ToString("N2") ?? "";
            txtPurchaseOrderDiscount.Text = _PurchaseOrderVM.Discount.ToString("N2") ?? "";
            txtPurchaseOrderVAT.Text = _PurchaseOrderVM.Tax.ToString("N2") ?? "";
            txtPurchaseOrderFreight.Text = _PurchaseOrderVM.Freight.ToString("N2") ?? "";
            txtPurchaseOrderTotalNET.Text = _PurchaseOrderVM.Total.ToString("N2") ?? "";
            txtBillNo.Text = _PurchaseOrder.Bill != null ? _PurchaseOrder.Bill.BillName : "";
            txtBillDate.Text = _PurchaseOrder.Bill != null ? _PurchaseOrder.Bill.BillDate.Date.ToLongDateString() : "";
            txtBillType.Text = _PurchaseOrder.Bill != null ? _PurchaseOrder.Bill.BillType.BillTypeName.ToString() : "";
            txtBillVendorDONo.Text = _PurchaseOrder.Bill != null ? _PurchaseOrder.Bill.VendorDONumber : "";
            txtBillVendorInvoiceNo.Text = _PurchaseOrder.Bill != null ? _PurchaseOrder.Bill.VendorInvoiceNumber : "";
            txtBillDueDate.Text = _PurchaseOrder.Bill != null ? _PurchaseOrder.Bill.BillDueDate.Date.ToLongDateString() : "";

            var grnVM = Program.Mapper.Map<IEnumerable<GoodsReceiveNoteInfoViewModel>>(_PurchaseOrder.GoodsReceivedNote);
            dgGoodsReceivedNote.DataSource = grnVM;

            var paymentVoucherVM = Program.Mapper.Map<IEnumerable<PaymentVoucherInfoViewModel>>(_PurchaseOrder.PaymentVoucher);
            dgPaymentVoucher.DataSource = paymentVoucherVM;
        }
    }
}
