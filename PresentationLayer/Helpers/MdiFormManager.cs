using PresentationLayer.Views.UserControls;
using Syncfusion.Windows.Forms.Tools.Enums;
using Syncfusion.WinForms.Controls;
using Syncfusion.WinForms.DataGrid.Events;
using Syncfusion.WinForms.DataGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.WinForms.DataGrid.Enums;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using ServiceLayer.Services.IRepositories;

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

    public static class ViewHelper
    {
        public static void WireCommonGridEvents<T>(
            SfDataGrid grid,
            CellClickEventHandler? editHandler = null,
            CellClickEventHandler? deleteHandler = null,
            KeyEventHandler? multipleDeleteHandler = null)
        {
            grid.CellClick += (sender, e) =>
            {
                if (e.DataRow?.RowType != RowType.DefaultRow) return;

                if (e.DataColumn.GridColumn.MappingName == "Edit")
                {
                    editHandler?.Invoke(sender, e);
                }
                else if (e.DataColumn.GridColumn.MappingName == "Delete")
                {
                    var result = MessageBox.Show("Are you sure you want to delete the selected item?", "Warning",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        deleteHandler?.Invoke(sender, e);
                    }
                }
            };

            grid.KeyDown += (sender, e) =>
            {
                if (e.KeyCode == Keys.Delete)
                {
                    var result = MessageBox.Show("Are you sure you want to delete the selected items?", "Warning",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        multipleDeleteHandler?.Invoke(sender, e);
                    }
                }
            };
        }

        public static void WireButtonEvents(
            Button btnAdd,
            Guna2ImageButton btnPrint,
            Guna2TextBox txtSearch,
            EventHandler? addHandler,
            EventHandler? searchHandler,
            EventHandler? printHandler)
        {
            btnAdd.Click += (s, e) => addHandler?.Invoke(s, e);
            btnPrint.Click += (s, e) => printHandler?.Invoke(s, e);

            txtSearch.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    searchHandler?.Invoke(s, e);
                    txtSearch.Focus();
                }
            };
        }
    }
}
