using System;

namespace Glory77.Models  // Changed from Inspinia.Models to Glory77.Models
{
    public class SuppliesDiscount
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal DiscountPercentage { get; set; }
        public decimal FixedDiscount { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int Status { get; set; }
        public string Notes { get; set; }
    }
}