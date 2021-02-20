using JobProcessor.DataAccess;
using JobProcessor.DataAccess.JobsRepository;
using JobProcessor.DataAccess.Services;
using JobProcessor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JobProcessor.Domain.Services
{
    public class JobService : IJobService
    {
        protected readonly IJobsRepository jobsRepository;
        protected readonly IIntermediaryMappingService mappingService;

        public JobService(IJobsRepository jobsRepository, IIntermediaryMappingService mappingService)
        {
            this.jobsRepository = jobsRepository;
            this.mappingService = mappingService;
        }

        public EntityStateResult<Job> Create(string name, DateTime? doAfter)
        {
            var domainJob = new Job(Guid.NewGuid(), name, JobStatus.New, doAfter, DateTime.Now, DateTime.Now, null);
            var job = mappingService.MapDomainToDALModel(domainJob);
            return (jobsRepository.Exist(job))
                ? new EntityStateResult<Job>() { ErrorMsg = "There already exists job with that name. Pick unique one.", Data = null }
                : new EntityStateResult<Job>() { Data = mappingService.MapDALToDomainModel(jobsRepository.Create(job)) };
        }

        public List<Job> Get(Metadata withMetadata)
        {
            var jobs = jobsRepository.Get(withMetadata);
            return mappingService.MapManyDALToDomainModel(jobs).ToList();
        }

        public int GetFilteredCount(int startIndex = 0, int pageSize = 0)
        {
            return jobsRepository.GetFilteredCount(startIndex, pageSize);
        }
    }
}
