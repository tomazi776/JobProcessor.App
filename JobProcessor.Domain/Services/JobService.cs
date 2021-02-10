using JobProcessor.DataAccess.Services;
using JobProcessor.Domain.Models;
using JobProcessor.Domain.Services;
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

        public Job Create(string name, DateTime? doAfter)
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
            jobsRepository.Create(mappedJob);
            return newJob;
        }

        public List<Job> Get()
        {
            var dalJobs = jobsRepository.Get();
            return mappingService.MapManyDALToDomainModel(dalJobs).ToList();
        }

        public List<Job> GetFiltered(int startIndex = 0, int pageSize = 0)
        {
            var filtered = jobsRepository.FactorToPaginate(startIndex, pageSize);
            var mappedFiltered = mappingService.MapManyDALToDomainModel(filtered);
            return mappedFiltered.ToList();
        }
    }
}
