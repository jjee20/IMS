using DomainLayer.ViewModels.PayrollViewModels;
using Microsoft.Reporting.WinForms;
using PresentationLayer;
using PresentationLayer.Reports;
using PresentationLayer.Views.UserControls;
using RavenTech_ERP.Views.IViews.Accounting.Payroll;
using RavenTech_ERP.Views.UserControls.Inventory;
using ServiceLayer.Services.IRepositories;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGrid.Events;

namespace RavenTech_ERP.Presenters.Accounting.Payroll
{
    public class EmployeeContributionPresenter
    {
        public IEmployeeContributionView _view;
        private IUnitOfWork _unitOfWork;
        private IEnumerable<EmployeeContributionViewModel> EmployeeContributionList;
        public EmployeeContributionPresenter(IEmployeeContributionView view, IUnitOfWork unitOfWork) {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;

            //Events
            _view.SearchEvent += Search;
            _view.AddEvent += AddNew;
            _view.EditEvent += Edit;
            _view.DeleteEvent += Delete;
            _view.MultipleDeleteEvent += MultipleDelete;
            _view.PrintEvent += Print;

            //Load

            LoadAllEmployeeContributionList();

            //Source Binding
        }

        private void AddNew(object? sender, EventArgs e)
        {
            using (var form = new UpsertEmployeeContributionView(_unitOfWork))
            {
                form.Text = "Add EmployeeContribution";
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadAllEmployeeContributionList();
                }
            }
        }
        
        private void Search(object? sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(_view.SearchValue);
            LoadAllEmployeeContributionList(emptyValue);
        }
        private void Edit(object? sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is EmployeeContributionViewModel row)
            {
                var entity = _unitOfWork.EmployeeContribution.Value.Get(c => c.EmployeeContributionId == row.EmployeeContributionId);
                using (var form = new UpsertEmployeeContributionView(_unitOfWork,entity))
                {
                    form.Text = "Edit EmployeeContribution";
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadAllEmployeeContributionList();
                    }
                }
            }
        }
        private void Delete(object? sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is EmployeeContributionViewModel row)
            {
                var entity = _unitOfWork.EmployeeContribution.Value.Get(c => c.EmployeeContributionId == row.EmployeeContributionId);
                if (entity != null)
                {
                    _unitOfWork.EmployeeContribution.Value.Remove(entity);
                    _unitOfWork.Save();

                    _view.ShowMessage("EmployeeContribution deleted successfully.");

                    LoadAllEmployeeContributionList();
                }
            }
        }
        private void MultipleDelete(object? sender, EventArgs e)
        {
            try
            {
                if (_view.DataGrid.SelectedItems == null || _view.DataGrid.SelectedItems.Count == 0)
                {
                    _view.ShowMessage("Please select item(s) to delete.");
                    return;
                }

                var selected = _view.DataGrid.SelectedItems.Cast<EmployeeContributionViewModel>().ToList(); // If you're using view models
                var ids = selected.Select(b => b.EmployeeContributionId).ToList();

                var entities = _unitOfWork.EmployeeContribution.Value
                    .GetAll()
                    .Where(b => ids.Contains(b.EmployeeContributionId))
                    .ToList();

                if (!entities.Any())
                {
                    _view.ShowMessage("Selected records could not be found.");
                    return;
                }

                _unitOfWork.EmployeeContribution.Value.RemoveRange(entities);
                _unitOfWork.Save();

                _view.ShowMessage($"{entities.Count} entries deleted successfully.");
                LoadAllEmployeeContributionList();
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"An error occurred while deleting: {ex.Message}");
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
        
        private void LoadAllEmployeeContributionList(bool emptyValue = false)
        {
            EmployeeContributionList = Program.Mapper.Map<IEnumerable<EmployeeContributionViewModel>>(_unitOfWork.EmployeeContribution.Value.GetAll(includeProperties: "Employee"));

            if (!emptyValue) EmployeeContributionList = EmployeeContributionList.Where(c => c.Employee.ToLower().Contains(_view.SearchValue.ToLower()));
            _view.SetEmployeeContributionListBindingSource(EmployeeContributionList);
        }
    }
}
