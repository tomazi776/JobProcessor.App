using JobProcessor.DataAccess;
using System;

namespace JobProcessor.Domain.Models
{
    public class Job
    {
        public Job(Guid id, string name, JobStatus status, DateTime? doAfter, DateTime createdAt, DateTime? updatedAt, DateTime? processedAt, int counter = 0)
        {
            Id = id;
            Name = name;
            Counter = counter;
            Status = status;
            DoAfter = doAfter;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            ProcessedAt = processedAt;

        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public int Counter { get; private set; }
        public JobStatus Status { get; private set; }
        public DateTime? DoAfter { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public DateTime? ProcessedAt { get; private set; }

    }
}
