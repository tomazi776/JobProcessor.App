using JobProcessor.App.ViewModels;
using JobProcessor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobProcessor.App.Services
{
    public interface IIntermediaryMappingService
    {
        JobCreationViewModel MapDomainToViewModel(Job job);
    }
}