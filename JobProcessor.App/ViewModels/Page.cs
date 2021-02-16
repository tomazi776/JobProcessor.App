using JobProcessor.DataAccess.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobProcessor.App.ViewModels
{
    public class Page
    {
        public int Number { get; set; }
        public Metadata Metadata { get; private set; } = new Metadata();
        public Page(Metadata metadata)
        {
            Metadata = metadata;
            Number = GetCurrentPageNumber(metadata.StartIndex);
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
    }
}