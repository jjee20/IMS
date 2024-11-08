using DomainLayer.Models;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using ServiceLayer.Services.IRepositories;
using static ServiceLayer.Services.CommonServices.MainMenu;

namespace PresentationLayer.Presenters
{
    public class PaymentReceivePresenter
    {
        public IPaymentReceiveView _view;
        private IUnitOfWork _unitOfWork;
        private BindingSource PaymentReceiveBindingSource;
        private BindingSource InvoiceBindingSource;
        private BindingSource PaymentTypeBindingSource;
        private IEnumerable<PaymentReceive> PaymentReceiveList;
        private IEnumerable<Invoice> InvoiceList;
        private IEnumerable<PaymentType> PaymentTypeList;
        public PaymentReceivePresenter(IPaymentReceiveView view, IUnitOfWork unitOfWork) {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            PaymentReceiveBindingSource = new BindingSource();
            InvoiceBindingSource = new BindingSource();
            PaymentTypeBindingSource = new BindingSource();

            //Events
            _view.AddNewEvent += AddNew;
            _view.SaveEvent += Save;
            _view.SearchEvent += Search;
            _view.EditEvent += Edit;
            _view.DeleteEvent += Delete;
            _view.PrintEvent += Print;
            _view.RefreshEvent += Return;

            //Source Binding
            _view.SetPaymentReceiveListBindingSource(PaymentReceiveBindingSource);
            _view.SetInvoiceListBindingSource(InvoiceBindingSource);
            _view.SetPaymentTypeListBindingSource(PaymentTypeBindingSource);

            //Load

            LoadAllPaymentReceiveList();
            LoadAllInvoiceList();
            LoadAllPaymentTypeList();
        }

        private void AddNew(object? sender, EventArgs e)
        {
            _view.IsEdit = false;
            CleanviewFields();
        }
        private void Save(object? sender, EventArgs e)
        {
            var Entity = _unitOfWork.PaymentReceive.Get(c => c.PaymentReceiveName == _view.PaymentReceiveName);
            if (Entity != null)
            {
                _view.Message = "PaymentReceive type is already added.";
                return;
            }

            var model = new PaymentReceive()
            {
                
                PaymentReceiveId = _view.PaymentReceiveId,
                PaymentReceiveName = _view.PaymentReceiveName,
                InvoiceId = _view.InvoiceId,
                PaymentDate = _view.PaymentDate,
                PaymentTypeId = _view.PaymentTypeId,
                PaymentAmount = _view.PaymentAmount,
                IsFullPayment = _view.IsFullPayment
            };

            try
            {
                new ModelDataValidation().Validate(model);
                if (_view.IsEdit)//Edit model
                {
                    _unitOfWork.PaymentReceive.Update(model);
                    _unitOfWork.Save();
                    _view.Message = "PaymentReceive type edited successfuly";
                }
                else //Add new model
                {
                    _unitOfWork.PaymentReceive.Add(model);
                    _unitOfWork.Save();
                    _view.Message = "PaymentReceive type added sucessfully";
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
                PaymentReceiveList = _unitOfWork.PaymentReceive.GetAll(c => c.PaymentReceiveName.Contains(_view.SearchValue));
                PaymentReceiveBindingSource.DataSource = PaymentReceiveList;
            }
            else
            {
                PaymentReceiveList = _unitOfWork.PaymentReceive.GetAll();
                PaymentReceiveBindingSource.DataSource = PaymentReceiveList;
            }
        }
        private void Edit(object? sender, EventArgs e)
        {
            var entity = (PaymentReceive)PaymentReceiveBindingSource.Current;
            _view.PaymentReceiveId = entity.PaymentReceiveId;
            _view.PaymentReceiveName = entity.PaymentReceiveName;
            _view.InvoiceId = entity.InvoiceId;
            _view.PaymentDate = entity.PaymentDate;
            _view.PaymentTypeId = entity.PaymentTypeId;
            _view.PaymentAmount = entity.PaymentAmount;
            _view.IsFullPayment = entity.IsFullPayment;
        }
        private void Delete(object? sender, EventArgs e)
        {
            try
            {
                var entity = (PaymentReceive)PaymentReceiveBindingSource.Current;
                _unitOfWork.PaymentReceive.Remove(entity);
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                _view.Message = "PaymentReceive type deleted successfully";
                LoadAllPaymentReceiveList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete PaymentReceive type";
            }
        }
        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "PaymentReceiveReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("PaymentReceive", PaymentReceiveList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        private void Return(object? sender, EventArgs e)
        {
            LoadAllPaymentReceiveList();
        }
        private void CleanviewFields()
        {
            LoadAllPaymentReceiveList();
            _view.PaymentReceiveId = 0;
            _view.PaymentReceiveName = "";
            _view.InvoiceId = 0;
            _view.PaymentDate = DateTime.Now;;
            _view.PaymentTypeId = 0;
            _view.PaymentAmount = 0;
            _view.IsFullPayment = true;
        }
        
        private void LoadAllPaymentReceiveList()
        {
            PaymentReceiveList = _unitOfWork.PaymentReceive.GetAll();
            PaymentReceiveBindingSource.DataSource = PaymentReceiveList;//Set data source.
        }
        private void LoadAllInvoiceList()
        {
            InvoiceList = _unitOfWork.Invoice.GetAll();
            InvoiceBindingSource.DataSource = InvoiceList;//Set data source.
        }
        private void LoadAllPaymentTypeList()
        {
            PaymentTypeList = _unitOfWork.PaymentType.GetAll();
            PaymentTypeBindingSource.DataSource = PaymentTypeList;//Set data source.
        }
    }
}
