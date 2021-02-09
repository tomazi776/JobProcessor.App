using System;

namespace JobProcessor.DataAccess.Entities
{
    public class Job
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Counter { get; set; }
        public int StatusFlag { get; set; }
        public DateTime DoAfter { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
