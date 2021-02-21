using JobProcessor.Domain.Models;
using System;

namespace JobProcessor.Domain.Services
{
    public interface IJobService
    {
        EntityStateResult<Job> Create(string name, DateTime? doAfter = null);
        EntityStateResult<Job> GetById(Guid jobId);
    }
}
