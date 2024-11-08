using DomainLayer.Models;
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
        private BindingSource ProductBindingSource;
        private BindingSource ProductTypeBindingSource;
        private BindingSource UnitOfMeasureBindingSource;
        private BindingSource BranchBindingSource;
        private BindingSource CurrencyBindingSource;
        private IEnumerable<Product> ProductList;
        private IEnumerable<ProductType> ProductTypeList;
        private IEnumerable<UnitOfMeasure> UnitOfMeasureList;
        private IEnumerable<Branch> BranchList;
        private IEnumerable<Currency> CurrencyList;
        public ProductPresenter(IProductView view, IUnitOfWork unitOfWork) {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            ProductBindingSource = new BindingSource();
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

            //Source Binding
            _view.SetProductListBindingSource(ProductBindingSource);
            _view.SetProductTypeListBindingSource(ProductTypeBindingSource);
            _view.SetUnitOfMeasureListBindingSource(UnitOfMeasureBindingSource);
            _view.SetBranchListBindingSource(BranchBindingSource);
            _view.SetCurrencyListBindingSource(CurrencyBindingSource);

            //Load

            LoadAllProductList();
            LoadAllProductTypeList();
            LoadAllUnitOfMeasureList();
            LoadAllBranchList();
            LoadAllCurrencyList();
        }

        private void AddNew(object? sender, EventArgs e)
        {
            _view.IsEdit = false;
            CleanviewFields();
        }
        private void Save(object? sender, EventArgs e)
        {
            var Entity = _unitOfWork.Product.Get(c => c.ProductName == _view.ProductName);
            if (Entity != null)
            {
                _view.Message = "Product type is already added.";
                return;
            }

            var model = new Product()
            {
                
                ProductId = _view.ProductId,
                ProductName = _view.ProductName,
                ProductCode = _view.ProductCode,
                Barcode = _view.Barcode,
                Description = _view.Description,
                ProductImageUrl = _view.ProductImageUrl,
                UnitOfMeasureId = _view.UnitOfMeasureId,
                DefaultBuyingPrice = _view.DefaultBuyingPrice,
                DefaultSellingPrice = _view.DefaultSellingPrice,
                BranchId = _view.BranchId,
                CurrencyId = _view.CurrencyId,
            };

            try
            {
                new ModelDataValidation().Validate(model);
                if (_view.IsEdit)//Edit model
                {
                    _unitOfWork.Product.Update(model);
                    _unitOfWork.Save();
                    _view.Message = "Product type edited successfuly";
                }
                else //Add new model
                {
                    _unitOfWork.Product.Add(model);
                    _unitOfWork.Save();
                    _view.Message = "Product type added sucessfully";
                }
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
            if (emptyValue == false)
            {
                ProductList = _unitOfWork.Product.GetAll(c => c.ProductName.Contains(_view.SearchValue));
                ProductBindingSource.DataSource = ProductList;
            }
            else
            {
                ProductList = _unitOfWork.Product.GetAll();
                ProductBindingSource.DataSource = ProductList;
            }
        }
        private void Edit(object? sender, EventArgs e)
        {
            var entity = (Product)ProductBindingSource.Current;
            _view.ProductId = entity.ProductId;
            _view.ProductName = entity.ProductName;
            _view.ProductCode = entity.ProductCode;
            _view.Barcode = entity.Barcode;
            _view.Description = entity.Description;
            _view.ProductImageUrl = entity.ProductImageUrl;
            _view.UnitOfMeasureId = entity.UnitOfMeasureId;
            _view.DefaultBuyingPrice = entity.DefaultBuyingPrice;
            _view.DefaultSellingPrice = entity.DefaultSellingPrice;
            _view.BranchId = entity.BranchId;
            _view.CurrencyId = entity.CurrencyId;
        }
        private void Delete(object? sender, EventArgs e)
        {
            try
            {
                var entity = (Product)ProductBindingSource.Current;
                _unitOfWork.Product.Remove(entity);
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                _view.Message = "Product type deleted successfully";
                LoadAllProductList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete Product type";
            }
        }
        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "ProductReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports");
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
            _view.ProductImageUrl = "";
            _view.UnitOfMeasureId = 0;
            _view.DefaultBuyingPrice = 0;
            _view.DefaultSellingPrice = 0;
            _view.BranchId = 0;
            _view.CurrencyId = 0;
        }
        
        private void LoadAllProductList()
        {
            ProductList = _unitOfWork.Product.GetAll();
            ProductBindingSource.DataSource = ProductList;//Set data source.
        }
        private void LoadAllProductTypeList()
        {
            ProductTypeList = _unitOfWork.ProductType.GetAll();
            ProductTypeBindingSource.DataSource = ProductTypeList;//Set data source.
        }
        private void LoadAllUnitOfMeasureList()
        {
            UnitOfMeasureList = _unitOfWork.UnitOfMeasure.GetAll();
            UnitOfMeasureBindingSource.DataSource = UnitOfMeasureList;//Set data source.
        }
        private void LoadAllBranchList()
        {
            BranchList = _unitOfWork.Branch.GetAll();
            BranchBindingSource.DataSource = BranchList;//Set data source.
        }
        private void LoadAllCurrencyList()
        {
            CurrencyList = _unitOfWork.Currency.GetAll();
            CurrencyBindingSource.DataSource = CurrencyList;//Set data source.
        }
    }
}
