namespace PresentationLayer.Views.IViews.Account
{
    public interface IProfileView
    {
        event EventHandler ShowUserProfile;
        event EventHandler ShowChangePassword;
        TabPage Guna2TabControlPage { get; }
    }
}