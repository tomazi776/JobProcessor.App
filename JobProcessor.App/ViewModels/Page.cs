using JobProcessor.DataAccess.Services;
using System;
using System.Web.Configuration;

namespace JobProcessor.App.ViewModels
{
    public class Page
    {
        public const string startIndex = "startIndex";
        public const string pageSize = "pageSize";
        public int Number { get; set; }
        public Metadata Metadata { get; private set; } = new Metadata();
        public Page(Metadata metadata)
        {
            Metadata = metadata;
            Number = GetCurrentPageNumber(Metadata.StartIndex);
        }

        public int GetLandingPageStartIndex(int landingPage)
        {
            return landingPage * Metadata.PageSize - Metadata.PageSize;
        }

        private int GetCurrentPageNumber(int startIndex)
        {
            return GetPreviousPagesCount(startIndex, Metadata.PageSize) + 1;
        }

        private int GetPreviousPagesCount(int totalRecordsCount, int pageSize)
        {
            return (int)Math.Ceiling((decimal)totalRecordsCount / (decimal)pageSize);
        }
        public static int GetDefault(string metadata)
        {
            return (int.TryParse(WebConfigurationManager.AppSettings[$"{metadata}"], out int result)) ? result : 0;
        }
    }
}