using System;
using System.Data.SqlClient;
using System.Windows;

using System.Collections.Generic;
using System.Data.SqlClient; // Додайте цю директиву
using System.Windows;

namespace LibrarySubscriberApp
{
    public partial class SubscribersWindow : Window
    {
        private string connectionString = "Server=localhost;Database=LibrarySubscriberDB;Integrated Security=True;"; // Ваш рядок підключення

        public SubscribersWindow()
        {
            InitializeComponent();
            LoadSubscribers();
        }

        private void LoadSubscribers()
        {
            var subscribers = new List<Subscriber>();

            // Підключення до бази даних
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Name, Surname, PhoneNumber FROM Subscribers"; // Ваш SQL-запит

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Додаємо абонентів до списку
                            subscribers.Add(new Subscriber
                            {
                                Name = reader["Name"].ToString(),
                                Surname = reader["Surname"].ToString(),
                                PhoneNumber = reader["PhoneNumber"].ToString()
                            });
                        }
                    }
                }
            }

            SubscribersListView.ItemsSource = subscribers; // Встановлюємо джерело даних для ListView
        }
    }

    public class Subscriber
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
    }
}
