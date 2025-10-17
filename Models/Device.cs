using System;

namespace Inspinia.Models
{
    public class Device
    {
        public int Id { get; set; }
        public string DeviceName { get; set; }
        public string MobileNumber { get; set; }
        public string DeviceNumber { get; set; }
        public string SerialNumber { get; set; }
        public string DeviceType { get; set; }
        public bool IsWorking { get; set; }
        public int QueueNumber { get; set; }
        public decimal Balance { get; set; }
        public string Account { get; set; }
        public bool IsBusy { get; set; }
        public string Network { get; set; }
        public string SimCode { get; set; }
        public decimal MinAmount { get; set; }
        public string Coverage { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime WarrantyExpiryDate { get; set; }
        public int Status { get; set; }
        public string Notes { get; set; }
    }
}