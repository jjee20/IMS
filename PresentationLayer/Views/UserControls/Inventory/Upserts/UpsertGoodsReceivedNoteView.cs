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
    public partial class UpsertGoodsReceivedNoteView : SfForm
    {
        private readonly PurchaseOrder _purchaseOrder;
        private readonly IUnitOfWork _unitOfWork;
        public UpsertGoodsReceivedNoteView(IUnitOfWork unitOfWork,PurchaseOrder purchaseOrder)
        {
            InitializeComponent();
            _purchaseOrder = purchaseOrder;
            _unitOfWork = unitOfWork;

            LoadWarehouse();
        }

        private void LoadWarehouse()
        {
            var warehouses = _unitOfWork.Warehouse.Value.GetAll();
            txtWarehouse.DataSource = warehouses;
            txtWarehouse.DisplayMember = "WarehouseName";
            txtWarehouse.ValueMember = "WarehouseId";
            txtWarehouse.Text = "~Select Warehouse~";
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
                    GRNDate = (DateTimeOffset)txtGRNDate.Value,
                    VendorDONumber = txtVendorDONumber.Text,
                    VendorInvoiceNumber = txtVendorInvoiceNumber.Text,
                    Remarks = txtRemarks.Text,
                    WarehouseId = (int)txtWarehouse.SelectedValue,
                    IsFullReceive = txtFullReceive.Checked
                };

                grns.Add(grn);

                _purchaseOrder.GoodsReceivedNote = grns;
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

        private void linkGRNs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var grnList = Program.Mapper.Map<IEnumerable<GoodsReceiveNoteViewModel>>(_purchaseOrder.GoodsReceivedNote);
            var grns = new GoodsReceivedNoteListVView(grnList, _unitOfWork);
            grns.Text = $"GRN List for P.O. #: {_purchaseOrder.PurchaseOrderName}";
            grns.ShowDialog();
        }
    }
}
