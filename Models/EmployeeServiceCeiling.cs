using System;

namespace Inspinia.Models
{
    public class EmployeeServiceCeiling
    {
        public int Id { get; set; }
        public string CeilingName { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int Status { get; set; }
        public string Notes { get; set; }
    }
}