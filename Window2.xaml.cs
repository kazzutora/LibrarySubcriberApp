using JewelryStoreApp;
using System.Windows;

namespace WpfApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenForm1_Click(object sender, RoutedEventArgs e)
        {
            MainWindow1 addProductWindow = new MainWindow1();
            addProductWindow.Show();
        }

        private void OpenForm2_Click(object sender, RoutedEventArgs e)
        {
            AddSupplierWindow addSupplierWindow = new AddSupplierWindow();
            addSupplierWindow.Show();
        }

        private void OpenForm3_Click(object sender, RoutedEventArgs e)
        {
            AddCustomerWindow addCustomerWindow = new AddCustomerWindow();
            addCustomerWindow.Show();
        }

        private void OpenForm4_Click(object sender, RoutedEventArgs e)
        {
            ViewProductsWindow viewProductsWindow = new ViewProductsWindow();
            viewProductsWindow.Show();
        }
        private void OpenForm5_Click(object sender, RoutedEventArgs e)
        {
            ViewSuppliersWindow viewSuppliersWindow = new ViewSuppliersWindow();
            viewSuppliersWindow.Show();
        }

        private void OpenForm6_Click(object sender, RoutedEventArgs e)
        {
            ViewCustomersWindow viewCustomersWindow = new ViewCustomersWindow();
            viewCustomersWindow.Show();
        }
        private void OpenForm7_Click(object sender, RoutedEventArgs e)
        {
            ViewSaleDetailsWindow viewSaleDetailsWindow = new ViewSaleDetailsWindow();
            viewSaleDetailsWindow.Show();
        }
    }
}
