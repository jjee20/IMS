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
    public partial class PaymentReceiveView : MaterialForm
    {
        private readonly SalesOrder _salesOrder;
        private readonly IUnitOfWork _unitOfWork;

        public PaymentReceiveView(SalesOrder salesOrder, IUnitOfWork unitOfWork)
        {
            InitializeComponent();
            _salesOrder = salesOrder;
            _unitOfWork = unitOfWork;

            LoadAllPaymentType();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                var paymentList = _salesOrder.PaymentReceive;
                var payments = new List<PaymentReceive>();
                if (paymentList.Any()) payments.AddRange(paymentList);

                var payment = new PaymentReceive
                {
                    PaymentReceiveName = Guid.NewGuid().ToString(),
                    PaymentDate = txtPaymentDate.Value,
                    PaymentTypeId = (int)txtPaymentType.SelectedValue,
                    PaymentAmount = double.Parse(txtAmount.Text),
                    IsFullPayment = txtFullPayment.Checked
                };

                payments.Add(payment);

                _salesOrder.PaymentReceive = payments;
                _unitOfWork.SalesOrder.Detach(_salesOrder);
                _unitOfWork.SalesOrder.Update(_salesOrder);
                _unitOfWork.Save();

                MessageBox.Show("Payment Received Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void LoadAllPaymentType()
        {
            txtPaymentType.DataSource = _unitOfWork.PaymentType.GetAll();
            txtPaymentType.ValueMember = "PaymentTypeId";
            txtPaymentType.DisplayMember = "PaymentTypeName";
        }

        private void linkPaymentList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var paymentReceiveList = Program.Mapper.Map<IEnumerable<PaymentReceiveViewModel>>(_salesOrder.PaymentReceive);
            var bindingSource = new BindingSource();
            bindingSource.DataSource = paymentReceiveList;
            var paymentList = new PaymentReceiveListView(bindingSource, _unitOfWork);
            paymentList.Text = $"Payment List for S.O. #: {_salesOrder.SalesOrderName}";
            paymentList.ShowDialog();
        }
    }
}
