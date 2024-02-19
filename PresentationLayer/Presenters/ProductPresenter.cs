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
        private IEnumerable<Product> ProductList;
        public ProductPresenter(IProductView view, IUnitOfWork unitOfWork) {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            ProductBindingSource = new BindingSource();

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

            //Load

            LoadAllProductList();
        }

        private void AddNew(object? sender, EventArgs e)
        {
            _view.IsEdit = false;
            CleanviewFields();
        }
        private void Save(object? sender, EventArgs e)
        {
            try
            {
                // Check if the Product already exists by name
                var existingEntity = _unitOfWork.Product.Get(c => c.ProductName == _view.ProductName);

                if (existingEntity != null)
                {
                    // If editing and entity with the same name already exists, handle appropriately
                    if (_view.IsEdit)
                    {
                        if (existingEntity.ProductId != _view.ProductId)
                        {
                            _view.Message = "Another Customer type with the same name already exists.";
                            return;
                        }
                    }
                    else
                    {
                        // If adding new and entity with the same name already exists, notify and return
                        _view.Message = "Customer type with the same name already exists.";
                        return;
                    }
                }

                // Create or update the Product entity
                Product entity;
                if (_view.ProductId == 0)
                {
                    entity = new Product()
                    {
                        ProductName = _view.ProductName,
                        Description = _view.Description
                    };
                    _unitOfWork.Product.Add(entity);
                }
                else
                {
                    // Retrieve the existing entity if editing
                    entity = _unitOfWork.Product.Get(c => c.ProductId == _view.ProductId);
                    if (entity == null)
                    {
                        // Handle scenario where entity with the provided ID is not found
                        _view.Message = "Customer type not found for editing.";
                        return;
                    }

                    // Update the existing entity
                    entity.ProductName = _view.ProductName;
                    entity.Description = _view.Description;
                    _unitOfWork.Product.Update(entity);
                }

                // Validate the entity
                new ModelDataValidation().Validate(entity);

                // Save changes
                _unitOfWork.Save();

                // Set success message
                _view.Message = _view.IsEdit ? "Customer type edited successfully" : "Customer type added successfully";
                _view.IsSuccessful = true;

                // Clear view fields
                CleanviewFields();
            }
            catch (Exception ex)
            {
                // Handle exceptions
                _view.IsSuccessful = false;
                _view.Message = ex.Message;
            }
        }

        //private void Save(object? sender, EventArgs e)
        //{
        //   var Entity = _unitOfWork.Product.Get(c => c.ProductName == _view.ProductName);
        //   if (Entity != null && _view.ProductId == 0)
        //        {
        //            _view.Message = "Customer type is already added.";
        //            return;
        //        }
        //        if(_view.ProductId == 0)
        //        {

        //        Entity = new Product()
        //        {
        //            ProductId = _view.ProductId,
        //            ProductName = _view.ProductName,
        //            Description = _view.Description,
        //        };
        //    }
        //    else
        //    {
        //        Entity.ProductName = _view.ProductName;
        //        Entity.Description = _view.Description;
        //    }

        //        try
        //        {
        //        new ModelDataValidation().Validate(Entity);
        //            if (_view.IsEdit)//Edit model
        //            {
        //                _unitOfWork.Product.Update(Entity);
        //                _unitOfWork.Save();
        //                _view.Message = "Customer type edited successfuly";
        //            }
        //            else //Add new model
        //            {
        //                _unitOfWork.Product.Add(Entity);
        //                _unitOfWork.Save();
        //                _view.Message = "Customer type added sucessfully";
        //            }
        //            _view.IsSuccessful = true;
        //            CleanviewFields();
        //        }
        //        catch (Exception ex)
        //        {
        //            _view.IsSuccessful = false;
        //            _view.Message = ex.Message;
        //        }
        //}
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
            _view.IsEdit = true;
            var entity = (Product)ProductBindingSource.Current;
            _view.ProductId = entity.ProductId;
            _view.ProductName = entity.ProductName;
            _view.Description = entity.Description;
        }
        private void Delete(object? sender, EventArgs e)
        {
            try
            {
                var entity = (Product)ProductBindingSource.Current;
                _unitOfWork.Product.Remove(entity);
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                _view.Message = "Customer type deleted successfully";
                LoadAllProductList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete customer type";
            }
        }
        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "ProductListReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("ProductList", ProductList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport, null);
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
            _view.Description = "";
        }
        
        private void LoadAllProductList()
        {
            ProductList = _unitOfWork.Product.GetAll();
            ProductBindingSource.DataSource = ProductList;//Set data source.
        }
    }
}
