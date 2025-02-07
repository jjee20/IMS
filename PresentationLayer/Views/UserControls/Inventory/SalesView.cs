using PresentationLayer.Views.IViews.Inventory;

namespace PresentationLayer.Views.UserControls
{
    public partial class SalesView : UserControl, ISalesView
    {
        public SalesView()
        {
            InitializeComponent();
            tcMain.SelectedIndexChanged += delegate
            {
                // Check if the selected tab is the one where you want to raise the event
                if (tcMain.SelectedTab == tbCustomer)
                {
                    ShowCustomer?.Invoke(this, EventArgs.Empty);
                }
                else if (tcMain.SelectedTab == tbSalesOrder)
                {
                    ShowSalesOrder?.Invoke(this, EventArgs.Empty);
                }
                else if (tcMain.SelectedTab == tbShipment)
                {
                    ShowShipment?.Invoke(this, EventArgs.Empty);
                }
                else if (tcMain.SelectedTab == tbInvoice)
                {
                    ShowSalesInvoice?.Invoke(this, EventArgs.Empty);
                }
                else if (tcMain.SelectedTab == tbPaymentReceive)
                {
                    ShowPaymentReceive?.Invoke(this, EventArgs.Empty);
                }
                else if (tcMain.SelectedTab == tbSettings)
                {
                    ShowSettings?.Invoke(this, EventArgs.Empty);
                }
            };
        }

        private static SalesView? instance;

        public TabPage Guna2TabControlPage => tcMain.SelectedTab;

        public event EventHandler ShowCustomer;
        public event EventHandler ShowSalesOrder;
        public event EventHandler ShowShipment;
        public event EventHandler ShowSalesInvoice;
        public event EventHandler ShowPaymentReceive;
        public event EventHandler ShowSettings;

        public static SalesView GetInstance(TabPage parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new SalesView();
                parentContainer.Controls.Add(instance);
                instance.Dock = DockStyle.Fill;
            }
            return instance;
        }
    }
}
