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
        private IEnumerable<CustomerType> CustomerTypeList;
        public CustomerTypePresenter(ICustomerTypeView view, IUnitOfWork unitOfWork) {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;

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
        private async void Save(object? sender, EventArgs e)
        {
            var model = await _unitOfWork.CustomerType.Value.GetAsync(c => c.CustomerTypeId == _view.CustomerTypeId, tracked: true);
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
                    await _unitOfWork.CustomerType.Value.AddAsync(model);
                    _view.Message = "Customer type added successfully";
                }
                await _unitOfWork.SaveAsync();
                _view.IsSuccessful = true;
                _view.ShowMessage(_view.Message);
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
                if (_view.DataGrid.SelectedItems == null || _view.DataGrid.SelectedItems.Count == 0)
                {
                    _view.IsSuccessful = false;
                    _view.Message = "Please select customer type(s) to delete.";
                    _view.ShowMessage(_view.Message);
                    return;
                }

                var selectedItems = _view.DataGrid.SelectedItems.Cast<CustomerType>().ToList();

                if (!selectedItems.Any())
                {
                    _view.IsSuccessful = false;
                    _view.Message = "No valid customer types selected.";
                    _view.ShowMessage(_view.Message);
                    return;
                }

                _unitOfWork.CustomerType.Value.RemoveRange(selectedItems);
                _unitOfWork.Save();

                _view.IsSuccessful = true;
                _view.Message = $"{selectedItems.Count} customer type(s) deleted successfully.";
                _view.ShowMessage(_view.Message);
                LoadAllCustomerTypeList();
            }
            catch (Exception ex)
            {
                _view.IsSuccessful = false;
                _view.Message = $"An error occurred while deleting: {ex.Message}";
                _view.ShowMessage(_view.Message);
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

            if (!emptyValue) CustomerTypeList = CustomerTypeList.Where(c => c.CustomerTypeName.Contains(_view.SearchValue));
            _view.SetCustomerTypeListBindingSource(CustomerTypeList);
        }
    }
}
