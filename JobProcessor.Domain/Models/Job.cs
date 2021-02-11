using System;

namespace JobProcessor.Domain.Models
{
    public class Job
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Counter { get; set; }
        public JobStatus Status { get; set; }
        public DateTime? DoAfter { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
