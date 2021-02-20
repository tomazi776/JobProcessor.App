
namespace JobProcessor.Domain.Services
{
    public class IntermediaryMapper : IIntermediaryMappingService
    {
        public Models.Job MapDALToDomainModel(DataAccess.Entities.Job job) => 
            new Models.Job(job.Id, job.Name, job.StatusFlag, job.DoAfter, job.CreatedAt, job.UpdatedAt, job.ProcessedAt, job.Counter);
        
        public DataAccess.Entities.Job MapDomainToDALModel(Models.Job job) => 
            new DataAccess.Entities.Job(job.Id, job.Name, job.Status, job.DoAfter, job.CreatedAt, job.UpdatedAt, job.ProcessedAt, job.Counter);
    }
}
