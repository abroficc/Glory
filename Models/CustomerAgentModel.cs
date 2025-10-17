using System;
using System.Collections.Generic;

namespace ASP.Net_Core_MVC.Full.Models
{
    public class CustomerAgentModel
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public string StoreName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
        public string GroupName { get; set; }
        public string GroupType { get; set; }
        public string Device { get; set; }
        public string Operations { get; set; }
        public decimal SalesAmount { get; set; }
        public decimal AmountToPay { get; set; }
        public string Agent { get; set; }
        public decimal Balance { get; set; }
        public bool Connected { get; set; }
        public string AccountType { get; set; }
        public decimal AccountBalance { get; set; }
    }
}