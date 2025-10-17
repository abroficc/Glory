using System;

namespace Inspinia.Models
{
    public class CustomerDevice
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int DeviceTypeId { get; set; }
        public string DeviceType { get; set; }
        public string SerialNumber { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int Status { get; set; }
        public string Notes { get; set; }
    }
}