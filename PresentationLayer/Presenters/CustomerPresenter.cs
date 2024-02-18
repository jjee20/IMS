using DomainLayer.Models;
using DomainLayer.Models.ViewModels;
using Microsoft.Reporting.WinForms;
using Newtonsoft.Json;
using PresentationLayer.Json.JsonClass;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using ServiceLayer.Services.IRepositories;
using System.Drawing;
using System.Windows.Forms;

namespace PresentationLayer.Presenters
{
    public class CustomerPresenter
    {
        public ICustomerView _view;
        private IUnitOfWork _unitOfWork;
        private BindingSource CustomerBindingSource;
        private BindingSource CustomerTypeBindingSource;

        private BindingSource BarangayBindingSource;
        private BindingSource CityBindingSource;
        private BindingSource ProvinceBindingSource;
        private BindingSource RegionBindingSource;

        private IEnumerable<Customer> CustomerList;
        private IEnumerable<CustomerType> CustomerTypeList;

        private IEnumerable<Barangay> GetBarangayList;
        private IEnumerable<City> GetCityList;
        private IEnumerable<Province> GetProvinceList;
        private IEnumerable<Regions> GetRegionList;

        private readonly static string reportDirectory = Path.Combine(Application.StartupPath, "Json");

        private readonly static string regionreportFileName = "region.json";
        private readonly static string regionreportPath = Path.Combine(reportDirectory, regionreportFileName);
        private readonly static string regiondata = File.ReadAllText(regionreportPath);

        private readonly static string provincereportFileName = "province.json";
        private readonly static string provincereportPath = Path.Combine(reportDirectory, provincereportFileName);
        private readonly static string provincedata = File.ReadAllText(provincereportPath);

        private readonly static string cityreportFileName = "city.json";
        private readonly static string cityreportPath = Path.Combine(reportDirectory, cityreportFileName);
        private readonly static string citydata = File.ReadAllText(cityreportPath);

        private readonly static string barangayreportFileName = "barangay.json";
        private readonly static string barangayreportPath = Path.Combine(reportDirectory, barangayreportFileName);
        private readonly static string barangaydata = File.ReadAllText(barangayreportPath);
        public CustomerPresenter(ICustomerView view, IUnitOfWork unitOfWork) {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            CustomerBindingSource = new BindingSource();
            CustomerTypeBindingSource = new BindingSource();

            BarangayBindingSource = new BindingSource();
            CityBindingSource = new BindingSource();
            ProvinceBindingSource = new BindingSource();
            RegionBindingSource = new BindingSource();

            //Events
            _view.AddNewEvent += AddNew;
            _view.SaveEvent += Save;
            _view.SearchEvent += Search;
            _view.EditEvent += Edit;
            _view.DeleteEvent += Delete;
            _view.PrintEvent += Print;
            _view.RefreshEvent += Return;

            _view.RegionEvent += RegionEvent;
            _view.ProvinceEvent += ProvinceEvent;
            _view.CityEvent += CityEvent;

            _view.DisplayCustomerEvent += DisplayCustomerEvent;

            //Source Binding
            _view.SetCustomerListBindingSource(CustomerBindingSource);
            _view.SetCustomerTypeListBindingSource(CustomerTypeBindingSource);
            _view.SetAddressBindingSource(BarangayBindingSource, CityBindingSource,
                                          ProvinceBindingSource, RegionBindingSource);

            //Load

            GetRegions();
            LoadAllCustomerTypeList();
            LoadAllCustomerList();
        }

        private void DisplayCustomerEvent(object? sender, DataGridViewCellEventArgs e)
        {
            var customerData = (CustomerVM)CustomerBindingSource.Current;
            var entity = _unitOfWork.Customer.Get(c => c.CustomerId.Equals(customerData.Id));
            string regionCode = entity.RegionCode;
            string provinceCode = entity.ProvinceCode;
            string cityCode = entity.CityCode;
            string barangayCode = entity.BarangayCode;

            var region = GetRegionList.FirstOrDefault(r => r.RegionCode == regionCode);
            var province = GetProvinceList.FirstOrDefault(p => p.ProvinceCode == provinceCode);
            var city = GetCityList.FirstOrDefault(p => p.CityCode == cityCode);
            var barangay = GetBarangayList.FirstOrDefault(p => p.BarangayCode == barangayCode);

            var parameters = new List<ReportParameter>
            {
                new ReportParameter("Region", region.RegionName),
                new ReportParameter("Province", province.ProvinceName),
                new ReportParameter("City", city.CityName),
                new ReportParameter("Barangay", barangay.BarangayName)
            };

            string reportFileName = "CustomerDetailReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            localReport.ReportPath = reportPath;
            var reportDataSource = new ReportDataSource("CustomerDetails", new List<Customer> { entity });
            localReport.SetParameters(parameters);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }

