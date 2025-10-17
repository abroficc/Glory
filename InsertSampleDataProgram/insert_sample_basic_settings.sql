INSERT INTO `basic_settings` (
  `send_transfer_service_id`,
  `receive_transfer_service_id`,
  `instant_recharge_service_id`,
  `instant_recharge_yemen_mobile_service_id`,
  `instant_recharge_you_service_id`,
  `instant_recharge_sabafon_service_id`,
  `instant_recharge_wai_service_id`,
  `you_packages_service_id`,
  `sabafon_packages_service_id`,
  `sabafon_units_service_id`,
  `mobile_balance_service_id`,
  `wholesale_service_id`,
  `fixed_discounts_service_id`,
  `internet_discounts_service_id`,
  `mobile_wholesale_service_id`,
  `sabafon_wholesale_service_id`,
  `you_wholesale_service_id`,
  `yemen_mobile_packages_service_id`,
  `fixed_phone_service_id`,
  `landline_internet_service_id`,
  `sabafon_south_packages_service_id`,
  `instant_recharge_sabafon_south_service_id`,
  `wifi_cards_sales_service_id`,
  `manual_services_numbers`,
  `default_currency`,
  `default_commission_account_id`,
  `sms_notification_services`,
  `transfer_between_accounts_number`,
  `commissions_added_by_admin_number`,
  `exchange_fund_account_number`,
  `full_cards_sales_client_account_number`,
  `sms_payment_numbers`,
  `design_number`,
  `alkareem_direct_account_numbers`,
  `alkareem_north_account_numbers`,
  `alkareem_south_account_numbers`,
  `whatsapp_numbers`,
  `sms_payment_waiting_minutes`,
  `additional_amount_for_sms_payment`,
  `provider_amount_type`,
  `feeder_name`,
  `feeder_phone`,
  `chat_image_upload_token`,
  `web_app_url`,
  `employee_login_notification_accounts`,
  `whatsapp_confirmation_devices`
) VALUES (
  148,   -- send_transfer_service_id
  156,   -- receive_transfer_service_id
  145,   -- instant_recharge_service_id
  206,   -- instant_recharge_yemen_mobile_service_id
  281,   -- instant_recharge_you_service_id
  101,   -- instant_recharge_sabafon_service_id
  155,   -- instant_recharge_wai_service_id
  117,   -- you_packages_service_id
  206,   -- sabafon_packages_service_id
  101,   -- sabafon_units_service_id
  155,   -- mobile_balance_service_id
  117,   -- wholesale_service_id
  0,     -- fixed_discounts_service_id
  149,   -- internet_discounts_service_id
  157,   -- mobile_wholesale_service_id
  127,   -- sabafon_wholesale_service_id
  146,   -- you_wholesale_service_id
  207,   -- yemen_mobile_packages_service_id
  282,   -- fixed_phone_service_id
  102,   -- landline_internet_service_id
  156,   -- sabafon_south_packages_service_id
  118,   -- instant_recharge_sabafon_south_service_id
  0,     -- wifi_cards_sales_service_id
  '120-115-170',  -- manual_services_numbers
  'ريال يمني',  -- default_currency
  1,     -- default_commission_account_id
  'اضافة تامين للعميل,اضافة يومية للعميل,تفعيل حساب العميل,إرسال حوالة مالية,التحويل الى حساب عميل اخر,اضافة قرض للعميل,اضافة عموله للعميل,شراء فاتورة,بيع فاتورة',  -- sms_notification_services
  '123456789',  -- transfer_between_accounts_number
  '987654321',  -- commissions_added_by_admin_number
  '111111111',  -- exchange_fund_account_number
  '222222222',  -- full_cards_sales_client_account_number
  '777777777,733333333,711111111',  -- sms_payment_numbers
  1,     -- design_number
  '777777777,333333333,111111111',  -- alkareem_direct_account_numbers
  '777777778,333333334,111111112',  -- alkareem_north_account_numbers
  '777777779,333333335,111111113',  -- alkareem_south_account_numbers
  '777777777,333333333,111111111',  -- whatsapp_numbers
  5,     -- sms_payment_waiting_minutes
  0.00,  -- additional_amount_for_sms_payment
  'صافي',  -- provider_amount_type
  'محمد أحمد',  -- feeder_name
  '777777777',  -- feeder_phone
  'sample_token_12345',  -- chat_image_upload_token
  'https://example.com',  -- web_app_url
  '111,222,333',  -- employee_login_notification_accounts
  '777777777,733333333,711111111'  -- whatsapp_confirmation_devices
);