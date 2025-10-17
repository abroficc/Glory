using Microsoft.EntityFrameworkCore;
using Glory77.Models;
using Inspinia.Models;

namespace Glory77.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Add your DbSets here
        public DbSet<Provider> Providers { get; set; }
        public DbSet<MatchingReport> MatchingReports { get; set; }
        public DbSet<SystemConnection> SystemConnections { get; set; }
        public DbSet<BasicSetting> BasicSettings { get; set; }
        // Removed PaymentDistributionPrinciples DbSet
        public DbSet<EmployeeDevice> EmployeeDevices { get; set; }
        public DbSet<PaymentDistribution> PaymentDistributions { get; set; }
    }
}