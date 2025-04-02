using DomainLayer.Models.Accounts;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using ServiceLayer.Services.IRepositories;

namespace PresentationLayer.Presenters
{
    public class CustomerTypePresenter
    {
        public ICustomerTypeView _view;
        private IUnitOfWork _unitOfWork;
        private BindingSource CustomerTypeBindingSource;
        private IEnumerable<CustomerType> CustomerTypeList;
        public CustomerTypePresenter(ICustomerTypeView view, IUnitOfWork unitOfWork) {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            CustomerTypeBindingSource = new BindingSource();

            //Events
            _view.AddNewEvent += AddNew;
            _view.SaveEvent += Save;
            _view.SearchEvent += Search;
            _view.EditEvent += Edit;
            _view.DeleteEvent += Delete;
            _view.PrintEvent += Print;
            _view.RefreshEvent += Return;

            //Load

            LoadAllCustomerTypeList();

            //Source Binding
        }

        private void AddNew(object? sender, EventArgs e)
        {
            _view.IsEdit = false;
            CleanviewFields();
        }
        private void Save(object? sender, EventArgs e)
        {
            var model = _unitOfWork.CustomerType.Value.Get(c => c.CustomerTypeId == _view.CustomerTypeId, tracked: true);
            if (model == null) model = new CustomerType();
            else _unitOfWork.CustomerType.Value.Detach(model);

            model.CustomerTypeId = _view.CustomerTypeId;
            model.CustomerTypeName = _view.CustomerTypeName;
            model.Description = _view.Description;

            try
            {
                new ModelDataValidation().Validate(model);
                if (_view.IsEdit)//Edit model
                {
                    _unitOfWork.CustomerType.Value.Update(model);
                    _view.Message = "Customer type edited successfully";
                }
                else //Add new model
                {
                    _unitOfWork.CustomerType.Value.Add(model);
                    _view.Message = "Customer type added successfully";
                }
                _unitOfWork.Save();
                _view.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                _view.IsSuccessful = false;
                _view.Message = ex.Message;
            }
            finally
            {
                CleanviewFields() ;
            }
        }
        private void Search(object? sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(_view.SearchValue);
            LoadAllCustomerTypeList(emptyValue);
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

            var entity = (CustomerType)_view.DataGrid.SelectedItem;
            _view.CustomerTypeId = entity.CustomerTypeId;
            _view.CustomerTypeName = entity.CustomerTypeName;
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

                var entity = (CustomerType)_view.DataGrid.SelectedItem;
                _unitOfWork.CustomerType.Value.Remove(entity);
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                _view.Message = "Customer type deleted successfully";
                LoadAllCustomerTypeList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete customer type";
            }
        }
        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "CustomerTypeReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports", "Inventory");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("CustomerType", CustomerTypeList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        private void Return(object? sender, EventArgs e)
        {
            LoadAllCustomerTypeList();
        }
        private void CleanviewFields()
        {
            LoadAllCustomerTypeList();
            _view.CustomerTypeId = 0;
            _view.CustomerTypeName = "";
            _view.Description = "";
        }
        
        private void LoadAllCustomerTypeList(bool emptyValue = false)
        {
            CustomerTypeList = _unitOfWork.CustomerType.Value.GetAll();

            if (!emptyValue)
            {
                CustomerTypeList = CustomerTypeList.Where(c => c.CustomerTypeName.Contains(_view.SearchValue));
            }

            CustomerTypeBindingSource.DataSource = CustomerTypeList;//Set data source.
            _view.SetCustomerTypeListBindingSource(CustomerTypeBindingSource);
        }
    }
}
