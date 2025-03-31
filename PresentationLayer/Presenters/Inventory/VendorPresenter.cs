using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels.Inventory;
using Microsoft.Reporting.Map.WebForms.BingMaps;
using Microsoft.Reporting.WinForms;
using Newtonsoft.Json;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using ServiceLayer.Services.IRepositories;
using ServiceLayer.Services.IRepositories.IInventory;
using static PresentationLayer.Json.Address;

namespace PresentationLayer.Presenters
{
    public class VendorPresenter
    {
        public IVendorView _view;
        private IUnitOfWork _unitOfWork;
        private BindingSource VendorBindingSource;
        private BindingSource VendorTypeBindingSource;

        private IEnumerable<VendorViewModel> VendorList;
        private IEnumerable<VendorType> VendorTypeList;

        //private List<string> GetBarangayList;
        //private List<string> GetMunicipalityList;
        //private List<string> GetProvinceList;
        //private List<string> GetRegionList;

        string reportFileName = "philippine_provinces_cities_municipalities_and_barangays_2019v2.json";
        string reportDirectory = Path.Combine(Application.StartupPath, "Json");
        public VendorPresenter(IVendorView view, IUnitOfWork unitOfWork) {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            VendorBindingSource = new BindingSource();
            VendorTypeBindingSource = new BindingSource();

            //GetBarangayList = new List<string>();
            //GetMunicipalityList = new List<string>();
            //GetProvinceList = new List<string>();
            //GetRegionList = new List<string>();

            //Events
            _view.AddNewEvent += AddNew;
            _view.SaveEvent += Save;
            _view.SearchEvent += Search;
            _view.EditEvent += Edit;
            _view.DeleteEvent += Delete;
            _view.PrintEvent += Print;
            _view.RefreshEvent += Return;
            //Load

            LoadAllVendorList();
            LoadAllVendorTypeList();
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
        private void Save(object? sender, EventArgs e)
        {
            var model = _unitOfWork.Vendor.Value.Get(c => c.VendorId == _view.VendorId, tracked: true);
            if (model == null) model = new Vendor();
            else _unitOfWork.Vendor.Value.Detach(model);

            model.VendorId = _view.VendorId;
            model.VendorName = _view.VendorName;
            model.VendorTypeId = _view.VendorTypeId;
            model.Address = _view.Address;
            model.Phone = _view.Phone;
            model.Email = _view.Email;
            model.ContactPerson = _view.ContactPerson;

            try
            {
                new ModelDataValidation().Validate(model);
                if (_view.IsEdit)//Edit model
                {
                    _unitOfWork.Vendor.Value.Update(model);
                    _view.Message = "Vendor edited successfully";
                }
                else //Add new model
                {
                    _unitOfWork.Vendor.Value.Add(model);
                    _view.Message = "Vendor added successfully";
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
        private void Search(object? sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(_view.SearchValue);
            if (emptyValue == false)
            {
                VendorList = Program.Mapper.Map<IEnumerable<VendorViewModel>>(_unitOfWork.Vendor.Value.GetAll(c => c.VendorName.Contains(_view.SearchValue), includeProperties: "VendorType"));
                VendorBindingSource.DataSource = VendorList;
            }
            else
            {
                LoadAllVendorList();
            }
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

            var vendor = (VendorViewModel)_view.DataGrid.SelectedItem;
            var entity = _unitOfWork.Vendor.Value.Get(c => c.VendorId == vendor.VendorId);
            _view.VendorId = entity.VendorId;
            _view.VendorName = entity.VendorName;
            _view.VendorTypeId = entity.VendorTypeId;
            _view.Address = entity.Address;
            _view.Phone = entity.Phone;
            _view.Email = entity.Email;
            _view.ContactPerson = entity.ContactPerson;
        }
        private void Delete(object? sender, EventArgs e)
        {
            try
            {
                if (_view.DataGrid.SelectedItem == null)
                {
                    _view.IsSuccessful = false;
                    _view.Message = "Please select one to edit";
                    return;
                }

                var vendor = (VendorViewModel)_view.DataGrid.SelectedItem;
                var entity = _unitOfWork.Vendor.Value.Get(c => c.VendorId == vendor.VendorId);
                _unitOfWork.Vendor.Value.Remove(entity);
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                _view.Message = "Vendor deleted successfully";
                LoadAllVendorList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete Vendor type";
            }
        }
        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "VendorReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports", "Inventory");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("Vendor", VendorList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        private void Return(object? sender, EventArgs e)
        {
            LoadAllVendorList();
        }
        private void CleanviewFields()
        {
            LoadAllVendorList();
            LoadAllVendorTypeList();
            _view.VendorId = 0;
            _view.VendorName = "";
            _view.VendorTypeId = 0;
            _view.Address = "";
            _view.Phone = "";
            _view.Email = "";
            _view.ContactPerson = "";
        }

        private void LoadAllVendorList()
        {
            VendorList = Program.Mapper.Map<IEnumerable<VendorViewModel>>(_unitOfWork.Vendor.Value.GetAll(includeProperties: "VendorType"));
            VendorBindingSource.DataSource = VendorList;//Set data source.
            _view.SetVendorListBindingSource(VendorBindingSource);
        }
        private void LoadAllVendorTypeList()
        {
            VendorTypeList = _unitOfWork.VendorType.Value.GetAll();
            VendorTypeBindingSource.DataSource = VendorTypeList;//Set data source.
            _view.SetVendorTypeListBindingSource(VendorTypeBindingSource);
        }

    }
}
