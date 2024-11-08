using DomainLayer.Models;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using ServiceLayer.Services.IRepositories;

namespace PresentationLayer.Presenters
{
    public class PurchaseOrderPresenter
    {
        public IPurchaseOrderView _view;
        private IUnitOfWork _unitOfWork;
        private BindingSource PurchaseOrderBindingSource;
        private BindingSource PurchaseTypeBindingSource;
        private BindingSource BranchBindingSource;
        private BindingSource VendorBindingSource;
        private BindingSource CurrencyBindingSource;
        private IEnumerable<PurchaseOrder> PurchaseOrderList;
        private IEnumerable<PurchaseType> PurchaseTypeList;
        private IEnumerable<Branch> BranchList;
        private IEnumerable<Vendor> VendorList;
        private IEnumerable<Currency> CurrencyList;
        public PurchaseOrderPresenter(IPurchaseOrderView view, IUnitOfWork unitOfWork) {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            PurchaseOrderBindingSource = new BindingSource();
            PurchaseTypeBindingSource = new BindingSource();
            BranchBindingSource = new BindingSource();
            VendorBindingSource = new BindingSource();
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
            _view.SetPurchaseOrderListBindingSource(PurchaseOrderBindingSource);
            _view.SetPurchaseTypeListBindingSource(PurchaseTypeBindingSource);
            _view.SetBranchListBindingSource(BranchBindingSource);
            _view.SetVendorListBindingSource(VendorBindingSource);
            _view.SetCurrencyListBindingSource(CurrencyBindingSource);

            //Load

            LoadAllPurchaseOrderList();
            LoadAllPurchaseTypeList();
            LoadAllBranchList();
            LoadAllVendorList();
            LoadAllCurrencyList();
        }

        private void AddNew(object? sender, EventArgs e)
        {
            _view.IsEdit = false;
            CleanviewFields();
        }
        private void Save(object? sender, EventArgs e)
        {
            var Entity = _unitOfWork.PurchaseOrder.Get(c => c.PurchaseOrderName == _view.PurchaseOrderName);
            if (Entity != null)
            {
                _view.Message = "PurchaseOrder type is already added.";
                return;
            }

            var model = new PurchaseOrder()
            {
                
                PurchaseOrderId = _view.PurchaseOrderId,
                PurchaseOrderName = _view.PurchaseOrderName,
                BranchId = _view.BranchId,
                VendorId = _view.VendorId,
                OrderDate = _view.OrderDate,
                DeliveryDate = _view.DeliveryDate,
                CurrencyId = _view.CurrencyId,
                PurchaseTypeId = _view.PurchaseTypeId,
                Remarks = _view.Remarks,
                Amount = _view.Amount,
                SubTotal = _view.SubTotal,
                Discount = _view.Discount,
                Tax = _view.Tax,
                Freight = _view.Freight,
                Total = _view.Total,
                PurchaseOrderLines = _view.PurchaseOrderLines,
            };

            try
            {
                new ModelDataValidation().Validate(model);
                if (_view.IsEdit)//Edit model
                {
                    _unitOfWork.PurchaseOrder.Update(model);
                    _unitOfWork.Save();
                    _view.Message = "PurchaseOrder type edited successfuly";
                }
                else //Add new model
                {
                    _unitOfWork.PurchaseOrder.Add(model);
                    _unitOfWork.Save();
                    _view.Message = "PurchaseOrder type added sucessfully";
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
                PurchaseOrderList = _unitOfWork.PurchaseOrder.GetAll(c => c.PurchaseOrderName.Contains(_view.SearchValue));
                PurchaseOrderBindingSource.DataSource = PurchaseOrderList;
            }
            else
            {
                PurchaseOrderList = _unitOfWork.PurchaseOrder.GetAll();
                PurchaseOrderBindingSource.DataSource = PurchaseOrderList;
            }
        }
        private void Edit(object? sender, EventArgs e)
        {
            var entity = (PurchaseOrder)PurchaseOrderBindingSource.Current;
            _view.PurchaseOrderId = entity.PurchaseOrderId;
            _view.PurchaseOrderName = entity.PurchaseOrderName;
            _view.BranchId = entity.BranchId;
            _view.VendorId = entity.VendorId;
            _view.OrderDate = entity.OrderDate;
            _view.DeliveryDate = entity.DeliveryDate;
            _view.CurrencyId = entity.CurrencyId;
            _view.PurchaseTypeId = entity.PurchaseTypeId;
            _view.Remarks = entity.Remarks;
            _view.Amount = entity.Amount;
            _view.SubTotal = entity.SubTotal;
            _view.Discount = entity.Discount;
            _view.Tax = entity.Tax;
            _view.Freight = entity.Freight;
            _view.Total = entity.Total;
            _view.PurchaseOrderLines = entity.PurchaseOrderLines;
        }
        private void Delete(object? sender, EventArgs e)
        {
            try
            {
                var entity = (PurchaseOrder)PurchaseOrderBindingSource.Current;
                _unitOfWork.PurchaseOrder.Remove(entity);
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                _view.Message = "PurchaseOrder type deleted successfully";
                LoadAllPurchaseOrderList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete PurchaseOrder type";
            }
        }
        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "PurchaseOrderReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("PurchaseOrder", PurchaseOrderList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        private void Return(object? sender, EventArgs e)
        {
            LoadAllPurchaseOrderList();
        }
        private void CleanviewFields()
        {
            LoadAllPurchaseOrderList();
            _view.PurchaseOrderId = 0;
            _view.PurchaseOrderName = "";
            _view.BranchId = 0;
            _view.VendorId = 0;
            _view.OrderDate = DateTime.Now;
            _view.DeliveryDate = DateTime.Now;
            _view.CurrencyId = 0;
            _view.PurchaseTypeId = 0;
            _view.Remarks = "";
            _view.Amount = 0;
            _view.SubTotal = 0;
            _view.Discount = 0;
            _view.Tax = 0;
            _view.Freight = 0;
            _view.Total = 0;
            _view.PurchaseOrderLines = new List<PurchaseOrderLine>();
        }
        
        private void LoadAllPurchaseOrderList()
        {
            PurchaseOrderList = _unitOfWork.PurchaseOrder.GetAll();
            PurchaseOrderBindingSource.DataSource = PurchaseOrderList;//Set data source.
        }
        private void LoadAllPurchaseTypeList()
        {
            PurchaseTypeList = _unitOfWork.PurchaseType.GetAll();
            PurchaseTypeBindingSource.DataSource = PurchaseTypeList;//Set data source.
        }
        private void LoadAllBranchList()
        {
            BranchList = _unitOfWork.Branch.GetAll();
            BranchBindingSource.DataSource = BranchList;//Set data source.
        }
        private void LoadAllVendorList()
        {
            VendorList = _unitOfWork.Vendor.GetAll();
            VendorBindingSource.DataSource = VendorList;//Set data source.
        }
        private void LoadAllCurrencyList()
        {
            CurrencyList = _unitOfWork.Currency.GetAll();
            CurrencyBindingSource.DataSource = CurrencyList;//Set data source.
        }
    }
}
