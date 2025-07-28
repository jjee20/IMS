using DomainLayer.Enums;
using PresentationLayer.Views.IViews.Account;
using Syncfusion.WinForms.Controls;
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
    public partial class ProfileView : SfForm, IProfileView
    {
        private readonly List<TaskRoles> items;
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
            foreach (var item in taskRoles)
            {
                listTask.Items.Add(item.ToString());
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string AppUserName
        {
            set => txtName.Text = value;
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string UserName
        {
            set => txtUsername.Text = value;
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Email
        {
            set => txtEmail.Text = value;
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Phone
        {
            set => txtPhone.Text = value;
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Department
        {
            set => txtDepartment.Text = value;
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]

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
