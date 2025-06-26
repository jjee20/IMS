using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels.InventoryViewModels;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using RavenTech_ERP.Views.IViews.Inventory;
using RavenTech_ERP.Views.UserControls.Inventory;
using ServiceLayer.Services.IRepositories;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGrid.Events;
using System.Linq;
using static Unity.Storage.RegistrationSet;

namespace PresentationLayer.Presenters
{
    public class ProductTypePresenter
    {
        public IProductTypeView _view;
        private IUnitOfWork _unitOfWork;
        private IEnumerable<ProductTypeViewModel> ProductTypeList;
        public ProductTypePresenter(IProductTypeView view, IUnitOfWork unitOfWork) {

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

            _view.SearchEvent += Search;
            _view.AddEvent += AddNew;
            _view.EditEvent += Edit;
            _view.DeleteEvent += Delete;
            _view.MultipleDeleteEvent += MultipleDelete;
            _view.PrintEvent += Print;

            //Load

            LoadAllProductTypeList();

            //Source Binding
        }

        private void AddNew(object? sender, EventArgs e)
        {
            using (var form = new UpsertProductTypeView(_unitOfWork))
            {
                form.Text = "Add Product Type";
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadAllProductTypeList();
                }
            }
        }
        
        private void Search(object? sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(_view.SearchValue);
            LoadAllProductTypeList(emptyValue);
        }
        private void Edit(object? sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is ProductTypeViewModel row)
            {
                var entity = _unitOfWork.ProductType.Value.Get(c => c.ProductTypeId == row.ProductTypeId);
                using (var form = new UpsertProductTypeView(_unitOfWork,entity))
                {
                    form.Text = "Edit Product Type";
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadAllProductTypeList();
                    }
                }
            }
        }
        private void Delete(object? sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is ProductTypeViewModel row)
            {
                var entity = _unitOfWork.ProductType.Value.Get(c => c.ProductTypeId == row.ProductTypeId);
                if (entity != null)
                {
                    _unitOfWork.ProductType.Value.Remove(entity);
                    _unitOfWork.Save();

                    _view.ShowMessage("Product Type deleted successfully.");

                    LoadAllProductTypeList();
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

                var selected = _view.DataGrid.SelectedItems.Cast<ProductTypeViewModel>().ToList(); // If you're using view models
                var ids = selected.Select(b => b.ProductTypeId).ToList();

                var entities = _unitOfWork.ProductType.Value
                    .GetAll()
                    .Where(b => ids.Contains(b.ProductTypeId))
                    .ToList();

                if (!entities.Any())
                {
                    _view.ShowMessage("Selected records could not be found.");
                    return;
                }

                _unitOfWork.ProductType.Value.RemoveRange(entities);
                _unitOfWork.Save();

                _view.ShowMessage($"{entities.Count} entries deleted successfully.");
                LoadAllProductTypeList();
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"An error occurred while deleting: {ex.Message}");
            }
        }

        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "ProductTypeReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports", "Inventory");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("ProductType", ProductTypeList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }

        private async void LoadAllProductTypeList(bool emptyValue = false)
        {
            ProductTypeList = Program.Mapper.Map<IEnumerable<ProductTypeViewModel>>(await _unitOfWork.ProductType.Value.GetAllAsync());

            if (!emptyValue) ProductTypeList = ProductTypeList.Where(c => c.ProductTypeName.ToLower().Contains(_view.SearchValue.ToLower()));
            _view.SetProductTypeListBindingSource(ProductTypeList);
        }
    }
}
