using JobProcessor.DataAccess.Entities;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace JobProcessor.DataAccess.Services
{
    public interface IDbContext : IDisposable
    {
        DbSet<Job> Jobs { get; set; }
        int SaveChanges();
    }
}
