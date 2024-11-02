using System;
using System.Data.SqlClient;
using System.Windows;

namespace JewelryStoreApp
{
    public partial class ViewProductsWindow : Window
    {
        private string connectionString = "Server=localhost;Database=JewelryDB;Integrated Security=True;";

        public ViewProductsWindow()
        {
            InitializeComponent();
            LoadProducts();
        }

        private void LoadProducts()
        {
            string query = "SELECT * FROM Product";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                System.Data.DataTable dataTable = new System.Data.DataTable();

                try
                {
                    conn.Open();
                    adapter.Fill(dataTable);
                    dgProducts.ItemsSource = dataTable.DefaultView;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading products: {ex.Message}");
                }
            }
        }
    }
}
