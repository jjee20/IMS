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

            LoadInformation();
        }

        private void LoadInformation()
        {
            if(_applicationUser != null)
            {
                if(_applicationUser.Profile != null)
                {
                    txtFirstName.Text = _applicationUser.Profile.FirstName;
                    txtLastName.Text = _applicationUser.Profile.LastName;
                }
                txtEmail.Text = _applicationUser.Email;
                txtPhone.Text = _applicationUser.PhoneNumber;
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (_applicationUser != null)
                {
                    var existingProfile = _unitOfWork.UserProfile.Value.Get(
                        c => c.ApplicationUserId == _applicationUser.Id,
                        tracked: true
                    );

                    if (existingProfile != null)
                    {
                        existingProfile.FirstName = txtFirstName.Text.Trim().ToUpper();
                        existingProfile.LastName = txtLastName.Text.Trim().ToUpper();
                        existingProfile.ApplicationUserId = _applicationUser.Id;
                        _applicationUser.Profile = existingProfile;
                    }
                    else
                    {
                        var newProfile = new UserProfile
                        {
                            FirstName = txtFirstName.Text.Trim().ToUpper(),
                            LastName = txtLastName.Text.Trim().ToUpper(),
                            ApplicationUserId = _applicationUser.Id
                        };
                        _applicationUser.Profile = newProfile;
                    }

                    _applicationUser.PhoneNumber = txtPhone.Text.Trim();
                    _applicationUser.Email = txtEmail.Text.Trim();

                    _unitOfWork.ApplicationUser.Value.UpdateWithChild(
                        _applicationUser, c => c.Profile, cd => cd.UserProfileId);

                    await _unitOfWork.SaveAsync();

                    MessageBox.Show("Account information updated successfully", "Update");

                    DialogResult = DialogResult.OK;
                    Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
        }
    }
}
