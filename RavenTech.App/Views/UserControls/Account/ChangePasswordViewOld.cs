using DomainLayer.Models.Inventory;
using MaterialSkin;
using PresentationLayer.Presenters;
using PresentationLayer.Views.IViews;
using PresentationLayer.Views.IViews.Inventory;
using RavenTech_ERP.Properties;
using ServiceLayer.Services.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls
{
    public partial class ChangePasswordViewOld : UserControl, IChangePasswordView
    {
        private string message;
        private bool isSuccessful;
        public ChangePasswordViewOld()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
        }

        private void AssociateAndRaiseViewEvents()
        {
            //Save changes
            btnSave.Click += delegate
            {
                SaveEvent?.Invoke(this, EventArgs.Empty);
                MessageBox.Show(Message);
            };
        }

        //Properties
        public string Password
        {
            get { return txtPassword.Text; }
            set { txtPassword.Text = value; }
        }
        public string NewPassword
        {
            get { return txtNewPassword.Text; }
            set { txtNewPassword.Text = value; }
        }
        public string ConfirmNewPassword
        {
            get { return txtConfirmNewPassword.Text; }
            set { txtConfirmNewPassword.Text = value; }
        }
        public bool IsSuccessful
        {
            get { return isSuccessful; }
            set { isSuccessful = value; }
        }

        public string Message
        {
            get { return message; }
            set { message = value; }
        }
        public event EventHandler SaveEvent;

        private static ChangePasswordViewOld? instance;
        public static ChangePasswordViewOld GetInstance(TabPage parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new ChangePasswordViewOld();
                parentContainer.Controls.Add(instance);
                instance.Dock = DockStyle.Fill;
            }
            return instance;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            // Check if the PasswordChar is set to the default bullet character, indicating password is hidden
            if (txtPassword.PasswordChar == '•') // Password is hidden
            {
                // Show the password and set 'eye' icon
                txtPassword.PasswordChar = '\0'; // Shows the password
                txtPassword.IconRight = GetIconFromResource("eye"); // Set eye icon
            }
            else // Password is visible
            {
                // Hide the password and set 'hidden' icon
                txtPassword.PasswordChar = '•'; // Hides the password
                txtPassword.IconRight = GetIconFromResource("hidden"); // Set hidden icon
            }
        }

        private void txtNewPassword_TextChanged(object sender, EventArgs e)
        {
            // Check if the PasswordChar is set to the default bullet character, indicating password is hidden
            if (txtNewPassword.PasswordChar == '•') // Password is hidden
            {
                // Show the password and set 'eye' icon
                txtNewPassword.PasswordChar = '\0'; // Shows the password
                txtNewPassword.IconRight = GetIconFromResource("eye"); // Set eye icon
            }
            else // Password is visible
            {
                // Hide the password and set 'hidden' icon
                txtNewPassword.PasswordChar = '•'; // Hides the password
                txtNewPassword.IconRight = GetIconFromResource("hidden"); // Set hidden icon
            }
        }

        private void txtConfirmNewPassword_TextChanged(object sender, EventArgs e)
        {
            // Check if the PasswordChar is set to the default bullet character, indicating password is hidden
            if (txtConfirmNewPassword.PasswordChar == '•') // Password is hidden
            {
                // Show the password and set 'eye' icon
                txtConfirmNewPassword.PasswordChar = '\0'; // Shows the password
                txtConfirmNewPassword.IconRight = GetIconFromResource("eye"); // Set eye icon
            }
            else // Password is visible
            {
                // Hide the password and set 'hidden' icon
                txtConfirmNewPassword.PasswordChar = '•'; // Hides the password
                txtConfirmNewPassword.IconRight = GetIconFromResource("hidden"); // Set hidden icon
            }
        }

        private Image GetIconFromResource(string iconName)
        {
            byte[] imageBytes = iconName == "eye" ? Resources.eye : Resources.hidden;
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                return Image.FromStream(ms);  // Converts byte[] to Image
            }
        }
    }
}
