using DomainLayer.Models.Inventory;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using ServiceLayer.Services.IRepositories.IInventory;

namespace PresentationLayer.Presenters
{
    public class GoodsReceivedNotePresenter
    {
        public IGoodsReceivedNoteView _view;
        private IUnitOfWork _unitOfWork;
        private BindingSource GoodsReceivedNoteBindingSource;
        private BindingSource PurchaseOrderBindingSource;
        private BindingSource WarehouseBindingSource;
        private IEnumerable<GoodsReceivedNote> GoodsReceivedNoteList;
        private IEnumerable<PurchaseOrder> PurchaseOrderList;
        private IEnumerable<Warehouse> WarehouseList;
       
        public GoodsReceivedNotePresenter(IGoodsReceivedNoteView view, IUnitOfWork unitOfWork) {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            GoodsReceivedNoteBindingSource = new BindingSource();
            PurchaseOrderBindingSource = new BindingSource();
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

            LoadAllGoodsReceivedNoteList();
            LoadAllPurchaseOrderList();
            LoadAllWarehouseList();

            //Source Binding
            _view.SetGoodsReceivedNoteListBindingSource(GoodsReceivedNoteBindingSource);
            _view.SetPurchaseOrderListBindingSource(PurchaseOrderBindingSource);
            _view.SetWarehouseListBindingSource(WarehouseBindingSource);
        }

        private void AddNew(object? sender, EventArgs e)
        {
            _view.IsEdit = false;
            CleanviewFields();
        }
        private void Save(object? sender, EventArgs e)
        {
            var model = _unitOfWork.GoodsReceivedNote.Get(c => c.GoodsReceivedNoteId == _view.GoodsReceivedNoteId, tracked: true);
            if (model == null) model = new GoodsReceivedNote();
            else _unitOfWork.GoodsReceivedNote.Detach(model);

            model.GoodsReceivedNoteId = _view.GoodsReceivedNoteId;
            model.GoodsReceivedNoteName = _view.GoodsReceivedNoteName;
            model.PurchaseOrderId = _view.PurchaseOrderId;
            model.GRNDate = _view.GRNDate;
            model.VendorDONumber = _view.VendorDONumber;
            model.VendorInvoiceNumber = _view.VendorInvoiceNumber;
            model.WarehouseId = _view.WarehouseId;
            model.IsFullReceive = _view.IsFullReceive;

            try
            {
                new ModelDataValidation().Validate(model);
                if (_view.IsEdit)//Edit model
                {
                    _unitOfWork.GoodsReceivedNote.Update(model);
                    _view.Message = "Goods Received Note edited successfully";
                }
                else //Add new model
                {
                    _unitOfWork.GoodsReceivedNote.Add(model);
                    _view.Message = "Goods Received Note added successfully";
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
                GoodsReceivedNoteList = _unitOfWork.GoodsReceivedNote.GetAll(c => c.GoodsReceivedNoteName.Contains(_view.SearchValue));
                GoodsReceivedNoteBindingSource.DataSource = GoodsReceivedNoteList;
            }
            else
            {
                LoadAllGoodsReceivedNoteList();
            }
        }
        private void Edit(object? sender, EventArgs e)
        {
            _view.IsEdit = true;
            var entity = (GoodsReceivedNote)GoodsReceivedNoteBindingSource.Current;
            _view.GoodsReceivedNoteId = entity.GoodsReceivedNoteId;
            _view.GoodsReceivedNoteName = entity.GoodsReceivedNoteName;
            _view.PurchaseOrderId = entity.PurchaseOrderId;
            _view.GRNDate = entity.GRNDate;
            _view.VendorDONumber = entity.VendorDONumber;
            _view.VendorInvoiceNumber = entity.VendorInvoiceNumber;
            _view.WarehouseId = entity.WarehouseId;
            _view.IsFullReceive = entity.IsFullReceive;
        }
        private void Delete(object? sender, EventArgs e)
        {
            try
            {
                var entity = (GoodsReceivedNote)GoodsReceivedNoteBindingSource.Current;
                _unitOfWork.GoodsReceivedNote.Remove(entity);
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                _view.Message = "Goods Received Note deleted successfully";
                LoadAllGoodsReceivedNoteList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete Goods Received Note";
            }
        }
        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "GoodsReceivedNoteReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("GoodsReceivedNote", GoodsReceivedNoteList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        private void Return(object? sender, EventArgs e)
        {
            LoadAllGoodsReceivedNoteList();
        }
        private void CleanviewFields()
        {
            LoadAllGoodsReceivedNoteList();
            _view.GoodsReceivedNoteId = 0;
            _view.GoodsReceivedNoteName = "";
            _view.PurchaseOrderId = 0;
            _view.GRNDate = DateTime.Now;
            _view.VendorDONumber = "";
            _view.VendorInvoiceNumber = "";
            _view.WarehouseId = 0;
            _view.IsFullReceive = false;
        }
        
        private void LoadAllGoodsReceivedNoteList()
        {
            GoodsReceivedNoteList = _unitOfWork.GoodsReceivedNote.GetAll();
            GoodsReceivedNoteBindingSource.DataSource = GoodsReceivedNoteList;//Set data source.
        }
        private void LoadAllPurchaseOrderList()
        {
            PurchaseOrderList = _unitOfWork.PurchaseOrder.GetAll();
            PurchaseOrderBindingSource.DataSource = PurchaseOrderList;//Set data source.
        }
        private void LoadAllWarehouseList()
        {
            WarehouseList = _unitOfWork.Warehouse.GetAll();
            WarehouseBindingSource.DataSource = WarehouseList;//Set data source.
        }
    }
}
