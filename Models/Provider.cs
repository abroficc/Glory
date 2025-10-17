using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Glory77.Models
{
    [Table("providers")]
    public class Provider
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("provider_name")]
        [Required]
        [StringLength(255)]
        public string? ProviderName { get; set; }

        [Column("status")]
        public byte Status { get; set; } = 1;

        [Column("created_at")]
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        
        // Navigation property
        public virtual ICollection<MatchingReport>? MatchingReports { get; set; } = new List<MatchingReport>();
    }
}