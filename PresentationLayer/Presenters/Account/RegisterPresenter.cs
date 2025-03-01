using AutoMapper;
using DomainLayer.Enums;
using DomainLayer.Models.Accounting.Payroll;
using DomainLayer.Models.Accounts;
using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels;
using DomainLayer.ViewModels.AccountViewModels;
using DomainLayer.ViewModels.Inventory;
using Microsoft.AspNetCore.Identity;
using Microsoft.Reporting.WinForms;
using PresentationLayer.Presenters.Commons;
using PresentationLayer.Reports;
using PresentationLayer.Views.IViews;
using PresentationLayer.Views.IViews.Account;
using ServiceLayer.Services.CommonServices;
using ServiceLayer.Services.IRepositories.IInventory;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PresentationLayer.Presenters.Account
{
    public class RegisterPresenter
    {
        public IRegisterView _view;
        private IUnitOfWork _unitOfWork;
        private BindingSource RegisterBindingSource;
        private BindingSource DepartmentBindingSource;
        private IEnumerable<AccountViewModel> RegisterList;
        private IEnumerable<EnumItemViewModel> DepartmentList;
        private readonly PasswordHasher<ApplicationUser> _passwordHasher;
        public RegisterPresenter(IRegisterView view, IUnitOfWork unitOfWork)
        {

            //Initialize

            _view = view;
            _unitOfWork = unitOfWork;
            _passwordHasher = new PasswordHasher<ApplicationUser>();
            RegisterBindingSource = new BindingSource();
            DepartmentBindingSource = new BindingSource();

            //Events
            _view.AddNewEvent += AddNew;
            _view.SaveEvent += Save;
            _view.SearchEvent += Search;
            _view.EditEvent += Edit;
            _view.DeleteEvent += Delete;
            _view.PrintEvent += Print;
            _view.RefreshEvent += Return;

            //Load

            LoadAllRegisterList();
            LoadAllDepartmentList();

            //Source Binding
            _view.SetRegisterListBindingSource(RegisterBindingSource);
            _view.SetDepartmentListBindingSource(DepartmentBindingSource);
        }

        private void LoadAllDepartmentList()
        {
            DepartmentList = EnumHelper.EnumToEnumerable<Departments>();
            DepartmentBindingSource.DataSource = DepartmentList;
        }

        private void AddNew(object? sender, EventArgs e)
        {
            _view.IsEdit = false;
            CleanviewFields();
        }
        private void Save(object? sender, EventArgs e)
        {
            var model = _unitOfWork.ApplicationUser.Get(c => c.UserName == _view.Username);
            if (model == null) model = new ApplicationUser();
            else _unitOfWork.ApplicationUser.Detach(model);

            model.Id = _view.Id;
            model.UserName = _view.Username;
            model.Department = (Departments)_view.Department;
            model.PasswordHash = _passwordHasher.HashPassword(null, _view.Password);
            model.TaskRoles = _view.TaskRoles;

            try
            {
                new ModelDataValidation().Validate(model);
                if (_view.IsEdit)//Edit model
                {
                    _unitOfWork.ApplicationUser.Update(model);
                    _view.Message = "Account edited successfully";
                }
                else //Add new model
                {
                    _unitOfWork.ApplicationUser.Add(model);
                    _view.Message = "Account added successfully";
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
                var user = _unitOfWork.ApplicationUser.GetAll(c => c.UserName.Contains(_view.SearchValue), includeProperties: "Profile");
                RegisterList = Program.Mapper.Map<IEnumerable<AccountViewModel>>(user);
                RegisterBindingSource.DataSource = RegisterList;
            }
            else
            {
                LoadAllRegisterList();
            }
        }
        private void Edit(object? sender, EventArgs e)
        {
            _view.IsEdit = true;
            var entity = (AccountViewModel)RegisterBindingSource.Current;
            var user = _unitOfWork.ApplicationUser.Get(c => c.Id == entity.Id, includeProperties: "Profile");
            _view.Id = entity.Id;
            _view.Username = entity.Username;
        }
        private void Delete(object? sender, EventArgs e)
        {
            try
            {
                var entity = (AccountViewModel)RegisterBindingSource.Current;
                var user = _unitOfWork.ApplicationUser.Get(c => c.Id == entity.Id, includeProperties: "Profile");
                _unitOfWork.ApplicationUser.Remove(user);
                _unitOfWork.Save();
                _view.IsSuccessful = true;
                _view.Message = "Account deleted successfully";
                LoadAllRegisterList();
            }
            catch (Exception)
            {
                _view.IsSuccessful = false;
                _view.Message = "An error ocurred, could not delete Account";
            }
        }
        private void Print(object? sender, EventArgs e)
        {
            string reportFileName = "RegisterReport.rdlc";
            string reportDirectory = Path.Combine(Application.StartupPath, "Reports");
            string reportPath = Path.Combine(reportDirectory, reportFileName);
            var localReport = new LocalReport();
            var reportDataSource = new ReportDataSource("Register", RegisterList);
            var reportView = new ReportView(reportPath, reportDataSource, localReport);
            reportView.ShowDialog();
        }
        private void Return(object? sender, EventArgs e)
        {
            LoadAllRegisterList();
        }
        private void CleanviewFields()
        {
            LoadAllRegisterList();
            _view.Id = "";
            _view.Username = "";
            _view.Password = "";
            _view.ConfirmPassword = "";
        }

        private void LoadAllRegisterList()
        {
            var user = _unitOfWork.ApplicationUser.GetAll(includeProperties: "Profile");
            RegisterList = Program.Mapper.Map<IEnumerable<AccountViewModel>>(user);
            RegisterBindingSource.DataSource = RegisterList;//Set data source.
        }
    }
}
