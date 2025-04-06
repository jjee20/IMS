using DomainLayer.Enums;
using DomainLayer.Models.Accounting.Payroll;
using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels;
using DomainLayer.ViewModels.Inventory;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using RevenTech_ERP.Views.IViews.Accounting.Payroll;
using ServiceLayer.Services.CommonServices;
using ServiceLayer.Services.IRepositories;

namespace RevenTech_ERP.Presenters.Accounting.Payroll
{
    public class ContributionPresenter
    {
        public IContributionView _view;
        private IUnitOfWork _unitOfWork;
        private BindingSource ContributionTypeBindingSource;
        private IEnumerable<Contribution> ContributionList;
        private IEnumerable<EnumItemViewModel> ContributionTypeList;
        public ContributionPresenter(IContributionView view, IUnitOfWork unitOfWork)
        {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            ContributionTypeBindingSource = new BindingSource();

            //Events
            _view.AddNewEvent += AddNew;
            _view.SaveEvent += Save;
            _view.SearchEvent += Search;
            _view.EditEvent += Edit;
            _view.DeleteEvent += Delete;
            _view.PrintEvent += Print;
            _view.RefreshEvent += Return;

            //Load

            LoadAllContributionList();
            LoadAllContributionTypeList();

            //Source Binding
        }

        private void AddNew(object? sender, EventArgs e)
        {
            _view.IsEdit = false;
            CleanviewFields();
        }
        private async void Save(object? sender, EventArgs e)
        {
            var model = await _unitOfWork.Contribution.Value.GetAsync(c => c.ContributionId == _view.ContributionId, tracked: true);
            if (model == null) model = new Contribution();
            else _unitOfWork.Contribution.Value.Detach(model);

            model.ContributionId = _view.ContributionId;
            model.ContributionType = _view.ContributionType;
            model.EmployeeRate = _view.Rate;
            model.MinimumLimit = _view.MinimumLimit;
            model.MaximumLimit = _view.MaximumLimit;
            model.MandatoryProvidentFund = _view.MandatoryProvidentFund;

            try
            {
                new ModelDataValidation().Validate(model);
                if (_view.IsEdit)//Edit model
                {
                    _unitOfWork.Contribution.Value.Update(model);
                    _view.Message = "Contribution edited successfully";
                }
                else //Add new model
                {
                    await _unitOfWork.Contribution.Value.AddAsync(model);
                    _view.Message = "Contribution added successfully";
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
            LoadAllContributionList(emptyValue);
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

            var entity = (Contribution)_view.DataGrid.SelectedItem;
            _view.ContributionId = entity.ContributionId;
            _view.ContributionType = entity.ContributionType;
            _view.Rate = entity.EmployeeRate;
            _view.MinimumLimit = entity.MinimumLimit;
            _view.MaximumLimit = entity.MaximumLimit;
            _view.MandatoryProvidentFund = (double)entity.MandatoryProvidentFund;
        }
        private void Delete(object? sender, EventArgs e)
        {
            try
            {
                if (_view.DataGrid.SelectedItems == null || _view.DataGrid.SelectedItems.Count == 0)
                {
                    _view.IsSuccessful = false;
                    _view.Message = "Please select contribution(s) to delete.";
                    _view.ShowMessage(_view.Message);
                    return;
                }

                var selectedContributions = _view.DataGrid.SelectedItems.Cast<Contribution>().ToList();

                if (!selectedContributions.Any())
                {
                    _view.IsSuccessful = false;
                    _view.Message = "No valid contributions selected.";
                    _view.ShowMessage(_view.Message);
                    return;
                }

                _unitOfWork.Contribution.Value.RemoveRange(selectedContributions);
                _unitOfWork.Save();

                _view.IsSuccessful = true;
                _view.Message = $"{selectedContributions.Count} contribution(s) deleted successfully.";
                _view.ShowMessage(_view.Message);
                LoadAllContributionList();
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
            string reportFileName = "ContributionReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports", "Accounting", "Payroll");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("Contribution", ContributionList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        private void Return(object? sender, EventArgs e)
        {
            LoadAllContributionList();
        }
        private void CleanviewFields()
        {
            LoadAllContributionList();
            _view.ContributionId = 0;
            _view.ContributionType = 0;
            _view.Rate = 0;
            _view.MinimumLimit = 0;
            _view.MaximumLimit = 0;
        }

        private void LoadAllContributionList(bool emptyValue = false)
        {
            ContributionList = _unitOfWork.Contribution.Value.GetAll();
            if (!emptyValue) ContributionList = ContributionList.Where(c => c.ContributionType.ToString().Contains(_view.SearchValue));
            _view.SetContributionListBindingSource(ContributionList);
        }
        private void LoadAllContributionTypeList()
        {
            ContributionTypeList = EnumHelper.EnumToEnumerable<ContributionType>();
            ContributionTypeBindingSource.DataSource = ContributionTypeList;//Set data source.
            _view.SetContributionTypeListBindingSource(ContributionTypeBindingSource);
        }
    }
}
