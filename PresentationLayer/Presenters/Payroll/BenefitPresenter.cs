using DomainLayer.Enums;
using DomainLayer.Models.Inventory;
using DomainLayer.Models.Payroll;
using DomainLayer.ViewModels;
using DomainLayer.ViewModels.Inventory;
using DomainLayer.ViewModels.PayrollViewModels;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using PresentationLayer.Views.IViews.Payroll;
using ServiceLayer.Services.CommonServices;
using ServiceLayer.Services.IRepositories;

namespace PresentationLayer.Presenters.Payroll
{
    public class BenefitPresenter
    {
        public IBenefitView _view;
        private IUnitOfWork _unitOfWork;
        private BindingSource BenefitBindingSource;
        private BindingSource BenefitTypeBindingSource;
        private BindingSource EmployeeBindingSource;
        private IEnumerable<BenefitViewModel> BenefitList;
        private IEnumerable<EnumItemViewModel> BenefitTypeList;
        private IEnumerable<Employee> EmployeeList;
        public BenefitPresenter(IBenefitView view, IUnitOfWork unitOfWork)
        {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            BenefitBindingSource = new BindingSource();
            BenefitTypeBindingSource = new BindingSource();
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

            LoadAllBenefitList();
            LoadAllBenefitTypeList();
            LoadAllEmployeeList();

            //Source Binding
            _view.SetBenefitListBindingSource(BenefitBindingSource);
            _view.SetBenefitTypeListBindingSource(BenefitTypeBindingSource);
            _view.SetEmployeeListBindingSource(EmployeeBindingSource);
        }

        private void AddNew(object? sender, EventArgs e)
        {
            _view.IsEdit = false;
            CleanviewFields();
        }
        private void Save(object? sender, EventArgs e)
        {
            var model = _unitOfWork.Benefit.Get(c => c.BenefitId == _view.BenefitId, tracked: true);
            if (model == null) model = new Benefit();
            else _unitOfWork.Benefit.Detach(model);

            model.BenefitId = _view.BenefitId;
            model.BenefitType = _view.BenefitType;
            model.Amount = _view.Amount;
            model.EmployeeId = _view.EmployeeId;

            try
            {
                new ModelDataValidation().Validate(model);
                if (_view.IsEdit)//Edit model
                {
                    _unitOfWork.Benefit.Update(model);
                    _view.Message = "Benefit edited successfully";
                }
                else //Add new model
                {
                    _unitOfWork.Benefit.Add(model);
                    _view.Message = "Benefit added successfully";
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
                BenefitList = Program.Mapper.Map<IEnumerable<BenefitViewModel>>(_unitOfWork.Benefit.GetAll(
                    c => c.Employee.LastName.Contains(_view.SearchValue) || 
                    c.Employee.FirstName.Contains(_view.SearchValue), includeProperties: "Employee"));
                BenefitBindingSource.DataSource = BenefitList;
            }
            else
            {
                LoadAllBenefitList();
            }
        }
        private void Edit(object? sender, EventArgs e)
        {
            _view.IsEdit = true;
            var benefit = (BenefitViewModel)BenefitBindingSource.Current;
            var entity = _unitOfWork.Benefit.Get(c => c.BenefitId == benefit.BenefitId);
            _view.BenefitId = entity.BenefitId;
            _view.BenefitType = entity.BenefitType;
            _view.Amount = entity.Amount;
            _view.EmployeeId = entity.EmployeeId;
        }
        private void Delete(object? sender, EventArgs e)
        {
            try
            {
                var benefit = (BenefitViewModel)BenefitBindingSource.Current;
                var entity = _unitOfWork.Benefit.Get(c => c.BenefitId == benefit.BenefitId);
                _unitOfWork.Benefit.Remove(entity);
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                _view.Message = "Benefit deleted successfully";
                LoadAllBenefitList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete Benefit";
            }
        }
        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "BenefitReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("Benefit", BenefitList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        private void Return(object? sender, EventArgs e)
        {
            LoadAllBenefitList();
        }
        private void CleanviewFields()
        {
            LoadAllBenefitList();
            _view.BenefitId = 0;
            _view.BenefitType = 0;
            _view.Amount = 0;
            _view.EmployeeId = 0;
        }

        private void LoadAllBenefitList()
        {
            BenefitList = Program.Mapper.Map<IEnumerable<BenefitViewModel>>(_unitOfWork.Benefit.GetAll(includeProperties:"Employee"));
            BenefitBindingSource.DataSource = BenefitList;//Set data source.
        }
        private void LoadAllBenefitTypeList()
        {
            BenefitTypeList = EnumHelper.EnumToEnumerable<BenefitType>();
            BenefitTypeBindingSource.DataSource = BenefitTypeList;//Set data source.
        }
        private void LoadAllEmployeeList()
        {
            EmployeeList = _unitOfWork.Employee.GetAll();
            EmployeeBindingSource.DataSource = EmployeeList;//Set data source.
        }
    }
}
