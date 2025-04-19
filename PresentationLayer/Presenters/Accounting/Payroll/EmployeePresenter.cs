using DomainLayer.ViewModels.PayrollViewModels;
using Microsoft.Reporting.WinForms;
using PresentationLayer;
using PresentationLayer.Reports;
using RavenTech_ERP.Views.IViews.Accounting;
using RavenTech_ERP.Views.IViews.Accounting.Payroll;
using RavenTech_ERP.Views.UserControls.Account;
using RavenTech_ERP.Views.UserControls.Inventory;
using ServiceLayer.Services.IRepositories;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGrid.Events;

namespace RavenTech_ERP.Presenters.Accounting.Payroll
{
    public class EmployeePresenter
    {
        public IEmployeeView _view;
        private IUnitOfWork _unitOfWork;
        private IEnumerable<EmployeeViewModel> EmployeeList;
        public EmployeePresenter(IEmployeeView view, IUnitOfWork unitOfWork) {

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
            _view.DetailsEvent += Details;

            //Load

            LoadAllEmployeeList();

            //Source Binding
        }

        private void Details(object sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is EmployeeViewModel row)
            {
                var entity = Program.Mapper.Map<UserInformationViewModel>(_unitOfWork.Employee.Value.Get(c => c.EmployeeId == row.EmployeeId));
                using var form = new EmployeeInformationView(entity);
                form.ShowDialog();
            }
        }

        private void AddNew(object? sender, EventArgs e)
        {
            using (var form = new UpsertEmployeeView(_unitOfWork))
            {
                form.Text = "Add Employee";
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadAllEmployeeList();
                }
            }
        }
        
        private void Search(object? sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(_view.SearchValue);
            LoadAllEmployeeList(emptyValue);
        }
        private void Edit(object? sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is EmployeeViewModel row)
            {
                var entity = _unitOfWork.Employee.Value.Get(c => c.EmployeeId == row.EmployeeId);
                using (var form = new UpsertEmployeeView(_unitOfWork,entity))
                {
                    form.Text = "Edit Employee";
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadAllEmployeeList();
                    }
                }
            }
        }
        private void Delete(object? sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is EmployeeViewModel row)
            {
                var entity = _unitOfWork.Employee.Value.Get(c => c.EmployeeId == row.EmployeeId);
                if (entity != null)
                {
                    _unitOfWork.Employee.Value.Remove(entity);
                    _unitOfWork.Save();

                    _view.ShowMessage("Employee deleted successfully.");

                    LoadAllEmployeeList();
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

                var selected = _view.DataGrid.SelectedItems.Cast<EmployeeViewModel>().ToList(); // If you're using view models
                var ids = selected.Select(b => b.EmployeeId).ToList();

                var entities = _unitOfWork.Employee.Value
                    .GetAll()
                    .Where(b => ids.Contains(b.EmployeeId))
                    .ToList();

                if (!entities.Any())
                {
                    _view.ShowMessage("Selected records could not be found.");
                    return;
                }

                _unitOfWork.Employee.Value.RemoveRange(entities);
                _unitOfWork.Save();

                _view.ShowMessage($"{entities.Count} entries deleted successfully.");
                LoadAllEmployeeList();
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"An error occurred while deleting: {ex.Message}");
            }
        }

        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "EmployeeReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports", "Accounting", "Payroll");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("Employee", EmployeeList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        
        private void LoadAllEmployeeList(bool emptyValue = false)
        {
            EmployeeList = Program.Mapper.Map<IEnumerable<EmployeeViewModel>>(_unitOfWork.Employee.Value.GetAll(includeProperties: "JobPosition,Department,Shift"));

            if (!emptyValue) EmployeeList = EmployeeList.Where(c => c.Name.ToLower().Contains(_view.SearchValue.ToLower()));
            _view.SetEmployeeListBindingSource(EmployeeList);
        }
    }
}
