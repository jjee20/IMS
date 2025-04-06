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
        private IEnumerable<ShipmentType> ShipmentTypeList;
        public ShipmentTypePresenter(IShipmentTypeView view, IUnitOfWork unitOfWork) {

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

            LoadAllShipmentTypeList();

            //Source Binding

        }

        private void AddNew(object? sender, EventArgs e)
        {
            _view.IsEdit = false;
            CleanviewFields();
        }
        private async void Save(object? sender, EventArgs e)
        {
            var model = await _unitOfWork.ShipmentType.Value.GetAsync(c => c.ShipmentTypeId == _view.ShipmentTypeId, tracked: true);
            if (model == null) model = new ShipmentType();
            else _unitOfWork.ShipmentType.Value.Detach(model);

            model.ShipmentTypeId = _view.ShipmentTypeId;
            model.ShipmentTypeName = _view.ShipmentTypeName;
            model.Description = _view.Description;

            try
            {
                new ModelDataValidation().Validate(model);
                if (_view.IsEdit)//Edit model
                {
                    _unitOfWork.ShipmentType.Value.Update(model);
                    _view.Message = "Shipment type edited successfully";
                }
                else //Add new model
                {
                    await _unitOfWork.ShipmentType.Value.AddAsync(model);
                    _view.Message = "Shipment type added successfully";
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
            LoadAllShipmentTypeList(emptyValue);
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

            var entity = (ShipmentType)_view.DataGrid.SelectedItem;
            _view.ShipmentTypeId = entity.ShipmentTypeId;
            _view.ShipmentTypeName = entity.ShipmentTypeName;
            _view.Description = entity.Description;
        }
        private void Delete(object? sender, EventArgs e)
        {
            try
            {
                if (_view.DataGrid.SelectedItems == null || _view.DataGrid.SelectedItems.Count == 0)
                {
                    _view.IsSuccessful = false;
                    _view.Message = "Please select shipment type(s) to delete.";
                    _view.ShowMessage(_view.Message);
                    return;
                }

                var selectedItems = _view.DataGrid.SelectedItems.Cast<ShipmentType>().ToList();

                if (!selectedItems.Any())
                {
                    _view.IsSuccessful = false;
                    _view.Message = "No valid shipment types selected.";
                    _view.ShowMessage(_view.Message);
                    return;
                }

                _unitOfWork.ShipmentType.Value.RemoveRange(selectedItems);
                _unitOfWork.Save();

                _view.IsSuccessful = true;
                _view.Message = $"{selectedItems.Count} shipment type(s) deleted successfully.";
                _view.ShowMessage(_view.Message);
                LoadAllShipmentTypeList();
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
        
        private void LoadAllShipmentTypeList(bool emptyValue = false)
        {
            ShipmentTypeList = _unitOfWork.ShipmentType.Value.GetAll();

            if (!emptyValue) ShipmentTypeList = ShipmentTypeList.Where(c => c.ShipmentTypeName.Contains(_view.SearchValue));
            _view.SetShipmentTypeListBindingSource(ShipmentTypeList);
        }
    }
}
