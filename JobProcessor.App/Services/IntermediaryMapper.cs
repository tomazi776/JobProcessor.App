using JobProcessor.App.ViewModels;
using JobProcessor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobProcessor.App.Services
{
    public class IntermediaryMapper : IIntermediaryMappingService
    {
        public JobCreationViewModel MapDomainToViewModel(Job job)
        {
            throw new NotImplementedException();
        }
    }
}
