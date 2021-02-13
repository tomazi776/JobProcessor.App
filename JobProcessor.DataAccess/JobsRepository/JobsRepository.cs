﻿using JobProcessor.DataAccess.ContextConfig;
using JobProcessor.DataAccess.Entities;
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

        public IEnumerable<Job> Get()
        {
            return ctx.Jobs.ToList();
        }

        public IEnumerable<Job> FactorToPaginate(int startIndex, int pageSize)
        {
            if (startIndex < 0)
            {
                startIndex = 0;
            }
            if (pageSize < 0)
            {
                pageSize = 0;
            }
            var factored = ctx.Jobs.OrderBy(j => j.CreatedAt).Skip(startIndex).Take(pageSize);
            var dupal = factored.ToList();
            return factored;
        }

        public int GetFilteredCount(int startIndex, int pageSize)
        {
            var factoredCount = ctx.Jobs.OrderBy(j => j.CreatedAt).Skip(startIndex).Take(pageSize).Count();
            return factoredCount;
        }
    }
}
