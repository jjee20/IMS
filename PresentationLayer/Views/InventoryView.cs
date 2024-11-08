using DomainLayer.Models;
using MaterialSkin;
using MaterialSkin.Controls;
using PresentationLayer.Views.IViews;
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
using static ServiceLayer.Services.CommonServices.MainMenu;

namespace PresentationLayer.Views
{
    public partial class InventoryView : MaterialForm, IInventoryView
    {
        public InventoryView()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            var colorScheme = new ColorScheme(
                                ColorTranslator.FromHtml("#457b9d"),
                                ColorTranslator.FromHtml("#1d3557"),
                                ColorTranslator.FromHtml("#f1faee"),
                                ColorTranslator.FromHtml("#457b9d"),
                                TextShade.WHITE // text shade
            );

            materialSkinManager.ColorScheme = colorScheme;

            tcMain.SelectedIndexChanged += delegate
            {
                // Check if the selected tab is the one where you want to raise the event
                if (tcMain.SelectedTab == tbBillType)
                {
                    ShowBillType?.Invoke(this, EventArgs.Empty);
                }
                else if (tcMain.SelectedTab == tbBill)
                {
                    ShowBill?.Invoke(this, EventArgs.Empty);
                }
                else if (tcMain.SelectedTab == tbBranch)
                {
                    ShowBranch?.Invoke(this, EventArgs.Empty);
                }
                else if (tcMain.SelectedTab == tbCashBank)
                {
                    ShowCashBank?.Invoke(this, EventArgs.Empty);
                }
                else if (tcMain.SelectedTab == tbCurrency)
                {
                    ShowCurrency?.Invoke(this, EventArgs.Empty);
                }
                else if (tcMain.SelectedTab == tbCustomerType)
                {
                    ShowCustomerType?.Invoke(this, EventArgs.Empty);
                }
                else if(tcMain.SelectedTab == tbCustomer)
                {
                    ShowCustomer?.Invoke(this, EventArgs.Empty);
                }
                else if(tcMain.SelectedTab == tbGoodsReceivedNote)
                {
                    ShowGoodsReceivedNote?.Invoke(this, EventArgs.Empty);
                }
                else if(tcMain.SelectedTab == tbInvoiceType)
                {
                    ShowInvoiceType?.Invoke(this, EventArgs.Empty);
                }
                else if(tcMain.SelectedTab == tbInvoice)
                {
                    ShowInvoice?.Invoke(this, EventArgs.Empty);
                }
                else if(tcMain.SelectedTab == tbPaymentReceive)
                {
                    ShowPaymentReceive?.Invoke(this, EventArgs.Empty);
                }
                else if(tcMain.SelectedTab == tbPaymentType)
                {
                    ShowPaymentType?.Invoke(this, EventArgs.Empty);
                }
                else if(tcMain.SelectedTab == tbPaymentVoucher)
                {
                    ShowPaymentVoucher?.Invoke(this, EventArgs.Empty);
                }
                else if(tcMain.SelectedTab == tbProductType)
                {
                    ShowProductType?.Invoke(this, EventArgs.Empty);
                }
                else if(tcMain.SelectedTab == tbProduct)
                {
                    ShowProduct?.Invoke(this, EventArgs.Empty);
                }
                else if(tcMain.SelectedTab == tbPurchaseOrder)
                {
                    ShowPurchaseOrder?.Invoke(this, EventArgs.Empty);
                }
                else if(tcMain.SelectedTab == tbPurchaseType)
                {
                    ShowPurchaseType?.Invoke(this, EventArgs.Empty);
                }
                else if(tcMain.SelectedTab == tbSalesOrder)
                {
                    ShowSalesOrder?.Invoke(this, EventArgs.Empty);
                }
                else if(tcMain.SelectedTab == tbSalesType)
                {
                    ShowSalesType?.Invoke(this, EventArgs.Empty);
                }
                else if(tcMain.SelectedTab == tbShipmentType)
                {
                    ShowShipmentType?.Invoke(this, EventArgs.Empty);
                }
                else if(tcMain.SelectedTab == tbShipment)
                {
                    ShowShipment?.Invoke(this, EventArgs.Empty);
                }
                else if(tcMain.SelectedTab == tbUnitOfMeasure)
                {
                    ShowUnitOfMeasure?.Invoke(this, EventArgs.Empty);
                }
                else if(tcMain.SelectedTab == tbVendorType)
                {
                    ShowVendorType?.Invoke(this, EventArgs.Empty);
                }
                else if(tcMain.SelectedTab == tbVendor)
                {
                    ShowVendor?.Invoke(this, EventArgs.Empty);
                }
            };
        }
        public TabPage TabControlPage
        {
            get { return tcMain.SelectedTab; }
        }   
        public event EventHandler ShowBillType;
        public event EventHandler ShowBill;
        public event EventHandler ShowBranch;
        public event EventHandler ShowCashBank;
        public event EventHandler ShowCurrency;
        public event EventHandler ShowCustomerType;
        public event EventHandler ShowCustomer;
        public event EventHandler ShowGoodsReceivedNote;
        public event EventHandler ShowInvoiceType;
        public event EventHandler ShowInvoice;
        public event EventHandler ShowPaymentReceive;
        public event EventHandler ShowPaymentType;
        public event EventHandler ShowPaymentVoucher;
        public event EventHandler ShowProductType;
        public event EventHandler ShowProduct;
        public event EventHandler ShowPurchaseOrder;
        public event EventHandler ShowPurchaseType;
        public event EventHandler ShowSalesOrder;
        public event EventHandler ShowSalesType;
        public event EventHandler ShowShipmentType;
        public event EventHandler ShowShipment;
        public event EventHandler ShowUnitOfMeasure;
        public event EventHandler ShowVendorType;
        public event EventHandler ShowVendor;
    }
}
