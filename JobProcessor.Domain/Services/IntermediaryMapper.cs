using System;
using System.Collections.Generic;

namespace JobProcessor.Domain.Services
{
    public class IntermediaryMapper : IIntermediaryMappingService
    {
        public Models.Job MapDALToDomainModel(DataAccess.Entities.Job job)
        {
            return new Models.Job()
            {
                Id = job.Id,
                Name = job.Name,
                Counter = job.Counter,
                Status = (JobStatus)job.StatusFlag,
                DoAfter = job.DoAfter,
                CreatedAt = job.CreatedAt,
                UpdatedAt = (DateTime)job.UpdatedAt
            };
        }

        public DataAccess.Entities.Job MapDomainToDALModel(Models.Job job)
        {
            return new DataAccess.Entities.Job()
            {
                Id = job.Id,
                Name = job.Name,
                Counter = job.Counter,
                StatusFlag = (DataAccess.JobStatus)job.Status,
                DoAfter = job.DoAfter,
                CreatedAt = job.CreatedAt,
                UpdatedAt = job.UpdatedAt
            };
        }

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
