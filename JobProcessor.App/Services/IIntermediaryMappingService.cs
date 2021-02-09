using JobProcessor.App.ViewModels;
using JobProcessor.Domain.Models;

namespace JobProcessor.App.Services
{
    public interface IIntermediaryMappingService
    {
        JobCreationViewModel MapDomainToViewModel(Job job);
    }
}