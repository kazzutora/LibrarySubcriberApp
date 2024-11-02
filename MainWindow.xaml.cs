using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
namespace JewelryStoreApp
{
    public partial class MainWindow1 : Window
    {
        private string connectionString = "Server=DESKTOP-CGB5USQ;Database=JewelryDB;Integrated Security=True;";

        public MainWindow1()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
{
    try
    {
        int productId;
        if (!int.TryParse(txtProductID.Text, out productId))
        {
            MessageBox.Show("Invalid Product ID. Please enter a valid integer number.");
            return;
        }

        string productName = txtProductName.Text;
        string productType = txtProductType.Text;
        string material = txtMaterial.Text;
        string weight = txtWeight.Text;
        string size = txtSize.Text;
        decimal price;
        if (!decimal.TryParse(txtPrice.Text, out price))
        {
            MessageBox.Show("Invalid price. Please enter a valid decimal number.");
            return;
        }

        string query = "INSERT INTO Product (ProductID, ProductName, ProductType, Material, Weight, Size, Price) VALUES (@ProductID, @ProductName, @ProductType, @Material, @Weight, @Size, @Price)";

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ProductID", productId);
            cmd.Parameters.AddWithValue("@ProductName", productName);
            cmd.Parameters.AddWithValue("@ProductType", productType);
            cmd.Parameters.AddWithValue("@Material", material);
            cmd.Parameters.AddWithValue("@Weight", weight);
            cmd.Parameters.AddWithValue("@Size", size);
            cmd.Parameters.AddWithValue("@Price", price);

            conn.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Product added successfully!");
            ClearFields();
        }
    }
    catch (SqlException sqlEx)
    {
        MessageBox.Show($"Database error: {sqlEx.Message}");
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Error: {ex.Message}");
    }
}

private void ClearFields()
{
    txtProductID.Clear();
    txtProductName.Clear();
    txtProductType.Clear();
    txtMaterial.Clear();
    txtWeight.Clear();
    txtSize.Clear();
    txtPrice.Clear();
}


    }
}