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
using RavenTech_ERP.Views.IViews.Accounting.Payroll;
using RevenTech_ERP.Views.IViews.Accounting.Payroll;
using ServiceLayer.Services.CommonServices;
using ServiceLayer.Services.IRepositories;

namespace RevenTech_ERP.Presenters.Accounting.Payroll
{
    public class EmployeeContributionPresenter
    {
        public IEmployeeContributionView _view;
        private IUnitOfWork _unitOfWork;
        private BindingSource EmployeeContributionBindingSource;
        private BindingSource EmployeeBindingSource;
        private IEnumerable<EmployeeContribution> EmployeeContributionList;
        private IEnumerable<EmployeeViewModel> EmployeeList;
        public EmployeeContributionPresenter(IEmployeeContributionView view, IUnitOfWork unitOfWork)
        {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            EmployeeContributionBindingSource = new BindingSource();
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

            LoadAllEmployeeContributionList();
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
            var model = _unitOfWork.EmployeeContribution.Value.Get(c => c.EmployeeContributionId == _view.EmployeeContributionId, tracked: true);
            if (model == null) model = new EmployeeContribution();
            else _unitOfWork.EmployeeContribution.Value.Detach(model);

            model.EmployeeContributionId = _view.EmployeeContributionId;
            model.EmployeeId = _view.EmployeeId;
            model.SSS = _view.SSS;
            model.SSSWISP = _view.SSSWISP;
            model.PhilHealth = _view.PhilHealth;
            model.PagIbig = _view.PagIbig;

            try
            {
                new ModelDataValidation().Validate(model);
                if (_view.IsEdit)//Edit model
                {
                    _unitOfWork.EmployeeContribution.Value.Update(model);
                    _view.Message = "EmployeeContribution edited successfully";
                }
                else //Add new model
                {
                    var Entity = _unitOfWork.EmployeeContribution.Value.Get(c => c.EmployeeId == _view.EmployeeId);
                    if (Entity != null)
                    {
                        _view.Message = "EmployeeContribution is already added.";
                        return;
                    }

                    _unitOfWork.EmployeeContribution.Value.Add(model);
                    _view.Message = "EmployeeContribution added successfully";
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
                // Safely parse and filter EmployeeContributions
                EmployeeContributionList = _unitOfWork.EmployeeContribution.Value.GetAll(c => c.Employee.LastName == _view.SearchValue || c.Employee.FirstName == _view.SearchValue, includeProperties: "Employee");
                EmployeeContributionBindingSource.DataSource = EmployeeContributionList;
            }
            else
            {
                LoadAllEmployeeContributionList();
            }
        }
        private void Edit(object? sender, EventArgs e)
        {
            _view.IsEdit = true;
            var entity = (EmployeeContribution)EmployeeContributionBindingSource.Current;
            _view.EmployeeContributionId = entity.EmployeeContributionId;
            _view.SSS = entity.SSS;
            _view.SSSWISP = entity.SSSWISP;
            _view.PagIbig = entity.PagIbig;
            _view.PhilHealth = entity.PhilHealth;
            _view.EmployeeId = entity.EmployeeId;
        }
        private void Delete(object? sender, EventArgs e)
        {
            try
            {
                var entity = (EmployeeContribution)EmployeeContributionBindingSource.Current;
                _unitOfWork.EmployeeContribution.Value.Remove(entity);
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                _view.Message = "EmployeeContribution deleted successfully";
                LoadAllEmployeeContributionList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete EmployeeContribution";
            }
        }
        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "EmployeeContributionReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports", "Accounting", "Payroll");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("EmployeeContribution", EmployeeContributionList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        private void Return(object? sender, EventArgs e)
        {
            LoadAllEmployeeContributionList();
        }
        private void CleanviewFields()
        {
            LoadAllEmployeeContributionList();
            _view.EmployeeContributionId = 0;
        }

        private void LoadAllEmployeeContributionList()
        {
            EmployeeContributionList = _unitOfWork.EmployeeContribution.Value.GetAll();
            EmployeeContributionBindingSource.DataSource = EmployeeContributionList;//Set data source.
            _view.SetEmployeeContributionListBindingSource(EmployeeContributionBindingSource);
        }
        private void LoadAllEmployeeList()
        {
            EmployeeList = Program.Mapper.Map<IEnumerable<EmployeeViewModel>>(_unitOfWork.Employee.Value.GetAll());
            EmployeeBindingSource.DataSource = EmployeeList;//Set data source.
            _view.SetEmployeeListBindingSource(EmployeeBindingSource);
        }
    }
}
