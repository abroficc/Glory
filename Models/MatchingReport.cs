using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Glory77.Models
{
    [Table("matching_reports")]
    public class MatchingReport
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("provider_id")]
        public int? ProviderId { get; set; }
        
        // Navigation property
        [ForeignKey("ProviderId")]
        public virtual Provider Provider { get; set; }

        [Column("report_time")]
        public DateTime? ReportTime { get; set; }

        [Column("networks")]
        public string Networks { get; set; }

        [Column("total_ready_provider")]
        public decimal TotalReadyProvider { get; set; } = 0;

        [Column("total_ready_system")]
        public decimal TotalReadySystem { get; set; } = 0;

        [Column("count_ready_provider")]
        public int CountReadyProvider { get; set; } = 0;

        [Column("count_ready_system")]
        public int CountReadySystem { get; set; } = 0;

        [Column("total_cancelled_provider")]
        public decimal TotalCancelledProvider { get; set; } = 0;

        [Column("total_cancelled_system")]
        public decimal TotalCancelledSystem { get; set; } = 0;

        [Column("count_cancelled_provider")]
        public int CountCancelledProvider { get; set; } = 0;

        [Column("count_cancelled_system")]
        public int CountCancelledSystem { get; set; } = 0;

        [Column("total_pending_provider")]
        public decimal TotalPendingProvider { get; set; } = 0;

        [Column("total_pending_system")]
        public decimal TotalPendingSystem { get; set; } = 0;

        [Column("count_pending_provider")]
        public int CountPendingProvider { get; set; } = 0;

        [Column("count_pending_system")]
        public int CountPendingSystem { get; set; } = 0;

        [Column("matching_status")]
        [StringLength(50)]
        public string MatchingStatus { get; set; }

        [Column("created_at")]
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}