using DomainLayer.Models;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using ServiceLayer.Services.IRepositories;

namespace PresentationLayer.Presenters
{
    public class VendorTypePresenter
    {
        public IVendorTypeView _view;
        private IUnitOfWork _unitOfWork;
        private BindingSource VendorTypeBindingSource;
        private IEnumerable<VendorType> VendorTypeList;
        public VendorTypePresenter(IVendorTypeView view, IUnitOfWork unitOfWork) {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            VendorTypeBindingSource = new BindingSource();

            //Events
            _view.AddNewEvent += AddNew;
            _view.SaveEvent += Save;
            _view.SearchEvent += Search;
            _view.EditEvent += Edit;
            _view.DeleteEvent += Delete;
            _view.PrintEvent += Print;
            _view.RefreshEvent += Return;

            //Source Binding
            _view.SetVendorTypeListBindingSource(VendorTypeBindingSource);

            //Load

            LoadAllVendorTypeList();
        }

        private void AddNew(object? sender, EventArgs e)
        {
            _view.IsEdit = false;
            CleanviewFields();
        }
        private void Save(object? sender, EventArgs e)
        {
            var Entity = _unitOfWork.VendorType.Get(c => c.VendorTypeName == _view.VendorTypeName);
            if (Entity != null)
            {
                _view.Message = "Vendor type is already added.";
                return;
            }

            var model = new VendorType()
            {
                
                VendorTypeId = _view.VendorTypeId,
                VendorTypeName = _view.VendorTypeName,
                Description = _view.Description,
            };

            try
            {
                new ModelDataValidation().Validate(model);
                if (_view.IsEdit)//Edit model
                {
                    _unitOfWork.VendorType.Update(model);
                    _unitOfWork.Save();
                    _view.Message = "Vendor type edited successfuly";
                }
                else //Add new model
                {
                    _unitOfWork.VendorType.Add(model);
                    _unitOfWork.Save();
                    _view.Message = "Vendor type added sucessfully";
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
                VendorTypeList = _unitOfWork.VendorType.GetAll(c => c.VendorTypeName.Contains(_view.SearchValue));
                VendorTypeBindingSource.DataSource = VendorTypeList;
            }
            else
            {
                VendorTypeList = _unitOfWork.VendorType.GetAll();
                VendorTypeBindingSource.DataSource = VendorTypeList;
            }
        }
        private void Edit(object? sender, EventArgs e)
        {
            var entity = (VendorType)VendorTypeBindingSource.Current;
            _view.VendorTypeId = entity.VendorTypeId;
            _view.VendorTypeName = entity.VendorTypeName;
            _view.Description = entity.Description;
        }
        private void Delete(object? sender, EventArgs e)
        {
            try
            {
                var entity = (VendorType)VendorTypeBindingSource.Current;
                _unitOfWork.VendorType.Remove(entity);
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                _view.Message = "Vendor type deleted successfully";
                LoadAllVendorTypeList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete Vendor type";
            }
        }
        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "VendorTypeReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("VendorType", VendorTypeList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        private void Return(object? sender, EventArgs e)
        {
            LoadAllVendorTypeList();
        }
        private void CleanviewFields()
        {
            LoadAllVendorTypeList();
            _view.VendorTypeId = 0;
            _view.VendorTypeName = "";
            _view.Description = "";
        }
        
        private void LoadAllVendorTypeList()
        {
            VendorTypeList = _unitOfWork.VendorType.GetAll();
            VendorTypeBindingSource.DataSource = VendorTypeList;//Set data source.
        }
    }
}
