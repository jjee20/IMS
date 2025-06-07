using DomainLayer.ViewModels;
using DomainLayer.ViewModels.Inventory;
using DomainLayer.ViewModels.InventoryViewModels;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using PresentationLayer.Views.UserControls;
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
    public class ProductPresenter
    {
        public IProductView _view;
        private IUnitOfWork _unitOfWork;
        private readonly IEventAggregator _eventAggregator;
        private IEnumerable<ProductViewModel> ProductList;
        public ProductPresenter(IProductView view, IUnitOfWork unitOfWork, ServiceLayer.Services.CommonServices.IEventAggregator eventAggregator) {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            this._eventAggregator = eventAggregator;

            //Events
            _view.SearchEvent -= Search;
            _view.AddEvent -= AddNew;
            _view.EditEvent -= Edit;
            _view.DeleteEvent -= Delete;
            _view.MultipleDeleteEvent -= MultipleDelete;
            _view.PrintEvent -= Print;

            _view.SearchEvent += Search;
            _view.AddEvent += AddNew;
            _view.EditEvent += Edit;
            _view.DeleteEvent += Delete;
            _view.MultipleDeleteEvent += MultipleDelete;
            _view.PrintEvent += Print;

            //Load

            LoadAllProductList();

            //Source Binding
        }

        private void AddNew(object? sender, EventArgs e)
        {
            using (var form = new UpsertProductView(_unitOfWork))
            {
                form.Text = "Add Product";
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadAllProductList();
                }
            }
        }
        
        private void Search(object? sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(_view.SearchValue);
            LoadAllProductList(emptyValue);
        }
        private void Edit(object? sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is ProductViewModel row)
            {
                var entity = _unitOfWork.Product.Value.Get(c => c.ProductId == row.ProductId);
                using (var form = new UpsertProductView(_unitOfWork,entity))
                {
                    form.Text = "Edit Product";
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadAllProductList();
                    }
                }
            }
        }
        private void Delete(object? sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is ProductViewModel row)
            {
                var entity = _unitOfWork.Product.Value.Get(c => c.ProductId == row.ProductId);
                if (entity != null)
                {
                    _unitOfWork.Product.Value.Remove(entity);
                    _unitOfWork.Save();

                    _view.ShowMessage("Product deleted successfully.");

                    LoadAllProductList();
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

                var selected = _view.DataGrid.SelectedItems.Cast<ProductViewModel>().ToList(); // If you're using view models
                var ids = selected.Select(b => b.ProductId).ToList();

                var entities = _unitOfWork.Product.Value
                    .GetAll()
                    .Where(b => ids.Contains(b.ProductId))
                    .ToList();

                if (!entities.Any())
                {
                    _view.ShowMessage("Selected records could not be found.");
                    return;
                }

                _unitOfWork.Product.Value.RemoveRange(entities);
                _unitOfWork.Save();

                _view.ShowMessage($"{entities.Count} entries deleted successfully.");
                LoadAllProductList();
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"An error occurred while deleting: {ex.Message}");
            }
        }

        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "ProductReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports", "Inventory");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("Product", ProductList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        
        private void LoadAllProductList(bool emptyValue = false)
        {
            ProductList = Program.Mapper.Map<IEnumerable<ProductViewModel>>(_unitOfWork.Product.Value.GetAll());

            if (!emptyValue) ProductList = ProductList.Where(c => c.ProductName.ToLower().Contains(_view.SearchValue.ToLower()));
            _view.SetProductListBindingSource(ProductList);
            _eventAggregator.Publish<InventoryCompletedEvent>();
        }
    }
}
