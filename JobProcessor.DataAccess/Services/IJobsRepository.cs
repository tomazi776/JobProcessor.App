using JobProcessor.DataAccess.Entities;

namespace JobProcessor.DataAccess.Services
{
    public interface IJobsRepository
    {
        int Create(Job job);
    }
}
