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
        public ProfileView()
        {
            InitializeComponent();

            tcMain.SelectedIndexChanged += delegate
            {
                // Check if the selected tab is the one where you want to raise the event
                if (tcMain.SelectedTab == tbEditProfile)
                {
                    ShowUserProfile?.Invoke(this, EventArgs.Empty);
                }
                else if (tcMain.SelectedTab == tbChangePassword)
                {
                    ShowChangePassword?.Invoke(this, EventArgs.Empty);
                }
            };
        }

        public event EventHandler ShowUserProfile;
        public event EventHandler ShowChangePassword;
        public TabPage Guna2TabControlPage => tcMain.SelectedTab;

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
