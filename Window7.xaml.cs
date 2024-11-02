using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace WpfApp
{
    public partial class ViewSaleDetailsWindow : Window
    {
        private string connectionString = "Server=localhost;Database=JewelryDB;Integrated Security=True;";

        public ViewSaleDetailsWindow()
        {
            InitializeComponent();
            LoadSales();
        }

        private void LoadSales()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Sale";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();

                try
                {
                    conn.Open();
                    dataAdapter.Fill(dataTable);
                    dataGridSales.ItemsSource = dataTable.DefaultView;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }
    }
}
