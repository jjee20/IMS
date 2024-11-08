using DomainLayer.Models;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using ServiceLayer.Services.IRepositories;

namespace PresentationLayer.Presenters
{
    public class BranchPresenter
    {
        public IBranchView _view;
        private IUnitOfWork _unitOfWork;
        private BindingSource BranchBindingSource;
        private BindingSource CurrencyBindingSource;
        private IEnumerable<Branch> BranchList;
        private IEnumerable<Currency> CurrencyList;
       
        public BranchPresenter(IBranchView view, IUnitOfWork unitOfWork) {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            BranchBindingSource = new BindingSource();
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
            _view.SetBranchListBindingSource(BranchBindingSource);
            _view.SetCurrencyListBindingSource(CurrencyBindingSource);
            
            //Load

            LoadAllBranchList();
            LoadAllCurrencyList();
        }

        private void AddNew(object? sender, EventArgs e)
        {
            _view.IsEdit = false;
            CleanviewFields();
        }
        private void Save(object? sender, EventArgs e)
        {
            var Entity = _unitOfWork.Branch.Get(c => c.BranchName == _view.BranchName);
            if (Entity != null)
            {
                _view.Message = "Branch type is already added.";
                return;
            }

            var model = new Branch()
            {
                
                BranchId = _view.BranchId,
                BranchName = _view.BranchName,
                Description = _view.Description,
                CurrencyId = _view.CurrencyId,
                Region = _view.Region,
                Municipality = _view.Municipality,
                Province = _view.Province,
                Barangay = _view.Barangay,
                ZipCode = _view.ZipCode,
                Phone = _view.Phone,
                Email = _view.Email,
                ContactPerson = _view.ContactPerson,
            };

            try
            {
                new ModelDataValidation().Validate(model);
                if (_view.IsEdit)//Edit model
                {
                    _unitOfWork.Branch.Update(model);
                    _unitOfWork.Save();
                    _view.Message = "Branch type edited successfuly";
                }
                else //Add new model
                {
                    _unitOfWork.Branch.Add(model);
                    _unitOfWork.Save();
                    _view.Message = "Branch type added sucessfully";
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
                BranchList = _unitOfWork.Branch.GetAll(c => c.BranchName.Contains(_view.SearchValue));
                BranchBindingSource.DataSource = BranchList;
            }
            else
            {
                BranchList = _unitOfWork.Branch.GetAll();
                BranchBindingSource.DataSource = BranchList;
            }
        }
        private void Edit(object? sender, EventArgs e)
        {
            var entity = (Branch)BranchBindingSource.Current;
            _view.BranchId = entity.BranchId;
            _view.BranchName = entity.BranchName;
            _view.Description = entity.Description;
            _view.CurrencyId = entity.CurrencyId;
            _view.Region = entity.Region;
            _view.Municipality = entity.Municipality;
            _view.Province = entity.Province;
            _view.Barangay = entity.Barangay;
            _view.ZipCode = entity.ZipCode;
            _view.Phone = entity.Phone;
            _view.Email = entity.Email;
            _view.ContactPerson = entity.ContactPerson;
        }
        private void Delete(object? sender, EventArgs e)
        {
            try
            {
                var entity = (Branch)BranchBindingSource.Current;
                _unitOfWork.Branch.Remove(entity);
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                _view.Message = "Branch type deleted successfully";
                LoadAllBranchList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete Branch type";
            }
        }
        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "BranchReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("Branch", BranchList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        private void Return(object? sender, EventArgs e)
        {
            LoadAllBranchList();
        }
        private void CleanviewFields()
        {
            LoadAllBranchList();
            _view.BranchId = 0;
            _view.BranchName = "";
            _view.Description = "";
            _view.CurrencyId = 0;
            _view.Region = "";
            _view.Municipality = "";
            _view.Province = "";
            _view.Barangay = "";
            _view.ZipCode = "";
            _view.Phone = "";
            _view.Email = "";
            _view.ContactPerson = "";
        }
        
        private void LoadAllBranchList()
        {
            BranchList = _unitOfWork.Branch.GetAll();
            BranchBindingSource.DataSource = BranchList;//Set data source.
        }
        private void LoadAllCurrencyList()
        {
            CurrencyList = _unitOfWork.Currency.GetAll();
            CurrencyBindingSource.DataSource = CurrencyList;//Set data source.
        }
    }
}
