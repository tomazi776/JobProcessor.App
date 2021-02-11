using JobProcessor.Domain.Models;
using System;

namespace JobProcessor.Domain.Services
{
    public interface IJobService
    {
        Job Create(string name, out int affectedRows, DateTime? doAfter = null );
    }
}
