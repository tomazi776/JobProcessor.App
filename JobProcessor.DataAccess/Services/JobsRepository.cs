﻿using JobProcessor.DataAccess.ContextConfig;
using JobProcessor.DataAccess.Entities;
using System.Collections.Generic;
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
            ctx.Jobs.Add(job);
            return ctx.SaveChanges();
        }

        public IEnumerable<Job> Get()
        {
            return ctx.Jobs.ToList();
        }
    }
}
