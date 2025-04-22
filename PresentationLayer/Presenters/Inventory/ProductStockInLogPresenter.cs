using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels;
using DomainLayer.ViewModels.InventoryViewModels;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using PresentationLayer.Views.UserControls;
using RavenTech_ERP.Views.IViews.Inventory;
using RavenTech_ERP.Views.UserControls.Inventory;
using ServiceLayer.Services.IRepositories;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGrid.Events;
using System.Linq;
using static Unity.Storage.RegistrationSet;

namespace PresentationLayer.Presenters
{
    public class ProductStockInLogPresenter
    {
        public IProductStockInLogView _view;
        private IUnitOfWork _unitOfWork;
        private IEnumerable<ProductStockInLogViewModel> ProductStockInLogList;
        public ProductStockInLogPresenter(IProductStockInLogView view, IUnitOfWork unitOfWork) {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;

            //Events
            _view.SearchEvent += Search;
            _view.AddEvent += AddNew;
            _view.EditEvent += Edit;
            _view.DeleteEvent += Delete;
            _view.MultipleDeleteEvent += MultipleDelete;
            _view.PrintEvent += Print;

            //Load

            LoadAllProductStockInLogList();

            //Source Binding
        }

        private void AddNew(object? sender, EventArgs e)
        {
            using (var form = new UpsertProductStockInLogView(_unitOfWork))
            {
                form.Text = "Add Product Stock-In Log";
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadAllProductStockInLogList();
                }
            }
        }
        
        private void Search(object? sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(_view.SearchValue);
            LoadAllProductStockInLogList(emptyValue);
        }
        private void Edit(object? sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is ProductStockInLogViewModel row)
            {
                var entity = _unitOfWork.StockInLogs.Value.Get(c => c.ProductStockInLogId == row.ProductStockInLogId);
                using (var form = new UpsertProductStockInLogView(_unitOfWork,entity))
                {
                    form.Text = "Edit Product Stock-In Log";
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadAllProductStockInLogList();
                    }
                }
            }
        }
        private void Delete(object? sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is ProductStockInLogViewModel row)
            {
                var entity = _unitOfWork.StockInLogs.Value.Get(c => c.ProductStockInLogId == row.ProductStockInLogId);
                if (entity != null)
                {
                    _unitOfWork.StockInLogs.Value.Remove(entity);
                    _unitOfWork.Save();

                    _view.ShowMessage("ProductStockInLog deleted successfully.");

                    LoadAllProductStockInLogList();
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

                var selected = _view.DataGrid.SelectedItems.Cast<ProductStockInLogViewModel>().ToList(); // If you're using view models
                var ids = selected.Select(b => b.ProductStockInLogId).ToList();

                var entities = _unitOfWork.StockInLogs.Value
                    .GetAll()
                    .Where(b => ids.Contains(b.ProductStockInLogId))
                    .ToList();

                if (!entities.Any())
                {
                    _view.ShowMessage("Selected records could not be found.");
                    return;
                }

                _unitOfWork.StockInLogs.Value.RemoveRange(entities);
                _unitOfWork.Save();

                _view.ShowMessage($"{entities.Count} entries deleted successfully.");
                LoadAllProductStockInLogList();
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"An error occurred while deleting: {ex.Message}");
            }
        }

        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "ProductStockInLogReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports", "Inventory");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("ProductStockInLog", ProductStockInLogList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        
        private void LoadAllProductStockInLogList(bool emptyValue = false)
        {
            ProductStockInLogList = Program.Mapper.Map<IEnumerable<ProductStockInLogViewModel>>(_unitOfWork.StockInLogs.Value.GetAll());

            if (!emptyValue) ProductStockInLogList = ProductStockInLogList.Where(c => c.Product.ToLower().Contains(_view.SearchValue.ToLower()));
            _view.SetProductInStockLogListBindingSource(ProductStockInLogList);
        }
    }
}
