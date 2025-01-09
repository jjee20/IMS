using PresentationLayer.Views.IViews.Inventory;

namespace PresentationLayer.Views.UserControls
{
    public partial class PurchaseView : UserControl, IPurchaseView
    {
        public PurchaseView()
        {
            InitializeComponent();
            tcMain.SelectedIndexChanged += delegate
            {
                if (tcMain.SelectedTab == tbPurchaseOrder)
                {
                    ShowPurchaseOrder?.Invoke(this, EventArgs.Empty);
                }
                else if (tcMain.SelectedTab == tbGoodsReceiveNote)
                {
                    ShowGoodsReceiveNote?.Invoke(this, EventArgs.Empty);
                }
                else if (tcMain.SelectedTab == tbBill)
                {
                    ShowBill?.Invoke(this, EventArgs.Empty);
                }
                else if (tcMain.SelectedTab == tbPaymentVoucher)
                {
                    ShowPaymentVoucher?.Invoke(this, EventArgs.Empty);
                }
                else if (tcMain.SelectedTab == tbSettings)
                {
                    ShowSettings?.Invoke(this, EventArgs.Empty);
                }
                else if (tcMain.SelectedTab == tbVendor)
                {
                    ShowVendor?.Invoke(this, EventArgs.Empty);
                }
            };
        }

        private static PurchaseView? instance;

        public TabPage Guna2TabControlPage => tcMain.SelectedTab;

        public event EventHandler ShowPurchaseOrder;
        public event EventHandler ShowGoodsReceiveNote;
        public event EventHandler ShowBill;
        public event EventHandler ShowPaymentVoucher;
        public event EventHandler ShowSettings;
        public event EventHandler ShowVendor;

        public static PurchaseView GetInstance(TabPage parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new PurchaseView();
                parentContainer.Controls.Add(instance);
                instance.Dock = DockStyle.Fill;
            }
            return instance;
        }
    }
}
