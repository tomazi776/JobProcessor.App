using JobProcessor.DataAccess.Entities;
using JobProcessor.DataAccess.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace JobProcessor.DataAccess.JobsRepository
{
    public interface IJobsRepository : IFiltrable
    {
        Job Create(Job job);
        bool Exist(Job job);
        IEnumerable<Job> Get(Metadata withMetadata = null);
        Job GetById(Guid Id);
    }
}
