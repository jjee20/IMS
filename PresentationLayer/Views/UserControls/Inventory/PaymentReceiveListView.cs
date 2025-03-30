using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels.Inventory;
using MaterialSkin.Controls;
using ServiceLayer.Services.Helpers;
using ServiceLayer.Services.IRepositories;
using Syncfusion.Data.Extensions;
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
    public partial class PaymentReceiveListView : MaterialForm
    {
        private readonly BindingSource _bindingSource;
        private readonly IUnitOfWork _unitOfWork;
        public PaymentReceiveListView(BindingSource bindingSource, IUnitOfWork unitOfWork)
        {
            InitializeComponent();
            _bindingSource = bindingSource;

            LoadAllPaymentReceiveList();
            _unitOfWork = unitOfWork;
        }

        private void LoadAllPaymentReceiveList()
        {

            dgPager.DataSource = _bindingSource.ToList<PaymentReceiveViewModel>();
            dgList.DataSource = dgPager.PagedSource;
        }

        private void dgList_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var paymentReceive = (PaymentReceiveViewModel)_bindingSource.Current;
            var entity = _unitOfWork.PaymentReceive.Get(c => c.PaymentReceiveId == paymentReceive.PaymentReceiveId, tracked: true);

            var result = MessageBox.Show("Are you sure you want to delete the selected payment?", "Warning",
                       MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                _unitOfWork.PaymentReceive.Detach(entity);
                _unitOfWork.PaymentReceive.Remove(entity);
                _unitOfWork.Save();

                MessageBox.Show("Payment deleted successfully", "Delete Payment", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _bindingSource.Remove(paymentReceive);
            }
        }
    }
}
