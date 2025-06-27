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
    public class SalesOrderPresenter
    {
        public ISalesOrderView _view;
        private readonly IUnitOfWork _unitOfWork;
        
        private IEnumerable<SalesOrderViewModel> SalesOrderList;
        public SalesOrderPresenter(ISalesOrderView view, IUnitOfWork unitOfWork) {

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
            view.PaymentEvent -= Payment;
            _view.InvoiceEvent -= Invoice;
            _view.DetailsEvent -= Details;

            _view.SearchEvent += Search;
            _view.AddEvent += AddNew;
            _view.EditEvent += Edit;
            view.PaymentEvent += Payment;
            _view.InvoiceEvent += Invoice;
            _view.DetailsEvent += Details;
            _view.DeleteEvent += Delete;
            _view.MultipleDeleteEvent += MultipleDelete;
            _view.PrintEvent += Print;

            //Load

            LoadAllSalesOrderList();

            //Source Binding
        }

        private void Payment(object sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is SalesOrderViewModel row)
            {
                var entity = _unitOfWork.SalesOrder.Value.Get(c => c.SalesOrderId == row.SalesOrderId, includeProperties: "SalesOrderLines,Invoice,Customer,Shipment,PaymentReceive");
                
                if(entity.PaymentReceive.Any())
                {
                    var form = new UpsertPaymentReceiveView(_unitOfWork, entity);
                    form.Text = $"Edit Payment for S.O. #: {entity.SalesOrderName}";
                    form.ShowDialog();
                }
                else
                {
                    var form = new UpsertPaymentReceiveView(_unitOfWork, entity);
                    form.Text = $"Add Payment for S.O. #: {entity.SalesOrderName}";
                    form.ShowDialog();
                }
            }
        }

        private void Invoice(object sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is SalesOrderViewModel row)
            {
                var entity = _unitOfWork.SalesOrder.Value.Get(c => c.SalesOrderId == row.SalesOrderId, includeProperties: "SalesOrderLines,Invoice,Customer,Shipment,PaymentReceive");

                var form = new InvoiceView(_unitOfWork, entity);
                form.ShowDialog();
            }
        }

        private void Details(object sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is SalesOrderViewModel row)
            {
                var entity = _unitOfWork.SalesOrder.Value.Get(c => c.SalesOrderId == row.SalesOrderId, includeProperties: "SalesOrderLines,Invoice,Customer,Shipment,PaymentReceive");
                var entityVM = Program.Mapper.Map<SalesOrderViewModel>(entity);
                var form = new SalesOrderInformationView(_unitOfWork, entity, entityVM);
                form.ShowDialog();
            }
        }

        private void AddNew(object? sender, EventArgs e)
        {
            using (var form = new UpsertSalesOrderView(_unitOfWork))
            {
                form.Text = "Add SalesOrder";
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadAllSalesOrderList();
                }
            }
        }
        
        private void Search(object? sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(_view.SearchValue);
            LoadAllSalesOrderList(emptyValue);
        }
        private void Edit(object? sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is SalesOrderViewModel row)
            {
                var entity = _unitOfWork.SalesOrder.Value.Get(c => c.SalesOrderId == row.SalesOrderId, includeProperties: "SalesOrderLines");
                using (var form = new UpsertSalesOrderView(_unitOfWork, entity))
                {
                    form.Text = "Edit SalesOrder";
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadAllSalesOrderList();
                    }
                }
            }
        }
        private void Delete(object? sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is SalesOrderViewModel row)
            {
                var entity = _unitOfWork.SalesOrder.Value.Get(c => c.SalesOrderId == row.SalesOrderId);
                if (entity != null)
                {
                    _unitOfWork.SalesOrder.Value.Remove(entity);
                    _unitOfWork.Save();

                    _view.ShowMessage("SalesOrder deleted successfully.");

                    LoadAllSalesOrderList();
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

                var selected = _view.DataGrid.SelectedItems.Cast<SalesOrderViewModel>().ToList(); // If you're using view models
                var ids = selected.Select(b => b.SalesOrderId).ToList();

                var entities = _unitOfWork.SalesOrder.Value
                    .GetAll()
                    .Where(b => ids.Contains(b.SalesOrderId))
                    .ToList();

                if (!entities.Any())
                {
                    _view.ShowMessage("Selected records could not be found.");
                    return;
                }

                _unitOfWork.SalesOrder.Value.RemoveRange(entities);
                _unitOfWork.Save();

                _view.ShowMessage($"{entities.Count} entries deleted successfully.");
                LoadAllSalesOrderList();
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"An error occurred while deleting: {ex.Message}");
            }
        }

        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "SalesOrderReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports", "Inventory");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("SalesOrder", SalesOrderList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        
        private async void LoadAllSalesOrderList(bool emptyValue = false)
        {

            SalesOrderList = Program.Mapper.Map<IEnumerable<SalesOrderViewModel>>(await _unitOfWork.SalesOrder.Value.GetAllAsync());

            if (!emptyValue) SalesOrderList = SalesOrderList.Where(c => c.SalesOrderName.ToLower().Contains(_view.SearchValue.ToLower()));


            _view.SetSalesOrderListBindingSource(SalesOrderList.OrderByDescending(c => c.OrderDate));

            
        }
    }
}
