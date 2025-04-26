using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels.Inventory;
using MaterialSkin.Controls;
using RavenTech_ERP.Properties;
using ServiceLayer.Services.Helpers;
using ServiceLayer.Services.IRepositories;
using Syncfusion.Data.Extensions;
using Syncfusion.WinForms.Controls;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGrid.Events;
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
    public partial class PaymentVoucherListView : SfForm
    {
        private readonly IEnumerable<PaymentVoucherViewModel> _paymentVoucher;
        private readonly IUnitOfWork _unitOfWork;
        public PaymentVoucherListView(IEnumerable<PaymentVoucherViewModel> paymentVoucher, IUnitOfWork unitOfWork)
        {
            InitializeComponent();
            _paymentVoucher = paymentVoucher;

            LoadAllPaymentVoucherList();
            _unitOfWork = unitOfWork;
        }

        private void LoadAllPaymentVoucherList()
        {

            dgPager.DataSource = _paymentVoucher;

            foreach (var item in _paymentVoucher)
            {
                item.Delete = Resources.delete;
            }

            dgList.DataSource = dgPager.DataSource;
        }

        private void dgList_CellClick(object sender, CellClickEventArgs e)
        {
            if (e.DataColumn.GridColumn.MappingName == "Delete")
            {
                if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is PaymentVoucherViewModel row)
                {
                    var entity = _unitOfWork.PaymentVoucher.Value.Get(c => c.PaymentVoucherId == row.PaymentVoucherId);

                    var result = MessageBox.Show("Are you sure you want to delete the selected voucher?", "Warning",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        _unitOfWork.PaymentVoucher.Value.Detach(entity);
                        _unitOfWork.PaymentVoucher.Value.Remove(entity);
                        _unitOfWork.Save();

                        MessageBox.Show("Voucher deleted successfully", "Delete Payment", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        _paymentVoucher.ToList().Remove(row);

                        dgList.DataSource = null;
                        dgList.DataSource = _paymentVoucher;
                    }
                }
            }
        }
    }
}
