using DomainLayer.Models.Inventory;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using ServiceLayer.Services.IRepositories;

namespace PresentationLayer.Presenters
{
    public class ProductTypePresenter
    {
        public IProductTypeView _view;
        private IUnitOfWork _unitOfWork;
        private BindingSource ProductTypeBindingSource;
        private IEnumerable<ProductType> ProductTypeList;
        public ProductTypePresenter(IProductTypeView view, IUnitOfWork unitOfWork) {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            ProductTypeBindingSource = new BindingSource();

            //Events
            _view.AddNewEvent += AddNew;
            _view.SaveEvent += Save;
            _view.SearchEvent += Search;
            _view.EditEvent += Edit;
            _view.DeleteEvent += Delete;
            _view.PrintEvent += Print;
            _view.RefreshEvent += Return;
            //Load

            LoadAllProductTypeList();

            //Source Binding
            _view.SetProductTypeListBindingSource(ProductTypeBindingSource);

        }

        private void AddNew(object? sender, EventArgs e)
        {
            _view.IsEdit = false;
            CleanviewFields();
        }
        private void Save(object? sender, EventArgs e)
        {
            var Entity = _unitOfWork.ProductType.Get(c => c.ProductTypeName == _view.ProductTypeName);
            if (Entity != null)
            {
                _view.Message = "Product type is already added.";
                return;
            }

            var model = new ProductType()
            {
                
                ProductTypeId = _view.ProductTypeId,
                ProductTypeName = _view.ProductTypeName,
                Description = _view.Description,
            };

            try
            {
                new ModelDataValidation().Validate(model);
                if (_view.IsEdit)//Edit model
                {
                    _unitOfWork.ProductType.Update(model);
                    _view.Message = "Product type edited successfully";
                }
                else //Add new model
                {
                    _unitOfWork.ProductType.Add(model);
                    _view.Message = "Product type added successfully";
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
        private async  void Search(object? sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(_view.SearchValue);
            if (emptyValue == false)
            {
                ProductTypeList = _unitOfWork.ProductType.GetAll(c => c.ProductTypeName.Contains(_view.SearchValue));
                ProductTypeBindingSource.DataSource = ProductTypeList;
            }
            else
            {
                LoadAllProductTypeList();
            }
        }
        private void Edit(object? sender, EventArgs e)
        {
            _view.IsEdit = true;
            var entity = (ProductType)ProductTypeBindingSource.Current;
            _view.ProductTypeId = entity.ProductTypeId;
            _view.ProductTypeName = entity.ProductTypeName;
            _view.Description = entity.Description;
        }
        private void Delete(object? sender, EventArgs e)
        {
            try
            {
                var entity = (ProductType)ProductTypeBindingSource.Current;
                _unitOfWork.ProductType.Remove(entity);
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                _view.Message = "Product type deleted successfully";
                LoadAllProductTypeList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete Product type";
            }
        }
        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "ProductTypeReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("ProductType", ProductTypeList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        private void Return(object? sender, EventArgs e)
        {
            LoadAllProductTypeList();
        }
        private void CleanviewFields()
        {
            LoadAllProductTypeList();
            _view.ProductTypeId = 0;
            _view.ProductTypeName = "";
            _view.Description = "";
        }
        
        private void LoadAllProductTypeList()
        {
            ProductTypeList = _unitOfWork.ProductType.GetAll();
            ProductTypeBindingSource.DataSource = ProductTypeList;//Set data source.
        }
    }
}
