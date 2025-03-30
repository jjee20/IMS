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
    public partial class GoodsReceivedNoteView : MaterialForm
    {
        private readonly PurchaseOrder _purchaseOrder;
        private readonly IUnitOfWork _unitOfWork;
        public GoodsReceivedNoteView(PurchaseOrder purchaseOrder, IUnitOfWork unitOfWork)
        {
            InitializeComponent();
            _purchaseOrder = purchaseOrder;
            _unitOfWork = unitOfWork;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                var grnList = _purchaseOrder.GoodsReceivedNote;
                var grns = new List<GoodsReceivedNote>();
                if (grnList.Any()) grns.AddRange(grnList);

                var grn = new GoodsReceivedNote
                {
                    GoodsReceivedNoteName = Guid.NewGuid().ToString(),
                    GRNDate = txtGRNDate.Value,
                    VendorDONumber = txtVendorDONumber.Text,
                    VendorInvoiceNumber = txtVendorInvoiceNumber.Text,
                    Remarks = txtRemarks.Text,
                    WarehouseId = (int)txtWarehouse.SelectedValue,
                    IsFullReceive = txtFullReceive.Checked
                };

                grns.Add(grn);

                _purchaseOrder.GoodsReceivedNote = grns;
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

        private void linkGRNs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var grnList = Program.Mapper.Map<IEnumerable<GoodsReceiveNoteViewModel>>(_purchaseOrder.GoodsReceivedNote);
            var bindingSource = new BindingSource();
            bindingSource.DataSource = grnList;
            var grns = new GoodsReceivedNoteListVView(bindingSource, _unitOfWork);
            grns.Text = $"GRN List for P.O. #: {_purchaseOrder.PurchaseOrderName}";
            grns.ShowDialog();
        }
    }
}
