using DomainLayer.Models.Accounts;
using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels.InventoryViewModels;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using RavenTech_ERP.Views.IViews.Inventory;
using RavenTech_ERP.Views.UserControls.Inventory;
using ServiceLayer.Services.CommonServices;
using ServiceLayer.Services.IRepositories;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGrid.Events;
using System.Linq;
using static ServiceLayer.Services.CommonServices.EventClasses;
using static Unity.Storage.RegistrationSet;

namespace PresentationLayer.Presenters
{
    public class CustomerTypePresenter
    {
        public ICustomerTypeView _view;
        private readonly IUnitOfWork _unitOfWork;
        private IEnumerable<CustomerTypeViewModel> CustomerTypeList;
        public CustomerTypePresenter(ICustomerTypeView view, IUnitOfWork unitOfWork) {

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

            LoadAllCustomerTypeList();

            //Source Binding
        }

        private void AddNew(object? sender, EventArgs e)
        {
            using (var form = new UpsertCustomerTypeView(_unitOfWork))
            {
                form.Text = "Add Customer Type";
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadAllCustomerTypeList();
                }
            }
        }
        
        private void Search(object? sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(_view.SearchValue);
            LoadAllCustomerTypeList(emptyValue);
        }
        private void Edit(object? sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is CustomerTypeViewModel row)
            {
                var entity = _unitOfWork.CustomerType.Value.Get(c => c.CustomerTypeId == row.CustomerTypeId);
                using (var form = new UpsertCustomerTypeView(_unitOfWork,entity))
                {
                    form.Text = "Edit Customer Type";
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadAllCustomerTypeList();
                    }
                }
            }
        }
        private void Delete(object? sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == RowType.DefaultRow && e.DataRow.RowData is CustomerTypeViewModel row)
            {
                var entity = _unitOfWork.CustomerType.Value.Get(c => c.CustomerTypeId == row.CustomerTypeId);
                if (entity != null)
                {
                    _unitOfWork.CustomerType.Value.Remove(entity);
                    _unitOfWork.Save();

                    _view.ShowMessage("Customer Type deleted successfully.");

                    LoadAllCustomerTypeList();
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

                var selected = _view.DataGrid.SelectedItems.Cast<CustomerTypeViewModel>().ToList(); // If you're using view models
                var ids = selected.Select(b => b.CustomerTypeId).ToList();

                var entities = _unitOfWork.CustomerType.Value
                    .GetAll()
                    .Where(b => ids.Contains(b.CustomerTypeId))
                    .ToList();

                if (!entities.Any())
                {
                    _view.ShowMessage("Selected records could not be found.");
                    return;
                }

                _unitOfWork.CustomerType.Value.RemoveRange(entities);
                _unitOfWork.Save();

                _view.ShowMessage($"{entities.Count} entries deleted successfully.");
                LoadAllCustomerTypeList();
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"An error occurred while deleting: {ex.Message}");
            }
        }

        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "CustomerTypeReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports", "Inventory");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("CustomerType", CustomerTypeList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }

        private async void LoadAllCustomerTypeList(bool emptyValue = false)
        {
            CustomerTypeList = Program.Mapper.Map<IEnumerable<CustomerTypeViewModel>>(await _unitOfWork.CustomerType.Value.GetAllAsync());

            if (!emptyValue) CustomerTypeList = CustomerTypeList.Where(c => c.CustomerTypeName.ToLower().Contains(_view.SearchValue.ToLower()));
            _view.SetCustomerTypeListBindingSource(CustomerTypeList);
        }
    }
}
