using DomainLayer.Models.Inventory;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using ServiceLayer.Services.IRepositories;

namespace PresentationLayer.Presenters
{
    public class ShipmentTypePresenter
    {
        public IShipmentTypeView _view;
        private IUnitOfWork _unitOfWork;
        private BindingSource ShipmentTypeBindingSource;
        private IEnumerable<ShipmentType> ShipmentTypeList;
        public ShipmentTypePresenter(IShipmentTypeView view, IUnitOfWork unitOfWork) {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            ShipmentTypeBindingSource = new BindingSource();

            //Events
            _view.AddNewEvent += AddNew;
            _view.SaveEvent += Save;
            _view.SearchEvent += Search;
            _view.EditEvent += Edit;
            _view.DeleteEvent += Delete;
            _view.PrintEvent += Print;
            _view.RefreshEvent += Return;
            //Load

            LoadAllShipmentTypeList();

            //Source Binding
            _view.SetShipmentTypeListBindingSource(ShipmentTypeBindingSource);

        }

        private void AddNew(object? sender, EventArgs e)
        {
            _view.IsEdit = false;
            CleanviewFields();
        }
        private void Save(object? sender, EventArgs e)
        {
            var model = _unitOfWork.ShipmentType.Get(c => c.ShipmentTypeId == _view.ShipmentTypeId, tracked: true);
            if (model == null) model = new ShipmentType();
            else _unitOfWork.ShipmentType.Detach(model);

            model.ShipmentTypeId = _view.ShipmentTypeId;
            model.ShipmentTypeName = _view.ShipmentTypeName;
            model.Description = _view.Description;

            try
            {
                new ModelDataValidation().Validate(model);
                if (_view.IsEdit)//Edit model
                {
                    _unitOfWork.ShipmentType.Update(model);
                    _view.Message = "Shipment type edited successfully";
                }
                else //Add new model
                {
                    _unitOfWork.ShipmentType.Add(model);
                    _view.Message = "Shipment type added successfully";
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
                ShipmentTypeList = _unitOfWork.ShipmentType.GetAll(c => c.ShipmentTypeName.Contains(_view.SearchValue));
                ShipmentTypeBindingSource.DataSource = ShipmentTypeList;
            }
            else
            {
                LoadAllShipmentTypeList();
            }
        }
        private void Edit(object? sender, EventArgs e)
        {
            _view.IsEdit = true;
            var entity = (ShipmentType)ShipmentTypeBindingSource.Current;
            _view.ShipmentTypeId = entity.ShipmentTypeId;
            _view.ShipmentTypeName = entity.ShipmentTypeName;
            _view.Description = entity.Description;
        }
        private void Delete(object? sender, EventArgs e)
        {
            try
            {
                var entity = (ShipmentType)ShipmentTypeBindingSource.Current;
                _unitOfWork.ShipmentType.Remove(entity);
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                _view.Message = "Shipment type deleted successfully";
                LoadAllShipmentTypeList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete Shipment type";
            }
        }
        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "ShipmentTypeReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports", "Inventory");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("ShipmentType", ShipmentTypeList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        private void Return(object? sender, EventArgs e)
        {
            LoadAllShipmentTypeList();
        }
        private void CleanviewFields()
        {
            LoadAllShipmentTypeList();
            _view.ShipmentTypeId = 0;
            _view.ShipmentTypeName = "";
            _view.Description = "";
        }
        
        private void LoadAllShipmentTypeList()
        {
            ShipmentTypeList = _unitOfWork.ShipmentType.GetAll();
            ShipmentTypeBindingSource.DataSource = ShipmentTypeList;//Set data source.
        }
    }
}
