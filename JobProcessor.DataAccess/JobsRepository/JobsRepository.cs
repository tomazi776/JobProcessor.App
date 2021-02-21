using JobProcessor.DataAccess.ContextConfig;
using JobProcessor.DataAccess.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace JobProcessor.DataAccess.JobsRepository
{
    public class JobsRepository : IJobsRepository
    {
        protected readonly IDbContext ctx;

        public JobsRepository(IDbContext ctx)
        {
            this.ctx = ctx;
        }

        public Job Create(Job job)
        {
            ctx.Jobs.Add(job);
            ctx.SaveChanges();
            return job;
        }

        public bool Exist(Job job) => ctx.Jobs.Any(j => j.Name == job.Name);

        public Job GetById(Guid Id)
        {
            return ctx.Jobs.FirstOrDefault(job => job.Id == Id);
        }
    }
}
