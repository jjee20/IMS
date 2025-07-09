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
    public class ExamTopicPresenter
    {
        public IExamTopicView _view;
        private readonly IUnitOfWork _unitOfWork;
        private IEnumerable<ExamTopicViewModel> ExamTopicList;
        public ExamTopicPresenter(IExamTopicView view, IUnitOfWork unitOfWork) {

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

            LoadAllExamTopicList();

            //Source Binding
        }

        private void AddNew(object? sender, EventArgs e)
        {
            using (var form = new UpsertExamTopicView(_unitOfWork))
            {
                form.Text = "Add Exam Topic";
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadAllExamTopicList();
                }
            }
        }
        
        private void Search(object? sender, EventArgs e)
        {
            var emptyValue = string.IsNullOrWhiteSpace(_view.SearchValue);
            LoadAllExamTopicList(emptyValue);
        }
        private void Edit(object? sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is ExamTopicViewModel row)
            {
                var entity = _unitOfWork.ExamTopic.Value.Get(c => c.ExamTopicId == row.ExamTopicId);
                using (var form = new UpsertExamTopicView(_unitOfWork,entity))
                {
                    form.Text = "Edit Exam Topic";
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadAllExamTopicList();
                    }
                }
            }
        }
        private void Delete(object? sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is ExamTopicViewModel row)
            {
                var entity = _unitOfWork.ExamTopic.Value.Get(c => c.ExamTopicId == row.ExamTopicId);
                if (entity != null)
                {
                    _unitOfWork.ExamTopic.Value.Detach(entity);
                    _unitOfWork.ExamTopic.Value.Remove(entity);
                    _unitOfWork.Save();

                    _view.ShowMessage("Exam Topic deleted successfully.");

                    LoadAllExamTopicList();
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

                var selected = _view.DataGrid.SelectedItems.Cast<ExamTopicViewModel>().ToList(); // If you're using view models
                var ids = selected.Select(b => b.ExamTopicId).ToList();

                var entities = _unitOfWork.ExamTopic.Value
                    .GetAll()
                    .Where(b => ids.Contains(b.ExamTopicId))
                    .ToList();

                if (!entities.Any())
                {
                    _view.ShowMessage("Selected records could not be found.");
                    return;
                }

                _unitOfWork.ExamTopic.Value.RemoveRange(entities);
                _unitOfWork.Save();

                _view.ShowMessage($"{entities.Count} entries deleted successfully.");
                LoadAllExamTopicList();
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"An error occurred while deleting: {ex.Message}");
            }
        }

        private void Print(object? sender, EventArgs e)
        {
            var reportFileName = "ExamTopicReport.rdlc";
            var reportDirectory = Path.Combine(Application.StartupPath, "Reports", "Inventory");
            var reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("ExamTopic", ExamTopicList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        
        private async void LoadAllExamTopicList(bool emptyValue = false)
        {
            ExamTopicList = Program.Mapper.Map<IEnumerable<ExamTopicViewModel>>(await _unitOfWork.ExamTopic.Value.GetAllAsync(includeProperties: "ReviewTopic"));

            if (!emptyValue) ExamTopicList = ExamTopicList.Where(c => c.Name.ToLower().Contains(_view.SearchValue.ToLower()));
            _view.SetExamTopicListBindingSource(ExamTopicList);
        }
    }
}
