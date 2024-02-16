using DomainLayer.Models;
using InfastructureLayer.DataAccess.Data;
using InfastructureLayer.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using PresentationLayer.Presenters.Commons;
using ServiceLayer.Services.IRepositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public partial class Form1 : Form
    {
        private readonly IUnitOfWork _unitOfWork;

        public Form1(IUnitOfWork unitOfWork)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            // Check if the CustomerType already exists by name
            var existingEntity = _unitOfWork.CustomerType.Get(c => c.CustomerTypeName == materialTextBox2.Text);

            if (existingEntity != null)
            {

                // Update the existing entity
                existingEntity.CustomerTypeName = materialTextBox2.Text;
                existingEntity.Description = materialTextBox3.Text;

                // Save changes
                _unitOfWork.CustomerType.Update(existingEntity);
                _unitOfWork.Save();
                MessageBox.Show("Updated");
            }
            else
            {
                // Create a new entity
                var entity = new CustomerType()
                {
                    CustomerTypeName = materialTextBox2.Text,
                    Description = materialTextBox3.Text
                };

                // Save changes
                _unitOfWork.CustomerType.Add(entity);
                _unitOfWork.Save();
                MessageBox.Show("Added");
            }
        }


    }
}
