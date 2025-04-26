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
    public partial class UpsertBillView : SfForm
    {
        private readonly PurchaseOrder _purchaseOrder;
        private readonly IUnitOfWork _unitOfWork;
        public UpsertBillView(IUnitOfWork unitOfWork,PurchaseOrder purchaseOrder)
        {
            InitializeComponent();
            _purchaseOrder = purchaseOrder;
            _unitOfWork = unitOfWork;

            LoadBill();
        }

        private void LoadBill()
        {
            if(_purchaseOrder.Bill != null)
            {
                txtDate.Value = _purchaseOrder.Bill.BillDate.Date;
                txtDueDate.Value = _purchaseOrder.Bill.BillDueDate.Date;
                txtBillType.SelectedValue = _purchaseOrder.Bill.BillTypeId;
                txtVendorDONumber.Text = _purchaseOrder.Bill.VendorDONumber;
                txtVendorInvoiceNumber.Text = _purchaseOrder.Bill.VendorInvoiceNumber;
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (_purchaseOrder.Bill == null) 
                    _purchaseOrder.Bill = new Bill
                    {
                        BillName = Guid.NewGuid().ToString(),
                        BillDate = (DateTimeOffset)txtDate.Value,
                        BillDueDate = (DateTimeOffset)txtDueDate.Value,
                        BillTypeId = (int)txtBillType.SelectedValue,
                        VendorDONumber = txtVendorDONumber.Text,
                        VendorInvoiceNumber = txtVendorInvoiceNumber.Text,
                    };

                _unitOfWork.PurchaseOrder.Value.Detach(_purchaseOrder);
                _unitOfWork.PurchaseOrder.Value.Update(_purchaseOrder);
                _unitOfWork.Save();

                MessageBox.Show("Goods Received Note created successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
