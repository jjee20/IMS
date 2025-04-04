using DomainLayer.Models.Inventory;
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
        private IEnumerable<VendorType> VendorTypeList;
        public VendorTypePresenter(IVendorTypeView view, IUnitOfWork unitOfWork) {

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

            LoadAllVendorTypeList();

            //Source Binding

        }

        private void AddNew(object? sender, EventArgs e)
        {
            _view.IsEdit = false;
            CleanviewFields();
        }
        private void Save(object? sender, EventArgs e)
        {
            var model = _unitOfWork.VendorType.Value.Get(c => c.VendorTypeId == _view.VendorTypeId, tracked: true);
            if (model == null) model = new VendorType();
            else _unitOfWork.VendorType.Value.Detach(model);

            model.VendorTypeId = _view.VendorTypeId;
            model.VendorTypeName = _view.VendorTypeName;
            model.Description = _view.Description;

            try
            {
                new ModelDataValidation().Validate(model);
                if (_view.IsEdit)//Edit model
                {
                    _unitOfWork.VendorType.Value.Update(model);
                    _view.Message = "Vendor type edited successfully";
                }
                else //Add new model
                {
                    _unitOfWork.VendorType.Value.Add(model);
                    _view.Message = "Vendor type added successfully";
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
            LoadAllVendorTypeList(emptyValue);
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

            var entity = (VendorType)_view.DataGrid.SelectedItem;
            _view.VendorTypeId = entity.VendorTypeId;
            _view.VendorTypeName = entity.VendorTypeName;
            _view.Description = entity.Description;
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

                var entity = (VendorType)_view.DataGrid.SelectedItem;
                _unitOfWork.VendorType.Value.Remove(entity);
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
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports", "Inventory");
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

        private void LoadAllVendorTypeList(bool emptyValue = false)
        {
            VendorTypeList = _unitOfWork.VendorType.Value.GetAll();

            if (!emptyValue) VendorTypeList = VendorTypeList.Where(c => c.VendorTypeName.ToLower().Contains(_view.SearchValue.ToLower()));
            _view.SetVendorTypeListBindingSource(VendorTypeList);
        }
    }
}
