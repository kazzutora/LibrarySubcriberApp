using System;
using System.Data.SqlClient;
using System.Windows;

namespace JewelryStoreApp
{
    public partial class ViewCustomersWindow : Window
    {
        private string connectionString = "Server=localhost;Database=JewelryDB;Integrated Security=True;";

        public ViewCustomersWindow()
        {
            InitializeComponent();
            LoadCustomers();
        }

        private void LoadCustomers()
        {
            string query = "SELECT * FROM Customer";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                System.Data.DataTable dataTable = new System.Data.DataTable();

                try
                {
                    conn.Open();
                    adapter.Fill(dataTable);
                    dgCustomers.ItemsSource = dataTable.DefaultView;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading customers: {ex.Message}");
                }
            }
        }
    }
}
