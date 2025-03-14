﻿using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels.Inventory;
using MaterialSkin.Controls;
using ServiceLayer.Services.Helpers;
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
    public partial class PaymentVoucherListView : MaterialForm
    {
        private readonly BindingSource _bindingSource;
        private readonly IUnitOfWork _unitOfWork;
        public PaymentVoucherListView(BindingSource bindingSource, IUnitOfWork unitOfWork)
        {
            InitializeComponent();
            _bindingSource = bindingSource;

            LoadAllPaymentVoucherList();
            _unitOfWork = unitOfWork;
        }

        private void LoadAllPaymentVoucherList()
        {

            dgList.DataSource = _bindingSource;
            DataGridHelper.ApplyDisplayNames<PaymentVoucherViewModel>(_bindingSource, dgList);
        }

        private void dgList_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var PaymentVoucher = (PaymentVoucherViewModel)_bindingSource.Current;
            var entity = _unitOfWork.PaymentVoucher.Get(c => c.PaymentVoucherId == PaymentVoucher.PaymentVoucherId, tracked: true);

            var result = MessageBox.Show("Are you sure you want to delete the selected payment voucher?", "Warning",
                       MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                _unitOfWork.PaymentVoucher.Detach(entity);
                _unitOfWork.PaymentVoucher.Remove(entity);
                _unitOfWork.Save();

                MessageBox.Show("Payment voucher deleted successfully", "Delete Payment", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _bindingSource.Remove(PaymentVoucher);
            }
        }
    }
}
