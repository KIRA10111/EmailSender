
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

        // TODO: Each entity configuration should be in separate file
        // Create folder 'Configuration'
        // Move LoggingRequest settings to LoggingRequestConfiguration file 
        // This link help you 
        // https://www.entityframeworktutorial.net/code-first/move-configurations-to-seperate-class-in-code-first.aspx
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoggingRequest>().ToTable("LoggingRequest");
            modelBuilder.Entity<LoggingRequest>().HasKey(_ => _.Id);
            modelBuilder.Entity<LoggingRequest>().Property(_ => _.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            base.OnModelCreating(modelBuilder);
        }
    }
}
