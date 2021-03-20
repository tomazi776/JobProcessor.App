
using JobProcessor.Domain.Models;
using System.Collections.Generic;

namespace JobProcessor.Domain.Services
{
    public interface IIntermediaryMappingService
    {
        DataAccess.Entities.Job MapDomainToDALModel(Job job);

        Job MapDALToDomainModel(DataAccess.Entities.Job job);

        IEnumerable<Job> MapManyDALToDomainModel(IEnumerable<DataAccess.Entities.Job> job);

    }
}