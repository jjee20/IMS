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
    public class ExamPresenter
    {
        public IExamView _view;
        private readonly IUnitOfWork _unitOfWork;
        private IEnumerable<ExamViewModel> ExamList;
        public ExamPresenter(IExamView view, IUnitOfWork unitOfWork) {

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

            LoadAllExamList();

            //Source Binding
        }

        private void AddNew(object? sender, EventArgs e)
        {
            using (var form = new UpsertExamView(_unitOfWork))
            {
                form.Text = "Add Exam";
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadAllExamList();
                }
            }
        }
        
        private void Search(object? sender, EventArgs e)
        {
            var emptyValue = string.IsNullOrWhiteSpace(_view.SearchValue);
            LoadAllExamList(emptyValue);
        }
        private void Edit(object? sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is ExamViewModel row)
            {
                var entity = _unitOfWork.Exam.Value.Get(c => c.ExamId == row.ExamId, includeProperties: "ExamFormat,Questions.Choices");
                using (var form = new UpsertExamView(_unitOfWork,entity))
                {
                    form.Text = "Edit Exam";
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadAllExamList();
                    }
                }
            }
        }
        private void Delete(object? sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is ExamViewModel row)
            {
                var entity = _unitOfWork.Exam.Value.Get(c => c.ExamId == row.ExamId);
                if (entity != null)
                {
                    _unitOfWork.Exam.Value.Detach(entity);
                    _unitOfWork.Exam.Value.Remove(entity);
                    _unitOfWork.Save();

                    _view.ShowMessage("Exam deleted successfully.");

                    LoadAllExamList();
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

                var selected = _view.DataGrid.SelectedItems.Cast<ExamViewModel>().ToList(); // If you're using view models
                var ids = selected.Select(b => b.ExamId).ToList();

                var entities = _unitOfWork.Exam.Value
                    .GetAll()
                    .Where(b => ids.Contains(b.ExamId))
                    .ToList();

                if (!entities.Any())
                {
                    _view.ShowMessage("Selected records could not be found.");
                    return;
                }

                _unitOfWork.Exam.Value.RemoveRange(entities);
                _unitOfWork.Save();

                _view.ShowMessage($"{entities.Count} entries deleted successfully.");
                LoadAllExamList();
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"An error occurred while deleting: {ex.Message}");
            }
        }

        private void Print(object? sender, EventArgs e)
        {
            var reportFileName = "ExamReport.rdlc";
            var reportDirectory = Path.Combine(Application.StartupPath, "Reports", "Inventory");
            var reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("Exam", ExamList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        
        private async void LoadAllExamList(bool emptyValue = false)
        {
            ExamList = Program.Mapper.Map<IEnumerable<ExamViewModel>>(await _unitOfWork.Exam.Value.GetAllAsync(includeProperties:"ExamFormat,Questions.Choices"));

            if (!emptyValue) ExamList = ExamList.Where(c => c.Title.ToLower().Contains(_view.SearchValue.ToLower()));
            _view.SetExamListBindingSource(ExamList);
        }
    }
}
