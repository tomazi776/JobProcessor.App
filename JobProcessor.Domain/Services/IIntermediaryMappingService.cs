
using JobProcessor.Domain.Models;

namespace JobProcessor.Domain.Services
{
    public interface IIntermediaryMappingService
    {
        DataAccess.Entities.Job MapDomainToDALModel(Job job);

        Job MapDALToDomainModel(DataAccess.Entities.Job job);
    }
}