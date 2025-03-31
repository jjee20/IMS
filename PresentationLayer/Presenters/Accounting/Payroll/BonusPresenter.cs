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
using ServiceLayer.Services.IRepositories;

namespace RevenTech_ERP.Presenters.Accounting.Payroll
{
    public class BonusPresenter
    {
        public IBonusView _view;
        private IUnitOfWork _unitOfWork;
        private BindingSource BonusBindingSource;
        private BindingSource BonusTypeBindingSource;
        private BindingSource EmployeeBindingSource;
        private IEnumerable<BonusViewModel> BonusList;
        private IEnumerable<EnumItemViewModel> BonusTypeList;
        private IEnumerable<EmployeeViewModel> EmployeeList;
        public BonusPresenter(IBonusView view, IUnitOfWork unitOfWork)
        {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            BonusBindingSource = new BindingSource();
            BonusTypeBindingSource = new BindingSource();
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

            LoadAllBonusList();
            LoadAllBonusTypeList();
            LoadAllEmployeeList();

            //Source Binding
        }

        private void AddNew(object? sender, EventArgs e)
        {
            _view.IsEdit = false;
            CleanviewFields();
        }
        private void Save(object? sender, EventArgs e)
        {
            var model = _unitOfWork.Bonus.Value.Get(c => c.BonusId == _view.BonusId, tracked: true);
            if (model == null) model = new Bonus();
            else _unitOfWork.Bonus.Value.Detach(model);

            model.BonusId = _view.BonusId;
            model.BonusType = _view.BonusType;
            model.Amount = _view.Amount;
            model.EmployeeId = _view.EmployeeId;
            model.Description = _view.Description;
            model.IsOneTime = _view.IsOneTime;

            try
            {
                new ModelDataValidation().Validate(model);
                if (_view.IsEdit)//Edit model
                {
                    _unitOfWork.Bonus.Value.Update(model);
                    _view.Message = "Bonus edited successfully";
                }
                else //Add new model
                {
                    _unitOfWork.Bonus.Value.Add(model);
                    _view.Message = "Bonus added successfully";
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
                BonusList = Program.Mapper.Map<IEnumerable<BonusViewModel>>(_unitOfWork.Bonus.Value.GetAll(c => c.Employee.LastName.Contains(_view.SearchValue) || c.Employee.FirstName.Contains(_view.SearchValue), includeProperties: "Employee"));
                BonusBindingSource.DataSource = BonusList;
            }
            else
            {
                LoadAllBonusList();
            }
        }
        private void Edit(object? sender, EventArgs e)
        {
            _view.IsEdit = true;
            var entity = (Bonus)BonusBindingSource.Current;
            _view.BonusId = entity.BonusId;
            _view.BonusType = entity.BonusType;
            _view.Amount = entity.Amount;
            _view.EmployeeId = entity.EmployeeId;
            _view.Description = entity.Description;
            _view.IsOneTime = entity.IsOneTime;
        }
        private void Delete(object? sender, EventArgs e)
        {
            try
            {
                var entity = (Bonus)BonusBindingSource.Current;
                _unitOfWork.Bonus.Value.Remove(entity);
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                _view.Message = "Bonus deleted successfully";
                LoadAllBonusList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete Bonus";
            }
        }
        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "BonusReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports", "Accounting", "Payroll");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("Bonus", BonusList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        private void Return(object? sender, EventArgs e)
        {
            LoadAllBonusList();
        }
        private void CleanviewFields()
        {
            LoadAllBonusList();
            _view.BonusId = 0;
            _view.BonusType = 0;
            _view.Amount = 0;
            _view.EmployeeId = 0;
            _view.Description = "";
        }

        private void LoadAllBonusList()
        {
            BonusList = Program.Mapper.Map<IEnumerable<BonusViewModel>>(_unitOfWork.Bonus.Value.GetAll(includeProperties:"Employee"));
            BonusBindingSource.DataSource = BonusList;//Set data source
            _view.SetBonusListBindingSource(BonusBindingSource);
        }
        private void LoadAllBonusTypeList()
        {
            BonusTypeList = EnumHelper.EnumToEnumerable<BonusType>();
            BonusTypeBindingSource.DataSource = BonusTypeList;//Set data source.
            _view.SetBonusTypeListBindingSource(BonusTypeBindingSource);
        }
        private void LoadAllEmployeeList()
        {
            EmployeeList = Program.Mapper.Map<IEnumerable<EmployeeViewModel>>(_unitOfWork.Employee.Value.GetAll());
            EmployeeBindingSource.DataSource = EmployeeList.OrderBy(c => c.Name);//Set data source.
            _view.SetEmployeeListBindingSource(EmployeeBindingSource);
        }
    }
}
