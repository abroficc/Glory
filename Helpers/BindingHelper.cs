namespace Inspinia.Helpers
{
    /// <summary>
    /// مساعد للنصوص الطويلة المستخدمة في Binding لتجنب خطأ CS8103
    /// </summary>
    public static class BindingHelper
    {
        /// <summary>
        /// نص Binding لـ SystemConnection Create
        /// </summary>
        public const string SystemConnectionCreateBinding =
            "ProviderId,ConnectionTime,SystemName,ConnectionStatus,LastCheck,ResponseTime,ErrorMessage," +
            "ProviderType,Balance,SupportedNetworks,Direction,AccountSources,Employees,AlertSettings,SuspensionSettings";

        /// <summary>
        /// نص Binding لـ SystemConnection Edit
        /// </summary>
        public const string SystemConnectionEditBinding =
            "Id,ProviderId,ConnectionTime,SystemName,ConnectionStatus,LastCheck,ResponseTime,ErrorMessage," +
            "ProviderType,Balance,SupportedNetworks,Direction,AccountSources,Employees,AlertSettings,SuspensionSettings,CreatedAt";

        /// <summary>
        /// نص Binding لـ Employee Create
        /// </summary>
        public const string EmployeeCreateBinding =
            "FullName,PhoneNumber,Email,Position,Department,HireDate,Salary,Status,Notes";

        /// <summary>
        /// نص Binding لـ Employee Edit
        /// </summary>
        public const string EmployeeEditBinding =
            "Id,FullName,PhoneNumber,Email,Position,Department,HireDate,Salary,Status,Notes,CreatedAt,UpdatedAt";

        /// <summary>
        /// نص Binding لـ Customer Create
        /// </summary>
        public const string CustomerCreateBinding =
            "Name,PhoneNumber,Email,Address,City,Country,CustomerType,Status,Notes";

        /// <summary>
        /// نص Binding لـ Customer Edit
        /// </summary>
        public const string CustomerEditBinding =
            "Id,Name,PhoneNumber,Email,Address,City,Country,CustomerType,Status,Notes,CreatedAt,UpdatedAt";

        /// <summary>
        /// نص Binding لـ Provider Create
        /// </summary>
        public const string ProviderCreateBinding =
            "ProviderName,ProviderType,ContactInfo,ApiEndpoint,ApiKey,Status,Notes";

        /// <summary>
        /// نص Binding لـ Provider Edit
        /// </summary>
        public const string ProviderEditBinding =
            "Id,ProviderName,ProviderType,ContactInfo,ApiEndpoint,ApiKey,Status,Notes,CreatedAt,UpdatedAt";
    }
}
