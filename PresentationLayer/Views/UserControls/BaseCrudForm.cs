using Syncfusion.WinForms.Controls;
using Syncfusion.WinForms.DataGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenTech_ERP.Views.UserControls
{
    public abstract class BaseCrudForm<TModel> : SfForm
    {
        protected TabControl TabControl;
        protected TabPage MainPage;
        protected TabPage EditPage;
        protected Button BtnAdd, BtnEdit, BtnSave, BtnDelete, BtnPrint, BtnReturn;
        protected TextBox TxtSearch;
        protected SfDataGrid DataGrid;

        public event EventHandler? AddNewEvent;
        public event EventHandler? SaveEvent;
        public event EventHandler? SearchEvent;
        public event EventHandler? EditEvent;
        public event EventHandler? DeleteEvent;
        public event EventHandler? PrintEvent;
        public event EventHandler? RefreshEvent;

        protected BaseCrudForm()
        {
            // Derived class should initialize controls before calling this
        }

        protected void BindCrudEvents()
        {
            BtnAdd.Click += (s, e) => SwitchToTab(MainPage, EditPage, "Add New", AddNewEvent);
            BtnEdit.Click += (s, e) => SwitchToTab(MainPage, EditPage, "Edit", EditEvent);
            BtnSave.Click += (s, e) => SaveEvent?.Invoke(this, EventArgs.Empty);
            BtnDelete.Click += (s, e) => ConfirmAndExecuteDelete();
            BtnPrint.Click += (s, e) => PrintEvent?.Invoke(this, EventArgs.Empty);
            BtnReturn.Click += (s, e) => ReturnToMainTab();
            TxtSearch.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) SearchEvent?.Invoke(this, EventArgs.Empty); };
        }

        protected void SwitchToTab(TabPage fromTab, TabPage toTab, string title, EventHandler? action)
        {
            if (TabControl.TabPages.Contains(fromTab))
            {
                toTab.Text = title;
                TabControl.TabPages.Remove(fromTab);
                TabControl.TabPages.Add(toTab);
                action?.Invoke(this, EventArgs.Empty);
                BtnReturn.Visible = true;
            }
        }

        protected void ReturnToMainTab()
        {
            if (!TabControl.TabPages.Contains(MainPage))
            {
                TabControl.TabPages.Remove(EditPage);
                TabControl.TabPages.Add(MainPage);
                RefreshEvent?.Invoke(this, EventArgs.Empty);
            }
            BtnReturn.Visible = false;
        }

        protected void ConfirmAndExecuteDelete()
        {
            var result = MessageBox.Show("Are you sure you want to delete the selected item?", "Warning",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                DeleteEvent?.Invoke(this, EventArgs.Empty);
            }
        }

        public void SetGridData(IEnumerable<TModel> list)
        {
            DataGrid.DataSource = list;
        }
    }
}
