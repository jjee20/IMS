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

        }

        private void AddNew(object? sender, EventArgs e)
        {
            _view.IsEdit = false;
            CleanviewFields();
        }
        private void Save(object? sender, EventArgs e)
        {
            var model = _unitOfWork.ProductType.Value.Get(c => c.ProductTypeId == _view.ProductTypeId, tracked: true);
            if (model == null) model = new ProductType();
            else _unitOfWork.ProductType.Value.Detach(model);

            model.ProductTypeId = _view.ProductTypeId;
            model.ProductTypeName = _view.ProductTypeName;
            model.Description = _view.Description;

            try
            {
                new ModelDataValidation().Validate(model);
                if (_view.IsEdit)//Edit model
                {
                    _unitOfWork.ProductType.Value.Update(model);
                    _view.Message = "Product type edited successfully";
                }
                else //Add new model
                {
                    _unitOfWork.ProductType.Value.Add(model);
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
            LoadAllProductTypeList(emptyValue);
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

            var entity = (ProductType)_view.DataGrid.SelectedItem;
            _view.ProductTypeId = entity.ProductTypeId;
            _view.ProductTypeName = entity.ProductTypeName;
            _view.Description = entity.Description;
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

                var entity = (ProductType)_view.DataGrid.SelectedItem;
                _unitOfWork.ProductType.Value.Remove(entity);
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
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports", "Inventory");
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
        
        private void LoadAllProductTypeList(bool emptyValue = false)
        {
            ProductTypeList = _unitOfWork.ProductType.Value.GetAll();

            if (emptyValue)
            {
                ProductTypeList = ProductTypeList.Where(c => c.ProductTypeName.Contains(_view.SearchValue));
            }

            ProductTypeBindingSource.DataSource = ProductTypeList;//Set data source.
            _view.SetProductTypeListBindingSource(ProductTypeBindingSource);
        }
    }
}
