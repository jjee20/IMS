using DomainLayer.ViewModels.PayrollViewModels;
using Microsoft.Reporting.WinForms;
using PresentationLayer;
using PresentationLayer.Reports;
using RavenTech_ERP.Views.IViews.Accounting.Payroll;
using RavenTech_ERP.Views.UserControls.Inventory;
using ServiceLayer.Services.IRepositories;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGrid.Events;

namespace RavenTech_ERP.Presenters.Accounting.Payroll
{
    public class HolidayPresenter
    {
        public IHolidayView _view;
        private IUnitOfWork _unitOfWork;
        private IEnumerable<HolidayViewModel> HolidayList;
        public HolidayPresenter(IHolidayView view, IUnitOfWork unitOfWork)
        {

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

            LoadAllHolidayList();

            //Source Binding
        }

        private void AddNew(object? sender, EventArgs e)
        {
            using (var form = new UpsertHolidayView(_unitOfWork))
            {
                form.Text = "Add Holiday";
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadAllHolidayList();
                }
            }
        }

        private void Search(object? sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(_view.SearchValue);
            LoadAllHolidayList(emptyValue);
        }
        private void Edit(object? sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is HolidayViewModel row)
            {
                var entity = _unitOfWork.Holiday.Value.Get(c => c.HolidayId == row.HolidayId);
                using (var form = new UpsertHolidayView(_unitOfWork, entity))
                {
                    form.Text = "Edit Holiday";
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadAllHolidayList();
                    }
                }
            }
        }
        private void Delete(object? sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is HolidayViewModel row)
            {
                var entity = _unitOfWork.Holiday.Value.Get(c => c.HolidayId == row.HolidayId);
                if (entity != null)
                {
                    _unitOfWork.Holiday.Value.Remove(entity);
                    _unitOfWork.Save();

                    _view.ShowMessage("Holiday deleted successfully.");

                    LoadAllHolidayList();
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

                var selected = _view.DataGrid.SelectedItems.Cast<HolidayViewModel>().ToList(); // If you're using view models
                var ids = selected.Select(b => b.HolidayId).ToList();

                var entities = _unitOfWork.Holiday.Value
                    .GetAll()
                    .Where(b => ids.Contains(b.HolidayId))
                    .ToList();

                if (!entities.Any())
                {
                    _view.ShowMessage("Selected records could not be found.");
                    return;
                }

                _unitOfWork.Holiday.Value.RemoveRange(entities);
                _unitOfWork.Save();

                _view.ShowMessage($"{entities.Count} entries deleted successfully.");
                LoadAllHolidayList();
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"An error occurred while deleting: {ex.Message}");
            }
        }

        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "HolidayReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports", "Accounting", "Payroll");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("Holiday", HolidayList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }

        private void LoadAllHolidayList(bool emptyValue = false)
        {
            HolidayList = Program.Mapper.Map<IEnumerable<HolidayViewModel>>(_unitOfWork.Holiday.Value.GetAll());

            if (!emptyValue) HolidayList = HolidayList.Where(c => c.HolidayName.ToLower().Contains(_view.SearchValue.ToLower()));
            _view.SetHolidayListBindingSource(HolidayList.OrderBy(c => c.EffectiveDate));
        }
    }
}