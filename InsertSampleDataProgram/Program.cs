using System;
using MySql.Data.MySqlClient;
using System.IO;

namespace InsertSampleDataProgram
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
                    
                    // Insert sample data for basic settings
                    string sqlScriptPath = Path.Combine(Directory.GetCurrentDirectory(), "..", "Glory77", "insert_sample_basic_settings.sql");
                    if (!File.Exists(sqlScriptPath))
                    {
                        // Try alternative path
                        sqlScriptPath = Path.Combine(Directory.GetCurrentDirectory(), "insert_sample_basic_settings.sql");
                    }
                    
                    if (File.Exists(sqlScriptPath))
                    {
                        string insertQuery = File.ReadAllText(sqlScriptPath);
                        MySqlCommand command = new MySqlCommand(insertQuery, connection);
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine($"SUCCESS: {rowsAffected} row(s) inserted into 'basic_settings' table.");
                        
                        // Verify the data was inserted for basic settings
                        string countQuery = "SELECT COUNT(*) FROM basic_settings";
                        MySqlCommand countCommand = new MySqlCommand(countQuery, connection);
                        var countResult = countCommand.ExecuteScalar();
                        Console.WriteLine($"The basic_settings table now contains {countResult} records.");
                    }
                    else
                    {
                        Console.WriteLine("Basic settings SQL script not found.");
                    }
                    
                    // Insert sample data for payment distribution principles
                    string paymentPrinciplesScriptPath = Path.Combine(Directory.GetCurrentDirectory(), "..", "Glory77", "insert_sample_payment_distribution_principles.sql");
                    if (!File.Exists(paymentPrinciplesScriptPath))
                    {
                        // Try alternative path
                        paymentPrinciplesScriptPath = Path.Combine(Directory.GetCurrentDirectory(), "insert_sample_payment_distribution_principles.sql");
                    }
                    
                    if (File.Exists(paymentPrinciplesScriptPath))
                    {
                        string paymentPrinciplesInsertQuery = File.ReadAllText(paymentPrinciplesScriptPath);
                        MySqlCommand paymentPrinciplesCommand = new MySqlCommand(paymentPrinciplesInsertQuery, connection);
                        int paymentPrinciplesRowsAffected = paymentPrinciplesCommand.ExecuteNonQuery();
                        Console.WriteLine($"SUCCESS: {paymentPrinciplesRowsAffected} row(s) inserted into 'payment_distribution_principles' table.");
                        
                        // Verify the data was inserted for payment distribution principles
                        string paymentPrinciplesCountQuery = "SELECT COUNT(*) FROM payment_distribution_principles";
                        MySqlCommand paymentPrinciplesCountCommand = new MySqlCommand(paymentPrinciplesCountQuery, connection);
                        var paymentPrinciplesCountResult = paymentPrinciplesCountCommand.ExecuteScalar();
                        Console.WriteLine($"The payment_distribution_principles table now contains {paymentPrinciplesCountResult} records.");
                    }
                    else
                    {
                        Console.WriteLine("Payment distribution principles SQL script not found.");
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