namespace PresentationLayer.Views.IViews.Payroll
{
    public interface IPayrollSystemView
    {
        TabPage Guna2TabControlPage { get; }

        event EventHandler ShowAttendance;
        event EventHandler ShowAuditLog;
        event EventHandler ShowContribution;
        event EventHandler ShowDeduction;
        event EventHandler ShowDepartment;
        event EventHandler ShowEmployee;
        event EventHandler ShowJobPosition;
        event EventHandler ShowLeave;
        event EventHandler ShowPayroll;
        event EventHandler ShowPerformanceReview;
        event EventHandler ShowShift;
        event EventHandler ShowTax;
        event EventHandler ShowProject;

        void ShowForm();
    }
}