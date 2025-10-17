using System;

namespace Inspinia.Models
{
    public class Backup
    {
        public int Id { get; set; }
        public string BackupName { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int Status { get; set; }
        public string Notes { get; set; }
    }
}