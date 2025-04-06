using DomainLayer.Models.Accounting.Payroll;
using DomainLayer.Models.Inventory;

using DomainLayer.ViewModels.Inventory;
using DomainLayer.ViewModels.PayrollViewModels;
using Microsoft.Reporting.WinForms;
using PresentationLayer;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using RevenTech_ERP.Views.IViews.Accounting.Payroll;
using ServiceLayer.Services.IRepositories;

namespace RevenTech_ERP.Presenters.Accounting.Payroll
{
    public class ShiftPresenter
    {
        public IShiftView _view;
        private IUnitOfWork _unitOfWork;
        private IEnumerable<ShiftViewModel> ShiftList;
        public ShiftPresenter(IShiftView view, IUnitOfWork unitOfWork)
        {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;

            //Events
            _view.AddNewEvent += AddNew;
            _view.SaveEvent += Save;
            _view.SearchEvent += Search;
            _view.EditEvent += Edit;
            _view.DeleteEvent += Delete;
            _view.PrintEvent += Print;
            _view.RefreshEvent += Return;

            //Load

            LoadAllShiftList();

            //Source Binding
        }

        private void AddNew(object? sender, EventArgs e)
        {
            _view.IsEdit = false;
            CleanviewFields();
        }
        private async void Save(object? sender, EventArgs e)
        {
            var model = await _unitOfWork.Shift.Value.GetAsync(c => c.ShiftId == _view.ShiftId, tracked: true);

            if (model == null) model = new Shift();
            else _unitOfWork.Shift.Value.Detach(model);

            model.ShiftId = _view.ShiftId;
            model.ShiftName = _view.ShiftName;
            model.StartTime = _view.StartTime;
            model.EndTime = _view.EndTime;
            model.OvertimeRate = _view.OvertimeRate;
            model.RegularHours = _view.RegularHours;

            try
            {
                new ModelDataValidation().Validate(model);
                if (_view.IsEdit)//Edit model
                {

                    _unitOfWork.Shift.Value.Update(model);
                    _view.Message = "Shift edited successfully";
                }
                else //Add new model
                {
                    var Entity = _unitOfWork.Shift.Value.Get(c => c.ShiftName == _view.ShiftName);
                    if (Entity != null)
                    {
                        _view.Message = "Shift is already added.";
                        return;
                    }
                    await _unitOfWork.Shift.Value.AddAsync(model);
                    _view.Message = "Shift added successfully";
                }
                await _unitOfWork.SaveAsync();
                _view.IsSuccessful = true;
                _view.ShowMessage(_view.Message);
                CleanviewFields();
            }
            catch (Exception ex)
            {
                _view.IsSuccessful = false;
                _view.Message = ex.Message;
            }
        }
        private void Search(object? sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(_view.SearchValue);
            LoadAllShiftList(emptyValue);
        }
        private void Edit(object? sender, EventArgs e)
        {
            _view.IsEdit = true;
            if (_view.DataGrid.SelectedItem == null)
            {
                _view.IsSuccessful = false;
                _view.Message = "Please select one to edit";
                return;
            }

            var shift = (ShiftViewModel)_view.DataGrid.SelectedItem;
            var entity = _unitOfWork.Shift.Value.Get(c => c.ShiftId == shift.ShiftId);
            _view.ShiftId = entity.ShiftId;
            _view.ShiftName = entity.ShiftName;
            _view.StartTime = entity.StartTime;
            _view.EndTime = entity.EndTime;
            _view.OvertimeRate = entity.OvertimeRate;
            _view.RegularHours = entity.RegularHours;
        }
        private void Delete(object? sender, EventArgs e)
        {
            try
            {
                if (_view.DataGrid.SelectedItems == null || _view.DataGrid.SelectedItems.Count == 0)
                {
                    _view.IsSuccessful = false;
                    _view.Message = "Please select shift(s) to delete.";
                    _view.ShowMessage(_view.Message);
                    return;
                }

                var selectedShifts = _view.DataGrid.SelectedItems.Cast<ShiftViewModel>().ToList();
                var ids = selectedShifts.Select(s => s.ShiftId).ToList();

                var entities = _unitOfWork.Shift.Value
                    .GetAll()
                    .Where(s => ids.Contains(s.ShiftId))
                    .ToList();

                if (!entities.Any())
                {
                    _view.IsSuccessful = false;
                    _view.Message = "Selected shift(s) could not be found.";
                    _view.ShowMessage(_view.Message);
                    return;
                }

                _unitOfWork.Shift.Value.RemoveRange(entities);
                _unitOfWork.Save();

                _view.IsSuccessful = true;
                _view.Message = $"{entities.Count} shift(s) deleted successfully.";
                _view.ShowMessage(_view.Message);
                LoadAllShiftList();
            }
            catch (Exception ex)
            {
                _view.IsSuccessful = false;
                _view.Message = $"An error occurred while deleting: {ex.Message}";
                _view.ShowMessage(_view.Message);
            }
        }

        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "ShiftReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports", "Accounting", "Payroll");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("Shift", ShiftList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        private void Return(object? sender, EventArgs e)
        {
            LoadAllShiftList();
        }
        private void CleanviewFields()
        {
            LoadAllShiftList();
            _view.ShiftId = 0;
            _view.ShiftName = "";
        }

        private void LoadAllShiftList(bool emptyValue = false)
        {
            ShiftList = Program.Mapper.Map<IEnumerable<ShiftViewModel>>(_unitOfWork.Shift.Value.GetAll());

            if (!emptyValue) ShiftList = ShiftList.Where(c => c.ShiftName.Contains(_view.SearchValue));
            _view.SetShiftListBindingSource(ShiftList);
        }
    }
}
