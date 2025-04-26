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
    public class ShiftPresenter
    {
        public IShiftView _view;
        private IUnitOfWork _unitOfWork;
        private IEnumerable<ShiftViewModel> ShiftList;
        public ShiftPresenter(IShiftView view, IUnitOfWork unitOfWork) {

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

            LoadAllShiftList();

            //Source Binding
        }

        private void AddNew(object? sender, EventArgs e)
        {
            using (var form = new UpsertShiftView(_unitOfWork))
            {
                form.Text = "Add Shift";
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadAllShiftList();
                }
            }
        }
        
        private void Search(object? sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(_view.SearchValue);
            LoadAllShiftList(emptyValue);
        }
        private void Edit(object? sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is ShiftViewModel row)
            {
                var entity = _unitOfWork.Shift.Value.Get(c => c.ShiftId == row.ShiftId);
                using (var form = new UpsertShiftView(_unitOfWork,entity))
                {
                    form.Text = "Edit Shift";
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadAllShiftList();
                    }
                }
            }
        }
        private void Delete(object? sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is ShiftViewModel row)
            {
                var entity = _unitOfWork.Shift.Value.Get(c => c.ShiftId == row.ShiftId);
                if (entity != null)
                {
                    _unitOfWork.Shift.Value.Remove(entity);
                    _unitOfWork.Save();

                    _view.ShowMessage("Shift deleted successfully.");

                    LoadAllShiftList();
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

                var selected = _view.DataGrid.SelectedItems.Cast<ShiftViewModel>().ToList(); // If you're using view models
                var ids = selected.Select(b => b.ShiftId).ToList();

                var entities = _unitOfWork.Shift.Value
                    .GetAll()
                    .Where(b => ids.Contains(b.ShiftId))
                    .ToList();

                if (!entities.Any())
                {
                    _view.ShowMessage("Selected records could not be found.");
                    return;
                }

                _unitOfWork.Shift.Value.RemoveRange(entities);
                _unitOfWork.Save();

                _view.ShowMessage($"{entities.Count} entries deleted successfully.");
                LoadAllShiftList();
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"An error occurred while deleting: {ex.Message}");
            }
        }

        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "ShiftReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports", "Accounting", "Payroll");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("Shift", ShiftList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        
        private void LoadAllShiftList(bool emptyValue = false)
        {
            ShiftList = Program.Mapper.Map<IEnumerable<ShiftViewModel>>(_unitOfWork.Shift.Value.GetAll());

            if (!emptyValue) ShiftList = ShiftList.Where(c => c.ShiftName.ToLower().Contains(_view.SearchValue.ToLower()));
            _view.SetShiftListBindingSource(ShiftList);
        }
    }
}
