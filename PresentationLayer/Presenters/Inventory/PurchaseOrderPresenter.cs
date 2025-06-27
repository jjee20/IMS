using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels;
using DomainLayer.ViewModels.Inventory;
using DomainLayer.ViewModels.InventoryViewModels;
using DomainLayer.ViewModels.PayrollViewModels;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using PresentationLayer.Views.UserControls;
using RavenTech_ERP.Views.IViews.Inventory;
using RavenTech_ERP.Views.UserControls;
using RavenTech_ERP.Views.UserControls.Inventory;
using ServiceLayer.Services.CommonServices;
using ServiceLayer.Services.IRepositories;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGrid.Events;
using System.Linq;
using static ServiceLayer.Services.CommonServices.EventClasses;
using static Unity.Storage.RegistrationSet;

namespace PresentationLayer.Presenters
{
    public class PurchaseOrderPresenter
    {
        public IPurchaseOrderView _view;
        private readonly IUnitOfWork _unitOfWork;
        
        private IEnumerable<PurchaseOrderViewModel> PurchaseOrderList;
        public PurchaseOrderPresenter(IPurchaseOrderView view, IUnitOfWork unitOfWork) {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            

            //Events
            _view.SearchEvent -= Search;
            _view.AddEvent -= AddNew;
            _view.EditEvent -= Edit;
            _view.DeleteEvent -= Delete;
            _view.MultipleDeleteEvent -= MultipleDelete;
            _view.PrintEvent -= Print;
            _view.VoucherEvent -= Voucher;
            _view.GRNEvent -= GRN;
            _view.BillEvent -= Bill;

            _view.VoucherEvent += Voucher;
            _view.SearchEvent += Search;
            _view.AddEvent += AddNew;
            _view.EditEvent += Edit;
            _view.GRNEvent += GRN;
            _view.BillEvent += Bill;
            _view.DeleteEvent += Delete;
            _view.MultipleDeleteEvent += MultipleDelete;
            _view.PrintEvent += Print;

            //Load

            LoadAllPurchaseOrderList();

            //Source Binding
        }

        private void GRN(object sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is PurchaseOrderViewModel row)
            {
                var entity = _unitOfWork.PurchaseOrder.Value.Get(c => c.PurchaseOrderId == row.PurchaseOrderId, includeProperties: "PurchaseOrderLines,Branch,Vendor,PurchaseType,GoodsReceivedNote,Bill,PaymentVoucher");
                
                if(entity.GoodsReceivedNote.Any())
                {
                    var form = new UpsertGoodsReceivedNoteView(_unitOfWork, entity);
                    form.Text = $"Edit Goods Received Note for P.O. #: {entity.PurchaseOrderName}";
                    form.ShowDialog();
                }
                else
                {
                    var form = new UpsertGoodsReceivedNoteView(_unitOfWork, entity);
                    form.Text = $"Add Goods Received Note for P.O. #: {entity.PurchaseOrderName}";
                    form.ShowDialog();
                }
            }
        }

        private void Bill(object sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is PurchaseOrderViewModel row)
            {
                var entity = _unitOfWork.PurchaseOrder.Value.Get(c => c.PurchaseOrderId == row.PurchaseOrderId, includeProperties: "PurchaseOrderLines,Branch,Vendor,PurchaseType,GoodsReceivedNote,Bill,PaymentVoucher");

                var form = new UpsertBillView(_unitOfWork, entity);
                form.ShowDialog();
            }
        }

        private void Voucher(object sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is PurchaseOrderViewModel row)
            {
                var entity = _unitOfWork.PurchaseOrder.Value.Get(c => c.PurchaseOrderId == row.PurchaseOrderId, includeProperties: "PurchaseOrderLines,Branch,Vendor,PurchaseType,GoodsReceivedNote,Bill,PaymentVoucher");

                var entityVM = Program.Mapper.Map<PurchaseOrderViewModel>(entity);
                var form = new PurchaseOrderInformationView(_unitOfWork, entity, entityVM);
                form.ShowDialog();
            }
        }

        private void AddNew(object? sender, EventArgs e)
        {
            using (var form = new UpsertPurchaseOrderView(_unitOfWork))
            {
                form.Text = "Add PurchaseOrder";
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadAllPurchaseOrderList();
                }
            }
        }
        
        private void Search(object? sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(_view.SearchValue);
            LoadAllPurchaseOrderList(emptyValue);
        }
        private void Edit(object? sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is PurchaseOrderViewModel row)
            {
                var entity = _unitOfWork.PurchaseOrder.Value.Get(c => c.PurchaseOrderId == row.PurchaseOrderId, includeProperties: "PurchaseOrderLines");
                using (var form = new UpsertPurchaseOrderView(_unitOfWork, entity))
                {
                    form.Text = "Edit PurchaseOrder";
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadAllPurchaseOrderList();
                    }
                }
            }
        }
        private void Delete(object? sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is PurchaseOrderViewModel row)
            {
                var entity = _unitOfWork.PurchaseOrder.Value.Get(c => c.PurchaseOrderId == row.PurchaseOrderId);
                if (entity != null)
                {
                    _unitOfWork.PurchaseOrder.Value.Remove(entity);
                    _unitOfWork.Save();

                    _view.ShowMessage("PurchaseOrder deleted successfully.");

                    LoadAllPurchaseOrderList();
                }
            }
        }
        private void MultipleDelete(object? sender, EventArgs e)
        {
            try
            {
                if (_view.DataGrid.SelectedItems == null || _view.DataGrid.SelectedItems.Count == 0)
                {
                    _view.ShowMessage("Please select item(s) to delete.");
                    return;
                }

                var selected = _view.DataGrid.SelectedItems.Cast<PurchaseOrderViewModel>().ToList(); // If you're using view models
                var ids = selected.Select(b => b.PurchaseOrderId).ToList();

                var entities = _unitOfWork.PurchaseOrder.Value
                    .GetAll()
                    .Where(b => ids.Contains(b.PurchaseOrderId))
                    .ToList();

                if (!entities.Any())
                {
                    _view.ShowMessage("Selected records could not be found.");
                    return;
                }

                _unitOfWork.PurchaseOrder.Value.RemoveRange(entities);
                _unitOfWork.Save();

                _view.ShowMessage($"{entities.Count} entries deleted successfully.");
                LoadAllPurchaseOrderList();
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"An error occurred while deleting: {ex.Message}");
            }
        }

        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "PurchaseOrderReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports", "Inventory");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("PurchaseOrder", PurchaseOrderList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        
        private async void LoadAllPurchaseOrderList(bool emptyValue = false)
        {

            PurchaseOrderList = Program.Mapper.Map<IEnumerable<PurchaseOrderViewModel>>(await _unitOfWork.PurchaseOrder.Value.GetAllAsync());

            if (!emptyValue) PurchaseOrderList = PurchaseOrderList.Where(c => c.PurchaseOrderName.ToLower().Contains(_view.SearchValue.ToLower()));


            _view.SetPurchaseOrderListBindingSource(PurchaseOrderList.OrderByDescending(c => c.OrderDate));
            
        }
    }
}
