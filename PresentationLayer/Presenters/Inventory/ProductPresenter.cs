using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels.Inventory;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using ServiceLayer.Services.IRepositories;

namespace PresentationLayer.Presenters
{
    public class ProductPresenter
    {
        public IProductView _view;
        private IUnitOfWork _unitOfWork;
        private BindingSource ProductTypeBindingSource;
        private BindingSource UnitOfMeasureBindingSource;
        private BindingSource BranchBindingSource;
        private BindingSource CurrencyBindingSource;
        private IEnumerable<ProductViewModel> ProductList;
        private IEnumerable<ProductType> ProductTypeList;
        private IEnumerable<UnitOfMeasure> UnitOfMeasureList;
        private IEnumerable<Branch> BranchList;
        public ProductPresenter(IProductView view, IUnitOfWork unitOfWork) {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            ProductTypeBindingSource = new BindingSource();
            UnitOfMeasureBindingSource = new BindingSource();
            BranchBindingSource = new BindingSource();
            CurrencyBindingSource = new BindingSource();

            //Events
            _view.AddNewEvent += AddNew;
            _view.SaveEvent += Save;
            _view.SearchEvent += Search;
            _view.EditEvent += Edit;
            _view.DeleteEvent += Delete;
            _view.PrintEvent += Print;
            _view.RefreshEvent += Return;

            //Load

            LoadAllProductList();
            LoadAllProductTypeList();
            LoadAllUnitOfMeasureList();
            LoadAllBranchList();

            //Source Binding
        }

        private void AddNew(object? sender, EventArgs e)
        {
            _view.IsEdit = false;
            CleanviewFields();
        }
        private void Save(object? sender, EventArgs e)
        {
            var model = _unitOfWork.Product.Value.Get(c => c.ProductId == _view.ProductId, tracked: true);
            if (model == null) model = new Product();
            else _unitOfWork.Product.Value.Detach(model);

            model.ProductId = _view.ProductId;
            model.ProductName = _view.ProductName ?? "";
            model.ProductCode = _view.ProductCode ?? "";
            model.Barcode = _view.Barcode ?? "";
            model.Description = _view.Description ?? "";
            model.ReorderLevel = _view.ReorderLevel;
            model.ProductTypeId = _view.ProductTypeId;
            model.UnitOfMeasureId = _view.UnitOfMeasureId;
            model.DefaultBuyingPrice = _view.DefaultBuyingPrice;
            model.DefaultSellingPrice = _view.DefaultSellingPrice;
            model.BranchId = _view.BranchId;
            model.Color = _view.PColor;
            model.Size = _view.PSize;
            model.Brand = _view.Brand;

            try
            {
                new ModelDataValidation().Validate(model);
                if (_view.IsEdit)//Edit model
                {
                    _unitOfWork.Product.Value.Update(model);
                    _view.Message = "Product edited successfully";
                }
                else //Add new model
                {
                    _unitOfWork.Product.Value.Add(model);
                    _view.Message = "Product added successfully";
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
            LoadAllProductList(emptyValue);
        }
        private void Edit(object? sender, EventArgs e)
        {
            _view.IsEdit = true;
            if (_view.DataGrid.SelectedItem == null)
            {
                _view.IsSuccessful = false;
                _view.Message = "Please select one to edit";
                return;
            }

            var product = (ProductViewModel)_view.DataGrid.SelectedItem;
            var entity = _unitOfWork.Product.Value.Get(c => c.ProductId == product.ProductId);
            _view.ProductId = entity.ProductId;
            _view.ProductName = entity.ProductName;
            _view.ProductCode = entity.ProductCode;
            _view.Barcode = entity.Barcode;
            _view.Description = entity.Description;
            _view.ReorderLevel = entity.ReorderLevel;
            _view.ProductTypeId = entity.ProductTypeId;
            _view.UnitOfMeasureId = entity.UnitOfMeasureId;
            _view.DefaultBuyingPrice = entity.DefaultBuyingPrice;
            _view.DefaultSellingPrice = entity.DefaultSellingPrice;
            _view.BranchId = entity.BranchId;
            _view.Brand = entity.Brand;
            _view.PSize = entity.Size;
            _view.PColor = entity.Color;
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

                var product = (ProductViewModel)_view.DataGrid.SelectedItem;
                var entity = _unitOfWork.Product.Value.Get(c => c.ProductId == product.ProductId);
                _unitOfWork.Product.Value.Remove(entity);
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                _view.Message = "Product deleted successfully";
                LoadAllProductList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete Product";
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
        private void Return(object? sender, EventArgs e)
        {
            LoadAllProductList();
        }
        private void CleanviewFields()
        {
            LoadAllProductList();
            _view.ProductId = 0;
            _view.ProductName = "";
            _view.ProductCode = "";
            _view.Barcode = "";
            _view.Description = "";
            _view.ReorderLevel = 0;
            _view.ProductTypeId = 0;
            _view.UnitOfMeasureId = 0;
            _view.DefaultBuyingPrice = 0;
            _view.DefaultSellingPrice = 0;
            _view.BranchId = 0;
        }
        
        private void LoadAllProductList(bool emptyValue = false)
        {
            ProductList = Program.Mapper.Map<IEnumerable<ProductViewModel>>(_unitOfWork.Product.Value.GetAll(includeProperties: "UnitOfMeasure,Branch"));

            if (!emptyValue) ProductList = ProductList.Where(c => c.ProductName.Contains(_view.SearchValue) || c.ProductCode.Contains(_view.SearchValue) || c.Barcode.Contains(_view.SearchValue));
            _view.SetProductListBindingSource(ProductList.OrderBy(c => c.ProductName));
        }
        private void LoadAllProductTypeList()
        {
            ProductTypeList = _unitOfWork.ProductType.Value.GetAll();
            ProductTypeBindingSource.DataSource = ProductTypeList;//Set data source.
            _view.SetProductTypeListBindingSource(ProductTypeBindingSource);
        }
        private void LoadAllUnitOfMeasureList()
        {
            UnitOfMeasureList = _unitOfWork.UnitOfMeasure.Value.GetAll();
            UnitOfMeasureBindingSource.DataSource = UnitOfMeasureList;//Set data source.
            _view.SetUnitOfMeasureListBindingSource(UnitOfMeasureBindingSource);
        }
        private void LoadAllBranchList()
        {
            BranchList = _unitOfWork.Branch.Value.GetAll();
            BranchBindingSource.DataSource = BranchList;//Set data source.
            _view.SetBranchListBindingSource(BranchBindingSource);
        }
    }
}
