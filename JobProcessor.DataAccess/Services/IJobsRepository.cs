using JobProcessor.DataAccess.Entities;
using System.Collections.Generic;

namespace JobProcessor.DataAccess.Services
{
    public interface IJobsRepository
    {
        int Create(Job job);
        IEnumerable<Job> Get();
    }
}
