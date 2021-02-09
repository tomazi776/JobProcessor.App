using JobProcessor.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobProcessor.DataAccess.Services
{
    public interface IJobsRepository
    {
        void Create(Job job);
    }
}
