
namespace JobProcessor.App.ViewModels
{
    public class JobsIndexMetadata : IPaginateable
    {
        public JobsIndexMetadata(int startIndex = 0, int pageSize = 0)
        {
            StartIndex = startIndex;
            PageSize = pageSize;
        }
        public int StartIndex { get; set; }
        public int PageSize { get; set; }


    }
}