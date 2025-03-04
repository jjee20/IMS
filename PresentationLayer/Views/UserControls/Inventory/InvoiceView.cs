﻿using DomainLayer.Models;
using DomainLayer.ViewModels.Inventory;
using MaterialSkin;
using PresentationLayer.Presenters;
using PresentationLayer.Views.IViews;
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
    public partial class InvoiceView : UserControl, IInvoiceView
    {
        private int id;
        private string message;
        private bool isSuccessful;
        public bool isEdit;
        public InvoiceView()
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
                if (Guna2TabControl1.SelectedTab == tabPage1)
                {
                    tabPage2.Text = "Edit Details";
                    Guna2TabControl1.TabPages.Remove(tabPage1);
                    Guna2TabControl1.TabPages.Add(tabPage2);
                }
                EditEvent?.Invoke(this, EventArgs.Empty);
                btnReturn.Visible = true;
            };
            //Delete
            btnDelete.Click += delegate
            {
                var result = MessageBox.Show("Are you sure you want to delete the selected invoice?", "Warning",
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
        public int InvoiceId
        {
            get { return id; }
            set { id = value; }
        }

        public string InvoiceName
        {
            get { return txtName.Text; }
            set { txtName.Text = value; }
        }
        public int ShipmentId
        {
            get { return (int)txtShipment.SelectedValue; }
            set { txtShipment.Text = value.ToString(); }
        }
        public DateTimeOffset InvoiceDate
        {
            get { return txtInvoiceDate.Value; }
            set { txtInvoiceDate.Text = value.ToString(); }
        }
        public DateTimeOffset InvoiceDueDate
        {
            get { return txtInvoiceDueDate.Value; }
            set { txtInvoiceDueDate.Text = value.ToString(); }
        }
        public int InvoiceTypeId
        {
            get { return (int)txtInvoiceType.SelectedValue; }
            set { txtInvoiceType.Text = value.ToString(); }
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

        public string SearchValue
        {
            get { return txtSearch.Text; }
            set { txtSearch.Text = value; }
        }

        public void SetInvoiceListBindingSource(BindingSource InvoiceList)
        {
            dgList.DataSource = InvoiceList;
            DataGridHelper.ApplyDisplayNames<InvoiceViewModel>(InvoiceList, dgList);
        }
        public void SetInvoiceTypeListBindingSource(BindingSource InvoiceTypeBindingSource)
        {
            txtInvoiceType.DataSource = InvoiceTypeBindingSource;
            txtInvoiceType.DisplayMember = "InvoiceTypeName";
            txtInvoiceType.ValueMember = "InvoiceTypeId";
        }
        public void SetShipmentListBindingSource(BindingSource ShipmentBindingSource)
        {
            txtShipment.DataSource = ShipmentBindingSource;
            txtShipment.DisplayMember = "ShipmentName";
            txtShipment.ValueMember = "ShipmentId";
        }

        public event EventHandler AddNewEvent;
        public event EventHandler SaveEvent;
        public event EventHandler SearchEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler PrintEvent;
        public event EventHandler RefreshEvent;

        private static InvoiceView? instance;
        public static InvoiceView GetInstance(TabPage parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new InvoiceView();
                parentContainer.Controls.Add(instance);
                instance.Dock = DockStyle.Fill;
            }
            return instance;
        }
    }
}
