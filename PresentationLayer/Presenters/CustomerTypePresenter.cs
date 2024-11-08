using DomainLayer.Models;
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

            //Source Binding
            _view.SetCustomerTypeListBindingSource(CustomerTypeBindingSource);

            //Load

            LoadAllCustomerTypeList();
        }

        private void AddNew(object? sender, EventArgs e)
        {
            _view.IsEdit = false;
            CleanviewFields();
        }
        private void Save(object? sender, EventArgs e)
        {
            var Entity = _unitOfWork.CustomerType.Get(c => c.CustomerTypeName == _view.CustomerTypeName);
            if (Entity != null)
            {
                _view.Message = "Customer type is already added.";
                return;
            }

            var model = new CustomerType()
            {
                
                CustomerTypeId = _view.CustomerTypeId,
                CustomerTypeName = _view.CustomerTypeName,
                Description = _view.Description,
            };

            try
            {
                new ModelDataValidation().Validate(model);
                if (_view.IsEdit)//Edit model
                {
                    _unitOfWork.CustomerType.Update(model);
                    _unitOfWork.Save();
                    _view.Message = "Customer type edited successfuly";
                }
                else //Add new model
                {
                    _unitOfWork.CustomerType.Add(model);
                    _unitOfWork.Save();
                    _view.Message = "Customer type added sucessfully";
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
                CustomerTypeList = _unitOfWork.CustomerType.GetAll(c => c.CustomerTypeName.Contains(_view.SearchValue));
                CustomerTypeBindingSource.DataSource = CustomerTypeList;
            }
            else
            {
                CustomerTypeList = _unitOfWork.CustomerType.GetAll();
                CustomerTypeBindingSource.DataSource = CustomerTypeList;
            }
        }
        private void Edit(object? sender, EventArgs e)
        {
            var entity = (CustomerType)CustomerTypeBindingSource.Current;
            _view.CustomerTypeId = entity.CustomerTypeId;
            _view.CustomerTypeName = entity.CustomerTypeName;
            _view.Description = entity.Description;
        }
        private void Delete(object? sender, EventArgs e)
        {
            try
            {
                var entity = (CustomerType)CustomerTypeBindingSource.Current;
                _unitOfWork.CustomerType.Remove(entity);
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
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports");
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
        
        private void LoadAllCustomerTypeList()
        {
            CustomerTypeList = _unitOfWork.CustomerType.GetAll();
            CustomerTypeBindingSource.DataSource = CustomerTypeList;//Set data source.
        }
    }
}
