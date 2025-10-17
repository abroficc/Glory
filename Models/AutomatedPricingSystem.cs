using System;

namespace Inspinia.Models
{
    public class AutomatedPricingSystem
    {
        public int Id { get; set; }
        public string SystemName { get; set; }
        public string Description { get; set; }
        public decimal BasePrice { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int Status { get; set; }
        public string Notes { get; set; }
    }
}