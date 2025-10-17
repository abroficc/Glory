using System;
using MySql.Data.MySqlClient;
using System.IO;

namespace CreateTableProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "server=localhost;port=3306;database=3000N;user=root;password=;Allow User Variables=True;SslMode=None;";
            
            // Drop and create system_connections table (existing code)
            string dropSystemConnectionsTableQuery = "DROP TABLE IF EXISTS `system_connections`";
            string createSystemConnectionsTableQuery = @"
                CREATE TABLE `system_connections` (
                  `id` int NOT NULL AUTO_INCREMENT,
                  `provider_id` int DEFAULT NULL,
                  `connection_time` datetime DEFAULT NULL,
                  `system_name` varchar(255) DEFAULT NULL,
                  `connection_status` varchar(50) DEFAULT NULL,
                  `last_check` datetime DEFAULT NULL,
                  `response_time` int DEFAULT '0',
                  `error_message` text,
                  `provider_type` varchar(100) DEFAULT NULL,
                  `balance` decimal(10,2) DEFAULT '0.00',
                  `supported_networks` text,
                  `direction` varchar(50) DEFAULT NULL,
                  `account_sources` text,
                  `employees` text,
                  `alert_settings` text,
                  `suspension_settings` text,
                  `created_at` datetime NOT NULL,
                  PRIMARY KEY (`id`)
                ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;";

            // Drop and create basic_settings table
            string dropBasicSettingsTableQuery = "DROP TABLE IF EXISTS `basic_settings`";
            string createBasicSettingsTableQuery = @"
                CREATE TABLE `basic_settings` (
                  `id` int NOT NULL AUTO_INCREMENT,
                  `send_transfer_service_id` int DEFAULT NULL,
                  `receive_transfer_service_id` int DEFAULT NULL,
                  `instant_recharge_service_id` int DEFAULT NULL,
                  `instant_recharge_yemen_mobile_service_id` int DEFAULT NULL,
                  `instant_recharge_you_service_id` int DEFAULT NULL,
                  `instant_recharge_sabafon_service_id` int DEFAULT NULL,
                  `instant_recharge_wai_service_id` int DEFAULT NULL,
                  `you_packages_service_id` int DEFAULT NULL,
                  `sabafon_packages_service_id` int DEFAULT NULL,
                  `sabafon_units_service_id` int DEFAULT NULL,
                  `mobile_balance_service_id` int DEFAULT NULL,
                  `wholesale_service_id` int DEFAULT NULL,
                  `fixed_discounts_service_id` int DEFAULT NULL,
                  `internet_discounts_service_id` int DEFAULT NULL,
                  `mobile_wholesale_service_id` int DEFAULT NULL,
                  `sabafon_wholesale_service_id` int DEFAULT NULL,
                  `you_wholesale_service_id` int DEFAULT NULL,
                  `yemen_mobile_packages_service_id` int DEFAULT NULL,
                  `fixed_phone_service_id` int DEFAULT NULL,
                  `landline_internet_service_id` int DEFAULT NULL,
                  `sabafon_south_packages_service_id` int DEFAULT NULL,
                  `instant_recharge_sabafon_south_service_id` int DEFAULT NULL,
                  `wifi_cards_sales_service_id` int DEFAULT NULL,
                  `manual_services_numbers` text,
                  `default_currency` varchar(50) DEFAULT NULL,
                  `default_commission_account_id` int DEFAULT NULL,
                  `sms_notification_services` text,
                  `transfer_between_accounts_number` varchar(255) DEFAULT NULL,
                  `commissions_added_by_admin_number` varchar(255) DEFAULT NULL,
                  `exchange_fund_account_number` varchar(255) DEFAULT NULL,
                  `full_cards_sales_client_account_number` varchar(255) DEFAULT NULL,
                  `sms_payment_numbers` text,
                  `design_number` int DEFAULT NULL,
                  `alkareem_direct_account_numbers` text,
                  `alkareem_north_account_numbers` text,
                  `alkareem_south_account_numbers` text,
                  `whatsapp_numbers` text,
                  `sms_payment_waiting_minutes` int DEFAULT NULL,
                  `additional_amount_for_sms_payment` decimal(10,2) DEFAULT '0.00',
                  `provider_amount_type` varchar(50) DEFAULT NULL,
                  `feeder_name` varchar(255) DEFAULT NULL,
                  `feeder_phone` varchar(50) DEFAULT NULL,
                  `chat_image_upload_token` text,
                  `web_app_url` varchar(500) DEFAULT NULL,
                  `employee_login_notification_accounts` text,
                  `whatsapp_confirmation_devices` text,
                  `created_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
                  `updated_at` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
                  PRIMARY KEY (`id`)
                ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    
                    // Drop and create system_connections table
                    MySqlCommand dropCommand1 = new MySqlCommand(dropSystemConnectionsTableQuery, connection);
                    dropCommand1.ExecuteNonQuery();
                    Console.WriteLine("Table 'system_connections' dropped.");
                    
                    MySqlCommand command1 = new MySqlCommand(createSystemConnectionsTableQuery, connection);
                    command1.ExecuteNonQuery();
                    Console.WriteLine("Table 'system_connections' created successfully.");
                    
                    // Drop and create basic_settings table
                    MySqlCommand dropCommand2 = new MySqlCommand(dropBasicSettingsTableQuery, connection);
                    dropCommand2.ExecuteNonQuery();
                    Console.WriteLine("Table 'basic_settings' dropped.");
                    
                    MySqlCommand command2 = new MySqlCommand(createBasicSettingsTableQuery, connection);
                    command2.ExecuteNonQuery();
                    Console.WriteLine("Table 'basic_settings' created successfully.");
                    
                    // Removed payment_distribution_principles table creation
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}