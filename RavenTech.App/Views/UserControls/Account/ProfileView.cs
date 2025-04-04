using DomainLayer.Enums;
using PresentationLayer.Views.IViews.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls
{
    public partial class ProfileView : UserControl, IProfileView
    {
        private List<TaskRoles> items;
        public ProfileView()
        {
            InitializeComponent();
            items = new List<TaskRoles>();

            btnEditProfile.Click += delegate { ShowEditProfile?.Invoke(this, EventArgs.Empty); };
            btnChangePassword.Click += delegate { ShowChangePassword?.Invoke(this, EventArgs.Empty); };
        }

        public void GetTaskRoles(List<TaskRoles> taskRoles)
        {
            listTask.Items.Clear();
            foreach (TaskRoles item in taskRoles)
            {
                listTask.Items.Add(item.ToString());
            }
        }

        public string AppUserName { set => txtName.Text = value; }
        public string UserName { set => txtUsername.Text = value; }
        public string Email { set => txtEmail.Text = value; }
        public string Phone { set => txtPhone.Text = value; }
        public string Department { set => txtDepartment.Text = value; }

        public event EventHandler ShowEditProfile;
        public event EventHandler ShowChangePassword;

        private static ProfileView? instance;
        public static ProfileView GetInstance(TabPage parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new ProfileView();
                parentContainer.Controls.Add(instance);
                instance.Dock = DockStyle.Fill;
            }
            return instance;
        }
    }
}
