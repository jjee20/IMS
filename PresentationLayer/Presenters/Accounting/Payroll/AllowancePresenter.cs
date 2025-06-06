using DomainLayer.ViewModels.PayrollViewModels;
using Microsoft.Reporting.WinForms;
using PresentationLayer;
using PresentationLayer.Reports;
using RavenTech_ERP.Views.IViews.Accounting.Payroll;
using RavenTech_ERP.Views.UserControls.Inventory;
using ServiceLayer.Services.IRepositories;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGrid.Events;
using System.Runtime.Intrinsics.Arm;

namespace RavenTech_ERP.Presenters.Accounting.Payroll
{
    public class AllowancePresenter
    {
        public IAllowanceView _view;
        private IUnitOfWork _unitOfWork;
        private IEnumerable<AllowanceViewModel> AllowanceList;
        public AllowancePresenter(IAllowanceView view, IUnitOfWork unitOfWork) {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;

            //Events
            _view.SearchEvent -= Search;
            _view.AddEvent -= AddNew;
            _view.EditEvent -= Edit;
            _view.DeleteEvent -= Delete;
            _view.MultipleDeleteEvent -= MultipleDelete;
            _view.PrintEvent -= Print;

            _view.SearchEvent += Search;
            _view.AddEvent += AddNew;
            _view.EditEvent += Edit;
            _view.DeleteEvent += Delete;
            _view.MultipleDeleteEvent += MultipleDelete;
            _view.PrintEvent += Print;

            //Load

            LoadAllAllowanceList();

            //Source Binding
        }

        private void AddNew(object? sender, EventArgs e)
        {
            using (var form = new UpsertAllowanceView(_unitOfWork))
            {
                form.Text = "Add Allowance";
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadAllAllowanceList();
                }
            }
        }
        
        private void Search(object? sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(_view.SearchValue);
            LoadAllAllowanceList(emptyValue);
        }
        private void Edit(object? sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is AllowanceViewModel row)
            {
                var entity = _unitOfWork.Allowance.Value.Get(c => c.AllowanceId == row.AllowanceId);
                using (var form = new UpsertAllowanceView(_unitOfWork,entity))
                {
                    form.Text = "Edit Allowance";
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadAllAllowanceList();
                    }
                }
            }
        }
        private void Delete(object? sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is AllowanceViewModel row)
            {
                var entity = _unitOfWork.Allowance.Value.Get(c => c.AllowanceId == row.AllowanceId);
                if (entity != null)
                {
                    _unitOfWork.Allowance.Value.Remove(entity);
                    _unitOfWork.Save();

                    _view.ShowMessage("Allowance deleted successfully.");

                    LoadAllAllowanceList();
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

                var selected = _view.DataGrid.SelectedItems.Cast<AllowanceViewModel>().ToList(); // If you're using view models
                var ids = selected.Select(b => b.AllowanceId).ToList();

                var entities = _unitOfWork.Allowance.Value
                    .GetAll()
                    .Where(b => ids.Contains(b.AllowanceId))
                    .ToList();

                if (!entities.Any())
                {
                    _view.ShowMessage("Selected records could not be found.");
                    return;
                }

                _unitOfWork.Allowance.Value.RemoveRange(entities);
                _unitOfWork.Save();

                _view.ShowMessage($"{entities.Count} entries deleted successfully.");
                LoadAllAllowanceList();
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"An error occurred while deleting: {ex.Message}");
            }
        }

        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "AllowanceReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports", "Accounting", "Payroll");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("Allowance", AllowanceList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        
        private void LoadAllAllowanceList(bool emptyValue = false)
        {
            AllowanceList = Program.Mapper.Map<IEnumerable<AllowanceViewModel>>(_unitOfWork.Allowance.Value.GetAll(includeProperties: "Employee"));

            if (!emptyValue) AllowanceList = AllowanceList.Where(c => c.Employee.Contains(_view.SearchValue));
            _view.SetAllowanceListBindingSource(AllowanceList.OrderByDescending(c => c.StartDate));
        }
    }
}
