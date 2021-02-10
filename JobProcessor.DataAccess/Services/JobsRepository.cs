using JobProcessor.DataAccess.ContextConfig;
using JobProcessor.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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

        public IEnumerable<Job> Get()
        {
            return ctx.Jobs.ToList();
        }

        public IEnumerable<Job> FactorToPaginate(int startIndex, int pageSize)
        {
            var factored = ctx.Jobs.OrderBy(j => j.CreatedAt).Take(pageSize).Skip(startIndex);
            return factored;
        }
    }
}
