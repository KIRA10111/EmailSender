
using System.Data.Entity;
using EmailSender.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using EmailSender.Data.Migrations;

namespace EmailSender.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(string connectionString) : base(connectionString)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }
        public ApplicationDbContext() : base("Default")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }
        public DbSet<LoggingRequest> LoggingRequest { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoggingRequest>().ToTable("LoggingRequest");
            modelBuilder.Entity<LoggingRequest>().HasKey(_ => _.Id);
            modelBuilder.Entity<LoggingRequest>().Property(_ => _.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            base.OnModelCreating(modelBuilder);
        }
    }
}
