using JobProcessor.DataAccess.Entities;
using System;
using System.Linq.Expressions;

namespace JobProcessor.DataAccess.JobsRepository
{
    public interface IJobsRepository
    {
        Job Create(Job job);
        bool Exist(Job job);
    }
}
