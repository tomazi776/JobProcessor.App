using JobProcessor.DataAccess.Services;
using JobProcessor.Domain.Models;
using JobProcessor.Domain.Services;
using System;

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

        public Job Create(string name, out int affectedRows, DateTime? doAfter)
        {
            var newJob = new Job()
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.Now,
                Name = name,
                DoAfter = doAfter,
                UpdatedAt = DateTime.Now,
                Status = JobStatus.New
            };

            var mappedJob = mappingService.MapDomainToDALModel(newJob);
            affectedRows = jobsRepository.Create(mappedJob);
            return newJob;
        }
    }
}
