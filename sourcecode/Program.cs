using System;
using System.Data.SqlClient;

class Program
{
    static void Main(string[] args)
    {
        // User input
        Console.Write("Enter username: ");
        string username = Console.ReadLine();

        Console.Write("Enter password: ");
        string password = Console.ReadLine();

        // Database connection
        string connectionString = "Server=DESKTOP-6VCCG31;Database=TaskDB;User Id=DESKTOP-6VCCG31";

        // Unsafe SQL query concatenation
        string query = "SELECT * FROM Users WHERE Username = '" + username + "' AND Password = '" + password + "';";

        // Execute the query
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    Console.WriteLine("Login successful!");
                }
                else
                {
                    Console.WriteLine("Invalid login credentials.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
