using PresentationLayer.Views.IViews.Inventory;

namespace PresentationLayer.Views.UserControls
{
    public partial class ProductInventoryView : UserControl, IProductInventoryView
    {
        public ProductInventoryView()
        {
            InitializeComponent();
            tcMain.SelectedIndexChanged += delegate
            {
                // Check if the selected tab is the one where you want to raise the event
                if (tcMain.SelectedTab == tbProductType)
                {
                    ShowProductType?.Invoke(this, EventArgs.Empty);
                }
                else if (tcMain.SelectedTab == tbUnitOfMeasure)
                {
                    ShowUnitOfMeasure?.Invoke(this, EventArgs.Empty);
                }
                else if (tcMain.SelectedTab == tbProduct)
                {
                    ShowProduct?.Invoke(this, EventArgs.Empty);
                }
                else if (tcMain.SelectedTab == tbStockIn)
                {
                    ShowStockIn?.Invoke(this, EventArgs.Empty);
                }
                else if (tcMain.SelectedTab == tbStockMonitoring)
                {
                    ShowStockMonitoring?.Invoke(this, EventArgs.Empty);
                }
            };
        }

        private static ProductInventoryView? instance;

        public TabPage Guna2TabControlPage => tcMain.SelectedTab;

        public event EventHandler ShowProductType;
        public event EventHandler ShowUnitOfMeasure;
        public event EventHandler ShowProduct;
        public event EventHandler ShowStockIn;
        public event EventHandler ShowStockMonitoring;

        public static ProductInventoryView GetInstance(TabPage parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new ProductInventoryView();
                parentContainer.Controls.Add(instance);
                instance.Dock = DockStyle.Fill;
            }
            return instance;
        }
    }
}
