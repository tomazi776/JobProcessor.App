using JobProcessor.DataAccess.ContextConfig;
using JobProcessor.DataAccess.Entities;
using JobProcessor.DataAccess.Services;
using System;
using System.Collections.Generic;
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

        public IEnumerable<Job> Get(Metadata withMetadata)
        {
            return (withMetadata is null) 
                ? ctx.Jobs.ToList() 
                : ctx.Jobs.OrderBy(j => j.CreatedAt).Skip(withMetadata.StartIndex).Take(withMetadata.PageSize).ToList();
        }

        public int GetFilteredCount(int startIndex, int pageSize)
        {
            var factoredCount = ctx.Jobs.OrderBy(j => j.CreatedAt).Skip(startIndex).Take(pageSize).Count();
            return factoredCount;
        }
    }
}
