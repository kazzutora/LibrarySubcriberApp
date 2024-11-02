using System;
using System.Data.SqlClient;
using System.Windows;

namespace JewelryStoreApp
{
    public partial class ViewSuppliersWindow : Window
    {
        private string connectionString = "Server=localhost;Database=JewelryDB;Integrated Security=True;";

        public ViewSuppliersWindow()
        {
            InitializeComponent();
            LoadSuppliers();
        }

        private void LoadSuppliers()
        {
            string query = "SELECT * FROM Supplier";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                System.Data.DataTable dataTable = new System.Data.DataTable();

                try
                {
                    conn.Open();
                    adapter.Fill(dataTable);
                    dgSuppliers.ItemsSource = dataTable.DefaultView;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading suppliers: {ex.Message}");
                }
            }
        }
    }
}
