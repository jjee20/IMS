using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels.Inventory;
using MaterialSkin.Controls;
using PresentationLayer;
using RavenTech_ERP.Views.UserControls.Inventory;
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

namespace RavenTech_ERP.Views.UserControls
{
    public partial class UpsertPaymentReceiveView : SfForm
    {
        private readonly SalesOrder _salesOrder;
        private readonly IUnitOfWork _unitOfWork;

        public UpsertPaymentReceiveView(IUnitOfWork unitOfWork, SalesOrder salesOrder)
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
                    PaymentDate = (DateTimeOffset)txtPaymentDate.Value,
                    PaymentTypeId = (int)txtPaymentType.SelectedValue,
                    PaymentAmount = double.Parse(txtAmount.Text),
                    IsFullPayment = txtFullPayment.Checked
                };

                payments.Add(payment);

                _salesOrder.PaymentReceive = payments;
                _unitOfWork.SalesOrder.Value.Detach(_salesOrder);
                _unitOfWork.SalesOrder.Value.Update(_salesOrder);
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
            txtPaymentType.DataSource = _unitOfWork.PaymentType.Value.GetAll();
            txtPaymentType.ValueMember = "PaymentTypeId";
            txtPaymentType.DisplayMember = "PaymentTypeName";
            txtPaymentType.Text = "~Select Payment Type~";
        }

        private void linkPaymentList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var paymentReceiveList = Program.Mapper.Map<IEnumerable<PaymentReceiveViewModel>>(_salesOrder.PaymentReceive);
            var paymentList = new PaymentReceiveListView(paymentReceiveList, _unitOfWork);
            paymentList.Text = $"Payment Received List for S.O. #: {_salesOrder.SalesOrderName}";
            paymentList.ShowDialog();
        }
    }
}
