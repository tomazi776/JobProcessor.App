﻿using JobProcessor.DataAccess.JobsRepository;
using JobProcessor.Domain.Models;
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

        public EntityStateResult<Job> Create(string name, DateTime? doAfter)
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

            var job = mappingService.MapDomainToDALModel(newJob);
            return (jobsRepository.Exist(job))
                ? new EntityStateResult<Job>() { ErrorMsg = "There already exists job with that name. Pick unique one.", Data = null }
                : new EntityStateResult<Job>() { Data = mappingService.MapDALToDomainModel(jobsRepository.Create(job)) };
        }
    }
}
