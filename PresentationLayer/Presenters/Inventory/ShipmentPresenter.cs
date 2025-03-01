using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels.Inventory;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using ServiceLayer.Services.IRepositories.IInventory;

namespace PresentationLayer.Presenters
{
    public class ShipmentPresenter
    {
        public IShipmentView _view;
        private IUnitOfWork _unitOfWork;
        private BindingSource ShipmentBindingSource;
        private BindingSource ShipmentTypeBindingSource;
        private BindingSource SalesOrderBindingSource;
        private BindingSource WarehouseBindingSource;
        private IEnumerable<ShipmentViewModel> ShipmentList;
        private IEnumerable<ShipmentType> ShipmentTypeList;
        private IEnumerable<SalesOrder> SalesOrderList;
        private IEnumerable<Warehouse> WarehouseList;
        public ShipmentPresenter(IShipmentView view, IUnitOfWork unitOfWork) {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            ShipmentBindingSource = new BindingSource();
            ShipmentTypeBindingSource = new BindingSource();
            SalesOrderBindingSource = new BindingSource();
            WarehouseBindingSource = new BindingSource();

            //Events
            _view.AddNewEvent += AddNew;
            _view.SaveEvent += Save;
            _view.SearchEvent += Search;
            _view.EditEvent += Edit;
            _view.DeleteEvent += Delete;
            _view.PrintEvent += Print;
            _view.RefreshEvent += Return;
            //Load

            LoadAllShipmentList();
            LoadAllShipmentTypeList();
            LoadAllSalesOrderList();
            LoadAllWarehouseList();

            //Source Binding
            _view.SetShipmentListBindingSource(ShipmentBindingSource);
            _view.SetShipmentTypeListBindingSource(ShipmentTypeBindingSource);
            _view.SetSalesOrderListBindingSource(SalesOrderBindingSource);
            _view.SetWarehouseListBindingSource(WarehouseBindingSource);

        }

        private void AddNew(object? sender, EventArgs e)
        {
            _view.IsEdit = false;
            CleanviewFields();
        }
        private void Save(object? sender, EventArgs e)
        {
            var model = _unitOfWork.Shipment.Get(c => c.ShipmentId == _view.ShipmentId, tracked: true);
            if (model == null) model = new Shipment();
            else _unitOfWork.Shipment.Detach(model);

            model.ShipmentId = _view.ShipmentId;
            model.ShipmentName = _view.ShipmentName;
            model.SalesOrderId = _view.SalesOrderId;
            model.ShipmentDate = _view.ShipmentDate;
            model.ShipmentTypeId = _view.ShipmentTypeId;
            model.WarehouseId = _view.WarehouseId;
            model.IsFullShipment = _view.IsFullShipment;

            try
            {
                new ModelDataValidation().Validate(model);
                if (_view.IsEdit)//Edit model
                {
                    _unitOfWork.Shipment.Update(model);
                    _view.Message = "Shipment edited successfully";
                }
                else //Add new model
                {
                    _unitOfWork.Shipment.Add(model);
                    _view.Message = "Shipment added successfully";
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
                ShipmentList = Program.Mapper.Map<IEnumerable<ShipmentViewModel>>(_unitOfWork.Shipment.GetAll(c => c.ShipmentName.Contains(_view.SearchValue)));
                ShipmentBindingSource.DataSource = ShipmentList;
            }
            else
            {
                LoadAllShipmentList();
            }
        }
        private void Edit(object? sender, EventArgs e)
        {
            _view.IsEdit = true;
            var shipment = (ShipmentViewModel)ShipmentBindingSource.Current;
            var entity = _unitOfWork.Shipment.Get(c => c.ShipmentId == shipment.ShipmentId);
            _view.ShipmentId = entity.ShipmentId;
            _view.ShipmentName = entity.ShipmentName;
            _view.SalesOrderId = entity.SalesOrderId;
            _view.ShipmentDate = entity.ShipmentDate;
            _view.ShipmentTypeId = entity.ShipmentTypeId;
            _view.WarehouseId = entity.WarehouseId;
            _view.IsFullShipment = entity.IsFullShipment;
        }
        private void Delete(object? sender, EventArgs e)
        {
            try
            {
                var shipment = (ShipmentViewModel)ShipmentBindingSource.Current;
                var entity = _unitOfWork.Shipment.Get(c => c.ShipmentId == shipment.ShipmentId);
                _unitOfWork.Shipment.Remove(entity);
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                _view.Message = "Shipment deleted successfully";
                LoadAllShipmentList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete Shipment";
            }
        }
        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "ShipmentReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports", "Inventory");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("Shipment", ShipmentList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        private void Return(object? sender, EventArgs e)
        {
            LoadAllShipmentList();
        }
        private void CleanviewFields()
        {
            LoadAllShipmentList();
            _view.ShipmentId = 0;
            _view.ShipmentName = "";
            _view.SalesOrderId = 0;
            _view.ShipmentDate = DateTime.Now;
            _view.ShipmentTypeId = 0;
            _view.WarehouseId = 0;
            _view.IsFullShipment = true;
        }
        
        private void LoadAllShipmentList()
        {
            ShipmentList = Program.Mapper.Map<IEnumerable<ShipmentViewModel>>(_unitOfWork.Shipment.GetAll());
            ShipmentBindingSource.DataSource = ShipmentList;//Set data source.
        }
        private void LoadAllShipmentTypeList()
        {
            ShipmentTypeList = _unitOfWork.ShipmentType.GetAll();
            ShipmentTypeBindingSource.DataSource = ShipmentTypeList;//Set data source.
        }
        private void LoadAllSalesOrderList()
        {
            SalesOrderList = _unitOfWork.SalesOrder.GetAll();
            SalesOrderBindingSource.DataSource = SalesOrderList;//Set data source.
        }
        private void LoadAllWarehouseList()
        {
            WarehouseList = _unitOfWork.Warehouse.GetAll();
            WarehouseBindingSource.DataSource = WarehouseList;//Set data source.
        }
    }
}
