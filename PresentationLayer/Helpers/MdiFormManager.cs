using PresentationLayer.Views.UserControls;
using Syncfusion.Windows.Forms.Tools.Enums;
using Syncfusion.WinForms.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenTech_ERP.Helpers
{
    public static class MdiFormManager<T> where T : Form, new()
    {
        private static T instance;

        public static T GetMdiInstance(Form mdiParent)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new T
                {
                    MdiParent = mdiParent,
                    FormBorderStyle = FormBorderStyle.None,
                    WindowState = FormWindowState.Maximized
                };
                instance.Show();
            }
            else
            {
                instance.BringToFront();
            }

            return instance;
        }
    }
    public static class ChildManager<T> where T : SfForm, new()
    {
        private static T instance;

        public static T GetChildInstance(SfForm mdiParent)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new T
                {
                    MdiParent = mdiParent,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill
                };
                instance.Show();
            }
            else
            {
                instance.BringToFront();
            }

            return instance;
        }
    }
}
