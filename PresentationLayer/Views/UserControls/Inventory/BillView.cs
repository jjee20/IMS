﻿using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels.Inventory;
using MaterialSkin.Controls;
using PresentationLayer;
using ServiceLayer.Services.IRepositories.IInventory;
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
    public partial class BillView : MaterialForm
    {
        private readonly PurchaseOrder _purchaseOrder;
        private readonly IUnitOfWork _unitOfWork;
        public BillView(PurchaseOrder purchaseOrder, IUnitOfWork unitOfWork)
        {
            InitializeComponent();
            _purchaseOrder = purchaseOrder;
            _unitOfWork = unitOfWork;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (_purchaseOrder.Bill == null) 
                    _purchaseOrder.Bill = new Bill
                    {
                        BillName = Guid.NewGuid().ToString(),
                        BillDate = txtDate.Value,
                        BillDueDate = txtDueDate.Value,
                        BillTypeId = (int)txtBillType.SelectedValue,
                        VendorDONumber = txtVendorDONumber.Text,
                        VendorInvoiceNumber = txtVendorInvoiceNumber.Text,
                    };

                _unitOfWork.PurchaseOrder.Detach(_purchaseOrder);
                _unitOfWork.PurchaseOrder.Update(_purchaseOrder);
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
