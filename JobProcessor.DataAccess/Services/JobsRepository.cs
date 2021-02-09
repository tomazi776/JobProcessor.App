using JobProcessor.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobProcessor.DataAccess.Services
{
    public class JobsRepository : IJobsRepository
    {
        protected readonly IDbContext ctx;

        public JobsRepository(IDbContext ctx)
        {
            this.ctx = ctx;
        }

        public void Create(Job job)
        {
            ctx.Jobs.Add(job);
            ctx.SaveChanges();
        }
    }
}
