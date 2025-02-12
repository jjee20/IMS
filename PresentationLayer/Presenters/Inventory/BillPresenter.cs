using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels.Inventory;
using InfastructureLayer.DataAccess.Repositories;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using ServiceLayer.Services.IRepositories;

namespace PresentationLayer.Presenters
{
    public class BillPresenter
    {
        public IBillView _view;
        private IUnitOfWork _unitOfWork;
        private BindingSource BillBindingSource;
        private BindingSource BillTypeBindingSource;
        private BindingSource GoodsReceivedNoteBindingSource;
        private IEnumerable<BillViewModel> BillList;
        private IEnumerable<BillType> BillTypeList;
        private IEnumerable<GoodsReceivedNote> GoodsReceivedNoteList;
        public BillPresenter(IBillView view, IUnitOfWork unitOfWork) {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            BillBindingSource = new BindingSource();
            BillTypeBindingSource = new BindingSource();
            GoodsReceivedNoteBindingSource = new BindingSource();

            //Events
            _view.AddNewEvent += AddNew;
            _view.SaveEvent += Save;
            _view.SearchEvent += Search;
            _view.EditEvent += Edit;
            _view.DeleteEvent += Delete;
            _view.PrintEvent += Print;
            _view.RefreshEvent += Return;

            //Load
            LoadAllBillList();
            LoadAllBillTypeList();
            LoadAllGoodsReceivedNoteList();

            //Source Binding
            _view.SetBillListBindingSource(BillBindingSource);
            _view.SetBillTypeListBindingSource(BillTypeBindingSource);
            _view.SetGoodsReceivedNoteListBindingSource(GoodsReceivedNoteBindingSource);
        }

        private void AddNew(object? sender, EventArgs e)
        {
            _view.IsEdit = false;
            CleanviewFields();
        }
        private void Save(object? sender, EventArgs e)
        {
            var model = _unitOfWork.Bill.Get(c => c.BillId == _view.BillId, tracked: true);
            if (model == null) model = new Bill();
            else _unitOfWork.Bill.Detach(model);

            model.BillId = _view.BillId;
            model.BillName = _view.BillName;
            model.GoodsReceivedNoteId = _view.GoodsReceivedNoteId;
            model.VendorDONumber = _view.VendorDONumber;
            model.VendorInvoiceNumber = _view.VendorInvoiceNumber;
            model.BillDate = _view.BillDate;
            model.BillDueDate = _view.BillDueDate;
            model.BillTypeId = _view.BillTypeId;

            try
            {
                new ModelDataValidation().Validate(model);
                if (_view.IsEdit)//Edit model
                {
                    _unitOfWork.Bill.Update(model);
                    _view.Message = "Bill edited successfully";
                }
                else //Add new model
                {
                    _unitOfWork.Bill.Add(model);
                    _view.Message = "Bill added successfully";
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
            if (!emptyValue)
            {
                BillList = Program.Mapper.Map<IEnumerable<BillViewModel>>(_unitOfWork.Bill.GetAll(c => c.BillName.Contains(_view.SearchValue), includeProperties: "GoodsReceivedNote,BillType"));
                BillBindingSource.DataSource = BillList;
            }
            else
            {
                LoadAllBillList();
            }
        }
        private void Edit(object? sender, EventArgs e)
        {
            _view.IsEdit = true;
            var bill = (BillViewModel)BillBindingSource.Current;
            var entity = _unitOfWork.Bill.Get(c => c.BillId == bill.BillId);
            _view.BillId = entity.BillId;
            _view.BillName = entity.BillName;
            _view.GoodsReceivedNoteId = entity.GoodsReceivedNoteId;
            _view.VendorDONumber = entity.VendorDONumber;
            _view.VendorInvoiceNumber = entity.VendorInvoiceNumber;
            _view.BillDate = entity.BillDate;
            _view.BillDueDate = entity.BillDueDate;
            _view.BillTypeId = entity.BillTypeId;
        }
        private void Delete(object? sender, EventArgs e)
        {
            try
            {
                var bill = (BillViewModel)BillBindingSource.Current;
                var entity = _unitOfWork.Bill.Get(c => c.BillId == bill.BillId);
                _unitOfWork.Bill.Remove(entity);
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                _view.Message = "Bill deleted successfully";
                LoadAllBillList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete Bill";
            }
        }
        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "BillReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("Bill", BillList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        private void Return(object? sender, EventArgs e)
        {
            LoadAllBillList();
        }
        private void CleanviewFields()
        {
            LoadAllBillList();
            _view.BillId = 0;
            _view.BillName = "";
            _view.GoodsReceivedNoteId = 0;
            _view.VendorDONumber = "";
            _view.VendorInvoiceNumber = "";
            _view.BillDate = DateTime.Now;
            _view.BillDueDate = DateTime.Now;
            _view.BillTypeId = 0;
        }
        
        private void LoadAllBillList()
        {
            BillList = Program.Mapper.Map<IEnumerable<BillViewModel>>(_unitOfWork.Bill.GetAll(includeProperties: "GoodsReceivedNote,BillType"));
            BillBindingSource.DataSource = BillList;//Set data source.
        }
        private void LoadAllBillTypeList()
        {
            BillTypeList = _unitOfWork.BillType.GetAll();
            BillTypeBindingSource.DataSource = BillTypeList;//Set data source.
        }
        private void LoadAllGoodsReceivedNoteList()
        {
            GoodsReceivedNoteList = _unitOfWork.GoodsReceivedNote.GetAll();
            GoodsReceivedNoteBindingSource.DataSource = GoodsReceivedNoteList;//Set data source.
        }
    }
}
