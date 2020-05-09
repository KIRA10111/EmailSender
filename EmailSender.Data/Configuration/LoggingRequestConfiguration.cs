using EmailSender.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EmailSender.Data
{
    class LoggingRequestConfiguration : EntityTypeConfiguration<LoggingRequest>
    {
        public LoggingRequestConfiguration()
        {
            this.ToTable("LoggingRequest");
            this.HasKey<int>(_ => _.Id);
            this.Property(_ => _.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }

    }
}
