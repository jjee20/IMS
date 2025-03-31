using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels.Inventory;
using MaterialSkin.Controls;
using PresentationLayer;
using RavenTech_ERP.Views.UserControls.Inventory;
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

namespace RavenTech_ERP.Views.UserControls
{
    public partial class PaymentVoucherView : MaterialForm
    {
        private readonly PurchaseOrder _PurchaseOrder;
        private readonly IUnitOfWork _unitOfWork;

        public PaymentVoucherView(PurchaseOrder PurchaseOrder, IUnitOfWork unitOfWork)
        {
            InitializeComponent();
            _PurchaseOrder = PurchaseOrder;
            _unitOfWork = unitOfWork;

            LoadAllPaymentType();
            LoadAllCashBank();
        }

        private void LoadAllCashBank()
        {
            txtCashBank.DataSource = _unitOfWork.CashBank.Value.GetAll();
            txtCashBank.ValueMember = "CashBankId";
            txtCashBank.DisplayMember = "CashBankName";
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                var paymentList = _PurchaseOrder.PaymentVoucher;
                var payments = new List<PaymentVoucher>();
                if (paymentList.Any()) payments.AddRange(paymentList);

                var payment = new PaymentVoucher
                {
                    PaymentVoucherName = Guid.NewGuid().ToString(),
                    PaymentDate = txtPaymentDate.Value,
                    PaymentTypeId = (int)txtPaymentType.SelectedValue,
                    PaymentAmount = double.Parse(txtAmount.Text),
                    CashBankId = (int)txtCashBank.SelectedValue,
                    IsFullPayment = txtFullPayment.Checked
                };

                payments.Add(payment);

                _PurchaseOrder.PaymentVoucher = payments;
                _unitOfWork.PurchaseOrder.Value.Detach(_PurchaseOrder);
                _unitOfWork.PurchaseOrder.Value.Update(_PurchaseOrder);
                _unitOfWork.Save();

                MessageBox.Show("Payment Voucher created successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void LoadAllPaymentType()
        {
            txtPaymentType.DataSource = _unitOfWork.PaymentType.Value.GetAll();
            txtPaymentType.ValueMember = "PaymentTypeId";
            txtPaymentType.DisplayMember = "PaymentTypeName";
        }

        private void linkPaymentList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var PaymentVoucherList = Program.Mapper.Map<IEnumerable<PaymentVoucherViewModel>>(_PurchaseOrder.PaymentVoucher);
            var bindingSource = new BindingSource();
            bindingSource.DataSource = PaymentVoucherList;
            var paymentList = new PaymentVoucherListView(bindingSource, _unitOfWork);
            paymentList.Text = $"Payment List for S.O. #: {_PurchaseOrder.PurchaseOrderName}";
            paymentList.ShowDialog();
        }
    }
}
