using DomainLayer.Enums;
using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels;
using DomainLayer.ViewModels.Inventory;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using RavenTech_ERP.Views.IViews.Inventory;
using ServiceLayer.Services.CommonServices;
using ServiceLayer.Services.IRepositories;

namespace PresentationLayer.Presenters
{
    public class ProductStockInLogPresenter
    {
        public IProductStockInLogView _view;
        private IUnitOfWork _unitOfWork;
        private BindingSource StatusBindingSource;
        private BindingSource ProductBindingSource;
        private IEnumerable<ProductStockInLogViewModel> ProductStockInLogList;
        private IEnumerable<EnumItemViewModel> StatusList;
        private IEnumerable<Product> ProductList;
        public ProductStockInLogPresenter(IProductStockInLogView view, IUnitOfWork unitOfWork) {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            StatusBindingSource = new BindingSource();
            ProductBindingSource = new BindingSource();

            //Events
            _view.AddNewEvent += AddNew;
            _view.SaveEvent += Save;
            _view.SearchEvent += Search;
            _view.EditEvent += Edit;
            _view.DeleteEvent += Delete;
            _view.PrintEvent += Print;
            _view.RefreshEvent += Return;

            //Load

            LoadAllProduct();
            LoadAllStatus();
            LoadAllProductStockInLogList();

            //Source Binding
        }

        private void AddNew(object? sender, EventArgs e)
        {
            _view.IsEdit = false;
            CleanviewFields();
        }
        private void Save(object? sender, EventArgs e)
        {
            var model = _unitOfWork.StockInLogs.Value.Get(c => c.ProductStockInLogId == _view.ProductStockInLogId, tracked: true);
            if (model == null) model = new ProductStockInLog();
            else _unitOfWork.StockInLogs.Value.Detach(model);

            model.ProductStockInLogId = _view.ProductStockInLogId;
            model.ProductId = _view.ProductId;
            model.ProductStatus = _view.ProductStatus;
            model.DateAdded = _view.DateAdded;
            model.Notes = _view.Notes;
            model.StockQuantity = _view.StockQuantity;

            try
            {
                new ModelDataValidation().Validate(model);
                if (_view.IsEdit)//Edit model
                {
                    _unitOfWork.StockInLogs.Value.Update(model);
                    _view.Message = "Product log edited successfully";
                }
                else //Add new model
                {
                    _unitOfWork.StockInLogs.Value.Add(model);
                    _view.Message = "Product log added successfully";
                }
                    _unitOfWork.Save();
                _view.IsSuccessful = true;
                CleanviewFields();
            }
            catch (Exception ex)
            {
                _view.IsSuccessful = false;
                _view.Message = ex.Message;
            }
        }
        private void Search(object? sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(_view.SearchValue);
            LoadAllProductStockInLogList(emptyValue);
        }
        private void Edit(object? sender, EventArgs e)
        {
            _view.IsEdit = true;
            if(_view.DataGrid.SelectedItem == null)
            {
                _view.IsSuccessful = false;
                _view.Message = "Please select one to edit";
                return;
            }
            var productlog = (ProductStockInLogViewModel)_view.DataGrid.SelectedItem;
            var entity = _unitOfWork.StockInLogs.Value.Get(c => c.ProductStockInLogId == productlog.ProductStockInLogId);
            _view.ProductStockInLogId = entity.ProductStockInLogId;
            _view.ProductId = entity.ProductId;
            _view.StockQuantity = entity.StockQuantity;
            _view.DateAdded = entity.DateAdded;
            _view.Notes = entity.Notes;
            _view.ProductStatus = entity.ProductStatus;
        }
        private void Delete(object? sender, EventArgs e)
        {
            try
            {
                if (_view.DataGrid.SelectedItem == null)
                {
                    _view.IsSuccessful = false;
                    _view.Message = "Please select one to delete";
                    return;
                }

                var productlog = (ProductStockInLogViewModel)_view.DataGrid.SelectedItem;
                var entity = _unitOfWork.StockInLogs.Value.Get(c => c.ProductStockInLogId == productlog.ProductStockInLogId);
                _unitOfWork.StockInLogs.Value.Remove(entity);
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                _view.Message = "Product log deleted successfully";
                LoadAllProductStockInLogList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete Product log";
            }
        }
        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "StockInLogReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports", "Inventory");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("StockInLogs", ProductStockInLogList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        private void Return(object? sender, EventArgs e)
        {
            LoadAllProductStockInLogList();
        }
        private void CleanviewFields()
        {
            LoadAllProductStockInLogList();
            _view.ProductStockInLogId = 0;
            _view.StockQuantity = 1;
            _view.Notes = "";
        }
        
        private void LoadAllProductStockInLogList(bool emptyValue = false)
        {
            ProductStockInLogList = Program.Mapper.Map<IEnumerable<ProductStockInLogViewModel>>(_unitOfWork.StockInLogs.Value.GetAll(includeProperties: "Product"));

            if (!emptyValue) ProductStockInLogList = ProductStockInLogList.Where(c => c.Product.ToLower().Contains(_view.SearchValue.ToLower()));
            _view.SetProductStockInLogListBindingSource(ProductStockInLogList);
        }
        private void LoadAllStatus()
        {
            StatusList = EnumHelper.EnumToEnumerable<ProductStatus>();
            StatusBindingSource.DataSource = StatusList;//Set data source.
            _view.SetProductStatusListBindingSource(StatusBindingSource);
        }
        private void LoadAllProduct()
        {
            ProductList = _unitOfWork.Product.Value.GetAll();
            ProductBindingSource.DataSource = ProductList;//Set data source.
            _view.SetProductListBindingSource(ProductBindingSource);
        }
    }
}
