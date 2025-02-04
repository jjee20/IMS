namespace PresentationLayer.Views.IViews.Inventory
{
    public interface ILoginView
    {
        bool IsSuccessful { get; set; }
        string Message { get; set; }
        string Username { get; set; }
        string Password { get; set; }

        event EventHandler LoginEvent;

        void Show();
        void Hide();
    }
}