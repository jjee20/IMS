using DomainLayer.Models;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using ServiceLayer.Services.IRepositories;

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
        private IEnumerable<Shipment> ShipmentList;
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

            //Source Binding
            _view.SetShipmentListBindingSource(ShipmentBindingSource);
            _view.SetShipmentTypeListBindingSource(ShipmentTypeBindingSource);
            _view.SetSalesOrderListBindingSource(SalesOrderBindingSource);
            _view.SetWarehouseListBindingSource(WarehouseBindingSource);

            //Load

            LoadAllShipmentList();
            LoadAllShipmentTypeList();
            LoadAllSalesOrderList();
            LoadAllWarehouseList();
        }

        private void AddNew(object? sender, EventArgs e)
        {
            _view.IsEdit = false;
            CleanviewFields();
        }
        private void Save(object? sender, EventArgs e)
        {
            var Entity = _unitOfWork.Shipment.Get(c => c.ShipmentName == _view.ShipmentName);
            if (Entity != null)
            {
                _view.Message = "Shipment type is already added.";
                return;
            }

            var model = new Shipment()
            {
                
                ShipmentId = _view.ShipmentId,
                ShipmentName = _view.ShipmentName,
                SalesOrderId = _view.SalesOrderId,
                ShipmentDate = _view.ShipmentDate,
                ShipmentTypeId = _view.ShipmentTypeId,
                WarehouseId = _view.WarehouseId,
                IsFullShipment = _view.IsFullShipment
            };

            try
            {
                new ModelDataValidation().Validate(model);
                if (_view.IsEdit)//Edit model
                {
                    _unitOfWork.Shipment.Update(model);
                    _unitOfWork.Save();
                    _view.Message = "Shipment type edited successfuly";
                }
                else //Add new model
                {
                    _unitOfWork.Shipment.Add(model);
                    _unitOfWork.Save();
                    _view.Message = "Shipment type added sucessfully";
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
                ShipmentList = _unitOfWork.Shipment.GetAll(c => c.ShipmentName.Contains(_view.SearchValue));
                ShipmentBindingSource.DataSource = ShipmentList;
            }
            else
            {
                ShipmentList = _unitOfWork.Shipment.GetAll();
                ShipmentBindingSource.DataSource = ShipmentList;
            }
        }
        private void Edit(object? sender, EventArgs e)
        {
            var entity = (Shipment)ShipmentBindingSource.Current;
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
                var entity = (Shipment)ShipmentBindingSource.Current;
                _unitOfWork.Shipment.Remove(entity);
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                _view.Message = "Shipment type deleted successfully";
                LoadAllShipmentList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete Shipment type";
            }
        }
        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "ShipmentReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports");
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
            ShipmentList = _unitOfWork.Shipment.GetAll();
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
