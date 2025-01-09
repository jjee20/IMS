using PresentationLayer.Views.IViews.Inventory;

namespace PresentationLayer.Views.UserControls
{
    public partial class ConfigurationView : UserControl, IConfigurationView
    {
        public ConfigurationView()
        {
            InitializeComponent();
            tcMain.SelectedIndexChanged += delegate
            {
                // Check if the selected tab is the one where you want to raise the event
                if (tcMain.SelectedTab == tbUserRole)
                {
                    ShowUserRole?.Invoke(this, EventArgs.Empty);
                }
            };
        }

        private static ConfigurationView? instance;

        public TabPage Guna2TabControlPage => tcMain.SelectedTab;

        public event EventHandler ShowUserRole;

        public static ConfigurationView GetInstance(TabPage parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new ConfigurationView();
                parentContainer.Controls.Add(instance);
                instance.Dock = DockStyle.Fill;
            }
            return instance;
        }
    }
}