        private void AddressEvent(object? sender, EventArgs e)
        {
            string selectedRegionId = _view.RegionCode;
            var selectedRegion = GetRegionList.FirstOrDefault(region => region.RegionCode.Equals(selectedRegionId));
            GetProvince(selectedRegion.RegionCode);
        }
        private void RegionEvent(object? sender, EventArgs e)
        {
            string selectedRegionId = _view.RegionCode;
            var selectedRegion = GetRegionList.FirstOrDefault(region => region.RegionCode.Equals(selectedRegionId));
            GetProvince(selectedRegion.RegionCode);
        }

        private void ProvinceEvent(object? sender, EventArgs e)
        {
            string selectedProvinceId = _view.ProvinceCode;
            var selectedProvince = GetProvinceList.FirstOrDefault(p => p.ProvinceCode.Equals(selectedProvinceId));
            GetCity(selectedProvince.ProvinceCode);
        }
        private void CityEvent(object? sender, EventArgs e)
        {
            string selectedCityId = _view.CityCode;
            var selectedCity = GetCityList.FirstOrDefault(p => p.CityCode.Equals(selectedCityId));
            GetBarangay(selectedCity.CityCode);
        }

        private void GetRegions()
        {
            GetRegionList = JsonConvert.DeserializeObject<List<Regions>>(regiondata);
            RegionBindingSource.DataSource = GetRegionList;
            if (GetRegionList.Any())
            {
                // Access provinces of the first region
                var firstRegion = GetRegionList.First();
                GetProvince(firstRegion.RegionCode);
            }
        }

