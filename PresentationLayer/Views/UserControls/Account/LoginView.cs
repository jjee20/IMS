using MaterialSkin;
using MaterialSkin.Controls;
using PresentationLayer.Properties;
using PresentationLayer.Views.IViews.Inventory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PresentationLayer.Views.UserControls.Inventory
{
    public partial class LoginView : MaterialForm, ILoginView
    {

        private string message;
        private bool isSuccessful;
        public LoginView()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            var colorScheme = new ColorScheme(
                                ColorTranslator.FromHtml("#457b9d"),
                                ColorTranslator.FromHtml("#1d3557"),
                                ColorTranslator.FromHtml("#f1faee"),
                                ColorTranslator.FromHtml("#457b9d"),
                                TextShade.WHITE // text shade
            );

            materialSkinManager.ColorScheme = colorScheme;

            btnLogin.Click += delegate
            {
                LoginEvent?.Invoke(this, EventArgs.Empty);
            };
        }
        public string Username
        {
            get { return txtUsername.Text; }
            set { txtUsername.Text = value; }
        }

        public string Password
        {
            get { return txtPassword.Text; }
            set { txtPassword.Text = value; }
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

        public void Show()
        {
            Show();
        }

        private Image GetIconFromResource(string iconName)
        {
            byte[] imageBytes = iconName == "eye" ? Properties.Resources.eye : Properties.Resources.hidden;
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                return Image.FromStream(ms);  // Converts byte[] to Image
            }
        }

    }
}
