using JobProcessor.DataAccess.Services;
using JobProcessor.Domain.Models;
using System;
using System.Collections.Generic;

namespace JobProcessor.Domain.Services
{
    public interface IJobService
    {
        EntityStateResult<Job> Create(string name, DateTime? doAfter = null);
        List<Job> Get(Metadata withMetadata = null);
        int GetFilteredCount(int startIndex = 0, int pageSize = 0);
    }
}
