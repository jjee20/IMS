using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels;
using DomainLayer.ViewModels.Inventory;
using DomainLayer.ViewModels.InventoryViewModels;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using PresentationLayer.Views.UserControls;
using RavenTech_ERP.Views.IViews.Inventory;
using RavenTech_ERP.Views.UserControls.Inventory;
using RavenTech_ERP.Views.UserControls.Inventory.Upserts;
using ServiceLayer.Services.CommonServices;
using ServiceLayer.Services.IRepositories;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGrid.Events;
using System.Linq;
using static ServiceLayer.Services.CommonServices.EventClasses;
using static Unity.Storage.RegistrationSet;

namespace PresentationLayer.Presenters
{
    public class ProductPullOutLogPresenter
    {
        public IProductPullOutLogView _view;
        private readonly IUnitOfWork _unitOfWork;
        
        private IEnumerable<ProductPullOutLogViewModel> ProductPullOutLogList;
        public ProductPullOutLogPresenter(IProductPullOutLogView view, IUnitOfWork unitOfWork) {

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
            _view.RefreshEvent -= Refresh;
            _view.IndividualPrintEvent -= IndividualPrint;

            _view.SearchEvent += Search;
            _view.AddEvent += AddNew;
            _view.EditEvent += Edit;
            _view.DeleteEvent += Delete;
            _view.MultipleDeleteEvent += MultipleDelete;
            _view.PrintEvent += Print;
            _view.RefreshEvent += Refresh;
            _view.IndividualPrintEvent += IndividualPrint;

            //Load

            LoadAllProductPullOutLogList();

            //Source Binding
        }
        private void IndividualPrint(object? sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is ProductPullOutLogViewModel row)
            {
                var entity = _unitOfWork.ProductPullOutLogs.Value.Get(c => c.ProductPullOutLogId == row.ProductPullOutLogId, includeProperties: "ProductPullOutLogLines.Product.UnitOfMeasure,Project");

                var lines = entity.ProductPullOutLogLines.Select(pl => new ProductPullOutLogLinesViewModel
                {
                    DateAdded = pl.DateAdded.ToShortDateString(),
                    Product = pl.Product.ProductName,
                    Quantity = pl.StockQuantity,
                    Unit = pl.Product.UnitOfMeasure.UnitOfMeasureName,
                    Size = pl.Product.Size,
                    Color = pl.Product.Color,
                    UnitCost = pl.Product.DefaultBuyingPrice,
                }).ToList();

                if (entity != null)
                {
                    var reportFileName = "ProductPullOutLogIndividualReport.rdlc";
                    var reportDirectory = Path.Combine(Application.StartupPath, "Reports", "Inventory");
                    var reportPath = Path.Combine(reportDirectory, reportFileName);
                    var localReport = new LocalReport();
                    var reportParameters = new List<ReportParameter>
                    {
                        new("Project", entity.Project?.ProjectName ?? "N/A"),
                        new("DeliveredBy", entity.DeliveredBy ?? "N/A"),
                        new("DeliveredDate", entity.DeliveredDate?.ToShortDateString() ?? "N/A"),
                        new("ReceivedBy", entity.ReceivedBy ?? "N/A"),
                        new("ReceivedDate", entity.ReceivedDate?.ToShortDateString() ?? "N/A")
                    };

                    var reportDataSource = new ReportDataSource("ProductPullOutLogLines", lines);
                    var reportView = new ReportView(reportPath, reportDataSource, localReport, reportParameters);
                    reportView.ShowDialog();
                }
            }
        }
        private void Refresh(object? sender, EventArgs e) => LoadAllProductPullOutLogList();

        private void AddNew(object? sender, EventArgs e)
        {
            using (var form = new UpsertProductPullOutLogView(_unitOfWork))
            {
                form.Text = "Add Product Pull-Out Log";
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadAllProductPullOutLogList();
                }
            }
        }
        
        private void Search(object? sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(_view.SearchValue);
            LoadAllProductPullOutLogList(emptyValue);
        }
        private void Edit(object? sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is ProductPullOutLogViewModel row)
            {
                var entity = _unitOfWork.ProductPullOutLogs.Value.Get(c => c.ProductPullOutLogId == row.ProductPullOutLogId, includeProperties: "ProductPullOutLogLines.Product");
                using (var form = new UpsertProductPullOutLogView(_unitOfWork,entity))
                {
                    form.Text = "Edit Product Pull-Out Log";
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadAllProductPullOutLogList();
                    }
                }
            }
        }
        private void Delete(object? sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is ProductPullOutLogViewModel row)
            {
                var entity = _unitOfWork.ProductPullOutLogs.Value.Get(c => c.ProductPullOutLogId == row.ProductPullOutLogId, includeProperties: "ProductPullOutLogLines");
                if (entity != null)
                {
                    _unitOfWork.ProductPullOutLogLines.Value.RemoveRange(entity.ProductPullOutLogLines);
                    _unitOfWork.ProductPullOutLogs.Value.Remove(entity);
                    _unitOfWork.Save();

                    _view.ShowMessage("ProductPullOutLog deleted successfully.");

                    LoadAllProductPullOutLogList();
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

                var selected = _view.DataGrid.SelectedItems.Cast<ProductPullOutLogViewModel>().ToList(); // If you're using view models
                var ids = selected.Select(b => b.ProductPullOutLogId).ToList();

                var entities = _unitOfWork.ProductPullOutLogs.Value
                    .GetAll(includeProperties: "ProductPullOutLogLines")
                    .Where(b => ids.Contains(b.ProductPullOutLogId))
                    .ToList();

                if (!entities.Any())
                {
                    _view.ShowMessage("Selected records could not be found.");
                    return;
                }
                foreach (var item in entities)
                {
                    _unitOfWork.ProductPullOutLogLines.Value.RemoveRange(item.ProductPullOutLogLines);
                }
                _unitOfWork.ProductPullOutLogs.Value.RemoveRange(entities);
                _unitOfWork.Save();

                _view.ShowMessage($"{entities.Count} entries deleted successfully.");
                LoadAllProductPullOutLogList();
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"An error occurred while deleting: {ex.Message}");
            }
        }

        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "ProductPullOutLogsReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports", "Inventory");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("ProductPullOutLog", ProductPullOutLogList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        
        private async void LoadAllProductPullOutLogList(bool emptyValue = false)
        {
            ProductPullOutLogList = Program.Mapper.Map<IEnumerable<ProductPullOutLogViewModel>>(await _unitOfWork.ProductPullOutLogs.Value.GetAllAsync(includeProperties: "Project,ProductPullOutLogLines.Product.UnitOfMeasure"));

            if (!emptyValue) ProductPullOutLogList = ProductPullOutLogList.Where(c => c.ProductPullOutLogLines.ToLower().Contains(_view.SearchValue.ToLower()));
            _view.SetProductInStockLogListBindingSource(ProductPullOutLogList);
            
        }
    }
}
