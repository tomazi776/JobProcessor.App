using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobProcessor.DataAccess.Entities
{
    public class Job
    {
        public Job() { }

        public Job(Guid id, string name, JobStatus statusFlag, DateTime? doAfter, DateTime createdAt, DateTime? updatedAt, DateTime? processedAt, int counter)
        {
            Id = id;
            Name = name;
            Counter = counter;
            StatusFlag = statusFlag;
            DoAfter = doAfter;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            ProcessedAt = processedAt;
        }

        public Guid Id { get; private set; }
        [StringLength(50)]
        [Index(IsUnique = true)]
        [Required(AllowEmptyStrings = false)]
        public string Name { get; private set; }
        public int Counter { get; private set; }
        public JobStatus StatusFlag { get; private set; }
        public DateTime? DoAfter { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public DateTime? ProcessedAt { get; private set; }
    }
}
