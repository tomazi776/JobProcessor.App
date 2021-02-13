
using System.Collections.Generic;

namespace JobProcessor.Domain.Services
{
    public class IntermediaryMapper : IIntermediaryMappingService
    {
        public Models.Job MapDALToDomainModel(DataAccess.Entities.Job job) => 
            new Models.Job(job.Id, job.Name, job.StatusFlag, job.DoAfter, job.CreatedAt, job.UpdatedAt, job.Counter);
        
        public DataAccess.Entities.Job MapDomainToDALModel(Models.Job job) => 
            new DataAccess.Entities.Job(job.Id, job.Name, job.Status, job.DoAfter, job.CreatedAt, job.UpdatedAt, job.Counter);

        public IEnumerable<Models.Job> MapManyDALToDomainModel(IEnumerable<DataAccess.Entities.Job> jobs)
        {
            var mappedJobs = new List<Models.Job>();

            foreach (var job in jobs)
            {
                mappedJobs.Add(MapDALToDomainModel(job));
            }
            return mappedJobs;
        }
    }
}
