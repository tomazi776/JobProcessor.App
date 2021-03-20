
namespace JobProcessor.DataAccess.Services
{
    public interface IPaginateable
    {
        int StartIndex { get; set; }
        int PageSize { get; set; }
    }
}
