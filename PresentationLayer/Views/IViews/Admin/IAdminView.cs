namespace PresentationLayer.Views.IViews.Admin
{
    public interface IAdminView
    {
        event EventHandler ShowRegister;
        event EventHandler ShowInventory;
        event EventHandler ShowPayroll;
        event EventHandler ShowProfile;
        TabPage Guna2TabControlPage { get; }

        void ShowForm();
    }
}