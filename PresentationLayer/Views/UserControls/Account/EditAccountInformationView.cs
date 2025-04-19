using DomainLayer.Models.Accounts;
using DomainLayer.Models.Inventory;
using MaterialSkin.Controls;
using ServiceLayer.Services.IRepositories;
using Syncfusion.WinForms.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RavenTech_ERP.Views.UserControls.Account
{
    public partial class EditAccountInformationView : SfForm
    {
        private readonly IUnitOfWork _unitOfWork;
        private ApplicationUser _applicationUser;
        public EditAccountInformationView(ApplicationUser applicationUser,IUnitOfWork unitOfWork)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            _applicationUser = applicationUser;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (_applicationUser != null)
                {
                    if (_applicationUser.Profile == null) _applicationUser.Profile = new UserProfile();

                    _applicationUser.Profile.FirstName = txtFirstName.Text.Trim().ToUpper();
                    _applicationUser.Profile.LastName = txtLastName.Text.Trim().ToUpper();
                    _applicationUser.PhoneNumber = txtPhone.Text.Trim();
                    _applicationUser.Email = txtEmail.Text.Trim();

                    _unitOfWork.ApplicationUser.Value.Update(_applicationUser);
                    _unitOfWork.Save();

                    MessageBox.Show("Account information updated successfully", "Update");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
        }
    }
}
