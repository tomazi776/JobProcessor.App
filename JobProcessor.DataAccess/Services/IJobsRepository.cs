using JobProcessor.DataAccess.Entities;
using System.Collections.Generic;

namespace JobProcessor.DataAccess.Services
{
    public interface IJobsRepository : IFiltrable<Job>
    {
        int Create(Job job);
        IEnumerable<Job> Get();
    }
}
