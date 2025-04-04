﻿using DomainLayer.Models;
using MaterialSkin;
using MaterialSkin.Controls;
using PresentationLayer.Views.IViews.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PresentationLayer.Views
{
    public partial class AdminView : MaterialForm, IAdminView
    {
        public AdminView()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            var colorScheme = new ColorScheme(
                Primary.Blue400, Primary.Blue500,
                Primary.Blue500, Accent.LightBlue200,
                TextShade.WHITE
            );

            materialSkinManager.ColorScheme = colorScheme;

            tcMain.SelectedIndexChanged += delegate
            {
                // Check if the selected tab is the one where you want to raise the event
                if (tcMain.SelectedTab == tbRegister)
                {
                    ShowRegister?.Invoke(this, EventArgs.Empty);
                }
                else if (tcMain.SelectedTab == tbInventory)
                {
                    ShowInventory?.Invoke(this, EventArgs.Empty);
                }
                else if (tcMain.SelectedTab == tbPayroll)
                {
                    ShowPayroll?.Invoke(this, EventArgs.Empty);
                }
                else if (tcMain.SelectedTab == tbProfile)
                {
                    ShowProfile?.Invoke(this, EventArgs.Empty);
                }
            };
        }
        public TabPage Guna2TabControlPage
        {
            get { return tcMain.SelectedTab; }
        }

        public void ShowForm()
        {
            Show();
        }

        public event EventHandler ShowRegister;
        public event EventHandler ShowInventory;
        public event EventHandler ShowPayroll;
        public event EventHandler ShowProfile;
    }
}
