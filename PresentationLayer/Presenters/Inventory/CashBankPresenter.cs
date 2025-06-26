using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels;
using DomainLayer.ViewModels.InventoryViewModels;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using PresentationLayer.Views.UserControls;
using RavenTech_ERP.Views.UserControls.Inventory;
using ServiceLayer.Services.IRepositories;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGrid.Events;
using System.Linq;
using static Unity.Storage.RegistrationSet;

namespace PresentationLayer.Presenters
{
    public class CashBankPresenter
    {
        public ICashBankView _view;
        private IUnitOfWork _unitOfWork;
        private IEnumerable<CashBankViewModel> CashBankList;
        public CashBankPresenter(ICashBankView view, IUnitOfWork unitOfWork) {

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

            LoadAllCashBankList();

            //Source Binding
        }

        private void AddNew(object? sender, EventArgs e)
        {
            using (var form = new UpsertCashBankView(_unitOfWork))
            {
                form.Text = "Add CashBank";
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadAllCashBankList();
                }
            }
        }
        
        private void Search(object? sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(_view.SearchValue);
            LoadAllCashBankList(emptyValue);
        }
        private void Edit(object? sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is CashBankViewModel row)
            {
                var entity = _unitOfWork.CashBank.Value.Get(c => c.CashBankId == row.CashBankId);
                using (var form = new UpsertCashBankView(_unitOfWork,entity))
                {
                    form.Text = "Edit CashBank";
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadAllCashBankList();
                    }
                }
            }
        }
        private void Delete(object? sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is CashBankViewModel row)
            {
                var entity = _unitOfWork.CashBank.Value.Get(c => c.CashBankId == row.CashBankId);
                if (entity != null)
                {
                    _unitOfWork.CashBank.Value.Remove(entity);
                    _unitOfWork.Save();

                    _view.ShowMessage("CashBank deleted successfully.");

                    LoadAllCashBankList();
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

                var selected = _view.DataGrid.SelectedItems.Cast<CashBankViewModel>().ToList(); // If you're using view models
                var ids = selected.Select(b => b.CashBankId).ToList();

                var entities = _unitOfWork.CashBank.Value
                    .GetAll()
                    .Where(b => ids.Contains(b.CashBankId))
                    .ToList();

                if (!entities.Any())
                {
                    _view.ShowMessage("Selected records could not be found.");
                    return;
                }

                _unitOfWork.CashBank.Value.RemoveRange(entities);
                _unitOfWork.Save();

                _view.ShowMessage($"{entities.Count} entries deleted successfully.");
                LoadAllCashBankList();
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"An error occurred while deleting: {ex.Message}");
            }
        }

        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "CashBankReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports", "Inventory");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("CashBank", CashBankList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }

        private async void LoadAllCashBankList(bool emptyValue = false)
        {
            CashBankList = Program.Mapper.Map<IEnumerable<CashBankViewModel>>(await _unitOfWork.CashBank.Value.GetAllAsync());

            if (!emptyValue) CashBankList = CashBankList.Where(c => c.CashBankName.ToLower().Contains(_view.SearchValue.ToLower()));
            _view.SetCashBankListBindingSource(CashBankList);
        }
    }
}
