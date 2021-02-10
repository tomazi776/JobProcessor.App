using JobProcessor.Domain.Models;
using System;
using System.Collections.Generic;

namespace JobProcessor.Domain.Services
{
    public interface IJobService
    {
        Job Create(string name, DateTime? doAfter = null);
        List<Job> Get();
    }
}
