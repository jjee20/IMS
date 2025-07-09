using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels.InventoryViewModels;
using DomainLayer.ViewModels.ThinkEE;
using Microsoft.Reporting.WinForms;
using PresentationLayer;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using RavenTech_ERP.Views.IViews.ThinkEE;
using RavenTech_ERP.Views.UserControls.Inventory;
using ServiceLayer.Services.IRepositories;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGrid.Events;
using System.Linq;
using static Unity.Storage.RegistrationSet;

namespace RavenTech_ERP.Presenters.ThinkEE
{
    public class ExamFormatPresenter
    {
        public IExamFormatView _view;
        private readonly IUnitOfWork _unitOfWork;
        private IEnumerable<ExamFormatViewModel> ExamFormatList;
        public ExamFormatPresenter(IExamFormatView view, IUnitOfWork unitOfWork) {

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

            LoadAllExamFormatList();

            //Source Binding
        }

        private void AddNew(object? sender, EventArgs e)
        {
            using (var form = new UpsertExamFormatView(_unitOfWork))
            {
                form.Text = "Add Exam Format";
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadAllExamFormatList();
                }
            }
        }
        
        private void Search(object? sender, EventArgs e)
        {
            var emptyValue = string.IsNullOrWhiteSpace(_view.SearchValue);
            LoadAllExamFormatList(emptyValue);
        }
        private void Edit(object? sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is ExamFormatViewModel row)
            {
                var entity = _unitOfWork.ExamFormat.Value.Get(c => c.ExamFormatId == row.ExamFormatId);
                using (var form = new UpsertExamFormatView(_unitOfWork,entity))
                {
                    form.Text = "Edit Exam Format";
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadAllExamFormatList();
                    }
                }
            }
        }
        private void Delete(object? sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is ExamFormatViewModel row)
            {
                var entity = _unitOfWork.ExamFormat.Value.Get(c => c.ExamFormatId == row.ExamFormatId);
                if (entity != null)
                {
                    _unitOfWork.ExamFormat.Value.Detach(entity);
                    _unitOfWork.ExamFormat.Value.Remove(entity);
                    _unitOfWork.Save();

                    _view.ShowMessage("Exam Format deleted successfully.");

                    LoadAllExamFormatList();
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

                var selected = _view.DataGrid.SelectedItems.Cast<ExamFormatViewModel>().ToList(); // If you're using view models
                var ids = selected.Select(b => b.ExamFormatId).ToList();

                var entities = _unitOfWork.ExamFormat.Value
                    .GetAll()
                    .Where(b => ids.Contains(b.ExamFormatId))
                    .ToList();

                if (!entities.Any())
                {
                    _view.ShowMessage("Selected records could not be found.");
                    return;
                }

                _unitOfWork.ExamFormat.Value.RemoveRange(entities);
                _unitOfWork.Save();

                _view.ShowMessage($"{entities.Count} entries deleted successfully.");
                LoadAllExamFormatList();
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"An error occurred while deleting: {ex.Message}");
            }
        }

        private void Print(object? sender, EventArgs e)
        {
            var reportFileName = "ExamFormatReport.rdlc";
            var reportDirectory = Path.Combine(Application.StartupPath, "Reports", "Inventory");
            var reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("ExamFormat", ExamFormatList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        
        private async void LoadAllExamFormatList(bool emptyValue = false)
        {
            ExamFormatList = Program.Mapper.Map<IEnumerable<ExamFormatViewModel>>(await _unitOfWork.ExamFormat.Value.GetAllAsync());

            if (!emptyValue) ExamFormatList = ExamFormatList.Where(c => c.Name.ToLower().Contains(_view.SearchValue.ToLower()));
            _view.SetExamFormatListBindingSource(ExamFormatList);
        }
    }
}
