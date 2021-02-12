using JobProcessor.DataAccess.Entities;
using System;
using System.Data.Entity;

namespace JobProcessor.DataAccess.ContextConfig
{
    public interface IDbContext : IDisposable
    {
        DbSet<Job> Jobs { get; set; }
        int SaveChanges();
    }
}
