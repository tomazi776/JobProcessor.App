using JobProcessor.DataAccess.Entities;

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
            ctx.Jobs.Add(job);
            return ctx.SaveChanges();
        }
    }
}
