using System;

namespace Inspinia.Models
{
    public class CommissionRatioGroup
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public string Description { get; set; }
        public decimal RatioPercentage { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int Status { get; set; }
        public string Notes { get; set; }
    }
}