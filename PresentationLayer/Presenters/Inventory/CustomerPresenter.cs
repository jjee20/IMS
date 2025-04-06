using AutoMapper;
using DomainLayer.Models.Accounts;
using DomainLayer.ViewModels.Inventory;
using Microsoft.Reporting.Map.WebForms.BingMaps;
using Microsoft.Reporting.WinForms;
using Newtonsoft.Json;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using ServiceLayer.Services.IRepositories;
using static PresentationLayer.Json.Address;

namespace PresentationLayer.Presenters
{
    public class CustomerPresenter
    {
        public ICustomerView _view;
        private IUnitOfWork _unitOfWork;
        private BindingSource CustomerTypeBindingSource;

        private IEnumerable<CustomerViewModel> CustomerList;
        private IEnumerable<CustomerType> CustomerTypeList;
        public CustomerPresenter(ICustomerView view, IUnitOfWork unitOfWork)
        {

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

            LoadAllCustomerList();
            LoadAllCustomerTypeList();
            //LoadAddress();

            //Source Binding
            //_view.SetAddressBindingSource(GetBarangayList, GetMunicipalityList,
            //                              GetProvinceList, GetRegionList);
        }

        //private void LoadAddress()
        //{
        //    string reportPath = Path.Combine(reportDirectory, reportFileName);
        //    string addressData = File.ReadAllText(reportPath);
        //    var regions = JsonConvert.DeserializeObject<Root>(addressData);
        //    foreach (var region in regions.Items)
        //    {
        //        GetRegionList.Add(region.Value.ToString());
        //        foreach (var province in region.Value.province.province_list)
        //        {
        //            GetProvinceList.Add(province.Value.ToString());
        //            foreach (var municipality in province.Value.municipality_list)
        //            {
        //                GetMunicipalityList.Add(municipality.Value.ToString());
        //                foreach (var barangay in municipality.Value.barangay_list)
        //                {
        //                    GetBarangayList.Add(barangay);
        //                }
        //            }
        //        }
        //    }
        //}

        private void AddNew(object? sender, EventArgs e)
        {
            _view.IsEdit = false;
            CleanviewFields();
        }
        private async void Save(object? sender, EventArgs e)
        {
            var model = await _unitOfWork.Customer.Value.GetAsync(c => c.CustomerId == _view.CustomerId, tracked: true);
            if (model == null) model = new Customer();
            else _unitOfWork.Customer.Value.Detach(model);

            model.CustomerId = _view.CustomerId;
            model.CustomerName = _view.CustomerName;
            model.CustomerTypeId = _view.CustomerTypeId;
            model.Address = _view.Address;
            model.Phone = _view.Phone;
            model.Email = _view.Email;
            model.ContactPerson = _view.ContactPerson;

            try
            {
                new ModelDataValidation().Validate(model);
                if (_view.IsEdit)//Edit model
                {
                    _unitOfWork.Customer.Value.Update(model);
                    _view.Message = "Customer edited successfully";
                }
                else //Add new model
                {
                    await _unitOfWork.Customer.Value.AddAsync(model);
                    _view.Message = "Customer added successfully";
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
            LoadAllCustomerList(emptyValue);
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

            var customer = (CustomerViewModel)_view.DataGrid.SelectedItem;
            var entity = _unitOfWork.Customer.Value.Get(c => c.CustomerId == customer.CustomerId);
            _view.CustomerId = entity.CustomerId;
            _view.CustomerName = entity.CustomerName;
            _view.CustomerTypeId = entity.CustomerTypeId;
            _view.Address = entity.Address;
            _view.Phone = entity.Phone;
            _view.Email = entity.Email;
            _view.ContactPerson = entity.ContactPerson;
        }
        private void Delete(object? sender, EventArgs e)
        {
            try
            {
                if (_view.DataGrid.SelectedItems == null || _view.DataGrid.SelectedItems.Count == 0)
                {
                    _view.IsSuccessful = false;
                    _view.Message = "Please select customer(s) to delete.";
                    _view.ShowMessage(_view.Message);
                    _view.ShowMessage(_view.Message);
                    return;
                }

                var selectedCustomers = _view.DataGrid.SelectedItems.Cast<CustomerViewModel>().ToList();
                var ids = selectedCustomers.Select(c => c.CustomerId).ToList();

                var entities = _unitOfWork.Customer.Value
                    .GetAll()
                    .Where(c => ids.Contains(c.CustomerId))
                    .ToList();

                if (!entities.Any())
                {
                    _view.IsSuccessful = false;
                    _view.Message = "Selected customers could not be found.";
                    _view.ShowMessage(_view.Message);
                    _view.ShowMessage(_view.Message);
                    return;
                }

                _unitOfWork.Customer.Value.RemoveRange(entities);
                _unitOfWork.Save();

                _view.IsSuccessful = true;
                _view.Message = $"{entities.Count} customer(s) deleted successfully.";
                _view.ShowMessage(_view.Message);
                LoadAllCustomerList();
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
            string reportFileName = "CustomerReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports", "Inventory");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("Customer", CustomerList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        private void Return(object? sender, EventArgs e)
        {
            LoadAllCustomerList();
        }
        private void CleanviewFields()
        {
            LoadAllCustomerList();
            LoadAllCustomerTypeList();
            _view.CustomerId = 0;
            _view.CustomerName = "";
            _view.CustomerTypeId = 0;
            _view.Address = "";
            _view.Phone = "";
            _view.Email = "";
            _view.ContactPerson = "";
        }
        
        private void LoadAllCustomerList(bool emptyValue = false)
        {
            CustomerList = Program.Mapper.Map<IEnumerable<CustomerViewModel>>(_unitOfWork.Customer.Value.GetAll(includeProperties: "CustomerType"));

            if (!emptyValue) CustomerList = CustomerList.Where(c => c.CustomerName.Contains(_view.SearchValue));
            _view.SetCustomerListBindingSource(CustomerList.OrderBy(c => c.CustomerName));
        }
        private void LoadAllCustomerTypeList()
        {
            CustomerTypeList = _unitOfWork.CustomerType.Value.GetAll();
            CustomerTypeBindingSource.DataSource = CustomerTypeList;//Set data source.
            _view.SetCustomerTypeListBindingSource(CustomerTypeBindingSource);
        }

    }
}
