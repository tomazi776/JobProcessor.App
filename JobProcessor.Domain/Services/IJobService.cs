using JobProcessor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobProcessor.Domain.Services
{
    public interface IJobService
    {
        Job Create(string name, DateTime? doAfter = null);
    }
}
