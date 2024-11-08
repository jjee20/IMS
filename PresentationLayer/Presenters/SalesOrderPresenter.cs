using DomainLayer.Models;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using ServiceLayer.Services.IRepositories;

namespace PresentationLayer.Presenters
{
    public class SalesOrderPresenter
    {
        public ISalesOrderView _view;
        private IUnitOfWork _unitOfWork;
        private BindingSource SalesOrderBindingSource;
        private BindingSource SalesTypeBindingSource;
        private BindingSource BranchBindingSource;
        private BindingSource CustomerBindingSource;
        private BindingSource CurrencyBindingSource;
        private IEnumerable<SalesOrder> SalesOrderList;
        private IEnumerable<SalesType> SalesTypeList;
        private IEnumerable<Branch> BranchList;
        private IEnumerable<Customer> CustomerList;
        private IEnumerable<Currency> CurrencyList;
        public SalesOrderPresenter(ISalesOrderView view, IUnitOfWork unitOfWork) {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            SalesOrderBindingSource = new BindingSource();
            SalesTypeBindingSource = new BindingSource();
            BranchBindingSource = new BindingSource();
            CustomerBindingSource = new BindingSource();
            CurrencyBindingSource = new BindingSource();

            //Events
            _view.AddNewEvent += AddNew;
            _view.SaveEvent += Save;
            _view.SearchEvent += Search;
            _view.EditEvent += Edit;
            _view.DeleteEvent += Delete;
            _view.PrintEvent += Print;
            _view.RefreshEvent += Return;

            //Source Binding
            _view.SetSalesOrderListBindingSource(SalesOrderBindingSource);
            _view.SetSalesTypeListBindingSource(SalesTypeBindingSource);
            _view.SetBranchListBindingSource(BranchBindingSource);
            _view.SetCustomerListBindingSource(CustomerBindingSource);
            _view.SetCurrencyListBindingSource(CurrencyBindingSource);

            //Load

            LoadAllSalesOrderList();
            LoadAllSalesTypeList();
            LoadAllBranchList();
            LoadAllCustomerList();
            LoadAllCurrencyList();
        }

        private void AddNew(object? sender, EventArgs e)
        {
            _view.IsEdit = false;
            CleanviewFields();
        }
        private void Save(object? sender, EventArgs e)
        {
            var Entity = _unitOfWork.SalesOrder.Get(c => c.SalesOrderName == _view.SalesOrderName);
            if (Entity != null)
            {
                _view.Message = "SalesOrder type is already added.";
                return;
            }

            var model = new SalesOrder()
            {
                
                SalesOrderId = _view.SalesOrderId,
                SalesOrderName = _view.SalesOrderName,
                BranchId = _view.BranchId,
                CustomerId = _view.CustomerId,
                OrderDate = _view.OrderDate,
                DeliveryDate = _view.DeliveryDate,
                CurrencyId = _view.CurrencyId,
                CustomerRefNumber = _view.CustomerRefNumber,
                SalesTypeId = _view.SalesTypeId,
                Remarks = _view.Remarks,
                Amount = _view.Amount,
                SubTotal = _view.SubTotal,
                Discount = _view.Discount,
                Tax = _view.Tax,
                Freight = _view.Freight,
                Total = _view.Total,
                SalesOrderLines = _view.SalesOrderLines,
            };

            try
            {
                new ModelDataValidation().Validate(model);
                if (_view.IsEdit)//Edit model
                {
                    _unitOfWork.SalesOrder.Update(model);
                    _unitOfWork.Save();
                    _view.Message = "SalesOrder type edited successfuly";
                }
                else //Add new model
                {
                    _unitOfWork.SalesOrder.Add(model);
                    _unitOfWork.Save();
                    _view.Message = "SalesOrder type added sucessfully";
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
                SalesOrderList = _unitOfWork.SalesOrder.GetAll(c => c.SalesOrderName.Contains(_view.SearchValue));
                SalesOrderBindingSource.DataSource = SalesOrderList;
            }
            else
            {
                SalesOrderList = _unitOfWork.SalesOrder.GetAll();
                SalesOrderBindingSource.DataSource = SalesOrderList;
            }
        }
        private void Edit(object? sender, EventArgs e)
        {
            var entity = (SalesOrder)SalesOrderBindingSource.Current;
            _view.SalesOrderId = entity.SalesOrderId;
            _view.SalesOrderName = entity.SalesOrderName;
            _view.BranchId = entity.BranchId;
            _view.CustomerId = entity.CustomerId;
            _view.OrderDate = entity.OrderDate;
            _view.DeliveryDate = entity.DeliveryDate;
            _view.CurrencyId = entity.CurrencyId;
            _view.CustomerRefNumber = entity.CustomerRefNumber;
            _view.SalesTypeId = entity.SalesTypeId;
            _view.Remarks = entity.Remarks;
            _view.Amount = entity.Amount;
            _view.SubTotal = entity.SubTotal;
            _view.Discount = entity.Discount;
            _view.Tax = entity.Tax;
            _view.Freight = entity.Freight;
            _view.Total = entity.Total;
            _view.SalesOrderLines = entity.SalesOrderLines;
        }
        private void Delete(object? sender, EventArgs e)
        {
            try
            {
                var entity = (SalesOrder)SalesOrderBindingSource.Current;
                _unitOfWork.SalesOrder.Remove(entity);
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                _view.Message = "SalesOrder type deleted successfully";
                LoadAllSalesOrderList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete SalesOrder type";
            }
        }
        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "SalesOrderReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("SalesOrder", SalesOrderList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        private void Return(object? sender, EventArgs e)
        {
            LoadAllSalesOrderList();
        }
        private void CleanviewFields()
        {
            LoadAllSalesOrderList();
            _view.SalesOrderId = 0;
            _view.SalesOrderName = "";
            _view.BranchId = 0;
            _view.CustomerId = 0;
            _view.OrderDate = DateTime.Now;
            _view.DeliveryDate = DateTime.Now;
            _view.CurrencyId = 0;
            _view.CustomerRefNumber = "";
            _view.SalesTypeId = 0;
            _view.Remarks = "";
            _view.Amount = 0;
            _view.SubTotal = 0;
            _view.Discount = 0;
            _view.Tax = 0;
            _view.Freight = 0;
            _view.Total = 0;
            _view.SalesOrderLines = new List<SalesOrderLine>();
        }
        
        private void LoadAllSalesOrderList()
        {
            SalesOrderList = _unitOfWork.SalesOrder.GetAll();
            SalesOrderBindingSource.DataSource = SalesOrderList;//Set data source.
        }
        private void LoadAllSalesTypeList()
        {
            SalesTypeList = _unitOfWork.SalesType.GetAll();
            SalesTypeBindingSource.DataSource = SalesTypeList;//Set data source.
        }
        private void LoadAllBranchList()
        {
            BranchList = _unitOfWork.Branch.GetAll();
            BranchBindingSource.DataSource = BranchList;//Set data source.
        }
        private void LoadAllCustomerList()
        {
            CustomerList = _unitOfWork.Customer.GetAll();
            CustomerBindingSource.DataSource = CustomerList;//Set data source.
        }
        private void LoadAllCurrencyList()
        {
            CurrencyList = _unitOfWork.Currency.GetAll();
            CurrencyBindingSource.DataSource = CurrencyList;//Set data source.
        }
    }
}
