using System;
using System.Collections.Generic;

namespace Inspinia.Models
{
    public class Delivery
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int Status { get; set; }
        public string Notes { get; set; }
    }
}