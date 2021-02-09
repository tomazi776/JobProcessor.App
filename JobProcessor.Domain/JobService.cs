using JobProcessor.Domain.Models;
using JobProcessor.Domain.Services;
using System;

namespace JobProcessor.Domain
{
    public class JobService : IJobService
    {
        public Job Create(string name, DateTime? doAfter) => new Job()
        {
            Id = Guid.NewGuid(),
            CreatedAt = DateTime.Now,
            Name = name,
            DoAfter = doAfter,
            UpdatedAt = DateTime.Now,
            Status = JobStatus.New
        };
    }
}
