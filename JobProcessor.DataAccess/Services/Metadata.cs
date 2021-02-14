
namespace JobProcessor.DataAccess.Services
{
    public class Metadata : IPaginateable
    {

        public Metadata()
        {
            SetDefaultPaginationValues();
        }

        private int startIndex;
        public int StartIndex
        {
            get { return startIndex; }
            set
            {
                if ((value < 0))
                {
                    startIndex = 0;
                }
                else
                {
                    startIndex = value;
                }
            }
        }

        private int pageSize;
        public int PageSize
        {
            get { return pageSize; }
            set => pageSize = (value < 0) ? 0 : value;
        }

        public void SetDefaultPaginationValues()
        {
            StartIndex = 0;
            PageSize = 2;
        }
    }
}