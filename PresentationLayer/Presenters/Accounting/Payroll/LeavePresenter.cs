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
    public class LeavePresenter
    {
        public ILeaveView _view;
        private IUnitOfWork _unitOfWork;
        private IEnumerable<LeaveViewModel> LeaveList;
        public LeavePresenter(ILeaveView view, IUnitOfWork unitOfWork) {

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

            LoadAllLeaveList();

            //Source Binding
        }

        private void AddNew(object? sender, EventArgs e)
        {
            using (var form = new UpsertLeaveView(_unitOfWork))
            {
                form.Text = "Add Leave";
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadAllLeaveList();
                }
            }
        }
        
        private void Search(object? sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(_view.SearchValue);
            LoadAllLeaveList(emptyValue);
        }
        private void Edit(object? sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is LeaveViewModel row)
            {
                var entity = _unitOfWork.Leave.Value.Get(c => c.LeaveId == row.LeaveId);
                using (var form = new UpsertLeaveView(_unitOfWork,entity))
                {
                    form.Text = "Edit Leave";
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadAllLeaveList();
                    }
                }
            }
        }
        private void Delete(object? sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is LeaveViewModel row)
            {
                var entity = _unitOfWork.Leave.Value.Get(c => c.LeaveId == row.LeaveId);
                if (entity != null)
                {
                    _unitOfWork.Leave.Value.Remove(entity);
                    _unitOfWork.Save();

                    _view.ShowMessage("Leave deleted successfully.");

                    LoadAllLeaveList();
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

                var selected = _view.DataGrid.SelectedItems.Cast<LeaveViewModel>().ToList(); // If you're using view models
                var ids = selected.Select(b => b.LeaveId).ToList();

                var entities = _unitOfWork.Leave.Value
                    .GetAll()
                    .Where(b => ids.Contains(b.LeaveId))
                    .ToList();

                if (!entities.Any())
                {
                    _view.ShowMessage("Selected records could not be found.");
                    return;
                }

                _unitOfWork.Leave.Value.RemoveRange(entities);
                _unitOfWork.Save();

                _view.ShowMessage($"{entities.Count} entries deleted successfully.");
                LoadAllLeaveList();
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"An error occurred while deleting: {ex.Message}");
            }
        }

        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "LeaveReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports", "Accounting", "Payroll");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("Leave", LeaveList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        
        private void LoadAllLeaveList(bool emptyValue = false)
        {
            LeaveList = Program.Mapper.Map<IEnumerable<LeaveViewModel>>(_unitOfWork.Leave.Value.GetAll(includeProperties: "Employee"));

            if (!emptyValue) LeaveList = LeaveList.Where(c => c.Employee.Contains(_view.SearchValue));
            _view.SetLeaveListBindingSource(LeaveList.OrderByDescending(c => c.StartDate));
        }
    }
}
