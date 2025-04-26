using Microsoft.Reporting.WinForms;
using PresentationLayer.Reports;
using ServiceLayer.Services.IRepositories;
using Syncfusion.WinForms.DataGrid.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenTech_ERP.Helpers
{
    public abstract class BaseCrudPresenter<TViewModel, TEntity> where TEntity : class
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected IEnumerable<TViewModel> _viewModelList = new List<TViewModel>();

        public BaseCrudPresenter(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected abstract IEnumerable<TEntity> GetEntities();
        protected abstract object GetEntityKey(TViewModel viewModel);
        protected abstract Form CreateUpsertForm(TEntity? entity = null);
        protected abstract string GetReportDataSetName();
        protected abstract string GetReportFileName();
        protected abstract string GetReportFolder();
        protected abstract string GetItemName();

        protected virtual void AddNew(object? sender, EventArgs e)
        {
            using var form = CreateUpsertForm();
            form.Text = $"Add {GetItemName()}";
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadAllData();
            }
        }

        protected virtual void Edit(object? sender, CellClickEventArgs e)
        {
            if (e.DataRow?.RowType == Syncfusion.WinForms.DataGrid.Enums.RowType.DefaultRow && e.DataRow.RowData is TViewModel viewModel)
            {
                var key = GetEntityKey(viewModel);
                var entity = GetEntities().FirstOrDefault(x => GetEntityKey(viewModel).Equals(GetEntityKey(viewModel)));

                using var form = CreateUpsertForm(entity);
                form.Text = $"Edit {GetItemName()}";
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadAllData();
                }
            }
        }

        protected virtual void Delete(object? sender, CellClickEventArgs e)
        {
            if (e.DataRow.RowData is TViewModel viewModel)
            {
                var key = GetEntityKey(viewModel);
                var entity = GetEntities().FirstOrDefault(x => GetEntityKey(viewModel).Equals(GetEntityKey(viewModel)));

                if (entity != null)
                {
                    RemoveEntity(entity);
                    _unitOfWork.Save();
                    ShowMessage($"{GetItemName()} deleted successfully.");
                    LoadAllData();
                }
            }
        }

        protected virtual void MultipleDelete(object? sender, EventArgs e, IList<TViewModel> selectedItems)
        {
            var keys = selectedItems.Select(GetEntityKey).ToList();
            var entities = GetEntities().Where(e => keys.Contains(GetEntityKeyFromEntity(e))).ToList();

            if (!entities.Any())
            {
                ShowMessage("Selected records could not be found.");
                return;
            }

            RemoveEntities(entities);
            _unitOfWork.Save();

            ShowMessage($"{entities.Count} {GetItemName()}(s) deleted successfully.");
            LoadAllData();
        }

        protected virtual void Print(string reportTitle)
        {
            string reportPath = Path.Combine(Application.StartupPath, "Reports", GetReportFolder(), GetReportFileName());
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource(GetReportDataSetName(), _viewModelList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.Text = reportTitle;
            reportView.ShowDialog();
        }

        protected abstract void LoadAllData();
        protected abstract void ShowMessage(string message);
        protected abstract void RemoveEntity(TEntity entity);
        protected abstract void RemoveEntities(IEnumerable<TEntity> entities);
        protected abstract object GetEntityKeyFromEntity(TEntity entity);
    }
}
