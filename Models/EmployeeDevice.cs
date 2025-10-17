using System;
using System.Collections.Generic;

namespace Inspinia.Models
{
    public class EmployeeDevice
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int DeviceTypeId { get; set; }
        public string DeviceType { get; set; }
        public string SerialNumber { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int Status { get; set; }
        public string Notes { get; set; }
    }
}