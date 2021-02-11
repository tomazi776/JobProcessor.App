
namespace JobProcessor.App.ViewModels
{
    public interface IPaginateable
    {
        int StartIndex { get; set; }
        int PageSize { get; set; }
    }
}
