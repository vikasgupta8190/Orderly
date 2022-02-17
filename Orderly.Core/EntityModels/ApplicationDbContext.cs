using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Orderly.Core.Domain.Common;
using Orderly.Core.Domain.Contact;
using Orderly.Core.Domain.Investment;
using Orderly.Core.Domain.Portfolio;
using Orderly.Core.Domain.Log;
using Orderly.Core.Domain.Tokens;
using Orderly.Core.Domain.OverTheCounter;

namespace Orderly.Core.EntityModels
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<PortfolioMonitoring> PortfolioMonitorings { get; set; }
        public DbSet<MonitoringType> MonitoringTypes { get; set; }
        public DbSet<UserInvestment> UserInvestments { get; set; }
        public DbSet<InvestmentDynamicDistribution> InvestmentDynamicDistributions { get; set; }
        public DbSet<UserContactGroupMapping> UserContactGroupMappings { get; set; }
        public DbSet<UserContact> UserContact { get; set; }
        public DbSet<UserGroup> UserGroup { get; set; }
        public DbSet<ErrorLog> ErrorLog { get; set; }
        public DbSet<NetworkToken> NetworkTokens { get; set; }
        public DbSet<Monitoring> Monitorings { get; set; }
        public DbSet<Calendar> Calendars { get; set; }
        public DbSet<QueuedEmail> QueuedEmails { get; set; }
        public DbSet<OTC> OTCs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            {
                modelBuilder.Entity<UserInvestment>()
                .HasOne(b => b.MonitoringType)
                .WithOne(a => a.Investment)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

                modelBuilder.Entity<UserInvestment>()
               .HasIndex(x => x.MonitoringTypeId)
               .IsUnique(false); 
                
                modelBuilder.Entity<NetworkToken>()
                .HasOne(b => b.Network)
                .WithMany(a => a.Tokens)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

                modelBuilder.Entity<NetworkToken>()
               .HasIndex(x => x.NetworkId)
               .IsUnique(false);
            }
        }
    }
}
