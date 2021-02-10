using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobProcessor.DataAccess.Entities
{
    public class Job
    {
        public Guid Id { get; set; }
        [StringLength(50)]
        [Index(IsUnique = true)]
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
        public int Counter { get; set; }
        public JobStatus StatusFlag { get; set; }
        public DateTime? DoAfter { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
