using JobProcessor.DataAccess.ContextConfig;
using JobProcessor.DataAccess.Entities;
using System.Linq;

namespace JobProcessor.DataAccess.Services
{
    public class JobsRepository : IJobsRepository
    {
        protected readonly IDbContext ctx;

        public JobsRepository(IDbContext ctx)
        {
            this.ctx = ctx;
        }

        public int Create(Job job)
        {
            var exists = ctx.Jobs.Any(j => j.Name == job.Name);
            if (exists)
            {
                return 0;
            }
            else
            {
                ctx.Jobs.Add(job);
                return ctx.SaveChanges();
            }
        }
    }
}
