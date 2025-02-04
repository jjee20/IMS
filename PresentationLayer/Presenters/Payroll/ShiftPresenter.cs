using DomainLayer.Models.Inventory;
using DomainLayer.Models.Payroll;
using DomainLayer.ViewModels.Inventory;
using DomainLayer.ViewModels.PayrollViewModels;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using PresentationLayer.Views.IViews.Payroll;
using ServiceLayer.Services.IRepositories;

namespace PresentationLayer.Presenters.Payroll
{
    public class ShiftPresenter
    {
        public IShiftView _view;
        private IUnitOfWork _unitOfWork;
        private BindingSource ShiftBindingSource;
        private IEnumerable<ShiftViewModel> ShiftList;
        public ShiftPresenter(IShiftView view, IUnitOfWork unitOfWork)
        {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            ShiftBindingSource = new BindingSource();

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
            _view.SetShiftListBindingSource(ShiftBindingSource);
        }

        private void AddNew(object? sender, EventArgs e)
        {
            _view.IsEdit = false;
            CleanviewFields();
        }
        private void Save(object? sender, EventArgs e)
        {

            var model = new Shift
            {
                ShiftId = _view.ShiftId,
                ShiftName = _view.ShiftName,
                StartTime = _view.StartTime,
                EndTime = _view.EndTime,
                OvertimeRate = _view.OvertimeRate,
                RegularHours = _view.RegularHours,
            };

            try
            {
                new ModelDataValidation().Validate(model);
                if (_view.IsEdit)//Edit model
                {

                    _unitOfWork.Shift.Update(model);
                    _view.Message = "Shift edited successfully";
                }
                else //Add new model
                {
                    var Entity = _unitOfWork.Shift.Get(c => c.ShiftName == _view.ShiftName);
                    if (Entity != null)
                    {
                        _view.Message = "Shift is already added.";
                        return;
                    }
                    _unitOfWork.Shift.Add(model);
                    _view.Message = "Shift added successfully";
                }
                _unitOfWork.Save();
                _view.IsSuccessful = true;
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
            if (!emptyValue)
            {
                ShiftList = Program.Mapper.Map<IEnumerable<ShiftViewModel>>(_unitOfWork.Shift.GetAll(c => c.ShiftName.Contains(_view.SearchValue)));
                ShiftBindingSource.DataSource = ShiftList;
            }
            else
            {
                LoadAllShiftList();
            }
        }
        private void Edit(object? sender, EventArgs e)
        {
            _view.IsEdit = true;
            var shift = (ShiftViewModel)ShiftBindingSource.Current;
            var entity = _unitOfWork.Shift.Get(c => c.ShiftId == shift.ShiftId);    
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
                var shift = (ShiftViewModel)ShiftBindingSource.Current;
                var entity = _unitOfWork.Shift.Get(c => c.ShiftId == shift.ShiftId);
                _unitOfWork.Shift.Remove(entity);
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                _view.Message = "Shift deleted successfully";
                LoadAllShiftList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete Shift";
            }
        }
        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "ShiftReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports");
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

        private void LoadAllShiftList()
        {
            ShiftList = Program.Mapper.Map<IEnumerable<ShiftViewModel>>(_unitOfWork.Shift.GetAll());
            ShiftBindingSource.DataSource = ShiftList;//Set data source.
        }
    }
}
