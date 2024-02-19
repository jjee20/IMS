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
    public class BranchPresenter
    {
        public IBranchView _view;
        private IUnitOfWork _unitOfWork;
        private BindingSource BranchBindingSource;
        private BindingSource CurrencyBindingSource;

        private BindingSource BarangayBindingSource;
        private BindingSource CityBindingSource;
        private BindingSource ProvinceBindingSource;
        private BindingSource RegionBindingSource;

        private IEnumerable<Branch> BranchList;
        private IEnumerable<Currency> CurrencyList;

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
        public BranchPresenter(IBranchView view, IUnitOfWork unitOfWork) {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            BranchBindingSource = new BindingSource();
            CurrencyBindingSource = new BindingSource();

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

            _view.DisplayBranchEvent += DisplayBranchEvent;

            //Source Binding
            _view.SetBranchListBindingSource(BranchBindingSource);
            _view.SetCurrencyListBindingSource(CurrencyBindingSource);
            _view.SetAddressBindingSource(BarangayBindingSource, CityBindingSource,
                                          ProvinceBindingSource, RegionBindingSource);

            //Load

            GetRegions();
            LoadAllCurrencyList();
            LoadAllBranchList();
        }

        private void DisplayBranchEvent(object? sender, DataGridViewCellEventArgs e)
        {
            var BranchData = (BranchVM)BranchBindingSource.Current;
            var entity = _unitOfWork.Branch.Get(c => c.BranchId.Equals(BranchData.Id), includeProperties: "Currency");

            var region = GetRegionList.FirstOrDefault(r => r.RegionCode == entity.RegionCode);
            var province = GetProvinceList.FirstOrDefault(p => p.ProvinceCode == entity.ProvinceCode);
            var city = GetCityList.FirstOrDefault(p => p.CityCode == entity.CityCode);
            var barangay = GetBarangayList.FirstOrDefault(p => p.BarangayCode == entity.BarangayCode);

            var parameters = new List<ReportParameter>
            {
                new ReportParameter("BranchName", entity.BranchName),
                new ReportParameter("Email", entity.Email),
                new ReportParameter("Phone", entity.Phone),
                new ReportParameter("ZipCode", entity.ZipCode),
                new ReportParameter("ContactPerson", entity.ContactPerson),
                new ReportParameter("Currency", entity.Currency.CurrencyName),
                new ReportParameter("Region", region.RegionName),
                new ReportParameter("Province", province.ProvinceName),
                new ReportParameter("City", city.CityName),
                new ReportParameter("Barangay", barangay.BarangayName)
            };

            string reportFileName = "BranchDetailReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            localReport.ReportPath = reportPath;
            var reportDataSource = new ReportDataSource("BranchDetails", new List<Branch> { entity });
            var reportView = new ReportView(reportPath, reportDataSource, localReport, parameters);
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
                var existingEntity = _unitOfWork.Branch.Get(c => c.BranchName == _view.BranchName);

                if (existingEntity != null)
                {
                    // If editing and entity with the same name already exists, handle appropriately
                    if (_view.IsEdit)
                    {
                        if (existingEntity.BranchId != _view.BranchId)
                        {
                            _view.Message = "Another Branch with the same name already exists.";
                            return;
                        }
                    }
                    else
                    {
                        // If adding new and entity with the same name already exists, notify and return
                        _view.Message = "Branch with the same name already exists.";
                        return;
                    }
                }
                Branch entity;
                if (_view.BranchId == 0)
                {
                    entity = new Branch()
                    {
                        BranchId = _view.BranchId,
                        BranchName = _view.BranchName,
                        Description = _view.Description,
                        CurrencyId = _view.CurrencyId,
                        RegionCode = _view.RegionCode,
                        ProvinceCode = _view.ProvinceCode,
                        CityCode = _view.CityCode,
                        BarangayCode = _view.BarangayCode,
                        ZipCode = _view.ZipCode,
                        Phone = _view.Phone,
                        Email = _view.Email,
                        ContactPerson = _view.ContactPerson,
                    };
                    _unitOfWork.Branch.Add(entity);
                }
                else
                {
                    // Retrieve the existing entity if editing
                    entity = _unitOfWork.Branch.Get(c => c.BranchId == _view.BranchId);
                    if (entity == null)
                    {
                        // Handle scenario where entity with the provided ID is not found
                        _view.Message = "Branch type not found for editing.";
                        return;
                    }

                    // Update the existing entity
                    entity.BranchId = _view.BranchId;
                    entity.BranchName = _view.BranchName;
                    entity.Description = _view.Description;
                    entity.CurrencyId = _view.CurrencyId;
                    entity.RegionCode = _view.RegionCode;
                    entity.ProvinceCode = _view.ProvinceCode;
                    entity.CityCode = _view.CityCode;
                    entity.BarangayCode = _view.BarangayCode;
                    entity.ZipCode = _view.ZipCode;
                    entity.Phone = _view.Phone;
                    entity.Email = _view.Email;
                    entity.ContactPerson = _view.ContactPerson;
                    _unitOfWork.Branch.Update(entity);
                }
                new ModelDataValidation().Validate(entity);
                // Save changes
                _unitOfWork.Save();

                // Set success message
                _view.Message = _view.IsEdit ? "Branch edited successfully" : "Branch added successfully";
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
                BranchList = _unitOfWork.Branch.GetAll(c => c.BranchName.Contains(_view.SearchValue));
                BranchBindingSource.DataSource = BranchList;
            }
            else
            {
                BranchList = _unitOfWork.Branch.GetAll();
                BranchBindingSource.DataSource = BranchList;
            }
        }
        private void Edit(object? sender, EventArgs e)
        {
            var BranchData = (BranchVM)BranchBindingSource.Current;
            var entity = _unitOfWork.Branch.Get(c => c.BranchId.Equals(BranchData.Id));
            _view.BranchId = entity.BranchId;
            _view.BranchName = entity.BranchName;
            _view.Description = entity.Description;
            _view.CurrencyId = entity.CurrencyId;
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
                var entity = (Branch)BranchBindingSource.Current;
                _unitOfWork.Branch.Remove(entity);
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                _view.Message = "Branch deleted successfully";
                LoadAllBranchList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete Branch type";
            }
        }
        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "BranchListReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("BranchList", BranchList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport,null);
            reportView.ShowDialog();
        }
        private void Return(object? sender, EventArgs e)
        {
            LoadAllBranchList();
        }
        private void CleanviewFields()
        {
            LoadAllBranchList();
            _view.BranchId = 0;
            _view.BranchName = "";
            _view.Description = "";
            _view.BranchId = 0;
            _view.ZipCode = "";
            _view.Phone = "";
            _view.Email = "";
            _view.ContactPerson = "";
        }
        
        private void LoadAllBranchList()
        {
            BranchList = _unitOfWork.Branch.GetAll(includeProperties: "Currency");
            var displayedBranchs = new List<BranchVM>();
            foreach (var Branch in BranchList)
            {
                //string regionCode = Branch.RegionCode; 
                //string provinceCode = Branch.ProvinceCode; 
                //string cityCode = Branch.CityCode; 
                //string barangayCode = Branch.BarangayCode;

                //var region = GetRegionList.FirstOrDefault(r => r.RegionCode == regionCode);
                //var province = GetProvinceList.FirstOrDefault(p => p.ProvinceCode == provinceCode);
                //var city = GetCityList.FirstOrDefault(p => p.CityCode == cityCode);
                //var barangay = GetBarangayList.FirstOrDefault(p => p.BarangayCode == barangayCode);
                //Branch.RegionName = region.RegionName;
                //Branch.ProvinceName = province.ProvinceName;
                //Branch.CityName = city.CityName;
                //Branch.BarangayName = barangay.BarangayName;

                var displayedBranch = new BranchVM
                {
                    Id = Branch.BranchId,
                    Name = Branch.BranchName,
                    Description = Branch.Description,
                    Currency = Branch.Currency?.CurrencyName, 
                };
                displayedBranchs.Add(displayedBranch);
            }

            BranchBindingSource.DataSource = displayedBranchs;//Set data source.
        }
        private void LoadAllCurrencyList()
        {
            CurrencyList = _unitOfWork.Currency.GetAll();
            CurrencyBindingSource.DataSource = CurrencyList;//Set data source.
        }
    }
}
