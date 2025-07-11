using DomainLayer.Enums;
using DomainLayer.Models.Accounts;
using Microsoft.AspNetCore.Identity;
using PresentationLayer.Views.IViews.Inventory;
using RavenTech_ERP;
using RavenTech_ERP.Presenters;
using RavenTech_ERP.Properties;
using RavenTech_ERP.Views.IViews;
using RevenTech_ERP.Presenters.Accounting.Payroll;
using RevenTech_ERP.Views.IViews.Accounting.Payroll;
using ServiceLayer.Services.IRepositories;
using Unity;

namespace PresentationLayer.Presenters.Account
{
    public class LoginPresenter
    {
        private ILoginView _view;
        private readonly IUnityContainer _container;
        private readonly PasswordHasher<ApplicationUser> _passwordHasher;

        public LoginPresenter(ILoginView view, IUnityContainer container)
        {
            _view = view;
            _container = container;
            _passwordHasher = new PasswordHasher<ApplicationUser>();

            // Subscribe to the login event in the view
            _view.LoginEvent -= Login;
            _view.LoginEvent += Login;
        }

        private async void Login(object? sender, EventArgs e)
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
                var user = await _container.Resolve<IUnitOfWork>().ApplicationUser.Value.GetAsync(c => c.UserName == username);
                
                if (user == null)
                {
                    MessageBox.Show("Invalid username or password.");
                    return;
                }

                // Verify the password by comparing the entered password with the hashed password
                var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, enteredPassword);

                if (passwordVerificationResult == PasswordVerificationResult.Success)
                {
                    var department = user.Department;
                    Settings.Default.User_Id = user.Id;
                    Settings.Default.Roles = user.TaskRoles != null ? string.Join(",",user.TaskRoles) : "";
                    Settings.Default.Department = department.ToString();

                    IMainForm mainForm = new MainForm();
                    new MainPresenter(mainForm, _container);
                    if(department == Departments.Inventory)
                    {
                        mainForm.InventoryTab.Visible = true;
                        mainForm.PayrollTab.Visible = false;
                        mainForm.RegisterButton.Visible = true;
                        mainForm.ThinkEETab.Visible = false;
                        if (user.TaskRoles != null && user.TaskRoles.Contains(TaskRoles.View))
                        {
                            mainForm.RegisterButton.Visible = false;
                        }
                    } 
                    else if(department == Departments.Payroll)
                    {
                        mainForm.PayrollTab.Visible = true;
                        mainForm.InventoryTab.Visible = false;
                        mainForm.RegisterButton.Visible = true;
                        mainForm.ThinkEETab.Visible = false;
                    }
                    mainForm.ShowForm();
                    _view.Hide();
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
    }
}
