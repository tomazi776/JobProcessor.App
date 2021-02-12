using JobProcessor.DataAccess.Entities;
using JobProcessor.DataAccess.Migrations;
using System.Data.Entity;

namespace JobProcessor.DataAccess.ContextConfig
{
    public class JobProcessorContext : DbContext, IDbContext
    {
        public DbSet<Job> Jobs { get; set; }
        public JobProcessorContext() : base("name=JobProcessorAppDbCnn")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<JobProcessorContext, Configuration>());
        }
    }
}
