using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels.InventoryViewModels;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using RavenTech_ERP.Views.IViews.Inventory;
using RavenTech_ERP.Views.UserControls.Inventory;
using ServiceLayer.Services.IRepositories;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGrid.Events;
using System.Linq;
using static Unity.Storage.RegistrationSet;

namespace PresentationLayer.Presenters
{
    public class SalesTypePresenter
    {
        public ISalesTypeView _view;
        private readonly IUnitOfWork _unitOfWork;
        private IEnumerable<SalesTypeViewModel> SalesTypeList;
        public SalesTypePresenter(ISalesTypeView view, IUnitOfWork unitOfWork) {

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

            LoadAllSalesTypeList();

            //Source Binding
        }

        private void AddNew(object? sender, EventArgs e)
        {
            using (var form = new UpsertSalesTypeView(_unitOfWork))
            {
                form.Text = "Add Sales Type";
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadAllSalesTypeList();
                }
            }
        }
        
        private void Search(object? sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(_view.SearchValue);
            LoadAllSalesTypeList(emptyValue);
        }
        private void Edit(object? sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is SalesTypeViewModel row)
            {
                var entity = _unitOfWork.SalesType.Value.Get(c => c.SalesTypeId == row.SalesTypeId);
                using (var form = new UpsertSalesTypeView(_unitOfWork,entity))
                {
                    form.Text = "Edit Sales Type";
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadAllSalesTypeList();
                    }
                }
            }
        }
        private void Delete(object? sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is SalesTypeViewModel row)
            {
                var entity = _unitOfWork.SalesType.Value.Get(c => c.SalesTypeId == row.SalesTypeId);
                if (entity != null)
                {
                    _unitOfWork.SalesType.Value.Remove(entity);
                    _unitOfWork.Save();

                    _view.ShowMessage("Sales Type deleted successfully.");

                    LoadAllSalesTypeList();
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

                var selected = _view.DataGrid.SelectedItems.Cast<SalesTypeViewModel>().ToList(); // If you're using view models
                var ids = selected.Select(b => b.SalesTypeId).ToList();

                var entities = _unitOfWork.SalesType.Value
                    .GetAll()
                    .Where(b => ids.Contains(b.SalesTypeId))
                    .ToList();

                if (!entities.Any())
                {
                    _view.ShowMessage("Selected records could not be found.");
                    return;
                }

                _unitOfWork.SalesType.Value.RemoveRange(entities);
                _unitOfWork.Save();

                _view.ShowMessage($"{entities.Count} entries deleted successfully.");
                LoadAllSalesTypeList();
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"An error occurred while deleting: {ex.Message}");
            }
        }

        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "SalesTypeReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports", "Inventory");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("SalesType", SalesTypeList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        
        private async void LoadAllSalesTypeList(bool emptyValue = false)
        {
            SalesTypeList = Program.Mapper.Map<IEnumerable<SalesTypeViewModel>>(await _unitOfWork.SalesType.Value.GetAllAsync());

            if (!emptyValue) SalesTypeList = SalesTypeList.Where(c => c.SalesTypeName.ToLower().Contains(_view.SearchValue.ToLower()));
            _view.SetSalesTypeListBindingSource(SalesTypeList);
        }
    }
}
