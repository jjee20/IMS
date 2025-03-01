using DomainLayer.Enums;
using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels.AccountViewModels;
using MaterialSkin;
using MaterialSkin.Controls;
using PresentationLayer.Presenters;
using PresentationLayer.Views.IViews;
using PresentationLayer.Views.IViews.Account;
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
    public partial class RegisterView : UserControl, IRegisterView
    {
        private string message;
        private bool isSuccessful;
        public bool isEdit;
        public RegisterView()
        {
            InitializeComponent();
            Guna2TabControl1.TabPages.Remove(tabPage2);
            AssociateAndRaiseViewEvents();
        }

        private void AssociateAndRaiseViewEvents()
        {
            //Add New
            btnAdd.Click += delegate
            {
                if (Guna2TabControl1.TabPages.Contains(tabPage1))
                {
                    AddNewEvent?.Invoke(this, EventArgs.Empty);
                    tabPage2.Text = "Add New";
                    Guna2TabControl1.TabPages.Remove(tabPage1);
                    Guna2TabControl1.TabPages.Add(tabPage2);
                }
                btnReturn.Visible = true;
            };
            //Save changes
            btnSave.Click += delegate
            {
                SaveEvent?.Invoke(this, EventArgs.Empty);
                if (isSuccessful)
                {
                    Guna2TabControl1.TabPages.Remove(tabPage2);
                    Guna2TabControl1.TabPages.Add(tabPage1);
                    btnReturn.Visible = false;
                }
                MessageBox.Show(Message);
            };
            txtSearch.TextChanged += (s, e) =>
            {
                SearchEvent?.Invoke(this, EventArgs.Empty);
            };
            //Edit
            btnEdit.Click += delegate
            {
                if (Guna2TabControl1.TabPages.Contains(tabPage1))
                {
                    EditEvent?.Invoke(this, EventArgs.Empty);
                    tabPage2.Text = "Edit";
                    Guna2TabControl1.TabPages.Remove(tabPage1);
                    Guna2TabControl1.TabPages.Add(tabPage2);
                }
                btnReturn.Visible = true;
            };
            //Delete
            btnDelete.Click += delegate
            {
                var result = MessageBox.Show("Are you sure you want to delete the selected account?", "Warning",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // Invoke the DeleteEvent with the selected row as an argument
                    DeleteEvent?.Invoke(this, EventArgs.Empty);
                    MessageBox.Show(Message);
                }
            };
            //Print
            btnPrint.Click += delegate
            {
                PrintEvent?.Invoke(this, EventArgs.Empty);
            };
            //Refresh
            btnReturn.Click += delegate
            {
                if (!Guna2TabControl1.TabPages.Contains(tabPage1))
                {
                    RefreshEvent?.Invoke(this, EventArgs.Empty);
                    Guna2TabControl1.TabPages.Remove(tabPage2);
                    Guna2TabControl1.TabPages.Add(tabPage1);
                }
                btnReturn.Visible = false;
            };
        }

        //Properties
        public string Id
        {
            get { return txtId.Text; }
            set { txtId.Text = value; }
        }

        public string Username
        {
            get { return txtName.Text; }
            set { txtName.Text = value; }
        }
        public string Password
        {
            get { return txtPassword.Text; }
            set { txtPassword.Text = value; }
        }
        public string ConfirmPassword
        {
            get { return txtConfirmPassword.Text; }
            set { txtConfirmPassword.Text = value; }
        }
        public int Department
        {
            get { return (int)txtDepartments.SelectedValue; }
            set { txtConfirmPassword.Text = value.ToString(); }
        }
        public bool IsEdit
        {
            get { return isEdit; }
            set { isEdit = value; }
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
        
        public bool Adding
        {
            get { return txtAdding.Checked; }
            set { txtAdding.Checked = value; }
        }
        
        public bool Editing
        {
            get { return txtEditing.Checked; }
            set { txtEditing.Checked = value; }
        }
        
        public bool Deleting
        {
            get { return txtDeleting.Checked; }
            set { txtDeleting.Checked = value; }
        }
        
        public bool Viewing
        {
            get { return txtViewing.Checked; }
            set { txtViewing.Checked = value; }
        }

        public string SearchValue
        {
            get { return txtSearch.Text; }
            set { txtSearch.Text = value; }
        }

        public void SetRegisterListBindingSource(BindingSource RegisterList)
        {
            dgList.DataSource = RegisterList;
            DataGridHelper.ApplyDisplayNames<AccountViewModel>(RegisterList, dgList);
        }

        public event EventHandler AddNewEvent;
        public event EventHandler SaveEvent;
        public event EventHandler SearchEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler PrintEvent;
        public event EventHandler RefreshEvent;

        private static RegisterView? instance;
        public static RegisterView GetInstance(TabPage parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new RegisterView();
                parentContainer.Controls.Add(instance);
                instance.Dock = DockStyle.Fill;
            }
            return instance;
        }

        public void SetDepartmentListBindingSource(BindingSource departmentBindingSource)
        {
            txtDepartments.DataSource = departmentBindingSource;
            txtDepartments.DisplayMember = "Name";
            txtDepartments.ValueMember = "Id";
        }

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

        private void txtConfirmPassword_IconRightClick(object sender, EventArgs e)
        {
            if (txtConfirmPassword.PasswordChar == '•') // Password is hidden
            {
                // Show the password and set 'eye' icon
                txtConfirmPassword.PasswordChar = '\0'; // Shows the password
                txtConfirmPassword.IconRight = GetIconFromResource("eye"); // Set eye icon
            }
            else // Password is visible
            {
                // Hide the password and set 'hidden' icon
                txtConfirmPassword.PasswordChar = '•'; // Hides the password
                txtConfirmPassword.IconRight = GetIconFromResource("hidden"); // Set hidden icon
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
