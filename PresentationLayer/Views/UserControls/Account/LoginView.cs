using PresentationLayer.Views.IViews.Inventory;
using RavenTech_ERP.Properties;
using Syncfusion.WinForms.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RavenTech_ERP.Views.UserControls.Account
{
    public partial class LoginView : Form, ILoginView
    {
        private bool isSuccessful;
        private string message;
        public LoginView()
        {
            InitializeComponent();
            btnLogin.Click += delegate { LoginEvent?.Invoke(this, EventArgs.Empty); };
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Username
        {
            get { return txtUsername.Text; }
            set { txtUsername.Text = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Password
        {
            get { return txtPassword.Text; }
            set { txtPassword.Text = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsSuccessful
        {
            get { return isSuccessful; }
            set { isSuccessful = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        public event EventHandler LoginEvent;
        private void txtPassword_IconRightClick(object sender, EventArgs e)
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
        private Image GetIconFromResource(string iconName)
        {
            byte[] imageBytes = iconName == "eye" ? Resources.hidden : Resources.eye;
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                return Image.FromStream(ms);  // Converts byte[] to Image
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
