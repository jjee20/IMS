using DomainLayer.Models;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using ServiceLayer.Services.IRepositories;

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
        private IEnumerable<PaymentVoucher> PaymentVoucherList;
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

            //Source Binding
            _view.SetPaymentVoucherListBindingSource(PaymentVoucherBindingSource);
            _view.SetBillListBindingSource(BillBindingSource);
            _view.SetPaymentTypeListBindingSource(PaymentTypeBindingSource);
            _view.SetCashBankListBindingSource(CashBankBindingSource);

            //Load

            LoadAllPaymentVoucherList();
            LoadAllBillList();
            LoadAllPaymentTypeList();
            LoadAllCashBankList();
        }

        private void AddNew(object? sender, EventArgs e)
        {
            _view.IsEdit = false;
            CleanviewFields();
        }
        private void Save(object? sender, EventArgs e)
        {
            var Entity = _unitOfWork.PaymentVoucher.Get(c => c.PaymentVoucherName == _view.PaymentVoucherName);
            if (Entity != null)
            {
                _view.Message = "PaymentVoucher type is already added.";
                return;
            }

            var model = new PaymentVoucher()
            {
                
                PaymentVoucherId = _view.PaymentVoucherId,
                PaymentVoucherName = _view.PaymentVoucherName,
                BillId = _view.BillId,
                PaymentDate = _view.PaymentDate,
                PaymentTypeId = _view.PaymentTypeId,
                PaymentAmount = _view.PaymentAmount,
                CashBankId = _view.CashBankId,
                IsFullPayment = _view.IsFullPayment,
            };

            try
            {
                new ModelDataValidation().Validate(model);
                if (_view.IsEdit)//Edit model
                {
                    _unitOfWork.PaymentVoucher.Update(model);
                    _unitOfWork.Save();
                    _view.Message = "PaymentVoucher type edited successfuly";
                }
                else //Add new model
                {
                    _unitOfWork.PaymentVoucher.Add(model);
                    _unitOfWork.Save();
                    _view.Message = "PaymentVoucher type added sucessfully";
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
                PaymentVoucherList = _unitOfWork.PaymentVoucher.GetAll(c => c.PaymentVoucherName.Contains(_view.SearchValue));
                PaymentVoucherBindingSource.DataSource = PaymentVoucherList;
            }
            else
            {
                PaymentVoucherList = _unitOfWork.PaymentVoucher.GetAll();
                PaymentVoucherBindingSource.DataSource = PaymentVoucherList;
            }
        }
        private void Edit(object? sender, EventArgs e)
        {
            var entity = (PaymentVoucher)PaymentVoucherBindingSource.Current;
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
                var entity = (PaymentVoucher)PaymentVoucherBindingSource.Current;
                _unitOfWork.PaymentVoucher.Remove(entity);
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                _view.Message = "PaymentVoucher type deleted successfully";
                LoadAllPaymentVoucherList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete PaymentVoucher type";
            }
        }
        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "PaymentVoucherReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports");
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
            PaymentVoucherList = _unitOfWork.PaymentVoucher.GetAll();
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
