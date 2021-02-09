using JobProcessor.Domain.Models;
using System;

namespace JobProcessor.Domain.Services
{
    public interface IJobService
    {
        Job Create(string name, DateTime? doAfter = null);
    }
}
