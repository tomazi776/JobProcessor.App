using JobProcessor.DataAccess.Services;
using System.Data.Entity;

namespace JobProcessor.DataAccess
{
    public class JobProcessorContext : DbContext, IDbContext
    {
        public JobProcessorContext() : base("name=JobProcessorAppDbCnn")
        {

        }
    }
}
