using DomainLayer.Enums;
using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Views.IViews.Payroll
{
    public interface IEmployeeView
    {
        int EmployeeId { get; set; }
        string EmployeeFirstName { get; set; }
        string EmployeeLastName { get; set; }
        DateTime DateOfBirth { get; set; }
        Gender Gender { get; set; }
        string ContactNumber { get; set; }
        string Email { get; set; }
        string Address { get; set; }
        int DepartmentId { get; set; }
        int JobPositionId { get; set; }
        int ShiftId { get; set; }
        double BasicSalary { get; set; }
        double LeaveCredits { get; set; }
        bool isDeducted { get; set; }
        bool IsEdit { get; set; }
        bool IsSuccessful { get; set; }
        string Message { get; set; }
        string SearchValue { get; set; }
        bool SaveButton { get; set; }

        event EventHandler AddNewEvent;
        event EventHandler DeleteEvent;
        event EventHandler EditEvent;
        event EventHandler PrintEvent;
        event EventHandler SaveEvent;
        event EventHandler SearchEvent;
        event EventHandler RefreshEvent;
        event EventHandler AddDepartmentEvent;
        event EventHandler AddJobPositionEvent;
        event EventHandler AddShiftEvent;
        event EventHandler ReloadEvent;

        void SetEmployeeListBindingSource(BindingSource EmployeeList);
        void SetGenderListBindingSource(BindingSource GenderList);
        void SetDepartmentListBindingSource(BindingSource DepartmentList);
        void SetJobPositionListBindingSource(BindingSource JobPositionList);
        void SetShiftListBindingSource(BindingSource ShiftList);
    }
}