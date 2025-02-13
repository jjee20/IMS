using DomainLayer.Models.Accounts;
using Microsoft.AspNetCore.Identity;
using PresentationLayer.Presenters.Admin;
using PresentationLayer.Presenters.Inventory;
using PresentationLayer.Views;
using PresentationLayer.Views.IViews.Admin;
using PresentationLayer.Views.IViews.Inventory;
using PresentationLayer.Views.UserControls.Payroll;
using RevenTech_ERP.Presenters.Accounting.Payroll;
using RavenTech_ERP.Properties;
using RevenTech_ERP.Views.IViews.Accounting.Payroll;
using ServiceLayer.Services.IRepositories.IInventory;

namespace PresentationLayer.Presenters.Account
{
    public class LoginPresenter
    {
        private ILoginView _view;
        private IUnitOfWork _unitOfWork;
        private readonly PasswordHasher<ApplicationUser> _passwordHasher;

        public LoginPresenter(ILoginView view, IUnitOfWork unitOfWork)
        {
            _view = view;
            _unitOfWork = unitOfWork;
            _passwordHasher = new PasswordHasher<ApplicationUser>();

            // Subscribe to the login event in the view
            _view.LoginEvent += Login;
        }

        private void Login(object? sender, EventArgs e)
        {
            try
            {
                // Get the credentials entered by the user
                var username = _view.Username; // Get username from the view
                var enteredPassword = _view.Password; // Get entered password from the view

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(enteredPassword))
                {
                    MessageBox.Show("Please enter both username and password.");
                    return;
                }

                // Retrieve the user from the database based on the username
                var user = _unitOfWork.ApplicationUser.Get(c => c.UserName == username);

                if (user == null)
                {
                    MessageBox.Show("Invalid username or password.");
                    return;
                }

                // Verify the password by comparing the entered password with the hashed password
                var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, enteredPassword);

                if (passwordVerificationResult == PasswordVerificationResult.Success)
                {
                    Settings.Default.User_Id = user.Id;
                    if (user.Department == DomainLayer.Enums.Departments.Admin)
                        ShowAdmin();
                    else if (user.Department == DomainLayer.Enums.Departments.Inventory)
                        ShowInventory();
                    else if (user.Department == DomainLayer.Enums.Departments.Payroll)
                        ShowPayroll();
                }
                else
                {
                    // Invalid password
                    MessageBox.Show("Invalid username or password.");
                }
            }
            catch (Exception ex)
            {
                // Handle unexpected exceptions
                MessageBox.Show($"An error occurred during login: {ex.Message}");
            }
        }

        private void ShowPayroll()
        {
            try
            {
                // Create the Inventory view
                IPayrollSystemView view = new PayrollSystemView();
                var presenter = new PayrollSystemPresenter(view, _unitOfWork);

                // Show the PayrollView (assuming it's a form or user control)
                view.ShowForm();
                _view.Hide();
            }
            catch (Exception ex)
            {
                // Handle errors when trying to show the Inventory view
                MessageBox.Show($"An error occurred while showing the Payroll view: {ex.Message}");
            }
        }

        private void ShowAdmin()
        {
            try
            {
                IAdminView view = new AdminView();
                var presenter = new AdminPresenter(view, _unitOfWork);

                view.ShowForm();
                _view.Hide();
            }
            catch (Exception ex)
            {
                // Handle errors when trying to show the Inventory view
                MessageBox.Show($"An error occurred while showing the Inventory view: {ex.Message}");
            }
        }

        private void ShowInventory()
        {
            try
            {
                // Create the Inventory view
                IInventoryView view = new InventoryView();
                var presenter = new InventoryPresenter(view, _unitOfWork);

                // Show the InventoryView (assuming it's a form or user control)
                view.ShowForm();
                _view.Hide();
            }
            catch (Exception ex)
            {
                // Handle errors when trying to show the Inventory view
                MessageBox.Show($"An error occurred while showing the Inventory view: {ex.Message}");
            }
        }
    }
}
