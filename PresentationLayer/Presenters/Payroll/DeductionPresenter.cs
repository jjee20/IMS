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
    public class DeductionPresenter
    {
        public IDeductionView _view;
        private IUnitOfWork _unitOfWork;
        private BindingSource DeductionBindingSource;
        private BindingSource DeductionTypeBindingSource;
        private BindingSource EmployeeBindingSource;
        private IEnumerable<Deduction> DeductionList;
        private IEnumerable<EnumItemViewModel> DeductionTypeList;
        private IEnumerable<Employee> EmployeeList;
        public DeductionPresenter(IDeductionView view, IUnitOfWork unitOfWork)
        {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            DeductionBindingSource = new BindingSource();
            DeductionTypeBindingSource = new BindingSource();
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

            LoadAllDeductionList();
            LoadAllDeductionTypeList();
            LoadAllEmployeeList();

            //Source Binding
            _view.SetDeductionListBindingSource(DeductionBindingSource);
            _view.SetDeductionTypeListBindingSource(DeductionTypeBindingSource);
            _view.SetEmployeeListBindingSource(EmployeeBindingSource);
        }

        private void AddNew(object? sender, EventArgs e)
        {
            _view.IsEdit = false;
            CleanviewFields();
        }
        private void Save(object? sender, EventArgs e)
        {
            var model = new Deduction
            {
                DeductionId = _view.DeductionId,
                DeductionType = _view.DeductionType,
                Amount = _view.Amount,
                EmployeeId = _view.EmployeeId,
            };

            try
            {
                new ModelDataValidation().Validate(model);
                if (_view.IsEdit)//Edit model
                {
                    _unitOfWork.Deduction.Update(model);
                    _view.Message = "Deduction edited successfully";
                }
                else //Add new model
                {
                    _unitOfWork.Deduction.Add(model);
                    _view.Message = "Deduction added successfully";
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
                DeductionList = _unitOfWork.Deduction.GetAll(c => c.Employee.LastName.Contains(_view.SearchValue) || c.Employee.FirstName.Contains(_view.SearchValue), includeProperties: "Employee");
                DeductionBindingSource.DataSource = DeductionList;
            }
            else
            {
                LoadAllDeductionList();
            }
        }
        private void Edit(object? sender, EventArgs e)
        {
            _view.IsEdit = true;
            var entity = (Deduction)DeductionBindingSource.Current;
            _view.DeductionId = entity.DeductionId;
            _view.DeductionType = entity.DeductionType;
            _view.Amount = entity.Amount;
            _view.EmployeeId = entity.EmployeeId;
        }
        private void Delete(object? sender, EventArgs e)
        {
            try
            {
                var entity = (Deduction)DeductionBindingSource.Current;
                _unitOfWork.Deduction.Remove(entity);
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                _view.Message = "Deduction deleted successfully";
                LoadAllDeductionList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete Deduction";
            }
        }
        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "DeductionReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("Deduction", DeductionList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        private void Return(object? sender, EventArgs e)
        {
            LoadAllDeductionList();
        }
        private void CleanviewFields()
        {
            LoadAllDeductionList();
            _view.DeductionId = 0;
            _view.DeductionType = 0;
            _view.Amount = 0;
            _view.EmployeeId = 0;
        }

        private void LoadAllDeductionList()
        {
            DeductionList = _unitOfWork.Deduction.GetAll();
            DeductionBindingSource.DataSource = DeductionList;//Set data source.
        }
        private void LoadAllDeductionTypeList()
        {
            DeductionTypeList = EnumHelper.EnumToEnumerable<DeductionType>();
            DeductionTypeBindingSource.DataSource = DeductionTypeList;//Set data source.
        }
        private void LoadAllEmployeeList()
        {
            EmployeeList = _unitOfWork.Employee.GetAll();
            EmployeeBindingSource.DataSource = EmployeeList;//Set data source.
        }
    }
}
