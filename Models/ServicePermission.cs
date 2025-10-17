using System;
using System.Collections.Generic;

namespace Inspinia.Models
{
    public class ServicePermission
    {
        public int Id { get; set; }
        public string PrincipleName { get; set; }
        public string Description { get; set; }
        public string Conditions { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int Status { get; set; }
        public string Notes { get; set; }
        public List<ServiceInfo> Services { get; set; } = new List<ServiceInfo>();
    }

    public class ServiceInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsEnabled { get; set; }
        public string Category { get; set; }
    }
}