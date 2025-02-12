using DomainLayer.Enums;
using DomainLayer.Models.Inventory;
using DomainLayer.Models.Payroll;
using DomainLayer.ViewModels;
using DomainLayer.ViewModels.Inventory;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using PresentationLayer.Views.IViews.Payroll;
using ServiceLayer.Services.CommonServices;
using ServiceLayer.Services.IRepositories;

namespace PresentationLayer.Presenters.Payroll
{
    public class AllowancePresenter
    {
        public IAllowanceView _view;
        private IUnitOfWork _unitOfWork;
        private BindingSource AllowanceBindingSource;
        private BindingSource AllowanceTypeBindingSource;
        private BindingSource EmployeeBindingSource;
        private IEnumerable<Allowance> AllowanceList;
        private IEnumerable<EnumItemViewModel> AllowanceTypeList;
        private IEnumerable<Employee> EmployeeList;
        public AllowancePresenter(IAllowanceView view, IUnitOfWork unitOfWork)
        {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            AllowanceBindingSource = new BindingSource();
            AllowanceTypeBindingSource = new BindingSource();
            EmployeeBindingSource = new BindingSource();

            //Events
            _view.AddNewEvent += AddNew;
            _view.SaveEvent += Save;
            _view.SearchEvent += Search;
            _view.EditEvent += Edit;
            _view.DeleteEvent += Delete;
            _view.PrintEvent += Print;
            _view.RefreshEvent += Return;

            //Load

            LoadAllAllowanceList();
            LoadAllAllowanceTypeList();
            LoadAllEmployeeList();

            //Source Binding
            _view.SetAllowanceListBindingSource(AllowanceBindingSource);
            _view.SetAllowanceTypeListBindingSource(AllowanceTypeBindingSource);
            _view.SetEmployeeListBindingSource(EmployeeBindingSource);
        }

        private void AddNew(object? sender, EventArgs e)
        {
            _view.IsEdit = false;
            CleanviewFields();
        }
        private void Save(object? sender, EventArgs e)
        {
            var model = _unitOfWork.Allowance.Get(c => c.AllowanceId == _view.AllowanceId, tracked: true);
            if (model == null) model = new Allowance();
            else _unitOfWork.Allowance.Detach(model);

            model.AllowanceId = _view.AllowanceId;
            model.AllowanceType = _view.AllowanceType;
            model.Amount = _view.Amount;
            model.EmployeeId = _view.EmployeeId;
            model.Description = _view.Description;
            try
            {
                new ModelDataValidation().Validate(model);
                if (_view.IsEdit)//Edit model
                {
                    _unitOfWork.Allowance.Update(model);
                    _view.Message = "Allowance edited successfully";
                }
                else //Add new model
                {
                    _unitOfWork.Allowance.Add(model);
                    _view.Message = "Allowance added successfully";
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
                AllowanceList = _unitOfWork.Allowance.GetAll(c => c.Employee.LastName.Contains(_view.SearchValue) || c.Employee.FirstName.Contains(_view.SearchValue), includeProperties: "Employee");
                AllowanceBindingSource.DataSource = AllowanceList;
            }
            else
            {
                LoadAllAllowanceList();
            }
        }
        private void Edit(object? sender, EventArgs e)
        {
            _view.IsEdit = true;
            var entity = (Allowance)AllowanceBindingSource.Current;
            _view.AllowanceId = entity.AllowanceId;
            _view.AllowanceType = entity.AllowanceType;
            _view.Amount = entity.Amount;
            _view.EmployeeId = entity.EmployeeId;
            _view.Description = entity.Description;
        }
        private void Delete(object? sender, EventArgs e)
        {
            try
            {
                var entity = (Allowance)AllowanceBindingSource.Current;
                _unitOfWork.Allowance.Remove(entity);
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                _view.Message = "Allowance deleted successfully";
                LoadAllAllowanceList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete Allowance";
            }
        }
        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "AllowanceReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("Allowance", AllowanceList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        private void Return(object? sender, EventArgs e)
        {
            LoadAllAllowanceList();
        }
        private void CleanviewFields()
        {
            LoadAllAllowanceList();
            _view.AllowanceId = 0;
            _view.AllowanceType = 0;
            _view.Amount = 0;
            _view.EmployeeId = 0;
            _view.Description = "";
        }

        private void LoadAllAllowanceList()
        {
            AllowanceList = _unitOfWork.Allowance.GetAll();
            AllowanceBindingSource.DataSource = AllowanceList;//Set data source.
        }
        private void LoadAllAllowanceTypeList()
        {
            AllowanceTypeList = EnumHelper.EnumToEnumerable<AllowanceType>();
            AllowanceTypeBindingSource.DataSource = AllowanceTypeList;//Set data source.
        }
        private void LoadAllEmployeeList()
        {
            EmployeeList = _unitOfWork.Employee.GetAll();
            EmployeeBindingSource.DataSource = EmployeeList;//Set data source.
        }
    }
}
