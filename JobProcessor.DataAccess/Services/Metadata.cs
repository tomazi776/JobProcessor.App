
namespace JobProcessor.DataAccess.Services
{
    public class Metadata : IPaginateable
    {
        public Metadata(int defaultstartIndex, int defaultPageSize)
        {
            StartIndex = defaultstartIndex;
            PageSize = defaultPageSize;
        }

        public Metadata() { }

        private int startIndex;
        public int StartIndex
        {
            get { return startIndex; }
            set => startIndex = (value < 0) ? 0 : value;
        }

        private int pageSize;
        public int PageSize
        {
            get { return pageSize; }
            set => pageSize = (value < 0) ? 0 : value;
        }
    }
}