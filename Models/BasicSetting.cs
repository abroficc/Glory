using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Glory77.Models
{
    [Table("basic_settings")]
    public class BasicSetting
    {
        public int Id { get; set; }
        
        // Transfer and charging services
        [Column("send_transfer_service_id")]
        public int? SendTransferServiceId { get; set; }
        
        [Column("receive_transfer_service_id")]
        public int? ReceiveTransferServiceId { get; set; }
        
        [Column("instant_recharge_service_id")]
        public int? InstantRechargeServiceId { get; set; }
        
        [Column("instant_recharge_yemen_mobile_service_id")]
        public int? InstantRechargeYemenMobileServiceId { get; set; }
        
        [Column("instant_recharge_you_service_id")]
        public int? InstantRechargeYouServiceId { get; set; }
        
        [Column("instant_recharge_sabafon_service_id")]
        public int? InstantRechargeSabafonServiceId { get; set; }
        
        [Column("instant_recharge_wai_service_id")]
        public int? InstantRechargeWaiServiceId { get; set; }
        
        [Column("you_packages_service_id")]
        public int? YouPackagesServiceId { get; set; }
        
        [Column("sabafon_packages_service_id")]
        public int? SabafonPackagesServiceId { get; set; }
        
        [Column("sabafon_units_service_id")]
        public int? SabafonUnitsServiceId { get; set; }
        
        [Column("mobile_balance_service_id")]
        public int? MobileBalanceServiceId { get; set; }
        
        [Column("wholesale_service_id")]
        public int? WholesaleServiceId { get; set; }
        
        [Column("fixed_discounts_service_id")]
        public int? FixedDiscountsServiceId { get; set; }
        
        [Column("internet_discounts_service_id")]
        public int? InternetDiscountsServiceId { get; set; }
        
        [Column("mobile_wholesale_service_id")]
        public int? MobileWholesaleServiceId { get; set; }
        
        [Column("sabafon_wholesale_service_id")]
        public int? SabafonWholesaleServiceId { get; set; }
        
        [Column("you_wholesale_service_id")]
        public int? YouWholesaleServiceId { get; set; }
        
        [Column("yemen_mobile_packages_service_id")]
        public int? YemenMobilePackagesServiceId { get; set; }
        
        [Column("fixed_phone_service_id")]
        public int? FixedPhoneServiceId { get; set; }
        
        [Column("landline_internet_service_id")]
        public int? LandlineInternetServiceId { get; set; }
        
        [Column("sabafon_south_packages_service_id")]
        public int? SabafonSouthPackagesServiceId { get; set; }
        
        [Column("instant_recharge_sabafon_south_service_id")]
        public int? InstantRechargeSabafonSouthServiceId { get; set; }
        
        [Column("wifi_cards_sales_service_id")]
        public int? WifiCardsSalesServiceId { get; set; }
        
        // Manual services numbers (dash separated)
        [Column("manual_services_numbers")]
        public string ManualServicesNumbers { get; set; }
        
        // Default currency
        [Column("default_currency")]
        public string DefaultCurrency { get; set; }
        
        // Default commission account
        [Column("default_commission_account_id")]
        public int? DefaultCommissionAccountId { get; set; }
        
        // SMS notification services (comma separated)
        [Column("sms_notification_services")]
        public string SmsNotificationServices { get; set; }
        
        // Account numbers
        [Column("transfer_between_accounts_number")]
        public string TransferBetweenAccountsNumber { get; set; }
        
        [Column("commissions_added_by_admin_number")]
        public string CommissionsAddedByAdminNumber { get; set; }
        
        [Column("exchange_fund_account_number")]
        public string ExchangeFundAccountNumber { get; set; }
        
        [Column("full_cards_sales_client_account_number")]
        public string FullCardsSalesClientAccountNumber { get; set; }
        
        // SMS payment numbers (comma separated)
        [Column("sms_payment_numbers")]
        public string SmsPaymentNumbers { get; set; }
        
        // Design number
        [Column("design_number")]
        public int? DesignNumber { get; set; }
        
        // Alkareem account numbers (comma separated)
        [Column("alkareem_direct_account_numbers")]
        public string AlkareemDirectAccountNumbers { get; set; }
        
        [Column("alkareem_north_account_numbers")]
        public string AlkareemNorthAccountNumbers { get; set; }
        
        [Column("alkareem_south_account_numbers")]
        public string AlkareemSouthAccountNumbers { get; set; }
        
        // WhatsApp numbers (comma separated)
        [Column("whatsapp_numbers")]
        public string WhatsappNumbers { get; set; }
        
        // SMS payment settings
        [Column("sms_payment_waiting_minutes")]
        public int? SmsPaymentWaitingMinutes { get; set; }
        
        [Column("additional_amount_for_sms_payment")]
        public decimal? AdditionalAmountForSmsPayment { get; set; }
        
        // Provider amount type
        [Column("provider_amount_type")]
        public string ProviderAmountType { get; set; }
        
        // Feeder information
        [Column("feeder_name")]
        public string FeederName { get; set; }
        
        [Column("feeder_phone")]
        public string FeederPhone { get; set; }
        
        // Chat image upload token
        [Column("chat_image_upload_token")]
        public string ChatImageUploadToken { get; set; }
        
        // Web app URL
        [Column("web_app_url")]
        public string WebAppUrl { get; set; }
        
        // Employee login notification accounts (comma separated)
        [Column("employee_login_notification_accounts")]
        public string EmployeeLoginNotificationAccounts { get; set; }
        
        // WhatsApp confirmation devices (comma separated)
        [Column("whatsapp_confirmation_devices")]
        public string WhatsappConfirmationDevices { get; set; }
        
        // Timestamps
        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        
        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}