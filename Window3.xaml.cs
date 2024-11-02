using System;
using System.Data.SqlClient;
using System.Windows;

namespace JewelryStoreApp
{
    public partial class AddCustomerWindow : Window
    {
        private string connectionString = "Server=localhost;Database=JewelryDB;Integrated Security=True;";

        public AddCustomerWindow()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            int customerID;
            if (!int.TryParse(txtCustomerID.Text, out customerID))
            {
                MessageBox.Show("Please enter a valid integer for Customer ID.");
                return;
            }

            string customerName = txtCustomerName.Text;
            string contactInfo = txtContactInfo.Text;

            string query = "INSERT INTO Customer (CustomerID, CustomerName, ContactInfo) VALUES (@CustomerID, @CustomerName, @ContactInfo)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CustomerID", customerID);
                cmd.Parameters.AddWithValue("@CustomerName", customerName);
                cmd.Parameters.AddWithValue("@ContactInfo", contactInfo);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer added successfully!");
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        private void ClearFields()
        {
            txtCustomerID.Clear();
            txtCustomerName.Clear();
            txtContactInfo.Clear();
        }
    }
}
