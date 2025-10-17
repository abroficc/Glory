using System;
using System.Collections.Generic;

namespace ASP.Net_Core_MVC.Full.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public int AccountId { get; set; }
    }
}