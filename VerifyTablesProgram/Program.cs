using System;
using MySql.Data.MySqlClient;

namespace VerifyTablesProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "server=localhost;port=3306;database=3000N;user=root;password=;Allow User Variables=True;SslMode=None;";
            
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    
                    // Check if payment_distribution_principles table exists and show its structure
                    string showColumnsQuery = "SHOW COLUMNS FROM payment_distribution_principles";
                    MySqlCommand showColumnsCommand = new MySqlCommand(showColumnsQuery, connection);
                    
                    Console.WriteLine("Columns in payment_distribution_principles table:");
                    using (var reader = showColumnsCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"- {reader["Field"]} ({reader["Type"]}) {reader["Null"]}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}