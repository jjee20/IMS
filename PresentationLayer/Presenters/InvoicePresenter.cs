using DomainLayer.Models;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using ServiceLayer.Services.IRepositories;

namespace PresentationLayer.Presenters
{
    public class InvoicePresenter
    {
        public IInvoiceView _view;
        private IUnitOfWork _unitOfWork;
        private BindingSource InvoiceBindingSource;
        private BindingSource InvoiceTypeBindingSource;
        private BindingSource ShipmentBindingSource;
        private IEnumerable<Invoice> InvoiceList;
        private IEnumerable<InvoiceType> InvoiceTypeList;
        private IEnumerable<Shipment> ShipmentList;
        public InvoicePresenter(IInvoiceView view, IUnitOfWork unitOfWork) {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            InvoiceBindingSource = new BindingSource();
            InvoiceTypeBindingSource = new BindingSource();
            ShipmentBindingSource = new BindingSource();

            //Events
            _view.AddNewEvent += AddNew;
            _view.SaveEvent += Save;
            _view.SearchEvent += Search;
            _view.EditEvent += Edit;
            _view.DeleteEvent += Delete;
            _view.PrintEvent += Print;
            _view.RefreshEvent += Return;

            //Source Binding
            _view.SetInvoiceListBindingSource(InvoiceBindingSource);
            _view.SetInvoiceTypeListBindingSource(InvoiceTypeBindingSource);
            _view.SetShipmentListBindingSource(ShipmentBindingSource);

            //Load

            LoadAllInvoiceList();
            LoadAllShipmentList();
        }

        private void AddNew(object? sender, EventArgs e)
        {
            _view.IsEdit = false;
            CleanviewFields();
        }
        private void Save(object? sender, EventArgs e)
        {
            var Entity = _unitOfWork.Invoice.Get(c => c.InvoiceName == _view.InvoiceName);
            if (Entity != null)
            {
                _view.Message = "Bill type is already added.";
                return;
            }

            var model = new Invoice()
            {
                
                InvoiceId = _view.InvoiceId,
                InvoiceName = _view.InvoiceName,
                ShipmentId = _view.ShipmentId,
                InvoiceDate = _view.InvoiceDate,
                InvoiceDueDate = _view.InvoiceDueDate,
                InvoiceTypeId = _view.InvoiceTypeId,
            };

            try
            {
                new ModelDataValidation().Validate(model);
                if (_view.IsEdit)//Edit model
                {
                    _unitOfWork.Invoice.Update(model);
                    _unitOfWork.Save();
                    _view.Message = "Bill type edited successfuly";
                }
                else //Add new model
                {
                    _unitOfWork.Invoice.Add(model);
                    _unitOfWork.Save();
                    _view.Message = "Bill type added sucessfully";
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
                InvoiceList = _unitOfWork.Invoice.GetAll(c => c.InvoiceName.Contains(_view.SearchValue));
                InvoiceBindingSource.DataSource = InvoiceList;
            }
            else
            {
                InvoiceList = _unitOfWork.Invoice.GetAll();
                InvoiceBindingSource.DataSource = InvoiceList;
            }
        }
        private void Edit(object? sender, EventArgs e)
        {
            var entity = (Invoice)InvoiceBindingSource.Current;
            _view.InvoiceId = entity.InvoiceId;
            _view.InvoiceName = entity.InvoiceName;
            _view.ShipmentId = entity.ShipmentId;
            _view.InvoiceDate = entity.InvoiceDate;
            _view.InvoiceDueDate = entity.InvoiceDueDate;
            _view.InvoiceTypeId = entity.InvoiceTypeId;
        }
        private void Delete(object? sender, EventArgs e)
        {
            try
            {
                var entity = (Invoice)InvoiceBindingSource.Current;
                _unitOfWork.Invoice.Remove(entity);
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                _view.Message = "Bill type deleted successfully";
                LoadAllInvoiceList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete Bill type";
            }
        }
        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "InvoiceReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("Invoice", InvoiceList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        private void Return(object? sender, EventArgs e)
        {
            LoadAllInvoiceList();
        }
        private void CleanviewFields()
        {
            LoadAllInvoiceList();
            _view.InvoiceId = 0;
            _view.InvoiceName = "";
            _view.ShipmentId = 0;
            _view.InvoiceDate = DateTime.Now;
            _view.InvoiceDueDate = DateTime.Now;
            _view.InvoiceTypeId = 0;
        }
        
        private void LoadAllInvoiceList()
        {
            InvoiceList = _unitOfWork.Invoice.GetAll();
            InvoiceBindingSource.DataSource = InvoiceList;//Set data source.
        }
        private void LoadAllInvoiceTypeList()
        {
            InvoiceTypeList = _unitOfWork.InvoiceType.GetAll();
            InvoiceTypeBindingSource.DataSource = InvoiceTypeList;//Set data source.
        }
        private void LoadAllShipmentList()
        {
            ShipmentList = _unitOfWork.Shipment.GetAll();
            ShipmentBindingSource.DataSource = ShipmentList;//Set data source.
        }
    }
}
