using JobProcessor.Domain.Models;
using System;
using System.Collections.Generic;

namespace JobProcessor.Domain.Services
{
    public interface IJobService
    {
        Job Create(string name, DateTime? doAfter = null);
        List<Job> Get();
        List<Job> GetFiltered(int startIndex = 0, int pageSize = 0);
        int GetFilteredCount(int startIndex = 0, int pageSize = 0);

    }
}
