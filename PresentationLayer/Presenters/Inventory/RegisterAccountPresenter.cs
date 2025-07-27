using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels.AccountViewModels;
using DomainLayer.ViewModels.InventoryViewModels;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using RavenTech_ERP.Views.IViews.Account;
using RavenTech_ERP.Views.UserControls.Inventory;
using ServiceLayer.Services.IRepositories;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGrid.Events;
using System.Linq;
using static Unity.Storage.RegistrationSet;

namespace PresentationLayer.Presenters
{
    public class RegisterAccountPresenter
    {
        public IRegisterAccountView _view;
        private readonly IUnitOfWork _unitOfWork;
        private IEnumerable<AccountViewModel> RegisterAccountList;
        public RegisterAccountPresenter(IRegisterAccountView view, IUnitOfWork unitOfWork) {

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

            LoadAllAccountList();

            //Source Binding
        }

        private void AddNew(object? sender, EventArgs e)
        {
            using (var form = new UpsertRegisterAccountView(_unitOfWork))
            {
                form.Text = "Add Account";
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadAllAccountList();
                }
            }
        }
        
        private void Search(object? sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(_view.SearchValue);
            LoadAllAccountList(emptyValue);
        }
        private void Edit(object? sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is AccountViewModel row)
            {
                var entity = _unitOfWork.ApplicationUser.Value.Get(c => c.Id == row.Id);
                using (var form = new UpsertRegisterAccountView(_unitOfWork,entity))
                {
                    form.Text = "Edit Account";
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadAllAccountList();
                    }
                }
            }
        }
        private void Delete(object? sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is AccountViewModel row)
            {
                var entity = _unitOfWork.ApplicationUser.Value.Get(c => c.Id == row.Id);
                if (entity != null)
                {
                    _unitOfWork.ApplicationUser.Value.Detach(entity);
                    _unitOfWork.ApplicationUser.Value.Remove(entity);
                    _unitOfWork.Save();

                    _view.ShowMessage("Account deleted successfully.");

                    LoadAllAccountList();
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

                var selected = _view.DataGrid.SelectedItems.Cast<AccountViewModel>().ToList(); // If you're using view models
                var ids = selected.Select(b => b.Id).ToList();

                var entities = _unitOfWork.ApplicationUser.Value
                    .GetAll()
                    .Where(b => ids.Contains(b.Id))
                    .ToList();

                if (!entities.Any())
                {
                    _view.ShowMessage("Selected records could not be found.");
                    return;
                }

                _unitOfWork.ApplicationUser.Value.RemoveRange(entities);
                _unitOfWork.Save();

                _view.ShowMessage($"{entities.Count} entries deleted successfully.");
                LoadAllAccountList();
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"An error occurred while deleting: {ex.Message}");
            }
        }

        private void Print(object? sender, EventArgs e)
        {
            var reportFileName = "RegisterReport.rdlc";
            var reportDirectory = Path.Combine(Application.StartupPath, "Reports");
            var reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("Register", RegisterAccountList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        
        private async void LoadAllAccountList(bool emptyValue = false)
        {
            RegisterAccountList = Program.Mapper.Map<IEnumerable<AccountViewModel>>(await _unitOfWork.ApplicationUser.Value.GetAllAsync(includeProperties: "Profile"));

            if (!emptyValue) RegisterAccountList = RegisterAccountList.Where(c => c.Email.ToLower().Contains(_view.SearchValue.ToLower()));
            _view.SetRegisterAccountListBindingSource(RegisterAccountList);
        }
    }
}