        private void GetProvince(string region)
        {
            GetProvinceList = JsonConvert.DeserializeObject<List<Province>>(provincedata);
            var selectedProvinces = GetProvinceList.Where(p => p.RegionCode.Contains(region)).ToList();
            ProvinceBindingSource.DataSource = selectedProvinces;
            if (GetProvinceList.Any())
            {
                // Access provinces of the first region
                var firstProvince = GetProvinceList.First();
                GetCity(firstProvince.ProvinceCode);
            }
        }
        private void GetCity(string province)
        {
            GetCityList = JsonConvert.DeserializeObject<List<City>>(citydata);
            var selectedCities = GetCityList.Where(c => c.ProvinceCode.Contains(province)).ToList();
            CityBindingSource.DataSource = selectedCities;
            if (GetCityList.Any())
            {
                // Access provinces of the first region
                var firstCity = GetCityList.First();
                GetBarangay(firstCity.CityCode);
            }
        }
        private void GetBarangay(string city)
        {
            GetBarangayList = JsonConvert.DeserializeObject<List<Barangay>>(barangaydata);
            var selectedBarangays = GetBarangayList.Where(c => c.CityCode.Contains(city)).ToList();
            BarangayBindingSource.DataSource = selectedBarangays;
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
                var existingEntity = _unitOfWork.Customer.Get(c => c.CustomerName == _view.CustomerName);

                if (existingEntity != null)
                {
                    // If editing and entity with the same name already exists, handle appropriately
                    if (_view.IsEdit)
                    {
                        if (existingEntity.CustomerId != _view.CustomerId)
                        {
                            _view.Message = "Another Customer with the same name already exists.";
                            return;
                        }
                    }
                    else
                    {
                        // If adding new and entity with the same name already exists, notify and return
                        _view.Message = "Customer with the same name already exists.";
                        return;
                    }
                }
                Customer entity;
                if (_view.CustomerId == 0)
                {
                    entity = new Customer()
                    {
                        CustomerId = _view.CustomerId,
                        CustomerName = _view.CustomerName,
                        CustomerTypeId = _view.CustomerTypeId,
                        RegionCode = _view.RegionCode,
                        ProvinceCode = _view.ProvinceCode,
                        CityCode = _view.CityCode,
                        BarangayCode = _view.BarangayCode,
                        ZipCode = _view.ZipCode,
                        Phone = _view.Phone,
                        Email = _view.Email,
                        ContactPerson = _view.ContactPerson,
                    };
                    _unitOfWork.Customer.Add(entity);
                }
                else
                {
                    // Retrieve the existing entity if editing
                    entity = _unitOfWork.Customer.Get(c => c.CustomerId == _view.CustomerId);
                    if (entity == null)
                    {
                        // Handle scenario where entity with the provided ID is not found
                        _view.Message = "Customer type not found for editing.";
                        return;
                    }

                    // Update the existing entity
                    entity.CustomerId = _view.CustomerId;
                    entity.CustomerName = _view.CustomerName;
                    entity.CustomerId = _view.CustomerId;
                    entity.RegionCode = _view.RegionCode;
                    entity.ProvinceCode = _view.ProvinceCode;
                    entity.CityCode = _view.CityCode;
                    entity.BarangayCode = _view.BarangayCode;
                    entity.ZipCode = _view.ZipCode;
                    entity.Phone = _view.Phone;
                    entity.Email = _view.Email;
                    entity.ContactPerson = _view.ContactPerson;
                    _unitOfWork.Customer.Update(entity);
                }
                new ModelDataValidation().Validate(entity);
                // Save changes
                _unitOfWork.Save();

                // Set success message
                _view.Message = _view.IsEdit ? "Customer edited successfully" : "Customer added successfully";
                _view.IsSuccessful = true;

                // Clear view fields
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
                CustomerList = _unitOfWork.Customer.GetAll(c => c.CustomerName.Contains(_view.SearchValue));
                CustomerBindingSource.DataSource = CustomerList;
            }
            else
            {
                CustomerList = _unitOfWork.Customer.GetAll();
                CustomerBindingSource.DataSource = CustomerList;
            }
        }
        private void Edit(object? sender, EventArgs e)
        {
            var customerData = (CustomerVM)CustomerBindingSource.Current;
            var entity = _unitOfWork.Customer.Get(c => c.CustomerId.Equals(customerData.Id));
            _view.CustomerId = entity.CustomerId;
            _view.CustomerName = entity.CustomerName;
            _view.CustomerId = entity.CustomerId;
            _view.BarangayCode = entity.BarangayCode;
            _view.CityCode = entity.CityCode;
            _view.ProvinceCode = entity.ProvinceCode;
            _view.RegionCode = entity.RegionCode;
            _view.ZipCode = entity.ZipCode;
            _view.Phone = entity.Phone;
            _view.Email = entity.Email;
            _view.ContactPerson = entity.ContactPerson;
        }
        private void Delete(object? sender, EventArgs e)
        {
            try
            {
                var entity = (Customer)CustomerBindingSource.Current;
                _unitOfWork.Customer.Remove(entity);
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                _view.Message = "Customer deleted successfully";
                LoadAllCustomerList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete customer type";
            }
        }
        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "CustomerListReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("CustomerList", CustomerList);
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
            _view.CustomerId = 0;
            _view.CustomerName = "";
            _view.CustomerId = 0;
            _view.ZipCode = "";
            _view.Phone = "";
            _view.Email = "";
            _view.ContactPerson = "";
        }
        
        private void LoadAllCustomerList()
        {
            CustomerList = _unitOfWork.Customer.GetAll(includeProperties: "CustomerType");
            var displayedCustomers = new List<CustomerVM>();
            foreach (var customer in CustomerList)
            {
                //string regionCode = customer.RegionCode; 
                //string provinceCode = customer.ProvinceCode; 
                //string cityCode = customer.CityCode; 
                //string barangayCode = customer.BarangayCode;

                //var region = GetRegionList.FirstOrDefault(r => r.RegionCode == regionCode);
                //var province = GetProvinceList.FirstOrDefault(p => p.ProvinceCode == provinceCode);
                //var city = GetCityList.FirstOrDefault(p => p.CityCode == cityCode);
                //var barangay = GetBarangayList.FirstOrDefault(p => p.BarangayCode == barangayCode);
                //customer.RegionName = region.RegionName;
                //customer.ProvinceName = province.ProvinceName;
                //customer.CityName = city.CityName;
                //customer.BarangayName = barangay.BarangayName;

                var displayedCustomer = new CustomerVM
                {
                    Id = customer.CustomerId,
                    Name = customer.CustomerName,
                    Type = customer.CustomerType?.CustomerTypeName, 
                };
                displayedCustomers.Add(displayedCustomer);
            }

            CustomerBindingSource.DataSource = displayedCustomers;//Set data source.
        }
        private void LoadAllCustomerTypeList()
        {
            CustomerTypeList = _unitOfWork.CustomerType.GetAll();
            CustomerTypeBindingSource.DataSource = CustomerTypeList;//Set data source.
        }
    }
}
