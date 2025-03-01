using DomainLayer.Models;
using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels.Inventory;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using ServiceLayer.Services.IRepositories.IInventory;

namespace PresentationLayer.Presenters
{
    public class PaymentVoucherPresenter
    {
        public IPaymentVoucherView _view;
        private IUnitOfWork _unitOfWork;
        private BindingSource PaymentVoucherBindingSource;
        private BindingSource BillBindingSource;
        private BindingSource PaymentTypeBindingSource;
        private BindingSource CashBankBindingSource;
        private IEnumerable<PaymentVoucherViewModel> PaymentVoucherList;
        private IEnumerable<Bill> BillList;
        private IEnumerable<PaymentType> PaymentTypeList;
        private IEnumerable<CashBank> CashBankList;
        public PaymentVoucherPresenter(IPaymentVoucherView view, IUnitOfWork unitOfWork) {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            PaymentVoucherBindingSource = new BindingSource();
            BillBindingSource = new BindingSource();
            PaymentTypeBindingSource = new BindingSource();
            CashBankBindingSource = new BindingSource();

            //Events
            _view.AddNewEvent += AddNew;
            _view.SaveEvent += Save;
            _view.SearchEvent += Search;
            _view.EditEvent += Edit;
            _view.DeleteEvent += Delete;
            _view.PrintEvent += Print;
            _view.RefreshEvent += Return;

            //Load

            LoadAllPaymentVoucherList();
            LoadAllBillList();
            LoadAllPaymentTypeList();
            LoadAllCashBankList();
            //Source Binding
            _view.SetPaymentVoucherListBindingSource(PaymentVoucherBindingSource);
            _view.SetBillListBindingSource(BillBindingSource);
            _view.SetPaymentTypeListBindingSource(PaymentTypeBindingSource);
            _view.SetCashBankListBindingSource(CashBankBindingSource);

        }

        private void AddNew(object? sender, EventArgs e)
        {
            _view.IsEdit = false;
            CleanviewFields();
        }
        private void Save(object? sender, EventArgs e)
        {
            var model = _unitOfWork.PaymentVoucher.Get(c => c.PaymentVoucherId == _view.PaymentVoucherId, tracked: true);
            if (model == null) model = new PaymentVoucher();
            else _unitOfWork.PaymentVoucher.Detach(model);

            model.PaymentVoucherId = _view.PaymentVoucherId;
            model.PaymentVoucherName = _view.PaymentVoucherName;
            model.BillId = _view.BillId;
            model.PaymentDate = _view.PaymentDate;
            model.PaymentTypeId = _view.PaymentTypeId;
            model.PaymentAmount = _view.PaymentAmount;
            model.CashBankId = _view.CashBankId;
            model.IsFullPayment = _view.IsFullPayment;

            try
            {
                new ModelDataValidation().Validate(model);
                if (_view.IsEdit)//Edit model
                {
                    _unitOfWork.PaymentVoucher.Update(model);
                    _view.Message = "Payment Voucher edited successfully";
                }
                else //Add new model
                {
                    _unitOfWork.PaymentVoucher.Add(model);
                    _view.Message = "Payment Voucher added successfully";
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
                PaymentVoucherList = Program.Mapper.Map<IEnumerable<PaymentVoucherViewModel>>(_unitOfWork.PaymentVoucher.GetAll(c => c.PaymentVoucherName.Contains(_view.SearchValue), includeProperties: "Bill,PaymentType,CashBank"));
                PaymentVoucherBindingSource.DataSource = PaymentVoucherList;
            }
            else
            {
                LoadAllPaymentVoucherList();
            }
        }
        private void Edit(object? sender, EventArgs e)
        {
            _view.IsEdit = true;
            var paymentVoucher = (PaymentVoucherViewModel)PaymentVoucherBindingSource.Current;
            var entity = _unitOfWork.PaymentVoucher.Get(c => c.PaymentVoucherId == paymentVoucher.PaymentVoucherId);
            _view.PaymentVoucherId = entity.PaymentVoucherId;
            _view.PaymentVoucherName = entity.PaymentVoucherName;
            _view.BillId = entity.BillId;
            _view.PaymentDate = entity.PaymentDate;
            _view.PaymentTypeId = entity.PaymentTypeId;
            _view.PaymentAmount = entity.PaymentAmount;
            _view.CashBankId = entity.CashBankId;
            _view.IsFullPayment = entity.IsFullPayment;
        }
        private void Delete(object? sender, EventArgs e)
        {
            try
            {
                var paymentVoucher = (PaymentVoucherViewModel)PaymentVoucherBindingSource.Current;
                var entity = _unitOfWork.PaymentVoucher.Get(c => c.PaymentVoucherId == paymentVoucher.PaymentVoucherId);
                _unitOfWork.PaymentVoucher.Remove(entity);
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                _view.Message = "Payment Voucher deleted successfully";
                LoadAllPaymentVoucherList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete Payment Voucher";
            }
        }
        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "PaymentVoucherReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports", "Inventory");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("PaymentVoucher", PaymentVoucherList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        private void Return(object? sender, EventArgs e)
        {
            LoadAllPaymentVoucherList();
        }
        private void CleanviewFields()
        {
            LoadAllPaymentVoucherList();
            _view.PaymentVoucherId = 0;
            _view.PaymentVoucherName = "";
            _view.BillId = 0;
            _view.PaymentDate = DateTime.Now;
            _view.PaymentTypeId = 0;
            _view.PaymentAmount = 0;
            _view.CashBankId = 0;
            _view.IsFullPayment = true;
        }
        
        private void LoadAllPaymentVoucherList()
        {
            PaymentVoucherList = Program.Mapper.Map<IEnumerable<PaymentVoucherViewModel>>(_unitOfWork.PaymentVoucher.GetAll(includeProperties: "Bill,PaymentType,CashBank"));
            PaymentVoucherBindingSource.DataSource = PaymentVoucherList;//Set data source.
        }
        private void LoadAllBillList()
        {
            BillList = _unitOfWork.Bill.GetAll();
            BillBindingSource.DataSource = BillList;//Set data source.
        }
        private void LoadAllPaymentTypeList()
        {
            PaymentTypeList = _unitOfWork.PaymentType.GetAll();
            PaymentTypeBindingSource.DataSource = PaymentTypeList;//Set data source.
        }
        private void LoadAllCashBankList()
        {
            CashBankList = _unitOfWork.CashBank.GetAll();
            CashBankBindingSource.DataSource = CashBankList;//Set data source.
        }
    }
}
