using DomainLayer.Enums;
using DomainLayer.Models.Accounting.Payroll;
using DomainLayer.Models.Inventory;

using DomainLayer.ViewModels;
using DomainLayer.ViewModels.Inventory;
using DomainLayer.ViewModels.PayrollViewModels;
using Microsoft.Reporting.WinForms;
using PresentationLayer;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using RevenTech_ERP.Views.IViews.Accounting.Payroll;
using ServiceLayer.Services.CommonServices;
using ServiceLayer.Services.IRepositories.IInventory;

namespace RevenTech_ERP.Presenters.Accounting.Payroll
{
    public class DeductionPresenter
    {
        public IDeductionView _view;
        private IUnitOfWork _unitOfWork;
        private BindingSource DeductionBindingSource;
        private BindingSource DeductionTypeBindingSource;
        private BindingSource EmployeeBindingSource;
        private IEnumerable<DeductionViewModel> DeductionList;
        private IEnumerable<EnumItemViewModel> DeductionTypeList;
        private IEnumerable<EmployeeViewModel> EmployeeList;
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
            var model = _unitOfWork.Deduction.Get(c => c.DeductionId == _view.DeductionId, tracked: true);
            if (model == null) model = new Deduction();
            else _unitOfWork.Deduction.Detach(model);

            model.DeductionId = _view.DeductionId;
            model.DeductionType = _view.DeductionType;
            model.Amount = _view.Amount;
            model.EmployeeId = _view.EmployeeId;
            model.Description = _view.Description;
            model.DateDeducted = _view.DateDeducted;

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
                DeductionList = Program.Mapper.Map<IEnumerable<DeductionViewModel>>(
                    _unitOfWork.Deduction.GetAll(c => c.Employee.LastName.Contains(_view.SearchValue) || 
                    c.Employee.FirstName.Contains(_view.SearchValue) ||
                    (c.DateDeducted.Date >= _view.StartDate.Date && c.DateDeducted.Date <= _view.EndDate.Date), 
                    includeProperties: "Employee"));
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
            var deduction = (DeductionViewModel)DeductionBindingSource.Current;
            var entity = _unitOfWork.Deduction.Get(c => c.DeductionId == deduction.DeductionId);
            _view.DeductionId = entity.DeductionId;
            _view.DeductionType = entity.DeductionType;
            _view.Amount = entity.Amount;
            _view.EmployeeId = entity.EmployeeId;
            _view.Description = entity.Description;
            _view.DateDeducted = entity.DateDeducted;
        }
        private void Delete(object? sender, EventArgs e)
        {
            try
            {
                var deduction = (DeductionViewModel)DeductionBindingSource.Current;
                var entity = _unitOfWork.Deduction.Get(c => c.DeductionId == deduction.DeductionId);
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
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports", "Accounting", "Payroll");
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
            _view.Description = "";
        }

        private void LoadAllDeductionList()
        {
            DeductionList = Program.Mapper.Map<IEnumerable<DeductionViewModel>>(
                _unitOfWork.Deduction.GetAll(c => c.DateDeducted.Date >= _view.StartDate.Date && c.DateDeducted.Date <= _view.EndDate.Date, 
                includeProperties: "Employee"));
            DeductionBindingSource.DataSource = DeductionList;//Set data source.
        }
        private void LoadAllDeductionTypeList()
        {
            DeductionTypeList = EnumHelper.EnumToEnumerable<DeductionType>();
            DeductionTypeBindingSource.DataSource = DeductionTypeList;//Set data source.
        }
        private void LoadAllEmployeeList()
        {
            EmployeeList = Program.Mapper.Map<IEnumerable<EmployeeViewModel>>(_unitOfWork.Employee.GetAll());
            EmployeeBindingSource.DataSource = EmployeeList.OrderBy(c => c.Name);//Set data source.
        }
    }
}
