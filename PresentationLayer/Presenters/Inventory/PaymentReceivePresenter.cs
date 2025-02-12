using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels.Inventory;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using ServiceLayer.Services.IRepositories;

namespace PresentationLayer.Presenters
{
    public class PaymentReceivePresenter
    {
        public IPaymentReceiveView _view;
        private IUnitOfWork _unitOfWork;
        private BindingSource PaymentReceiveBindingSource;
        private BindingSource InvoiceBindingSource;
        private BindingSource PaymentTypeBindingSource;
        private IEnumerable<PaymentReceiveViewModel> PaymentReceiveList;
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

            //Load

            LoadAllPaymentReceiveList();
            LoadAllInvoiceList();
            LoadAllPaymentTypeList();
            //Source Binding
            _view.SetPaymentReceiveListBindingSource(PaymentReceiveBindingSource);
            _view.SetInvoiceListBindingSource(InvoiceBindingSource);
            _view.SetPaymentTypeListBindingSource(PaymentTypeBindingSource);

        }

        private void AddNew(object? sender, EventArgs e)
        {
            _view.IsEdit = false;
            CleanviewFields();
        }
        private void Save(object? sender, EventArgs e)
        {
            var model = _unitOfWork.PaymentReceive.Get(c => c.PaymentReceiveId == _view.PaymentReceiveId, tracked: true);
            if (model == null) model = new PaymentReceive();
            else _unitOfWork.PaymentReceive.Detach(model);

            model.PaymentReceiveId = _view.PaymentReceiveId;
            model.PaymentReceiveName = _view.PaymentReceiveName;
            model.InvoiceId = _view.InvoiceId;
            model.PaymentDate = _view.PaymentDate;
            model.PaymentTypeId = _view.PaymentTypeId;
            model.PaymentAmount = _view.PaymentAmount;
            model.IsFullPayment = _view.IsFullPayment;

            try
            {
                new ModelDataValidation().Validate(model);
                if (_view.IsEdit)//Edit model
                {
                    _unitOfWork.PaymentReceive.Update(model);
                    _view.Message = "Payment Receive edited successfully";
                }
                else //Add new model
                {
                    _unitOfWork.PaymentReceive.Add(model);
                    _view.Message = "Payment Receive added successfully";
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
                PaymentReceiveList = Program.Mapper.Map<IEnumerable<PaymentReceiveViewModel>>(_unitOfWork.PaymentReceive.GetAll(c => c.PaymentReceiveName.Contains(_view.SearchValue)));
                PaymentReceiveBindingSource.DataSource = PaymentReceiveList;
            }
            else
            {
                LoadAllPaymentReceiveList();
            }
        }
        private void Edit(object? sender, EventArgs e)
        {
            _view.IsEdit = true;
            var paymentReceive = (PaymentReceiveViewModel)PaymentReceiveBindingSource.Current;
            var entity = _unitOfWork.PaymentReceive.Get(c => c.PaymentReceiveId == paymentReceive.PaymentReceiveId);
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
                var paymentReceive = (PaymentReceiveViewModel)PaymentReceiveBindingSource.Current;
                var entity = _unitOfWork.PaymentReceive.Get(c => c.PaymentReceiveId == paymentReceive.PaymentReceiveId);
                _unitOfWork.PaymentReceive.Remove(entity);
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                _view.Message = "Payment Receive deleted successfully";
                LoadAllPaymentReceiveList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete Payment Receive";
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
            PaymentReceiveList = Program.Mapper.Map<IEnumerable<PaymentReceiveViewModel>>(_unitOfWork.PaymentReceive.GetAll());
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
