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
        private BindingSource EmployeeBindingSource;
        private IEnumerable<EmployeeContributionViewModel> EmployeeContributionList;
        private IEnumerable<EmployeeViewModel> EmployeeList;
        public EmployeeContributionPresenter(IEmployeeContributionView view, IUnitOfWork unitOfWork)
        {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
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
        private async void Save(object? sender, EventArgs e)
        {
            var model = await _unitOfWork.EmployeeContribution.Value.GetAsync(c => c.EmployeeContributionId == _view.EmployeeContributionId, tracked: true);
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
                    await _unitOfWork.EmployeeContribution.Value.AddAsync(model);
                    _view.Message = "EmployeeContribution added successfully";
                }
                await _unitOfWork.SaveAsync();
                _view.IsSuccessful = true;
                _view.ShowMessage(_view.Message);
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
            LoadAllEmployeeContributionList(emptyValue);
        }
        private void Edit(object? sender, EventArgs e)
        {
            _view.IsEdit = true;
            if (_view.DataGrid.SelectedItem == null)
            {
                _view.IsSuccessful = false;
                _view.Message = "Please select one to edit";
                return;
            }

            var employeeContribution = (EmployeeContributionViewModel)_view.DataGrid.SelectedItem;
            var entity = _unitOfWork.EmployeeContribution.Value.Get(c => c.EmployeeContributionId == employeeContribution.EmployeeContributionId);
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
                if (_view.DataGrid.SelectedItems == null || _view.DataGrid.SelectedItems.Count == 0)
                {
                    _view.IsSuccessful = false;
                    _view.Message = "Please select employee contribution(s) to delete.";
                    _view.ShowMessage(_view.Message);
                    return;
                }

                var selectedContributions = _view.DataGrid.SelectedItems.Cast<EmployeeContributionViewModel>().ToList();
                var ids = selectedContributions.Select(ec => ec.EmployeeContributionId).ToList();

                var entities = _unitOfWork.EmployeeContribution.Value
                    .GetAll()
                    .Where(ec => ids.Contains(ec.EmployeeContributionId))
                    .ToList();

                if (!entities.Any())
                {
                    _view.IsSuccessful = false;
                    _view.Message = "Selected employee contribution(s) could not be found.";
                    _view.ShowMessage(_view.Message);
                    return;
                }

                _unitOfWork.EmployeeContribution.Value.RemoveRange(entities);
                _unitOfWork.Save();

                _view.IsSuccessful = true;
                _view.Message = $"{entities.Count} employee contribution(s) deleted successfully.";
                _view.ShowMessage(_view.Message);
                LoadAllEmployeeContributionList();
            }
            catch (Exception ex)
            {
                _view.IsSuccessful = false;
                _view.Message = $"An error occurred while deleting: {ex.Message}";
                _view.ShowMessage(_view.Message);
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

        private void LoadAllEmployeeContributionList(bool emptyValue = false)
        {
            EmployeeContributionList = Program.Mapper.Map<IEnumerable<EmployeeContributionViewModel>>(
                _unitOfWork.EmployeeContribution.Value.GetAll(includeProperties:"Employee"));

            if (!emptyValue) EmployeeContributionList = EmployeeContributionList.Where(c => c.Employee.Equals(_view.SearchValue));
            _view.SetEmployeeContributionListBindingSource(EmployeeContributionList.OrderBy(c => c.Employee));
        }
        private void LoadAllEmployeeList()
        {
            EmployeeList = Program.Mapper.Map<IEnumerable<EmployeeViewModel>>(_unitOfWork.Employee.Value.GetAll());
            EmployeeBindingSource.DataSource = EmployeeList.OrderBy(c => c.Name);//Set data source.
            _view.SetEmployeeListBindingSource(EmployeeBindingSource);
        }
    }
}
