using DomainLayer.Models;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using ServiceLayer.Services.IRepositories;

namespace PresentationLayer.Presenters
{
    public class PaymentTypePresenter
    {
        public IPaymentTypeView _view;
        private IUnitOfWork _unitOfWork;
        private BindingSource PaymentTypeBindingSource;
        private IEnumerable<PaymentType> PaymentTypeList;
        public PaymentTypePresenter(IPaymentTypeView view, IUnitOfWork unitOfWork) {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
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
            _view.SetPaymentTypeListBindingSource(PaymentTypeBindingSource);

            //Load

            LoadAllPaymentTypeList();
        }

        private void AddNew(object? sender, EventArgs e)
        {
            _view.IsEdit = false;
            CleanviewFields();
        }
        private void Save(object? sender, EventArgs e)
        {
            var Entity = _unitOfWork.PaymentType.Get(c => c.PaymentTypeName == _view.PaymentTypeName);
            if (Entity != null)
            {
                _view.Message = "Payment type is already added.";
                return;
            }

            var model = new PaymentType()
            {
                
                PaymentTypeId = _view.PaymentTypeId,
                PaymentTypeName = _view.PaymentTypeName,
                Description = _view.Description,
            };

            try
            {
                new ModelDataValidation().Validate(model);
                if (_view.IsEdit)//Edit model
                {
                    _unitOfWork.PaymentType.Update(model);
                    _unitOfWork.Save();
                    _view.Message = "Payment type edited successfuly";
                }
                else //Add new model
                {
                    _unitOfWork.PaymentType.Add(model);
                    _unitOfWork.Save();
                    _view.Message = "Payment type added sucessfully";
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
                PaymentTypeList = _unitOfWork.PaymentType.GetAll(c => c.PaymentTypeName.Contains(_view.SearchValue));
                PaymentTypeBindingSource.DataSource = PaymentTypeList;
            }
            else
            {
                PaymentTypeList = _unitOfWork.PaymentType.GetAll();
                PaymentTypeBindingSource.DataSource = PaymentTypeList;
            }
        }
        private void Edit(object? sender, EventArgs e)
        {
            var entity = (PaymentType)PaymentTypeBindingSource.Current;
            _view.PaymentTypeId = entity.PaymentTypeId;
            _view.PaymentTypeName = entity.PaymentTypeName;
            _view.Description = entity.Description;
        }
        private void Delete(object? sender, EventArgs e)
        {
            try
            {
                var entity = (PaymentType)PaymentTypeBindingSource.Current;
                _unitOfWork.PaymentType.Remove(entity);
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                _view.Message = "Payment type deleted successfully";
                LoadAllPaymentTypeList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete Payment type";
            }
        }
        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "PaymentTypeReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("PaymentType", PaymentTypeList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        private void Return(object? sender, EventArgs e)
        {
            LoadAllPaymentTypeList();
        }
        private void CleanviewFields()
        {
            LoadAllPaymentTypeList();
            _view.PaymentTypeId = 0;
            _view.PaymentTypeName = "";
            _view.Description = "";
        }
        
        private void LoadAllPaymentTypeList()
        {
            PaymentTypeList = _unitOfWork.PaymentType.GetAll();
            PaymentTypeBindingSource.DataSource = PaymentTypeList;//Set data source.
        }
    }
}
