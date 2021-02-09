using JobProcessor.DataAccess.Entities;
using JobProcessor.DataAccess.Services;
using System.Data.Entity;

namespace JobProcessor.DataAccess
{
    public class JobProcessorContext : DbContext, IDbContext
    {
        DbSet<Job> Jobs { get; set; }
        public JobProcessorContext() : base("name=JobProcessorAppDbCnn")
        {

        }
    }
}
