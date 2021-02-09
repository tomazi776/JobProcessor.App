
namespace JobProcessor.Domain
{
    public enum JobStatus
    {
        Failed = -1,
        New = 0,
        InProgress = 1,
        Done = 2,
        Closed = 3
    }
}
