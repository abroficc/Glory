using System;

namespace Inspinia.Models
{
    public class WebDevice
    {
        public int Id { get; set; }
        public int DeviceTypeId { get; set; }
        public string DeviceType { get; set; }
        public string SerialNumber { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime WarrantyExpiryDate { get; set; }
        public int Status { get; set; }
        public string Notes { get; set; }
    }
}