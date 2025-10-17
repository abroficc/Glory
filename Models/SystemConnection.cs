using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Glory77.Models
{
    [Table("system_connections")]
    public class SystemConnection
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("provider_id")]
        public int? ProviderId { get; set; }
        
        // Navigation property
        [ForeignKey("ProviderId")]
        public virtual Provider? Provider { get; set; }

        [Column("connection_time")]
        public DateTime? ConnectionTime { get; set; }

        [Column("system_name")]
        [StringLength(255)]
        public string? SystemName { get; set; }

        [Column("connection_status")]
        [StringLength(50)]
        public string? ConnectionStatus { get; set; }

        [Column("last_check")]
        public DateTime? LastCheck { get; set; }

        [Column("response_time")]
        public int ResponseTime { get; set; } = 0;

        [Column("error_message")]
        public string? ErrorMessage { get; set; }

        [Column("provider_type")]
        [StringLength(100)]
        public string? ProviderType { get; set; }

        [Column("balance")]
        public decimal Balance { get; set; } = 0;

        [Column("supported_networks")]
        public string? SupportedNetworks { get; set; }

        [Column("direction")]
        [StringLength(50)]
        public string? Direction { get; set; }

        [Column("account_sources")]
        public string? AccountSources { get; set; }

        [Column("employees")]
        public string? Employees { get; set; }

        [Column("alert_settings")]
        public string? AlertSettings { get; set; }

        [Column("suspension_settings")]
        public string? SuspensionSettings { get; set; }

        [Column("created_at")]
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}