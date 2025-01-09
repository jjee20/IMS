using PresentationLayer.Presenters.Account;
using PresentationLayer.Presenters.Inventory;
using PresentationLayer.Views;
using PresentationLayer.Views.IViews;
using PresentationLayer.Views.IViews.Account;
using PresentationLayer.Views.IViews.Inventory;
using PresentationLayer.Views.IViews.Payroll;
using PresentationLayer.Views.UserControls;
using ServiceLayer.Services.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Presenters.Payroll
{
    public class PayrollSystemPresenter
    {
        private IPayrollSystemView _view;
        private IUnitOfWork _unitOfWork;
        public PayrollSystemPresenter(IPayrollSystemView view, IUnitOfWork unitOfWork)
        {
            _view = view;
            _unitOfWork = unitOfWork;

            _view.ShowAttendance += ShowAttendance;
            _view.ShowProject += ShowProject;
            _view.ShowContribution += ShowContribution;
            _view.ShowDeduction += ShowDeduction;
            _view.ShowDepartment += ShowDepartment;
            _view.ShowEmployee += ShowEmployee;
            _view.ShowJobPosition += ShowJobPosition;
            _view.ShowLeave += ShowLeave;
            _view.ShowPayroll += ShowPayroll;
            //_view.ShowPerformanceReview += ShowPerformanceReview;
            _view.ShowShift += ShowShift;
            _view.ShowTax += ShowTax;
            ShowAttendance(this, EventArgs.Empty);
        }

        private void ShowTax(object? sender, EventArgs e)
        {
            ITaxView view = TaxView.GetInstance(_view.Guna2TabControlPage);
            new TaxPresenter(view, _unitOfWork);
        }

        private void ShowShift(object? sender, EventArgs e)
        {
            IShiftView view = ShiftView.GetInstance(_view.Guna2TabControlPage);
            new ShiftPresenter(view, _unitOfWork);
        }

        private void ShowProject(object? sender, EventArgs e)
        {
            IProjectView view = ProjectView.GetInstance(_view.Guna2TabControlPage);
            new ProjectPresenter(view, _unitOfWork);
        }

        private void ShowPayroll(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ShowLeave(object? sender, EventArgs e)
        {
            ILeaveView view = LeaveView.GetInstance(_view.Guna2TabControlPage);
            new LeavePresenter(view, _unitOfWork);
        }

        private void ShowDepartment(object? sender, EventArgs e)
        {
            IDepartmentView view = DepartmentView.GetInstance(_view.Guna2TabControlPage);
            new DepartmentPresenter(view, _unitOfWork);
        }

        private void ShowJobPosition(object? sender, EventArgs e)
        {
            IJobPositionView view = JobPositionView.GetInstance(_view.Guna2TabControlPage);
            new JobPositionPresenter(view, _unitOfWork);
        }

        private void ShowEmployee(object? sender, EventArgs e)
        {
            IEmployeeView view = EmployeeView.GetInstance(_view.Guna2TabControlPage);
            new EmployeePresenter(view, _unitOfWork);
        }

        private void ShowDeduction(object? sender, EventArgs e)
        {
            IDeductionView view = DeductionView.GetInstance(_view.Guna2TabControlPage);
            new DeductionPresenter(view, _unitOfWork);
        }

        private void ShowContribution(object? sender, EventArgs e)
        {
            IContributionView view = ContributionView.GetInstance(_view.Guna2TabControlPage);
            new ContributionPresenter(view, _unitOfWork);
        }

        private void ShowAuditLog(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ShowAttendance(object? sender, EventArgs e)
        {
            IAttendanceView view = AttendanceView.GetInstance(_view.Guna2TabControlPage);
            new AttendancePresenter(view, _unitOfWork);
        }

        private void ShowProfile(object? sender, EventArgs e)
        {
            IProfileView view = ProfileView.GetInstance(_view.Guna2TabControlPage);
            new ProfilePresenter(view, _unitOfWork);
        }
        private void ShowDashboard(object? sender, EventArgs e)
        {
            IDashboardView view = DashboardView.GetInstance(_view.Guna2TabControlPage);
            new DashboardPresenter(view, _unitOfWork);
        }
    }
}
