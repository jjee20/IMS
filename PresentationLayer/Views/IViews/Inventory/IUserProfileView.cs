namespace PresentationLayer.Views.IViews.Inventory
{
    public interface IUserProfileView
    {
        string Email { get; set; }
        string FirstName { get; set; }
        bool IsSuccessful { get; set; }
        string LastName { get; set; }
        string Message { get; set; }
        string PhoneNumber { get; set; }

        event EventHandler PrintEvent;
        event EventHandler SaveEvent;
    }
}