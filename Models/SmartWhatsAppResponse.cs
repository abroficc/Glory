using System;

namespace Inspinia.Models
{
    public class SmartWhatsAppResponse
    {
        public int Id { get; set; }
        public string Keyword { get; set; }
        public string Response { get; set; }
        public string Category { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int Status { get; set; }
        public string Notes { get; set; }
    }
}