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
    public class ReviewTopicPresenter
    {
        public IReviewTopicView _view;
        private readonly IUnitOfWork _unitOfWork;
        private IEnumerable<ReviewTopicViewModel> ReviewTopicList;
        public ReviewTopicPresenter(IReviewTopicView view, IUnitOfWork unitOfWork) {

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

            LoadAllReviewTopicList();

            //Source Binding
        }

        private void AddNew(object? sender, EventArgs e)
        {
            using (var form = new UpsertReviewTopicView(_unitOfWork))
            {
                form.Text = "Add Review Topic";
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadAllReviewTopicList();
                }
            }
        }
        
        private void Search(object? sender, EventArgs e)
        {
            var emptyValue = string.IsNullOrWhiteSpace(_view.SearchValue);
            LoadAllReviewTopicList(emptyValue);
        }
        private void Edit(object? sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is ReviewTopicViewModel row)
            {
                var entity = _unitOfWork.ReviewTopic.Value.Get(c => c.ReviewTopicId == row.ReviewTopicId);
                using (var form = new UpsertReviewTopicView(_unitOfWork,entity))
                {
                    form.Text = "Edit Review Topic";
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadAllReviewTopicList();
                    }
                }
            }
        }
        private void Delete(object? sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is ReviewTopicViewModel row)
            {
                var entity = _unitOfWork.ReviewTopic.Value.Get(c => c.ReviewTopicId == row.ReviewTopicId);
                if (entity != null)
                {
                    _unitOfWork.ReviewTopic.Value.Detach(entity);
                    _unitOfWork.ReviewTopic.Value.Remove(entity);
                    _unitOfWork.Save();

                    _view.ShowMessage("Review Topic deleted successfully.");

                    LoadAllReviewTopicList();
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

                var selected = _view.DataGrid.SelectedItems.Cast<ReviewTopicViewModel>().ToList(); // If you're using view models
                var ids = selected.Select(b => b.ReviewTopicId).ToList();

                var entities = _unitOfWork.ReviewTopic.Value
                    .GetAll()
                    .Where(b => ids.Contains(b.ReviewTopicId))
                    .ToList();

                if (!entities.Any())
                {
                    _view.ShowMessage("Selected records could not be found.");
                    return;
                }

                _unitOfWork.ReviewTopic.Value.RemoveRange(entities);
                _unitOfWork.Save();

                _view.ShowMessage($"{entities.Count} entries deleted successfully.");
                LoadAllReviewTopicList();
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"An error occurred while deleting: {ex.Message}");
            }
        }

        private void Print(object? sender, EventArgs e)
        {
            var reportFileName = "ReviewTopicReport.rdlc";
            var reportDirectory = Path.Combine(Application.StartupPath, "Reports", "Inventory");
            var reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("ReviewTopic", ReviewTopicList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        
        private async void LoadAllReviewTopicList(bool emptyValue = false)
        {
            ReviewTopicList = Program.Mapper.Map<IEnumerable<ReviewTopicViewModel>>(await _unitOfWork.ReviewTopic.Value.GetAllAsync());

            if (!emptyValue) ReviewTopicList = ReviewTopicList.Where(c => c.Name.ToLower().Contains(_view.SearchValue.ToLower()));
            _view.SetReviewTopicListBindingSource(ReviewTopicList);
        }
    }
}
